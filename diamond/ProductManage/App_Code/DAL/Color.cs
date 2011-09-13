// ================================================================================
// 		File: Color.cs
// 		Desc: Color���ݲ����ࡣ
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
	/// Color���ݲ����ࡣ
	/// </summary>
public class Color : ModuleDALBase
	{
		#region ��Ա���������캯������������
		
		int m_nColor_ID;
		string m_strColor_Name;

		/// <summary>
		/// ��ʼ����Color����ʵ����
		/// </summary>
		public Color()
		{
			
		}

		/// <summary>
		/// ����������
		/// </summary>
		~ Color()
		{
		}

		#endregion

		#region �ֶ�����
		

		/// <summary>
		/// ��ȡ������Color_ID��
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
		/// ��ȡ������Color_Name���ֶγ���Ϊ50��
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

		#region ��������
		#endregion

		#region �ۺϹ���
		#endregion

		#region �ۺϲ�ѯ
		#endregion

	}