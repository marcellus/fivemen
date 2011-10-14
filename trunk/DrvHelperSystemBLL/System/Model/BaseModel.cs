using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace DrvHelperSystemBLL.System.Model
{
    public class BaseModel
    {
        public BaseModel()
        {
        }

        [SimpleColumn(Column = "i_dep_id")]
        [Alias("部门ID")]
        public int DepId;

        public int 部门ID
        {
            get { return DepId; }
            set { DepId = value; }
        }


        [SimpleColumn(Column = "i_dep_type")]
        [Alias("部门类别")]
        public int DepType;

        public int 部门类别
        {
            get { return DepType; }
            set { DepType = value; }
        }
    }
}
