using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramSettings = System.Configuration.ConfigurationSettings;

namespace CodeReview.Database
{
    class RemoteServer : LogsDataContext
    {
        private static string connectionString = new Config.Application().ConnectionString;
        private bool success = false;
        public bool Success
        {
            get
            {
                return success;
            }
        }
        public RemoteServer() : base(connectionString)
        {
            //this.OnCreated();
        }

        public void NewLog(int type, string message, DateTime datetime)
        {
            try
            {
                using (RemoteServer db = new RemoteServer())
                {
                    Log newLog = new Log()
                    {
                        message = message,
                        type = type,
                        datetime = datetime
                    };
                    db.Logs.InsertOnSubmit(newLog);
                    db.SubmitChanges();
                }
                success = true;
            }
            catch
            {
                //
            }
        }

    }
}
