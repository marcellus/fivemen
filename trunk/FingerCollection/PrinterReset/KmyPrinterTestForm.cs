using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Win32;

namespace PrinterReset
{
    public partial class KmyPrinterTestForm : Form
    {
        public KmyPrinterTestForm()
        {
            InitializeComponent();
        }

        FT.Device.EncryptKeyboard.KmyKeyboardTool kmy=null;

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            kmy= new FT.Device.EncryptKeyboard.KmyKeyboardTool(Convert.ToInt32(this.txtPort.Text));
            kmy.keyPressByteEvent += new FT.Commons.Win32.WindowFormDelegate.ByteHandler(kmy_keyPressByteEvent);
            kmy.keyPressStringEvent += new FT.Commons.Win32.WindowFormDelegate.StringHandler(kmy_keyPressStringEvent);
            kmy.Open();
        }

        void kmy_keyPressStringEvent(string info)
        {
            WindowFormDelegate.AddMainThreadHintText(this.txtKeyResult, ";" + info);
        }

        void kmy_keyPressByteEvent(byte info)
        {
            throw new NotImplementedException();
        }

        private void btnClosePort_Click(object sender, EventArgs e)
        {
            if (kmy != null)
            {
                kmy.Close();
            }
        }

        private void btnOpenKey_Click(object sender, EventArgs e)
        {
            if (kmy != null)
            {
                kmy.Open(Convert.ToInt32(this.cbOpenKeyType.SelectedIndex+1));
            }
        }

        private void KmyPrinterTestForm_Load(object sender, EventArgs e)
        {
            this.cbOpenKeyType.SelectedIndex = 0;
        }

    }
}
