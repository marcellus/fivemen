using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FT.DAL;

namespace FT.Windows.Controls.PanelEx
{
    public partial class DataSearch : UserControl
    {
        public DataSearch()
        {
            InitializeComponent();
        }
        protected Pager pager = new Pager(0);

        protected ArrayList lists=new ArrayList();

        private Type entityClass;

        protected Type EntityClass
        {
            get { return entityClass; }
            set { entityClass = value; }
        }

        protected bool IsReady
        {
            get
            {
                return this.entityClass != null;
            }

        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.IsReady)
            {
               // FT.DAL.Orm.SimpleOrmOperator.Query<this.entityClass>();
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
