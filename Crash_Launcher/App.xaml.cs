using Crash_Launcher.Services;
using Microsoft.UI.Xaml;
using WinUIEx;
using Crash_Launcher.Startup;
using System.Diagnostics;
using Microsoft.UI.Xaml.Controls;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Crash_Launcher
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public SplashScreen splash {  get; set; }
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            AppSettingService appSettingService = new AppSettingService();
            var settings=appSettingService.GetUncompletedSettings();
            Trace.WriteLine(settings.Count);
            
            if(settings.Count> 0)
            {
                splash = new SplashScreen(typeof(Startup.Startup));
            }
            splash.Completed += (s, e) => m_window = e;

        }
        private Window m_window;
    }
}
