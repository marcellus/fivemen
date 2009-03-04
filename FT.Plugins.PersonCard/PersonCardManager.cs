using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FT.DAL.Orm;

namespace FT.Plugins.PersonCard
{
    public partial class PersonCardManager : UserControl
    {
        public PersonCardManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonCardBrowser form = new PersonCardBrowser(new Card());
            form.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex > -1)
            {

                TabPage tb = this.tabControl1.TabPages[this.tabControl1.SelectedIndex];
                tb.Controls.Add(this.personCardSearch1);
                this.personCardSearch1.SetConditions("c_classical='" + tb.Text + "'");
            }
        }

        private void PersonCardManager_Load(object sender, EventArgs e)
        {
            ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(Group));
            if (lists.Count > 0)
            {
                this.tabControl1.TabPages.Clear();
                Group group = null;
                for (int i = 0; i < lists.Count; i++)
                {
                    group = lists[i] as Group;
                    this.tabControl1.TabPages.Add(group.Name);

                }
                
                TabPage tb = this.tabControl1.TabPages[0];
                tb.Controls.Add(this.personCardSearch1);
                this.personCardSearch1.SetConditions("c_classical='" + tb.Text + "'");
            }

        }
    }
}
