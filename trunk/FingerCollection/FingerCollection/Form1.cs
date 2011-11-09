using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Cache;
using FT.Commons.Tools;
using FingerCollection.Config;

namespace FingerCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            Form form = new SystemConfigForm();
            form.ShowDialog();
        }
        private const int SUCCESSED = 0;
        private TrustLinkGeneralController _TG = new TrustLinkGeneralController();

        private void SetConfig()
        {
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
            _TG.HostName = config.HostName;
            _TG.ProductID = config.ProductID;
            _TG.Port = config.Port;
            _TG.AuthenID = config.AuthenID;
            _TG.AuthenPwd = config.AuthenPwd;
            _TG.XSDevName = config.XSDevName;
        }

      

        private void btnCollection_Click(object sender, EventArgs e)
        {
            String idcard = this.txtIdCard.Text.Trim();
            if (idcard.Length == 0)
            {
                MessageBoxHelper.Show("请输入要采集的身份证号码！");
                return;
            }
            string result = string.Empty;
            result=IDCardHelper.Validate(idcard) ;
            if (result!= string.Empty)
            {
                MessageBoxHelper.Show(result);
                return;
            }
             String name = this.txtName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBoxHelper.Show("请输入要采集的姓名！");
                return;
            }
            if(FingerDbOperator.Exists(idcard))
            {
                MessageBoxHelper.Show("已存在身份证号码为"+idcard+"的指纹记录！");
                return; 
            }

            int intResult = SUCCESSED;
            this.SetConfig();
            
            intResult = _TG.NewEnroll(idcard);
            if (intResult == SUCCESSED)
            {
                MessageBox.Show("采集成功！");
                FingerDbOperator.Enroll(idcard,name,this.datePxrq.Value.ToString("yyyy-MM-dd"),this.cbStudentType.SelectedValue.ToString(),this.cbLearnCar.Text);
                this.localFingerRecordSearch2.SetConditions(" c_name like '%'");
            }
            else
            {
                MessageBox.Show(Convert.ToString(_TG.LastErrCode)
                + "\n" + _TG.LastErrMsg
                + "\n" + _TG.LastErrReason);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String idcard = this.txtIdCard.Text.Trim();
            if (idcard.Length == 0)
            {
                MessageBoxHelper.Show("请输入要删除的身份证号码！");
                return;
            }
            string result = string.Empty;
            result = IDCardHelper.Validate(idcard);
            if (result != string.Empty)
            {
                MessageBoxHelper.Show(result);
                return;
            }

            this.SetConfig();
            if (_TG.DeleteUser(idcard) == SUCCESSED)
            {
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show(Convert.ToString(_TG.LastErrCode)
                + "\n" + _TG.LastErrMsg
                + "\n" + _TG.LastErrReason);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            String idcard = this.txtIdCard.Text.Trim();
            if (idcard.Length == 0)
            {
                MessageBoxHelper.Show("请输入要验证的身份证号码！");
                return;
            }

            this.SetConfig();




            if (_TG.FPUserVerify(idcard) == SUCCESSED)
            {
                MessageBox.Show("找到身份证号码为：\n" + idcard);
            }
            else
            {
                MessageBox.Show(Convert.ToString(_TG.LastErrCode)
                + "\n" + _TG.LastErrMsg
                + "\n" + _TG.LastErrReason);
            }
        }

        private void btnDeleteNow_Click(object sender, EventArgs e)
        {
            String idcard = this.txtIdCard.Text.Trim();
            if (idcard.Length == 0)
            {
                MessageBoxHelper.Show("请输入要删除的身份证号码！");
                return;
            }
            

            if(FingerDbOperator.DeleteUser(idcard))
            {
                MessageBoxHelper.Show("删除用户成功！");
                this.localFingerRecordSearch2.SetConditions(" c_name like '%'");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtIdCard.Focus();
            FingerDbOperator.BindDict(this.cbLearnCar, "准驾车型");
            FingerDbOperator.BindDict(this.cbStudentType, "学员类型");
        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            FingerDbOperator.Clear();
            MessageBoxHelper.Show("清空成功！");
        }

        private void btnUpdateLsh_Click(object sender, EventArgs e)
        {
            FingerDbOperator.UpdateLsh(this.txtIdCard.Text.Trim(),this.txtLsh.Text.Trim());
            this.localFingerRecordSearch2.SetConditions(" c_name like '%'");
           
        }
    }
}
