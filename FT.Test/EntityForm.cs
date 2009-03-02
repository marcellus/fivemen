using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.DAL.Orm;

namespace FT.Test
{
    public partial class EntityForm : FT.Windows.Forms.DataBrowseForm
    {
        public EntityForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected override object GetEntity()
        {
            return new TestUsers();
            //   return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestUsers user = this.MockUsers();
            SimpleOrmOperator.Create(user);
            //this.ClearAdd();
            //this.LoadData(user);
            //this.Save();
        }

        private TestUsers MockUsers()
        {
            TestUsers user = new TestUsers();
            user.CreatorIp = "127.0.0.1";
            user.Description = "descrip";
            user.Creator = "mock";
            user.IsValided = true;
            user.KeyWords = "keyword";
            user.Name = "mock_name";
            user.Sex = "mock_female";
            return user;
        }
       // DAL.Orm.SimpleOrmOperator op = new SimpleOrmOperator();

        private void button2_Click(object sender, EventArgs e)
        {
            //TestUsers user=
            TestUsers user=SimpleOrmOperator.Query<TestUsers>(Convert.ToInt32(this.textBox1.Text.Trim()));
            //TestUsers user = SimpleOrmOperator.Query<TestUsers>(1);
            if (user != null)
            {
                this.LoadData(user);
            }
            
        }

        private void EntityForm_Load(object sender, EventArgs e)
        {
            SimpleOrmOperator.InitDataAccess(DAL.DataAccessFactory.GetDataAccess());
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (this.txtName.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(this.txtName, "对不起，姓名不得为空！");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider1.SetError(this.txtName, "");
                e.Cancel = false;
            }
        }

        private void cbSex_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbSex.Text != "female" && this.cbSex.Text != "male")
            {
                this.errorProvider1.SetError(this.cbSex, "性别不对，只能是男女，英文字母是female or male，比如handsome就不行，别乱填写咯！");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider1.SetError(this.cbSex, "");
                e.Cancel = false;
            }
        }
    }
}

