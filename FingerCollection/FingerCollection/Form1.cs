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
using System.IO;
using System.Diagnostics;

//this.localFingerRecordSearch2 = new LocalFingerRecordSearch(this.txtIdCard,this.txtName,this.txtLsh,this.cbStudentType,this.cbLearnCar);

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

        private void ClearInput()
        {
            this.txtName.Text = string.Empty;
            //this.txtIdCard.Text = this.txtName.Text = string.Empty;
        }

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
            if (idcard.Length >= 15)
            {
                result = IDCardHelper.Validate(idcard);
                if (result != string.Empty)
                {
                    MessageBoxHelper.Show(result);
                    return;
                }
            }
             String name = this.txtName.Text.Trim();
            if (name.Length == 0)
            {
                MessageBoxHelper.Show("请输入要采集的姓名！");
                return;
            }
          //  if(FingerDbOperator.Exists(idcard))
          //  {
         //       MessageBoxHelper.Show("已存在身份证号码为"+idcard+"的指纹记录！");
          //      return; 
         //   }

            int intResult = SUCCESSED;
            this.SetConfig();
            //if (FingerDbOperator.Exists(idcard))
            //{
                //FingerDbOperator.DeleteUser(idcard);
            //}
            
            intResult = _TG.NewEnroll(idcard);
            if (intResult == SUCCESSED)
            {
                MessageBoxHelper.Show("采集成功！");
                FingerDbOperator.Enroll(idcard,name,this.datePxrq.Value.ToString("yyyy-MM-dd"),this.cbStudentType.SelectedValue.ToString(),this.cbLearnCar.Text);
               // this.localFingerRecordSearch2.SetConditions(" c_name like '%'");
               // this.localFingerRecordSearch2.se
                this.localFingerRecordSearch2.SetMyConditon(" c_name like '%'");
                //this.txtIdCard.Text = string.Empty;
                this.ClearInput();
                //this.localFingerRecordSearch2.SetMyConditon(string.Empty);
                
               // this.lo
            }
            else if (intResult == 404)
            {
                MessageBoxHelper.Show("使用者要求取消或者离开");

            }
            else if (intResult == 31)
            {
                MessageBoxHelper.Show("身份证号码"+idcard+"已经采集了指纹，请先删除该身份证的指纹后进行采集！");
                return;
                /*
                FingerDbOperator.DeleteUser(idcard);
                _TG.DeleteUser(idcard);
                intResult = _TG.NewEnroll(idcard);
                if (intResult == SUCCESSED)
                {
                    MessageBoxHelper.Show("更新采集成功！");
                    FingerDbOperator.Enroll(idcard, name, this.datePxrq.Value.ToString("yyyy-MM-dd"), this.cbStudentType.SelectedValue.ToString(), this.cbLearnCar.Text);
                    //this.localFingerRecordSearch2.SetConditions(" c_name like '%'");
                    //this.localFingerRecordSearch2.SetMyConditon(string.Empty);
                    this.localFingerRecordSearch2.SetMyConditon(" c_name like '%'");
                    this.ClearInput();

                    // this.localFingerRecordSearch2.Refresh();

                }
                */
            }
            else if (intResult == 40)
            {
                FingerDbOperator.ClearFingerAratek();
                System.Threading.Thread.Sleep(1000);
                intResult = _TG.NewEnroll(idcard);
                if (intResult == SUCCESSED)
                {
                    MessageBoxHelper.Show("采集成功！");
                    FingerDbOperator.Enroll(idcard, name, this.datePxrq.Value.ToString("yyyy-MM-dd"), this.cbStudentType.SelectedValue.ToString(), this.cbLearnCar.Text);
                    //  this.localFingerRecordSearch2.SetConditions(" c_name like '%'");
                    //  this.localFingerRecordSearch2.Refresh();
                    //this.localFingerRecordSearch2.SetMyConditon(string.Empty);
                    this.localFingerRecordSearch2.SetMyConditon(" c_name like '%'");
                    this.ClearInput();

                }
                // MessageBoxHelper.Show("已经超出授权数量，无法采集！");
            }
            else if (intResult == 94||intResult==10)
            {
                MessageBoxHelper.Show("指纹采集数据库被使用中，请多点击几次或重启操作系统！"+intResult.ToString());
            }
            else
            {
                MessageBoxHelper.Show("指纹采集监控平台返回代码：" + intResult);

                //_TG.UpdateEnroll(idcard);
                // MessageBox.Show("更新采集成功！");
                // MessageBox.Show(Convert.ToString(_TG.LastErrCode)
                //  + "\n" + _TG.LastErrMsg
                // + "\n" + _TG.LastErrReason);
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
                MessageBoxHelper.Show("删除成功！");
            }
            else
            {
                MessageBoxHelper.Show(Convert.ToString(_TG.LastErrCode)
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
                MessageBox.Show("验证身份证号码为：\n" + idcard+"指纹清晰！");
            }
            else
            {
                MessageBox.Show("验证失败！由于"+Convert.ToString(_TG.LastErrCode)
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

            if (MessageBoxHelper.Confirm("确定要删除身份证明号码为"+idcard+"人员的指纹数据吗？"))
            {
                if (FingerDbOperator.DeleteUser(idcard))
                {
                    FingerDbOperator.ClearFingerAratek();
                    MessageBoxHelper.Show("删除用户成功！");
                    this.localFingerRecordSearch2.SetMyConditon(" c_name like '%'");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtIdCard.Focus();
            FingerDbOperator.BindDict(this.cbLearnCar, "准驾车型");
            FingerDbOperator.BindDict(this.cbStudentType, "学员类型");
            this.cbLearnCar.SelectedValue = "C1";
            //this.tabControl1.TabPages[1].
        }

        

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBoxHelper.Confirm("清空指纹库将删除所有指纹吗？"))
            {
                FingerDbOperator.Clear();
                MessageBoxHelper.Show("清空成功！");
            }
        }

        private void btnUpdateLsh_Click(object sender, EventArgs e)
        {
            FingerDbOperator.UpdateLsh(this.txtIdCard.Text.Trim(),this.txtLsh.Text.Trim());
            this.localFingerRecordSearch2.SetMyConditon(" c_name like '%'");
           
        }

        private void btnCompact_Click(object sender, EventArgs e)
        {
           // string path=Application.StartupPath+"\\db\\db.mdb";
           //CompactAccessDB(" Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+path+";User Id=admin;Password=;",path);
            //System.IO.File.Delete(mdwfilename);
           if( MessageBoxHelper.Confirm("压缩指纹库将删除所有指纹吗？"))
           {
            string pathOrg = Application.StartupPath + "\\db.mdb";
            string pathDst = Application.StartupPath + "\\db\\db.mdb";
            string pathbakDst = Application.StartupPath + "\\db\\db"+System.DateTime.Now.ToString("yyyyMMddHHmmss")+"-bak.mdb";
            System.IO.File.Copy(pathDst, pathbakDst, true);
            System.IO.File.Copy(pathOrg,pathDst,true);
            MessageBoxHelper.Show("压缩完毕！");
           }

        }
            /// <summary> 
            /// MBD compact method (c) 2004 Alexander Youmashev  
            /// !!IMPORTANT!!  
            /// !make sure there's no open connections  
            ///to your db before calling this method!  
            /// !!IMPORTANT!! 
            /// /// </summary> 
            /// <param name="connectionString">connection string to your db</param> 
            /// <param name="mdwfilename">FULL name  
            /// of an MDB file you want to compress.</param> 
            /// 
            public static void CompactAccessDB(string connectionString, string mdwfilename)  
            {  object[] oParams;  
                //create an inctance of a Jet Replication Object  
                object objJRO =  Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));   
                //filling Parameters array  
                //cnahge "Jet OLEDB:Engine Type=5" to an appropriate value  
                // or leave it as is if you db is JET4X format (access 2000,2002)  
                //(yes, jetengine5 is for JET4X, no misprint here)  
                oParams = new object[] {  connectionString,  "Provider=Microsoft.Jet.OLEDB.4.0;Data" +  " Source=C:\\tempdb.mdb;Jet OLEDB:Engine Type=5"};  
                //invoke a CompactDatabase method of a JRO object  
                //pass Parameters array 
                objJRO.GetType().InvokeMember("CompactDatabase",  System.Reflection.BindingFlags.InvokeMethod,  null,  objJRO,  oParams);   
                //database is compacted now  
                //to a new file C:\\tempdb.mdw  
                //let's copy it over an old one and delete it   
                System.IO.File.Delete(mdwfilename);  
                System.IO.File.Move("C:\\tempdb.mdb", mdwfilename);   //clean up (just in case)  
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);  objJRO=null;  
            }

            private void btnUpdateInfo_Click(object sender, EventArgs e)
            {
                if (this.txtIdCard.Text.Trim().Length == 0)
                {
                    MessageBoxHelper.Show("身份证明号码为空，无法更新！");
                }
                else if (FingerDbOperator.UpdateInfo(this.txtIdCard.Text.Trim(), this.txtLsh.Text.Trim(), this.txtName.Text.Trim(), this.datePxrq.Value.ToString("yyyy-MM-dd"), this.cbStudentType.SelectedValue.ToString(), this.cbLearnCar.Text))
                {
                    MessageBoxHelper.Show("更新身份证明号码为" + this.txtIdCard.Text.Trim() + "的学员资料成功！");
                    this.localFingerRecordSearch2.SetMyConditon(" c_name like '%'");
                }
            }

            private void btnPrepareUpload_Click(object sender, EventArgs e)
            {
                SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
                FileInfo file = new FileInfo(Application.StartupPath + "/db/db.mdb");
                string filename=config.UploadFilePre+System.DateTime.Now.ToString("yyyyMMddHHmmss")+"db.mdb";
                string target = FT.Commons.Tools.FileDialogHelper.Save("准备上传的指纹文件", "Access(*.mdb)|*.mdb|All File(*.*)|*.*", filename);
                if (!string.IsNullOrEmpty(target))
                {
                    file.CopyTo(target, true);
                }
                //Process.Start(Application.StartupPath+"/db");
                

            }

            private void btnOpenUrl_Click(object sender, EventArgs e)
            {
                SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
                Process.Start("explorer.exe "+config.FTPUrl);
                //Process.Start("iexplore.exe " + config.FTPUrl);
            } 
        
    }
}
