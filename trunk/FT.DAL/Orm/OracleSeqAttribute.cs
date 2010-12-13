using System;
using System.Collections.Generic;
using System.Text;

namespace FT.DAL.Orm
{
    [AttributeUsage(AttributeTargets.Field)]
    public class OracleSeqAttribute:Attribute
    {
        public OracleSeqAttribute()
        {
        }
        private string seqname;

        public string SeqName
        {
            get { return seqname; }
            set { seqname = value; }
        }
    }
}
