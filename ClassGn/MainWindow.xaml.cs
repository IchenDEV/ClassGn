using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClassGn
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<CExam, Grid> dics = new Dictionary<CExam, Grid>();
        private int cindex = 0;
        private Color[] ccolor = new Color[] { Colors.DeepPink, Colors.Orange, Colors.DeepSkyBlue, Colors.Violet };
        string tempPath = AppDomain.CurrentDomain.BaseDirectory + "data.txt";

        public MainWindow()
        {
            InitializeComponent();
            
            if (File.Exists(tempPath))
            {
                try
                {
                    TbkInput.Text = File.ReadAllText(tempPath);
                }
                catch (Exception)
                {
                }
            }
        }

        private void TbkInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] data = TbkInput.Text.Split('\n');
            ClearCExam();
            foreach (var item in data)
            {
                CExam c = ParseCExam(item);
                if (c!=null)
                {
                    AddCExam(c);
                }
            }
        }

        private Color Get_NextColor()
        {
            Color re = ccolor[cindex];
            cindex++;
            if (cindex >= ccolor.Length)
            {
                cindex = 0;
            }
            return re;
        }
        /// <summary>
        /// 生成一个课表元素
        /// </summary>
        /// <param name="exam"></param>
        /// <returns></returns>
        private void AddCExam(CExam exam)
        {
            Grid grid = new Grid();
            Rectangle rectangle = new Rectangle();
            rectangle.Fill = new SolidColorBrush(Get_NextColor());
            rectangle.RadiusX = 2;
            rectangle.RadiusY = 2;
            grid.Children.Add(rectangle);
            TextBlock tbxDect = new TextBlock();
            tbxDect.VerticalAlignment = VerticalAlignment.Top;
            tbxDect.Padding = new Thickness(5);
            tbxDect.Text = exam.Dest;
            tbxDect.FontSize = 14;
            tbxDect.TextWrapping = TextWrapping.Wrap;
            tbxDect.Foreground = Brushes.White;
            tbxDect.TextAlignment = TextAlignment.Center;
            grid.Children.Add(tbxDect);
            TextBlock tbxDetail = new TextBlock();
            tbxDetail.Margin = new Thickness(0, 35, 0, 0);
            tbxDetail.Padding = new Thickness(3);
            tbxDetail.VerticalAlignment = VerticalAlignment.Center;
            tbxDetail.TextAlignment = TextAlignment.Center;
            tbxDetail.FontSize = 12;
            tbxDetail.TextWrapping = TextWrapping.Wrap;
            tbxDetail.Foreground = Brushes.White;
            tbxDetail.Text = exam.Title + ":" + exam.Teacher;
            grid.Children.Add(tbxDetail);
            dics.Add(exam, grid);

            int h = 2 * (exam.DayOfWeek - 1);
            int vStart = 2 * (exam.TimeStart - 1);
            int vSpan = 2 * (exam.TimeEnd - exam.TimeStart) + 1;

            GridTable.Children.Add(grid);
            Grid.SetColumn(grid, h);
            Grid.SetRow(grid, vStart);
            Grid.SetRowSpan(grid, vSpan);
        }
        private void ClearCExam()
        {
            foreach (var item in dics)
            {
                GridTable.Children.Remove(item.Value);
            }
            dics.Clear();
            cindex = 0;
        }
        private CExam ParseCExam(string text)
        {
            try
            {
                string[] d = text.Split(' ');
                int dayOfWeek = int.Parse(d[0]);
                if (dayOfWeek <= 0 || dayOfWeek > 7)
                {
                    return null;
                }
                string[] dTime = d[1].Split('-');
                int timeStart = int.Parse(dTime[0]);
                int timeEnd = int.Parse(dTime[1]);
                if (timeStart <= 0 || timeEnd > 13 || timeStart > timeEnd)
                {
                    return null;
                }
                string dest = d[2].Trim();
                string title = d[3].Trim();
                string teacher = d[4].Trim();
                if (dest=="" || title == "" || teacher == "")
                {
                    return null;
                }
                return new CExam(dayOfWeek,timeStart,timeEnd,dest,title,teacher);
            }
            catch (Exception)
            {
                return null;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                File.WriteAllText(tempPath, TbkInput.Text);
            }
            catch (Exception)
            {
            }
        }
    }

    class CExam
    {
        public CExam(int dayOfWeek, int timeStart, int timeEnd, string dest, string title, string teacher)
        {
            DayOfWeek = dayOfWeek;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Dest = dest;
            Title = title;
            Teacher = teacher;
        }

        /// <summary>
        /// 星期几，有效值为1-7。
        /// </summary>
        public int DayOfWeek { get;}
        public int TimeStart { get;  }
        public int TimeEnd { get; }
        public string Dest { get;  }
        public string Title { get; }
        public string Teacher { get;  }
    }
}
