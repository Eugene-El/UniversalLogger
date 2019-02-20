using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalLogger;

namespace TestingUniversalLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            ULogger logger = new ULogger()
            {
                LocalFilePath = "Logs\\testingLogs.txt"
            };

            logger.Debug("Test");
        }
    }
}
