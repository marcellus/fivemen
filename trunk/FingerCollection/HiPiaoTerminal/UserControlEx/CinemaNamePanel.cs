using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.ConfigModel;

namespace HiPiaoTerminal.UserControlEx
{
    public partial class CinemaNamePanel : UserControl
    {
        public CinemaNamePanel()
        {
            InitializeComponent();
        }

        private bool leftAlign = true;

        public bool LeftAlign
        {
            get { return leftAlign; }
            set { leftAlign = value; }
        }

        private int locationX;

        public int LocationX
        {
            get { return locationX; }
            set { locationX = value; }
        }
        private int locationY;

        public int LocationY
        {
            get { return locationY; }
            set { locationY = value; }
        }

        

        private void CinemaNamePanel_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.DesignMode)
                {
                    SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                    
                    this.simpleLabel1.AutoSize = true;
                    this.simpleLabel1.Text = config.Cinema;
                    
                    if (!leftAlign)
                    {
                        this.Location = new Point(this.locationX - this.simpleLabel1.Width-8, this.LocationY);
                    }
                    else
                    {
                        this.Location = new Point(this.locationX, this.LocationY);
                    }
                    this.Width = this.simpleLabel1.Width+8;
                    this.Height = 58;
                }
            }
            catch
            {
            }
        }
    }
}
