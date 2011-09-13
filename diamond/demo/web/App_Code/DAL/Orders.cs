// ================================================================================
// 		File: Orders.cs
// 		Desc: Orders���ݲ����ࡣ
//  
// 		Called by:   
//               
// 		Auth: PC
// 		Date: 2009-11-19
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
	/// Orders���ݲ����ࡣ
	/// </summary>
public class Orders : ModuleDALBase
	{
		#region ��Ա���������캯������������
		
		int m_nOrder_ID;
		string m_strOrder_Name;
		string m_strDelete_YN;
		int m_nCreated_By;
		DateTime m_dtCreated_Date;

		/// <summary>
		/// ��ʼ����Orders����ʵ����
		/// </summary>
		public Orders()
		{
			
		}

		/// <summary>
		/// ����������
		/// </summary>
		~ Orders()
		{
		}

		#endregion

        #region �ֶ�����


        /// <summary>
		/// ��ȡ������Order_ID��
		/// </summary>
		[DBField("Order_ID",ACE.Common.EnumDBFieldUsage.PrimaryKey)]
		public int Order_ID
		{
			get
			{
				return m_nOrder_ID;
			}
			set
			{
				m_nOrder_ID=value;
			}
		}

		/// <summary>
		/// ��ȡ������Order_Name���ֶγ���Ϊ10��
		/// </summary>
		[DBField("Order_Name")]
		public string Order_Name
		{
			get
			{
				return m_strOrder_Name;
			}
			set
			{
				m_strOrder_Name=value;
			}
		}

		/// <summary>
		/// ��ȡ������Delete_YN���ֶγ���Ϊ1��
		/// </summary>
		[DBField("Delete_YN")]
		public string Delete_YN
		{
			get
			{
				return m_strDelete_YN;
			}
			set
			{
				m_strDelete_YN=value;
			}
		}

		/// <summary>
		/// ��ȡ������Created_By��
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
		/// ��ȡ������Created_Date��
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
		#endregion

		#region ��������
		#endregion

		#region �ۺϹ���
		#endregion

		#region �ۺϲ�ѯ
        public DataSet GetAllOrder()
        {
            string sql = "select * from Orders where Delete_YN<>'Y' order by Created_Date desc";
            return this.DatabaseAccess.ExecuteDataset(sql);
        }

        public string GetOrderNamebyID(string id)
        {
            int intid = 0;
            if (id != string.Empty)
            {
                intid = Convert.ToInt32(id);
            }
            string sql = "select Order_Name from Orders where Order_ID=" + intid + "";
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
		#endregion

	}