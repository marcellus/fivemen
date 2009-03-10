using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace DS.Plugins.Car
{
    [SimpleTable("table_car_owner")]
    [Alias("车主信息表")]
    public class CarOwner:Person
    {
    }
}
