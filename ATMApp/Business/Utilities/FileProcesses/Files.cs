using ATMApp.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Business.Utilities.FileProcesses
{
    public static class Files
    {
        public static void WriteToFile(string message)
        {
            string path = $@"{Environment.CurrentDirectory}\Logs\Date_{DateTime.Now.ToShortDateString()}.txt";

            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(message);
            }

        }

        public static void ReadFromFile()
        {
            Console.WriteLine("\n**************** Gün Sonu Raporu *****************\n");
            string path = $@"{Environment.CurrentDirectory}\Logs\Date_{DateTime.UtcNow.ToShortDateString()}.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
