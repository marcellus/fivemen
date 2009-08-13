using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Util;
using System.Data;
using System.IO;
using System.Web;

namespace FT.Commons.Web.Tools
{
    /// <summary>
    /// web文件导出帮助器
    /// </summary>
    public class FileExportHelper
    {
        private FileExportHelper()
        {


        }
        /// <summary>
        /// 导出Datatable到一个txt文档输出给客户端
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filename"></param>
        /// <param name="encoding"></param>
        /// <param name="timeformat"></param>
        public static void ExportTxt(DataTable dt, string prefixname)
        {
            ExportTxt(dt, prefixname, "UTF-8", string.Empty);
        }

        /// <summary>
        /// 导出Datatable到一个txt文档输出给客户端
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filename"></param>
        /// <param name="encoding"></param>
        /// <param name="timeformat"></param>
        public static void ExportTxt(DataTable dt, string prefixname,string timeformat)
        {
            ExportTxt(dt, prefixname, "UTF-8", timeformat);
        }

        private static void ExportTxt(DataTable dt, string prefixname, string encoding, string timeformat)
        {
            if (dt == null || prefixname .Length== 0)
            {
                throw new ArgumentException("待导出的dt为null，无法进行导出！");
                return;
            }
            HttpResponse response=System.Web.HttpContext.Current.Response;
            Encoding coding=System.Text.Encoding.GetEncoding(encoding);
            response.HeaderEncoding = coding;
            response.AppendHeader("Content-Disposition", "attachment;filename="+
                System.Web.HttpUtility.UrlEncode(prefixname, coding) + ".txt");
            response.ContentEncoding = coding;

            System.IO.StringWriter   oStringWriter   =   new   System.IO.StringWriter();
            
            response.ContentType = "text/plain";
            response.Clear();

            foreach (DataColumn dc in dt.Columns)
            {
                oStringWriter.Write(dc.ColumnName + "\t");
            }
            oStringWriter.Write("\r\n");

            foreach (DataRow  dr in dt.Rows)
            {
                object cell = null;
                for (int i = 0; i < dt.Columns.Count;i++ )
                {
                    cell = dr.ItemArray[i];
                    if(timeformat.Length>0&&dt.Columns[i].DataType==typeof(DateTime))
                    {
                        oStringWriter.Write(cell != null && cell != DBNull.Value ? Convert.ToDateTime(cell).ToString(timeformat)+"\t" : "null\t");
                    }
                    else
                    {
                        oStringWriter.Write(cell != null && cell != DBNull.Value ? cell.ToString()+"\t" : "null\t");
                    }
                }
               
                oStringWriter.Write("\r\n");
            }

            response.Write(oStringWriter.ToString());
            response.End();   
        }
    }
}