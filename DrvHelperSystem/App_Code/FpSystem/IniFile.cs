using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
///IniFile 的摘要说明
/// </summary>
public class IniFile
{
    //ini file name
    public string Path;

    //declare read and write ini file API 
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


    //structure function
    public IniFile(string inipath)
    {
        //
        // TODO: Add constructor logic here
        //
        Path = inipath;
    }

    //write ini file
    public void IniWriteValue(string Section, string Key, string Value)
    {
        WritePrivateProfileString(Section, Key, Value, this.Path);
    }

    //read INI file content
    public string IniReadValue(string Section, string Key)
    {
        StringBuilder temp = new StringBuilder(255);
        int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.Path);
        return temp.ToString();
    }
}
