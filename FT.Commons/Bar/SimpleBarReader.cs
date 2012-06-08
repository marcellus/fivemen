using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Windows.Forms;

namespace FT.Commons.Bar
{
    /// <summary>
    /// �÷�
    /// </summary>
    /// <example><code>
    /// SimpleBarReader reader = new SimpleBarReader();
    /// if (!reader.StartWatching())
    ///             {
    ///                MessageBoxHelper.Show("�����������ʧ�ܣ�");
    ///            }
    ///            else
    ///            {//���û��ע����Ϣ�����������ģ����̷���
    ///                //reader.RegisterProcesser(AppendText);
    ///            }
    /// </code></example>
    public class SimpleBarReader
    {
        protected ILog log = log4net.LogManager.GetLogger("FT.Commons.Bar.SimpleBarReader");
        //public static SimpleBarReader barReader;

        private System.IO.Ports.SerialPort serialPort1;
        private BarReaderConfig config;
        public SimpleBarReader()
        {
            config = FT.Commons.Cache.StaticCacheManager.GetConfig<BarReaderConfig>();
            this.serialPort1=new System.IO.Ports.SerialPort();
            this.InitByConfig();
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }
       
        void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
            //serialPort1.ReadTimeout = 1000;
            try
            {
                //��������ȡ���ݻ�ʱ(����Ϊ2��)
                System.Threading.Thread.Sleep(config.DelayMimiTime);
                byte firstByte = Convert.ToByte(this.serialPort1.ReadByte());
                int bytesRead = this.serialPort1.BytesToRead;
                byte[] bytesData = new byte[bytesRead + 1];
                bytesData[0] = firstByte;
                for (int i = 1; i <= bytesRead; i++)
                    bytesData[i] = Convert.ToByte(this.serialPort1.ReadByte());
                string data = System.Text.Encoding.GetEncoding(config.Encoding).GetString(bytesData);
                if (this.processer != null)
                {
                    processer(data);
                    data = string.Empty;
                }
                else
                {
                    SendKeys.SendWait(data);
                    if (config.AddReturn)
                    {
                        SendKeys.SendWait("{ENTER}");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("��ȡɨ��ǹ��������"+ex.ToString());
                //MessageBox.Show(e.Message);
                //����ʱ����
            }
             
            //throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// �������ó�ʼ��
        /// </summary>
        private void InitByConfig()
        {
            BarReaderConfig config=FT.Commons.Cache.StaticCacheManager.GetConfig<BarReaderConfig>();
            this.serialPort1.PortName = config.Port;
            this.serialPort1.DataBits = config.DataBit;
            this.serialPort1.BaudRate = config.BaudRate;
            this.serialPort1.ReceivedBytesThreshold = config.ReceivedBytesThreshold;
            if (config.StopBit == 1)
            {
                this.serialPort1.StopBits = System.IO.Ports.StopBits.One;
            }
            else
            {
                this.serialPort1.StopBits = System.IO.Ports.StopBits.Two;
            }
            if (config.Parity == "��У��")
            {
                this.serialPort1.Parity = System.IO.Ports.Parity.None;
            }
            else if (config.Parity == "��У��")
            {
                this.serialPort1.Parity = System.IO.Ports.Parity.Odd;
            }
            else if (config.Parity == "żУ��")
            {
                this.serialPort1.Parity = System.IO.Ports.Parity.Even;
            }
            this.serialPort1.Encoding = System.Text.Encoding.GetEncoding(config.Encoding); 

        }

        private  ProcessBarData processer;

        /// <summary>
        /// ע�����ݴ�����
        /// </summary>
        /// <param name="processer"></param>
        public void RegisterProcesser(ProcessBarData processer)
        {

            this.processer = processer;
        }



        public  bool StartWatching()
        {
           
            if (this.serialPort1 != null && !this.serialPort1.IsOpen)
            {
                try
                {
                    this.serialPort1.Open();
                    this.state = true;
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error("�򿪶˿�"+this.serialPort1.PortName+"�쳣��"+ex.ToString());
                    this.state = false;
                    return false;
                }
            }
            this.state = false;
            return false;
        }

        public  bool StopWatching()
        {
           
            if (this.serialPort1 != null && this.serialPort1.IsOpen)
            {
                try
                {
                    this.serialPort1.Close();
                    this.state = false;
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error("�رն˿�" + this.serialPort1.PortName + "�쳣��" + ex.ToString());
                    return false;
                }
            }
            return false;
        }

        private bool state = false;
        public bool IsOpen
        {
            get { return this.state; }
           
        }
    }
}
