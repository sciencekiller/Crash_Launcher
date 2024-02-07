using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Crash_Launcher.Services
{
    internal class AppDataService
    {
        private ApplicationDataContainer _applicationDataContainer = ApplicationData.Current.LocalSettings;
        public string GetAppData(string key)
        {
            if (_applicationDataContainer.Values[key] == null)
            {
                return string.Empty;
            }
            return _applicationDataContainer.Values[key].ToString();
        }
        public void SetAppData(string key, string value)
        {
            _applicationDataContainer.Values[key] = value;
        }
    }
}
