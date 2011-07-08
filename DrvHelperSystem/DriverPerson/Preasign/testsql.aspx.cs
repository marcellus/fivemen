using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class DriverPerson_Preasign_testsql : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           // select distinct '' "jxmc",b.jxmc "jxdm", 'A' "idCardType", a.sfzmhm "idCard",a.xm "name",b.zkcx "zkcx",a.lsh "lsh",to_char(b.yxqs,'yyyy-MM-dd') "yxqs",to_char(b.yxqz,'yyyy-MM-dd') "yxqz",b.jly "jly" from trff_app.drv_flow a left join trff_app.drv_examcard b on a.sfzmhm=b.sfzmhm where a.ywlx in ('A','B') and a.sfzmhm='440583199005011018'

            FT.WebServiceInterface.DrvQuery.DrvQueryHelper.TestSql();
        }
    }
}
