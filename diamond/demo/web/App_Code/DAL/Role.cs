// ================================================================================
// 		File: Role.cs
// 		Desc: Role���ݲ����ࡣ
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

	/// <summary>
	/// Role���ݲ����ࡣ
	/// </summary>
public class Role : ModuleDALBase
	{
		#region ��Ա���������캯������������
		
		int m_nRole_ID;
		string m_strRole_Name;

		/// <summary>
		/// ��ʼ����Role����ʵ����
		/// </summary>
		public Role()
		{
			
		}

		/// <summary>
		/// ����������
		/// </summary>
		~ Role()
		{
		}

		#endregion

		#region �ֶ�����
		

		/// <summary>
		/// ��ȡ������Role_ID��
		/// </summary>
		[DBField("Role_ID",ACE.Common.EnumDBFieldUsage.PrimaryKey)]
		public int Role_ID
		{
			get
			{
				return m_nRole_ID;
			}
			set
			{
				m_nRole_ID=value;
			}
		}

		/// <summary>
		/// ��ȡ������Role_Name���ֶγ���Ϊ50��
		/// </summary>
		[DBField("Role_Name")]
		public string Role_Name
		{
			get
			{
				return m_strRole_Name;
			}
			set
			{
				m_strRole_Name=value;
			}
		}
		#endregion

		#region ��������
		#endregion

		#region �ۺϹ���
		#endregion

		#region �ۺϲ�ѯ
		#endregion

	}