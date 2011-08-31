using System;
using System.Data;
using System.Configuration;
namespace FT.WebServiceInterface.DrvQuery
{

    /// <summary>
    ///TempStudentInfo 的摘要说明
    /// </summary>
    /// 
    [Serializable]
    public class TempStudentInfo
    {
        public TempStudentInfo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public String lsh;
        public String name;
        public String zkcx;
        public String jxmc;
        public String jxdm;
        public String idCard;
        public String idCardType;

        public String jly;

        public String yxqs;
        public String yxqz;
        public String phone;
        public String address;
        public String sex;
        public String mobile;

        public String birthday;
    }
}
