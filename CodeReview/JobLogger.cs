using System;
using System.Linq;
using System.Text;

namespace CodeReview
{
    public class JobLogger
    {
        public bool LOG_CONSOLE = false;
        public bool LOG_FILE = false;
        public bool LOG_DATABASE = false;

        public JobLogger()
        {
        }

        /// <summary>
        /// Enum none is for default value of enum, but is not valid
        /// </summary>
        public enum TypeMessage
        {
            None = 0, //default value
            Message = 1,
            Error = 2,
            Warning = 3
        }

        public void LogMessage(string message, TypeMessage logType)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new Exception("The message is empty.");
            }

            if(logType == TypeMessage.None)
            {
                throw new Exception("You must set the type log.");
            }


            if (!LOG_CONSOLE && !LOG_FILE && !LOG_DATABASE)
            {
                throw new Exception("Invalid configuration.");
            }

            WriteLog(logType, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">Type of message Warning</param>
        /// <param name="message">Message string.</param>
        private void WriteLog(TypeMessage type, string message)
        {
            Console.ForegroundColor = GetConsoleColor(type);
            DateTime currentDateTime = DateTime.Now;
            string currentDate = currentDateTime.ToString(Common.Culture.DateFormat); //this replace ToShortDateString()
            string logString = String.Format("type: {0} | date: {1} | message: {2}", (int)type, currentDate, message);

            if (LOG_CONSOLE)
            {
                Console.WriteLine(logString);
            }

            if(LOG_FILE)
            {
                FileManager.LogFile file = new FileManager.LogFile();
                file.NewLog(currentDate, logString);
                if (!file.Success)
                {
                    throw new Exception("Error while executing file manager.");
                }
            }

            if(LOG_DATABASE)
            {
                Database.RemoteServer db = new Database.RemoteServer();
                db.NewLog((int)type, message, currentDateTime);
                if(!db.Success)
                {
                    throw new Exception("Error while executing database server.");
                }

            }
        }


        private ConsoleColor GetConsoleColor(TypeMessage type)
        {
            //get default color
            ConsoleColor color = Console.ForegroundColor;

            switch (type)
            {
                case TypeMessage.Error:
                    color = ConsoleColor.Red;
                    break;
                case TypeMessage.Message:
                    color = ConsoleColor.White;
                    break;
                case TypeMessage.Warning:
                    color = ConsoleColor.Yellow;
                    break;
            }

            return color;
        }
    }
}