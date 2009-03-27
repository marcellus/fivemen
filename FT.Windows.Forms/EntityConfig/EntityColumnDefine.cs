using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;
using FT.DAL.Entity;

namespace FT.Windows.Forms
{
    [SimpleTable("table_entity_column_define")]
    [Alias("ʵ����ж���")]
    public class EntityColumnDefine
    {
        [SimplePK]
        [Alias("���")]
        public int Id;

        public int ���
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column="c_property_name")]
        [Alias("��������")]
        public string PropertyName;

        public string ��������
        {
            get { return PropertyName; }
            set { PropertyName = value; }
        }

        [SimpleColumn(Column = "c_header_name")]
        [Alias("��ͷ����")]
        public string HeaderName;

        public string ��ͷ����
        {
            get { return HeaderName; }
            set { HeaderName = value; }
        }

        [SimpleColumn(Column = "i_header_width")]
        [Alias("��ͷ���")]
        public int HeaderWidth;

        public int ��ͷ���
        {
            get { return HeaderWidth; }
            set { HeaderWidth = value; }
        }

        [SimpleColumn(Column = "bool_isprinted")]
        [Alias("�Ƿ��ӡ")]
        public bool IsPrinted;

        public bool �Ƿ��ӡ
        {
            get { return IsPrinted; }
            set { IsPrinted = value; }
        }

        [SimpleColumn(Column = "i_printed_width")]
        [Alias("��ӡ���")]
        public int PrintedWidth;

        public int ��ӡ���
        {
            get { return PrintedWidth; }
            set { PrintedWidth = value; }
        }

        [SimpleColumn(Column = "bool_isexported")]
        [Alias("�Ƿ񵼳�")]
        public bool IsExportExcel;

        public bool �Ƿ񵼳�
        {
            get { return IsExportExcel; }
            set { IsExportExcel = value; }
        }

        [SimpleColumn(Column = "i_export_width")]
        [Alias("�������")]
        public int ExportWidth;

        public int �������
        {
            get { return ExportWidth; }
            set { ExportWidth = value; }
        }

        [SimpleColumn(Column = "bool_showindetail")]
        [Alias("�Ƿ���ʾ")]
        public bool ShowInDetail = false;

        public bool �Ƿ���ʾ
        {
            get { return ShowInDetail; }
            set { ShowInDetail = value; }
        }
        [SimpleColumn(Column = "i_detail_width")]
        [Alias("�б���")]
        public int DetailWidth;

        public int �б���
        {
            get { return DetailWidth; }
            set { DetailWidth = value; }
        }

        [SimpleColumn(Column = "c_class_cn_name")]
        [Alias("����ʵ������")]
        public string ClassCnName;

        public string ����ʵ������
        {
            get { return ClassCnName; }
            set { ClassCnName = value; }
        }

        [SimpleColumn(Column = "c_class_full_name")]
        [Alias("������ȫ��")]
        public string ClassFullName;

        public string ������ȫ��
        {
            get { return ClassFullName; }
            set { ClassFullName = value; }
        }

        [SimpleColumn(Column = "i_order_num")]
        [Alias("����˳��")]
        public int OrderNum;

        public int ����˳��
        {
            get { return OrderNum; }
            set { OrderNum = value; }
        }
    }
}
