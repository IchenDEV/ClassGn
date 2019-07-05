using ClassGen.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClassGen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(UserSettingPage));
            Window.Current.SetTitleBar(TitleBar);
            nvSample.SelectedItem = User;
            SharedShadow.Receivers.Add(BackgroundGrid);
            contentFrame.Translation += new Vector3(0, 0, 16);
        }

        private void NvSample_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (!contentFrame.CanGoBack) { rootFrame.GoBack(); }

            else contentFrame.GoBack();
            ElementSoundPlayer.Play(ElementSoundKind.GoBack);
        }

        private void NvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null) return;
            if (item.Tag == null) return;
            var tag = item.Tag.ToString();
           
            switch (tag)
            {
                case "AboutPage":
                    contentFrame.Navigate(typeof(AboutPage));
                    break;
                case "UserSettingPage":
                    contentFrame.Navigate(typeof(UserSettingPage));
                    break;
            }
        }
    }
}
