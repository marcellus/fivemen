using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Win32;
using System.Threading;

namespace FT.Device.EncryptKeyboard
{

    
    public class KmyKeyboardTool
    {
        private int port = 1;
        private bool isOpened = false;
        public event FT.Commons.Win32.WindowFormDelegate.StringHandler keyPressStringEvent;

        //事件触发方法
        protected void OnKeyPressStringEvent(string key)
        {
            if (keyPressStringEvent != null)
                keyPressStringEvent(key);
        }

        public event FT.Commons.Win32.WindowFormDelegate.ByteHandler keyPressByteEvent;

        //事件触发方法
        protected void OnKeyPressByteEvent(byte key)
        {
            if (keyPressByteEvent != null)
                keyPressByteEvent(key);
        }

        public void WatchKeyPress()
        {
            while (true)
            {
                byte key=1;
                int result=KmyImporter.ScoutKeyPress(ref key);
                OnKeyPressByteEvent(key);
                OnKeyPressStringEvent(key.ToString());
            }
        }

        public KmyKeyboardTool(int port)
        {
            this.port = port;
        }
        public void Open()
        {
            Open(2);
        }

        

        private Thread watcherThread = null;

        public void Open(int type)
        {
            if (!isOpened)
            {
                KmyImporter.OpenPort(port, 9600);
                KmyImporter.KeyboardControl(type);
                this.isOpened = true;
                watcherThread = new Thread(new ThreadStart(WatchKeyPress));
                watcherThread.IsBackground = true;
                watcherThread.Start();
            }
        }




        public void Close()
        {
            if (isOpened)
            {
                KmyImporter.KeyboardControl(1);
                KmyImporter.ClosePort();
                if (watcherThread != null)
                {
                    watcherThread.Abort();
                }
            }
        }

        ~KmyKeyboardTool()
        {
            this.Close();
        }
    }
}
