using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;
using FT.Commons.Tools;

namespace FT.DAL.Orm
{
    /// <summary>
    /// 简单的Orm操纵类
    /// 现仅仅支持DateTime类型，所有的插入语句都使用字符串
    /// 实体对象都只是一些vo对象才可正常使用
    /// </summary>
    public class SimpleOrmOperator
    {
        #region 处理连接,唯一连接
        private static IDataAccess dataAccess;

        /// <summary>
        /// 初始化取数据的链接，唯一连接
        /// </summary>
        /// <param name="access">数据源链接</param>
        public static void InitDataAccess(IDataAccess access)
        {
            dataAccess = access;
        }


        public static bool CreateTable(Type type)
        {
            IDataAccess dataAccess = CreateConn();
            string sql = SimpleOrmCache.GetTableDDL(type);

            return dataAccess.ExecuteSql(sql);
        }

        public static bool DropTable(Type type)
        {
            IDataAccess dataAccess = CreateConn();
            string sql = "drop table "+SimpleOrmCache.GetTableName(type);

            return dataAccess.ExecuteSql(sql);
        }

        /// <summary>
        /// 判断数据库连接，默认调用配置的连接
        /// </summary>
        private static IDataAccess CreateConn()
        {
            return  DAL.DataAccessFactory.GetDataAccess();

        }

        /// <summary>
        /// 判断数据库连接，默认调用配置的连接
        /// </summary>
        private static void CheckConn()
        {
            if (dataAccess == null)
            {
                dataAccess = DAL.DataAccessFactory.GetDataAccess();
                //throw new ArgumentException("请先执行InitDataAccess来初始化链接！");
            }
        }
        #endregion

        /// <summary>
        /// 比较两实体的主键是否一致，一致认为是一个对象
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool EntityIsEqual(object obj1, object obj2)
        {
            if (obj1.GetType() != obj2.GetType())
            {
                return false;
            }
            else
            {
                Type type = obj1.GetType();
                string pk = SimpleOrmCache.GetPK(type);
                object value1 = type.GetField(pk, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj1);
                object value2 = type.GetField(pk, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj2);
                return value1.ToString() == value2.ToString();


            }
        }

        #region 增删改

