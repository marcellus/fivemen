using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:MyPager runat=server></{0}:MyPager>")]
    public class MyPager : WebControl
    {

        private DataGrid _dg;
        private ImageButton _pre;
        private ImageButton _next;
        private ImageButton _first;
        private ImageButton _end;
        private TextBox _number;
        private Label _lb;
        private ImageButton _go;

        private bool EnablePre
        {
            get
            {
                if (this.CurrentPage == 0)
                    return false;
                else
                    return true;
            }
        }

        private bool EnableNext
        {
            get
            {
                if (this.CurrentPage == this.Pages)
                    return false;
                else
                    return true;
            }
        }

        public int CurrentPage
        {
            get
            {
                if (ViewState["currentpage"] != null)
     
                    ViewState["currentpage"] = this.MyDataGrid.CurrentPageIndex;
                return int.Parse(ViewState["currentpage"].ToString());
            }
            set
            {
                ViewState["currentpage"] =value;
            }
        }
        public int Pages
        {
            get
            {
                if (ViewState["pages"] != null)

                    ViewState["pages"] = this.MyDataGrid.PageCount;
                return int.Parse(ViewState["pages"].ToString());
            }
            set
            {
                ViewState["pages"] = value;
            }

        }
        

        public MyPager()
        {
            _pre = new ImageButton();
            _next = new ImageButton();
            _first = new ImageButton();
            _end = new ImageButton();
            _go = new ImageButton();
            _lb = new Label();
        }

        protected override void CreateChildControls()
        {
            _pre = new ImageButton();
            _next = new ImageButton();
            _first = new ImageButton();
            _end = new ImageButton();
            _go = new ImageButton();
            _lb = new Label();
            _pre.Click += new ImageClickEventHandler(_pre_Click);
            _next.Click += new ImageClickEventHandler(_next_Click);
            _first.Click += new ImageClickEventHandler(_first_Click);
            _end.Click += new ImageClickEventHandler(_end_Click);
            _go.Click += new ImageClickEventHandler(_go_Click);
            base.CreateChildControls();
        }

        void _go_Click(object sender, ImageClickEventArgs e)
        {
            

            //throw new Exception("The method or operation is not implemented.");
        }

        void _end_Click(object sender, ImageClickEventArgs e)
        {
            object obj=this.MyDataGrid.DataSource;
            this.MyDataGrid.CurrentPageIndex += 1;
            this.MyDataGrid.DataSource = obj;
            this.MyDataGrid.DataBind();
            //throw new Exception("The method or operation is not implemented.");
        }

        void _first_Click(object sender, ImageClickEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void _next_Click(object sender, ImageClickEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void _pre_Click(object sender, ImageClickEventArgs e)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();
            writer.WriteBeginTag("<div class='pager'>");
            
            _first.RenderControl(writer);
            _pre.RenderControl(writer);
            _next.RenderControl(writer);
            _end.RenderBeginTag(writer);
            _number.RenderControl(writer);
            _go.RenderControl(writer);

            writer.WriteEndTag("</div>");
           
            base.Render(writer);
        }


        private DataGrid MyDataGrid
        {
            get
            {
                _dg = this.Page.FindControl(this.BindControl) as DataGrid;
                if (_dg == null)
                {
                    throw new ArgumentException("找不到要绑定的DataGrid！");

                }
                return _dg;
            }
        }

        public string PreImageUrl
        {
            get
            {
                return _pre.ImageUrl;
            }
            set
            {
                _pre.ImageUrl = value;
            }
        }
        public string GoImageUrl
        {
            get
            {
                return _go.ImageUrl;
            }
            set
            {
                _go.ImageUrl = value;
            }

        }

        public string NextImageUrl
        {

            get
            {
                return _next.ImageUrl;
            }
            set
            {
                _next.ImageUrl = value;
            }
        }
        public string FirstImageUrl
        {
            get
            {
                return _first.ImageUrl;
            }
            set
            {
                _first.ImageUrl = value;
            }
        }
        public string EndImageUrl
        {
            get
            {
                return _end.ImageUrl;
            }
            set
            {
                _end.ImageUrl = value;
            }
        }

        public string BindControl
        {
            get
            {
                if (_dg != null)
                {
                    return _dg.ClientID;
                }
                else
                {
                    throw new ArgumentException("使用前请绑定一个DataGrid！");
                }
            }
            set
            {
                _dg=this.Parent.Page.FindControl(value) as DataGrid;
                if (_dg == null)
                {
                    throw new ArgumentException("目前仅支持DataGrid！");
                    
                }
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
}
