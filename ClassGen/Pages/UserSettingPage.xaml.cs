using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace ClassGen.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserSettingPage : Page
    {
        public UserSettingPage()
        {
            this.InitializeComponent();
            if(Settings.Username != null)
            {
                username.Text= Settings.Username;
               
            }
            if(Settings.Password != null)
            {
                password.Text = Settings.Password;
            }

            if (Settings.Year!= null)
            {
                year.Text = Settings.Year;
            }

            if (Settings.TheTerm != 0)
            {
                switch (Settings.TheTerm)
                {
                    case Model.Term.first:
                        ter.SelectedIndex = 0;
                        break;
                    case Model.Term.seconed:
                        ter.SelectedIndex = 1;
                        break;
                    case Model.Term.shor:
                        ter.SelectedIndex = 2;
                        break;
                    default:
                        break;
                }
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(sender is TextBox)
            {
                Settings.Username = (sender as TextBox).Text;
            }
          
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                Settings.Password = (sender as TextBox).Text;
            }
        }

        private void year_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                Settings.Year = (sender as TextBox).Text;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vb = sender as ComboBox;
            switch (vb.SelectedIndex)
            {
                case 0:
                    Settings.TheTerm = Model.Term.first;
                    break;
                case 1:
                    Settings.TheTerm = Model.Term.seconed;
                    break;
                case 2:
                    Settings.TheTerm = Model.Term.shor;
                    break;
                default:
                    break;
            }
        }
    }
}
