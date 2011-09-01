using System;
using System.Data;
using System.Configuration;
using System.Text;
//using Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
/// <summary>
/// 从DataTable中导出EXCEL(HTML格式)
/// 编码为UTF-8
/// </summary>
public class ExportExcel
{
    /// <summary>
    /// 被导出的数据源
    /// </summary>
    private System.Data.DataTable exportDataSource;
    /// <summary>
    /// 要导出的文件名
    /// </summary>
    private string downloadFileName;
    public System.Data.DataTable ExportDataSource
    {
        get
        {
            return exportDataSource;
        }
        set
        {
            exportDataSource = value;
        }
    }
    public string DownloadFileName
    {
        get
        {
            return String.IsNullOrEmpty(this.downloadFileName) ? DateTime.Now.ToString("yyyyMMdd") : this.downloadFileName;
        }
        set
        {
            downloadFileName = value;
        }
    }
    public ExportExcel()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    /// <summary>
    /// 导出文件
    /// </summary>
    public void Download()
    {
        //设置response
        System.Web.HttpContext.Current.Response.Clear();
        System.Web.HttpContext.Current.Response.BufferOutput = true;
        System.Web.HttpContext.Current.Response.Charset = System.Text.Encoding.UTF8.HeaderName;
        System.Web.HttpContext.Current.Response.BufferOutput = true;
        System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + DownloadFileName + ".xls");
        System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
        System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        System.Web.HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.UTF8;
        StringBuilder sb = new StringBuilder();
        //设置HTML头
        sb.Append("<html><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><style>td{mso-number-format:\"\\@\";}</style></head><body><table border=\"1\" cellpadding=\"0\" cellspacing= \"0\"><tr>");
        //循环Columns 设置列名
        if (exportDataSource != null)
        {
            foreach (DataColumn dc in exportDataSource.Columns)
            {
                //sb.AppendFormat("<td>{0}</td>", dc.Caption);
                if (dc.Caption == "Product_Name")
                {
                    sb.AppendFormat("<td>{0}</td>", "品名");
                }
                else if (dc.Caption == "Barcode")
                {
                    sb.AppendFormat("<td>{0}</td>", "条码");
                }
                else if (dc.Caption == "Factory_Weight")
                {
                    sb.AppendFormat("<td>{0}</td>", "工厂货重");
                }

                else if (dc.Caption == "Gold_NetWeight")
                {
                    sb.AppendFormat("<td>{0}</td>", "净金重");
                }
                else if (dc.Caption == "ShouCun")
                {
                    sb.AppendFormat("<td>{0}</td>", "手寸");
                }
                else if (dc.Caption == "Price")
                {
                    sb.AppendFormat("<td>{0}</td>", "零售价");
                }
                else if (dc.Caption == "Style")
                {
                    sb.AppendFormat("<td>{0}</td>", "款号");
                }
                else if (dc.Caption == "Factory_Name")
                {
                    sb.AppendFormat("<td>{0}</td>", "供货商");
                }
                else if (dc.Caption == "SuJinFeiYong")
                {
                    sb.AppendFormat("<td>{0}</td>", "素金工费");
                }
                else if (dc.Caption == "GongFei")
                {
                    sb.AppendFormat("<td>{0}</td>", "工费");
                }
            }
        }
        sb.Append("</tr>");
        //循环TABLE设置数据行
        if (exportDataSource != null && exportDataSource.Rows.Count > 0)
        {
            foreach (DataRow dr in exportDataSource.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in exportDataSource.Columns)
                {
                    sb.AppendFormat("<td>{0}</td>", dr[dc.Caption]);
                }
                sb.Append("</tr>");
            }
        }
        //设置HTML尾
        sb.Append("</table></body></html>");
        //导出数据
        System.Web.HttpContext.Current.Response.Write(sb);
        System.Web.HttpContext.Current.Response.End();
    }
    public void Download(int ImageColNum, string filePathName, string tempFileName)
    {
        //设置response
        System.Web.HttpContext.Current.Response.Clear();
        System.Web.HttpContext.Current.Response.BufferOutput = true;
        System.Web.HttpContext.Current.Response.Charset = System.Text.Encoding.UTF8.HeaderName;
        System.Web.HttpContext.Current.Response.BufferOutput = true;
        System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + DownloadFileName + ".xls");
        System.Web.HttpContext.Current.Response.ContentType = "application/ms-excel";
        System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        System.Web.HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.UTF8;

        //设置HTML头
        System.Reflection.Missing MissingValue = System.Reflection.Missing.Value;
        Application app = new Application();
        Workbooks wks = app.Workbooks;
        Workbook wk = wks.Add(MissingValue);
        Sheets wss = wk.Worksheets;
        Worksheet ws = (Worksheet)wss.get_Item(1);
        app.Visible = false;
        app.DisplayAlerts = false;
        int i = 1, j = 2;
        //循环Columns 设置列名
        if (exportDataSource != null)
        {
            ((Range)ws.Cells[1, 1]).Value2 = "Picture";
            foreach (DataColumn dc in exportDataSource.Columns)
            {
                if (dc.Caption != "Picture")
                {
                    //((Range)ws.Cells[i, j]).Value2 = dc.Caption;
                    if (dc.Caption == "Name")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 25;
                        ((Range)ws.Cells[i, j]).Value2 = "Name";
                    }
                    else if (dc.Caption == "Style")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 20;
                        ((Range)ws.Cells[i, j]).Value2 = "Model Number";
                    }
                    else if (dc.Caption == "Barcode")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 14;
                        ((Range)ws.Cells[i, j]).Value2 = "Barcode";
                    }
                    else if (dc.Caption == "Type_Name")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 14;
                        ((Range)ws.Cells[i, j]).Value2 = "Category";
                    }
                    else if (dc.Caption == "SType_Name")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 14;
                        ((Range)ws.Cells[i, j]).Value2 = "Sub Category";
                    }
                    else if (dc.Caption == "Color")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 12;
                        ((Range)ws.Cells[i, j]).Value2 = "Color";
                    }
                    else if (dc.Caption == "Size")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 6;
                        ((Range)ws.Cells[i, j]).Value2 = "Size";
                    }
                    else if (dc.Caption == "Order_Number")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 15;
                        ((Range)ws.Cells[i, j]).Value2 = "Order quantity";
                    }
                    else if (dc.Caption == "Real_Number")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 15;
                        ((Range)ws.Cells[i, j]).Value2 = "Real quantity";
                    }
                    else if (dc.Caption == "Descriptions")
                    {
                        ((Range)ws.Cells[i, j]).ColumnWidth = 30;
                        ((Range)ws.Cells[i, j]).Value2 = "Descriptions";
                    }
                    j++;
                }
                //sb.AppendFormat("<td>{0}</td>", dc.Caption);
            }
            i++;
        }
        ((Range)ws.Cells[1, 1]).RowHeight = 22;
        string imgPath;    // 图片地址
        int tempRowIndex;   // 当前图片所在行
        //循环TABLE设置数据行
        if (exportDataSource != null && exportDataSource.Rows.Count > 0)
        {
            // 初始化图片地址和当前图片行
            imgPath = filePathName + exportDataSource.Rows[0]["Picture"].ToString();
            tempRowIndex = 2;
            Pictures pics = (Pictures)ws.Pictures(MissingValue);
            float PictureWidth, PictureHeight;
            PictureWidth = 135;
            PictureHeight = 80;
            ((Range)ws.Cells[1, 1]).ColumnWidth = 30;

            // 第一行插入图片
            if (imgPath != string.Empty)
            {
                if (File.Exists(imgPath))
                {
                    Bitmap bp = new Bitmap(imgPath); //todo:
                    PictureHeight = bp.Height * PictureWidth / bp.Width;
                    Range r = (Range)ws.Cells[2, ImageColNum];
                    r.Select();

                    //ws.Shapes.AddPicture(imgPath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, Convert.ToInt32(r.Left), Convert.ToInt32(r.Top) + 1, PictureWidth, PictureHeight);
                }
                //ws.Shapes.AddPicture(imgPath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, 10, 10, PictureWidth, PictureHeight);
            }

            foreach (DataRow dr in exportDataSource.Rows)
            {
                // 填充单元格
                j = 2;
                foreach (DataColumn dc in exportDataSource.Columns)
                {
                    if (j != ImageColNum && dc.Caption != "Picture")
                    {
                        ((Range)ws.Cells[i, j]).Value2 = "'" + dr[dc.Caption];
                    }
                    //sb.AppendFormat("<td>{0}</td>", dr[dc.Caption]);
                    j++;
                }
                //填充图片
                if (filePathName + dr["Picture"].ToString() != imgPath)
                {
                    if (imgPath != filePathName)
                    {
                        //设置高度和宽度
                        int rowCount = i - tempRowIndex;
                        if (rowCount * 20 < PictureHeight)
                        {
                            for (int tempi = tempRowIndex; tempi < i; tempi++)
                            {
                                ((Range)ws.Cells[tempi, ImageColNum]).RowHeight = PictureHeight / rowCount + 3;
                            }
                        }
                        //合并单元格

                        if (i > 2)
                        {
                            Range tempr = ws.get_Range(ws.Cells[tempRowIndex, ImageColNum], ws.Cells[i - 1, ImageColNum]);
                            tempr.MergeCells = true;
                        }
                        else
                        {
                            Range tempr = ws.get_Range(ws.Cells[tempRowIndex, ImageColNum], ws.Cells[i, ImageColNum]);
                            tempr.MergeCells = true;
                        }
                    }

                    //重新设置临时变量
                    imgPath = filePathName + dr["Picture"].ToString();
                    tempRowIndex = i;
                    if (File.Exists(imgPath))
                    {
                        Bitmap bp = new Bitmap(imgPath); //todo:
                        PictureHeight = bp.Height * PictureWidth / bp.Width;
                        Range r = (Range)ws.Cells[i, ImageColNum];
                        r.Select();
                        //ws.Shapes.AddPicture(imgPath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, (float)r.Left, (float)r.Top, PictureWidth, PictureHeight);
                        //ws.Shapes.AddPicture(imgPath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, Convert.ToInt32(r.Left), Convert.ToInt32(r.Top) + 1, PictureWidth, PictureHeight);
                        //ws.Shapes.AddPicture(imgPath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, 10, 10, 150, 150);
                    }
                }
                i++;
            }
            //设置最后一个图片的高度和宽度
            int rowCount2 = i - tempRowIndex;
            if (rowCount2 * 20 < PictureHeight)
                for (int tempi = tempRowIndex; tempi < i; tempi++)
                {
                    ((Range)ws.Cells[tempi, ImageColNum]).RowHeight = PictureHeight / rowCount2 + 3;
                }
            //合并单元格
            Range tempr2 = ws.get_Range(ws.Cells[tempRowIndex, ImageColNum], ws.Cells[i - 1, ImageColNum]);
            tempr2.MergeCells = true;
        }
        //导出数据
        wk.SaveAs(tempFileName, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, XlSaveAsAccessMode.xlNoChange, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue);

        //关闭文件，退出EXCEL

        //System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);
        //System.Runtime.InteropServices.Marshal.ReleaseComObject(wk);
        //System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        //GC.Collect();               //显式调用GC


        wk.Close(false, MissingValue, MissingValue);
        app.Quit();
        //释放Excel资源
        if (wks!= null && app != null)
        {
            foreach (_Workbook book in wks)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wks);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);
        }

        app = null;
        wks = null;
        wk = null;
        ws = null;
        GC.Collect();

        //app.Visible = true;
        //Kill(app);
        //下载文件
        System.Web.HttpContext.Current.Response.WriteFile(tempFileName);

        System.Web.HttpContext.Current.Response.End();
    }

    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

    public static void Kill(Application excel)
    {
        IntPtr t = new IntPtr(excel.Hwnd);   //得到这个句柄，具体作用是得到这块内存入口 

        int k = 0;
        GetWindowThreadProcessId(t, out k);   //得到本进程唯一标志k
        System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);   //得到对进程k的引用
        p.Kill();     //关闭进程k

    }
}
