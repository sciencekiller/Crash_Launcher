using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WinUIEx;

namespace Crash_Launcher.Services
{
    internal class WindowService<T>
        where T:Window
    {
        private T window;
        public WindowService(T _window) { 
            window = _window;

        }
        public void SetScaleAndCenterOnScreen(double scale)
        {
            var screenHeight = DisplayArea.Primary.WorkArea.Height;
            var screenWidth= DisplayArea.Primary.WorkArea.Width;
            var windowHeight = screenHeight * scale;
            var windowWidth = screenWidth * scale;
            window.SetWindowSize(windowWidth, windowHeight);
            window.CenterOnScreen();
        }
        public void UseMica(bool fallbackToArcrylic = true,bool useMicaAlt=true)
        {
            if (MicaController.IsSupported())
            {
                if (useMicaAlt)
                {
                    window.SystemBackdrop = new MicaBackdrop() { Kind = MicaKind.BaseAlt };
                }
                else
                {
                    window.SystemBackdrop = new MicaBackdrop();
                }
            }
            else if(fallbackToArcrylic)
            {
                window.SystemBackdrop = new DesktopAcrylicBackdrop();
            }
        }
    }
}
