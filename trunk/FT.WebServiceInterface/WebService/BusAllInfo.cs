using System;
using System.Data;
using System.Configuration;
using FT.DAL.Orm;
namespace FT.WebServiceInterface.WebService
{
    /// <summary>
    ///BusAllInfo 的摘要说明
    /// </summary>
    [SimpleTable("table_bus_all_info")]
    [Alias("所有的业务日志")]
    public class BusAllInfo
    {
        public BusAllInfo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        [SimplePK]
        [OracleSeqAttribute(SeqName = "seq_bus_all_info")]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "c_lsh")]
        [Alias("流水号")]
        public String Lsh;

        public String 流水号
        {
            get { return Lsh; }
            set { Lsh = value; }
        }

        [SimpleColumn(Column = "c_dabh")]
        [Alias("档案编号")]
        public String Dabh;

        public String 档案编号
        {
            get { return Dabh; }
            set { Dabh = value; }
        }

        [SimpleColumn(Column = "c_xm")]
        [Alias("姓名")]
        public String Xm;

        public String 姓名
        {
            get { return Xm; }
            set { Xm = value; }
        }

        [SimpleColumn(Column = "c_idcardtype")]
        [Alias("身份证明名称")]
        public String IdCardType;

        public String 身份证明名称
        {
            get { return IdCardType; }
            set { IdCardType = value; }
        }

        [SimpleColumn(Column = "c_idcard")]
        [Alias("身份证明号码")]
        public String IdCard;

        public String 身份证明号码
        {
            get { return IdCard; }
            set { IdCard = value; }
        }


        [SimpleColumn(Column = "c_sex")]
        [Alias("性别")]
        public String Sex;

        public String 性别
        {
            get { return Sex; }
            set { Sex = value; }
        }


        [SimpleColumn(Column = "c_birthday")]
        [Alias("出生日期")]
        public String Birthday;

        public String 出生日期
        {
            get { return Birthday; }
            set { Birthday = value; }
        }

        [SimpleColumn(Column = "c_nation")]
        [Alias("国籍")]
        public String Nation;

        public String 国籍
        {
            get { return Nation; }
            set { Nation = value; }
        }


        [SimpleColumn(Column = "c_car_type")]
        [Alias("车型")]
        public String CarType;

        public String 车型
        {
            get { return CarType; }
            set { CarType = value; }
        }

        [SimpleColumn(Column = "i_state")]
        [Alias("当前状态")]
        public int State;

        public int 当前状态
        {
            get { return State; }
            set { State = value; }
        }

        [SimpleColumn(Column = "is_print_add")]
        [Alias("是否打印过申请表")]
        public int IsPrintAdd = 0;

        public int 是否打印过申请表
        {
            get { return IsPrintAdd; }
            set { IsPrintAdd = value; }
        }

        [SimpleColumn(Column = "is_print_return")]
        [Alias("是否打印过回执单")]
        public int IsPrintReturn = 0;

        public int 是否打印过回执单
        {
            get { return IsPrintReturn; }
            set { IsPrintReturn = value; }
        }

        [SimpleColumn(Column = "i_print_add")]
        [Alias("补打申请表")]
        public int PrintAdd = 0;

        public int 补打申请表
        {
            get { return PrintAdd; }
            set { PrintAdd = value; }
        }

        [SimpleColumn(Column = "i_print_return")]
        [Alias("补打回执单")]
        public int PrintReturn = 0;

        public int 补打回执单
        {
            get { return PrintReturn; }
            set { PrintReturn = value; }
        }



        [SimpleColumn(Column = "c_operator")]
        [Alias("操作者")]
        public String Operator;

        public String 操作者
        {
            get { return Operator; }
            set { Operator = value; }
        }

        [SimpleColumn(Column = "checkdate")]
        [Alias("体检日期")]
        public String CheckDate;

        public String 体检日期
        {
            get { return CheckDate; }
            set { CheckDate = value; }
        }

        [SimpleColumn(Column = "regdate", AllowInsert = false, AllowUpdate = false)]
        [Alias("操作时间")]
        public String RegDate;

        public String 操作时间
        {
            get { return RegDate; }
            set { 操作时间 = value; }
        }


        [SimpleColumn(Column = "c_regarea_code")]
        [Alias("登记住所地址代码")]
        public string RegAreaCode;

        public string 登记住所地址代码
        {
            get { return RegAreaCode; }
            set { RegAreaCode = value; }
        }

        [SimpleColumn(Column = "c_regarea")]
        [Alias("登记住所地址")]
        public string RegArea;

        public string 登记住所地址
        {
            get { return RegArea; }
            set { RegArea = value; }
        }


        [SimpleColumn(Column = "c_postcode")]
        [Alias("邮政编码")]
        public string PostCode;

        public string 邮政编码
        {
            get { return PostCode; }
            set { PostCode = value; }
        }

        [SimpleColumn(Column = "c_phone")]
        [Alias("联系电话")]
        public string Phone;

        public string 联系电话
        {
            get { return Phone; }
            set { Phone = value; }
        }

        [SimpleColumn(Column = "c_height")]
        [Alias("身高")]
        public string Height;

        public string 身高
        {
            get { return Height; }
            set { Height = value; }
        }

        [SimpleColumn(Column = "c_zsl")]
        [Alias("左视力")]
        public string Zsl;

        public string 左视力
        {
            get { return Zsl; }
            set { Zsl = value; }
        }

        [SimpleColumn(Column = "c_ysl")]
        [Alias("右视力")]
        public string Ysl;

        public string 右视力
        {
            get { return Ysl; }
            set { Ysl = value; }
        }

        [SimpleColumn(Column = "c_bsl")]
        [Alias("辨色力")]
        public string Bsl;

        public string 辨色力
        {
            get { return Bsl; }
            set { Bsl = value; }
        }

        [SimpleColumn(Column = "c_tl")]
        [Alias("听力")]
        public string Tl;

        public string 听力
        {
            get { return Tl; }
            set { Tl = value; }
        }

        [SimpleColumn(Column = "c_sz")]
        [Alias("上肢")]
        public string Sz;

        public string 上肢
        {
            get { return Sz; }
            set { Sz = value; }
        }


        [SimpleColumn(Column = "c_zxz")]
        [Alias("左下肢")]
        public string Zxz;

        public string 左下肢
        {
            get { return Zxz; }
            set { Zxz = value; }
        }


        [SimpleColumn(Column = "c_yxz")]
        [Alias("右下肢")]
        public string Yxz;

        public string 右下肢
        {
            get { return Yxz; }
            set { Yxz = value; }
        }

        [SimpleColumn(Column = "c_qgjb")]
        [Alias("躯干颈部")]
        public string Qgjb;

        public string 躯干颈部
        {
            get { return Qgjb; }
            set { Qgjb = value; }
        }


        [SimpleColumn(Column = "c_hospital")]
        [Alias("体检医院")]
        public string Hospital;

        public string 体检医院
        {
            get { return Hospital; }
            set { Hospital = value; }
        }





    }
}
