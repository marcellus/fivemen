using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.DAL;
using System.Collections;
using FT.Windows.CommonsPlugin;

namespace Jxc.Plugin
{
    public partial class SellCounter : FT.Windows.Forms.DataCounterControl
    {
        public SellCounter()
        {
            InitializeComponent();
           // this.dataGridView1.AutoGenerateColumns = false;
            //this.ClearColumns();
            //this.CreateColumn("日期", 120);
            //this.CreateColumn("货品名称", 120);
            //this.CreateColumn("货品来源", 120);
            //this.CreateColumn("入库量", 120);
            //this.CreateColumn("出库量", 120);
            //this.CreateColumn("金额").DefaultCellStyle.Format = "N2";
        }

        protected override void Search()
        {
            /*SELECT format(a.date_in,"yyyy-MM-dd") AS 日期, a.c_name AS 货品名称, a.c_from AS 货品来源, IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu)) AS 入库, IIf(IsNull(sum(b.m_dun_shu)),0,sum(b.m_dun_shu)) AS 出库
FROM table_jxc_in_record AS a LEFT JOIN table_jxc_sell_record AS b ON format(a.date_in,"yyyy-MM-dd")=format(b.date_sell,"yyyy-MM-dd")
GROUP BY format(a.date_in,"yyyy-MM-dd"), a.c_name, a.c_from;
*/
           
            DataTable dt = new DataTable();
            dt.Columns.Add("日期");
            //if(this.checkGroupTypeName)
            ArrayList typelist = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(BaseData));
            BaseData type = null;
            ArrayList fromlist = JxcHelper.GetFromList();
            Dict from = null;
            for (int i = 0; i < typelist.Count;i++ )
            {
                type = typelist[i] as BaseData;
                dt.Columns.Add(type.TypeName + "入库量");
                for (int j = 0; j < fromlist.Count; j++)
                {
                    from = fromlist[j] as Dict;
                    dt.Columns.Add(type.TypeName+"("+from.Text + ")入库量");
                    //dt.Columns.Add(type.TypeName+"("+from.Text + ")入库量");
                }

                dt.Columns.Add(type.TypeName + "出库量");
            }
            dt.Columns.Add("本日入库量");
            dt.Columns.Add("本日出库量");

            string sql = "select format(a.date_in,\"yyyy-MM-dd\") AS 日期,";
            
            
            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            DataRow dr=null;
            DateTime begindate1=this.dateBetweenPanel1.BeginDate;
            DateTime begindate = begindate1;
            
            TimeSpan ts=this.dateBetweenPanel1.EndDate.Subtract(begindate);
            int days=ts.Days+1;
            DataTable tmptable=null;
            for(int i=0;i<days;i++)
            {
                begindate=begindate1.AddDays(i);
#region 分类分来源入库量
                sql="SELECT c_name, c_from, format(a.date_in,\"yyyy-MM-dd\"), IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu))"
+" FROM table_jxc_in_record AS a "
+ " where format(a.date_in,\"yyyy-MM-dd\")='" + begindate.ToString("yyyy-MM-dd") + "' GROUP BY c_name, c_from, format(a.date_in,\"yyyy-MM-dd\")";

                dr=dt.NewRow();
                dr[0]=begindate.ToString("yyyy-MM-dd");
                for (int j=1;j<dt.Columns.Count;j++)
                {
                    dr[j]=0;
                }
                tmptable=access.SelectDataTable(sql,"tmptable");
                if(tmptable!=null)
                {
                     for (int k=0;k<tmptable.Rows.Count;k++)
                    {
                        dr[tmptable.Rows[k][0].ToString()+"("+tmptable.Rows[k][1].ToString()+")入库量"]=
                            tmptable.Rows[k][3].ToString();
                    }
                }
#endregion
#region 分类出库量
                sql="SELECT c_name,  format(a.date_sell,\"yyyy-MM-dd\"), IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu))"
+" FROM table_jxc_sell_record AS a "
+ " where format(a.date_sell,\"yyyy-MM-dd\")='" + begindate.ToString("yyyy-MM-dd") + "' GROUP BY c_name, format(a.date_sell,\"yyyy-MM-dd\")";
                tmptable=access.SelectDataTable(sql,"tmptable");
                if(tmptable!=null)
                {
                     for (int k=0;k<tmptable.Rows.Count;k++)
                    {
                        dr[tmptable.Rows[k][0].ToString()+"出库量"]=
                            tmptable.Rows[k][2].ToString();
                    }
                }
#endregion
#region 分类不分来源入库量

                    sql="SELECT c_name, format(a.date_in,\"yyyy-MM-dd\"), IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu))"
+" FROM table_jxc_in_record AS a "
+ " where format(a.date_in,\"yyyy-MM-dd\")='" + begindate.ToString("yyyy-MM-dd") + "' GROUP BY c_name, format(a.date_in,\"yyyy-MM-dd\")";
                tmptable=access.SelectDataTable(sql,"tmptable");
                if(tmptable!=null)
                {
                     for (int k=0;k<tmptable.Rows.Count;k++)
                    {
                        dr[tmptable.Rows[k][0].ToString()+"入库量"]=
                            tmptable.Rows[k][2].ToString();
                    }
                }
#endregion

#region 今日入库出库量
                                    sql="SELECT  IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu))"
+" FROM table_jxc_in_record AS a "
+" where format(a.date_in,\"yyyy-MM-dd\")='"+begindate.ToString("yyyy-MM-dd")+"'";
                tmptable=access.SelectDataTable(sql,"tmptable");
                if(tmptable!=null)
                {
                    dr["本日入库量"]=tmptable.Rows[0][0].ToString();
                }
                 sql="SELECT  IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu))"
+" FROM table_jxc_sell_record AS a "
+" where format(a.date_sell,\"yyyy-MM-dd\")='"+begindate.ToString("yyyy-MM-dd")+"'";
                tmptable=access.SelectDataTable(sql,"tmptable");
                if(tmptable!=null)
                {
                    dr["本日出库量"]=tmptable.Rows[0][0].ToString();
                }
#endregion
                dt.Rows.Add(dr);
            }
            
            
            if (dt != null)
            {
                dr = dt.NewRow();
                dr[0] = "合计";
                decimal[] counters =new decimal[dt.Columns.Count-1];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    try
                    {
                        for (int k=0;k<counters.Length;k++)
                        {
                            counters[k]+=Convert.ToDecimal(dt.Rows[i].ItemArray[k+1].ToString());
                        }
                        
                    }
                    catch
                    {
                    }
                }
                for (int k = 0; k < counters.Length; k++)
                {
                    dr[k + 1] = counters[k].ToString();
                }
                dt.Rows.Add(dr);
                //dt.Rows.Add(new object[] { "合计", "合计", "合计", countin, countout });*/
                this.dataGridView1.DataSource = dt;
             }
        }

        protected override string GetTitle()
        {
            return this.dateBetweenPanel1.BeginDate.ToShortDateString() + "至"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() + "统计";
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = this.GetTitle() + "销售详细信息";
            SellRecordSearch search = new SellRecordSearch();
            search.Dock = DockStyle.Fill;
            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            string condition = access.BetweenDateString("date_sell", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            search.SetConditions(condition);
            form.Controls.Add(search);
            form.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnInDetail_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = this.GetTitle() + "入库详细信息";
            InRecordSearch search = new InRecordSearch();
            search.Dock = DockStyle.Fill;
            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            string condition = access.BetweenDateString("date_in", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            search.SetConditions(condition);
            form.Controls.Add(search);
            form.Show();
        }
    }
}


