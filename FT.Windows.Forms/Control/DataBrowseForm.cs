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
using FT.Commons.Cache;
using log4net;

namespace FT.Windows.Forms
{
    
    ///初始化顺序，父类构造，子类构造，父类load，子类load
    /// 所以操作习惯可在父类的load方法实现
    /// <summary>
    /// 浏览实体对象的窗体，如果碰到date和combo怎么处理
    /// </summary>
    public partial class DataBrowseForm : DevExpress.XtraEditors.XtraForm
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");
        public DataBrowseForm()
        {
            InitializeComponent();
            
            this.lbId.Text = string.Empty;
            //MessageBoxHelper.Show("父类的空构造函数！");
        }
        protected object entity;

        public DataBrowseForm(object entity):this()
        {
            //MessageBoxHelper.Show("父类的带参构造函数！");
            this.entity = entity;
            //InitializeComponent();
            //MessageBoxHelper.Show("父类的构造函数！");
        }

        protected IRefreshParent refresher;

        public DataBrowseForm(object entity, IRefreshParent refresher):this()
        {
            this.entity = entity;
            this.refresher = refresher;
        }

        public DataBrowseForm(IRefreshParent refresher)
            : this()
        {
            this.refresher = refresher;
        }

        /// <summary>
        /// 初始化操作习惯，比如按回车等效于Tab
        /// </summary>
        protected void InitHabit()
        {
            FormHelper.InitHabitToForm(this);
        }


