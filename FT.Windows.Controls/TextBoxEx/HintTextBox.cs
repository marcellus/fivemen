using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace FT.Windows.Controls.TextBoxEx
{
    public partial class HintTextBox : SimpleTextBox
    {
        public HintTextBox()
        {
            InitializeComponent();
            //this.Text = this.hint;
           // this.Text = "12314";
            //this.SetHint();
            this.Enter += new EventHandler(HintTextBox_Enter);
            this.Leave += new EventHandler(HintTextBox_Leave);
            //this.KeyUp += new System.Windows.Forms.KeyEventHandler(HintTextBox_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(HintTextBox_KeyDown);
            this.TextChanged += new EventHandler(HintTextBox_TextChanged);
           // this.KeyDown += new System.Windows.Forms.KeyEventHandler(HintTextBox_KeyDown);
        }

       

        public void OnTextChangedEx(EventArgs e)
        {
            this.OnTextChanged(e);
        }

        void HintTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ((57 >= e.KeyValue && e.KeyValue >= 48) || (90 >= e.KeyValue && e.KeyValue >= 65) || (122 >= e.KeyValue & e.KeyValue >= 97))
            {
                if (this.Text != hint)
                {
                    //this.Text += e.KeyCode.ToString();
                }
                else
                {
                    //this.Text = e.KeyCode.ToString();
                    this.HideHint();
                }
            }
        }

        public bool HasValue
        {
            get
            {
                return this.Text != hint;
            }
        }

        void HintTextBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //97-122;65-90;48-57
            
        }

        
/*
        void HintTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(e.)
        }
 * */

        void HintTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Focused)
            {
                if (this.Text.Trim() == this.hint)
                {
                    this.HideHint();
                }
            }
            else
            {
                if (this.Text.Trim().Length == 0)
                {
                    this.SetHint();
                }

            }
        }


        void HintTextBox_Leave(object sender, EventArgs e)
        {
            if (this.Text.Trim().Length == 0)
            {
                this.SetHint();
            }
        }

       

        void HintTextBox_Enter(object sender, EventArgs e)
        {
            /*
            if (this.Text != hint)
            {
                this.HideHint();
            }
            */
        }



        private char tempPasswordChar;

        public char TempPasswordChar
        {
            get { return tempPasswordChar; }
            set { tempPasswordChar = value; }
        }

        public void HideHint()
        {
            this.PasswordChar = this.tempPasswordChar;
            this.Text = string.Empty;
            this.ForeColor = System.Drawing.Color.Black;
        }

        public void SetHint()
        {
           this.PasswordChar = '\0';
           this.Text = hint;
           this.ForeColor = System.Drawing.Color.FromArgb(198,198,198);
        }

        public string GetRealText()
        {
            if (this.Text == this.hint)
                {
                    return string.Empty;
                }
         
                return this.Text;
        }

        public override string Text
        {
            get
            {
                /*
                if (base.Text == this.hint)
                {
                    return string.Empty;
                }
                 */
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        private string hint=string.Empty;

        /// <summary>
        /// 提示语
        /// </summary>
        public string Hint
        {
            get { return hint; }
            set { 
                
                hint = value;
                if (hint!=null&&hint.Length > 0)
                {
                    this.SetHint();
                }
            
            }
        }

        

       
    }
}
