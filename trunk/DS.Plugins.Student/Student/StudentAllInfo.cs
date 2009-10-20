using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    /// <summary>
    /// 所有的学生信息，用来系统集成
    /// </summary>
    [Serializable]
    public class StudentAllInfo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex = string.Empty;

        /// <summary>
        /// 出生年月
        /// </summary>
        public string Birthday = string.Empty;

        /// <summary>
        /// 国籍名称
        /// </summary>
        public string NationString = string.Empty;

        /// <summary>
        /// 国籍代码
        /// </summary>
        public string NationCode = string.Empty;

        /// <summary>
        ///  身份证明名称字符串
        /// </summary>
        public string IdCardTypeString = string.Empty;

        /// <summary>
        ///  身份证明名称代码
        /// </summary>
        public string IdCardTypeCode = string.Empty;

        /// <summary>
        ///  身份证明号码
        /// </summary>
        public string IdCard = string.Empty;

        /// <summary>
        /// 暂住证明号码
        /// </summary>
        public string TempId = string.Empty;

        /// <summary>
        /// 证件地址的省份字符串
        /// </summary>
        public string RegProvinceString = string.Empty;

        /// <summary>
        /// 证件地址的省份区划代码
        /// </summary>
        public string RegProvinceCode = string.Empty;

        /// <summary>
        /// 证件地址的市区字符串
        /// </summary>
        public string RegCityString = string.Empty;


        /// <summary>
        /// 证件地址的市区区划代码
        /// </summary>
        public string RegCityCode = string.Empty;

        /// <summary>
        /// 证件地址的地区字符串
        /// </summary>
        public string RegAreaString = string.Empty;

        /// <summary>
        /// 证件地址的地区区划代码
        /// </summary>
        public string RegAreaCode = string.Empty;

        /// <summary>
        /// 证件地址的联系地址字符串
        /// </summary>
        public string RegAddress = string.Empty;

        /// <summary>
        /// 所属辖区的字符串
        /// </summary>
        public string BelongAreaString = string.Empty;

        /// <summary>
        /// 所属辖区的联系字符串
        /// </summary>
        public string BelongAreaCode = string.Empty;

        /// <summary>
        /// 联系地址的街道
        /// </summary>
        public string Xiang = string.Empty;

        /// <summary>
        /// 联系地址的村居委
        /// </summary>
        public string Cun = string.Empty;

        /// <summary>
        /// 联系地址的字符串
        /// </summary>
        public string ConnAddress = string.Empty;

        /// <summary>
        /// 联系电话1
        /// </summary>
        public string Phone1 = string.Empty;

        /// <summary>
        /// 联系电话二
        /// </summary>
        public string Phone2 = string.Empty;

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode = string.Empty;

        /// <summary>
        /// 学车类型，初学还是增驾
        /// </summary>
        public string LearnType = string.Empty;

        /// <summary>
        /// 学习车辆的型号代码，C1还是B1
        /// </summary>
        public string CarTypeCode = string.Empty;

        /// <summary>
        /// 学习车辆的型号文本，C1还是B1
        /// </summary>
        public string CarTypeString = string.Empty;

        /// <summary>
        /// 档案编号
        /// </summary>
        public string ProfileId = string.Empty;

        /// <summary>
        /// 报名日期
        /// </summary>
        public string RegDate = string.Empty;

        /// <summary>
        /// 推荐人信息
        /// </summary>
        public string Recommender = string.Empty;

        /// <summary>
        /// 增驾前的准驾型号
        /// </summary>
        public string OldCarType = string.Empty;

        /// <summary>
        /// 车辆类型,货车，轿车之类
        /// </summary>
        public string CarType = string.Empty;


        /// <summary>
        /// 备注
        /// </summary>
        public string Description = string.Empty;

        /// <summary>
        /// 报名费用
        /// </summary>
        public string Fee = string.Empty;

        /// <summary>
        /// 身高
        /// </summary>
        public string Height = string.Empty;

        /// <summary>
        /// 左视力
        /// </summary>
        public string LeftEye = string.Empty;

        /// <summary>
        /// 右视力
        /// </summary>
        public string RightEye = string.Empty;

        /// <summary>
        /// 辩视力
        /// </summary>
        public string Light = string.Empty;

        /// <summary>
        /// 听力
        /// </summary>
        public string Listening = string.Empty;

        /// <summary>
        /// 上肢
        /// </summary>
        public string TopBody = string.Empty;

        /// <summary>
        /// 左下肢
        /// </summary>
        public string LeftDownBody = string.Empty;

        /// <summary>
        /// 右下肢
        /// </summary>
        public string RightDownBody = string.Empty;

        /// <summary>
        /// 躯干径部
        /// </summary>
        public string MainBody = string.Empty;

        /// <summary>
        /// 体检日期
        /// </summary>
        public string CheckDate = string.Empty;

        /// <summary>
        /// 体检医院名称
        /// </summary>
        public string HospitalString = string.Empty;

        /// <summary>
        /// 体检医院代码
        /// </summary>
        public string HospitalCode = string.Empty;
    }
}
