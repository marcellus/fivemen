using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.PrinterEx;
using FT.Commons.PrinterEx.SupportObject;
using FT.Commons.Tools;
using FT.Windows.Forms.Domain;
using FT.Commons.Cache;
using FT.DAL;

namespace DS.Plugins.Student
{
    public partial class BaoMinReport : UserControl
    {
        public BaoMinReport()
        {
            InitializeComponent();
            SubjectHelper.BindCombox(this.cbSubject);
            this.comboBox1.SelectedIndex = 0;
        }

        private void BaoMinReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
            }
            else if (e.KeyCode == Keys.F2)
            {
            }
            else if (e.KeyCode == Keys.F3)
            {
            }
            else if (e.KeyCode == Keys.F4)
            {
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString(Convert.ToString(e.RowIndex + 1, System.Globalization.CultureInfo.CurrentUICulture),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            } 
        }

        private void txtIdCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtIdCard.Text.Trim().Length < 8)
                {
                    MessageBoxHelper.Show("必须输入至少8位的身份证号码!");
                    return;
                }
                string sql = "SELECT a.c_hmhp, b.c_name, b.c_sex, b.c_idcard, b.c_examid FROM table_students AS b LEFT JOIN table_coach AS a ON b.i_coachid=a.id WHERE b.c_idcard like '" + this.txtIdCard.Text.Trim() + "%'";
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "test");
                foreach (DataRow dr in dt.Rows)
                {
                    this.dataGridView1.Rows.Add(new object[] {dr[0],dr[1],dr[2],dr[3],dr[4] });
                }
            }
            
        }

        private DataTable GetDataFromGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("车号");
            dt.Columns.Add("姓名");
            dt.Columns.Add("性别");
            dt.Columns.Add("身份证明号码");
            dt.Columns.Add("准考证明号");
            dt.Columns.Add("空白1");
            dt.Columns.Add("空白2");
            dt.Columns.Add("空白3");
            DataGridViewRow row=null;
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                row = this.dataGridView1.Rows[i];
                dt.Rows.Add(new string[] {row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString(),
                row.Cells[2].Value.ToString(),
                row.Cells[3].Value.ToString(),
                row.Cells[4].Value.ToString(),string.Empty,string.Empty,string.Empty});
            }
            return dt;
        }

        private DataTable MockData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("车号");
            dt.Columns.Add("姓名");
            dt.Columns.Add("性别");
            dt.Columns.Add("身份证明号码");
            dt.Columns.Add("准考证明号");
            dt.Columns.Add("性别2");
            dt.Columns.Add("学号3");
            dt.Columns.Add("兴趣4");
            for (int i = 0; i < 47; i++)
            {
                dt.Rows.Add(new string[] { "车号" + i, "姓名" + i, "性别" + i, "35012819840319492" + i, "准考证明号" + i, "sex2" + i, "1233-" + i, "interest4" + i });
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintCommonSetting.Default_Border_Style = BordersEdgeStyle.All;
            //if (this.dataGridView1.Rows.Count == 0)
            //{
                //MessageBoxHelper.Show("请先添加需要打印的学员！");
            //}
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            int rowHeight = 34;
            PageMargin margin = new PageMargin();
            margin.Left = 35;
            margin.Right = 35;
            //margin.Bottom = 36;

           
            //margin.Top = 37;
            margin.Bottom = 40;
            margin.Top = 33;
            PrinterContent content = new PrinterContent();
            content.CustomPageMargin = margin;
            PrinterHint header = this.GetHeader(content.CustomPageMargin.Width, this.comboBox1.Text);
            //header.Rectangle = new Rectangle((content.CustomPageMargin.Width - header.Rectangle.Width), 0, header.Rectangle.Width, header.Rectangle.Height);
            content.Header = header;
            content.IsPrinterPages = false;
           

            int[] columnWidth ={ 60, 90, 90,60, 184, 135,60, content.CustomPageMargin.Width - 679 };
            string[] columnHeader ={ "序号", "车号", "姓名", "性别", "身份证明号码", "准考证明号", "成绩", "备注" };
            int len = columnWidth.Length;
            PrinterTable table = new PrinterTable();
            PrinterRow row = new PrinterRow();
            row.Rectangle = new System.Drawing.Rectangle(0, 0, content.CustomPageMargin.Width, 43);
            TextDraw text = null;
            int tmp = 0;
            Font col = new Font("宋体",15);
            
            for (int i = 0; i < len; i++)
            {
                text = new TextDraw(columnHeader[i]);
                text.Formater = sf;
                text.Font = col;
                text.Border = BordersEdgeStyle.All;
                text.Rectangle = new System.Drawing.Rectangle(tmp, 0, columnWidth[i], 43);
                tmp += columnWidth[i];
                row.Add(text);
            }
            table.Header = row;
            //table.Add(row);
            row = null;
            DataRow dr = null;
            string tmpCarType = string.Empty;
           // DataTable dt = this.MockData();
            DataTable dt = this.GetDataFromGrid();
            if (dt.Rows.Count == 0)
            {
                for (int i = 0; i < 24; i++)
                {
                    dt.Rows.Add(new string[] { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty });
                }
            }
            else
            {
                int tmprowcount = dt.Rows.Count % 24;
                if (tmprowcount != 0)
                {
                    tmprowcount = 24 - tmprowcount;
                    for (int i = 0; i < tmprowcount; i++)
                    {
                        dt.Rows.Add(new string[] { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty });
                    }
                }
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                dr = dt.Rows[j];
                tmp = 0;
                row = new PrinterRow();
                row.Rectangle = new System.Drawing.Rectangle(0, 0, content.CustomPageMargin.Width, rowHeight);
                text = new TextDraw(((j + 1)%24==0?24:(j+1)%24).ToString());
                text.Formater = sf;
                text.Border = BordersEdgeStyle.All;
                text.Rectangle = new System.Drawing.Rectangle(tmp, 0, columnWidth[0], rowHeight);
                tmp += columnWidth[0];
                row.Add(text);
                tmpCarType = dr[3].ToString();
                for (int i = 1; i < len; i++)
                {
                    text = new TextDraw(Convert.IsDBNull(dr[i - 1]) ? string.Empty : dr[i - 1].ToString());
                    text.Border = BordersEdgeStyle.All;
                    text.Formater = sf;
                    text.Rectangle = new System.Drawing.Rectangle(tmp, 0, columnWidth[i], rowHeight);
                    tmp += columnWidth[i];
                    row.Add(text);
                }
                table.Add(row);
            }
            table.Border = BordersEdgeStyle.None;
            content.Body = table;
            PrinterHint footer = this.GetFooter(content.CustomPageMargin.Width);
            content.Footer = footer;
            content.PrinterSetting();
            //content.Preview();
        }


        public PrinterHint GetFooter(int pageWidth)
        {
            Font font = new Font("宋体",15);

            PrinterHint footer = new PrinterHint();
            footer.Border = BordersEdgeStyle.None;
            footer.Rectangle = new Rectangle(-2, 0, pageWidth+2, 147);
            /*有时候不打线出来*/
            //RecetangleDraw outer = new RecetangleDraw();
            TextDraw outer = new TextDraw(" ");
            outer.Font = font;
            outer.Border = BordersEdgeStyle.All;
            outer.Rectangle = new Rectangle(-1, 0, pageWidth +2, 3 * 34);

            TextDraw inner = new TextDraw(" ");
            inner.Font = font;
            inner.Border = BordersEdgeStyle.All;
            //RecetangleDraw inner = new RecetangleDraw();
            inner.Rectangle = new Rectangle(2, 3, pageWidth -4, 3 * 34-5);
            /*有时候不打线出来*/
            footer.Add(outer);
            footer.Add(inner);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;


            TextDraw txt1 = new TextDraw("报考员");
            txt1.Font = font;
            txt1.Rectangle = new Rectangle(2, 3, footerWidth, footer1Height);
            txt1.Border = BordersEdgeStyle.Right;
            txt1.Formater = sf;
            footer.Add(txt1);

            TextDraw txt2 = new TextDraw("签名");
            txt2.Font = font;
            txt2.Rectangle = new Rectangle(2, footer1Height+3, footerWidth, footer1Height);
            txt2.Border = BordersEdgeStyle.Right;
            txt2.Formater = sf;
            footer.Add(txt2);

            RecetangleDraw space1 = new RecetangleDraw();
            space1.Rectangle = new Rectangle(2 + footerWidth, 3, spaceWidth, 2 * footer1Height);
            space1.Border = BordersEdgeStyle.Right;
            footer.Add(space1);



            TextDraw txt3 = new TextDraw("主考员");
            txt3.Font = font;
            txt3.Rectangle = new Rectangle(2 + spaceWidth + footerWidth, 3, footerWidth, footer1Height);
            txt3.Border = BordersEdgeStyle.Right;
            txt3.Formater = sf;
            footer.Add(txt3);

            TextDraw txt4 = new TextDraw("签名");
            txt4.Font = font;
            txt4.Rectangle = new Rectangle(2 + spaceWidth + footerWidth, footer1Height + 3, footerWidth, footer1Height);
            txt4.Border = BordersEdgeStyle.Right;
            txt4.Formater = sf;
            footer.Add(txt4);

            RecetangleDraw space2 = new RecetangleDraw();
            space2.Rectangle = new Rectangle(2 + 2 * footerWidth + spaceWidth, 3, spaceWidth, 2 * footer1Height);
            space2.Border = BordersEdgeStyle.Right;
            footer.Add(space2);

            TextDraw txt5 = new TextDraw("助考员");
            txt5.Font = font;
            txt5.Rectangle = new Rectangle(2 + 2 * (spaceWidth + footerWidth), 3, footerWidth, footer1Height);
            txt5.Border = BordersEdgeStyle.Right;
            txt5.Formater = sf;
            footer.Add(txt5);

            TextDraw txt6 = new TextDraw("签名");
            txt6.Font = font;
            txt6.Rectangle = new Rectangle(2 + 2 * (spaceWidth + footerWidth), footer1Height + 3, footerWidth, footer1Height);
            txt6.Border = BordersEdgeStyle.Right;
            txt6.Formater = sf;
            footer.Add(txt6);

            RecetangleDraw space3 = new RecetangleDraw();
            space3.Rectangle = new Rectangle(2 + 3 * footerWidth + 2 * spaceWidth, 3, spaceWidth - 10, footer1Height*2);
            space3.Border = BordersEdgeStyle.Right;
            footer.Add(space3);


            TextDraw txt7 = new TextDraw("审核人");
            txt7.Font = font;
            txt7.Rectangle = new Rectangle(2 + 3 * (spaceWidth + footerWidth) - 10, 3, footerWidth - 6, footer1Height*2);
            txt7.Border = BordersEdgeStyle.Right;
            txt7.Formater = sf;
            footer.Add(txt7);

            TextDraw txt8 = new TextDraw("报考人数：_______");
            txt8.Font = font;
            txt8.Rectangle = new Rectangle(2, 3 + 2*footer1Height, footerWidth2, 45);
            footer.Add(txt8);

            TextDraw txt9 = new TextDraw("合格人数：_______");
            txt9.Font = font;
            txt9.Rectangle = new Rectangle(2 + footerWidth2, 3 + 2 * footer1Height, footerWidth2, 45);
            footer.Add(txt9);

            TextDraw txt10 = new TextDraw("不合格人数：_____");
            txt10.Font = font;
            txt10.Rectangle = new Rectangle(2 + 2 * footerWidth2, 3 + 2 * footer1Height, footerWidth2, 45);
            footer.Add(txt10);

            TextDraw txt11 = new TextDraw("缺考人数：______");
            txt11.Font = font;
            txt11.Rectangle = new Rectangle(2 + 3 * footerWidth2, 3 + 2 * footer1Height, pageWidth - 4 - 3 * footerWidth2, 45);
            footer.Add(txt11);

            TextDraw text = new TextDraw("   注：此表填写不全，不予受理。填写内容涂改无效。");
            text.Border = BordersEdgeStyle.None;
          
            text.Font = font;
            text.Rectangle = new Rectangle(0, 102, pageWidth, 40);
            footer.Add(text);
            footer.PrintInEveryPage = true;
            return footer;
            
        }

        private const int footer1Height = 26;

        private const int footerWidth = 81;

        private const int spaceWidth = 120;

        private const int footerWidth2 = 190;

        public PrinterHint GetHeader(int pagewidth,string text)
        {
            int captionHeight = 45;
            Font font = new Font("宋体",20);
            Graphics g=this.button1.CreateGraphics();
            int height=(int)g.MeasureString(text, font).Height;
            int width = (int)g.MeasureString(text, font).Width;
            g.Dispose();
            PrinterHint header = new PrinterHint();
            header.Rectangle = new Rectangle(0, 0, pagewidth, height + captionHeight+12);
            header.PrintInEveryPage = true;
            header.Border = BordersEdgeStyle.None;
            TitleDraw title = new TitleDraw(text);
            title.Font = font;
            title.Rectangle = new Rectangle((pagewidth-width)/2, 0, width, height);
            title.Border = BordersEdgeStyle.Bottom;

            TitleDraw line = new TitleDraw("");
            line.Rectangle = new Rectangle((pagewidth - width) / 2, 2, width, height);
            line.Border = BordersEdgeStyle.Bottom;
            header.Add(title);
            header.Add(line);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Far;
            Font cap = new Font("宋体", 14);
            TextDraw header2 = new TextDraw("培训单位：                报考车型：          考试日期：      年   月   日");
            header2.Formater = sf;
            header2.Font = cap;
            header2.Rectangle = new Rectangle(0, height + 7, pagewidth, captionHeight);
            
            header2.Border = BordersEdgeStyle.None;
            CompanyInfo compInfo = StaticCacheManager.GetConfig<CompanyInfo>();

            TextDraw comp = new TextDraw(compInfo.NickName);
             comp.Formater = sf;
             comp.Font = cap;
             comp.Rectangle = new Rectangle(100, height + 7, 200, captionHeight);
            comp.Border = BordersEdgeStyle.None;
            header.Add(comp);
            header.Add(header2);
            return header;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }

        private void cbSubject_TextChanged(object sender, EventArgs e)
        {
            string subject = this.cbSubject.Text.Trim();
            if (subject.Length > 0)
            {
                StudentSystemConfig config = StaticCacheManager.GetConfig<StudentSystemConfig>();
                string sql = "SELECT a.c_hmhp, b.c_name, b.c_sex, b.c_idcard, b.c_examid,b.c_state FROM table_students AS b LEFT JOIN table_coach AS a ON b.i_coachid=a.id WHERE b.c_state like '{0}' And {1}";
                IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
                string tmp1 = string.Empty;
                string tmp2=string.Empty;
                if (subject.StartsWith("科目一"))
                {
                    tmp1 = "初始报名";
                    tmp2 = access.LowerEqualDateString("b.date_baoming", System.DateTime.Now.AddDays(0 - config.RegToSubject1));
                }
                else if(subject.StartsWith("科目二"))
                {
                    tmp1 = "科目一%合格";
                    tmp2 = " exists(select c.c_examdate from table_student_exam as c"
                        + "  where c.c_idcard=b.c_idcard and c.c_subject like '科目一%' and "
                    + access.LowerEqualDateString("c_examdate", System.DateTime.Now.AddDays(0 - config.Subject1To2Days))
                    + ")";
                }
                else
                {
                    tmp1 = "科目二%合格";
                    tmp2 = " exists(select c.c_examdate from table_student_exam as c"
                       + "  where c.c_idcard=b.c_idcard and c.c_subject like '科目二%' and "
                   + access.LowerEqualDateString("c_examdate", System.DateTime.Now.AddDays(0 - config.Subject2To3Days))
                   + ")";
                }
                
                sql = string.Format(sql, new string[] { tmp1, tmp2 });
                Console.WriteLine(sql);
                DataTable dt = access.SelectDataTable(sql, "test");
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.dataGridView1.Rows.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.dataGridView1.Rows.Add(new object[] { dr[0], dr[1], dr[2], dr[3], dr[4], dr[5] });
                    }
                }

                

            }
        }
    }
}
