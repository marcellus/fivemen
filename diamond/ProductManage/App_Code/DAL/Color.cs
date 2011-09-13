// ================================================================================
// 		File: Color.cs
// 		Desc: Color数据操作类。
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
	/// Color数据操作类。
	/// </summary>
public class Color : ModuleDALBase
	{
		#region 成员变量、构造函数和析构函数
		
		int m_nColor_ID;
		string m_strColor_Name;

		/// <summary>
		/// 初始化类Color的新实例。
		/// </summary>
		public Color()
		{
			
		}

		/// <summary>
		/// 析构函数。
		/// </summary>
		~ Color()
		{
		}

		#endregion

		#region 字段属性
		

		/// <summary>
		/// 获取或设置Color_ID。
		/// </summary>
		[DBField("Color_ID",ACE.Common.EnumDBFieldUsage.PrimaryKey)]
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
		/// 获取或设置Color_Name，字段长度为50。
		/// </summary>
		[DBField("Color_Name")]
		public string Color_Name
		{
			get
			{
				return m_strColor_Name;
			}
			set
			{
				m_strColor_Name=value;
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