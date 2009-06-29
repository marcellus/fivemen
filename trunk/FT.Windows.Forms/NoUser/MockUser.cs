using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Security;

namespace FT.Windows.Forms.NoUser
{
    [Serializable]
    public class MockUser
    {
        public string Pwd;

        public MockUser()
        {
            this.Pwd = SecurityFactory.GetSecurity().Encrypt("123456");
        }
    }
}
