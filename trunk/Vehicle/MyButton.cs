using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Vehicle
{
    public class MyButton:System.Windows.Forms.Button
    {
        private static Font defaultFont = new Font("ËÎÌו", 15, FontStyle.Bold | FontStyle.Italic);

        public MyButton()
        {
            base.Font = defaultFont;
        }

       /* 
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]   
        public override Font Font
        {
            get
            {
                return base.Font;
                //if (Font != null) return Font;
                //else return defaultFont;
            }
            set
            {
                base.Font = value;
            }
        }*/

        public bool ShouldSerializeFont()
        {
            return Font != null;
            //return !Font.Equals(defaultFont);
        }

        public override void ResetFont()
        {
            Font = new Font("ËÎÌו", 15, FontStyle.Bold | FontStyle.Italic); 
        }

    }
}
