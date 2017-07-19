using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppConfig = System.Configuration;

namespace CodeReview.Config
{
    class Application
    {
        public Application()
        {
        }

        public string ConnectionString
        {
            get
            {
                return Properties.Settings.Default.ConnectionString;
            }
        }

        public string DirectoryPath
        {
            get
            {
                return Properties.Settings.Default.LogFileDirectory;
            }
        }
    }
}
