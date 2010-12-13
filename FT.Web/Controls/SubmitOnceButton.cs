using System;
using System.Web.UI.WebControls;

namespace HMG.WebControls
{
    /**/
    /// <summary>
    /// 提交成功后执行关闭还是重定位到本页面
    /// </summary>
    public enum SubmitStyle
    {
        /**/
        /// <summary>
        /// 重定位
        /// </summary>
        Redirect,
        /**/
        /// <summary>
        /// 关闭
        /// </summary>
        Close
    }

    /**/
    /// <summary>
    /// SubmitOnceButton 的摘要说明。
    /// </summary>
    public class SubmitOnceButton : System.Web.UI.WebControls.Button
    {
        /**/
        /// <summary>
        /// 默认的构造函数，当没有构造函数的时候不会执行
        /// </summary>
        public SubmitOnceButton()
            : base()
        {
        }

        /**/
        /// <summary>
        /// 执行成功后重定位的Url
        /// </summary>
        public string Url
        {
            get
            {
                if (ViewState["url"] == null)
                {
                    ViewState["url"] = string.Empty;
                }
                return ViewState["url"].ToString();
            }
            set
            {
                ViewState["url"] = value;
            }
        }
        /**/
        /// <summary>
        /// 执行时候显示的临时文本
        /// </summary>
        public string TempText
        {
            get
            {
                if (ViewState["temptext"] == null)
                {
                    ViewState["temptext"] = "请稍候";
                }
                return ViewState["temptext"].ToString();
            }
            set
            {
                ViewState["temptext"] = value;
            }
        }
        /**/
        /// <summary>
        /// 执行成功后关闭本页面还是重定位 使用的样式
        /// </summary>
        private SubmitStyle hint = SubmitStyle.Redirect;
        /**/
        /// <summary>
        /// 执行成功后关闭本页面还是重定位
        /// </summary>
        public SubmitStyle SubmitSuccessStyle
        {
            get
            {
                return this.hint;
            }
            set
            {
                this.hint = value;
            }

        }
        private string GetScriptBlock()
        {
            const string FormatStr = "javascript:if(validSuccess&&validSuccess==0){{this.value='{0}';setTimeout(function Test(){{this.disabled=true;}},0);}}";
            string temp = string.Empty;
            return string.Format(FormatStr, new object[] { this.TempText }) + temp;
        }
        /**/
        /// <summary>
        /// 执行成功后重新定位
        /// </summary>
        /// <param name="msg">成功后的提示信息</param>
        public void SubmitSuccess(string msg)
        {
            if (this.Url == string.Empty)
            {
                this.Url = this.Page.Request.UrlReferrer.ToString();
            }
            if (this.SubmitSuccessStyle == SubmitStyle.Redirect)
            {
                this.Page.RegisterStartupScript(this.ClientID, "<script>alert('" + msg + "');window.location.href='" + this.Url + "';history.go(1);</script>");
            }
            else
            {
                this.Page.RegisterStartupScript(this.ClientID, "<script>alert('" + msg + "');window.opener=null;window.close();</script>");
            }


        }
        /**/
        /// <summary>
        /// 给加客户端提示信息
        /// </summary>
        /// <param name="writer">输出流</param>
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            this.Attributes.Add("onclick", this.GetScriptBlock());
            base.AddAttributesToRender(writer);
        }


    }
}