        /// <summary>
        /// 把实体对象的属性转换成要保存的字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string TransObjectField(object value)
        {
            if(value==null)
            {
                return string.Empty;
            }
            if(value is DateTime)
            {
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            /*if (value is Enum)
            {
                return ((Enum)value).ToString("yyyy-MM-dd HH:mm:ss");
            }*/
            else
            {

                return value.ToString();
            }
        }

        /// <summary>
        /// 更新一个实体对象
        /// </summary>
        /// <param name="obj">实体对象</param>
        /// <returns>是否更新成功</returns>
        public static bool Update(object obj)
        {
            IDataAccess dataAccess = CreateConn();
            Type type = obj.GetType();
            StringBuilder sql = new StringBuilder(SimpleOrmCache.GetUpdateSql(type));
            Hashtable table = SimpleOrmCache.GetUpdateField(type);
            System.Collections.IDictionaryEnumerator enumerator = table.GetEnumerator();
            string field = string.Empty;
            object value = null;
            while (enumerator.MoveNext())
            {
                field = enumerator.Key.ToString();
                value = type.GetField(field, BindingFlags.IgnoreCase|BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj);
                sql.Replace("#" + field + "#", value == null ? "" : DALSecurityTool.TransferInsertField(TransObjectField(value)));
            }
            sql.Append(type.GetField(SimpleOrmCache.GetPK(type),BindingFlags.IgnoreCase|BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj).ToString());
            return dataAccess.ExecuteSql(sql.ToString());
        }

        /// <summary>
        /// 创建一个对象到数据库中,成功后通过select max()来返回主键
        /// </summary>
        /// <param name="obj">实体对象</param>
        /// <returns>是否插入成功</returns>
        public static bool Create(object obj)
        {
            IDataAccess dataAccess = CreateConn();
            Type type = obj.GetType();
            StringBuilder sql = new StringBuilder(SimpleOrmCache.GetInsertSql(type));
            Hashtable table = SimpleOrmCache.GetInsertField(type);
            System.Collections.IDictionaryEnumerator enumerator = table.GetEnumerator();
            string field=string.Empty;
            object value=null;
            while (enumerator.MoveNext())
            {
               field=enumerator.Key.ToString();
               value=type.GetField(field, BindingFlags.IgnoreCase|BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj);
               sql.Replace("#" + field + "#", value == null ? "" : DALSecurityTool.TransferInsertField(TransObjectField(value)));
            }
            bool result= dataAccess.ExecuteSql(sql.ToString());
            if (result)//执行把主键赋给对象
            {
                string pk = SimpleOrmCache.GetPK(type);
                object objtmp = dataAccess.SelectScalar("select max("+pk+") from "+SimpleOrmCache.GetTableName(type));
                if (objtmp != null)
                {
                    FormHelper.SetDataToObject(obj, pk, objtmp);
                    //FormHelper.SetDataToObject(obj,pk,FormHelper.ParseFieldInfo(obj,objtmp);
                    //FieldInfo fieldtmp=type.GetField(pk);
                    //fieldtmp.SetValue(obj, FormHelper.ParseFieldInfo(fieldtmp, objtmp));
                }
            }
            return result;

        }

        /// <summary>
        /// 删除一个实体对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="pk">主键id</param>
        /// <returns>是否成功删除</returns>
        public static bool Delete<T>(object pk)
        {
            IDataAccess dataAccess = CreateConn();
            if (pk == null || pk.ToString().Length == 0)
            {
                throw new ArgumentException("删除的PK主键不得为空！");
                //return null;
            }

            string sql = "delete from "+SimpleOrmCache.GetTableName(typeof(T)) + " where " + SimpleOrmCache.GetPK(typeof(T)) + "=" + pk.ToString();
            return dataAccess.ExecuteSql(sql);
        }

        public static bool Delete(object entity)
        {
            if (entity == null)
            {
                //throw new ArgumentException("删除的PK主键不得为空！");
                return false;
            }
            IDataAccess dataAccess = CreateConn();
            
            Type type = entity.GetType();
            string pk=SimpleOrmCache.GetPK(type);
            object value = type.GetField(pk, BindingFlags.IgnoreCase|BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(entity);
            string sql = "delete from " + SimpleOrmCache.GetTableName(type) + " where " + pk + "=" + value.ToString();
            return dataAccess.ExecuteSql(sql);
        }

        /// <summary>
        /// 查询一个对象出来
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="pk">主键值</param>
        /// <returns>一个对象</returns>
        public static T Query<T>(object pk)
        {
            IDataAccess dataAccess = CreateConn();
            if (pk == null || pk.ToString().Length == 0)
            {
                throw new ArgumentException("查询的PK主键不得为空！");
                //return null;
            }

            string sql = SimpleOrmCache.GetSelectSql(typeof(T)) + " where " + SimpleOrmCache.GetPK(typeof(T)) + "=" + pk.ToString();
            DataTable dt = dataAccess.SelectDataTable(sql, SimpleOrmCache.GetTableName(typeof(T)));
            if (dt!=null&&dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return CreateFromDataRow<T>(dr);
            }
            else
            {
                return default(T);
            }

        }

        /// <summary>
        /// 查询一个对象列表出来出来
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="condition">带有where的条件</param>
        /// <returns>一个对象</returns>
        public static ArrayList QueryConditionList<T>(string condition)
        {
            return QueryConditionList(typeof(T), condition);

        }

        /// <summary>
        /// 查询一个对象列表出来出来
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="sql">完整的sql语句</param>
        /// <returns>一个对象</returns>
        public static ArrayList QueryList(Type type, string sql)
        {
            IDataAccess dataAccess = CreateConn();
            ArrayList list = new ArrayList();
            if (sql == null&&sql.Length==0)
            {
                throw new ArgumentException("查询的语句不得为空！");
                //return null;
            }

            // string sql = SimpleOrmCache.GetSelectSql(typeof(T)) + " where " + SimpleOrmCache.GetPK(typeof(T)) + "=" + pk.ToString();
            string tablename = SimpleOrmCache.GetTableName(type);
            DataTable dt = dataAccess.SelectDataTable(sql, tablename);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = null;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    list.Add(CreateFromDataRow(type, dr));
                }
            }
            return list;

        }

        /// <summary>
        /// 查询一个对象列表出来出来
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="condition">带有where的条件</param>
        /// <returns>一个对象</returns>
        public static ArrayList QueryConditionList(Type type,string condition)
        {
            string sql = "select * from " + SimpleOrmCache.GetTableName(type) + " " + condition;
            return QueryList(type,sql);

        }

        public static ArrayList QueryListAll(Type type)
        {
            return QueryConditionList(type, string.Empty);
        }

        /// <summary>
        /// 返回查询条件的记录总数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int QueryCounts<T>(string condition)
        {
            return QueryCounts(typeof(T), condition);
        }

