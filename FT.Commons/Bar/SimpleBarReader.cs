using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Windows.Forms;

namespace FT.Commons.Bar
{
    /// <summary>
    /// 用法
    /// </summary>
    /// <example><code>
    /// SimpleBarReader reader = new SimpleBarReader();
    /// if (!reader.StartWatching())
    ///             {
    ///                MessageBoxHelper.Show("启动条码监听失败！");
    ///            }
    ///            else
    ///            {//如果没有注册消息处理器，则会模拟键盘发送
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
                //阻塞到读取数据或超时(这里为2秒)
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
                log.Error("读取扫描枪数据有误："+ex.ToString());
                //MessageBox.Show(e.Message);
                //处理超时错误
            }
             
            //throw new Exception("The method or operation is not implemented.");
        }
        /// <summary>
        /// 根据配置初始化
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
            if (config.Parity == "无校验")
            {
                this.serialPort1.Parity = System.IO.Ports.Parity.None;
            }
            else if (config.Parity == "奇校验")
            {
                this.serialPort1.Parity = System.IO.Ports.Parity.Odd;
            }
            else if (config.Parity == "偶校验")
            {
                this.serialPort1.Parity = System.IO.Ports.Parity.Even;
            }
            this.serialPort1.Encoding = System.Text.Encoding.GetEncoding(config.Encoding); 

        }

        private  ProcessBarData processer;

        /// <summary>
        /// 注册数据处理器
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
                    log.Error("打开端口"+this.serialPort1.PortName+"异常："+ex.ToString());
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
                    log.Error("关闭端口" + this.serialPort1.PortName + "异常：" + ex.ToString());
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
