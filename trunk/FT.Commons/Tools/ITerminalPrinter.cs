using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.Tools
{
    public interface ITerminalPrinter
    {
        bool Open();
        bool Open(string port);
        bool Close();
        bool Write(string str);
        bool HasPaper();
    }
}
