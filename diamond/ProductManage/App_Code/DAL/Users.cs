// ================================================================================
// 		File: Users.cs
// 		Desc: Users数据操作类。
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
	/// Users数据操作类。
	/// </summary>
public class Users : ModuleDALBase
	{
		#region 成员变量、构造函数和析构函数
		
		int m_nUser_ID;
		string m_strUser_Name;
		string m_strPassWord;
		string m_strRole;

		/// <summary>
		/// 初始化类Users的新实例。
		/// </summary>
		public Users()
		{
			
		}

		/// <summary>
		/// 析构函数。
		/// </summary>
		~ Users()
		{
		}

		#endregion

		#region 字段属性
		

		/// <summary>
		/// 获取或设置User_ID。
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
		/// 获取或设置User_Name，字段长度为100。
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
		/// 获取或设置PassWord，字段长度为50。
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
		/// 获取或设置Role，字段长度为50。
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

		#region 对象属性
		#endregion

		#region 综合管理
		#endregion

		#region 综合查询
		#endregion

	}