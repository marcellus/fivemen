// ================================================================================
// 		File: Product.cs
// 		Desc: Product���ݲ����ࡣ
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
	/// Product���ݲ����ࡣ
	/// </summary>
public class StorageList : ModuleDALBase
	{
		#region ��Ա���������캯������������
		
		
		string m_storagrno;
		string m_storagrdescription;
		DateTime m_generationtime;
		

		/// <summary>
		/// ��ʼ����Product����ʵ����
		/// </summary>
		public StorageList()
		{
			
		}

		/// <summary>
		/// ����������
		/// </summary>
        ~StorageList()
		{
		}

		#endregion

		#region �ֶ�����
		

		/// <summary>
        /// ��ȡ������StorageNo��
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
        /// ��ȡ������GenerationTime��
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

		#region ��������
		#endregion

		#region �ۺϹ���
		#endregion

		#region �ۺϲ�ѯ
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
    /// ������ⵥ�Ż�ȡ��Ӧ��¼
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