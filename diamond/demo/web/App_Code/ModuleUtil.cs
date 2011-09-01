using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text;
using System.IO;
/// <summary>
/// Summary description for ModuleUtil
/// </summary>
public class ModuleUtil
{
    public ModuleUtil()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region 日期格式?
    /// <summary>
    /// �获取标准的yyyy-mm-dd 格式日期，方便存储至数据?
    /// </summary>
    /// <param name="dateString">�英文格式下的 dd/mm/yyyy字符串或中文格式下的字符?yyyy-mm-dd.(�建议不要传控值进?</param>
    /// <returns></returns>
    public static DateTime GetNormalDateFormat(string dateString)
    {
        DateTime dtReturn = DateTime.MinValue;
        string strDt = string.Empty;
        if (dateString != string.Empty)
        {
            if (dateString.IndexOf("/") != -1)
            {
                if (dateString.Length > 10)
                {
                    strDt = string.Format("{0}-{1}-{2} {3}", dateString.Substring(6, 4), dateString.Substring(3, 2), dateString.Substring(0, 2), dateString.Substring(10, (dateString.Length - 10)));
                }
                else if (dateString.Length == 10)
                {
                    strDt = string.Format("{0}-{1}-{2}", dateString.Substring(6, 4), dateString.Substring(3, 2), dateString.Substring(0, 2));
                }
            }
            else if (dateString.IndexOf("-") != -1)
            {
                strDt = dateString;
            }
        }
        if (strDt != string.Empty)
        {
            dtReturn = Convert.ToDateTime(strDt);
        }
        return dtReturn;
    }
    #endregion

    #region Base64�编码/解码
    /// <summary>
    /// 将指定字符串进行Base64编码?
    /// </summary>
    /// <param name="codeType"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string EncodeBase64(string codeType, string code)
    {
        string encode = "";
        byte[] bytes = Encoding.GetEncoding(codeType).GetBytes(code);
        encode = Convert.ToBase64String(bytes);
        return encode;
    }
    /// <summary>
    /// �将指定字符串进行Base64解码?
    /// </summary>
    /// <param name="codeType"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string DecodeBase64(string codeType, string code)
    {
        string decode = "";
        byte[] bytes = Convert.FromBase64String(code);

        decode = Encoding.GetEncoding(codeType).GetString(bytes);
        return decode;
    }
    #endregion

    #region 上传文件处理
    /// <summary>
    /// 上传文件处理
    /// </summary>
    /// <param name="postedFile">HttpPostedFile 对象</param>
    /// <param name="fileSavePath">保存文件的路径</param>
    /// <param name="fileType">文件要求的类型,如果没有要求则传入传入空字符串</param>
    /// <param name="fileMaxSize">文件大小限制(字节)</param>
    /// <param name="msg">返回操作后的消息</param>
    /// <param name="newFileName">返回保存后用GUID重新命名的文件名</param>
    /// <returns>保存是否成功</returns>
    public static bool UpLoadFile(HttpPostedFile postedFile, string fileSavePath, string fileType, Int64 fileMaxSize, ref string msg, ref string newFileName)
    {
        string fileExt = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf(".") + 1);
        if (postedFile.ContentLength == 0 || postedFile.FileName == string.Empty)
        {
            msg = ACE.Common.Util.ACECulture.GetGlobeConstResource("haveNotFile");
            return false;
        }
        if (postedFile.ContentLength > fileMaxSize)
        {
            msg = ACE.Common.Util.ACECulture.GetGlobeConstResource("fileSizeError") + fileMaxSize.ToString();
            return false;
        }
        if (fileType != "" && fileType.ToLower().IndexOf(fileExt.ToLower()) < 0)
        {
            msg = ACE.Common.Util.ACECulture.GetGlobeConstResource("fileTypeError");
            return false;
        }
        newFileName = ACE.Common.Util.ACEUtil.NewGuidID + "." + fileExt;
        FileStream fs = new FileStream(fileSavePath + "\\" + newFileName, FileMode.CreateNew);
        try
        {
            byte[] file = new byte[postedFile.ContentLength];
            postedFile.InputStream.Read(file, 0, postedFile.ContentLength);
            fs.Write(file, 0, postedFile.ContentLength);
            msg = ACE.Common.Util.ACECulture.GetGlobeConstResource("fileSaveSuccessful");
            return true;
        }
        catch (Exception ee)
        {
            msg = ee.Message;
            return false;
        }
        finally
        {
            fs.Close();
        }
        //ACE.Common.Util.ACECulture.GetGlobeConstResource("fileSaveSuccessful");

    }
    #endregion
}
