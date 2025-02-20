# CSVLocalizer
CSV Localizer is a Windows Forms application that simplifies the process of generating localized resource files for Android and iOS applications. It reads a CSV file containing localization keys and values, processes the data, and exports properly formatted resource files for both platforms.

Features ✨
✔️ CSV File Parsing – Uses CsvHelper to read and display CSV content in a DataGridView.
✔️ Localization Key Processing – Extracts keys and values to create platform-specific files.
✔️ Android & iOS Support – Generates strings.xml for Android and Localizable.strings for iOS.
✔️ Background Processing – Uses BackgroundWorker to prevent UI freezing during file generation.
✔️ Progress Tracking – Displays progress with a progress bar and percentage updates.
✔️ Automated Folder & File Creation – Saves localized files in structured directories.
✔️ Open Output Directory – Prompts users to open the output folder after completion.

How It Works 🛠️
Load a CSV File: Click the "Browse" button and select a CSV file with localization keys.
Display CSV Data: The file's content appears in a DataGridView.
Generate Localization Files: Click "Generate" to create resource files for selected platforms.
Check Output: The program stores the files in the /Android/Resources/ and /iOS/Resources/ directories.
CSV Format Example 

CSV Format Example 📑
Key	en	fr	de
app_name	My App	Mon App	Meine App
welcome_message	Hello!	Bonjour!	Hallo!

Android (values-fr/strings.xml)
xml
Copy
Edit
<?xml version="1.0" encoding="utf-8"?>
<resources>
    <string name="app_name">Mon App</string>
    <string name="welcome_message">Bonjour!</string>
</resources>
iOS (fr.lproj/Localizable.strings)
plaintext
Copy
Edit
"app_name" = "Mon App";
"welcome_message" = "Bonjour!";
Technologies Used 🏗️
C# (.NET Framework, WinForms)
CsvHelper (for reading CSV files)
BackgroundWorker (for non-blocking execution)
Installation & Usage 🚀
Clone the Repository:
sh
Copy
Edit
git clone https://github.com/yourusername/csv-localizer.git
Open in Visual Studio and build the solution.
Run the application and select a CSV file.
Generate localized files and check the output folders.