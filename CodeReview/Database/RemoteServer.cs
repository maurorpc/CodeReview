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

        public RemoteServer() : base(connectionString)
        {
            //this.OnCreated();
        }

        public bool NewLog(int type, string message = null)
        {
            try
            {
                using (RemoteServer db = new RemoteServer())
                {
                    Log newLog = new Log()
                    {
                        message = message,
                        type = type,
                        datetime = DateTime.Now
                    };
                    db.Logs.InsertOnSubmit(newLog);
                    db.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
