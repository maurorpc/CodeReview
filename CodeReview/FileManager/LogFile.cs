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
        private string prefix;
        private string message;
        private string extension;
        private string filename;
        private string dateString;
        private bool success = false;

        public bool Success
        {
            get
            {
                return success;
            }
        }


        public LogFile(string dateString, string message, string prefix = "LogFile_", string extension = "txt")
        {
            this.dateString = dateString;
            this.message = message;
            this.prefix = prefix;
            this.extension = extension;
        }

        public void NewLog()
        {

            //create file manager to logfile
            /*if (!System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt"))
            {
                l = System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt");
            }*/
            // l = l + DateTime.Now.ToShortDateString() + message; method to log
            string fileName = String.Format("{0}{1}{2}{3}{4}", prefix, "_", dateString, ".", extension);
            string fileDirectory = directoryPath + fileName;
            if(!ManageFile.Exists(fileDirectory))
            {
                ManageFile.Create(fileDirectory);
            }

            using (TextWriter tw = new StreamWriter(fileDirectory))
            {
                tw.WriteLine(message);
                tw.Close(); 
            }

            success = true;
            //trycatch
        }



    }
}
