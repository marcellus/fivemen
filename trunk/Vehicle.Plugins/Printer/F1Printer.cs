using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Plugins
{
    public class F1Printer : BaseVehicleInfoPrinter
    {
        public F1Printer(VehicleInfo vehicle)
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
            if (this.GetCurrentPage() == 1)
            {
                this.PrintF3();

            }
            else if (this.GetCurrentPage() == 2)
            {
                this.PrintF4();

            }
            else if (this.GetCurrentPage() == 3)
            {
                this.PrintF5();

            }
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
