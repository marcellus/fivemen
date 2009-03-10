using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using FT.Windows.Forms;

namespace DS.Plugins.Car
{
    public class PrinterHelper
    {
        private PrinterHelper()
        {
        }

        public static AbstractPrinterContent PrintCarInfo(CarInfo car)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col1");
            dt.Columns.Add("col2");
            dt.Columns.Add("col3");
            dt.Columns.Add("col4");
            dt.Columns.Add("col5");
            dt.Columns.Add("col6");
            dt.Rows.Add(new string[] {"号码号牌",car.Hmhp,"车辆识别码",
                car.Identify,"发动机号",car.Fdjh });
            dt.Rows.Add(new string[] {"车辆品牌",car.PinPai,"车辆类型",
                car.CarType,"车主",car.OwnerName });
            dt.Rows.Add(new string[] {"车辆颜色",car.FirstColor+car.SecondColor+car.ThirdColor,"车辆状态",
                car.State,"车保险日期",car.InsuranceDate });
            dt.Rows.Add(new string[] {"年检日期",car.YearCheckDate,"转入日期",
                car.ZrDate,"路费购买日期",car.RoadFeeBuyDate });
            dt.Rows.Add(new string[] {"合同签订日期",car.ContractDate,"合同签订人",
                car.ContractPerson,"是否教练车",car.IsTeacherCar });

            dt.Rows.Add(new string[] {"是否考试车",car.IsExamCar,"",
                "","","" });

            return DataTablePrinterContent.BuildAbstractPrinterContent(dt,new int[]{120,80,120,80,120},car.Hmhp+"车辆信息",false);
        }
    }
}
