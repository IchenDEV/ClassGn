using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClassGen.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        public string ApplicationName => SystemInformation.ApplicationName;

        // To get application's version:
        public string ApplicationVersion => $"{SystemInformation.ApplicationVersion.Major}.{SystemInformation.ApplicationVersion.Minor}.{SystemInformation.ApplicationVersion.Build}.{SystemInformation.ApplicationVersion.Revision}";
        public ProcessorArchitecture OperatingSystemArchitecture => SystemInformation.OperatingSystemArchitecture;


        public AboutPage()
        {
            this.InitializeComponent();


        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRing.IsActive = true;
            var update = await Package.Current.CheckUpdateAvailabilityAsync();
            UpdateRing.IsActive = false;
            switch (update.Availability)
            {
                case PackageUpdateAvailability.Unknown:
                    UpdateStatusTextBlock.Text = "在检查更新时发生错误";
                    UpdateSymbol.Symbol = Symbol.DisconnectDrive;
                    break;
                case PackageUpdateAvailability.NoUpdates:
                    UpdateStatusTextBlock.Text = "是最新版本";
                    UpdateSymbol.Symbol = Symbol.Accept;
                    break;
                case PackageUpdateAvailability.Available:
                    UpdateStatusTextBlock.Text = "有更新";
                    UpdateSymbol.Symbol = Symbol.Refresh;
                    break;
                case PackageUpdateAvailability.Required:
                    UpdateStatusTextBlock.Text = "有更新";
                    UpdateSymbol.Symbol = Symbol.Refresh;
                    break;
                case PackageUpdateAvailability.Error:
                    UpdateStatusTextBlock.Text = "在检查更新时发生错误";
                    UpdateSymbol.Symbol = Symbol.DisconnectDrive;
                    break;
                default:
                    break;
            }
        }
    }
}
