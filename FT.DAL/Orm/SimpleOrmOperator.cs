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
    /// �򵥵�Orm������
    /// �ֽ���֧��DateTime���ͣ����еĲ�����䶼ʹ���ַ���
    /// ʵ�����ֻ��һЩvo����ſ�����ʹ��
    /// </summary>
    public class SimpleOrmOperator
    {
        #region ��������,Ψһ����
        private static IDataAccess dataAccess;

        /// <summary>
        /// ��ʼ��ȡ���ݵ����ӣ�Ψһ����
        /// </summary>
        /// <param name="access">����Դ����</param>
        public static void InitDataAccess(IDataAccess access)
        {
            dataAccess = access;
        }

        /// <summary>
        /// �ж����ݿ����ӣ�Ĭ�ϵ������õ�����
        /// </summary>
        private static void CheckConn()
        {
            if (dataAccess == null)
            {
                dataAccess = DAL.DataAccessFactory.GetDataAccess();
                //throw new ArgumentException("����ִ��InitDataAccess����ʼ�����ӣ�");
            }
        }
        #endregion

        /// <summary>
        /// �Ƚ���ʵ��������Ƿ�һ�£�һ����Ϊ��һ������
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

        #region ��ɾ��
        /// <summary>
        /// ����һ��ʵ�����
        /// </summary>
        /// <param name="obj">ʵ�����</param>
        /// <returns>�Ƿ���³ɹ�</returns>
        public static bool Update(object obj)
        {
            CheckConn();
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
                sql.Replace("#" + field + "#", value == null ? "" : DALSecurityTool.TransferInsertField(value.ToString()));
            }
            sql.Append(type.GetField(SimpleOrmCache.GetPK(type),BindingFlags.IgnoreCase|BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(obj).ToString());
            return dataAccess.ExecuteSql(sql.ToString());
        }

        /// <summary>
        /// ����һ���������ݿ���
        /// </summary>
        /// <param name="obj">ʵ�����</param>
        /// <returns>�Ƿ����ɹ�</returns>
        public static bool Create(object obj)
        {
            CheckConn();
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
               sql.Replace("#" + field + "#", value == null ? "" : DALSecurityTool.TransferInsertField(value.ToString()));
            }
            bool result= dataAccess.ExecuteSql(sql.ToString());
            if (result)//ִ�а�������������
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
        /// ɾ��һ��ʵ�����
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <param name="pk">����id</param>
        /// <returns>�Ƿ�ɹ�ɾ��</returns>
        public static bool Delete<T>(object pk)
        {
            CheckConn();
            if (pk == null || pk.ToString().Length == 0)
            {
                throw new ArgumentException("ɾ����PK��������Ϊ�գ�");
                //return null;
            }

            string sql = "delete from "+SimpleOrmCache.GetTableName(typeof(T)) + " where " + SimpleOrmCache.GetPK(typeof(T)) + "=" + pk.ToString();
            return dataAccess.ExecuteSql(sql);
        }

        public static bool Delete(object entity)
        {
            if (entity == null)
            {
                //throw new ArgumentException("ɾ����PK��������Ϊ�գ�");
                return false;
            }
            CheckConn();
            
            Type type = entity.GetType();
            string pk=SimpleOrmCache.GetPK(type);
            object value = type.GetField(pk, BindingFlags.IgnoreCase|BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy).GetValue(entity);
            string sql = "delete from " + SimpleOrmCache.GetTableName(type) + " where " + pk + "=" + value.ToString();
            return dataAccess.ExecuteSql(sql);
        }

        /// <summary>
        /// ��ѯһ���������
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="pk">����ֵ</param>
        /// <returns>һ������</returns>
        public static T Query<T>(object pk)
        {
            CheckConn();
            if (pk == null || pk.ToString().Length == 0)
            {
                throw new ArgumentException("��ѯ��PK��������Ϊ�գ�");
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
        /// ��ѯһ�������б��������
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="pk">����ֵ</param>
        /// <returns>һ������</returns>
        public static ArrayList QueryList<T>(string sql)
        {
            return QueryList(typeof(T),sql);

        }

        /// <summary>
        /// ��ѯһ�������б��������
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="pk">����ֵ</param>
        /// <returns>һ������</returns>
        public static ArrayList QueryList(Type type,string sql)
        {
            CheckConn();
            ArrayList list = new ArrayList();
            CheckConn();
            if (sql == null || sql.ToString().Length == 0)
            {
                throw new ArgumentException("��ѯ����䲻��Ϊ�գ�");
                //return null;
            }

            // string sql = SimpleOrmCache.GetSelectSql(typeof(T)) + " where " + SimpleOrmCache.GetPK(typeof(T)) + "=" + pk.ToString();
            DataTable dt = dataAccess.SelectDataTable(sql, SimpleOrmCache.GetTableName(type));
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr=null;
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    dr= dt.Rows[i];
                    list.Add(CreateFromDataRow(type,dr));
                }
            }
            return list;

        }

        /// <summary>
        /// ���ز�ѯ�����ļ�¼����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int QueryCounts<T>(string condition)
        {
            return QueryCounts(typeof(T), condition);
        }

        /// <summary>
        /// ���ز�ѯ�����ļ�¼����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int QueryCounts(Type type,string condition)
        {
            CheckConn();
            string sql = "select count(*) from " + SimpleOrmCache.GetTableName(type) + condition;
            object obj = dataAccess.SelectScalar(sql);
            return Convert.ToInt32(obj);

        }

        /// <summary>
        /// ���ز�ѯ�����ļ�¼����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int QueryCounts(string table,string condition)
        {
            CheckConn();
            string sql = "select count(*) from " + table + condition;
            object obj = dataAccess.SelectScalar(sql);
            return Convert.ToInt32(obj);

        }

        #endregion
        #region ������ѯ����

        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <param name="condition">�������</param>
        /// <param name="pager">��ҳ����</param>
        /// <param name="order">������</param>
        /// <param name="isDesc">�Ƿ���</param>
        /// <returns></returns>
        public List<T> Query<T>(string condition, Pager pager,string order ,bool isDesc)
        {
            CheckConn();
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



        #region ��������
        /// <summary>
        /// ����datarow����һ���������
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="dr">datarow</param>
        /// <returns>����һ������</returns>
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
        /// ����datarow����һ���������
        /// </summary>
        /// <typeparam name="T">����</typeparam>
        /// <param name="dr">datarow</param>
        /// <returns>����һ������</returns>
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
        /// �����ֶε����ͣ����и�ֵ
        /// </summary>
        /// <param name="obj">ʵ�����</param>
        /// <param name="field">�ֶ�</param>
        /// <param name="value">�����ֵ</param>
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
                    field.SetValue(obj, Convert.ToDateTime(value));
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
