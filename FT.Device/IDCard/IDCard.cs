using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Drawing;

namespace FT.Device.IDCard
{
    /// <summary>
    /// 二代证的信息类
    /// </summary>
    public class IDCard
    {
        private SortedList lstMZ = new SortedList();
        private string _Name;   //姓名
        private string _Sex_Code;   //性别代码
        private string _Sex_CName;   //性别
        private string _IDC;      //身份证号码
        private string _NATION_Code;   //民族代码
        private string _NATION_CName;   //民族
        private DateTime _BIRTH;     //出生日期
        private string _ADDRESS;    //住址
        private string _REGORG;     //签发机关
        private DateTime _STARTDATE;    //身份证有效起始日期
        private DateTime _ENDDATE;    //身份证有效截至日期
        private string _Period_Of_Validity_Code;   //有效期限代码，许多原来系统上面为了一代证考虑，常常存在这样的字段，二代证中已经没有了
        private string _Period_Of_Validity_CName;   //有效期限
        private byte[] _PIC_Byte;    //照片二进制
        private Image _PIC_Image;   //照片

        public IDCard()
        {
            lstMZ.Add("01", "汉族");
            lstMZ.Add("02", "蒙古族");
            lstMZ.Add("03", "回族");
            lstMZ.Add("04", "藏族");
            lstMZ.Add("05", "维吾尔族");
            lstMZ.Add("06", "苗族");
            lstMZ.Add("07", "彝族");
            lstMZ.Add("08", "壮族");
            lstMZ.Add("09", "布依族");
            lstMZ.Add("10", "朝鲜族");
            lstMZ.Add("11", "满族");
            lstMZ.Add("12", "侗族");
            lstMZ.Add("13", "瑶族");
            lstMZ.Add("14", "白族");
            lstMZ.Add("15", "土家族");
            lstMZ.Add("16", "哈尼族");
            lstMZ.Add("17", "哈萨克族");
            lstMZ.Add("18", "傣族");
            lstMZ.Add("19", "黎族");
            lstMZ.Add("20", "傈僳族");
            lstMZ.Add("21", "佤族");
            lstMZ.Add("22", "畲族");
            lstMZ.Add("23", "高山族");
            lstMZ.Add("24", "拉祜族");
            lstMZ.Add("25", "水族");
            lstMZ.Add("26", "东乡族");
            lstMZ.Add("27", "纳西族");
            lstMZ.Add("28", "景颇族");
            lstMZ.Add("29", "柯尔克孜族");
            lstMZ.Add("30", "土族");
            lstMZ.Add("31", "达翰尔族");
            lstMZ.Add("32", "仫佬族");
            lstMZ.Add("33", "羌族");
            lstMZ.Add("34", "布朗族");
            lstMZ.Add("35", "撒拉族");
            lstMZ.Add("36", "毛南族");
            lstMZ.Add("37", "仡佬族");
            lstMZ.Add("38", "锡伯族");
            lstMZ.Add("39", "阿昌族");
            lstMZ.Add("40", "普米族");
            lstMZ.Add("41", "塔吉克族");
            lstMZ.Add("42", "怒族");
            lstMZ.Add("43", "乌孜别克族");
            lstMZ.Add("44", "俄罗斯族");
            lstMZ.Add("45", "鄂温克族");
            lstMZ.Add("46", "德昂族");
            lstMZ.Add("47", "保安族");
            lstMZ.Add("48", "裕固族");
            lstMZ.Add("49", "京族");
            lstMZ.Add("50", "塔塔尔族");
            lstMZ.Add("51", "独龙族");
            lstMZ.Add("52", "鄂伦春族");
            lstMZ.Add("53", "赫哲族");
            lstMZ.Add("54", "门巴族");
            lstMZ.Add("55", "珞巴族");
            lstMZ.Add("56", "基诺族");
            lstMZ.Add("57", "其它");
            lstMZ.Add("98", "外国人入籍");
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Sex_Code
        {
            get { return _Sex_Code; }
            set
            {
                _Sex_Code = value;
                switch (value)
                {
                    case "1":
                        Sex_CName = "男";
                        break;
                    case "2":
                        Sex_CName = "女";
                        break;
                }
            }
        }
        public string Sex_CName
        {
            get { return _Sex_CName; }
            set { _Sex_CName = value; }
        }
        public string IDC
        {
            get { return _IDC; }
            set { _IDC = value; }
        }
        public string NATION_Code
        {
            get { return _NATION_Code; }
            set
            {
                _NATION_Code = value;
                if (lstMZ.Contains(value))
                    NATION_CName = lstMZ[value].ToString();
            }
        }
        public string NATION_CName
        {
            get { return _NATION_CName; }
            set { _NATION_CName = value; }
        }
        public DateTime BIRTH
        {
            get { return _BIRTH; }
            set { _BIRTH = value; }
        }
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }
        public string REGORG
        {
            get { return _REGORG; }
            set { _REGORG = value; }
        }
        public DateTime STARTDATE
        {
            get { return _STARTDATE; }
            set { _STARTDATE = value; }
        }
        public DateTime ENDDATE
        {
            get { return _ENDDATE; }
            set
            {
                _ENDDATE = value;
                if (_ENDDATE == DateTime.MaxValue)
                {
                    _Period_Of_Validity_Code = "3";
                    _Period_Of_Validity_CName = "长期";
                }
                else
                {
                    if (_STARTDATE != DateTime.MinValue)
                    {
                        switch (value.AddDays(1).Year - _STARTDATE.Year)
                        {
                            case 5:
                                _Period_Of_Validity_Code = "4";
                                _Period_Of_Validity_CName = "5年";
                                break;
                            case 10:
                                _Period_Of_Validity_Code = "1";
                                _Period_Of_Validity_CName = "10年";
                                break;
                            case 20:
                                _Period_Of_Validity_Code = "2";
                                _Period_Of_Validity_CName = "20年";
                                break;
                        }
                    }
                }

            }
        }
        public string Period_Of_Validity_Code
        {
            get { return _Period_Of_Validity_Code; }
            set { _Period_Of_Validity_Code = value; }
        }
        public string Period_Of_Validity_CName
        {
            get { return _Period_Of_Validity_CName; }
            set { _Period_Of_Validity_CName = value; }
        }
        public byte[] PIC_Byte
        {
            get { return _PIC_Byte; }
            set { _PIC_Byte = value; }
        }
        public Image PIC_Image
        {
            get { return _PIC_Image; }
            set { _PIC_Image = value; }
        }



    }

}
