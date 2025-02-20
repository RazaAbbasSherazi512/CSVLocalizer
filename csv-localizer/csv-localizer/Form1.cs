using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using DataTable = System.Data.DataTable;
using System.Linq;
using System.ComponentModel;
using System.Threading;
using System.Globalization;
using CsvHelper;
using System.Text;
using System.Text.RegularExpressions;

namespace csv_localizer
{
    public partial class Form1 : Form
    {
        BackgroundWorker myBackgroundWorker;
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }
        private void InitializeBackgroundWorker()
        {
            myBackgroundWorker = new BackgroundWorker();
            this.myBackgroundWorker.WorkerReportsProgress = true;
            this.myBackgroundWorker.WorkerSupportsCancellation = true;
            myBackgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            myBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            myBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                fileDialog.DefaultExt = "*.resx";
                fileDialog.Filter = "resx files (*.csv)|*.csv";
                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtBrowse.Text = fileDialog.FileName;
                    if (string.Compare(Path.GetExtension(txtBrowse.Text).ToLower(), ".csv") == 0)
                    {
                        btnLoad.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
            btnLoad.Enabled = false;
            btnBrowse.Enabled = false;
            myBackgroundWorker.RunWorkerAsync();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgv.DataSource = ReadCSVByCSVHelper(txtBrowse.Text);
            btnGenerate.Enabled = true;
            DisableColumnsSorting();
        }
        private DataTable ReadCSV(string filePath)
        {
            try
            {
                var dt = new DataTable();
                foreach (var headerLine in File.ReadLines(filePath).Take(1))
                {
                    foreach (var headerItem in headerLine.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        dt.Columns.Add(headerItem.Trim());
                    }
                }
                foreach (var line in File.ReadLines(filePath).Skip(1))
                {
                    var d = line.Split(',');
                    dt.Rows.Add(line.Split(','));
                }
                return dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }

        }
        private DataTable ReadCSVByCSVHelper(string filePath)
        {
            //Encoding.GetEncoding("ISO-8859-1")
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                using (var dr = new CsvDataReader(csv))
                {
                    var dt = new DataTable();
                    dt.Load(dr);
                    return dt;
                }
            }
        }
        private void DisableColumnsSorting()
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void Generate(BackgroundWorker backgroundWorker)
        {
            const int keyIndex = 0;
            int FilesProcessed = 0;
            Regex reg = new Regex("[']");

            int fileLength = CBAndroid.Checked && CBIOS.Checked ? 2 : 1;
            int TotalFilesToProcess = (dgv.ColumnCount - 1) * fileLength;

            for (var colIndex = 1; colIndex < dgv.ColumnCount; colIndex++)
            {
                Dictionary<string, string> keyValuePairsAndroid = new Dictionary<string, string>();
                Dictionary<string, string> keyValuePairsIOS = new Dictionary<string, string>();

                var folderName = dgv.Columns[colIndex].HeaderText;
                for (int rowIndex = 0; rowIndex < dgv.Rows.Count; rowIndex++)
                {
                    var value = dgv.Rows[rowIndex].Cells[colIndex].Value.ToString().Trim();
                    string newValue = reg.Replace(value, @"\'");
                    var key = dgv.Rows[rowIndex].Cells[keyIndex].Value.ToString().Trim();
                    keyValuePairsIOS.Add(key, value);
                    keyValuePairsAndroid.Add(key, newValue);
                }
                if (CBIOS.Checked)
                {
                    WriteLocalized(folderName, IOSFormate(keyValuePairsIOS), "IOS");
                    FilesProcessed++;
                }
                if (CBAndroid.Checked)
                {
                    WriteLocalized(folderName, AndroidFormate(keyValuePairsAndroid), "Android");
                    FilesProcessed++;
                }
                int totalProgress = (int)((double)FilesProcessed / TotalFilesToProcess * 100);
                Thread.Sleep(100);
                backgroundWorker.ReportProgress(totalProgress);
            }
        }
        private void WriteLocalized(string folderName, string keyValue, string OS)
        {
            folderName = OS == "IOS" ? $"{folderName}.lproj" : $"values-{folderName}";
            var WhichOS = OS == "Android" ? "strings" : "Localizable";
            var WhichExtension = OS == "Android" ? ".xml" : ".strings";

            var root = AppDomain.CurrentDomain.BaseDirectory + OS + "\\Resources";
            var SubDir = root + "\\" + folderName + "\\";

            var filePath = SubDir + "\\" + WhichOS + WhichExtension;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            if (!Directory.Exists(SubDir))
            {
                Directory.CreateDirectory(SubDir);
            }
            File.WriteAllText(filePath, keyValue,Encoding.UTF8);
            //using (StreamWriter writer = File.AppendText(filePath))
            //{
            //    writer.Write(keyValue.ToString());
            //}
        }
        private string AndroidFormate(Dictionary<string, string> keyValuePairs)
        {
            const string quote = "\"";
            // xml formate for android localize
            //<resources>
            //< string name = "app_name" > RSL\nMonitor </ string >
            //</resources>
            var xml = $"<?xml version={quote}1.0{quote} encoding={quote}utf-8{quote}?>{Environment.NewLine}<resources>";
            foreach (var item in keyValuePairs)
            {
                xml += $"{Environment.NewLine}<string name={quote}{item.Key}{quote}>{item.Value}</string>";
            }
            xml += $"{Environment.NewLine}</resources>";
            return xml;
        }
        private string IOSFormate(Dictionary<string, string> keyValuePairs)
        {
            //IOS Localize.strings Formate Type
            //"Key"="Value"
            //e.g "Device Information" = "Device Information"; 
            const string quote = "\"";
            string strings = string.Empty;
            foreach (var item in keyValuePairs)
            {
                strings += $"{quote}{item.Key}{quote}={quote}{item.Value}{quote}{";"}{Environment.NewLine}";
            }
            return strings;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Generate(worker);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            csvProgressBar.Value = e.ProgressPercentage;
            // Set the text.
            LblProgressed.Text = e.ProgressPercentage.ToString();

        }
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //myToolStripStatusLabel.Text = "Translation Cancelled...";
                csvProgressBar.Value = csvProgressBar.Maximum;
            }
            else if (e.Error != null)
            {
                // myToolStripStatusLabel.Text = "Error...";
                MessageBox.Show("Error while Translating..!" + e.Result.ToString(), "CSV Localizer");
            }
            else
            {
                MessageBox.Show("Translation finished. Please check the corresponding resx files.", "CSV Localizer");
                DialogResult res = MessageBox.Show("Do You Want me to Open Localized Files", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    var root = AppDomain.CurrentDomain.BaseDirectory;
                    var psi = new System.Diagnostics.ProcessStartInfo() { FileName = root, UseShellExecute = true };
                    System.Diagnostics.Process.Start(psi);
                }
            }
            btnGenerate.Enabled = true;
            btnLoad.Enabled = true;
            btnBrowse.Enabled = true;
        }
    }
}
