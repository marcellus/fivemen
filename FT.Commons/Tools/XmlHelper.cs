using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace FT.Commons.Tools
{
    /// <summary>
    /// xml�����࣬��Ҫִ��һ��Xml��һЩ����
    /// </summary>
    public class XmlHelper : BaseHelper
    {
        #region �޸�app.config
        /*
        private const string ipKey = "DbIp";
        private const string grantKey = "GrantCode";

        private const string connKey = "DefaultConnString";

        private void button2_Click(object sender, EventArgs e)
        {
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
             * 

            XmlDocument doc = new XmlDocument();
            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='" + ipKey + "']");
            XmlElement ele = (XmlElement)node;
            ele.SetAttribute("value", this.txtIp.Text.Trim());

            XmlNode node3 = doc.SelectSingleNode(@"//add[@key='" + grantKey + "']");
            XmlElement ele3 = (XmlElement)node3;
            ele3.SetAttribute("value", this.txtGrantCode.Text.Trim());

            XmlNode node1 = doc.SelectSingleNode(@"//add[@key='" + connKey + "']");
            XmlElement ele1 = (XmlElement)node1;
            ele1.SetAttribute("value", FT.Commons.Security.SecurityFactory.GetSecurity().Encrypt("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\\\" + this.txtIp.Text.Trim() + "\\db\\db.mdb;User Id=admin;Password=;"));
            doc.Save(Application.ExecutablePath + ".config");
            MessageBoxHelper.Show("����ɹ������˳��ؽ���");
        }
    */
        #endregion
    }
}
