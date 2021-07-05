/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.IO;

string appPath = System.AppDomain.CurrentDomain.BaseDirectory;
string appPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
//Ex:
string backup_excel_file_path = System.AppDomain.CurrentDomain.BaseDirectory + "backup_excel.xlsx";
if (!File.Exists(backup_excel_file_path))
{
	MessageBox.Show("backup_excel.xlsx file does not exist in the current directory!");
}
//Ex:
string fileName = @"c:\temp\Mahesh.txt";
if (File.Exists(fileName))
    Console.WriteLine("File exists.");
else
    Console.WriteLine("File does not exist.");
//Ex:
string fileName = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\backup_excel.xlsx";
if (!File.Exists(fileName))
    MessageBox.Show("Backup Excel File doest not exists.");
	
	
	string text = System.IO.File.ReadAllText(@"E:\Lable.prn");
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

