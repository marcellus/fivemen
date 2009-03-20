using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Print;
using FT.Windows.Forms;
using FT.Commons.Cache;

namespace Vehicle.Plugins
{
    public class F2ExcelPrinter : BaseVehicleInfoPrinter
    {
        public F2ExcelPrinter(VehicleInfo vehicle)
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
            if (Vehicle.DyHtzbh.Length > 0)
            {
                this.PrintExcelF7();
            }
            BaseVehicleInfoPrinter printer = new F5Printer(this.Vehicle);
            CommonPrinter commonPrinter = new CommonPrinter(printer);
            //commonPrinter.ShowPreviewPrinter();
            GlobalPrintSetting printSetting = StaticCacheManager.GetConfig<GlobalPrintSetting>();
            if (printSetting.PrintModel == "直接打")
            {
                commonPrinter.Print();
            }
            else if (printSetting.PrintModel == "选择打印机")
            {
                commonPrinter.ShowPreviewPrinter();
            }
            else
            {
                commonPrinter.Preview();
            }
          //todo,excelprinteer
        }
    }
}
