using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeReview
{
    class Program
    {
        static void Main(string[] args)
        {
            //call JobLogger example
            try
            {
                JobLogger Log = new JobLogger();

                Log.LOG_CONSOLE = true;
                Log.LOG_DATABASE = true;
                Log.LOG_FILE = true;
                
                Log.LogMessage("Test Message 1", JobLogger.TypeMessage.Warning);

                Log.LOG_DATABASE = false;
                Log.LogMessage("Test Message 2", JobLogger.TypeMessage.Error);

                //this was writed for run this example
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                //this was writed for run this example
                Console.ForegroundColor = ConsoleColor.Red;
                string writeException = String.Format("Exception: {0}", ex.Message);
                Console.WriteLine(writeException);
                Console.ReadLine();
            }
        }
    }
}
