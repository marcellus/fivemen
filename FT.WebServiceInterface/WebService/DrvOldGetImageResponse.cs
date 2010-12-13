using System;
using System.Collections.Generic;
using System.Text;

namespace FT.WebServiceInterface.WebService
{
    public class DrvOldGetImageResponse:DrvOldBaseResponse
    {
        public override void ParseFromXml(string xml)
        {
            base.ParseFromXml(xml);
            this.zp=this.SelectNode("//zp");
        }
        public string zp;
    }
}
