using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Windows.ExternalTool
{
    
    [SimpleTable("table_trains")]
    [Alias("�𳵳�����Ϣ")]
    public class Train
    {
        [SimpleColumn(Column = "cc")]
        [SimplePK]
        [Alias("����")]
        public string Cc;

        public string ����
        {
            get { return Cc; }
            set { Cc = value; }
        }

        [SimpleColumn(Column = "sf")]
        [Alias("ʼ��վ")]
        public string Sf;

        public string ʼ��վ
        {
            get { return Sf; }
            set { Sf = value; }
        }

        [SimpleColumn(Column = "zd")]
        [Alias("�յ�վ")]
        public string Zd;

        public string �յ�վ
        {
            get { return Zd; }
            set { Zd = value; }
        }


        [SimpleColumn(Column = "fs")]
        [Alias("��ʱ")]
        public string Fs;

        public string ��ʱ
        {
            get { return Fs; }
            set { Fs = value; }
        }


        [SimpleColumn(Column = "ds")]
        [Alias("��ʱ")]
        public string Ds;

        public string ��ʱ
        {
            get { return Ds; }
            set { Ds = value; }
        }


        [SimpleColumn(Column = "lc")]
        [Alias("���")]
        public string Lc;

        public string ���
        {
            get { return Lc; }
            set { Lc = value; }
        }


        [SimpleColumn(Column = "ls")]
        [Alias("��ʱ")]
        public string Ls;

        public string ��ʱ
        {
            get { return Ls; }
            set { Ls = value; }
        }

        [SimpleColumn(Column = "zs")]
        [Alias("��վ��")]
        public string Zs;

        public string ��վ��
        {
            get { return Zs; }
            set { Zs = value; }
        }


        
    }
}
