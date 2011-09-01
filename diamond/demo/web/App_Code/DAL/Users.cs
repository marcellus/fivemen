// ================================================================================
// 		File: Users.cs
// 		Desc: Users���ݲ����ࡣ
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
	/// Users���ݲ����ࡣ
	/// </summary>
public class Users : ModuleDALBase
	{
		#region ��Ա���������캯������������
		
		int m_nUser_ID;
		string m_strUser_Name;
		string m_strPassWord;
		string m_strRole;

		/// <summary>
		/// ��ʼ����Users����ʵ����
		/// </summary>
		public Users()
		{
			
		}

		/// <summary>
		/// ����������
		/// </summary>
		~ Users()
		{
		}

		#endregion

		#region �ֶ�����
		

		/// <summary>
		/// ��ȡ������User_ID��
		/// </summary>
		[DBField("User_ID",ACE.Common.EnumDBFieldUsage.PrimaryKey)]
		public int User_ID
		{
			get
			{
				return m_nUser_ID;
			}
			set
			{
				m_nUser_ID=value;
			}
		}

		/// <summary>
		/// ��ȡ������User_Name���ֶγ���Ϊ100��
		/// </summary>
		[DBField("User_Name")]
		public string User_Name
		{
			get
			{
				return m_strUser_Name;
			}
			set
			{
				m_strUser_Name=value;
			}
		}

		/// <summary>
		/// ��ȡ������PassWord���ֶγ���Ϊ50��
		/// </summary>
		[DBField("PassWord")]
		public string PassWord
		{
			get
			{
				return m_strPassWord;
			}
			set
			{
				m_strPassWord=value;
			}
		}

		/// <summary>
		/// ��ȡ������Role���ֶγ���Ϊ50��
		/// </summary>
		[DBField("Role")]
		public string Role
		{
			get
			{
				return m_strRole;
			}
			set
			{
				m_strRole=value;
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