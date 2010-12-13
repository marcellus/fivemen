using System;
using System.Collections.Generic;
using System.Text;

namespace FT.WebServiceInterface.WebService
{
    public class DrvHealthWriteRequest:DrvBaseTmriRequest
    {
        public override string ToXml()
        {
            return string.Empty;
        }

        public string sg;
        public int zsl;
        public int ysl;
        public int tl;
        public int bsl;
        public int sz;
        public int zxz;
        public int yxz;
        public int qgjb;
        public string tjrq;
        public string tjyy;
    }
}
