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
public class Product : ModuleDALBase
	{
		#region 成员变量、构造函数和析构函数
		
		int m_nProduct_ID;
		string m_strBarcode;
		string m_strProduct_Name;
		int m_nType_ID;
		int m_nSType_ID;
		int m_nColor_ID;
		string m_strProduct_Size;
		string m_strPicture;
		int m_nOrder_Number;
		int m_nReal_Number;
		DateTime m_dtCreated_Date;
		int m_nCreated_By;
		DateTime m_dtModify_Date;
		int m_nModify_By;

		/// <summary>
		/// 初始化类Product的新实例。
		/// </summary>
		public Product()
		{
			
		}

		/// <summary>
		/// 析构函数。
		/// </summary>
		~ Product()
		{
		}

		#endregion

		#region 字段属性
		

		/// <summary>
		/// 获取或设置Product_ID。
		/// </summary>
		[DBField("Product_ID",ACE.Common.EnumDBFieldUsage.PrimaryKey)]
		public int Product_ID
		{
			get
			{
				return m_nProduct_ID;
			}
			set
			{
				m_nProduct_ID=value;
			}
		}

		/// <summary>
		/// 获取或设置Barcode，字段长度为13。
		/// </summary>
		[DBField("Barcode")]
		public string Barcode
		{
			get
			{
				return m_strBarcode;
			}
			set
			{
				m_strBarcode=value;
			}
		}

		/// <summary>
		/// 获取或设置Product_Name，字段长度为100。
		/// </summary>
		[DBField("Product_Name")]
		public string Product_Name
		{
			get
			{
				return m_strProduct_Name;
			}
			set
			{
				m_strProduct_Name=value;
			}
		}

		/// <summary>
		/// 获取或设置Type_ID。
		/// </summary>
		[DBField("Type_ID")]
		public int Type_ID
		{
			get
			{
				return m_nType_ID;
			}
			set
			{
				m_nType_ID=value;
			}
		}

		/// <summary>
		/// 获取或设置SType_ID。
		/// </summary>
		[DBField("SType_ID")]
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
		/// 获取或设置Color_ID。
		/// </summary>
		[DBField("Color_ID")]
		public int Color_ID
		{
			get
			{
				return m_nColor_ID;
			}
			set
			{
				m_nColor_ID=value;
			}
		}

		/// <summary>
		/// 获取或设置Product_Size，字段长度为10。
		/// </summary>
		[DBField("Product_Size")]
		public string Product_Size
		{
			get
			{
				return m_strProduct_Size;
			}
			set
			{
				m_strProduct_Size=value;
			}
		}

		/// <summary>
		/// 获取或设置Picture，字段长度为100。
		/// </summary>
		[DBField("Picture")]
		public string Picture
		{
			get
			{
				return m_strPicture;
			}
			set
			{
				m_strPicture=value;
			}
		}

		/// <summary>
		/// 获取或设置Order_Number。
		/// </summary>
		[DBField("Order_Number")]
		public int Order_Number
		{
			get
			{
				return m_nOrder_Number;
			}
			set
			{
				m_nOrder_Number=value;
			}
		}

		/// <summary>
		/// 获取或设置Real_Number。
		/// </summary>
		[DBField("Real_Number")]
		public int Real_Number
		{
			get
			{
				return m_nReal_Number;
			}
			set
			{
				m_nReal_Number=value;
			}
		}

		/// <summary>
		/// 获取或设置Created_Date。
		/// </summary>
		[DBField("Created_Date")]
		public DateTime Created_Date
		{
			get
			{
				return m_dtCreated_Date;
			}
			set
			{
				m_dtCreated_Date=value;
			}
		}

		/// <summary>
		/// 获取或设置Created_By。
		/// </summary>
		[DBField("Created_By")]
		public int Created_By
		{
			get
			{
				return m_nCreated_By;
			}
			set
			{
				m_nCreated_By=value;
			}
		}

		/// <summary>
		/// 获取或设置Modify_Date。
		/// </summary>
		[DBField("Modify_Date")]
		public DateTime Modify_Date
		{
			get
			{
				return m_dtModify_Date;
			}
			set
			{
				m_dtModify_Date=value;
			}
		}

		/// <summary>
		/// 获取或设置Modify_By。
		/// </summary>
		[DBField("Modify_By")]
		public int Modify_By
		{
			get
			{
				return m_nModify_By;
			}
			set
			{
				m_nModify_By=value;
			}
		}
		#endregion

		#region 对象属性
		#endregion

		#region 综合管理
		#endregion

		#region 综合查询
        public DataSet GetExportData(string orderid, string typeid, string subtypeid)
        {
            string sql = @"select Product_Name as Name,StyleID as Style,Barcode,Type_Name,SType_Name,Product_Size as Size,Color_Name as Color,Order_Number,Real_Number,Descriptions,Picture from Product 
                        left join Color on Product.Color_ID=Color.Color_ID left join Main_Type on Product.Type_ID=Main_Type.Type_ID 
                        left join Small_Type on Product.SType_ID=Small_Type.SType_ID where 1=1";
            if (orderid != string.Empty)
            {
                sql += string.Format(" and Order_Name={0}", Convert.ToInt32(orderid));
            }
            if (typeid != string.Empty)
            {
                sql += string.Format(" and Product.Type_ID={0}", Convert.ToInt32(typeid));
            }
            if (subtypeid != string.Empty)
            {
                sql += string.Format(" and Product.SType_ID in ('{0}')", subtypeid.Replace(",", "','"));
            }
            sql += " order by Product_ID desc";
            return this.DatabaseAccess.ExecuteDataset(sql);
        }

        public DataSet GetExportData(string orderid, string typeid, string subtypeid,string size)
        {
            string sql = @"select Product_Name as Name,StyleID as Style,Barcode,Type_Name,SType_Name,Product_Size as Size,Color_Name as Color,Order_Number,Real_Number,Descriptions,Picture from Product 
                        left join Color on Product.Color_ID=Color.Color_ID left join Main_Type on Product.Type_ID=Main_Type.Type_ID 
                        left join Small_Type on Product.SType_ID=Small_Type.SType_ID where 1=1";
            if (orderid != string.Empty)
            {
                sql += string.Format(" and Order_Name={0}", Convert.ToInt32(orderid));
            }
            if (typeid != string.Empty)
            {
                sql += string.Format(" and Product.Type_ID={0}", Convert.ToInt32(typeid));
            }
            if (subtypeid != string.Empty)
            {
                sql += string.Format(" and Product.SType_ID in ('{0}')", subtypeid.Replace(",", "','"));
            }
            sql += " order by replicate('0',10-len(Product_Size))+Product_Size asc, Product_ID desc";
            return this.DatabaseAccess.ExecuteDataset(sql);
        }


        public string GetPicture(string barcode)
        {
            string sql = "select Picture from Product where Barcode='" + barcode + "'";
            DataSet ds = this.DatabaseAccess.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0] != DBNull.Value)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        public int getMaxID()
        {
            int maxid=0;
            string sql = "select max(a.Product_ID) from product a ";
            DataSet ds = this.DatabaseAccess.ExecuteDataset(sql);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                maxid = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            return maxid;
        
        }
    /// <summary>
    /// 根据产品编号获取复秤
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
        public double GetComfirmWeight(string ID)
        {
            double weight = 0;
            string sql = string.Format("select ComfirmWeight from Product where Product_ID={0}", ID);
            DataSet ds = this.DatabaseAccess.ExecuteDataset(sql);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            { 
                weight=ds.Tables[0].Rows[0][0].ToString()==""?0:double.Parse(ds.Tables[0].Rows[0][0].ToString());
            
            }

            return weight;
        
        
        }
       


        public string GetPictureNameList(string idlist)
        {
            string picnamelist = string.Empty;
            string sql = "select Picture from Product where Product_ID in ('" + idlist.Replace(",", "','") + "')";
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

        public bool HaveProductExist(string picturename)
        {
            string sql = "select * from Product where Picture='" + picturename + "'";
            DataSet ds = this.DatabaseAccess.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HaveProductUsethisColor(int id)
        {
            string sql = "select * from Product where Color_ID=" + id + "";
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