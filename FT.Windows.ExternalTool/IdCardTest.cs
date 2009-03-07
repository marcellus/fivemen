using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Device.IDCard;


namespace FT.Windows.ExternalTool
{
    public partial class IdCardTest : Form
    {
       Timer timer;

        private delegate void BindControlDelegate();        // 创建委托和委托对象
        private BindControlDelegate bindControlDelegate;

        private IDCardReader reader;

        private CV100UReader cvReader;

        private void TimerCall(Object obj)
        {
           
        }

        private void Read()
        {
            reader.ReadICCard();
        }
        
        public IdCardTest()
        {
            bindControlDelegate = new BindControlDelegate(Read);
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            InitializeComponent();
            reader = new IDCardReader();

            reader.ReadICCardComplete += new IDCardReader.De_ReadICCardComplete(reader_ReadICCardComplete);
            cvReader = new CV100UReader();
            cvReader.AfterReadICCardComplete += new CV100UReader.ReadICCardComplete(cvReader_AfterReadICCardComplete);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Read();
            //throw new Exception("The method or operation is not implemented.");
        }

        void cvReader_AfterReadICCardComplete(IDCard card)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void reader_ReadICCardComplete(IDCard card)
        {
            this.txtName.Text = card.Name;
            this.txtSex.Text = card.Sex_CName;
            this.txtRace.Text = card.NATION_CName;
            this.txtBirthday.Text = card.BIRTH.ToShortDateString();
            this.txtAddress.Text = card.ADDRESS;
            this.txtDateBegin.Text = card.STARTDATE.ToShortDateString();
            this.txtDateEnd.Text = card.ENDDATE.ToShortDateString();
            this.txtNewData.Text = card.Period_Of_Validity_CName;
            this.pictureBox1.Image=card.PIC_Image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reader.ReadICCard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cvReader.Read();
            cvReader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox tbTemp;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                tbTemp=this.Controls[i] as TextBox;
                if (tbTemp != null)
                {
                    tbTemp.Text = "";
                }
            }
        }

        private void IdCardTest_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}