        #region 验证输入的基类方法
        protected void ValidateIdCard(object sender, CancelEventArgs e,  bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                string tmp=txt.Text.Trim();
                if (allowBlank)
                {
                    if (tmp.Length == 0)
                    {   
                        this.errorProvider1.SetError(txt, string.Empty);
                        e.Cancel = false;
                    }
                    else
                    {
                        tmp = IDCardHelper.Validate(tmp);
                        if (tmp.Length != 0)
                        {
                            this.errorProvider1.SetError(txt, tmp);
                            e.Cancel = true;
                        }
                        else
                        {
                            this.errorProvider1.SetError(txt, string.Empty);
                            e.Cancel = false;
                        }
                    }
                }
                else if (tmp.Length == 0)
                {
                    this.errorProvider1.SetError(txt, "请输入身份证号!");
                    e.Cancel = true;
                }
                else
                {
                    tmp = IDCardHelper.Validate(tmp);
                    if (tmp.Length != 0)
                    {
                        this.errorProvider1.SetError(txt, tmp);
                        e.Cancel = true;
                    }
                    else
                    {
                        this.errorProvider1.SetError(txt, string.Empty);
                        e.Cancel = false;
                    }
                }
                
                
            }
        }

        protected void ValidateAlapha(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateAlapha(sender, e, "请输入正确的字母！", allowBlank);
        }

        protected void ValidateAlapha(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateAlapha(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateUrl(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateUrl(sender, e, "请输入正确的Url格式！", allowBlank);
        }

        protected void ValidateUrl(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateUrl(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }
        protected void ValidateEmail(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateEmail(sender, e, "请输入正确的Email格式！", allowBlank);
        }

        protected void ValidateEmail(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateEmail(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateIp(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateIp(sender, e, "请输入正确的IP格式！", allowBlank);
        }

        protected void ValidateIp(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateIp(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidatePostCode(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidatePostCode(sender, e, "请输入六位邮编号！", allowBlank);
        }

        protected void ValidatePostCode(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidatePostCode(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateDate(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {

                try
                {
                    Convert.ToDateTime(txt.Text);
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
                catch
                {
                    this.errorProvider1.SetError(txt, "请输入格式为yyyy-MM-dd的日期！");
                    e.Cancel = true;

                }

            }
        }
        protected void ValidateDateMaskedLargeNow(object sender, CancelEventArgs e)
        {
            ValidateDateMaskedLarge(sender, e, System.DateTime.Now);
        }


        protected void ValidateDateMaskedLarge(object sender, CancelEventArgs e,DateTime begin)
        {
            MaskedTextBox txt = sender as MaskedTextBox;
            if (txt != null)
            {

                try
                {
                    DateTime dt = Convert.ToDateTime(txt.Text);
                    if (dt < begin.AddDays(1))
                    {
                        this.errorProvider1.SetError(txt, "输入的时间必须大于"+begin.ToString("yyyy-MM-dd")+"！");
                        e.Cancel = true;
                    }
                    else
                    {
                        this.errorProvider1.SetError(txt, string.Empty);
                        e.Cancel = false;
                    }
                }
                catch
                {
                    this.errorProvider1.SetError(txt, "请输入格式为yyyy-MM-dd的日期！");
                    e.Cancel = true;

                }

            }
        }

        protected void ValidateDateMaskedBetween(object sender, CancelEventArgs e, DateTime begin,DateTime end)
        {
            MaskedTextBox txt = sender as MaskedTextBox;
            if (txt != null)
            {

                try
                {
                    DateTime dt = Convert.ToDateTime(txt.Text);
                    if (dt < begin.AddDays(1))
                    {
                        this.errorProvider1.SetError(txt, "输入的时间必须大于" + begin.ToString("yyyy-MM-dd") + "！");
                        e.Cancel = true;
                    }
                    else if (dt > end.AddDays(-1))
                    {
                        this.errorProvider1.SetError(txt, "输入的时间必须小于" + end.ToString("yyyy-MM-dd") + "！");
                        e.Cancel = true;
                    }
                    else
                    {
                        this.errorProvider1.SetError(txt, string.Empty);
                        e.Cancel = false;
                    }
                }
                catch
                {
                    this.errorProvider1.SetError(txt, "请输入格式为yyyy-MM-dd的日期！");
                    e.Cancel = true;

                }

            }
        }

        protected void ValidateDateMasked(object sender, CancelEventArgs e)
        {
            MaskedTextBox txt = sender as MaskedTextBox;
            if (txt != null)
            {

                try
                {
                    DateTime dt=Convert.ToDateTime(txt.Text);
                    
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
                catch
                {
                    this.errorProvider1.SetError(txt, "请输入格式为yyyy-MM-dd的日期！");
                    e.Cancel = true;
                    
                }
                
            }
        }

        protected void ValidateNotNull(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "请输入！");
        }

        protected void ValidateNotNull(object sender, CancelEventArgs e, string text)
        {
            TextBox txt=sender as TextBox;
            if (txt != null)
            {
                if (txt.Text.Trim().Length == 0)
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }
        protected void ValidateNumber(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateNumber(sender, e, "请输入数字！", allowBlank);
        }

        protected void ValidateNumber(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateNumber(txt.Text.Trim(),allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateInteger(object sender, CancelEventArgs e, bool allowBlank, int min)
        {
            ValidateInteger(sender, e, allowBlank, min, "无效数字！");
        }

        protected void ValidateInteger(object sender, CancelEventArgs e,  bool allowBlank,int min,string text)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateNumber(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    if (!allowBlank)
                    {
                        int tmp = Convert.ToInt32(txt.Text.Trim());
                        if (tmp <= min)
                        {
                            this.errorProvider1.SetError(txt, "请输入大于" + min + "的数字!");
                            e.Cancel = true;
                        }
                        else
                        {
                            this.errorProvider1.SetError(txt, string.Empty);
                            e.Cancel = false;
                        }
                    }
                    else
                    {
                        this.errorProvider1.SetError(txt, string.Empty);
                        e.Cancel = false;
                    }
                }
            }
        }

        protected void ValidatePhone(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidatePhone(sender, e, "请输入格式正确的固定电话号码！", allowBlank);
        }

        protected void ValidatePhone(object sender, CancelEventArgs e, string text,bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidatePhone(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidatePhoneOrMobile(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidatePhoneOrMobile(sender, e, "请输入格式正确的固定电话或手机号码！", allowBlank);
        }

        protected void ValidatePhoneOrMobile(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidatePhoneOrMobile(txt.Text.Trim(), allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        protected void ValidateMobile(object sender, CancelEventArgs e, bool allowBlank)
        {
            this.ValidateMobile(sender, e,"请输入格式正确的手机号码！" ,allowBlank);
        }

        protected void ValidateMobile(object sender, CancelEventArgs e, string text, bool allowBlank)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (!ValidatorHelper.ValidateMobile(txt.Text.Trim(),allowBlank))
                {
                    this.errorProvider1.SetError(txt, text);
                    e.Cancel = true;
                }
                else
                {
                    this.errorProvider1.SetError(txt, string.Empty);
                    e.Cancel = false;
                }
            }
        }

        /// <summary>
        /// 为控件设置text错误信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="text"></param>
        protected void SetError(object sender, string text)
        {
            this.errorProvider1.SetError((Control)sender, text);
        }
        /// <summary>
        /// 清空某控件上的错误信息
        /// </summary>
        /// <param name="sender"></param>
        protected void ClearError(object sender)
        {
            SetError(sender, string.Empty);
        }
        #endregion

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
            FormHelper.GetDataFromForm(this, entity);
        }

        /// <summary>
        /// 清理控件的值,只清理textbox的值
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
        /// <summary>
        /// 在更新之前进行验证
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckBeforeUpdate()
        {
            return true;
        }

        /// <summary>
        /// 在新创建之前进行验证
        /// </summary>
        /// <returns></returns>
        protected virtual bool CheckBeforeCreate()
        {
            return true;
        }
        
        

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bool result= this.ValidateChildren(ValidationConstraints.Enabled);
            
            //MessageBoxHelper.Show("validate result is:"+result);
            if (result)
            {
                this.ClearValidateError();
                this.Save();
            }
            else
            {
                MessageBoxHelper.Show("输入有误，请检查！");
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

        protected virtual void BeforeCreateEntity(object entity)
        {

        }

        protected virtual void BeforeUpdateEntity(object entity)
        {

        }
        protected virtual void BeforeSave(object entity)
        {
        }

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="obj"></param>
        protected static void Debug(object obj)
        {
            if (log != null && log.IsDebugEnabled)
            {
                log.Debug(obj);
            }
        }

        protected virtual bool Save()
        {
            if (this.entity == null)
            {
                log.Debug("实体为空，开始创建实体！");
                this.entity = this.GetEntity();
            }
            log.Debug("从窗体上获取实体值！");
            FormHelper.GetDataFromForm(this, entity);
            log.Debug("保存或者创建新实体之前的动作！");
            this.BeforeSave(entity);
            if (this.lbId.Text.Length==0||this.lbId.Text.Trim()=="0")
            {
                log.Debug("开始检查创建新实体的数据校验！");
                if (this.CheckBeforeCreate())
                {
                    log.Debug("开始把新实体插入数据库前的数据组合！");
                    this.BeforeCreateEntity(entity);
                    if (SimpleOrmOperator.Create(entity))
                    {
                        log.Debug("插入数据库完成，并准备同步数据！");
                        this.AfterSuccessCreate();
                        FormHelper.SetDataToForm(this, entity);
                        MessageBoxHelper.Show("添加成功！");
                        if (refresher != null)
                        {
                            refresher.Add(entity);
                        }

                    }
                    else
                    {
                        MessageBoxHelper.Show("添加失败！");
                        return false;
                    }
                }
                else
                {
                    //MessageBoxHelper.Show("添加失败！");
                    return false;
                }
            }
            else
            {
                log.Debug("开始检查更新新实体的数据校验！");
                if (this.CheckBeforeUpdate())
                {
                    log.Debug("开始把新实体更新数据库前的数据组合！");
                    this.BeforeUpdateEntity(entity);
                    if (SimpleOrmOperator.Update(entity))
                    {
                        log.Debug("更新新实体成功，并准备数据库同步！");
                        this.AfterSuccessUpdate();
                        MessageBoxHelper.Show("修改成功！");
                        if (refresher != null)
                        {
                            refresher.Update(entity);
                        }
                    }
                    else
                    {
                        MessageBoxHelper.Show("修改失败！");
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        protected virtual void AfterSuccessUpdate()
        {

        }
        protected virtual void AfterSuccessCreate()
        {

        }

        protected virtual AbstractPrinterContent GetPrinterContent()
        {
            
            return null;
            //throw new Exception("");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.entity == null)
            {
                MessageBoxHelper.Show("无法打印未保存的数据！");
                return;
            }
            AbstractPrinterContent content = this.GetPrinterContent();
            if (content != null)
            {
                content.Print();
            }
            else
            {
                MessageBoxHelper.Show("对不起，还没有实现打印该对象！");
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            this.ClearValidateError();
            this.lbId.Text = string.Empty;
            this.entity = null;
            //this.entity=
            this.ClearAdd();

        }

        /// <summary>
        /// 清理验证错误
        /// </summary>
        protected void ClearValidateError()
        {
            this.errorProvider1.Clear();
        }
       // private int id=-1;
        /// <summary>
        /// 清理后添加
        /// </summary>
        protected virtual void ClearAdd()
        {
            
            this.ClearControl(this);
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
            form.ShowInTaskbar = false;
            
            form.ShowDialog();
        }

        private void DataBrowseForm_Load(object sender, EventArgs e)
        {
            //MessageBoxHelper.Show("父类的Load！");
            if (!this.DesignMode)
            {
                this.InitHabit();
                if (this.entity != null)
                {
                    this.LoadData(entity);
                }
            }
        }
    }
}