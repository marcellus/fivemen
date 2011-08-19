using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data;

namespace FT.DAL.Orm
{
    /// <summary>
    /// orm的缓存，简单的缓存，缓存级别：
    ///                             对应的update字段
    ///         1、update.field;    对应的update字段
    ///                             对应的update字段
    /// 
    ///                             对应的insert字段
    /// object  2、insert.field;    对应的insert字段
    /// 
    ///         3、select.field       对应的select字段
    ///                             
    ///         4、select.sql
    ///         5、update.sql
    ///         6、insert.sql
    /// 
    ///         7、tablename
    ///         8、pkcolumn
    ///         9、select.conditions//查询条件用到的别名和列实际名对应的datatable
    ///         10、tablealiasname 表的别名
    ///         11、export.sql 导出excel需要导出的别名
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
        //TODO:是否根据数据库方言来生成插入和更新语句
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

        public static void RefreshTemplateSql(Type type)
        {
            string key1 = "print.sql.table.template";
            string key2 = "export.sql.table.template";
            string key3 = "export.widths.table.template";
            string key4 = "print.widths.table.template";
            string key5 = type.FullName + "-detail-columndefine";
            FT.Commons.Cache.StaticCacheManager.Caches.Remove(key5);
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            second.Remove(key1);
            second.Remove(key2);
            second.Remove(key3);
            second.Remove(key4);
        }

        

        public static int[] GetPrintWidths(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            string key = "print.widths.table.template";
            if (second.ContainsKey(key))
            {
                return second[key] as int[];
            }
            else
            {
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select i_printed_width from table_entity_column_define  where bool_isprinted='True' and c_class_full_name='" + type.FullName + "' order by i_order_num", "temp");
                int[] widths=new int[dt.Rows.Count-1];
                for(int i=0;i<widths.Length;i++)
                {
                    try
                    {
                        widths[i]=Convert.ToInt32(dt.Rows[i][0].ToString());
                    }
                    catch
                    {
                        widths[i]=50;
                    }
                }

                second[key] = widths ;
                return second[key] as int[];

            }
            return null;
        }

