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

public partial class Controls_DateSelectorEX : System.Web.UI.UserControl
{
    protected string jsfile;
    private void Page_Load(object sender, System.EventArgs e)
    {
        //if (Cul == "en")
        //    jsfile = "../Controls/cal/popcalendar_en.js";
        //if (Cul == "cn")
        //    jsfile = "../Controls/cal/popcalendar.js";
        string formatstr = ModuleConfiguration.ModuleConfig.GetConfigValue("DateStringFormat").ToLower();
        string scriptStr = "javascript:return popUpCalendar(this," + getClientID() + @", '"+formatstr+@"', '__doPostBack(\'" + getClientID() + @"\')')";
        this.txt_Date.Width = Width;
        //Response.Write(scriptStr);
        imgCalendar.Attributes.Add("onclick", scriptStr);


        //imgCalendar.Attributes.Add("onkeypress", "");

        //txt
        if (ReadOnly)
        {
            txt_Date.Attributes["onkeydown"] = "return false";
            txt_Date.Attributes["onpaste"] = "return false";
            txt_Date.Attributes["ondragenter"] = "return false";
        }
        else
        {
            txt_Date.Attributes.Remove("onkeydown");
            txt_Date.Attributes.Remove("onpaste");
            txt_Date.Attributes.Remove("ondragenter");
        }
    }


    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    ///		Required method for Designer support - do not modify
    ///		the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);

    }
    #endregion

    // Get the id of the control rendered on client side
    // Very essential for Javascript Calendar scripts to locate the textbox
    public string getClientID()
    {
        return txt_Date.ClientID;
    }

    // This propery sets/gets the calendar date
    public string CalendarDate
    {
        get
        {
            return txt_Date.Text;
        }
        set
        {
            txt_Date.Text = value;
        }
    }
    public bool Enabled
    {
        get
        {
            return txt_Date.Enabled;
        }
        set
        {
            txt_Date.Enabled = value;
            imgCalendar.Visible = value;
        }
    }

    public bool ReadOnly
    {
        get
        {

            return ViewState["ReadOnly"] == null ? true : Convert.ToBoolean(ViewState["ReadOnly"]);
        }
        set
        {
            ViewState["ReadOnly"]=value;
        }
    }

    public Unit Width
    {
        get
        {     
            
            return ViewState["Width"] == null ?new Unit("75px") : (Unit)ViewState["Width"];
        }
        set
        {
            ViewState["Width"] = value;
        }
    }

    //protected override void OnLoad(EventArgs e)
    //{
    //    base.OnLoad(e);
    //    div.InnerHtml = txt_Date.Text;
    //}
    // This Property sets or gets the the label for 
    // Dateselector user control
    //public string Text
    //{
    //    get
    //    {
    //        return lbl_Date.Text;
    //    }
    //    set
    //    {
    //        lbl_Date.Text = value;
    //    }
    //}

    //// This Property sets or gets the the label for 
    //// Dateselector user control
    //public string Cul
    //{
    //    get
    //    {
    //        return jsfile;
    //    }

    //    set
    //    {
    //        jsfile = value;
    //    }
    //}

   
}
