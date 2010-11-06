using System;

using System.Collections.Generic;
using System.Text;

namespace PDA
{
    class CheckMain
    {
        #region 私有属性
        private string kw;
        private string pnno;
        private string cpqufen;
        private int sl;
        private int status;
        #endregion

        #region 公共属性
        public string Kw
        {
            get
            {
                return kw;
            }
            set
            {
                kw = value;
            }
        }

        public string Pnno
        {
            get
            {
                return pnno;
            }
            set
            {
                pnno = value;
            }
        }

        public string Cpqufen
        {
            get
            {
                return cpqufen;
            }
            set
            {
                cpqufen = value;
            }
        }

        public int Sl
        {
            get
            {
                return sl;
            }
            set
            {
                sl = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        #endregion

    }
}
