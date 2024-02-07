using Crash_Launcher.Services;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System.Collections.Generic;
using WinUIEx;
using Crash_Launcher.Startup.Settings;
using System;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Crash_Launcher.Startup
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Startup : WindowEx
    {
        private List<string> UncompletedSettings = new List<string>();
        private List<Type> Settings = new List<Type>();
        private int totalSetting;
        private int currentSetting = 1;
        public Startup()
        {

            InitializeComponent();
            UncompletedSettings = Data.settings;
            ExtendsContentIntoTitleBar = true;
            WindowService<WindowEx> windowService = new WindowService<WindowEx>(this);
            windowService.SetScaleAndCenterOnScreen(0.6);
            windowService.UseMica(true, false);
            this.SetIsResizable(false);
            totalSetting = UncompletedSettings.Count;
            GetPages();
            SettingFrame.Navigate(Settings[0], null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }
        private void GetPages()
        {
            if (UncompletedSettings.Count == new AppSettingService().TotalSetting)
            {
                Settings.Add(typeof(Welcome));
                totalSetting++;
            }
            foreach (var item in UncompletedSettings)
            {
                switch (item)
                {
                    case "AppCulture":
                        Settings.Add(typeof(AppCulture));
                        break;
                    case "DataPath":
                        Settings.Add(typeof(DataPath));
                        break;
                }
            }
        }

        private void BackButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (currentSetting == totalSetting)
            {
                FinishButton.Visibility = Visibility.Collapsed;
                NextButton.Visibility = Visibility.Visible;
            }
            if (currentSetting == 2)
            {
                BackButton.Visibility = Visibility.Collapsed;
            }
            var willVisible = currentSetting - 2;
            currentSetting--;
            SettingFrame.Navigate(Settings[willVisible], null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromLeft });
        }

        private void NextButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            if (currentSetting == totalSetting - 1)
            {
                NextButton.Visibility = Visibility.Collapsed;
                FinishButton.Visibility = Visibility.Visible;
            }
            if (currentSetting == 1)
            {
                BackButton.Visibility = Visibility.Visible;
            }
            var willVisible = currentSetting;
            currentSetting++;
            SettingFrame.Navigate(Settings[willVisible], null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void FinishButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
   
        }
    }
}
