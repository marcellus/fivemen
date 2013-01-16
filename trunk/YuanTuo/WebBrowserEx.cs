using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalIeForm
{
    public class WebBrowserEx:System.Windows.Forms.WebBrowser
    {
        protected override void WndProc(ref   System.Windows.Forms.Message m)       
        {           
            switch (m.Msg)            
            {   
                case 0x201:   //   WM_LMOUSEBUTTON                 
                case 0x204:               
                case 0x207:                
                case 0x21:                   
                base.DefWndProc(ref   m);                    
                return;            
            }            
            base.WndProc(ref   m);       
        } 
    }
}
