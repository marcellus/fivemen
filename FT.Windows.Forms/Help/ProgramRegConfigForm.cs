using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.Domain;
using FT.Commons.Tools;
using FT.Commons.Security;
using FT.Commons.Cache;

namespace FT.Windows.Forms
{
    public partial class ProgramRegConfigForm : DevExpress.XtraEditors.XtraForm
    {
        public ProgramRegConfigForm()
        {
            InitializeComponent();
            FormHelper.InitHabitToForm(this);
        }

        private void ProgramRegConfigForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                ProgramRegConfig config = StaticCacheManager.GetConfig<ProgramRegConfig>();
                FormHelper.SetDataToForm(this,config);
            }
        }
    }
}