// ================================================================================
// 		File: Main_Type.cs
// 		Desc: Main_Type���ݲ����ࡣ
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
    using System.Data;
    using ACE.Common;
    using ACE.Common.DB;
    using System.Data.SqlClient;
    using System.Text;
    using System.IO;

	/// <summary>
	/// Main_Type���ݲ����ࡣ
	/// </summary>
    public class Main_Type : ModuleDALBase
	{
		#region ��Ա���������캯������������
		
		int m_nType_ID;
		string m_strType_Name;

		/// <summary>
		/// ��ʼ����Main_Type����ʵ����
		/// </summary>
		public Main_Type()
		{
			
		}

		/// <summary>
		/// ����������
		/// </summary>
		~ Main_Type()
		{
		}

		#endregion

		#region �ֶ�����
		

		/// <summary>
		/// ��ȡ������Type_ID��
		/// </summary>
		[DBField("Type_ID",ACE.Common.EnumDBFieldUsage.PrimaryKey)]
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
		/// ��ȡ������Type_Name���ֶγ���Ϊ100��
		/// </summary>
		[DBField("Type_Name")]
		public string Type_Name
		{
			get
			{
				return m_strType_Name;
			}
			set
			{
				m_strType_Name=value;
			}
		}
		#endregion

		#region ��������
		#endregion

		#region �ۺϹ���
		#endregion

		#region �ۺϲ�ѯ
        public DataSet GetAllMainType()
        {
            string sql = "select * from Main_Type order by Type_Name";
            return this.DatabaseAccess.ExecuteDataset(sql);
        }

        public string GetTypeName(string id)
        {
            int intid = 0;
            if (id != string.Empty)
            {
                intid = Convert.ToInt32(id);
            }
            string sql = "select Type_Name from Main_Type where Type_ID=" + intid + "";
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