        /// <summary>
        /// 返回查询条件的记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">必须带where的条件</param>
        /// <returns></returns>
        public static int QueryCounts(Type type,string condition)
        {
            IDataAccess dataAccess = CreateConn();
            string sql = "select count(*) from " + SimpleOrmCache.GetTableName(type) + condition;
            object obj = dataAccess.SelectScalar(sql);
            return Convert.ToInt32(obj);

        }

        /// <summary>
        /// 返回查询条件的记录总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">必须带where的条件</param>
        /// <returns></returns>
        public static int QueryCounts(string table,string condition)
        {
            IDataAccess dataAccess = CreateConn();
            string sql = "select count(*) from " + table + condition;
            object obj = dataAccess.SelectScalar(sql);
            return Convert.ToInt32(obj);

        }

        #endregion
        #region 条件查询方法

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="condition">条件语句</param>
        /// <param name="pager">分页对象</param>
        /// <param name="order">排序列</param>
        /// <param name="isDesc">是否降序</param>
        /// <returns></returns>
        public List<T> Query<T>(string condition, Pager pager,string order ,bool isDesc)
        {
            IDataAccess dataAccess = CreateConn();
            List<T> result = new List<T>();
            string sql = dataAccess.GetPageSql(SimpleOrmCache.GetSelectSql(typeof(T)) + condition,pager,order,isDesc);
            
            DataTable dt = dataAccess.SelectDataTable(sql, SimpleOrmCache.GetTableName(typeof(T)));
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    result.Add(CreateFromDataRow<T>(dr));
                }
               
            }
            return result;
        }
        public List<T> Query<T>(string condition, Pager pager)
        {
            return this.Query<T>(condition,pager,"id",true);
        }
         
        #endregion



        #region 辅助方法
        /// <summary>
        /// 根据datarow创建一个对象出来
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="dr">datarow</param>
        /// <returns>创建一个对象</returns>
        private static T CreateFromDataRow<T>(DataRow dr)
        {
            T result = (T)System.Reflection.Assembly.GetAssembly(typeof(T)).CreateInstance(typeof(T).ToString());
            Hashtable table = SimpleOrmCache.GetSelectField(typeof(T));
            System.Collections.IDictionaryEnumerator enumerator = table.GetEnumerator();
            object drvalue = null;
            FieldInfo fieldInfo = null;
            while (enumerator.MoveNext())
            {
                drvalue = dr[enumerator.Key.ToString()];
                fieldInfo = result.GetType().GetField(enumerator.Value.ToString(), BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                SetValueToField(result, fieldInfo, drvalue);
            }
            return result;
        }

        /// <summary>
        /// 根据datarow创建一个对象出来
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="dr">datarow</param>
        /// <returns>创建一个对象</returns>
        private static object CreateFromDataRow(Type type,DataRow dr)
        {
            
            object result = ReflectHelper.CreateInstance(type);
            Hashtable table = SimpleOrmCache.GetSelectField(type);
            System.Collections.IDictionaryEnumerator enumerator = table.GetEnumerator();
            object drvalue = null;
            FieldInfo fieldInfo = null;
            while (enumerator.MoveNext())
            {
                drvalue = dr[enumerator.Key.ToString()];
                fieldInfo = result.GetType().GetField(enumerator.Value.ToString(), BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
                SetValueToField(result, fieldInfo, drvalue);
            }
            return result;
        }
        /// <summary>
        /// 根据字段的类型，进行赋值
        /// </summary>
        /// <param name="obj">实体对象</param>
        /// <param name="field">字段</param>
        /// <param name="value">具体的值</param>
        private static void SetValueToField(object obj,FieldInfo field,object value)
        {
            if (Convert.IsDBNull(value))
            {
                value = null;
            }
            if (value != null)
            {
                Type fieldType = field.FieldType;
                if (typeof(string) == fieldType)
                {
                    field.SetValue(obj, value.ToString());
                }
                else if (typeof(int) == fieldType)
                {
                    field.SetValue(obj, Convert.ToInt32(value));
                }
                else if (typeof(bool) == fieldType)
                {
                    field.SetValue(obj, Convert.ToBoolean(value));
                }
                else if (typeof(decimal) == fieldType)
                {
                    field.SetValue(obj, Convert.ToDecimal(value));
                }
                else if (typeof(DateTime) == fieldType)
                {
                    field.SetValue(obj, Convert.ToDateTime(value.ToString()));
                }
            }
            else
            {
                field.SetValue(obj, value);
            }
        }
        #endregion
    }
}
