using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Entity;
using FT.DAL.Orm;

namespace DS.Plugins.Car
{
    [SimpleTable("table_cars")]
    public class CarInfo
    {
        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_first_color")]
        public string FirstColor;

        [SimpleColumn(Column = "c_second_color")]
        public string SecondColor;

        [SimpleColumn(Column = "c_third_color")]
        public string ThirdColor;

        [SimpleColumn(Column = "c_identify")]
        [Alias("车辆识别码")]
        public string Identify;//识别代码

        public string 车辆识别码
        {
            get { return Identify; }
            set { Identify = value; }
        }

        [SimpleColumn(Column = "c_fdjh")]
        [Alias("发动机号")]
        public string Fdjh;//发动机号


        [SimpleColumn(Column = "c_hmhp")]
        [Alias("号码号牌")]
        public string Hmhp;//号码好牌

        public string 号码号牌
        {
            get { return Hmhp; }
            set { Hmhp = value; }
        }

        [SimpleColumn(Column = "c_cartype")]
        [Alias("车辆类型")]
        public string CarType;//车辆类型 A1 ,B1那些

        public string 车辆类型
        {
            get { return CarType; }
            set { CarType = value; }
        }

        [SimpleColumn(Column = "i_ownerid")]
        public string OwnerId;//车主ID

        [SimpleColumn(Column = "i_ownername")]
        [Alias("车主姓名")]
        public string OwnerName;//车主姓名

        public string 车主姓名
        {
            get { return OwnerName; }
            set { OwnerName = value; }
        }

        [SimpleColumn(Column = "c_pinpai")]
        [Alias("车辆品牌")]
        public string PinPai;//车辆品牌

        public string 车辆品牌
        {
            get { return PinPai; }
            set { PinPai = value; }
        }

        [SimpleColumn(Column = "c_state")]
        [Alias("车辆状态")]
        public string State;//车辆状态

        public string 车辆状态
        {
            get { return State; }
            set { State = value; }
        }

        [SimpleColumn(Column = "date_insurancedate")]
        [Alias("车保险日期")]
        public string InsuranceDate;//车保险日期

        public string 车保险日期
        {
            get { return InsuranceDate; }
            set { InsuranceDate = value; }
        }

        [SimpleColumn(Column = "date_yearcheck")]
        [Alias("年检时间")]
        public string YearCheckDate;//年检时间

        public string 年检时间
        {
            get { return YearCheckDate; }
            set { YearCheckDate = value; }
        }

        [SimpleColumn(Column = "date_zhuanru")]
        [Alias("转入时间")]
        public string ZrDate;//转入时间

        public string 转入时间
        {
            get { return ZrDate; }
            set { ZrDate = value; }
        }

        [SimpleColumn(Column = "date_roadfee")]
        [Alias("路费购买日期")]
        public string RoadFeeBuyDate;//路费购买日期

        public string 路费购买日期
        {
            get { return RoadFeeBuyDate; }
            set { RoadFeeBuyDate = value; }
        }

        [SimpleColumn(Column = "date_contract")]
        [Alias("合同签订时间")]
        public string ContractDate;//合同签订时间

        public string 合同签订时间
        {
            get { return ContractDate; }
            set { ContractDate = value; }
        }

        [SimpleColumn(Column = "c_contract_person")]
        [Alias("合同签订人")]
        public string ContractPerson;//合同签订人

        [SimpleColumn(Column = "c_is_teachercar")]
        [Alias("是否教练车")]
        public string IsTeacherCar;//是否教练车

        public string 是否教练车
        {
            get { return IsTeacherCar; }
            set { IsTeacherCar = value; }
        }

        [SimpleColumn(Column = "c_is_examcar")]
        [Alias("是否考试车")]
        public string IsExamCar;//是否考试车

        public string 是否考试车
        {
            get { return IsExamCar; }
            set { IsExamCar = value; }
        }
    }
}
