using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.DAL;
using DS.Plugins.Car;

namespace DS.Plugins.Student
{
    public partial class CarFeeCounter : FT.Windows.Forms.DataCounterControl
    {
        public CarFeeCounter()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.ClearColumns();
            this.CreateColumn("费用类别",120);
            this.CreateColumn("金额").DefaultCellStyle.Format = "N2";
        }

        protected override void Search()
        {
            string sql = "select c_feetype as 费用类别,sum(i_fee) as 金额";
           

            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            sql += " from table_car_fee where c_hmhp like '%"+
                this.txtHmhp.Text.Trim()+"%' and " + access.BetweenDateString("date_fee", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            sql += " group by c_feetype";
            
            DataTable dt = access
            .SelectDataTable(sql, "tmp");
            
            
            if (dt != null)
            {
                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        count += Convert.ToInt32(dt.Rows[i].ItemArray[1].ToString());
                    }
                    catch
                    {
                    }
                }
                dt.Rows.Add(new object[] {"合计",count });
                this.dataGridView1.DataSource = dt;
             }
        }

        protected override string GetTitle()
        {
            return this.dateBetweenPanel1.BeginDate.ToShortDateString() + "至"
                + this.dateBetweenPanel1.EndDate.ToShortDateString() + "车费统计";
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Form form = new DetailForm();
            form.Text = this.GetTitle() + "详细信息";
            CarFeeSearch search = new CarFeeSearch();
            search.Dock = DockStyle.Fill;
            IDataAccess access = FT.DAL.DataAccessFactory.GetDataAccess();
            string condition = access.BetweenDateString("date_fee", this.dateBetweenPanel1.BeginDate,
                this.dateBetweenPanel1.EndDate);
            condition += " and c_hmhp like '%"+
                this.txtHmhp.Text.Trim()+"%'";
            search.SetConditions(condition);
            form.Controls.Add(search);
            form.Show();
        }
    }
}

