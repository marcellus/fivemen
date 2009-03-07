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
            this.personCardSearch1.InitBeforeAdd += new FT.Windows.Forms.ProcessObjectDelegate(personCardSearch1_InitBeforeAdd);
            //this.personCardSearch1.AllowCustomeSearch = false;
        }

        void personCardSearch1_InitBeforeAdd(ref object entity)
        {
            Card tmp = new Card();
            tmp.Group = this.tabControl1.SelectedTab.Text;
            entity = tmp;
            //throw new Exception("The method or operation is not implemented.");
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
                this.personCardSearch1.SetConditions("c_groupid='" + tb.Tag.ToString() + "'");
            }
        }

        private void PersonCardManager_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
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
                        this.tabControl1.TabPages[this.tabControl1.TabCount - 1].Tag = group.Id;

                    }

                    TabPage tb = this.tabControl1.TabPages[0];
                    tb.Controls.Add(this.personCardSearch1);
                    this.personCardSearch1.SetConditions("c_groupid='" + tb.Tag.ToString() + "'");
                }
            }

        }
    }
}
