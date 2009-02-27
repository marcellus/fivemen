using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace FT.Commons.Tools
{
    /// <summary>
    /// xml工具类，主要执行一个Xml的一些帮助
    /// </summary>
    public class XmlHelper : BaseHelper
    {
        #region 修改app.config
        /*
        private const string ipKey = "DbIp";
        private const string grantKey = "GrantCode";

        private const string connKey = "DefaultConnString";

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            // 打开可执行的配置文件*.exe.config
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
             如果连接串已存在，首先删除它
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // 将新的连接串添加到配置文件中.
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
             
            // 保存对配置文件所作的更改
            config.AppSettings.Settings.Add("123", "test");
            config.AppSettings.Settings[ipKey].Value = this.txtIp.Text.Trim();
            config.Save(ConfigurationSaveMode.Full);

           
            // 强制重新载入配置文件的ConnectionStrings配置节
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
            MessageBoxHelper.Show("保存成功，请退出重进！");
        }
    */
        #endregion
    }
}
