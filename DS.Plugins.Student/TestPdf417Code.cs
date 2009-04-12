using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DS.Plugins.Student
{
    public partial class TestPdf417Code : Form
    {
        public TestPdf417Code()
        {
            InitializeComponent();
        }
        /*
         * dw_student.setitem(1, 'sfzmmc', ls_input[4])
	dw_student.setitem(1, 'xm', ls_input[5])
	dw_student.setitem(1, 'cp_sfzmhm', ls_input[3])
	dw_student.setitem(1, 'xb', ls_input[6])
	dw_student.setitem(1, 'csrq', date(ls_input[7]))
	dw_student.setitem(1, 'gj', ls_input[8])
	dw_student.setitem(1, 'djzsxzqh', ls_input[9])
	dw_student.setitem(1, 'djzsxxdz', ls_input[10])
	dw_student.setitem(1, 'lxzsxzqh', ls_input[11])
	dw_student.setitem(1, 'lxzsxxdz', ls_input[12])
	dw_student.setitem(1, 'lxzsyzbm', ls_input[13])
	dw_student.setitem(1, 'lxdh1', ls_input[14])
	dw_student.setitem(1, 'xzqh', ls_input[15])
	dw_student.setitem(1, 'xxcx', ls_input[16])
	dw_student.setitem(1, 'ly', ls_input[17])
	dw_student.setitem(1, 'zzzm', ls_input[18])
//	dw_student.setitem(1, 'jxmc', ls_input[19])
    dw_student.setitem(1, 'cp_jxmc', g_nvo_app.ui_s_company)
	dw_student.setitem(1, 'jly1', ls_input[20])
	dw_student.setitem(1, 'sg', integer(ls_input[21]))
	dw_student.setitem(1, 'zsl', dec(ls_input[22]))
	dw_student.setitem(1, 'ysl', dec(ls_input[23]))
	dw_student.setitem(1, 'bsl', ls_input[24])
	dw_student.setitem(1, 'tl', ls_input[25])
	dw_student.setitem(1, 'sz', ls_input[26])
	dw_student.setitem(1, 'zxz', ls_input[27])
	dw_student.setitem(1, 'yxz', ls_input[28])
	dw_student.setitem(1, 'qgjb', ls_input[29])
	dw_student.setitem(1, 'tjyymc', ls_input[30])
	dw_student.setitem(1, 'tjrq', date(ls_input[31]))
         * */

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
           // string str = "jsyxx&92055EDA&320522197203140014&A&陈涛&1&1972-03-14&156&320585&江苏省苏州市太仓市城厢镇人民北路46-3号103室&320585&江苏省苏州市太仓市城厢镇人民北路46-3号103室&215400&56609869&320585&C1&A&&38&沈建飞&175&5.0&5.0&1&1&1&1&1&1&19&2005-07-06";

            //int length = str.Split('&').Length;
            //System.Threading.Thread.Sleep(5000);
            
        }

        private void GrantString()
        {

            string[] arrays = this.txtBarCode.Text.Split('&');
            if (arrays != null && arrays.Length == 32)
            {
                this.txtIdCard.Text = arrays[2];
                this.txtIdType.Text = arrays[3];//A为身份证
                this.txtName.Text = arrays[4];
                this.txtSex.Text = arrays[5] == "1" ? "男" : "女";//1男，2女
                this.txtBirthday.Text = arrays[6];
                this.txtNation.Text = arrays[7];//国籍代码：156中国？
                this.txtRegArea.Text = arrays[8];
                this.txtRegAddress.Text = arrays[9];
                this.txtConnArea.Text = arrays[10];
                this.txtConnAddress.Text = arrays[11];
                this.txtPostCode.Text = arrays[12];
                this.txtPhone.Text = arrays[13];
                this.txtArea.Text = arrays[14];//所属辖区？
                this.txtLearnCar.Text = arrays[15];
                this.txtFrom.Text = arrays[16];//来源 A代表本地 别的呢？
                this.txtTempId.Text = arrays[17];
                this.txtSchoolName.Text = arrays[18];
                this.textBox30.Text = arrays[19];//20是什么？//教练员
                this.txtHeight.Text = arrays[20];
                this.txtLeftEye.Text = arrays[21];
                this.txtRightEye.Text = arrays[22];
                this.txtColor.Text = arrays[23] == "1" ? "合格" : "不合格";
                this.txtListening.Text = arrays[24] == "1" ? "合格" : "不合格";
                this.txtTopBody.Text = arrays[25] == "1" ? "合格" : "不合格";
                this.txtLeftDownBody.Text = arrays[26] == "1" ? "合格" : "不合格";
                this.txtRightDownBody.Text = arrays[27] == "1" ? "合格" : "不合格";
                this.txtBody.Text = arrays[28] == "1" ? "合格" : "不合格";
                this.txtHospital.Text = arrays[29];
                //string temp = arrays[30];
                // System.Console.WriteLine("the checkdate is:"+temp);
                // this.txtCheckDate.Focus();

                this.txtCheckDate.Text = arrays[30];
                this.txtRightCode.Text = arrays[31];
                // this.txtBarCode.Focus();
                this.txtBarCode.Text = string.Empty;


            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
           // Fm.Common.Logging.LogFactoryWrapper.Debug("按键为："+e.KeyCode.ToString());
            if (e.KeyCode == Keys.Enter)
            {
                this.GrantString();
            }
        }
    }
}