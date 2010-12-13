//----------------------------------------------------------------------------------------------------
//Name:	GLOBAL_TOOLS
//Function:	
//Author:	
// Date:	
//----------------------------------------------------------------------------------------------------
using System;
using System.Diagnostics ;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;

namespace FT.Web.Tools
{
	/// <summary>
	/// Web常用工具
	/// </summary>
	public class WebTools
	{	
	    /// <summary>
	    /// 私有构造函数
	    /// </summary>
		private WebTools()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        public static void WriteTitle(Page pg,string title)
        {
            pg.RegisterStartupScript("title", "<script>document.title='重庆国通工程技术有限公司-" + title + "';</script>");
        }

        public static string GeneratorRandom(int count)
        {
            System.Random rd = new Random();
            int result =0;
            for (int i = 0; i < count; i++)
            {
                int p = (int)Math.Pow(10, i);
                result = result + rd.Next(1, 9) * p;

                //123 = 3 + 2 * 10 + 1 * 100;
            }
            return result.ToString();
        }

        public static void InsertDefaultDDL(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("请选择","-1"));
        }
        public static void SetDDLByText(DropDownList ddl, string value)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Text == value)
                {
                    ddl.SelectedIndex = i;
                    return;
                }
            }
        }

        public static void SetDDLByValue(DropDownList ddl, string value)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value == value)
                {
                    ddl.SelectedIndex = i;
                    return;
                }
            }
        }
        public static void Open(string url, int width, int height)
        {
            WriteScript("window.open('" + url + "','','height=" + height + "px, width=" + width + "px, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no','_blank')");
        }
        public static void ShowModalWindows(string url,int width,int height)
        {
            //WriteScript();
            //'ShowMessage.aspx', '','height=300, width=400, top=250, left=250, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no','_blank'
            WriteScript("window.showModalDialog('"+url+"','','height="+height+"px, width="+width+"px, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no')");
        }

        public static void ShowModalWindows(Page pg,string url, int width, int height)
        {
            

            pg.ClientScript.RegisterStartupScript(123.GetType(),"pop", "<script language='javascript'>window.showModalDialog('" + url + "','','dialogHeight=" + height + "px;dialogWidth=" + width + "px');</script>");
            
        }

        public static uint IP2Int(string ip)
        {
            uint IP = 0;
            byte[] addbyte = new byte[128];
            try
            {
                System.Net.IPAddress ipaddr = System.Net.IPAddress.Parse(ip);
                addbyte = ipaddr.GetAddressBytes();
                byte[] IPByte = new byte[4];
                IPByte[0] = addbyte[3];
                IPByte[1] = addbyte[2];
                IPByte[2] = addbyte[1];
                IPByte[3] = addbyte[0];
                IP = System.BitConverter.ToUInt32(IPByte, 0);//??????
            }
            catch (System.Exception e1)
            {
                return 0;
            }
            return IP;
        }

        public static uint GetClientIP()
        {
            try
            {
                uint IP = 0;
                string ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                IP = IP2Int(ip);
                return IP;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        /// <summary>
        /// 通知窗口
        /// </summary>
        /// <param name="msg">消息内容，换行请用\\n</param>
        public static void Alert(string msg)
        {
            WriteScript("alert('"+msg+"');");
        }

        public static void Alert(Page pg, string msg)
        {
            pg.ClientScript.RegisterStartupScript(typeof(int), "alertmsg", "<script language='javascript'>alert('" + msg + "');</script>");
        }

        /// <summary>
        /// 向当前页面写出脚本内容
        /// </summary>
        /// <param name="scriptContent">脚本内容</param>
        public static void WriteScript(string scriptContent)
        {
            System.Web.HttpContext.Current.Response.Write("<script language='javascript'>"+scriptContent+"</script>");
        }
        [Obsolete]
		public static void CloseSelf(Page pg)
		{
            pg.ClientScript.RegisterStartupScript(typeof(int),"closeself", "<script language='javascript'>window.opener=null;window.close();</script>");
		}
        /// <summary>
        /// 关闭页面target为self的页面
        /// </summary>
       	public static void CloseSelf()
		{
			WriteScript("window.opener=null;window.close();");
		}

        /// <summary>
        /// 根据Repeater导出名叫reportname的excel报表
        /// </summary>
        /// <param name="reportname">报表名字带xls后缀</param>
        /// <param name="rp">Repeater控件</param>
		public static void ExportExcelReport(string reportname,Repeater rp)
		{
			
			System.Web.HttpContext.Current.Response.Clear();			
			System.Web.HttpContext.Current.Response.ContentEncoding=System.Text.Encoding.UTF8;		
			System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(reportname));
			System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
			rp.RenderControl(new HtmlTextWriter(System.Web.HttpContext.Current.Response.Output));
			System.Web.HttpContext.Current.Response.End();		
		    
		}

        /// <summary>
        /// 根据表头跟datatable导出名叫reportname的excel报表
        /// </summary>
        /// <param name="reportname">报表名字带xls后缀</param>
        /// <param name="array">表头字符串数组</param>
        /// <param name="dt">datatable</param>
		public static void ExportExcelReport(string reportname,string[] array,DataTable dt)
		{
			System.Web.HttpContext.Current.Response.Clear();			
			System.Web.HttpContext.Current.Response.ContentEncoding=System.Text.Encoding.UTF8;		
			System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(reportname));
			System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
			
			string title=string.Empty;
			foreach(string str  in array)
			{
				title+=str+"	";
			}
			byte[] title_b = System.Text.Encoding.GetEncoding("GB2312").GetBytes(title);
			System.Web.HttpContext.Current.Response.BinaryWrite(title_b);	
			System.Web.HttpContext.Current.Response.Write('\r');			
			int rowIndex = dt.Rows.Count;
			int colIndex = dt.Columns.Count;				
			for(int i=0;i<rowIndex;i++)
			{
				DataRow row = dt.Rows[i];
				for(int j=0;j<colIndex;j++)
				{					
					byte[] temp = System.Text.Encoding.GetEncoding("GB2312").GetBytes(row[j].ToString()+"	");
					System.Web.HttpContext.Current.Response.BinaryWrite(temp);					
				}
				System.Web.HttpContext.Current.Response.Write('\r');	
				System.Web.HttpContext.Current.Response.Flush();
			}			
			System.Web.HttpContext.Current.Response.End();
		}

        /// <summary>
        /// 根据datatable导出名叫reportname的excel报表
        /// </summary>
        /// <param name="reportname">报表名字带xls后缀</param>
        /// <param name="dt">datatable</param>
		public static void ExportExcelReport(string reportname,DataTable dt)
		{
			System.Web.HttpContext.Current.Response.Clear();			
			System.Web.HttpContext.Current.Response.ContentEncoding=System.Text.Encoding.UTF8;		
			System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(reportname));
			System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
			
			string title=string.Empty;
			foreach(DataColumn dc in dt.Columns)
			{
				title+=dc.ColumnName+"	";
			}
			byte[] title_b = System.Text.Encoding.GetEncoding("GB2312").GetBytes(title);
			System.Web.HttpContext.Current.Response.BinaryWrite(title_b);	
			System.Web.HttpContext.Current.Response.Write('\r');			
			int rowIndex = dt.Rows.Count;
			int colIndex = dt.Columns.Count;				
			for(int i=0;i<rowIndex;i++)
			{
				DataRow row = dt.Rows[i];
				for(int j=0;j<colIndex;j++)
				{					
					byte[] temp = System.Text.Encoding.GetEncoding("GB2312").GetBytes(row[j].ToString()+"	");
					System.Web.HttpContext.Current.Response.BinaryWrite(temp);					
				}
				System.Web.HttpContext.Current.Response.Write('\r');	
				System.Web.HttpContext.Current.Response.Flush();
			}			
			System.Web.HttpContext.Current.Response.End();
		}

        /// <summary>
        /// 根据datagrid导出名叫reportname的excel报表
        /// </summary>
        /// <param name="reportname">报表名字带xls后缀</param>
        /// <param name="dg">datagrid控件</param>
		public static void ExportExcelReport(string reportname,DataGrid dg)
		{
			
			System.Web.HttpContext.Current.Response.Clear();			
			System.Web.HttpContext.Current.Response.ContentEncoding=System.Text.Encoding.UTF8;		
			System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(reportname));
			System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
			dg.RenderControl(new HtmlTextWriter(System.Web.HttpContext.Current.Response.Output));		
			System.Web.HttpContext.Current.Response.End();		
		    
		}
