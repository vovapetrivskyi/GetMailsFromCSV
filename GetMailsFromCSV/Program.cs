
using GetMailsFromCSV;
using System.Runtime.CompilerServices;

try
{
    CSVReader.ReadCSVFile();
}
catch (Exception ex)
{
    Console.WriteLine("Error. View log_file.txt");

    Logger.LogException(ex);
}

