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

    }
}
