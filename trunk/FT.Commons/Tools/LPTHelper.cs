using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace FT.Commons.Tools
{
    public class LPTHelper : BaseHelper, ITerminalPrinter
    {
        public LPTHelper()
        {
        }

        #region inpout32相关
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(uint adress, int value);

        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern int Input(uint adress); 
        
        #endregion

        //并口打印
        #region //并口打印

        [StructLayout(LayoutKind.Sequential)]
        private struct OVERLAPPED
        {
            int Internal;
            int InternalHigh;
            int Offset;
            int OffSetHigh;
            int hEvent;
        }
        [DllImport("kernel32.dll")]
        private static extern int CreateFile(
            string FileName,          // file name
            uint DesiredAccess,       // access mode
            uint ShareMode,           // share mode
            uint SecurityAttributes,  // Security Attributes
            uint CreationDisposition, // how to create
            uint FlagsAndAttributes,  // file attributes
            int hTemplateFile         // handle to template file
            );

        [DllImport("kernel32.dll")]
        private static extern bool WriteFile(int hFile, byte[] lpBuffer, int nNumberOfBytesToWriter, out int lpNumberOfBytesWriten, out OVERLAPPED lpOverLapped);


        public unsafe int Read(byte[] buffer, int index, int count)
        {
            int n = 0;
            fixed (byte* p = buffer)
            {
                if (!ReadFile(iHandle, p + index, count, &n, 0))
                {
                    return 0;
                }
            }
            return n;
        }

        public void Read(HandleReturnStringDelegate handler)
        {
            

            if (iHandle!=-1)
            {
                // Assume that an ASCII file is being read.
                System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
                byte[] buffer = new byte[128];
                int bytesRead;
                do
                {
                    bytesRead = this.Read(buffer, 0, buffer.Length);
                    string content = Encoding.GetString(buffer, 0, bytesRead);
                    if (handler != null)
                    {
                        handler(content);
                    }
                    else
                    {
                        System.Console.Write("{0}", content);
                    }
                    //return content;
                }
                while (bytesRead > 0);

            }
           // return string.Empty;
        }

        [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
        public static extern unsafe bool ReadFile
        (
            int hFile,      // handle to file
            void* pBuffer,            // data buffer
            int NumberOfBytesToRead,  // number of bytes to read
            int* pNumberOfBytesRead,  // number of bytes read
            int Overlapped            // overlapped buffer
        );

        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(int hObject);

        private const uint GENERIC_WRITE = 0x40000000;

        private const uint GENERIC_READ = 0x80000000; 
        
        private const int OPEN_EXISTING = 3;
        /*
         case 0:
                        send = "" + (char)(27) + (char)(64) + (char)(27) + 'j' + (char)(255);    //退纸1 255 为半张纸长
                        send = send + (char)(27) + 'j' + (char)(125);    //退纸2
                        break;
                    case 1:
                        send = "" + (char)(27) + (char)(64) + (char)(27) + 'J' + (char)(255);    //进纸
                        break;
                    case 2:
                        send = "" + (char)(27) + (char)(64) + (char)(12);   //换行
                        break;
                    default:
                        send = "" + (char)(27) + (char)(64) + (char)(12);   //换行
                        break;

         */
        //lpt.Write(((char)12).ToString());   //换页
        public  bool CutPaper(string lpt)
        {
            string send = "" + (char)'\n' + (char)(29) + (char)(86) + (char)(66) + (char)(10) + (char)'\n';
            /*
            byte[] buf = new byte[send.Length];
            for (int i = 0; i < send.Length; i++)
            {
                buf[i] = (byte)send[i];
            }
             * */
            return Write(lpt, send);


            
        }
        //char  LF = (char)(10);  
		//CurrLptCtrl.Write(textBox1.Lines[i]+LF); 
        public  int GetLPTState()
        {
            return GetLPTState("lpt1");
        }

        public  int GetLPTState(string lpt)
        {
            int iHandle = 0;
            if (lpt.Length == 0)
            {
                lpt = "lpt1";
            }
            return iHandle;
        }

        public  bool Write(string myString)
        {
            log.Debug("写入并口的内容为："+myString);
            Console.WriteLine("写入并口的内容为：" + myString);
            return Write("lpt1", myString.Replace("\r",""));
        }

        

        public  bool Write(string lpt, byte[] cmdData)
        {

            if (iHandle != -1)
            {
                
                int i;
                OVERLAPPED x;

                log.Debug("准备写入并口指令！");
                //return WriteFile(iHandle, mybyte, mybyte.Length, out i, out x);
                //if (0 == FlushFileBuffers(hFile))  //如果WriteFile执行成功，这里就不需要调用   
                //{
                    //printf("Flush failed/n");
                //}  

                if (WriteFile(iHandle, cmdData, cmdData.Length, out i, out x))
                {
                    log.Debug("完成写入并口指令！");
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                log.Debug(string.Format("并口{0}并未打开！", lpt));
                return false;
            }
               
        }

        //打印函数，参数为打印机的命令或者其他文本！
        public bool Write(string lpt,string myString)
        {
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(myString);
            return Write(lpt, mybyte);
        }

        private int iHandle = 0;

        public bool Close()
        {
            try
            {
                if (iHandle != -1)
                {
                    log.Debug("准备关闭并口！");
                    CloseHandle(iHandle);
                    log.Debug("完成关闭并口！");
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Debug("关闭并口异常！"+ex);
                return false;
            }
        }

        public bool Open(string lpt)
        {
            if (lpt.Length == 0)
            {
                lpt = "lpt1";
            }
            try
            {
                iHandle = CreateFile(lpt, GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);
                if (iHandle != -1)
                {
                    log.Debug(string.Format("打开并口：{0}成功！", lpt));
                    return true;
                }
                else
                {
                    log.Info(string.Format("打开并口：{0}，打开返回句柄结果：{1}", lpt, iHandle.ToString()));
                    return false;
                }
            }
            catch (Exception ex)
            {
                log.Info(string.Format("打开并口：{0}，打开异常：{1}", lpt, ex.ToString()));
                return false;
            }
        }
        
        #endregion


        #region ITerminalPrinter 成员

        public bool Open()
        {
            return Open(string.Empty);
        }

       
        public bool HasPaper()
        {
            return true;
        }

        #endregion
    }

    public delegate void HandleReturnStringDelegate(string str);
}
