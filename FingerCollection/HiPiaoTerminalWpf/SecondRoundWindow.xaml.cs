﻿using System;
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
using System.Windows.Shapes;

namespace HiPiaoTerminalWpf
{
    /// <summary>
    /// SecondRoundWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SecondRoundWindow : Window
    {
        public SecondRoundWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.windowBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(125, 183, 0));
        }
    }
}
