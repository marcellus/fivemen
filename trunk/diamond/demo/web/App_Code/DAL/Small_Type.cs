// ================================================================================
// 		File: Small_Type.cs
// 		Desc: Small_Type数据操作类。
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
	/// Small_Type数据操作类。
	/// </summary>
public class Small_Type : ModuleDALBase
	{
		#region 成员变量、构造函数和析构函数
		
		int m_nSType_ID;
		string m_strType_ID;
		string m_strStype_Name;

		/// <summary>
		/// 初始化类Small_Type的新实例。
		/// </summary>
		public Small_Type()
		{
			
		}

		/// <summary>
		/// 析构函数。
		/// </summary>
		~ Small_Type()
		{
		}

		#endregion

		#region 字段属性
		

		/// <summary>
		/// 获取或设置SType_ID。
		/// </summary>
		[DBField("SType_ID",ACE.Common.EnumDBFieldUsage.PrimaryKey)]
		public int SType_ID
		{
			get
			{
				return m_nSType_ID;
			}
			set
			{
				m_nSType_ID=value;
			}
		}

		/// <summary>
		/// 获取或设置Type_ID，字段长度为10。
		/// </summary>
		[DBField("Type_ID")]
		public string Type_ID
		{
			get
			{
				return m_strType_ID;
			}
			set
			{
				m_strType_ID=value;
			}
		}

		/// <summary>
		/// 获取或设置Stype_Name，字段长度为100。
		/// </summary>
		[DBField("Stype_Name")]
		public string Stype_Name
		{
			get
			{
				return m_strStype_Name;
			}
			set
			{
				m_strStype_Name=value;
			}
		}
		#endregion

		#region 对象属性
		#endregion

		#region 综合管理
		#endregion

		#region 综合查询
        public DataSet GetSubType(string filter)
        {
            string sql = "select * from Small_Type left join Main_Type on Small_Type.Type_ID=Main_Type.Type_ID where 1=1";
            if (filter != string.Empty)
            {
                sql = sql + filter;
            }
            return this.DatabaseAccess.ExecuteDataset(sql);
        }

        public string GetSubTypeNameList(string idlist)
        {
            string strReturn = string.Empty;
            string sql = "select SType_Name from Small_Type where SType_ID in ('" + idlist.Replace(",", "','") + "')";
            DataTable dt = this.DatabaseAccess.ExecuteDataset(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0] != DBNull.Value)
                    {
                        strReturn += dr[0].ToString() + ",";
                    }                   
                }
                strReturn = strReturn.Length > 0 ? strReturn.Substring(0, strReturn.Length - 1) : strReturn;
            }
            return strReturn;
        }

        public DataSet GetSubTypeList(string typeid)
        {
            int inttypeid = 0;
            if (typeid != string.Empty)
            {
                inttypeid = Convert.ToInt32(typeid);
            }
            string sql = string.Empty;
            if (inttypeid != 0)
            {
                sql = "select * from Small_Type where Type_ID=" + inttypeid + " order by Type_ID";
            }
            else
            {
                sql = "select * from Small_Type order by Type_ID";
            }
            return this.DatabaseAccess.ExecuteDataset(sql);
        }

        public string GetSubTypeString()
        {
            string sql = "select * from Small_Type order by Type_ID";
            DataSet ds = this.DatabaseAccess.ExecuteDataset(sql);
            string returnstr = string.Empty;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    returnstr += ds.Tables[0].Rows[i]["Type_ID"].ToString() + "%" + ds.Tables[0].Rows[i]["Stype_Name"].ToString() + "%" + ds.Tables[0].Rows[i]["SType_ID"].ToString() + ",";
                }
                returnstr = returnstr == string.Empty ? string.Empty : returnstr.Substring(0, returnstr.Length - 1);
            }
            return returnstr;
        }
		#endregion

	}