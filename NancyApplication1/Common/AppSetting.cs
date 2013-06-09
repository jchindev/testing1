using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AppSetting
    {
        public static string EspnApiKey = ConfigurationManager.AppSettings["espnApiKey"];

        public static string EspnHeadlinesUrl = ConfigurationManager.AppSettings["EspnHeadlinesUrl"];

        public static string BlogEngineBaseUrl = ConfigurationManager.AppSettings["BlogEngineBaseUrl"];
    }
}
