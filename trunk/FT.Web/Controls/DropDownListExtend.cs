using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Web;
using System.Collections;


namespace WebControls
{
	/// <summary>
	/// WebCustomControl1 的摘要说明。
	/// </summary>
	[ToolboxBitmapAttribute(typeof(DropDownListExtend), "DropDownListExtend.bmp")] 
	[DefaultProperty("Text"),
		ToolboxData("<{0}:DropDownListExtend runat=server></{0}:DropDownListExtend>")]
	public class DropDownListExtend : System.Web.UI.WebControls.WebControl
	{
		private TextBox tb;
		private DropDownList ddl;
		private ArrayList items;

		public DropDownListExtend()
		{
			tb=new TextBox();
			ddl=new DropDownList();
			items=new ArrayList();
			
		}

		public void Add(System.Web.UI.WebControls.ListItem li)
		{
			ddl.Items.Add(li);
			items.Add(new string[]{li.Text,li.Value});
			
			ViewState[this.ClientID]=items;
			
		}
		private void ReInit()
		{
			
			this.ddl.Items.Clear();
			if(ViewState[this.ClientID]!=null)
			{
				ArrayList a=ViewState[this.ClientID] as ArrayList;
				for(int i=0;i<a.Count;i++)
				{
					string[] array=a[i] as string[];
					ddl.Items.Add(new ListItem(array[0],array[1]));
				}
				
			}
			
			ddl.Items.Insert(0,new ListItem("请选择","-1"));
			if(ViewState[this.ClientID+"_text"]!=null)
			{
				this.tb.Text=ViewState[this.ClientID+"_text"].ToString();
			}
			
		}
		public void Insert(int index,ListItem li)
		{
			ddl.Items.Insert(index,li);
			items.Insert(index,new string[]{li.Text,li.Value});
			ViewState[this.ClientID]=items;
		
		}
		[Bindable(true),
		Category("Appearance"),
		DefaultValue("")]
		public object DataSource
		{
			get
			{
				return ddl.DataSource;
			}
			set
			{
				ddl.DataSource=value;
			}
		}

		[Bindable(true),
		Category("Appearance"),
		DefaultValue("")]
		public string DataTextField
		{
			get
			{
				return ddl.DataTextField;
			}
			set
			{
				ddl.DataTextField=value;
			}
		}

		[Bindable(true),
		Category("Appearance"),
		DefaultValue("")]
		public string DataValueField
		{
			get
			{
				return ddl.DataValueField;
			}
			set
			{
				ddl.DataValueField=value;
			}
		}

		[Bindable(true),
			Category("Appearance"),
			DefaultValue("")]
		public string Text
		{
			get
			{
				string temp=System.Web.HttpContext.Current.Request.Form[this.ClientID+"_tb"];
				ViewState[this.ClientID+"_text"]=temp;
				return temp;
			}

			set
			{
				ViewState[this.ClientID+"_text"]=value;
				tb.Text = value;
			}
		}

		/// <summary>
		/// 将此控件呈现给指定的输出参数。
		/// </summary>
		/// <param name="output"> 要写出到的 HTML 编写器 </param>
		protected override void Render(HtmlTextWriter output)
		{
			int iWidth = Convert.ToInt32(base.Width.Value);
			if(iWidth == 0)
			{
				iWidth = 102;
				base.Width = Unit.Parse("102px");
			}

			int sWidth = iWidth + 16;
			int spanWidth=sWidth-18;
			

			output.Write("<div style=\"POSITION:relative\">");
			output.Write("<span style=\"MARGIN-LEFT:" + iWidth.ToString() + "px;OVERFLOW:hidden;WIDTH:16px\">");

			this.ddl.ID=this.ClientID+"_ddl";
			ddl.Width = Unit.Parse(sWidth.ToString() + "px");
			ddl.Style.Add("MARGIN-LEFT", "-" + spanWidth.ToString() + "px");
			ddl.Attributes.Add("onchange", "this.parentNode.nextSibling.value=this.options[this.selectedIndex].text");

		    this.ReInit();
			ddl.RenderControl(output);
			
			
			

			output.Write("</span>");
			tb.ID=this.ClientID+"_tb";
			tb.Width=sWidth;
			tb.ToolTip="请选择或者输入!";
			tb.Style.Add("MARGIN-LEFT", "-" + sWidth.ToString() + "px");
			tb.RenderControl(output);
//
//			base.Style.Clear();
//			base.Width = Unit.Parse(iWidth.ToString() + "px");
//			base.Style.Add("left", "0px");
//			base.Style.Add("POSITION", "absolute");
//
//			base.Render(output);

			output.Write("</div>");
		}
	}
}
