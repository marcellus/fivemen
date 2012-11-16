using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Terminal.CommonControl;
using System.Runtime.InteropServices;
using HiPiaoInterface;

namespace HiPiaoTerminal
{
    public partial class Form1 : HiPiaoTerminal.CommonForm.BaseMaskKeyForm
    {
       


        public Form1()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.smo
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.UpdateStyles();
            //this.WindowState = FormWindowState.Maximized;
            this.Width = 1280;
            this.Height = 960;
            HiPiaoCache.DeSerializedCache();
            GlobalTools.InitAll(this);
            GlobalTools.MaskFormKeyDown(this);
            //HiPiaoCache.DeSerializedCache();
            //SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //UpdateStyles();
        }

        private void btnToManagePanel_Click(object sender, EventArgs e)
        {
            /*
            UserControl panel = new MaintenancePanel();
            //panel.Anchor=AnchorStyles.
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer1.Panel1.Controls.Add(panel);
            Panel parent = this.splitContainer1.Panel1;

            panel.Location = new Point((parent.Size.Width - panel.Size.Width) / 2, (parent.Size.Height - panel.Size.Height) / 2);
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            GlobalTools.ReturnMain();
            
            
        }

       

        private void mainPanel1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            HiPiaoCache.SerializedCache();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           

        }

      
    }
}
