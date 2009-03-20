using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Plugins
{
    public class F4Printer : BaseVehicleInfoPrinter
    {
        public F4Printer(VehicleInfo vehicle)
            : base(vehicle)
        {
        }
        public override int GetTotalPage()
        {
            return 1;
            //throw new Exception("The method or operation is not implemented.");
        }

        public override System.Drawing.Image Paint()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void PaintPrinter()
        {
            if (this.GetCurrentPage() == 1)
            {
                this.PrintF4();

            }
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
