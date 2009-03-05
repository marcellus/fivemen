using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data;

namespace FT.DAL.Orm
{
    /// <summary>
    /// orm�Ļ��棬�򵥵Ļ��棬���漶��
    ///                             ��Ӧ��update�ֶ�
    ///         1��update.field;    ��Ӧ��update�ֶ�
    ///                             ��Ӧ��update�ֶ�
    /// 
    ///                             ��Ӧ��insert�ֶ�
    /// object  2��insert.field;    ��Ӧ��insert�ֶ�
    /// 
    ///         3��select.field       ��Ӧ��select�ֶ�
    ///                             
    ///         4��select.sql
    ///         5��update.sql
    ///         6��insert.sql
    /// 
    ///         7��tablename
    ///         8��pkcolumn
    ///         9��select.conditions//��ѯ�����õ��ı�������ʵ������Ӧ��datatable
    /// </summary>
    public class SimpleOrmCache
    {
        private static Hashtable caches = new Hashtable();

        public static DataTable GetConditionDT(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return (DataTable)second["select.conditions"];
        }

        public static Hashtable GetUpdateField(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return (Hashtable)second["update.field"];
        }

        public static string GetUpdateSql(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return second["update.sql"].ToString();
        }

        public static Hashtable GetInsertField(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return (Hashtable)second["insert.field"];
        }
        //TODO:�Ƿ�������ݿⷽ�������ɲ���͸������
        public static string GetInsertSql(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return second["insert.sql"].ToString();
        }

        public static Hashtable GetSelectField(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return (Hashtable)second["select.field"];
        }

        public static string GetSelectSql(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return second["select.sql"].ToString();
        }

        public static string GetTableName(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return second["tablename"].ToString();
        }
        public static string GetPK(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return second["pkcolumn"].ToString();
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="type"></param>
        public static void InitType(Type type)
        {
            if (caches.Contains(type.FullName))
            {
                return;
            }
            //SimplePKAttribute pkAtt = Attribute.GetCustomAttribute(type, typeof(SimplePKAttribute),true) as SimplePKAttribute;
           // if (pkAtt == null)
           // {
             //   throw new ArgumentException("��������ʵ������SimplePKAttribute��");
            //    return;
           // }
            string pk = string.Empty;
            Hashtable second = new Hashtable();
            Hashtable updates = new Hashtable();
            Hashtable inserts = new Hashtable();
            Hashtable selects = new Hashtable();
            DataTable selectsAlias = new DataTable();//�ֶα���
            selectsAlias.Columns.Add("value");
            selectsAlias.Columns.Add("text");
           
            SimpleTableAttribute tableAtt = Attribute.GetCustomAttribute(type, typeof(SimpleTableAttribute)) as SimpleTableAttribute;
            string tablename=tableAtt == null ? type.Name.ToLower() : tableAtt.Table;
            second.Add("tablename",tablename);
            StringBuilder updateSql = new StringBuilder("update "+tablename+" set ");
            StringBuilder insertSql = new StringBuilder("insert into "+tablename+" (");
            StringBuilder selectSql = new StringBuilder("");
            SimpleColumnAttribute columnAtt;
           
            FieldInfo[] fields=type.GetFields(BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Public|BindingFlags.FlattenHierarchy);
            FieldInfo tmp = null;
            bool findPk = false;
            string columnname = string.Empty;
            string tmpstr = string.Empty;
            StringBuilder inserttmp = new StringBuilder();
           
            for (int i = 0; i < fields.Length;i++ )
            {
                
                tmp = fields[i];
                columnname = tmp.Name.ToLower();
                if (!findPk)
                {
                    //�������������ñ���
                    if (Attribute.IsDefined(tmp, typeof(SimplePKAttribute)))
                    {
                        pk = columnname;
                        findPk = true;
                        second.Add("pkcolumn",pk);
                        continue;
                    }
                }
                columnAtt = Attribute.GetCustomAttribute(tmp, typeof(SimpleColumnAttribute)) as SimpleColumnAttribute;
                if (columnAtt != null)
                {
                    tmpstr = columnAtt.Column == null || columnAtt.Column.Length == 0 ? columnname : columnAtt.Column.ToLower();
                    if (columnAtt.AllowUpdate)
                    {
                        updateSql.Append(tmpstr + "='#" + columnname + "#',");
                        updates.Add(columnname, columnname);
                    }
                    if (columnAtt.AllowInsert)
                    {
                        insertSql.Append(tmpstr + ",");
                        inserttmp.Append("'#" + columnname + "#',");
                        inserts.Add(columnname, columnname);
                    }
                    if (columnAtt.AllowSelect)
                    {
                        selectSql.Append(tmpstr + ",");
                        selects.Add(tmpstr, columnname);

                        AliasAttribute aliasAtt = Attribute.GetCustomAttribute(tmp, typeof(AliasAttribute)) as AliasAttribute;
                        if (aliasAtt != null)
                        {
                            selectsAlias.Rows.Add(new string[] { tmpstr, aliasAtt.Name });
                        }
                        else
                        {
                            //selectsAlias.Rows.Add(new string[] { tmpstr, tmpstr });
                        }
                    }
                }
                else
                {
                    tmpstr = columnname;
                    updateSql.Append(tmpstr + "='#" + tmpstr + "#',");
                    updates.Add(tmpstr, tmpstr);
                    insertSql.Append(tmpstr + ",");
                    inserttmp.Append("'#" + tmpstr + "#',");
                    inserts.Add(tmpstr, tmpstr);
                    selects.Add(columnname, columnname);
                    selectSql.Append(tmpstr + ",");
                    selectsAlias.Rows.Add(new string[] { tmpstr, tmpstr });
                }
                
                
            }
            selects.Add(pk, pk);
            second.Add("update.sql",updateSql.ToString().TrimEnd(',') + " where " + pk + "=");
            second.Add("update.field",updates);
            second.Add("insert.sql",insertSql.ToString().TrimEnd(',')+") values("+inserttmp.ToString().TrimEnd(',')+")");
            second.Add("insert.field", inserts);
            second.Add("select.sql","select "+selectSql.ToString()+pk+" from "+tablename);
            second.Add("select.field", selects);
            second.Add("select.conditions", selectsAlias);
            Console.WriteLine("���������Ϊ��" + second["insert.sql"].ToString());
            Console.WriteLine("��������ֶθ���Ϊ��" + inserts.Count);
            Loop(inserts);
            Console.WriteLine("���������Ϊ��" + second["update.sql"].ToString());
            Console.WriteLine("��������ֶθ���Ϊ��" + updates.Count);
            Loop(updates);
            Console.WriteLine("��ѯ�����Ϊ��"+second["select.sql"].ToString());
            Loop(selects);
            caches.Add(type.FullName,second);
            
        }

        private static void Loop(Hashtable table)
        {
            System.Collections.IDictionaryEnumerator enumerator = table.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Value.ToString());
            }
        }

        public static void InitObject(object obj)
        {
            InitType(obj.GetType());
        }
    }
}