        public static string GetPrintSql(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            string key = "print.sql.table.template";
            if (second.ContainsKey(key))
            {
                return second[key].ToString();
            }
            else
            {
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select c_column_name,c_header_name from table_entity_column_define  where bool_isprinted='True' and c_class_full_name='" + type.FullName + "' order by i_order_num", "temp");
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append(dr[0].ToString() + " as " + dr[1].ToString() + ",");
                }
                second[key] = sb.ToString().TrimEnd(',');
                return second[key].ToString();

            }
            return second["export.sql"].ToString();
        }

        public static int[] GetExportWidths(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            string key = "export.widths.table.template";
            if (second.ContainsKey(key))
            {
                return second[key] as int[];
            }
            else
            {
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select i_export_width from table_entity_column_define  where bool_isexported='True' and c_class_full_name='" + type.FullName + "' order by i_order_num", "temp");
                int[] widths = new int[dt.Rows.Count];
                for (int i = 0; i < widths.Length; i++)
                {
                    try
                    {
                        widths[i] = Convert.ToInt32(dt.Rows[i][0].ToString());
                    }
                    catch
                    {
                        widths[i] = 50;
                    }
                }

                second[key] = widths;
                return second[key] as int[];

            }
            return null;
        }

        public static string GetExportSql(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            string key = "export.sql.table.template";
            if (second.ContainsKey(key))
            {
                return second[key].ToString();
            }
            else
            {
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable("select c_column_name,c_header_name from table_entity_column_define  where bool_isexported='True' and c_class_full_name='" + type.FullName + "' order by i_order_num", "temp");
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append(dr[0].ToString() + " as " + dr[1].ToString() + ",");
                }
                second[key] = sb.ToString().TrimEnd(',');
                return second[key].ToString();

            }
            return second["export.sql"].ToString();
        }

        public static string GetExportTitle(Type type)
        {
            InitType(type);
            Hashtable second = caches[type.FullName] as Hashtable;
            return second["tablealiasname"].ToString();
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
        /// 获取表的定义字段
        /// </summary>
        /// <returns></returns>
        public static string GetTableDDL(Type type)
        {
            if (type == null)
            {
                return string.Empty;
            }
            InitType(type);
            StringBuilder sb = new StringBuilder();
            string tablename = GetTableName(type);
            string pk = GetPK(type);
            Hashtable table=GetSelectField(type);
            sb.Append("create table "+tablename+"(");
            sb.Append(pk + " autoincrement PRIMARY KEY ");
            System.Collections.IDictionaryEnumerator enumerator = table.GetEnumerator();
            string field = string.Empty;
            while (enumerator.MoveNext())
            {
                field = enumerator.Key.ToString();
                if (field != pk)
                {
                    sb.Append("," +field.ToLower() +" TEXT(50)");
                }
            }
            return sb.ToString().TrimEnd(',')+")";
            
        }

        /// <summary>
        /// 初始化类型
        /// </summary>
        /// <param name="type"></param>
        public static void InitType(Type type)
        {
            if (type==null||caches.Contains(type.FullName))
            {
                return;
            }
            //SimplePKAttribute pkAtt = Attribute.GetCustomAttribute(type, typeof(SimplePKAttribute),true) as SimplePKAttribute;
           // if (pkAtt == null)
           // {
             //   throw new ArgumentException("必须设置实体对象的SimplePKAttribute！");
            //    return;
           // }
            string pk = string.Empty;
            Hashtable second = new Hashtable();
            Hashtable updates = new Hashtable();
            Hashtable inserts = new Hashtable();
            Hashtable selects = new Hashtable();
            DataTable selectsAlias = new DataTable();//字段别名
            selectsAlias.Columns.Add("value");
            selectsAlias.Columns.Add("text");

            //DataTable selectsAlias = new DataTable();
           
            SimpleTableAttribute tableAtt = Attribute.GetCustomAttribute(type, typeof(SimpleTableAttribute)) as SimpleTableAttribute;
            AliasAttribute tableAliasAtt = Attribute.GetCustomAttribute(type, typeof(AliasAttribute)) as AliasAttribute;
            string tablename=tableAtt == null ? type.Name.ToLower() : tableAtt.Table;
            string tableAliasName = tableAliasAtt == null ? tablename : tableAliasAtt.Name;
            second.Add("tablename",tablename);
            second.Add("tablealiasname", tableAliasName);
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
            StringBuilder exporttmp = new StringBuilder();
            AliasAttribute aliasAtt=null;
            OracleSeqAttribute seqAtt = null;
            for (int i = 0; i < fields.Length;i++ )
            {
                
                tmp = fields[i];
                columnname = tmp.Name.ToLower();
                if (!findPk)
                {
                    //主键不允许设置别名
                    if (Attribute.IsDefined(tmp, typeof(SimplePKAttribute)))
                    {
                        pk = columnname;
                        findPk = true;
                        second.Add("pkcolumn",pk);
                        aliasAtt = Attribute.GetCustomAttribute(tmp, typeof(AliasAttribute)) as AliasAttribute;
                        
                        if (aliasAtt != null)
                        {
                            exporttmp.Append(pk + " as " + aliasAtt.Name + ",");
                        }
                        seqAtt = Attribute.GetCustomAttribute(tmp, typeof(OracleSeqAttribute)) as OracleSeqAttribute;
                        if(seqAtt!=null)
                        {
                            insertSql.Append(pk + ",");
                            inserttmp.Append("" + seqAtt.SeqName + ".nextval,");
                        }
                        continue;
                    }
                }
                columnAtt = Attribute.GetCustomAttribute(tmp, typeof(SimpleColumnAttribute)) as SimpleColumnAttribute;
                if (columnAtt != null)
                {
                    tmpstr = columnAtt.Column == null || columnAtt.Column.Length == 0 ? columnname : columnAtt.Column.ToLower();
                    if (columnAtt.AllowUpdate)
                    {
                        if(columnAtt.ColumnType==SimpleColumnType.Int)
                        {
                            updateSql.Append(tmpstr + "=#" + columnname + "#,");
                        }
                        else if (columnAtt.ColumnType == SimpleColumnType.Date)
                        {
                            updateSql.Append(tmpstr + "=to_date('#" + columnname + "#','yyyy-MM-dd hh24:mi:ss'),");
                        }
                        else
                        {
                            updateSql.Append(tmpstr + "='#" + columnname + "#',");
                        }
                        
                        updates.Add(columnname, columnname);
                    }
                    if (columnAtt.AllowInsert)
                    {
                        insertSql.Append(tmpstr + ",");
                        if (columnAtt.ColumnType == SimpleColumnType.Int)
                        {
                            inserttmp.Append("#" + columnname + "#,");
                        }
                        else if(columnAtt.ColumnType == SimpleColumnType.Date)
                        {
                            inserttmp.Append("to_date('#" + columnname + "#','yyyy-MM-dd hh24:mi:ss'),");
                        }
                        else
                        {
                            inserttmp.Append("'#" + columnname + "#',");
                        }
                      
                        inserts.Add(columnname, columnname);
                    }
                    if (columnAtt.AllowSelect)
                    {
                        selectSql.Append(tmpstr + ",");
                        selects.Add(tmpstr, columnname);

                        aliasAtt = Attribute.GetCustomAttribute(tmp, typeof(AliasAttribute)) as AliasAttribute;
                        if (aliasAtt != null)
                        {
                            selectsAlias.Rows.Add(new string[] { tmpstr, aliasAtt.Name });
                            exporttmp.Append(tmpstr + " as " + aliasAtt.Name+",");
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
                    aliasAtt = Attribute.GetCustomAttribute(tmp, typeof(AliasAttribute)) as AliasAttribute;
                    if (aliasAtt != null)
                    {
                        selectsAlias.Rows.Add(new string[] { tmpstr, aliasAtt.Name });
                        exporttmp.Append(tmpstr + " as " + aliasAtt.Name+",");
                    }
                    else
                    {
                        //selectsAlias.Rows.Add(new string[] { tmpstr, tmpstr });
                    }
                    //selectsAlias.Rows.Add(new string[] { tmpstr, tmpstr });
                }
                
                
            }
            selects.Add(pk, pk);
            second.Add("update.sql",updateSql.ToString().TrimEnd(',') + " where " + pk + "=");
            second.Add("update.field",updates);
            second.Add("insert.sql",insertSql.ToString().TrimEnd(',')+") values("+inserttmp.ToString().TrimEnd(',')+")");
            second.Add("insert.field", inserts);
            second.Add("select.sql","select "+selectSql.ToString()+pk+" from "+tablename);
            second.Add("select.field", selects);
            second.Add("export.sql", exporttmp.ToString().TrimEnd(','));
            second.Add("select.conditions", selectsAlias);
            //Console.WriteLine("插入语句结果为：" + second["insert.sql"].ToString());
            //Console.WriteLine("插入语句字段个数为：" + inserts.Count);
            //Loop(inserts);
            //Console.WriteLine("更新语句结果为：" + second["update.sql"].ToString());
            //Console.WriteLine("更新语句字段个数为：" + updates.Count);
            //Loop(updates);
            //Console.WriteLine("查询语句结果为："+second["select.sql"].ToString());
            //Loop(selects);
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
