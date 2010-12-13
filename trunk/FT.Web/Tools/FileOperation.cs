using System;
using System.IO;

namespace FT.Web.Tools
{
	/// <summary>
	/// FileOperation 的摘要说明。
	/// </summary>
	public class FileOperation
	{
		public FileOperation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static void DeleteFile(string dirname,string search)
		{
			DeleteFile(dirname,search,-1);
		}

		public static void DeleteFile(string dirname)
		{
			DeleteFile(dirname,string.Empty,-1);
		}

		public static void DeleteFile(string dirname,int time)
		{
			DeleteFile(dirname,string.Empty,time);
		}

		/// <summary>
		/// 删除文件夹下的文件
		/// </summary>
		/// <param name="dirname">目录</param>
		/// <param name="search">搜索字符串</param>
		/// <param name="time">时间超过多少毫秒的删除</param>
		public static void DeleteFile(string dirname,string search,int time)
		{
			System.IO.DirectoryInfo dir=new DirectoryInfo(dirname);
			System.IO.FileInfo[] files;
			if(search!=string.Empty)
			{
				files=dir.GetFiles(search);
			}
			else
			{
				files=dir.GetFiles();
			}
			if(files!=null)
			{
				for(int i=0;i<files.Length;i++)
				{
					
					if(time!=-1)
					{
						TimeSpan ts=System.DateTime.Now.Subtract(files[i].CreationTime);
						if(ts.TotalMilliseconds>time)
						   files[i].Delete();
					}
					else
					{
                          files[i].Delete();
					}
				}
			}
		}
	}
}
