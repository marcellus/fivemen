using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Commons.PrinterEx.SupportObject;
using FT.DAL.Orm;

namespace FT.Windows.Forms
{
    /// <summary>
    /// 浏览实体对象的窗体，如果碰到date和combo怎么处理
    /// </summary>
    public partial class DataBrowseForm : Form
    {
        public DataBrowseForm()
        {
            InitializeComponent();
        }

        public DataBrowseForm(object entity)
        {
            InitializeComponent();
            FormHelper.SetDataToForm(this, entity);
        }

        /// <summary>
        /// 从实体载入数据到窗体上
        /// </summary>
        /// <param name="entity">实体</param>
        protected void LoadData(object entity)
        {
            FormHelper.SetDataToForm(this, entity);
        }

        protected void GetData(object entity)
        {
            FormHelper.SetDataToForm(this, entity);
        }

        /// <summary>
        /// 清理控件的值
        /// </summary>
        /// <param name="ctr">The CTR.</param>
        protected void ClearControl(Control ctr)
        {
            int count = ctr.Controls.Count;

            if (count == 0)
            {
                if (ctr is TextBox)
                {
                    ((TextBox)ctr).Text = string.Empty;
                }
            }
            else
            {
                foreach (Control tmp in ctr.Controls)
                {
                    ClearControl(tmp);
                }
            }
        }

        

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bool result= this.ValidateChildren(ValidationConstraints.Enabled);
            
            //MessageBoxHelper.Show("validate result is:"+result);
            if(result)
            {
                this.ClearValidateError();
                this.Save();
            }
            
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
        protected virtual object GetEntity()
        {
            throw new Exception("子类必须继承该方法能生成一个实体！");
         //   return null;
        }

        protected virtual void Save()
        {
            object entity = this.GetEntity();
            FormHelper.GetDataFromForm(this, entity);
            
            if (this.lbId.Text.Length==0)
            {
                if (SimpleOrmOperator.Create(entity))
                {
                    FormHelper.SetDataToForm(this, entity);
                    MessageBoxHelper.Show("添加成功！");
                   
                }
                else
                {
                    MessageBoxHelper.Show("添加失败！");
                }
            }
            else
            {
                if (SimpleOrmOperator.Update(entity))
                {
                    MessageBoxHelper.Show("修改成功！");
                }
                else
                {
                    MessageBoxHelper.Show("修改失败！");
                }
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            PrinterContent content = this.GetPrinterContent();
            if (content != null)
            {
                content.Preview();
            }
        }

        protected virtual PrinterContent GetPrinterContent()
        {
            MessageBoxHelper.Show("对不起，还没有实现打印该对象！");
            return null;
            //throw new Exception("");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PrinterContent content = this.GetPrinterContent();
            if (content != null)
            {
                content.Print();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
           
            this.ClearAdd();

        }

        /// <summary>
        /// 清理验证错误
        /// </summary>
        private void ClearValidateError()
        {
            this.errorProvider1.Clear();
        }
       // private int id=-1;
        /// <summary>
        /// 清理后添加
        /// </summary>
        protected virtual void ClearAdd()
        {
            this.ClearValidateError();
            this.ClearControl(this);
            this.lbId.Text= string.Empty;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.ShowAbout();
        }
        /// <summary>
        /// 显示关于对话框
        /// </summary>
        protected virtual void ShowAbout()
        {
            SimpleAbout form = new SimpleAbout();
            form.ShowDialog();
        }
    }
}