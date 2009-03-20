using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Plugins
{
    public class F6ExcelPrinter : BaseVehicleInfoPrinter
    {
        public F6ExcelPrinter(VehicleInfo vehicle)
            : base(vehicle)
        {
        }
        public override int GetTotalPage()
        {
            return 3;
            //throw new Exception("The method or operation is not implemented.");
        }

        public override System.Drawing.Image Paint()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void PaintPrinter()
        {
            this.PrintExcelF6();
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
