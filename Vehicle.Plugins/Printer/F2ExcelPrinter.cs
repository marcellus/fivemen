using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Print;
using FT.Windows.Forms;
using FT.Commons.Cache;
using FT.Commons.Tools;

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
            MessageBoxHelper.Show("请放入申请表正面进行打印！ ");
            this.PrintExcelF6();
            if (Vehicle.DyHtzbh.Length > 0)
            {
                MessageBoxHelper.Show("请放入抵押表进行打印！ ");
                this.PrintExcelF7();
            }
            MessageBoxHelper.Show("请放入申请表背面进行打印！ ");
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
