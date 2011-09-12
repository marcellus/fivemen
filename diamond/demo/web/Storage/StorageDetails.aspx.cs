using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Storage_StorageDetails : System.Web.UI.Page
{
    private string htype, sid;
    protected void Page_Load(object sender, EventArgs e)
    {
        htype = HttpContext.Current.Request.Params["type"] == null ? "" : HttpContext.Current.Request.Params["type"].ToString();
        sid = HttpContext.Current.Request.Params["Sid"] == null ? "" : HttpContext.Current.Request.Params["Sid"].ToString();
        if (!IsPostBack)
        {


            HandRequest(htype, sid);///根据输入参数进行相应处理
        }
       



    }
    #region 私有函数
    /// <summary>
    /// 根据输入参数进行相应处理
    /// </summary>
    /// <param name="type"></param>
    /// <param name="StorageID"></param>
    private void HandRequest(string type, string storageID)
    {
        if (!string.IsNullOrEmpty(type))
        {
            switch (type)
            {
                case "new"://新增

                    NewRecord();
                    break;
                case "edit"://编辑
                    BindDetails(storageID);
                    break;
                case "view"://浏览
                    BindDetails(storageID);
                    setReadOnly();
                    break;

                default:


                    break;
            }

        }


    }
    /// <summary>
    /// 绑定值
    /// </summary>
    /// <param name="storageID"></param>
    private void BindDetails(string storageID)
    {
        if (!string.IsNullOrEmpty(storageID))
        {
            StorageList storage = new StorageList();
            DataTable dt = storage.GetEntityByID(storageID) as DataTable;
            if (dt != null && dt.Rows.Count > 0)
            {
                this.txt_SNo.Text = storageID;
                this.txt_SNo.ReadOnly = true;
                this.txt_Date.Text = dt.Rows[0]["GenerationTime"] == null ? "" : Convert.ToDateTime(dt.Rows[0]["GenerationTime"].ToString()).ToShortDateString();
                this.txt_Description.Text = dt.Rows[0]["StorageDescription"] == null ? "" : dt.Rows[0]["StorageDescription"].ToString();



            }

        }



    }
    /// <summary>
    ///  设置为只读
    /// </summary>
    private void setReadOnly()
    {
        this.txt_Description.ReadOnly = true;

    }
    private void NewRecord()
    {
        this.txt_Date.Text = DateTime.Now.ToShortDateString();
    
    }
    #endregion



    protected void btn_Save_Click(object sender, EventArgs e)
    {
        StorageList storage = new StorageList();
        string sID=this.txt_SNo.Text==null?"":this.txt_SNo.Text.ToString();
        string description=this.txt_Description.Text==null?"":this.txt_Description.Text.ToString();
        string sql;
        if (string.IsNullOrEmpty(sid))//新增
        {
            sql=string.Format(@"insert into StorageList( StorageNo,StorageDescription,GenerationTime) values('{0}','{1}',getdate())",sID,description);
            storage.DatabaseAccess.ExecuteNonQuery(sql);
            Response.Write("<script>alert('入库单生成成功！');opener.location = opener.location;</script>");
        }
        else//修改
        { 
         sql=string.Format(@"update StorageList set StorageDescription='{1}',GenerationTime=getdate() where StorageNo='{0}'",sID,description);
            storage.DatabaseAccess.ExecuteNonQuery(sql);
            Response.Write("<script>alert('入库单修改成功！');opener.location = opener.location;</script>");
        
        }
    }
}
