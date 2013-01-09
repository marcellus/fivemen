using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Text;
using System.Drawing;
using System.Data.OracleClient;
using FT.DAL;
using System.Data.SqlClient;

namespace WebControls
{
	/// <summary>
	/// �����ṩ��ί��
	/// </summary>
	

	#region �����֧�֣�����ɣ�
	/// <summary>
	/// SimplePager�������֧��
	/// </summary>
	public class ProcedurePagerDesigner:ControlDesigner
	{
		/// <summary>
		/// ����ڵ�Html
		/// </summary>
		/// <returns> ����ڵ�Html</returns>
		public override string GetDesignTimeHtml()
		{
			
			ProcedurePager temp=(ProcedurePager)this.Component;
			StringBuilder sb=new StringBuilder();
			sb.Append("<div >");
			sb.Append(temp.GetDescription());
			sb.Append("  ");
			sb.Append(temp.ButtonStrings.ToString());
			sb.Append("<input type='text' style='border:solid 1px black;width:40px'></input>");
			sb.Append("<a style='width:40px'>"+temp.ButtonStrings.Go+"</a>");
			sb.Append("</div>");
			return sb.ToString();
		

			//return base.GetDesignTimeHtml ();
		}
		/// <summary>
		/// Ĭ�ϳ�ʼ��
		/// </summary>
		/// <param name="component">��ʱû���õ�</param>
		public override void Initialize(IComponent component)
		{

		
			base.Initialize (component);
		}


	}
	#endregion

	
	/// <summary>
	/// SimplePager ��ժҪ˵����
	/// </summary>
	[
	ParseChildren(true),
	PersistChildren(false),
	Designer(typeof(ProcedurePagerDesigner))
	]
	[ToolboxBitmapAttribute(typeof(ProcedurePager), "ProcedurePager.bmp")] 
	[DefaultProperty("FormatString"),
	ToolboxData("<{0}:ProcedurePager  runat=\"server\"></{0}:ProcedurePager>")]
	public class ProcedurePager:System.Web.UI.WebControls.WebControl,INamingContainer
	{
		
		/// <summary>
		/// ��ȡ��Ϣ���������統ǰҳ{0}/{1},�ܼ�¼��{2}
		/// </summary>
		/// <returns>��Ϣ����</returns>
		public string GetDescription()
		{
			string str=string.Format(this.FormatString,new object[]{this.CurrentPageIndex,this.TotalPages,this.TotalRecordSize});
			if(this.TrueRecordSize>this.TotalRecordSize)
			{
				str+="(ʵ�ʲ�ѯ��¼Ϊ��"+this.TrueRecordSize.ToString()+"��)";
			}
			return str;
		}
		#region ��������
		[Description("��ѯ�������ַ���")]
		[Browsable(true)]

		public string ConnString
		{
			get
			{
				if(ViewState["connstring"]!=null)
				{
					return ViewState["connstring"].ToString();
				}
				else
				{
					return string.Empty;
				}
			}
			set
			{
				ViewState["connstring"]=value;
			}
	}
		/// <summary>
		/// ����
		/// </summary>
		[Description("��ѯ�ı���")]
		[Browsable(true)]
		public string TableName
		{
			get
			{
				if(ViewState["tablename"]==null)
				{
					ViewState["tablename"]=string.Empty;

				}
				return ViewState["tablename"].ToString();

			}
			set
			{
				ViewState["tablename"]=value;
			}

		}
		/// <summary>
		/// �ֶ���
		/// </summary>
		[Description("��ѯ���ֶ���")]
		[Browsable(true)]
		public string FieldString
		{
			get
			{
				if(ViewState["fieldstring"]==null)
				{
					ViewState["fieldstring"]=string.Empty;

				}
				return ViewState["fieldstring"].ToString();

			}
			set
			{
				ViewState["fieldstring"]=value;
			}

		}
		/// <summary>
		/// �����ֶ�
		/// </summary>
		[Description("��ѯ�������ֶ�")]
        [Browsable(true)]
		public string RowFilter
		{
			get
			{
                if (ViewState["rowfilter"] == null || ViewState["rowfilter"].ToString().Length==0)
				{
					ViewState["rowfilter"]=" 1=1";

				}
				return ViewState["rowfilter"].ToString();

			}
			set
			{
				ViewState["rowfilter"]=value;
			}

		}
		//ProcedurePager
		/// <summary>
		/// �����ֶ�
		/// </summary>
		[Description("��ѯ�������ֶ�")]
		[Browsable(true)]
		public string SortString
		{
			get
			{
				if(ViewState["sortstring"]==null)
				{
					ViewState["sortstring"]=string.Empty;

				}
				return ViewState["sortstring"].ToString();

			}
			set
			{
				ViewState["sortstring"]=value;
			}

		}
		[Description("��ѯ�����ҳ����Ĭ��Ϊ300")]
		[Browsable(true)]
		public int MaxPageSize
		{
			get
			{
				if(ViewState["maxpagesize"]==null)
				{
					ViewState["maxpagesize"]=300;

				}
				return Convert.ToInt32(ViewState["maxpagesize"].ToString());

			}
			set
			{
				ViewState["maxpagesize"]=value;
			}

		}
        [Description("��ѯ������ʵ�ʼ�¼����")]
		public int TrueRecordSize
		{
			get
			{
				if(ViewState["truerecordsize"]==null)
				{
					ViewState["truerecordsize"]=0;

				}
				return Convert.ToInt32(ViewState["truerecordsize"].ToString());

			}
			set
			{
				ViewState["truerecordsize"]=value;
			}

		}



		


