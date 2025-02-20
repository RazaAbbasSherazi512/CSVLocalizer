
namespace csv_localizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.CBIOS = new System.Windows.Forms.CheckBox();
            this.CBAndroid = new System.Windows.Forms.CheckBox();
            this.LblProgressed = new System.Windows.Forms.Label();
            this.csvProgressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(680, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 35);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "....";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBrowse
            // 
            this.txtBrowse.Enabled = false;
            this.txtBrowse.Location = new System.Drawing.Point(12, 3);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.Size = new System.Drawing.Size(662, 27);
            this.txtBrowse.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(872, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(90, 35);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 83);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 29;
            this.dgv.Size = new System.Drawing.Size(971, 335);
            this.dgv.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(776, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(90, 35);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // CBIOS
            // 
            this.CBIOS.AutoSize = true;
            this.CBIOS.Checked = true;
            this.CBIOS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBIOS.Location = new System.Drawing.Point(776, 48);
            this.CBIOS.Name = "CBIOS";
            this.CBIOS.Size = new System.Drawing.Size(54, 24);
            this.CBIOS.TabIndex = 5;
            this.CBIOS.Text = "IOS";
            this.CBIOS.UseVisualStyleBackColor = true;
            // 
            // CBAndroid
            // 
            this.CBAndroid.AutoSize = true;
            this.CBAndroid.Checked = true;
            this.CBAndroid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CBAndroid.Location = new System.Drawing.Point(872, 48);
            this.CBAndroid.Name = "CBAndroid";
            this.CBAndroid.Size = new System.Drawing.Size(85, 24);
            this.CBAndroid.TabIndex = 6;
            this.CBAndroid.Text = "Android";
            this.CBAndroid.UseVisualStyleBackColor = true;
            // 
            // LblProgressed
            // 
            this.LblProgressed.AutoSize = true;
            this.LblProgressed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblProgressed.Location = new System.Drawing.Point(692, 44);
            this.LblProgressed.Name = "LblProgressed";
            this.LblProgressed.Size = new System.Drawing.Size(24, 28);
            this.LblProgressed.TabIndex = 8;
            this.LblProgressed.Text = "0";
            // 
            // csvProgressBar
            // 
            this.csvProgressBar.Location = new System.Drawing.Point(12, 44);
            this.csvProgressBar.Name = "csvProgressBar";
            this.csvProgressBar.Size = new System.Drawing.Size(662, 31);
            this.csvProgressBar.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 418);
            this.Controls.Add(this.csvProgressBar);
            this.Controls.Add(this.LblProgressed);
            this.Controls.Add(this.CBAndroid);
            this.Controls.Add(this.CBIOS);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV Localizer";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.CheckBox CBIOS;
        private System.Windows.Forms.CheckBox CBAndroid;
        private System.Windows.Forms.Label LblProgressed;
        private System.Windows.Forms.ProgressBar csvProgressBar;
    }
}

