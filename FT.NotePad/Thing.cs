using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.NotePad
{
    [SimpleTable("table_things")]
    [Alias("����ʵ��")]
    public class Thing
    {
        [SimplePK]
        [Alias("���")]
        public int Id;

        public int ���
        {
            get { return Id; }
            set { Id = value; }
        }
        [SimpleColumn(Column = "c_title")]
        [Alias("����")]
        public string Title;

        public string ����
        {
            get { return Title; }
            set { Title = value; }
        }

        [SimpleColumn(Column = "d_notedate")]
        [Alias("����ʱ��")]
        public DateTime NoteDate;

        public DateTime ����ʱ��
        {
            get { return NoteDate; }
            set { NoteDate = value; }
        }
        [SimpleColumn(Column = "c_context")]
        [Alias("��������")]
        public string Context;

        public string ��������
        {
            get { return Context; }
            set { Context = value; }
        }

        [SimpleColumn(Column = "i_parent_id")]
        [Alias("���ڵ�")]
        public int ParentId;

        public int ���ڵ�
        {
            get { return ParentId; }
            set { ParentId = value; }
        }

        [SimpleColumn(Column = "i_node_type")]
        [Alias("�ڵ�����")]
        public int NodeType;

        public int �ڵ�����
        {
            get { return NodeType; }
            set { NodeType = value; }
        }


    }
}
