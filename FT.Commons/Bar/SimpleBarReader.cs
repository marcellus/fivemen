using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace FT.Commons.Bar
{
    public class SimpleBarReader
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Bar.SimpleBarReader");
        //public static SimpleBarReader barReader;

        private System.IO.Ports.SerialPort serialPort1;
        public SimpleBarReader()
        {
            this.serialPort1=new System.IO.Ports.SerialPort();
            this.InitByConfig();
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
        }

        void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            BarReaderConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<BarReaderConfig>();
            string data=string.Empty;
            //data = this.serialPort1.ReadLine();
            while(this.serialPort1.BytesToRead>0)
             data+= this.serialPort1.ReadExisting();
            if (this.processer != null)
            {
                processer(data);
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
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error("打开端口"+this.serialPort1.PortName+"异常："+ex.ToString());
                    return false;
                }
            }
            return false;
        }

        public  bool StopWatching()
        {
           
            if (this.serialPort1 != null && this.serialPort1.IsOpen)
            {
                try
                {
                    this.serialPort1.Close();
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
        public bool IsOpen
        {
            get { return this.serialPort1.IsOpen; }
           
        }
    }
}
