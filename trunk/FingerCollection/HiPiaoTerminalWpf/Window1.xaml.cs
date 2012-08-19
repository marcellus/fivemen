using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HiPiaoTerminalWpf
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //VisualTreeHelper.get
           // this.WindowState = WindowState.Maximized;
           // WpfGlobalTools.InitAll(this);
          //  WpfGlobalTools.ReturnMain();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            FirstRoundWindow window = new FirstRoundWindow();
            window.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SecondRoundWindow window = new SecondRoundWindow();
            window.ShowDialog();
           // window.add
        }
    }
}
