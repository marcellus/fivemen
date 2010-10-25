using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using PDA.DataInit;

namespace PDA
{
    public partial class Function_List : Form
    {
        public Function_List(object[] al)
        {
            InitializeComponent();
            SetRight(al);
        }

        void this_Closed(object sender, EventArgs e)
        {
            //this.Close();
            this.Show();
        }

        private void btn_PingtuoHadTray_Click(object sender, EventArgs e)
        {
            PinTuoDetailHadTray ptdh = new PinTuoDetailHadTray();
            OpenForm(ptdh);
        }

        private void btn_Pingtuo_Click(object sender, EventArgs e)
        {
            PinTuoDetail ptd = new PinTuoDetail();
            OpenForm(ptd);
        }

        private void btn_JieTuo_Click(object sender, EventArgs e)
        {
            JieTuoDetail jt = new JieTuoDetail();
            OpenForm(jt);
        }

        private void btn_ZuTuo_Click(object sender, EventArgs e)
        {
            ZuTuoDetail zt = new ZuTuoDetail();
            OpenForm(zt);
        }

        private void btn_CheckHadTray_Click(object sender, EventArgs e)
        {
            CheckDetailHadTray cdh = new CheckDetailHadTray();
            OpenForm(cdh);
        }

        private void btn_Check_Click(object sender, EventArgs e)
        {
            CheckDetail cd = new CheckDetail();
            OpenForm(cd);
        }

        private void btn_MoveLocHadTray_Click(object sender, EventArgs e)
        {
            MoveLocDetailHadTray mldh = new MoveLocDetailHadTray();
            OpenForm(mldh);
        }

        private void btn_MoveLoc_Click(object sender, EventArgs e)
        {
            MoveLocDetail mld = new MoveLocDetail();
            OpenForm(mld);
        }

        private void btn_PickHadTray_Click(object sender, EventArgs e)
        {
            PickScan ps = new PickScan(true);
            OpenForm(ps);
        }
        private void btn_Pick_Click(object sender, EventArgs e)
        {
            PickScan ps = new PickScan(false);
            OpenForm(ps);
        }

        private void btn_ASNHadTray_Click(object sender, EventArgs e)
        {
            ASNScan asns = new ASNScan(true);
            OpenForm(asns);
        }

        private void btn_ASN_Click(object sender, EventArgs e)
        {
            ASNScan asns = new ASNScan(false);
            OpenForm(asns);
        }

        private void OpenForm(Form f)
        {
            f.Show();
            f.Closed += new EventHandler(this_Closed);
            this.Hide();
        }
        private void SetRight(object[] rights)
        {
            Hashtable funRigthMapping = new Hashtable();
            funRigthMapping.Add("01", new Control[] { btn_ASN, btn_ASNHadTray });
            funRigthMapping.Add("02", new Control[] { btn_MoveLoc, btn_MoveLocHadTray });
            funRigthMapping.Add("03", new Control[] { btn_Pick, btn_PickHadTray });
            funRigthMapping.Add("04", new Control[] { btn_Check, btn_CheckHadTray });
            funRigthMapping.Add("05", new Control[] { btn_Pingtuo, btn_PingtuoHadTray });
            funRigthMapping.Add("06", new Control[] { btn_ZuTuo });
            funRigthMapping.Add("07", new Control[] { btn_JieTuo });
            funRigthMapping.Add("08", new Control[] { btn_UpdataBaseData });

            for (int i = 0; i < rights.Length; i++)
            {
                if (funRigthMapping[rights[i].ToString()] != null)
                {
                    Control[] controls = (Control[])funRigthMapping[rights[i].ToString()];
                    foreach (Control c in controls)
                    {
                        c.Enabled = true;
                    }
                }
            }
        }

        private void btn_UpdataBaseData_Click(object sender, EventArgs e)
        {
            DataSet ds = new DB().GetFactoryAndStorage();
            if (ds == null || ds.Tables.Count < 2)
            {
                MessageBox.Show("获取数据失败，请检查网络！");
                return;
            }
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from mydicts;");
            sql.Append("insert into mydicts(dicttype,dictvalue,dicttext) ");
            foreach (DataRow dr in ds.Tables["Factory"].Rows)
            {
                sql.AppendFormat(System.Globalization.CultureInfo.CurrentCulture, "select '{0}','{1}','{2}' union all ", 1, dr["id"], dr["name"]);
            }
            foreach (DataRow dr in ds.Tables["Storage"].Rows)
            {
                sql.AppendFormat(System.Globalization.CultureInfo.CurrentCulture, "select '{0}','{1}','{2}' union all ", 2, dr["id"], dr["name"]);
            }
            if (sql.Length == 0) return;
            sql.Length = sql.Length - "union all ".Length;
            if (SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql.ToString().Split(";".ToCharArray())) == 0)
            {
                MessageBox.Show("同步基础数据失败，请检查网络！");
                return;
            }

            ds = new DB().GetLoc();
            sql.Length = 0;
            sql.Append("delete from kuweiinfo;");
            sql.Append("insert into kuweiinfo(kuweicode) ");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                sql.AppendFormat(System.Globalization.CultureInfo.CurrentCulture, "select '{0}' union all ", dr["loc"]);
            }
            if (sql.Length == 0) return;
            sql.Length = sql.Length - "union all ".Length;
            if (SqliteDbFactory.GetSqliteDbOperator().BatchExecute(sql.ToString().Split(";".ToCharArray())) == 0)
            {
                MessageBox.Show("同步基础数据失败，请检查网络！");
                return;
            }
            MessageBox.Show("同步基础数据成功！");
        }
    }
}