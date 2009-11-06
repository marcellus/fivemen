using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.DAL.Oracle;
using FT.DAL.Access;
using FT.DAL;
using FT.DAL.SqlServer;
using System.Xml;
using FT.Commons.Tools;
using System.IO;

namespace FtDbConnectionTest
{
    public partial class Form1 : Form
    {

        private string[] ConnectStrings = new string[] {  "Data Source=(localhost);Initial Catalog=CABook_History;User ID=sa", "Data Source=dnsname;user=users;password=pwd;","Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb;User Id=admin;Password=;" };
        private IDataAccess access = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
            switch(this.cbDbType.SelectedIndex)
            {
                case 0:
                    access = new SqlServerDataHelper(this.txtConnString.Text.Trim());
                    break;
                case 1:
                    access = new OracleDataHelper(this.txtConnString.Text.Trim());
                    break;
                case 2:
                    access = new AccessDataHelper(this.txtConnString.Text.Trim());
                    break;
            }
            try
            {
                if (access.Open())
                {
                    MessageBox.Show("���Գɹ���", "��ʾ");
                    access.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Fm.Common.SkinProcessor.IrisSkin2Proccssor.InitSkinEngine();
        }

        private void cbDbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtConnString.Text=ConnectStrings[this.cbDbType.SelectedIndex];
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sql=this.tbSql.Text.Trim();
            if (sql.ToLower().StartsWith("select"))
            {
                //access.Open();
                DataTable dt = access.SelectDataTable(sql, "tablename");
                this.dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("��ѯ��������select��ʼ��", "��ʾ");
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            this.txtAfterProcess.Text = FT.Commons.Security.SecurityFactory.GetSecurity().Encrypt(this.txtNeedProcess.Text.Trim());
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            this.txtAfterProcess.Text = FT.Commons.Security.SecurityFactory.GetSecurity().Decrypt(this.txtNeedProcess.Text.Trim());
        }

        private bool TestConnection()
        {

            IDataAccess acc = new FT.DAL.Access.AccessDataHelper("Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=true;Data Source=\\\\" + this.txtIp.Text.Trim() + "\\db\\db.mdb;Jet OLEDB:Database Password=SQL");
            try
            {
                if (acc.Open())
                {
                    MessageBox.Show("���Գɹ���", "��ʾ");
                    acc.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("����ʧ�ܣ�", "��ʾ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
            
        }

        private const string connKey = "DefaultConnString";

        private void SaveConfig(string file)
        {
            XmlDocument doc = new XmlDocument();
            string path = Application.StartupPath + "/" + file;
            doc.Load(path);
           
            XmlNode node1 = doc.SelectSingleNode(@"//add[@key='" + connKey + "']");
            XmlElement ele1 = (XmlElement)node1;
            ele1.SetAttribute("value", FT.Commons.Security.SecurityFactory.GetSecurity().Encrypt("Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=true;Data Source=\\\\" + this.txtIp.Text.Trim() + "\\db\\db.mdb;Jet OLEDB:Database Password=SQL"));
            doc.Save(path);
            MessageBox.Show("���óɹ���");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.txtIp.Text.Length==0)
            {

                MessageBoxHelper.Show("������IP��ַ��");
                return ;
            }
            else if(this.txtFileName.Text.Length==0){
                

                MessageBoxHelper.Show("�����������ļ�����");
                return ;

            }
            if (!File.Exists(this.txtFileName.Text.Trim()))
            {
                MessageBoxHelper.Show("�����ļ��������ڣ�");
                return ;

            }
            /*
            // �򿪿�ִ�е������ļ�*.exe.config
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
             ������Ӵ��Ѵ��ڣ�����ɾ����
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // ���µ����Ӵ���ӵ������ļ���.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
             
            // ����������ļ������ĸ���
            config.AppSettings.Settings.Add("123", "test");
            config.AppSettings.Settings[ipKey].Value = this.txtIp.Text.Trim();
            config.Save(ConfigurationSaveMode.Full);

           
            // ǿ���������������ļ���ConnectionStrings���ý�
           // ConfigurationManager.RefreshSection("ConnectionStrings");
           // ConfigurationManager.AppSettings.Set(ipKey,this.txtIp.Text.Trim());
             * */
            if (this.TestConnection())
            {
                this.SaveConfig(this.txtFileName.Text.Trim());
            }
        }

       
    }
}