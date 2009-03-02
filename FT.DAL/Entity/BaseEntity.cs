using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.PrinterEx;
using FT.DAL.Orm;

namespace FT.DAL.Entity
{
    /// <summary>
    /// 简单的基类，用户跟根据实体类来生成数据库表格
    /// 如果该类需要打印，则必须实现打印的接口方法,一个保存为图片
    /// 一个打印用
    /// 默认的实体类字段都必须是public的,以便反射使用
    /// </summary>
    public abstract class BaseEntity : ObjectPrinter
    {
        [SimplePK]
        public int Id;

        [SimpleColumn(Column="c_creator_ip",AllowUpdate = false)]
        public string CreatorIp;

        [SimpleColumn(Column="time_create_time",AllowUpdate = false)]
        public DateTime CreateTime = System.DateTime.Now;

        [SimpleColumn(Column="c_creator",AllowUpdate = false)]
        public string Creator;

        [SimpleColumn(Column="c_modifier_ip",AllowInsert = false)]
        public string ModifierIp;

        [SimpleColumn(Column="time_modify_time",AllowInsert = false)]
        public DateTime ModifyTime = System.DateTime.Now;

        [SimpleColumn(Column="c_modifier",AllowInsert = false)]
        public string Modifier;

        [SimpleColumn(Column = "bool_isvalided")]
        public bool IsValided = true;

        [SimpleColumn(Column="c_keywords")]
        public string KeyWords;

        [SimpleColumn(Column = "c_description")]
        public string Description;


        public virtual System.Drawing.Image Paint()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public virtual void PaintPrinter()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
