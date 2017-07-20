using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramSettings = System.Configuration.ConfigurationSettings;
using ManageFile = System.IO.File;
using System.IO;

namespace CodeReview.FileManager
{
    class LogFile
    {
        private string directoryPath = new Config.Application().DirectoryPath;
        bool success = false;
        public bool Success
        {
            get
            {
                return success;
            }
        }

        public LogFile()
        {
        }

        public void NewLog(string dateString, string message, string prefix = "LogFile_", string extension = "txt")
        {
            try
            {
                string fileName = String.Format("{0}{1}{2}{3}{4}", prefix, "_", dateString, ".", extension);
                string fileDirectory = directoryPath + fileName;
                if (!ManageFile.Exists(fileDirectory))
                {
                    var textfile = ManageFile.Create(fileDirectory);
                    textfile.Close();
                }

                using (TextWriter file = new StreamWriter(fileDirectory))
                {
                    file.WriteLine(message);
                    file.Close();
                }

                success = true;
            }
            catch
            {
                success = false;
            }
        }



    }
}
