using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Device.HotPrinter;
using FT.Device.CashCode;
using FT.Device.InvoicePrinter;
using System.Threading;
using FT.Device.IDCard;
using FT.Commons.Tools;
using FT.Device.VisaCardReader;
using FT.Device.EncryptKeyboard;
//using FT.Device.IDCardWithScan;
using System.IO;

namespace ETTSelfDeviceHardTest
{
    public partial class Form1 : Form
    {
        private delegate void ThreadExecutor();//代理

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnHotOpenDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.OpenDevice(Convert.ToInt32(this.txtHotPort.Text.Trim()),msg);
            this.lbHotHint.Text = "打开设备返回code:" + i + "返回msg:" + msg;
            if (i == 0)
            {

                this.SetHotPrinter(true);
            }
        }

        private void btnHotCloseDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i=HotPrinterImporter.CloseDevice(msg);
            this.lbHotHint.Text = "关闭设备返回code:" + i + "返回msg:" + msg;
            if(i==0)
            {

                this.SetHotPrinter(false);
            }
        }

        private void SetHotPrinter(bool result)
        {
            this.btnHotChangeLine.Enabled = result;
            this.btnHotCloseDevice.Enabled = result;
            this.btnHotCutPaper.Enabled = result;
            this.btnHotGetState.Enabled = result;
            this.btnHotLineSpace.Enabled = result;
            this.btnHotNVBitmap.Enabled = result;
            this.btnHotOpenDevice.Enabled = !result;
            this.btnHotSetFont.Enabled = result;
            this.btnHotSetLeft.Enabled = result;
            this.btnHotPrintLine.Enabled = result;
        }

        private void SetCashCode(bool result)
        {
            this.btnCashCodeCloseDevice.Enabled = result;
            this.btnCashCodeIdentify.Enabled = result;
            this.btnCashCodeOpenDevice.Enabled = !result;
            this.btnCashCodeReset.Enabled = result;
        }

        private void btnHotSetLeft_Click(object sender, EventArgs e)
        {
            //HotPrinterImporter.SetLeftDistance()
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.SetLeftDistance(Convert.ToInt32(this.txtHotLeftDistance.Text.Trim()),msg);
            this.lbHotHint.Text = "设置左边距返回code:" + i + "返回msg:" + msg;
           
        }

        private void btnHotLineSpace_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.SetRowDistance(Convert.ToInt32(this.txtHotLineSpace.Text.Trim()), msg);
            this.lbHotHint.Text = "设置行间距返回code:" + i + "返回msg:" + msg;
        }

        private void btnHotPrintLine_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.PrintLine(this.txtHotPrintText.Text.Trim(), msg);
            this.lbHotHint.Text = "打印文字返回code:" + i + "返回msg:" + msg;
        }

        private void btnHotChangeLine_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.PrintLine("", msg);
            this.lbHotHint.Text = "换行返回code:" + i + "返回msg:" + msg;
        }

        private void btnHotCutPaper_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.CutPaper(msg);
            this.lbHotHint.Text = "切纸返回code:" + i + "返回msg:" + msg;
        }

        private void btnHotNVBitmap_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.PrintBitmapNV(Convert.ToInt32(this.txtHotNVIndex), 1, Convert.ToInt32(this.txtHotNVBeforeSpace), msg);
            this.lbHotHint.Text = "PrintBitmapNV返回code:" + i + "返回msg:" + msg;
        }

        private void btnHotSetFont_Click(object sender, EventArgs e)
        {
            string style = "";
            if(this.cbHotBolder.Checked)
            {
                style += "|" + this.cbHotBolder.Tag.ToString();
            }
            if (this.cbHotCharB.Checked)
            {
                style += "|" + this.cbHotCharB.Tag.ToString();
            }
            if (this.cbHotDoubleHeight.Checked)
            {
                style += "|" + this.cbHotDoubleHeight.Tag.ToString();

            }
            if (this.cbHotDoubleWeight.Checked)
            {
                style += "|" + this.cbHotDoubleWeight.Tag.ToString();
            }
            if (this.cbHotUnderLine.Checked)
            {
                style += "|" + this.cbHotUnderLine.Tag.ToString();
            }
            style=style.TrimStart('|');
            if(style.Length>0)
            {
                StringBuilder msg = new StringBuilder();
                int i = HotPrinterImporter.SetTextStyle(style, msg);
                this.lbHotHint.Text = "设置字体返回code:" + i + "返回msg:" + msg;
            }
          
        }

        private void btnHotGetState_Click(object sender, EventArgs e)
        {
             StringBuilder msg = new StringBuilder();
            int i = HotPrinterImporter.GetDeviceStatus(msg);
            this.lbHotHint.Text = "获取状态返回code:" + i + "返回msg:" + msg;

        }

        private void btnCashCodeOpenDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i =  CashCodeImporter.OpenDevice(Convert.ToInt32(this.txtCashCodePort.Text.Trim()),msg);
            this.lbCashCodeHint.Text = "打开设备返回code:" + i + "返回msg:" + msg;
            if (i == 0)
            {

                this.SetCashCode(true);
            }
        }

        private void btnCashCodeCloseDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            this.AllowAcceptMoney = false;
            CashCodeImporter.StopIdentify(msg);
            int i = CashCodeImporter.CloseDevice(msg);
            this.lbCashCodeHint.Text = "关闭设备返回code:" + i + "返回msg:" + msg;
            if (i == 0)
            {

                this.SetCashCode(false);
            }
        }

        private void btnCashCodeReset_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int result = CashCodeImporter.Reset(msg);
            this.lbCashCodeHint.Text = "复位纸币识别器返回code:" + result + "返回msg:" + msg;
        }
        private String GetCashCodeSetting()
        {
            String result = "";
            if(this.cbCashCode100.Checked)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
            if (this.cbCashCode50.Checked)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
            if (this.cbCashCode20.Checked)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
            if (this.cbCashCode10.Checked)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
            if (this.cbCashCode5.Checked)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
            if (this.cbCashCode2.Checked)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
            if (this.cbCashCode1.Checked)
            {
                result += "1";
            }
            else
            {
                result += "0";
            }
            return result;
        }
        private bool AllowAcceptMoney = false;
        private void btnCashCodeIdentify_Click(object sender, EventArgs e)
        {
             StringBuilder msg = new StringBuilder();
             int result=CashCodeImporter.StartIdentifyV2("", "", this.GetCashCodeSetting(), msg);
             this.lbCashCodeHint.Text = "准备投币返回code:" + result + "返回msg:" + msg;
             this.AllowAcceptMoney = true;
             ThreadExecutor thread = new ThreadExecutor(IdentifyMoney);
             thread.BeginInvoke(null, null);

             //Thread thread = new Thread();
            // thread.IsBackground = true;
            // thread.Start();
        }
        private void IdentifyMoney()
        {
            int result = 0;
            StringBuilder msg = new StringBuilder();
            while (AllowAcceptMoney)
            {

                result = CashCodeImporter.IdentifyV2(100, msg);
                if (result > 0)
                {
                    this.txtCashCodeResult.Text += "\r\n" + "收到" + result + "元现金！";
                }
            }
        }

        private void rbtnInvoiceBlackSettingCut_CheckedChanged(object sender, EventArgs e)
        {
            this.rbtnInvoiceImmediate.Checked = !this.rbtnInvoiceBlackSettingCut.Checked;
        }

        private void rbtnInvoiceImmediate_CheckedChanged(object sender, EventArgs e)
        {
            this.rbtnInvoiceBlackSettingCut.Checked = !this.rbtnInvoiceImmediate.Checked;
        }

        private void btnInvoiceOpenDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = InvoicePrinterImporter.OpenDevice(Convert.ToInt32(this.txtInvoicePort.Text.Trim()), msg);
            this.lbInvoiceHint.Text = "打开设备返回code:" + i + "返回msg:" + msg;
            if (i == 0)
            {
                this.EnabledButton(this.tabControl1.TabPages[2], this.btnInvoiceOpenDevice, true);
            }
        }
        private void EnableButtonCycle(Control parent,bool result)
        {
            for (int i = 0; i < parent.Controls.Count;i++ )
            {
                if(parent.Controls[i].Controls.Count>0)
                {

                    EnableButtonCycle(parent.Controls[i], result);
                }
                else
                {

                    if(parent.Controls[i] is Button)
                    {
                        parent.Controls[i].Enabled = result;
                    }
                }
            }
        }

        private void EnabledButton(Control parent,Button btn,bool result)
        {

            this.EnableButtonCycle(parent, result);
                btn.Enabled = !result;

        }

        private void btnInvoiceCloseDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = InvoicePrinterImporter.CloseDevice(msg);
            this.lbInvoiceHint.Text = "关闭设备返回code:" + i + "返回msg:" + msg;
            if (i == 0)
            {
                this.EnabledButton(this.tabControl1.TabPages[2], this.btnInvoiceOpenDevice, false);
            }
        }

        private void btnInvoiceGetState_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = InvoicePrinterImporter.GetDeviceStatus( msg);
            this.lbInvoiceHint.Text = "获取设备状态返回code:" + i + "返回msg:" + msg;
        }

        private void btnInvoiceBlackOffSet_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = InvoicePrinterImporter.SetBlackOffset(Convert.ToInt32(this.txtInvoiceLength.Text)
                ,Convert.ToInt32(this.txtInvoiceBlackMarkPosition.Text)
            ,Convert.ToInt32(this.txtInvoicePrintPostion.Text),msg);

            this.lbInvoiceHint.Text = "设置黑标位置返回code:" + i + "返回msg:" + msg;
        }

        private void btnInvoiceSettingBlackMark_Click(object sender, EventArgs e)
        {

        }

        private void btnInvoiceCancelBlackMark_Click(object sender, EventArgs e)
        {
          
        }

        private void btnInvoiceRowDistance_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = InvoicePrinterImporter.SetRowDistance(Convert.ToInt32(this.txtInvoiceRowDistance.Text.Trim()), msg);
            this.lbInvoiceHint.Text = "设置行间距返回code:" + i + "返回msg:" + msg;
        }

        private void btnInvoiceSettingFont_Click(object sender, EventArgs e)
        {
            string style = "";
            if (this.cbInvoiceBolder.Checked)
            {
                style += "|" + this.cbHotBolder.Tag.ToString();
            }
            if (this.cbInvoiceCharB.Checked)
            {
                style += "|" + this.cbHotCharB.Tag.ToString();
            }
            if (this.cbInvoiceDoubleHeight.Checked)
            {
                style += "|" + this.cbHotDoubleHeight.Tag.ToString();

            }
            if (this.cbInvoiceDoubleWidth.Checked)
            {
                style += "|" + this.cbHotDoubleWeight.Tag.ToString();
            }
            if (this.cbInvoiceUnderLine.Checked)
            {
                style += "|" + this.cbHotUnderLine.Tag.ToString();
            }
            style = style.TrimStart('|');
            if (style.Length > 0)
            {
                StringBuilder msg = new StringBuilder();
                int i = InvoicePrinterImporter.SetTextStyle(style, msg);
                this.lbInvoiceHint.Text = "设置字体返回code:" + i + "返回msg:" + msg;
            }
        }

        private void btnInvoicePositionBlackMark_Click(object sender, EventArgs e)
        {
              StringBuilder msg = new StringBuilder();
            int i = InvoicePrinterImporter.BlackMarkIdentify(msg);
            this.lbInvoiceHint.Text = "定位黑标位置返回code:" + i + "返回msg:" + msg;

        }

        private void btnInvoicePrintLine_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = InvoicePrinterImporter.PrintLine(this.txtInvoicePrintText.Text.Trim(), msg);
            this.lbInvoiceHint.Text = "打印一行返回code:" + i + "返回msg:" + msg;
        }

        private void btnInvoiceMoveInPaper_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = InvoicePrinterImporter.MovePaper(Convert.ToInt32(this.txtInvoicePaperMoveDistance.Text.Trim()), msg);
            this.lbInvoiceHint.Text = "进纸返回code:" + i + "返回msg:" + msg;
        }

        private void btnInvoiceCancelPaper_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = InvoicePrinterImporter.MovePaper(0-Convert.ToInt32(this.txtInvoicePaperMoveDistance.Text.Trim()),msg);
            this.lbInvoiceHint.Text = "退纸返回code:" + i + "返回msg:" + msg;
        }

        private void btnInvoiceCutPaper_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int flag = this.rbtnInvoiceBlackSettingCut.Checked == true ? 0 : 1;
            int i = InvoicePrinterImporter.CutPaper(flag, msg);
            this.lbInvoiceHint.Text = "切纸返回code:" + i + "返回msg:" + msg;
        }

        private IDCardReaderHelper reader = null;
        private void button1_Click(object sender, EventArgs e)
        {
            reader = new IDCardReaderHelper(new De_ReadICCardComplete(AfterReadIdCard));
        }

        private void AfterReadIdCard(IDCard card)
        {
            //TODO,所属地区代码的实现
           // card.PIC_Image;
            this.lbIdCardQfjg.Text = card.REGORG;
            this.lbIdCardYxqx.Text = card.Period_Of_Validity_CName;
            this.picIdCardImage.Image = card.PIC_Image;
            this.picIdCardImage.SizeMode = PictureBoxSizeMode.StretchImage;
            this.lbIdCardSfzmhm.Text = card.IDC;
            this.lbIDCardName.Text = card.Name;
            this.lbIdCardNational.Text = card.IDC;
           // this.InitByIdCard(this.txtIdCard.Text);
            this.lbIdCardAddress.Text = card.ADDRESS;
            this.lbIdCardBirthDay.Text = card.BIRTH.ToString("yyyy 年 MM 月 dd 日");
            this.lbIdCardSex.Text = IDCardHelper.GetSexName(card.IDC);
        }

        private void btnTTClearTrack_Click(object sender, EventArgs e)
        {
            this.txtTTTrack1.Text = "";
            this.txtTTTrack2.Text = "";
            this.txtTTTrack3.Text = "";
        }

        private void btnTTOpenDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = TTCardReaderImporter.OpenDevice(Convert.ToInt32(this.txtTTPort.Text.Trim()),msg);
            this.lbTTHint.Text = "打开设备返回code:" + i + "返回msg:" + msg;
            this.txtTTTrack1.Text = msg.ToString();
            this.txtTTTrack1.Enabled = true;
            if (i == 0)
            {
                this.EnabledButton(this.tabControl1.TabPages[5], this.btnTTOpenDevice, true);
            }
        }

        private void btnTTCloseDevice_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = TTCardReaderImporter.CloseDevice(msg);
            this.lbTTHint.Text = "关闭设备返回code:" + i + "返回msg:" + msg;
            if (i == 0)
            {
                this.EnabledButton(this.tabControl1.TabPages[5], this.btnTTOpenDevice, false);
            }
        }

        private void btnTTEnableEntry_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = TTCardReaderImporter.EnableEntry(msg);
            this.lbTTHint.Text = "允许进卡返回code:" + i + "返回msg:" + msg;
           
        }

        private void btnTTMoveCardFront_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = TTCardReaderImporter.EjectCard(msg);
            this.lbTTHint.Text = "前端退卡返回code:" + i + "返回msg:" + msg;
        }

        private void btnTTGetState_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = TTCardReaderImporter.GetDeviceStatus(msg);
            this.lbTTHint.Text = "获取状态返回code:" + i + "返回msg:" + msg;
        }

        private void btnTTCaptureCard_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = TTCardReaderImporter.CaptureCard(msg);
            this.lbTTHint.Text = "后端吞卡返回code:" + i + "返回msg:" + msg;
        }

        private void btnTTDisableEntry_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            int i = TTCardReaderImporter.DisableEntry(msg);
            this.lbTTHint.Text = "禁止进卡返回code:" + i + "返回msg:" + msg;
        }

        private void btnTTReadTrack_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder(1024);
            StringBuilder track1 = new StringBuilder(1024);
            StringBuilder track2 = new StringBuilder(1024);
            StringBuilder track3 = new StringBuilder(1024);
            int i = TTCardReaderImporter.ReadTracks(track1,track2,track3,msg);
            this.lbTTHint.Text = "读卡信息返回code:" + i +"返回msg:" + msg;
            this.txtTTTrack1.Text = track1.ToString().Trim();
            this.txtTTTrack1.Enabled = true;
            this.txtTTTrack2.Text = track2.ToString().Trim();
            this.txtTTTrack2.Enabled = true;
            this.txtTTTrack3.Text = track3.ToString().Trim();
            this.txtTTTrack3.Enabled = true;
        }


        private string GetStatusMeans(long status)
        {
            string result = string.Empty;
            switch (status)
            {
                case 0:
                    result = "STATUS_CARD_NONE";
                    break;
                case 1:
                    result = "STATUS_CARD_F_READY";
                    break;
                case 2:
                    result = "STATUS_CARD_F_SCANNING";
                    break;
                case 3:
                    result = "STATUS_CARD_R_READY";
                    break;
                case 4:
                    result = "STATUS_CARD_R_SCANNING";
                    break;
                case 5:
                    result = "STATUS_CARD_DONE";
                    break;
                case 6:
                    result = "STATUS_CARD_EJECTING";
                    break;
                case 7:
                    result = "STATUS_CARD_CONFISCATING";
                    break;
                case 8:
                    result = "STATUS_CARD_ABORT";
                    break;
                default:
                    result = "Error.";
                    break;
            }
            return result;
        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnA8OpenDevice_Click(object sender, EventArgs e)
        {
            int lRet = 0; bool result = false;
            lRet = A8ScannerReaderImporter.IO_HasScanner("IVS-600DS");
            A8ScannerReaderImporter.Sleep(100);
            if (lRet == 1)
            {
                modeA8.mode_d = 7;
                modeA8.mode_d_r = 7;
                modeA8.mode_u = 7;
                modeA8.mode_u_r = 7;
                modeA8.atuo_reverse = 0;
                lRet = A8ScannerReaderImporter.IO_SetScanModeA8(ref modeA8);
                A8ScannerReaderImporter.Sleep(100);
                if (lRet == 0)
                {
                    lRet = A8ScannerReaderImporter.IO_GetCalibData(ref CalibData);
                    if (lRet == 0)
                    {
                        btnA8OpenDevice.Enabled = false;
                        MessageBox.Show("Open Device Success.");
                    }
                    else
                    {
                        A8ScannerReaderImporter.IO_CloseDevice();
                        MessageBox.Show("Get Calib Status Failed.");
                    }
                }
                else
                {
                    A8ScannerReaderImporter.IO_CloseDevice();
                    MessageBox.Show("Set Scanmode Error." + lRet.ToString());
                }
            }
            else
            {
                A8ScannerReaderImporter.IO_CloseDevice();
                MessageBox.Show("Open Device Failed.");
            }
        }

        private void btnA8SetMode_Click(object sender, EventArgs e)
        {
            int lRet = 0;

            modeA8.mode_d = 7;
            modeA8.mode_d_r = 7;
            modeA8.mode_u = 7;
            modeA8.mode_u_r = 7;
            modeA8.atuo_reverse = 0;

            lRet = A8ScannerReaderImporter.IO_SetScanModeA8(ref modeA8);
            if (lRet == 0)
                MessageBox.Show("Set scan mode OK.");
            else
                MessageBox.Show("Set scan mode Failed.");
        }

        private void btnA8GetMode_Click(object sender, EventArgs e)
        {
            int lRet = 0;

            lRet = A8ScannerReaderImporter.IO_GetScanModeA8(ref modeA8);
            if (lRet == 0)
                txtInfo.Text = "mode_d = " + modeA8.mode_d.ToString() + "\r\n" + "mode_d_r = " + modeA8.mode_d_r.ToString() + "\r\n" + "mode_u = " + modeA8.mode_u.ToString() + "\r\n" + "mode_u_r = " + modeA8.mode_u_r.ToString() + "\r\n" + "atuo_reverse = " + modeA8.atuo_reverse.ToString();
            else
                MessageBox.Show("Get scan mode failed.");
        }

        private void btnA8Scan_Click(object sender, EventArgs e)
        {
            ScanCard();
        }


        private A8ScannerReaderImporter.SC_CALIBDATA CalibData;
        private A8ScannerReaderImporter.SC_MODEA8 modeA8;
        private int g_DPI;

        private string ByteToString(byte[] info)
        {
            string result = System.Text.Encoding.Unicode.GetString(info);
            result = result.Trim().Replace("\0", String.Empty);
            return result;
        }
        private A8ScannerReaderImporter.Id_Card pid_Card;
        private void ScanCard()
        {
            int lRet = 0;
            int w1, h1, w2, h2;
            w1 = h1 = w2 = h2 = 0;
            if (true)
            {
                pid_Card = new A8ScannerReaderImporter.Id_Card();
                lRet = A8ScannerReaderImporter.IO_ReadRFIDInfo(ref pid_Card);
                if (lRet == 0)
                {
                    this.txtInfo.Text += ByteToString(pid_Card.id_Name) + "\r\n";
                    this.txtInfo.Text += ByteToString(pid_Card.id_Sex) + "\r\n";
                    this.txtInfo.Text += ByteToString(pid_Card.id_Born) + "\r\n";
                    this.txtInfo.Text += ByteToString(pid_Card.id_Code) + "\r\n";
                    this.txtInfo.Text += ByteToString(pid_Card.id_NewAddr) + "\r\n";
                    this.txtInfo.Text += ByteToString(pid_Card.id_Home) + "\r\n";

                    this.txtInfo.Text += ByteToString(pid_Card.id_ValidPeriod) + "\r\n";
                    this.txtInfo.Text += ByteToString(pid_Card.id_RegOrg) + "\r\n";
                    this.txtInfo.Text += ByteToString(pid_Card.id_Home) + "\r\n";
                    this.txtInfo.Text += ByteToString(pid_Card.id_ValidPeriod) + "\r\n";
                    int g_DPI = (optDPI300.Checked ? 300 : 600);
                    lRet = A8ScannerReaderImporter.IO_GetImgFromUnit(g_DPI, "Picture1.bmp", ref w1, ref h1, "Picture2.bmp", ref w2, ref h2);
                    if (lRet == 0)
                    {
                        if (chkToJpg.Checked)
                        {
                            lRet = A8ScannerReaderImporter.BmpToJpeg(@"Picture1.bmp", @"Picture1.jpg");
                            if (lRet == 0) File.Delete("Picture1.bmp");

                            lRet = A8ScannerReaderImporter.BmpToJpeg(@"Picture2.bmp", @"Picture2.jpg");
                            if (lRet == 0) File.Delete(@"Picture2.bmp");
                        }
                        MessageBox.Show("Get Image From Unit Success.");
                    }
                    else
                        MessageBox.Show("Get Image From Unit Failed.");
                }
            }
            else
            {
                MessageBox.Show("请插入二代身份证");
            }

        }

        private void btnA8DeviceStatus_Click(object sender, EventArgs e)
        {
            int lRet = 0;
            long lStatus = 0;
            string result = string.Empty;

            lRet = A8ScannerReaderImporter.IO_GetDeviceStatus(ref lStatus);
            if (lRet == 0)
            {
                switch (lStatus)
                {
                    case 0:
                        result = "--ready";
                        break;
                    case 1:
                        result = "--busy";
                        break;
                    case 2:
                        result = "--calibrating";
                        break;
                    case 3:
                        result = "--reversed";
                        break;
                    case 4:
                        result = "--scanning";
                        break;
                    case 5:
                        result = "--testing motor";
                        break;
                    case 6:
                        result = "--communication error";
                        break;
                    default:
                        break;
                }
                txtInfo.Text = result;
            }
            else
                MessageBox.Show("IO_GetDeviceStauts Error");
        }

        private void btnA8CardStatus_Click(object sender, EventArgs e)
        {
            int lRet = 0;
            long lStatus = 0;

            lRet = A8ScannerReaderImporter.IO_GetCardStatus(ref lStatus);
            if (lRet != 0)
            {
                txtInfo.Text = "IO_GetCardStatus:" + lRet.ToString();
                return;
            }

            txtInfo.Text = "IO_GetCardStatus:" + lRet.ToString() + "\r\n" + GetStatusMeans(lStatus);
        }

        private void btnA8SensorStatus_Click(object sender, EventArgs e)
        {
            int lRet = 0;
            long lStatus = 0;

            lRet = A8ScannerReaderImporter.IO_GetSensorStatus(ref lStatus);
            if (lRet != 0)
            {
                txtInfo.Text = "IO_GetSensorStatus:" + lRet.ToString();
                return;
            }

            txtInfo.Text = "IO_GetSensorStatus:" + lRet.ToString() + "\r\n" + GetStatusMeans(lStatus);
        }

        private void btnA8GetChipID_Click(object sender, EventArgs e)
        {
            int lRet = 0;
            long lID = 0;

            lRet = A8ScannerReaderImporter.IO_GetChipID(ref lID);
            if (lRet == 0)
            {
                lID = lID / 65536;
                txtInfo.Text = Convert.ToString(lID, 16);
            }
            else
                MessageBox.Show("IO_GetChipID Failed.");
        }

        private void btnA8GetVersion_Click(object sender, EventArgs e)
        {
            int lRet = 0;
            string strVersion = string.Empty;

            lRet = A8ScannerReaderImporter.IO_GetVersion(strVersion);
            if (lRet == 0)
                txtInfo.Text = strVersion;
            else
                MessageBox.Show("IO_GetVersion Failed.");
        }

        private void btnA8SetCalibdata_Click(object sender, EventArgs e)
        {
            int lRet = 0;

            lRet = A8ScannerReaderImporter.IO_SetCalibdata();
            if (lRet == 0)
                MessageBox.Show("IO_SetCalibData Success.");
            else
                MessageBox.Show("IO_SetCalibData Failed.");
        }

        private void btnA8ResetDevice_Click(object sender, EventArgs e)
        {
            int lRet = 0;

            lRet = A8ScannerReaderImporter.IO_ResetDevice();
            if (lRet == 0)
                MessageBox.Show("IO_ResetDevice OK.");
            else
                MessageBox.Show("IO_ResetDevice error.");
        }

        private void btnA8ConfiscateCard_Click(object sender, EventArgs e)
        {
            int lRet = 0;

            lRet = A8ScannerReaderImporter.IO_ConfiscateCard();
            if (lRet == 0)
                MessageBox.Show("IO_ConfiscateCard OK.");
            else
                MessageBox.Show("IO_ConfiscateCard error.");
        }

        private void btnA8EjectCard_Click(object sender, EventArgs e)
        {
            int lRet = 0;

            lRet = A8ScannerReaderImporter.IO_EjectCard();
            if (lRet == 0)
                MessageBox.Show("IO_EjectCard OK.");
            else
                MessageBox.Show("IO_EjectCard error.");
        }

        private void btnA8Beep_Click(object sender, EventArgs e)
        {
            A8ScannerReaderImporter.IO_Beep(1000);
        }

        private void btnA8EnableSuckCard_Click(object sender, EventArgs e)
        {
            int lRet = 0;

            lRet = A8ScannerReaderImporter.IO_StartSuckCard();
            if (lRet == 0)
                MessageBox.Show("IO_StartSuckCard OK.");
            else
                MessageBox.Show("IO_StartSuckCard error.");
        }

        private void btnA8DisableSuckCard_Click(object sender, EventArgs e)
        {
            int lRet = 0;

            lRet = A8ScannerReaderImporter.IO_CancelSuckCard();
            if (lRet == 0)
                MessageBox.Show("IO_CancelSuckCard OK.");
            else
                MessageBox.Show("IO_CancelSuckCard error.");
        }

        private void groupBox15_Enter(object sender, EventArgs e)
        {

        }

        private void btnZtOpenDevice_Click(object sender, EventArgs e)
        {
            int ret = Zt598Importer.ZT_EPP_OpenCom(Convert.ToInt32(this.txtZtPort.Text), 9600);
            this.lbZtHint.Text = "打开串口返回code:" + ret;
            if (ret == 0)
            {
                this.EnabledButton(this.tabControl1.TabPages[4], this.btnZtOpenDevice, true);
            }

        }

        private void btnZtCloseDevice_Click(object sender, EventArgs e)
        {
            int ret = Zt598Importer.ZT_EPP_CloseCom();
            this.lbZtHint.Text = "打开串口返回code:" + ret;
            if (ret == 0)
            {
                this.EnabledButton(this.tabControl1.TabPages[4], this.btnZtOpenDevice, false);
            }
        }

        private void btnZtGetVersion_Click(object sender, EventArgs e)
        {
            StringBuilder sbVersion = new StringBuilder(255);
            StringBuilder sbSn = new StringBuilder(255);
            StringBuilder sbRechang = new StringBuilder(255);
            int ret = Zt598Importer.ZT_EPP_PinReadVersion(sbVersion, sbSn, sbRechang);

            this.lbZtHint.Text = "版本信息:" + sbVersion.ToString() + " 生产序号:"+sbSn.ToString()
                + " 描述代码" + sbRechang.ToString();
        }

        private void btnZtSetMathParam_Click(object sender, EventArgs e)
        {
            int ret = Zt598Importer.ZT_EPP_SetDesPara(Convert.ToInt32(this.txtZtMathP.Text), Convert.ToInt32(this.txtZtMathF.Text));

            this.lbZtHint.Text = "设置算法参数返回code:" + ret;
        }

        private void btnZtDownMasterKey_Click(object sender, EventArgs e)
        {
            StringBuilder cpExChk = new StringBuilder(255);
            int ret = Zt598Importer.ZT_EPP_PinLoadMasterKey(1,Convert.ToInt32(this.txtZtDownMasterKeyIndex.Text),this.txtZtDownMasterKey.Text,cpExChk);

            this.lbZtHint.Text = "下载主密钥返回code:" + ret + "检验值："+cpExChk.ToString();
        }

        private void btnZtDownWorkKey_Click(object sender, EventArgs e)
        {
            StringBuilder cpExChk = new StringBuilder(255);
            int ret = Zt598Importer.ZT_EPP_PinLoadWorkKey(1, Convert.ToInt32(this.txtZtDownMasterKeyIndex.Text), Convert.ToInt32(this.txtZtDownWorkKeyIndex.Text), this.txtZtDownWorkKey.Text, cpExChk);

            this.lbZtHint.Text = "下载工作密钥返回code:" + ret + "检验值：" + cpExChk.ToString();
        }

        private void btnZtActiveWorkKey_Click(object sender, EventArgs e)
        {
            int ret = Zt598Importer.ZT_EPP_ActivWorkPin(Convert.ToInt32(this.txtZtActiveWorkKeyMasterKeyIndex.Text), Convert.ToInt32(this.txtZtActiveWorkKeyWorkKeyIndex.Text));
            this.lbZtHint.Text = "激活工作密钥返回code:" + ret;
        }

        private void btnZtDataEncrypt_Click(object sender, EventArgs e)
        {
            string org = this.txtZtOrgData.Text.Trim();
            this.SetParam();
            if (org.Length == 0)
            {

                MessageBox.Show("源字符串的长度必须大于0！");
                this.txtZtOrgData.Focus();
                return;
            }
            if (org.Length % 16 != 0)
            {
                MessageBox.Show("源字符串的长度必须是16的倍数！");
                this.txtZtOrgData.Focus();
                return;
            }
            Zt598Importer.ZT_EPP_ActivWorkPin(this.ztMainId, this.ztWorkId);
            
            StringBuilder dest=new StringBuilder(255);
            int ret=Zt598Importer.ZT_EPP_PinAdd(this.ztPEAMode, 0, org, dest);
            this.lbZtHint.Text = "加密数据返回code:" + ret;
            this.txtZtResultData.Text = dest.ToString();
            if(ret==0)
            {

                this.txtZtResultData.Text = dest.ToString();
            }
           // this.txtZtResultData.Text += "  "+tmp.ToString();
        }
        private void SetParam()
        {
            this.ztMainId = Convert.ToInt32(this.txtZtActiveWorkKeyMasterKeyIndex.Text);
            this.ztWorkId = Convert.ToInt32(this.txtZtActiveWorkKeyWorkKeyIndex.Text);
            this.ztTimeout = Convert.ToInt32(this.txtZtEncryptTimeout.Text);
            this.ztPEAMode = Convert.ToInt32(this.txtZtEncryptPEAMode.Text);
        }
       
        private void btnZtDataDecrypt_Click(object sender, EventArgs e)
        {
            string org = this.txtZtOrgData.Text.Trim();

            this.SetParam();
            if (org.Length == 0)
            {

                MessageBox.Show("源字符串的长度必须大于0！");
                this.txtZtOrgData.Focus();
                return;
            }
            if (org.Length % 16 != 0)
            {
                MessageBox.Show("源字符串的长度必须是16的倍数！");
                this.txtZtOrgData.Focus();
                return;
            }
            Zt598Importer.ZT_EPP_ActivWorkPin(this.ztMainId, this.ztWorkId);
            StringBuilder dest = new StringBuilder(255);
            int ret = Zt598Importer.ZT_EPP_PinUnAdd(this.ztPEAMode, 0, org, dest);
            this.lbZtHint.Text = "解密数据返回code:" + ret;
            this.txtZtResultData.Text = dest.ToString();
            if (ret == 0)
            {

                this.txtZtResultData.Text = dest.ToString();
            }
        }

        private void btnZtMAC_Click(object sender, EventArgs e)
        {
            string org = this.txtZtOrgData.Text.Trim();
            this.SetParam();
            Zt598Importer.ZT_EPP_ActivWorkPin(this.ztMainId, this.ztWorkId);
            StringBuilder dest = new StringBuilder(255);
            int ret = Zt598Importer.ZT_EPP_PinCalMAC(this.ztPEAMode, 1, org, dest);
            this.lbZtHint.Text = "MAC运算数据返回code:" + ret;
            if (ret == 0)
            {

                this.txtZtResultData.Text = dest.ToString();
            }
        }

        private void btnZtSetEncryptParam_Click(object sender, EventArgs e)
        {

        }

        private void btnZtBeginUnInput_Click(object sender, EventArgs e)
        {
            this.txtZtInputData.Text = "";
            this.AllowZtInput=true;
            Zt598Importer.ZT_EPP_OpenKeyVoic(3);
             ThreadExecutor thread = new ThreadExecutor(ZtUnEncryptInput);
             thread.BeginInvoke(null, null);

        }

        private void btnZtEndUnInput_Click(object sender, EventArgs e)
        {
            this.AllowZtInput = false;
            Zt598Importer.ZT_EPP_OpenKeyVoic(0);

        }
        private bool AllowZtInput=false;

        private void ZtUnEncryptInput()
        {
            int result = 0;
            StringBuilder msg = new StringBuilder();
            while (AllowZtInput)
            {

                result = Zt598Importer.ZT_EPP_PinReportPressed(msg,100);
                if (result == 0)
                {
                    this.txtZtInputData.Text+=msg.ToString();
                }
            }
        }

        private void ZtPwdEncryptInput()
        {
            int result = 0;
            StringBuilder msg = new StringBuilder(32);
            while (AllowZtInput)
            {

                result = Zt598Importer.ZT_EPP_PinReportPressed(msg, 100);
               // this.txtZtUserPwd.Text += msg.ToString();
                if (result == 0)
                {
                    if(msg.ToString()[0]==0x08)//更正8
                    {
                        this.txtZtUserPwd.Text = "";
                        this.txtZtUserPwdEncryptResult.Text = "";
                        this.pwdNowLen = 0;
                    }
                    else if (msg.ToString()[0] == 0x0D)//确认13
                    {
                        AllowZtInput = false;
                        if (ztPinMode == 0)
                        {
                            Zt598Importer.ZT_EPP_PinLoadCardNo(this.txtZtEncryptPan.Text);
                            Zt598Importer.ZT_EPP_ActivWorkPin(this.ztMainId, this.ztWorkId);
                            Zt598Importer.ZT_EPP_SetDesPara(0x04, 0x00);
                        }
                        Zt598Importer.ZT_EPP_PinReadPin(ztPinMode == 0 ? this.ztPEAMode : 0, msg);
                        this.txtZtUserPwdEncryptResult.Text = msg.ToString();
                    }
                    else if(msg.ToString()[0]==0x1B)//取消27
                    {
                        AllowZtInput = false;
                        this.txtZtUserPwd.Text = "";
                        this.txtZtUserPwdEncryptResult.Text = "";
                    }
                    else
                    {

                    
                        this.txtZtUserPwd.Text += msg.ToString();
                        pwdNowLen++;
                        if(pwdNowLen==pwdLen)
                        {
                            AllowZtInput = false;
                            if (ztPinMode == 0)
                            {
                                Zt598Importer.ZT_EPP_PinLoadCardNo(this.txtZtEncryptPan.Text);
                                Zt598Importer.ZT_EPP_ActivWorkPin(this.ztMainId, this.ztWorkId);
                                Zt598Importer.ZT_EPP_SetDesPara(0x04,0x00);
                            }
                            Zt598Importer.ZT_EPP_PinReadPin(ztPinMode == 0 ? this.ztPEAMode : 0, msg);
                            this.txtZtUserPwdEncryptResult.Text = msg.ToString();
                        }
                    }
                }
            }
        }
        private int pwdLen=6;
        private int pwdNowLen = 0;

        private int ztPinMode = 0;
        private int ztPEAMode = 0;

        private int ztWorkId=0;
        private int ztMainId = 0;
        private int ztTimeout = 100;

        private void btnZtInputUserPwd_Click(object sender, EventArgs e)
        {
            this.SetParam();
            this.txtZtUserPwd.Text = "";
           
            this.AllowZtInput = true;

           pwdLen= Convert.ToInt32(this.txtZtEncryptLength.Text);
           pwdNowLen = 0;
           ztPinMode = this.rbZtFrontEncrypt.Checked ? 1 : 0;
           if (ztPinMode == 1)
           {
               Zt598Importer.ZT_EPP_PinLoadCardNo(this.txtZtEncryptPan.Text);
               Zt598Importer.ZT_EPP_ActivWorkPin(this.ztMainId,this.ztWorkId);
           }
            Zt598Importer.ZT_EPP_OpenKeyVoic(2);
            Zt598Importer.ZT_EPP_PinStartAdd(Convert.ToInt32(this.txtZtEncryptLength.Text), 1, ztPinMode, 0, this.ztTimeout);
            ThreadExecutor thread = new ThreadExecutor(ZtPwdEncryptInput);
            thread.BeginInvoke(null, null);
            
        }

        private void rbZtFrontEncrypt_Click(object sender, EventArgs e)
        {

        }

        private void rbZtFrontEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            this.rbZtFrontEncrypt.Checked=!this.rbZtEndEncrypt.Checked;
        }

        private void rbZtEndEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            this.rbZtEndEncrypt.Checked = !this.rbZtFrontEncrypt.Checked;
        }

        private void btnZtGetEncryptData_Click(object sender, EventArgs e)
        {
            //int ret=0x08;//8
           // int ret2 = 0x0D;//13
           // int ret3 = 0x1B;//27
           // this.txtZtInputData.Text = ret.ToString()+"-"+ret2.ToString()+"-"+ret3.ToString();

            string org = this.txtZtUserPwdEncryptResult.Text.Trim();

            this.SetParam();
           
            Zt598Importer.ZT_EPP_ActivWorkPin(this.ztMainId, this.ztWorkId);
            StringBuilder dest = new StringBuilder(255);
            int ret = Zt598Importer.ZT_EPP_PinUnAdd(this.ztPEAMode, 0, org, dest);
            this.lbZtHint.Text = "解密数据返回code:" + ret;
            
            if (ret == 0)
            {

                this.txtZtUserPwdOrg.Text = dest.ToString().Substring(2).Replace("F","");
            }

        }
       

    }
}
