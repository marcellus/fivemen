// ================================================================================
// 		File: Role.cs
// 		Desc: Role数据操作类。
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
	/// Role数据操作类。
	/// </summary>
public class Role : ModuleDALBase
	{
		#region 成员变量、构造函数和析构函数
		
		int m_nRole_ID;
		string m_strRole_Name;

		/// <summary>
		/// 初始化类Role的新实例。
		/// </summary>
		public Role()
		{
			
		}

		/// <summary>
		/// 析构函数。
		/// </summary>
		~ Role()
		{
		}

		#endregion

		#region 字段属性
		

		/// <summary>
		/// 获取或设置Role_ID。
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
		/// 获取或设置Role_Name，字段长度为50。
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

		#region 对象属性
		#endregion

		#region 综合管理
		#endregion

		#region 综合查询
		#endregion

	}