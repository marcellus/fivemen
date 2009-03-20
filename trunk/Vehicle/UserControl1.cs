using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Vehicle
{
    public partial class UserControl1 : UserControl


    {
        private static Font defaultFont=new Font("ËÎÌו",15,FontStyle.Bold);
        public UserControl1()
        {
            InitializeComponent();
        }

        //[DefaultValue(]

        public override System.Drawing.Font Font
        {
            get
            {
                return (base.Font);
            }
            set
            {
                if (value == null)
                    base.Font = defaultFont;
                else
                {
                    if (value == System.Windows.Forms.Control.DefaultFont)
                        base.Font = defaultFont;
                    else
                        base.Font = value;
                }
            }
        }

        public override void ResetFont()
        {
            Font = null;
        }

        private bool ShouldSerializeFont()
        {
            return (!Font.Equals(defaultFont));
        }

    }
}
