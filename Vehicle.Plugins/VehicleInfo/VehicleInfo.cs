using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace Vehicle.Plugins
{
    [SimpleTable("table_vehicle_temp")]
    [Alias("�����ǼǱ�")]
    public class VehicleInfo
    {
        [SimplePK]
        public int Id;

        public string ���
        {
            get { return Id.ToString(); }
        }

        [SimpleColumn(AllowUpdate = false, Column = "firstregdate")]
        [Alias("�Ǽ�ʱ��")]
        public string FirstRegDate;

        public string �Ǽ�ʱ��
        {
            get { return FirstRegDate; }
            set { FirstRegDate = value; }
        }

        #region �Ǽ���Ϣ
        #region ��������Ϣ
        [SimpleColumn(Column = "c_base_syr_idcardtype")]
        [Alias("���������֤������")]
        public string BaseSyrIdCardType;

        public string ���������֤������
        {
            get { return BaseSyrIdCardType; }
            set { BaseSyrIdCardType = value; }
        }
        [SimpleColumn(Column = "c_base_syr_idcard")]
        [Alias("���������֤������")]
        public string BaseSyrIdCard;

        public string ���������֤������
        {
            get { return BaseSyrIdCard; }
            set { BaseSyrIdCard = value; }
        }
        [SimpleColumn(Column = "c_base_syr_name")]
        [Alias("����������")]
        public string BaseSyrName;

        public string ����������
        {
            get { return BaseSyrName; }
            set { BaseSyrName = value; }
        }
        [SimpleColumn(Column = "c_base_syr_phone")]
        [Alias("��������ϵ�绰")]
        public string BaseSyrPhone;

        public string ��������ϵ�绰
        {
            get { return BaseSyrPhone; }
            set { BaseSyrPhone = value; }
        }
        [SimpleColumn(Column = "c_base_syr_mobile")]
        [Alias("�������ƶ��绰")]
        public string BaseSyrMobile;

        public string �������ƶ��绰
        {
            get { return BaseSyrMobile; }
            set { BaseSyrMobile = value; }
        }
        [SimpleColumn(Column = "c_base_syr_postcode")]
        [Alias("��������������")]
        public string BaseSyrPostCode;

        public string ��������������
        {
            get { return BaseSyrPostCode; }
            set { BaseSyrPostCode = value; }
        }

        public string BaseSyrRegArea;

        [SimpleColumn(Column = "c_base_syr_regaddress")]
        [Alias("������ס����ַ")]
        public string BaseSyrRegAddress;

        public string BaseSyrConnArea;

        public string PhotoXh;

        [SimpleColumn(Column = "c_base_syr_connaddress")]
        [Alias("�������ʼĵ�ַ")]
        public string BaseSyrConnAddress;

        [SimpleColumn(Column = "c_base_syr_tempidtype")]
        [Alias("��������ס֤������")]
        public string BaseSyrTempIdType;
        [SimpleColumn(Column = "c_base_syr_tempid")]
        [Alias("��������ס֤��")]
        public string BaseSyrTempId;

        [SimpleColumn(Column = "c_base_syr_email")]
        public string BaseSyrEmail;
        
        #endregion
        #region �����˴����ˣ���λ����Ϣ
        public string BaseDlrIdCardType;
        public string BaseDlrIdCard;
        public string BaseDlrName;
        public string BaseDlrPhone;
        public string BaseDlrConnAddress;
        #endregion
        #region �����˴���λ��������Ϣ
        public string BaseJbrIdCardType;
        public string BaseJbrIdCard;
        public string BaseJbrName;
        public string BaseJbrConnAddress;
        #endregion
        #endregion

        #region �Ǽ���Ϣ(��)
        #region ������Ϣ
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
        
        #region ����ƾ֤��Ϣ
        public string XuJkPzType;
        public string XuPzHm;
        public string XuJkDate;
        public string XuVehicleColor;
        public string XuQzcpxh;
        #endregion
        #endregion

        #region ��������
        #region ������Ϣ
        public string TecHgzbh;
        [Alias("�����ͺ�")]
        public string TecClxh;

        public string �����ͺ�
        {
            get { return TecClxh; }
            set { TecClxh = value; }
        }
        [Alias("����Ʒ��")]
        public string TecZwpp;

        public string ����Ʒ��
        {
            get { return TecZwpp; }
            set { TecZwpp = value; }
        }
        public string TecYwpp;
        public string TecCllx;
        [Alias("����ʶ����")]
        public string TecClsbm;

        public string ����ʶ����
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
        
        #region ������Ϣ
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

        #region ��Ѻ��Ϣ
        #region ��ͬ��Ϣ
        public string DyHtzbh;
        public string DyDyHtbh;
        #endregion
        #region ��ѺȨ����Ϣ
        public string DyDyqrIdCardType;
        public string DyDyqrIdCard;
        public string DyDyqrName;
        public string DyDyqrPhone;
        public string DyDyqrConnAddress;
        public string DyDyqrPostCode;
        #endregion
        #region ��ѺȨ�˴����ˣ���λ����Ϣ
        public string DyDldwIdCardType;
        public string DyDldwIdCard;
        public string DyDldwName;
        public string DyDldwPhone;
        public string DyDldwConnAddress;
        //public string DyDldwPostCode;
        #endregion
        #region ��ѺȨ�˴���λ��������Ϣ
        public string DyJbrIdCardType;
        public string DyJbrIdCard;
        public string DyJbrName;
        public string DyJbrConnAddress;
        #endregion
        #endregion

        public string OthDimension;

    }
}