/*
		public static void ShowErrorMessage (   String str ) 
		{
			str = HttpUtility.UrlEncode(str);
			System.Web.HttpContext.Current.Response.Redirect ( "../frmErrorMessage.aspx?strMessage=" + str ,true  ) ;
		}

		public static void ShowErrorMessage (  String str, int iIsClose) 
		{
			str = HttpUtility.UrlEncode(str);
			System.Web.HttpContext.Current.Response.Redirect ( "../frmErrorMessage.aspx?IsClose=" + iIsClose + "&strMessage=" + str , true ) ;
		}

		public static void ShowReturnMessage ( String str ) 
		{
			str = HttpUtility.UrlEncode(str);
			System.Web.HttpContext.Current.Response.Redirect ( "../frmReturnMessage.aspx?strMessage=" + str , true  ) ;
		}

		public static void ShowMessage (  String str ) 
		{
			str = HttpUtility.UrlEncode(str);
			System.Web.HttpContext.Current.Response.Redirect ( "../frmMessage.aspx?strMessage=" + str , true  ) ;
		}

		public static void ShowMessage ( String str , int iRefresh ) 
		{
			str = HttpUtility.UrlEncode(str);
			System.Web.HttpContext.Current.Response.Redirect ( "../frmMessage.aspx?refresh=" + iRefresh + "&strMessage=" + str , true  ) ;
		}

		public static void ShowMessage ( String str , String strURL)
		{
			str = HttpUtility.UrlEncode(str);
			strURL = HttpUtility.UrlEncode(strURL);
			System.Web.HttpContext.Current.Response.Redirect ( "../frmMessage.aspx?strMessage=" + str + "&backURL=" + strURL , true  ) ;
		}

		public static void ShowMessage ( String str , String strURL,int iRefresh)
		{
			str = HttpUtility.UrlEncode(str);
			strURL = HttpUtility.UrlEncode(strURL);
			System.Web.HttpContext.Current.Response.Redirect ( "../frmMessage.aspx?strMessage=" + str + "&backURL=" + strURL+"&refresh=" + iRefresh , true  ) ;
		}

		public static void ShowErrorMessage (  String strMes , String strURL)
		{
			strMes = HttpUtility.UrlEncode(strMes);
			strURL = HttpUtility.UrlEncode(strURL);
			System.Web.HttpContext.Current.Response.Redirect ( "../frmErrorMessage.aspx?strMessage=" + strMes + "&backURL=" + strURL , true  ) ;
		}

		public static void ShowErrorMessagePop (   String str ) 
		{
			str = HttpUtility.UrlEncode(str);
			System.Web.HttpContext.Current.Response.Write("<script>alert('"+str+"')</script>");
			return ;
		}

		public static void ShowErrorMessageRoot(  String str)
		{
			
			str = HttpUtility.UrlEncode(str);
			System.Web.HttpContext.Current.Response.Redirect("frmErrorMessage.aspx?strMessage="+str ,true);
		}
 * */
	}
}

