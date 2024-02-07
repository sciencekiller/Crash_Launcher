using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Crash_Launcher.Services
{
    internal class AppCultureService
    {
        public string GetCurrentCulture()
        {
            return Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride;
        } 
    }
}