		#endregion
	
		
		
		#region ����������
		/// <summary>
		/// ��ҳ
		/// </summary>
		private System.Web.UI.WebControls.LinkButton lbFirst;
		/// <summary>20
		/// βҳ
		/// </summary>
		private LinkButton lbEnd;
		/// <summary>
		/// ��һҳ
		/// </summary>
		private LinkButton lbPre;
		/// <summary>
		/// ��һҳ
		/// </summary>
		private LinkButton lbNext;
		/// <summary>
		/// ��ת
		/// </summary>
		private LinkButton lbGo;
		/// <summary>
		/// ��ȡ��ǰҳ
		/// </summary>
		private TextBox tbNum;
		
		#endregion

		#region ���ø��������е���
		/// <summary>
		/// �����������Ӱ�ť��Text
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content),NotifyParentProperty(true)]
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public ButtonStringProvider ButtonStrings
		{
			get
			{
				if(this.buttonStrs==null)
				{
					this.buttonStrs=new ButtonStringProvider();
				}
				return this.buttonStrs;
			}
		}
		private ButtonStringProvider buttonStrs=new ButtonStringProvider();
		#endregion

		#region �ַ���
		/// <summary>
		/// ��ʽ���ַ��� �������page {0} of {1} all{2]record
		/// </summary>
		private string formatStr="��ǰҳ{0}/{1},��{2}����¼";

		/// <summary>
		/// ��ʽ���ַ��� �������page {0} of {1} all{2]record
		/// </summary>
		[DefaultValue("��ǰҳ{0}/{1},��{2}����¼")]
		[Browsable(true)]
		public string FormatString
		{
			get
			{
				return this.formatStr;
			}
			set
			{
				if(this.formatStr.IndexOf("{0}")==-1||this.formatStr.IndexOf("{1}")==-1||this.formatStr.IndexOf("{2}")==-1)
				{
					throw new ArgumentException("��ʽ�ַ����������{0},{1},{2}");
					
				}
				this.formatStr=value;
			}
		}

		/// <summary>
		/// �󶨵Ŀؼ�����
		/// </summary>
		private string bindControl;
		/// <summary>
		/// �󶨵Ŀؼ�����
		/// </summary>
		public string BindControlString
		{
			get
			{
				return this.bindControl;
			}
			set
			{
				this.bindControl=value;
			}
		}

        private Control FindControlExtend(string id, ControlCollection controls)
        {
            int i;
            Control found = null;
            for (i = 0; i < controls.Count; i++)
            {
                if (controls[i].ID == id)
                {

                    found = controls[i];
                    break;
                }
                if (controls[i].Controls.Count > 0)
                {
                    found = FindControlExtend(id, controls[i].Controls);
                    if (found != null)
                    {
                        break;
                    }
                }
            } return (found);
        }

		/// <summary>
		/// �󶨵Ŀؼ�
		/// </summary>
		[Browsable(false)]
		public Control BindedControl
		{
			get
			{
				
				//Control sender =this.OwnerPage.FindControl(this.bindControl);
				this.EnsureChildControls();
                Control sender;
                if (this.Page.Master != null)
                {
                    sender = FindControlExtend(this.bindControl, this.Page.Controls);
                }
                else
                {
                    sender = this.Page.FindControl(this.bindControl);
                }
				return sender;
			}
			
		}

		
		//private string delegateMethod;

		#endregion

		/// <summary>
		/// ��ʼ��
		/// </summary>
		/// <param name="e">����</param>
		protected override void OnInit(EventArgs e)
		{
			//this.BindControl.DataBinding+=new EventHandler(BindControl_DataBinding);
			base.OnInit (e);
			
			
		}

		
		

		#region ViewState������

		/// <summary>
		/// �Ƿ�����Ҫ���°�
		/// </summary>
		[DefaultValue(true)]
		[Browsable(true)]
		public bool Changed
		{
			get
			{
				if(ViewState["changed"]==null)
				{
					ViewState["changed"]=true;

				}
				return Convert.ToBoolean(ViewState["changed"].ToString());

			}
			set
			{
				ViewState["changed"]=value;
			}
		}
		/// <summary>
		/// ҳ��¼����С
		/// </summary>
		[DefaultValue(10)]
		[Browsable(true)]
		public int PageSize
		{
			get
			{
				if(ViewState["pagesize"]==null)
				{
					ViewState["pagesize"]=10;
					
				}
				int result=Convert.ToInt32(ViewState["pagesize"]);
				if(result<1)
				{
					throw new ArgumentException("ҳ�Ĵ�С�������1��");
				}
				return result;
			}
			set
			{
				if(value<1)
				{
					throw new ArgumentException("ҳ�Ĵ�С�������1��");
				}
				ViewState["pagesize"]=value;
			}
			
		}
		/// <summary>
		/// ��ǰҳ��������ʽ�ַ�����{0}
		/// </summary>

		[DefaultValue(0)]
		[Browsable(false)]
		public int CurrentPageIndex
		{
			get
			{
				if(ViewState["currentpageindex"]==null)
				{
					ViewState["currentpageindex"]=1;
					
				}
				int result=Convert.ToInt32(ViewState["currentpageindex"]);
				if(result<1)
				{
					throw new ArgumentException("��ǰҳ����С��1��");
				}
				return result;
			}
			set
			{
				if(value<1)
				{
					throw new ArgumentException("��ǰҳ����С��1��");
				}
				ViewState["currentpageindex"]=value;
			}
		}
		/// <summary>
		/// ��¼��������ʽ�ַ�����{2}
		/// </summary>
		[DefaultValue(0)]
		[Browsable(false)]
		public int TotalRecordSize
		{
			get
			{
				if(ViewState["totalrecordsize"]==null)
				{
					ViewState["totalrecordsize"]=0;
					
				}
				int result=Convert.ToInt32(ViewState["totalrecordsize"]);
				if(result<0)
				{
					throw new ArgumentException("��¼������С��0��");
				}
				return result;
			}
			set
			{
				ViewState["totalrecordsize"]=value;
			}
			
		}
		#endregion
		


		/// <summary>
		/// ��д��Render����
		/// </summary>
		/// <param name="writer">�����</param>
		protected override void Render(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Id,this.ClientID);
			writer.RenderBeginTag(HtmlTextWriterTag.Span);
			writer.Write(this.GetDescription());
			writer.Write("  ");
			this.lbFirst.RenderControl(writer);
			writer.Write(" | ");
			this.lbEnd.RenderControl(writer);
			writer.Write(" | ");
			this.lbPre.RenderControl(writer);
			writer.Write(" | ");
			this.lbNext.RenderControl(writer);
			writer.Write("  ");
			this.tbNum.RenderControl(writer);
			writer.Write(" ");
			this.lbGo.RenderControl(writer);

			writer.RenderEndTag();//Span
			//base.Render (writer);
		}
		/// <summary>
		/// �¼�ð�ݣ���ʱû��ʹ��
		/// </summary>
		/// <param name="source">�¼�Դ</param>
		/// <param name="args">����</param>
		/// <returns>�Ƿ�ð��</returns>
		protected override bool OnBubbleEvent(object source, EventArgs args)
		{
			return base.OnBubbleEvent (source, args);
		}


		/// <summary>
		/// ע��ؼ�Ϊ��Ҫ�ش����¼�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreRender(EventArgs e)
		{
			if(this.Changed)
				this.BindData();
			base.OnPreRender (e);
			//Page.RegisterRequiresPostBack(this);
			
		}


		/// <summary>
		/// ��д�Ĺ��캯��
		/// </summary>

		protected override void CreateChildControls()
		{
			//base.CreateChildControls ();
			Controls.Clear();
			this.lbFirst=new LinkButton();
			this.lbFirst.ID="lbFirst";
			lbFirst.Text=this.ButtonStrings.First;
			this.lbFirst.Click+=new EventHandler(lbFirst_Click);
			this.Controls.Add(this.lbFirst);
			
			this.lbPre=new LinkButton();
			this.lbPre.ID="lbPre";
			this.lbPre.Text=this.ButtonStrings.Pre;
			this.lbPre.Click+=new EventHandler(lbPre_Click);
			this.Controls.Add(this.lbPre);
			
			this.lbNext=new LinkButton();
			this.lbNext.ID="lbNext";
			this.lbNext.Text=this.ButtonStrings.Next;
			this.lbNext.Click+=new EventHandler(lbNext_Click);
			this.Controls.Add(this.lbNext);
			
			this.lbEnd=new LinkButton();
			this.lbEnd.ID="lbEnd";
			this.lbEnd.Text=this.ButtonStrings.End;
			this.lbEnd.Click+=new EventHandler(lbEnd_Click);
			this.Controls.Add(this.lbEnd);
	
			this.tbNum=new TextBox();
			this.tbNum.ID="tbNum";
			this.tbNum.Width=30;
			this.tbNum.Style.Add("border","solid 1px black;");
			this.tbNum.Text=this.CurrentPageIndex.ToString();
			this.Controls.Add(this.tbNum);
		
			this.lbGo=new LinkButton();
			this.lbGo.ID="lbGo";
			this.lbGo.Text=this.ButtonStrings.Go;
			this.lbGo.Click+=new EventHandler(lbGo_Click);
			this.Controls.Add(this.lbGo);
			//this.BindedControl.DataBinding+=new EventHandler(BindControl_DataBinding);

			

		}




		/// <summary>
		/// Ĭ�Ϲ��캯��
		/// </summary>
		public ProcedurePager()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ǰҳ��¼��ʼ��
		/// </summary>
		private int StartRow
		{
			get
			{
				return (this.CurrentPageIndex-1)*this.PageSize;
			}
		}
		/// <summary>
		/// �Ƿ��������ݰ�
		/// </summary>
		[
		Browsable(true)
		]
		public bool AllowBinded
		{
			get
			{
				if (ViewState["allowbinded"] == null)
				{
					ViewState["allowbinded"] = false;
				}
				return (bool)ViewState["allowbinded"];
			}
			set
			{
				ViewState["allowbinded"] = value;
			}
		}
		/// <summary>
		/// ��ǰҳ����������
		/// </summary>
		private int EndRow
		{
			get
			{

				int t=(this.CurrentPageIndex)*this.PageSize-1;
				return t<this.TotalRecordSize?t+1:this.TotalRecordSize;
			}
		}
		/// <summary>
		/// �ܵ�ҳ��
		/// </summary>
		private int TotalPages
		{
			get
			{
				int temp=this.TotalRecordSize/this.PageSize;
				if (temp == 0)
					return 1;
				if(this.TotalRecordSize%this.PageSize>0)
				{
					temp++;
				}
				return temp;
			}
		}

		private DataTable DataProvider()
		{
            DataSet ds = null;
			IDataAccess ob;
            //.SelectDSByProcedure
			if(this.ConnString!=string.Empty)
			{
				//ob=new OracleBase(this.ConnString);
                ob = FT.DAL.DataAccessFactory.GetDataAccess();
				
			}
			else
			{
				//ob=new OracleBase();
                ob = FT.DAL.DataAccessFactory.GetDataAccess();
			}
            if (ob.GetDialectType() == DBDialect.Oracle)
            {

                //ob.Open();
                System.Data.OracleClient.OracleParameter[] cmdparams = new OracleParameter[9];
                System.Data.OracleClient.OracleParameter p1 = new OracleParameter("TbName", OracleType.VarChar, 50);
                p1.Value = this.TableName;



                System.Data.OracleClient.OracleParameter p2 = new OracleParameter("FieldStr", OracleType.VarChar, 3000);
                p2.Value = this.FieldString;

                System.Data.OracleClient.OracleParameter p3 = new OracleParameter("RowFilter", OracleType.VarChar, 3000);
                p3.Value = this.RowFilter;

                System.Data.OracleClient.OracleParameter p4 = new OracleParameter("SortStr", OracleType.VarChar, 3000);
                p4.Value = this.SortString;

                System.Data.OracleClient.OracleParameter p5 = new OracleParameter("Pagesize", OracleType.Number);
                p5.Value = this.PageSize;

                System.Data.OracleClient.OracleParameter p6 = new OracleParameter("Currentindex", OracleType.Number);
                p6.Value = this.CurrentPageIndex;


                System.Data.OracleClient.OracleParameter p7 = new OracleParameter("TotalCount", OracleType.Number);
                p7.Value = 0;
                p7.Direction = System.Data.ParameterDirection.Output;

                System.Data.OracleClient.OracleParameter p8 = new OracleParameter("MaxPageSize", OracleType.Number);
                p8.Value = this.MaxPageSize;

                System.Data.OracleClient.OracleParameter p9 = new OracleParameter("returncur", OracleType.Cursor);
                p9.Direction = System.Data.ParameterDirection.Output;
                cmdparams[0] = p1;
                cmdparams[1] = p2;
                cmdparams[2] = p3;
                cmdparams[3] = p4;
                cmdparams[4] = p5;
                cmdparams[5] = p6;
                cmdparams[6] = p7;
                cmdparams[7] = p8;
                cmdparams[8] = p9;
                for (int i = 0; i < 7; i++)
                {
                    Debug.WriteLine(cmdparams[i].Value.ToString());
                }

                Debug.WriteLine(System.DateTime.Now.ToShortTimeString());
                ds = ob.SelectDSByProcedure("ProcedurePager.Per_QuickPage", cmdparams);
                Debug.WriteLine(System.DateTime.Now.ToShortTimeString());
                this.TrueRecordSize = Convert.ToInt32(p7.Value);
                this.TotalRecordSize = this.TrueRecordSize > this.PageSize * this.MaxPageSize ? this.PageSize * this.MaxPageSize : this.TrueRecordSize;

            }
            else if (ob.GetDialectType() == DBDialect.SqlServer)
            {
                /*--asp.net��ȡ����public DataSet GetList(int PageSize,int PageIndex,string strWhere,string ziduan)
086
{
087
SqlParameter[] parameters = {
088
new SqlParameter("@tblName", SqlDbType.VarChar, 255),
089
new SqlParameter("@fldName", SqlDbType.VarChar, 255),
090
new SqlParameter("@PageSize", SqlDbType.Int),
091
new SqlParameter("@PageIndex", SqlDbType.Int),
092
new SqlParameter("@IsReCount", SqlDbType.Bit),
093
new SqlParameter("@OrderType", SqlDbType.Bit),
094
new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
095
};
096
parameters[0].Value = "azj_zxgsinfo";
097
  parameters[1].Value = ziduan;//snow [2012-7-20 10:21:51]
098
parameters[2].Value = PageSize;
099
parameters[3].Value = PageIndex;
100
parameters[4].Value = 0;
101
parameters[5].Value = 1;
102
parameters[6].Value = strWhere;
103
  return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
104
}
*/
                //ob.Open();
                System.Data.SqlClient.SqlParameter[] cmdparams = new SqlParameter[11];
                System.Data.SqlClient.SqlParameter p1 = new SqlParameter("@TableName", SqlDbType.VarChar, 255);
                p1.Value = this.TableName;



                System.Data.SqlClient.SqlParameter p2 = new SqlParameter("@FieldList", SqlDbType.VarChar, 1000);
                p2.Value = this.FieldString;

                System.Data.SqlClient.SqlParameter p3 = new SqlParameter("@PageSize", SqlDbType.Int);
                p3.Value = this.PageSize;

                System.Data.SqlClient.SqlParameter p4 = new SqlParameter("@PageIndex", SqlDbType.Int);
                p4.Value = this.CurrentPageIndex;

                System.Data.SqlClient.SqlParameter p5 = new SqlParameter("@RecorderCount", SqlDbType.Int);
                p5.Value = 0;

                System.Data.SqlClient.SqlParameter p6 = new SqlParameter("@Where", SqlDbType.VarChar, 1000);
                p6.Value = this.RowFilter;


                System.Data.SqlClient.SqlParameter p7 = new SqlParameter("@TotalCount", SqlDbType.Int);
               // p7.Value = 1;
                p7.Direction = System.Data.ParameterDirection.Output;

                System.Data.SqlClient.SqlParameter p8 = new SqlParameter("@Order", SqlDbType.VarChar, 1000);
                p8.Value = this.SortString;

                

                System.Data.SqlClient.SqlParameter p9 = new SqlParameter("@TotalPageCount", SqlDbType.Int);
                p9.Direction = System.Data.ParameterDirection.Output;

                System.Data.SqlClient.SqlParameter p10 = new SqlParameter("@SortType", SqlDbType.Int);
                p10.Value = 3;



                System.Data.SqlClient.SqlParameter p11 = new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 100);
                p11.Value = string.Empty;
                cmdparams[0] = p1;
                cmdparams[1] = p2;
                cmdparams[2] = p3;
                cmdparams[3] = p4;
                cmdparams[4] = p5;
                cmdparams[5] = p6;
                cmdparams[6] = p7;
                cmdparams[7] = p8;
                cmdparams[8] = p9;
                cmdparams[9] = p10;
                cmdparams[10] = p11;
                

                Debug.WriteLine(System.DateTime.Now.ToShortTimeString());
                ds = ob.SelectDSByProcedure("P_viewPage", cmdparams);
                Debug.WriteLine(System.DateTime.Now.ToShortTimeString());
                this.TrueRecordSize = Convert.ToInt32(p7.Value);
                this.TotalRecordSize = this.TrueRecordSize > this.PageSize * this.MaxPageSize ? this.PageSize * this.MaxPageSize : this.TrueRecordSize;

            }
			return ds==null?null:ds.Tables[0];
		}

		/// <summary>
		/// ������Դȡ������ɸѡ����ǰҳ��������
		/// </summary>
		/// <returns>�µ�DataTable</returns>
		private DataTable PreData()
		{
           
			try
			{
				//int count;
				DataTable dt=this.DataProvider();
				if(dt!=null)
				{
					//this.TotalRecordSize=count;
					if(this.TotalPages<this.CurrentPageIndex)
					{
						this.CurrentPageIndex=this.TotalPages;
					}
					Debug.WriteLine("��¼����:"+this.TotalRecordSize);
					Debug.WriteLine("��ʼ��¼��"+this.StartRow);
					Debug.WriteLine("������¼��"+this.EndRow);
					return dt;
				}
				else
				{
					this.lbFirst.Enabled = false;
					this.lbPre.Enabled = false;
					this.lbNext.Enabled = false;
					this.lbEnd.Enabled = false;
					return null;
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine(ex.ToString());
				throw new ArgumentException("�ṩ������Դ����ת��ΪDataView");
				
			}
		}

		/// <summary>
		/// �����ת��ť���¼�
		/// </summary>
		/// <param name="sender">��ת��ť</param>
		/// <param name="e">�¼�����</param>
	
		private void lbGo_Click(object sender, EventArgs e)
		{
			try
			{
				int newIndex=Convert.ToInt32(this.tbNum.Text);
				if(newIndex>=1&&newIndex<=this.TotalPages)
				{
					this.CurrentPageIndex=newIndex;
					this.Changed=true;
					this.BindData();
				}
				else
				{
					this.tbNum.Text=this.CurrentPageIndex.ToString();
				}
			}
			catch
			{

			}
		}

		/// <summary>
		/// ���βҳ�İ�ť�¼�
		/// </summary>
		/// <param name="sender">βҳ��ť</param>
		/// <param name="e">�¼�����</param>
		private void lbEnd_Click(object sender, EventArgs e)
		{
			this.CurrentPageIndex=this.TotalPages;
			this.Changed=true;
			this.BindData();
		}

		/// <summary>
		/// �����һҳ�İ�ť�¼�
		/// </summary>
		/// <param name="sender">��һҳ��ť</param>
		/// <param name="e">�¼�����</param>
		private void lbNext_Click(object sender, EventArgs e)
		{
			if(this.CurrentPageIndex<this.TotalPages)
				this.CurrentPageIndex++;
			this.Changed=true;
			this.BindData();

		}

		/// <summary>
		/// ���ǰһҳ�İ�ť�¼�
		/// </summary>
		/// <param name="sender">ǰһҳ��ť</param>
		/// <param name="e">�¼�����</param>
		private void lbPre_Click(object sender, EventArgs e)
		{
			if(this.CurrentPageIndex>1)
				this.CurrentPageIndex--;
			this.Changed=true;
			this.BindData();

		}

		/// <summary>
		/// �����ҳ�������¼�
		/// </summary>
		/// <param name="sender">��ҳ��ť</param>
		/// <param name="e">�¼�����</param>
		private void lbFirst_Click(object sender, EventArgs e)
		{
			this.CurrentPageIndex=1;
			this.Changed=true;
			this.BindData();

		}

		
		/// <summary>
		/// �ؼ������ݰ�
		/// </summary>

		private void BindData()
		{
			if (!this.AllowBinded)
			{
				this.lbFirst.Enabled = false;
				this.lbPre.Enabled = false;
				this.lbNext.Enabled = false;
				this.lbEnd.Enabled = false;
				this.lbGo.Enabled = false;

				return;
			}
			else if(this.Changed)
			{
				this.lbGo.Enabled = true;
				Control sender = this.BindedControl;
				try
				{
					if (sender is DataGrid)
					{
						DataGrid dg = (DataGrid)sender;
						DataTable dt = this.PreData();
						if (dt != null)
						{

							dg.DataSource = dt;
							dg.DataBind();
						}
						else
						{
							return;
						}
					}
					else if (sender is Repeater)
					{
						Repeater rp = (Repeater)sender;
						DataTable dt = this.PreData();
						if (dt != null)
						{
							rp.DataSource = dt;
							rp.DataBind();
						}
						else
						{
							return;
						}
					}
					else if (sender is DataList)
					{
						DataList list = (DataList)sender;
						DataTable dt = this.PreData();
						if (dt != null)
						{
							list.DataSource = dt;
							list.DataBind();
						}
						else
						{
							return;
						}
					}
                    else if (sender is GridView)
                    {
                        GridView list = (GridView)sender;
                        DataTable dt = this.PreData();
                        if (dt != null)
                        {
                            list.DataSource = dt;
                            list.DataBind();
                        }
                        else
                        {
                            return;
                        }
                    }
					else
					{
						throw new ArgumentException("�󶨵Ŀؼ���֧��DataGrid,DataList,Repeater");
					}
					if(this.TotalPages==1)
					{

						this.lbFirst.Enabled = false;
						this.lbPre.Enabled = false;
						this.lbNext.Enabled = false;
						this.lbEnd.Enabled = false;
					}
					else if (this.CurrentPageIndex == this.TotalPages)
					{
						this.lbFirst.Enabled = true;
						this.lbPre.Enabled = true;
						this.lbNext.Enabled = false;
						this.lbEnd.Enabled = false;
					}
				    
					else if (this.CurrentPageIndex == 1)
					{
						this.lbFirst.Enabled = false;
						this.lbPre.Enabled = false;
						this.lbNext.Enabled = true;

						this.lbEnd.Enabled = true;
					}
					else if (this.CurrentPageIndex > 1 && this.CurrentPageIndex < this.TotalPages)
					{

						this.lbFirst.Enabled = true;
						this.lbPre.Enabled = true;
						this.lbNext.Enabled = true;

						this.lbEnd.Enabled = true;
					}
					this.tbNum.Text = this.CurrentPageIndex.ToString();
					this.Changed=false;


				}
				catch(Exception ex)
				{
					Debug.WriteLine(ex.ToString());

					//throw new ArgumentException("���ṩһ������ת��Ϊdataview������Դ��");
				}
			}
		}

	}
}
