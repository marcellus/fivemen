using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.NotePad
{
    [SimpleTable("table_things")]
    [Alias("事情实体")]
    public class Thing
    {
        [SimplePK]
        [Alias("编号")]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }
        [SimpleColumn(Column = "c_title")]
        [Alias("标题")]
        public string Title;

        public string 标题
        {
            get { return Title; }
            set { Title = value; }
        }

        [SimpleColumn(Column = "d_notedate")]
        [Alias("创建时间")]
        public DateTime NoteDate;

        public DateTime 创建时间
        {
            get { return NoteDate; }
            set { NoteDate = value; }
        }
        [SimpleColumn(Column = "c_context")]
        [Alias("文章内容")]
        public string Context;

        public string 文章内容
        {
            get { return Context; }
            set { Context = value; }
        }

        [SimpleColumn(Column = "i_parent_id")]
        [Alias("父节点")]
        public int ParentId;

        public int 父节点
        {
            get { return ParentId; }
            set { ParentId = value; }
        }

        [SimpleColumn(Column = "i_node_type")]
        [Alias("节点类型")]
        public int NodeType;

        public int 节点类型
        {
            get { return NodeType; }
            set { NodeType = value; }
        }


    }
}
