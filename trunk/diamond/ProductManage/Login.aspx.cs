using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.InteropServices;

public partial class Login : Pagebase
{
    [DllImport("ET_OTPVerify.dll")]
    public static extern int ET_CheckPwdz201(string authkey, UInt64 t, UInt64 t0, uint x, int drift, int authwnd, UInt64 lastsucc, string otp, int otplen, ref UInt64 currsucc, ref int currdft);


    [DllImport("ET_OTPVerify.dll")]
    public static extern int ET_Syncz201(string authkey, UInt64 t, UInt64 t0, uint x, int drift, int syncwnd, UInt64 lastsucc, string otp1, int otp1len, string otp2, int otp2len, ref UInt64 currsucc, ref int currdft);

    UInt64 currsucc1 = 0;
    int currdft1 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["logout"] == "true")
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        //CheckLogin checkLogin = new CheckLogin();
        //string userID = this.txt_UserName.Text;
        //string msg = string.Empty;

        //if (checkLogin.Login(this.txt_UserName.Text, this.txt_Pwd.Text, out msg))
        //{
        //    Response.Redirect("Product_List.aspx");
        //}
        //else
        //{
        //    this.lbl_ErrorMessage.Text = msg;
        //    //WriteErrorMsg(msg);
        //}


        CheckLogin checkLogin = new CheckLogin();
        string username = this.txt_UserName.Text;
        string psd = this.txt_Pwd.Text;
        string otp = this.txt_DigiPwd.Text;

        string sql1 = "select User_Temp.Otp_Code,authkey,currsucc,currdft from User_Temp left join otp_data on User_Temp.Otp_Code=otp_data.otp_code where UserName='" + username + "' and PassWord='" + psd + "'";
        DataSet ds1 = checkLogin.DatabaseAccess.ExecuteDataset(sql1);
        if (ds1.Tables[0].Rows.Count == 0)
        {
            Response.Write("<script>alert('ÃÜÂë´íÎó£¡')</script>");
            return;
        }
        string authkey = ds1.Tables[0].Rows[0]["authkey"].ToString();
        string Otp_Code = ds1.Tables[0].Rows[0]["Otp_Code"].ToString();

        UInt64 currsucc = 0;
        int currdft = 0;
        currsucc1 = Convert.ToUInt64(ds1.Tables[0].Rows[0]["currsucc"]);
        currdft1 = Convert.ToInt32(ds1.Tables[0].Rows[0]["currdft"]);

        TimeSpan tsTimeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
        ulong ulgTimeStamp = (ulong)tsTimeSpan.TotalSeconds;
        int iRe = 0;

        iRe = ET_CheckPwdz201(authkey, ulgTimeStamp, 0, 60, currdft1, 40, currsucc1, otp, 6, ref currsucc, ref currdft);
        if (iRe == 0)
        {
            currsucc1 = currsucc;
            currdft1 = currdft;

            string sql2 = string.Format(@"update otp_data set currsucc={0},currdft={1} where otp_code='{2}'", currsucc1, currdft1, Otp_Code);
            int i = checkLogin.DatabaseAccess.ExecuteNonQuery(sql2);
            if (i > 0)
            {
                checkLogin.WriteSession(username, username, username, username);
                Response.Write("<script>alert('µÇÂ¼³É¹¦£¡')</script>");
                Response.Redirect("Storage/BulkStorage.aspx");
            }
        }
        else
        {
            Response.Write("<script>alert('¶¯Ì¬ÃÜÂë´íÎó£¡')</script>");
        }


    }

    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        this.lbl_ErrorMessage.Text = string.Empty;
        this.txt_Pwd.Text = string.Empty;
        this.txt_UserName.Text = string.Empty;
    }
}
