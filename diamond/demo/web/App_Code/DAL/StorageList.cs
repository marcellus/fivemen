// ================================================================================
// 		File: Product.cs
// 		Desc: Product数据操作类。
//  
// 		Called by:   
//               
// 		Auth: PC
// 		Date: 2009-11-18
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//    
// ================================================================================
// Copyright (C) 2009-2010 ACE Corporation
// ================================================================================

	using System;
	using ACE.Common;
    using ACE.Common.DB;
using System.Data;

	/// <summary>
	/// Product数据操作类。
	/// </summary>
public class StorageList : ModuleDALBase
	{
		#region 成员变量、构造函数和析构函数
		
		
		string m_storagrno;
		string m_storagrdescription;
		DateTime m_generationtime;
		

		/// <summary>
		/// 初始化类Product的新实例。
		/// </summary>
		public StorageList()
		{
			
		}

		/// <summary>
		/// 析构函数。
		/// </summary>
        ~StorageList()
		{
		}

		#endregion

		#region 字段属性
		

		/// <summary>
        /// 获取或设置StorageNo。
		/// </summary>
        [DBField("StorageNo", ACE.Common.EnumDBFieldUsage.PrimaryKey)]
		public string  StorageNo
		{
			get
			{
                return m_storagrno;
			}
			set
			{
                m_storagrno = value;
			}
		}

		
        [DBField("StorageDescription")]
        public string StorageDescription
		{
			get
			{
                return m_storagrdescription;
			}
			set
			{
                m_storagrdescription = value;
			}
		}

		

		/// <summary>
        /// 获取或设置GenerationTime。
		/// </summary>
        [DBField("GenerationTime")]
        public DateTime GenerationTime
		{
			get
			{
                return m_generationtime;
			}
			set
			{
                m_generationtime = value;
			}
		}

		
		#endregion

		#region 对象属性
		#endregion

		#region 综合管理
		#endregion

		#region 综合查询
        public DataSet GetExportData(string storageNo, DateTime geStartDate, DateTime geEndDate)
        {
            string sql = @"SELECT StorageNo,StorageDescription,GenerationTime FROM StorageList where 1=1  ";
            if (storageNo != string.Empty)
            {
                sql += string.Format(" and StorageNo='{0}'", Convert.ToInt32(storageNo));
            }
            if (geStartDate != DateTime.MinValue && geEndDate != DateTime.MaxValue)
            {
                sql += string.Format(" and GenerationTime between '{0}' and '{1}", geStartDate.ToString(), geEndDate.AddDays(1).AddMilliseconds(-1).ToString());
            }

            sql += " order by GenerationTime desc";
            return this.DatabaseAccess.ExecuteDataset(sql);
        }

      
        public string GetPictureNameByOrderId(int id)
        {
            string picnamelist = string.Empty;
            string sql = string.Format("select Picture from Product where Order_Name={0}", id);
            DataSet ds = this.DatabaseAccess.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][0] != DBNull.Value)
                    {
                        picnamelist += ds.Tables[0].Rows[i][0].ToString() + ",";
                    }
                }
            }
            return picnamelist == string.Empty ? string.Empty : picnamelist.Substring(0, picnamelist.Length - 1);
        }

    /// <summary>
    /// 根据入库单号获取相应记录
    /// </summary>
    /// <param name="sID"></param>
    /// <returns></returns>
        public DataTable GetEntityByID(string sID)
        {
            string sql = string.Format("SELECT StorageNo,StorageDescription,GenerationTime FROM StorageList where StorageNo='{0}'", sID);
            DataSet ds = this.DatabaseAccess.ExecuteDataset(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public bool HaveProductUsethisCategory(int id)
        {
            string sql = "select * from Product where SType_ID=" + id + "";
            DataSet ds = this.DatabaseAccess.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		#endregion

	}