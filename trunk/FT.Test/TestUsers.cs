using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;


namespace FT.Test
{
    [SimpleTable("testusers")]
    public class TestUsers:BaseEntity
    {
        [SimpleColumn(Column="c_name")]
        public String Name;

        [SimpleColumn(Column = "c_sex")]
        public String Sex;
    }
}
