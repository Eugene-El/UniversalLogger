using System;
using System.IO;

namespace UniversalLogger
{
    public class ULogger
    {
        public ULogger()
        {
            SetStandartPath();
        }

        public string LogFilePath { get; set; }

        private void SetStandartPath()
        {
            LogFilePath = Directory.GetCurrentDirectory() + "//logs.txt";
        }

        private void WriteToFile(string log, string category)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(LogFilePath, true))
                {
                    DateTime now = DateTime.Now;
                    file.WriteLine("[{0} | {1} [{2}]] {3}", now.ToShortDateString(), now.ToLongTimeString(), category, log);
                }
            }
            catch
            {
                RepairLogger();
                WriteToFile(log, category);
            }
        }

        private void RepairLogger()
        {
            SetStandartPath();
            Error("The path for logger was incorrect!");
        }

        public void Log(string log)
        {
            WriteToFile(log, "LOG");
        }

        public void Info(string info)
        {
            WriteToFile(info, "INFO");
        }

        public void Debug(string debug)
        {
            WriteToFile(debug, "DEBUG");
        }

        public void Error(string error)
        {
            WriteToFile(error, "ERROR");
        }

        public void Custom(string log, string category)
        {
            WriteToFile(log, category);
        }

        public void Error(Exception exception)
        {
            string error = exception.Message;
            while(exception.InnerException != null)
            {
                exception = exception.InnerException;
                error += '\n' + exception.Message;
            }

            WriteToFile(error, "ERROR");
        }

    }
}
