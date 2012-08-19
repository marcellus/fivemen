using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;

namespace FT.Commons.Tools
{
    public class SerialPortHelper:BaseHelper
    {
        public  SerialPortHelper()
        {
        }

        private HandleReturnStringDelegate hanlder;

        public void Read(HandleReturnStringDelegate handler)
        {


            if (comPort.IsOpen)
            {
                this.hanlder = handler;
                comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            }
        }

        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                //阻塞到读取数据或超时(这里为2秒)
                System.Threading.Thread.Sleep(2000);
                byte firstByte = Convert.ToByte(comPort.ReadByte());
                int bytesRead = comPort.BytesToRead;
                byte[] bytesData = new byte[bytesRead + 1];
                bytesData[0] = firstByte;
                for (int i = 1; i <= bytesRead; i++)
                    bytesData[i] = Convert.ToByte(comPort.ReadByte());
                string data = System.Text.Encoding.Default.GetString(bytesData);
                if (this.hanlder != null)
                {
                    hanlder(data);
                    data = string.Empty;
                }
                else
                {
                    SendKeys.SendWait(data);
                   
                }
            }
            catch (Exception ex)
            {
                log.Error("读取串口数据有误：" + ex.ToString());
                //MessageBox.Show(e.Message);
                //处理超时错误
            }
        }


        private SerialPort comPort;
        public bool Open(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            try
            {
                log.Debug(string.Format("准备打开串口{0},波特率{1},奇偶校验位{2},数据位{3},停止位{4}", portName, baudRate.ToString(), parity.ToString(), dataBits.ToString(), stopBits.ToString()));
                comPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                if (comPort.IsOpen)
                {
                    comPort.Close();
                }
                comPort.Open();
                log.Debug(string.Format("成功打开串口{0}！", portName));
                
                return true;
            }
            catch (Exception ex)
            {
                log.Info(string.Format("打开串口：{0}异常：{1}", portName, ex.ToString()));
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                
                if (comPort.IsOpen)
                {
                    log.Debug(string.Format("准备关闭串口{0}！", comPort.PortName));
                    comPort.Close();
                    log.Debug(string.Format("成功关闭串口{0}！", comPort.PortName));
                    
                }
                return true;
                
                
            }
            catch (Exception ex)
            {
                log.Info(string.Format("关闭串口：{0}异常：{1}", comPort.PortName, ex.ToString()));
                return false;
            }
        }

        public bool Write(string myString)
        {
            try
            {
                log.Debug("准备写入数据！");
                //System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();
               // Byte[] writeBytes = utf8.GetBytes(myString);
                Byte[] writeBytes = System.Text.Encoding.Default.GetBytes(myString);
                comPort.Write(writeBytes, 0, writeBytes.Length);
                /*
                comPort.WriteLine(myString);

                System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
                Byte[] writeBytes2 = ascii.GetBytes("你好世界ASCII");
                comPort.Write(writeBytes2, 0, writeBytes2.Length);
                 * */

                comPort.BaseStream.Flush();
                log.Debug("成功写入数据！");
            
                return true;
            }
            catch (Exception ex)
            {
                log.Info(string.Format("往串口：{0}写入数据异常：{1}",comPort.PortName,ex.ToString()));
                return false;
            }
        }

    }
}
