using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Device.EncryptKeyboard
{
    public class KmyKeyboardTool
    {
        private int port = 1;
        private bool isOpened = false;
        public KmyKeyboardTool(int port)
        {
            this.port = port;
        }
        public void Open()
        {
            if (!isOpened)
            {
                KmyImporter.OpenPort(port, 9600);
                KmyImporter.KeyboardControl(2);
                this.isOpened = true;
            }
        }

        public void Close()
        {
            if (isOpened)
            {
                KmyImporter.KeyboardControl(1);
                KmyImporter.ClosePort();
            }
        }

        ~KmyKeyboardTool()
        {
            this.Close();
        }
    }
}
