using System;
using System.Collections.Generic;
using System.Text;

namespace FingerCollection
{
    [Serializable]
    public class SystemConfig
    {

        /*
          _TG.HostName = this.txtHostName.Text.Trim();
            _TG.ProductID = this.txtProductID.Text.Trim();
            _TG.Port = Convert.ToInt32(this.txtPort.Text.Trim());
            _TG.AuthenID = this.txtAuthenId.Text.Trim();
            _TG.AuthenPwd = this.txtAdminPassword.Text.Trim();
            _TG.XSDevName = XSDllName[this.cboProductType.SelectedIndex];
         */

        public string HostName="127.0.0.1";

        public string ProductID="DEMO";

        public int Port=26057;

        public string AuthenID="sa";
        public string AuthenPwd="sa";
        public string XSDevName = "XSDev12.dll";

        public string SchoolName = "驾校名称";

        public string SchoolCode = "jxdm";

    }
}
