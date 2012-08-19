using System;
using System.Collections.Generic;

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
using System.Windows.Forms;
using HiPiaoTerminal.Wpf;

namespace HiPiaoTerminal.UserRegister
{
    /// <summary>
    /// UserRegisterSuccessWpf.xaml 的交互逻辑
    /// </summary>
    public partial class UserRegisterSuccessWpf : System.Windows.Controls.UserControl,IParentWpfWindows
    {
        public UserRegisterSuccessWpf()
        {
            InitializeComponent();
        }
        private Form parent;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);

           
            
            window.Close();

            if (parent != null)
            {
                parent.Close();
            }
           
        }

        #region IParentWpfWindows 成员

        public void Register(Form form)
        {
            this.parent = form;
        }

        #endregion
    }
}
