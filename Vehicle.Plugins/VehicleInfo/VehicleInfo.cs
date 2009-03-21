using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace Vehicle.Plugins
{
    [SimpleTable("table_vehicle_temp")]
    [Alias("车辆登记表")]
    public class VehicleInfo
    {
        [SimplePK]
        public int Id;

        public string 编号
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(AllowUpdate = false, Column = "firstregdate")]
        [Alias("登记时间")]
        public string FirstRegDate;

        public string 登记时间
        {
            get { return FirstRegDate; }
            set { FirstRegDate = value; }
        }

        #region 登记信息
        #region 所有人信息
        [SimpleColumn(Column = "c_base_syr_idcardtype")]
        [Alias("所有人身份证明名称")]
        public string BaseSyrIdCardType;

        public string 所有人身份证明名称
        {
            get { return BaseSyrIdCardType; }
            set { BaseSyrIdCardType = value; }
        }
        [SimpleColumn(Column = "c_base_syr_idcard")]
        [Alias("所有人身份证明号码")]
        public string BaseSyrIdCard;

        public string 所有人身份证明号码
        {
            get { return BaseSyrIdCard; }
            set { BaseSyrIdCard = value; }
        }
        [SimpleColumn(Column = "c_base_syr_name")]
        [Alias("所有人姓名")]
        public string BaseSyrName;

        public string 所有人姓名
        {
            get { return BaseSyrName; }
            set { BaseSyrName = value; }
        }
        [SimpleColumn(Column = "c_base_syr_phone")]
        [Alias("所有人联系电话")]
        public string BaseSyrPhone;

        public string 所有人联系电话
        {
            get { return BaseSyrPhone; }
            set { BaseSyrPhone = value; }
        }
        [SimpleColumn(Column = "c_base_syr_mobile")]
        [Alias("所有人移动电话")]
        public string BaseSyrMobile;

        public string 所有人移动电话
        {
            get { return BaseSyrMobile; }
            set { BaseSyrMobile = value; }
        }
        [SimpleColumn(Column = "c_base_syr_postcode")]
        [Alias("所有人邮政编码")]
        public string BaseSyrPostCode;

        public string 所有人邮政编码
        {
            get { return BaseSyrPostCode; }
            set { BaseSyrPostCode = value; }
        }

        public string BaseSyrRegArea;

        [SimpleColumn(Column = "c_base_syr_regaddress")]
        [Alias("所有人住所地址")]
        public string BaseSyrRegAddress;

        public string BaseSyrConnArea;

        public string PhotoXh;

        [SimpleColumn(Column = "c_base_syr_connaddress")]
        [Alias("所有人邮寄地址")]
        public string BaseSyrConnAddress;

        [SimpleColumn(Column = "c_base_syr_tempidtype")]
        [Alias("所有人暂住证明名称")]
        public string BaseSyrTempIdType;
        [SimpleColumn(Column = "c_base_syr_tempid")]
        [Alias("所有人暂住证号")]
        public string BaseSyrTempId;

        [SimpleColumn(Column = "c_base_syr_email")]
        public string BaseSyrEmail;
        
        #endregion
        #region 所有人代理人（单位）信息
        public string BaseDlrIdCardType;
        public string BaseDlrIdCard;
        public string BaseDlrName;
        public string BaseDlrPhone;
        public string BaseDlrConnAddress;
        #endregion
        #region 所有人代理单位经办人信息
        public string BaseJbrIdCardType;
        public string BaseJbrIdCard;
        public string BaseJbrName;
        public string BaseJbrConnAddress;
        #endregion
        #endregion

        #region 登记信息(续)
        #region 基本信息
        public string XuUseFor;
        public string XuSyq;
        public string XuGetFrom;
        public string XuBelongArea;
        public string XuHmhp;
        public string XuLlpp1;
        public string XuLlppHm1;
        public string XuLlpp2;
        public string XuLlppHm2;
        public string XuGzzm;
        public string XuGzzmBh;
        public string XuBxBh;
        public string XuBxCompany;
        public string XuBxBeginDate;
        public string XuBxEndDate;
        public string XuSellDw;
        public string XuSellPrice;
        public string XuDescription;
        #endregion
        
        #region 进口凭证信息
        public string XuJkPzType;
        public string XuPzHm;
        public string XuJkDate;
        public string XuVehicleColor;
        public string XuQzcpxh;
        #endregion
        #endregion

        #region 技术参数
        #region 基本信息
        public string TecHgzbh;
        [Alias("车辆型号")]
        public string TecClxh;

        public string 车辆型号
        {
            get { return TecClxh; }
            set { TecClxh = value; }
        }
        [Alias("中文品牌")]
        public string TecZwpp;

        public string 中文品牌
        {
            get { return TecZwpp; }
            set { TecZwpp = value; }
        }
        public string TecYwpp;
        public string TecCllx;
        [Alias("车辆识别码")]
        public string TecClsbm;

        public string 车辆识别码
        {
            get { return TecClsbm; }
            set { TecClsbm = value; }
        }
        public string TecFdjh;
        public string TecZzcm;
        public string TecColor1;
        public string TecColor2;
        public string TecColor3;
        public string TecCcrq;
        public string TecGcjk;
        public string TecZzg;
        public string TecFdjxh;
        public string TecPl;
        public string TecGl;
        public string TecRlzl1;
        public string TecRlzl2;
        
        #endregion
        
        #region 数字信息
        public string TecWkc;
        public string TecWkk;
        public string TecWkg;
        public string TecZxfs;
        public string TecNkc;
        public string TecNkk;
        public string TecNkg;
        public string TecHbdb;
        public string TecGbtfs;
        public string TecZs;
        public string TecZj;
        public string TecLts;
        public string TecLtgg;
        public string TecLjq;
        public string TecLjh;
        public string TecZzl;
        public string TecZbzl;
        public string TecHdzk;
        public string TecZqyzl;
        public string TecHdzzl;
        
        public string TecZkrsq;
        public string TecZkrsh;
        #endregion
        #endregion

        #region 抵押信息
        #region 合同信息
        public string DyHtzbh;
        public string DyDyHtbh;
        #endregion
        #region 抵押权人信息
        public string DyDyqrIdCardType;
        public string DyDyqrIdCard;
        public string DyDyqrName;
        public string DyDyqrPhone;
        public string DyDyqrConnAddress;
        public string DyDyqrPostCode;
        #endregion
        #region 抵押权人代理人（单位）信息
        public string DyDldwIdCardType;
        public string DyDldwIdCard;
        public string DyDldwName;
        public string DyDldwPhone;
        public string DyDldwConnAddress;
        //public string DyDldwPostCode;
        #endregion
        #region 抵押权人代理单位经办人信息
        public string DyJbrIdCardType;
        public string DyJbrIdCard;
        public string DyJbrName;
        public string DyJbrConnAddress;
        #endregion
        #endregion

        public string OthDimension;

    }
}
