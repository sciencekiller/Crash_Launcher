using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crash_Launcher.Services
{
    internal class AppSettingService
    {
        public AppSettingService()
        {
            TotalSetting = 2;
        }
        public List<string> GetUncompletedSettings()
        {
            List<string> settings = new List<string>();
            AppDataService appDataService = new AppDataService();
            if (string.IsNullOrEmpty(appDataService.GetAppData("AppCulture")))
            {
                settings.Add("AppCulture");
            }
            if (string.IsNullOrEmpty(appDataService.GetAppData("DataPath")))
            {
                settings.Add("DataPath");
            }
            Data.settings = settings;
            return settings;
        }
        public int TotalSetting { get; set; }
    }
}
