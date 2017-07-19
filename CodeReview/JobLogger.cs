using System;
using System.Linq;
using System.Text;

namespace CodeReview
{
    public class JobLogger
    {
        public const bool LOG_CONSOLE = false;
        public const bool LOG_FILE = false;
        public const bool LOG_DATABASE = false;
        private TypeMessage message;

        public JobLogger(TypeMessage message)
        {
            this.message = message;
        }
        public enum TypeMessage
        {
            Message = 1,
            Error = 2,
            Warning = 3
        }

        public static void LogMessage(string message, TypeMessage logType)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new Exception("The message is empty.");
            }

            if (!LOG_CONSOLE && !LOG_FILE && !LOG_DATABASE)
            {
                throw new Exception("Invalid configuration.");
            }
           
            Console.ForegroundColor = GetConsoleColor(logType);

            WriteLog(logType, message);//
        }

        private static ConsoleColor GetConsoleColor(TypeMessage type)
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

        private static void WriteLog(TypeMessage type, string message)
        {
            DateTime currentDateTime = DateTime.Now;
            string currentDate = currentDateTime.ToShortDateString();
            message = String.Format("type: {0} | message: {1}", type, currentDate);

            if (LOG_CONSOLE)
            {
                //write console
            }

            if(LOG_FILE)
            {
                //write file
            }

            if(LOG_DATABASE)
            {
                //write db
            }
        }
    }
}