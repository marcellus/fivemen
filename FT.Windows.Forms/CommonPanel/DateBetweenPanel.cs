using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;

namespace FT.Windows.Forms.CommonPanel
{
    public partial class DateBetweenPanel : UserControl
    {
        public DateBetweenPanel()
        {
            InitializeComponent();
        }

        public DateTime BeginDate
        {
            get
            {
                return this.dateBegin.Value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.dateEnd.Value;
            }
        }

        private void checkWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkWeek.Checked)
            {
                this.dateBegin.Value = DateTimeHelper.GetMonday();
                this.dateEnd.Value = DateTimeHelper.GetSunday();
                this.checkMonth.Checked = this.checkSeason.Checked = !this.checkWeek.Checked;
            }
        }

        private void checkMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkMonth.Checked)
            {
                this.dateBegin.Value = DateTimeHelper.GetMonthFirstDay();
                this.dateEnd.Value = DateTimeHelper.GetMonthLastDay();
                this.checkWeek.Checked = this.checkSeason.Checked = !this.checkMonth.Checked;
            }
        }

        private void checkSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkSeason.Checked)
            {
                this.dateBegin.Value = DateTimeHelper.GetSeasonFirstDay();
                this.dateEnd.Value = DateTimeHelper.GetSeasonLastDay();
                this.checkWeek.Checked = this.checkMonth.Checked = !this.checkSeason.Checked;
            }
        }
    }
}
