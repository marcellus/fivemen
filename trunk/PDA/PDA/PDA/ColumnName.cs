using System;

using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace PDA
{
    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Field)]
    public class ColumnNameAttribute : Attribute
    {
        private string name;
        private Types.ActionType action;

        public Types.ActionType Action
        {
            get { return action; }
            set { action = value; }
        }
        

        public ColumnNameAttribute(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return this.name == null ? string.Empty : this.name;
        }
    }
}
