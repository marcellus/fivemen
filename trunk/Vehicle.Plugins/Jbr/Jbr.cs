using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace Vehicle.Plugins
{
    [SimpleTable("table_jbr")]
    [Alias("经办人信息")]
    public class Jbr:FT.DAL.Entity.Person
    {
    }
}
