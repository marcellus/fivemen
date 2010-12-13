using System;
using System.IO;

namespace FT.Web.Tools
{
	/// <summary>
	/// FileOperation ��ժҪ˵����
	/// </summary>
	public class FileOperation
	{
		public FileOperation()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
		/// ɾ���ļ����µ��ļ�
		/// </summary>
		/// <param name="dirname">Ŀ¼</param>
		/// <param name="search">�����ַ���</param>
		/// <param name="time">ʱ�䳬�����ٺ����ɾ��</param>
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
