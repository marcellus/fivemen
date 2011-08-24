using System;
using System.Collections.Generic;
using System.Text;

namespace FT.WebServiceInterface.WebService
{
    class DrvStudentInfoRequest:DrvBaseTmriRequest
    {

 

        private string sfzmhm;


        public string SFZMHM {

            get { return this.sfzmhm; }
            set { this.sfzmhm = value; }
        }

        public override string ToXml()
        {
            StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sb.Append("<root>");
            sb.Append("<QueryCondition>");
            this.AppendTag(sb, "sfzmhm", this.sfzmhm);
            sb.Append("</QueryCondition>");
            sb.Append("</root>");
            return sb.ToString();
        }
    }
}
