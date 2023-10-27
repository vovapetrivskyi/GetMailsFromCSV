using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetMailsFromCSV
{
    public static class CSVReader
    {
        public static void ReadCSVFile()
        {
            Console.WriteLine("Input file location:");

            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                StringBuilder result = new StringBuilder();

                int linesCount = 0; 

                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        var values = line.Split(';');

                        linesCount++;

                        var emails = values.Where(v => IsValidEmail(v));

                        foreach (var email in emails)
                        {
                            result.AppendLine(email);
                        }
                    }
                }

                stopwatch.Stop();

                Console.WriteLine("Elapsed time: " + stopwatch.Elapsed);

                string resultString = result.ToString();

                File.WriteAllText("result.txt", resultString);

                Console.WriteLine("Result was written to result.txt");

                Console.WriteLine("Lines count: " + linesCount);

                Console.WriteLine("Emails count: " + Regex.Matches(resultString, Environment.NewLine).Count);
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }

        private static bool IsValidEmail(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }
    }
}
