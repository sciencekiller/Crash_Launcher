using Crash_Launcher.Services;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;
using WinUIEx;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Crash_Launcher
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplashScreen : WinUIEx.SplashScreen
    {
        private Type launchType;
        public SplashScreen(Type window):base(window)
        {
            InitializeComponent();
            launchType = window;
            ExtendsContentIntoTitleBar = true;
            WindowService<WinUIEx.SplashScreen> windowService = new WindowService<WinUIEx.SplashScreen>(this);
            windowService.UseMica(true,false);
        }
        protected override async Task OnLoading()
        {
        }
    }
}
