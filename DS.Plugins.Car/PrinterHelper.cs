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
            dt.Rows.Add(new string[] {"�������",car.Hmhp,"����ʶ����",
                car.Identify,"��������",car.Fdjh });
            dt.Rows.Add(new string[] {"����Ʒ��",car.PinPai,"��������",
                car.CarType,"����",car.OwnerName });
            dt.Rows.Add(new string[] {"������ɫ",car.FirstColor+car.SecondColor+car.ThirdColor,"����״̬",
                car.State,"����������",car.InsuranceDate });
            dt.Rows.Add(new string[] {"�������",car.YearCheckDate,"ת������",
                car.ZrDate,"·�ѹ�������",car.RoadFeeBuyDate });
            dt.Rows.Add(new string[] {"��ͬǩ������",car.ContractDate,"��ͬǩ����",
                car.ContractPerson,"�Ƿ������",car.IsTeacherCar });

            dt.Rows.Add(new string[] {"�Ƿ��Գ�",car.IsExamCar,"",
                "","","" });

            return DataTablePrinterContent.BuildAbstractPrinterContent(dt,new int[]{120,80,120,80,120},car.Hmhp+"������Ϣ",false);
        }
    }
}
