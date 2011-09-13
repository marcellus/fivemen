using System;
using System.Data;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using Vasco;

/// <summary>
/// Summary description for Vacman
/// </summary>
public class Vacman : ModuleDALBase
{
	public Vacman()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
    /// <summary>
    /// 将DPX文件中的DIGIPASS信息存入数据库
    /// </summary>
    /// <param name="DPXFileNamePath">DPX文件路径</param>
    /// <param name="InitKey">DPX文件使用的KEY</param>
    /// <param name="Msg">返回的操作信息</param>
    /// <returns>操作是否成功</returns>
    public bool SaveDataFromDPX(string DPXFileNamePath, string InitKey, ref string Msg)
    {
        DatabaseAccess.BeginTransaction();
        AAL2Wrap dp = null;
        try
        {
            dp = new AAL2Wrap();
            int appCount = 0, digiPassCount = 0;
            string[] AppliNames = dp.AAL2DPXInit(DPXFileNamePath, InitKey, ref appCount, ref digiPassCount);
            if (AppliNames == null)
            {
                Msg = string.Format("DPX Import Error:{0}", dp.getLastError());
                return false;
            }
            AAL2Wrap.TDigipass[] AppliBlobs;

            AppliBlobs = new AAL2Wrap.TDigipass[appCount];
            for (int j = 0; j < (digiPassCount * appCount); )
            {
                AppliBlobs = dp.AAL2DPXGetTokenBlobs(ref appCount);
                for (int l = 0; l < appCount; l++)
                {
                    SaveDigiPass(AppliBlobs[l].SerialNumber, AppliBlobs[l].Type, AppliBlobs[l].Mode, AppliBlobs[l].bDpData);
                    j++;
                }
            }
            Msg = string.Format("AppCount:{0},DigiPassCount:{1} Saved", appCount, digiPassCount);
            return true;
        }
        catch (SqlException ex)
        {
            Msg = ex.Message;
            DatabaseAccess.RollbackTransaction();
            return false;
        }
        finally
        {
            dp.AAL2DPXClose();
            DatabaseAccess.CommitTransaction();
        }
    }
    /// <summary>
    /// 根据序列号插入或修改DIGIPASS相关信息
    /// </summary>
    /// <param name="SerialNumber">序列号</param>
    /// <param name="DigipassType">DIGIPASS型号</param>
    /// <param name="Mode">验证模式</param>
    /// <param name="Data">DIGIPASS数据</param>
    public void SaveDigiPass(string SerialNumber, string DigipassType, string Mode, byte[] Data)
    {
        ACE.Common.DB.DBParameterCollection param = new ACE.Common.DB.DBParameterCollection();
        param.Add(new SqlParameter("@Serial_number", SerialNumber));
        param.Add(new SqlParameter("@Digipass_Type", DigipassType));
        param.Add(new SqlParameter("@Application_Mode", Mode));
        param.Add(new SqlParameter("@Digipass_Data", Data));
        ((SqlParameter)param["@Digipass_Data"]).SqlDbType = SqlDbType.Binary;
        ((SqlParameter)param["@Digipass_Data"]).Size = 248;
        DatabaseAccess.ExecuteNonQuery("SaveDigiPass", param);
    }
    /// <summary>
    /// 保存DIGIPASS信息
    /// </summary>
    /// <param name="Digipass">DIGIPASS数据</param>
    public void SaveDigiPass(AAL2Wrap.TDigipass Digipass)
    {
        SaveDigiPass(Digipass.SerialNumber, Digipass.Type, Digipass.Mode, Digipass.bDpData);
    }
    /// <summary>
    /// 验证动态密码,RESPONSE ONLY
    /// </summary>
    /// <param name="passWord">密码</param>
    /// <param name="Digipass">DIGIPASS数据</param>
    /// <param name="Msg">返回的消息</param>
    /// <returns>验证成功返回HOSTCODE否则返回FALSE</returns>
    public bool VerifyDigiPass(string passWord,AAL2Wrap.TDigipass Digipass,ref string Msg)
    {
        return VerifyDigiPass(passWord, Digipass.SerialNumber, Digipass.Type, Digipass.Mode, Digipass.bDpData, ref Msg);
    }
    /// <summary>
    /// 验证动态密码 RESPONSE ONLY
    /// </summary>
    /// <param name="passWord">密码</param>
    /// <param name="SerialNumber">序列号</param>
    /// <param name="DigipassType">型号</param>
    /// <param name="Mode">模式</param>
    /// <param name="Data">数据</param>
    /// <param name="Msg">返回的消息</param>
    /// <returns>验证成功返回HOSTCODE否则返回FALSE</returns>
    public bool VerifyDigiPass(string passWord,string SerialNumber, string DigipassType, string Mode, byte[] Data,ref string Msg)
    {
        AAL2Wrap dp = new AAL2Wrap();
        int ret = 0;
        ret = dp.AAL2VerifyPassword(Data, passWord, null);
        Msg = dp.getLastError();
        //超出限时阀值,重置数据.
        if (ret == 202 || ret == 203)
        {
            dp.AAL2ResetTokenInfo(Data);
        }
        //保存数据到数据库
        SaveDigiPass(SerialNumber, DigipassType, Mode, Data);
        if (ret == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 验证动态密码 RESPONSE ONLY
    /// </summary>
    /// <param name="passWord">密码</param>
    /// <param name="SerialNumber">序列号</param>
    /// <param name="DigipassType">型号</param>
    /// <param name="Mode">模式</param>
    /// <param name="Data">数据</param>
    /// <param name="Msg">返回的消息</param>
    /// <returns>验证成功返回HOSTCODE否则返回FALSE</returns>
    public bool VerifyDigiPass(string passWord, string SerialNumber, string DigipassType, string Mode, string Data, ref string Msg)
    {
        byte[] buffer = new byte[Data.Length + 1];
        int index = 0;
        foreach (char ch in Data.ToCharArray())
        {
            buffer[index] = Convert.ToByte(ch);
            index++;
        }
        buffer[index] = 0;
        return VerifyDigiPass(passWord, SerialNumber, DigipassType, Mode, buffer,ref Msg);
    }
}
