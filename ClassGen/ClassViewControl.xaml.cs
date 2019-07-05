using ClassGen.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ClassGen
{
    public sealed partial class ClassViewControl : UserControl
    {
        string studentNum = Settings.Username;
        string studentPass = Settings.Password;
        string year = Settings.Year;
        Term term = Settings.TheTerm;

        const string apiUri = "http://api.jh.zjut.edu.cn/student/classZf.php";
        private static Color[] ccolor = new Color[] { Colors.DeepPink, Colors.Orange, Colors.DeepSkyBlue, Colors.Violet,Colors.LightCyan,Colors.SeaShell };
        private static int cindex = 0;
        private static Color GetNextColor()
        {
            Color re = ccolor[cindex];
            cindex++;
            if (cindex >= ccolor.Length)
            {
                cindex = 0;
            }
            return re;
        }

        public ClassViewControl()
        {
            this.InitializeComponent();
            /// Add BackgroundGrid as a shadow receiver and elevate the casting buttons above it
            SharedShadow.Receivers.Add(BackgroundGrid);
            GridTable.Translation += new Vector3(0, 0, 16);
            BoxShadow.Receivers.Add(BackgroundTable);

            GetTableAsync();

        }

        private async void GetTableAsync()
        {
            ErrGrid.Visibility = Visibility.Collapsed;
            try
            {
                await GetNewTable();
            }
            catch (Exception e)
            {
                ErrGrid.Visibility = Visibility.Visible;
                ErrMsg.Text = e.Message;
                pr.IsActive = false;
            }
        }

        public async Task GetNewTable()
        {
            if (String.IsNullOrEmpty(studentNum) || String.IsNullOrEmpty(studentPass))
            {
                throw new Exception("用户名或密码未输入");
            }
            if (String.IsNullOrEmpty(year) || term == 0)
            {
                throw new Exception("学期未指定");
            }

            pr.IsActive = true;
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();

            Uri requestUri = new Uri(
               String.Format(apiUri + "?username={0}&password={1}&year={2}&term={3}", studentNum, studentPass, year, (int)term)
               );
            var response = await httpClient.TryGetAsync(requestUri);



            if (!response.Succeeded) throw response.ExtendedError;

            var json = Windows.Data.Json.JsonObject.Parse(response.ResponseMessage.Content.ToString());
            var status = json.GetNamedString("status");


            pr.IsActive = false;

            if (status != "success") throw new Exception(json.GetNamedString("msg"));

            var classlist = Class.Serializer(json.GetNamedArray("msg").ToString());

            if (classlist.Count == 0) throw new Exception("暂无指定课表");

            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(String.Format("offline_{0}_{1}.json", year, (int)term), CreationCollisionOption.ReplaceExisting);
            using (var ss = await file.OpenStreamForWriteAsync())
            {
                using (StreamWriter dw = new StreamWriter(ss))
                {
                    dw.Write(json.GetNamedArray("msg").ToString());
                    dw.Flush();
                
                }
            }


            SetClassTable(classlist);
        }

        private async Task LoadOffline()
        {
            string json = "";

            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(String.Format("offline_{0}_{1}.json", year, (int)term));
            using (var ss = await file.OpenStreamForReadAsync())
            {

                using (StreamReader streamReader = new StreamReader(ss))
                {
                    json = streamReader.ReadToEnd();
                }

            }

            var classlist = Class.Serializer(json);

            SetClassTable(classlist);
        }

        private void SetClassTable(List<Class> classlist)
        {
            GridTable.Children.Clear();
            classlist.Reverse();
            int[,] book = new int[10, 20];
            foreach (var item in classlist)
            {
                ClassBox cb = new ClassBox(item, GetNextColor());
                Grid.SetColumn(cb, Convert.ToInt32(item.xqj) - 1);
                var ct = item.jcs.Split('-');
                Grid.SetRow(cb, Convert.ToInt32(ct[0]) - 1);
                cb.Margin = new Thickness(0, book[Convert.ToInt32(ct[0]) - 1, Convert.ToInt32(item.xqj) - 1] * 20, 0, 0);
                book[Convert.ToInt32(ct[0]) - 1, Convert.ToInt32(item.xqj) - 1]++;

                if (ct.Length > 1)
                {
                    Grid.SetRowSpan(cb, Convert.ToInt32(ct[1]) - Convert.ToInt32(ct[0]) + 1);
                }
                cb.Shadow = (Shadow)Table.Resources["BoxShadow"];
                cb.Translation += new Vector3(0, 0, 32);
                Canvas.SetZIndex(cb, 1);
                GridTable.Children.Add(cb);
            }
        }

        private void TryAgain_Click(object sender, RoutedEventArgs e)
        {
            GetTableAsync();
        }

        private void set_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(SettingPage));
        }

        private async void Offline_Click(object sender, RoutedEventArgs e)
        {
            ErrGrid.Visibility = Visibility.Collapsed;
            try
            {
                await LoadOffline();
            }
            catch (Exception)
            {
                ErrGrid.Visibility = Visibility.Visible;
                ErrMsg.Text = "无对应离线课表";
            }
         
        }
    }
}
