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
            //this.CreateColumn("����", 120);
            //this.CreateColumn("��Ʒ����", 120);
            //this.CreateColumn("��Ʒ��Դ", 120);
            //this.CreateColumn("�����", 120);
            //this.CreateColumn("������", 120);
            //this.CreateColumn("���").DefaultCellStyle.Format = "N2";
        }

        protected override void Search()
        {
            /*SELECT format(a.date_in,"yyyy-MM-dd") AS ����, a.c_name AS ��Ʒ����, a.c_from AS ��Ʒ��Դ, IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu)) AS ���, IIf(IsNull(sum(b.m_dun_shu)),0,sum(b.m_dun_shu)) AS ����
FROM table_jxc_in_record AS a LEFT JOIN table_jxc_sell_record AS b ON format(a.date_in,"yyyy-MM-dd")=format(b.date_sell,"yyyy-MM-dd")
GROUP BY format(a.date_in,"yyyy-MM-dd"), a.c_name, a.c_from;
*/
           
            DataTable dt = new DataTable();
            dt.Columns.Add("����");
            //if(this.checkGroupTypeName)
            ArrayList typelist = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(BaseData));
            BaseData type = null;
            ArrayList fromlist = JxcHelper.GetFromList();
            Dict from = null;
            for (int i = 0; i < typelist.Count;i++ )
            {
                type = typelist[i] as BaseData;
                dt.Columns.Add(type.TypeName + "�����");
                for (int j = 0; j < fromlist.Count; j++)
                {
                    from = fromlist[j] as Dict;
                    dt.Columns.Add(type.TypeName+"("+from.Text + ")�����");
                    //dt.Columns.Add(type.TypeName+"("+from.Text + ")�����");
                }

                dt.Columns.Add(type.TypeName + "������");
            }
            dt.Columns.Add("���������");
            dt.Columns.Add("���ճ�����");

            string sql = "select format(a.date_in,\"yyyy-MM-dd\") AS ����,";
            
            
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
#region �������Դ�����
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
                        dr[tmptable.Rows[k][0].ToString()+"("+tmptable.Rows[k][1].ToString()+")�����"]=
                            tmptable.Rows[k][3].ToString();
                    }
                }
#endregion
#region ���������
                sql="SELECT c_name,  format(a.date_sell,\"yyyy-MM-dd\"), IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu))"
+" FROM table_jxc_sell_record AS a "
+ " where format(a.date_sell,\"yyyy-MM-dd\")='" + begindate.ToString("yyyy-MM-dd") + "' GROUP BY c_name, format(a.date_sell,\"yyyy-MM-dd\")";
                tmptable=access.SelectDataTable(sql,"tmptable");
                if(tmptable!=null)
                {
                     for (int k=0;k<tmptable.Rows.Count;k++)
                    {
                        dr[tmptable.Rows[k][0].ToString()+"������"]=
                            tmptable.Rows[k][2].ToString();
                    }
                }
#endregion
#region ���಻����Դ�����

                    sql="SELECT c_name, format(a.date_in,\"yyyy-MM-dd\"), IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu))"
+" FROM table_jxc_in_record AS a "
+ " where format(a.date_in,\"yyyy-MM-dd\")='" + begindate.ToString("yyyy-MM-dd") + "' GROUP BY c_name, format(a.date_in,\"yyyy-MM-dd\")";
                tmptable=access.SelectDataTable(sql,"tmptable");
                if(tmptable!=null)
                {
                     for (int k=0;k<tmptable.Rows.Count;k++)
                    {
                        dr[tmptable.Rows[k][0].ToString()+"�����"]=
                            tmptable.Rows[k][2].ToString();
                    }
                }
#endregion

#region ������������
                                    sql="SELECT  IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu))"
+" FROM table_jxc_in_record AS a "
+" where format(a.date_in,\"yyyy-MM-dd\")='"+begindate.ToString("yyyy-MM-dd")+"'";
                tmptable=access.SelectDataTable(sql,"tmptable");
                if(tmptable!=null)
                {
                    dr["���������"]=tmptable.Rows[0][0].ToString();
                }
                 sql="SELECT  IIf(IsNull(sum(a.m_dun_shu)),0,sum(a.m_dun_shu))"
+" FROM table_jxc_sell_record AS a "
+" where format(a.date_sell,\"yyyy-MM-dd\")='"+begindate.ToString("yyyy-MM-dd")+"'";
                tmptable=access.SelectDataTable(sql,"tmptable");
                if(tmptable!=null)
                {
                    dr["���ճ�����"]=tmptable.Rows[0][0].ToString();
                }
#endregion
                dt.Rows.Add(dr);
            }
            
            
            if (dt != null)
            {
                dr = dt.NewRow();
                dr[0] = "�ϼ�";
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
                //dt.Rows.Add(new object[] { "�ϼ�", "�ϼ�", "�ϼ�", countin, countout });*/
                this.dataGridView1.DataSource = dt;
             }
        }

        protected override string GetTitle()
        {
            return this.dateBetweenPanel1.BeginDate.ToShortDateString() + "��"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() + "ͳ��";
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form form = new Form();
            form.Text = this.GetTitle() + "������ϸ��Ϣ";
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
            form.Text = this.GetTitle() + "�����ϸ��Ϣ";
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


