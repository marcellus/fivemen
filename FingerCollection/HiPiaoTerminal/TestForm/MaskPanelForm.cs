using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Controls.PanelEx;

namespace HiPiaoTerminal.TestForm
{
    public partial class MaskPanelForm : Form
    {
        public MaskPanelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyOpaqueLayerTools.ShowOpaqueLayer(this.panelHeader, 60, true);
        }
    }
}
