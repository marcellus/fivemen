using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace Vehicle.Plugins
{
    [SimpleTable("table_vehicle_bak")]
    [Alias("车辆登记备份表")]
    public class VehicleInfoBak:VehicleInfo
    {
    }
}
