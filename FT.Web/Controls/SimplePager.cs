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

namespace WebControls
{
    /// <summary>
    /// �����ṩ��ί��
    /// </summary>
    public delegate DataTable PagerDataProvider();

    #region �����֧�֣�����ɣ�
    /// <summary>
    /// SimplePager�������֧��
    /// </summary>
    public class SimplePagerDesigner : ControlDesigner
    {
        /// <summary>
        /// ����ڵ�Html
        /// </summary>
        /// <returns> ����ڵ�Html</returns>
        public override string GetDesignTimeHtml()
        {
            SimplePager temp = (SimplePager)this.Component;
            StringBuilder sb = new StringBuilder();
            sb.Append("<div >");
            sb.Append(temp.GetDescription());
            sb.Append("  ");
            sb.Append(temp.ButtonStrings.ToString());
            sb.Append("<input type='text' style='border:solid 1px black;width:40px'></input>");
            sb.Append("<a style='width:40px'>" + temp.ButtonStrings.Go + "</a>");
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
            base.Initialize(component);
        }
    }
    #endregion

    #region ��ť�ַ��ṩ�ߣ��������ԣ�����ɣ�
    /// <summary>
    /// ��ť�ַ��ṩ�ߣ��������ԣ�����ɣ�
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ButtonStringProvider
    {

        private string pre;
        private string end;
        private string first;
        private string next;
        private string go;
        /// <summary>
        /// ��д��ToString
        /// </summary>
        /// <returns>��ҳ��βҳ����һҳ����һҳ</returns>
        public override string ToString()
        {
            return first + " | " + end + " | " + pre + " | " + next;
        }

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public ButtonStringProvider()
            : this("��ҳ", "βҳ", "��һҳ", "��һҳ", "����")
        {

        }
        /// <summary>
        /// �������Ĺ��캯��
        /// </summary>
        /// <param name="first">��ҳ��Text</param>
        /// <param name="end">βҳ��Text</param>
        /// <param name="pre">��һҳ��Text</param>
        /// <param name="next">��һҳ��Text</param>
        /// <param name="go">��ת��Text</param>
        public ButtonStringProvider(string first, string end, string pre, string next, string go)
        {
            this.first = first;
            this.end = end;
            this.pre = pre;
            this.next = next;
            this.go = go;
        }
        /// <summary>
        /// ��ת��Text
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue("����")]
        [Browsable(true)]
        public string Go
        {
            get
            {
                return this.go;
            }
            set
            {
                this.go = value;
            }
        }
        /// <summary>
        /// ��һҳ��Text
        /// </summary>
        [DefaultValue("��һҳ")]
        [Browsable(true)]
        [NotifyParentProperty(true)]
        public string Next
        {
            get
            {
                return this.next;
            }
            set
            {
                this.next = value;
            }
        }
        /// <summary>
        /// ��һҳ��Text
        /// </summary>
        [DefaultValue("��һҳ")]
        [Browsable(true)]
        [NotifyParentProperty(true)]
        public string Pre
        {
            get
            {
                return this.pre;
            }
            set
            {
                this.pre = value;
            }
        }
        /// <summary>
        /// βҳ��Text
        /// </summary>
        [DefaultValue("βҳ")]
        [Browsable(true)]
        [NotifyParentProperty(true)]
        public string End
        {
            get
            {
                return this.end;
            }
            set
            {
                this.end = value;
            }
        }
        /// <summary>
        /// ��ҳ��Text
        /// </summary>
        [DefaultValue("��ҳ")]
        [Browsable(true)]
        [NotifyParentProperty(true)]
        public string First
        {
            get
            {
                return this.first;
            }
            set
            {
                this.first = value;
            }
        }
    }
    #endregion

    /// <summary>
    /// SimplePager ��ժҪ˵����
    /// </summary>
    [
    ParseChildren(true),
    PersistChildren(false),
    Designer(typeof(SimplePagerDesigner))
    ]
    [ToolboxBitmapAttribute(typeof(SimplePager), "SimplePager.bmp")]
    [DefaultProperty("FormatString"),
    ToolboxData("<{0}:SimplePager  runat=\"server\"></{0}:SimplePager>")]
    public class SimplePager : System.Web.UI.WebControls.WebControl, INamingContainer
    {
        /// <summary>
        /// ��ȡ��Ϣ���������統ǰҳ{0}/{1},�ܼ�¼��{2}
        /// </summary>
        /// <returns>��Ϣ����</returns>
        public string GetDescription()
        {
            return string.Format(this.FormatString, new object[] { this.CurrentPageIndex, this.TotalPages, this.TotalRecordSize });
        }

        /// <summary>
        /// �ṩ����Դ�ķ���
        /// </summary>
        private PagerDataProvider provider;

        /// <summary>
        /// �ṩ����Դ�ķ���
        /// </summary>
        public PagerDataProvider Provider
        {
            get { return provider; }
            set { provider = value; }
        }

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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ButtonStringProvider ButtonStrings
        {
            get
            {
                if (this.buttonStrs == null)
                {
                    this.buttonStrs = new ButtonStringProvider();
                }
                return this.buttonStrs;
            }
        }
        private ButtonStringProvider buttonStrs = new ButtonStringProvider();
        #endregion

        #region �ַ���
        /// <summary>
        /// ��ʽ���ַ��� �������page {0} of {1} all{2]record
        /// </summary>
        private string formatStr = "��ǰҳ{0}/{1},��{2}����¼";

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
                if (this.formatStr.IndexOf("{0}") == -1 || this.formatStr.IndexOf("{1}") == -1 || this.formatStr.IndexOf("{2}") == -1)
                {
                    throw new ArgumentException("��ʽ�ַ����������{0},{1},{2}");

                }
                this.formatStr = value;
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
                this.bindControl = value;
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
                    sender = FindControlExtend(this.bindControl,this.Page.Controls);
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
            base.OnInit(e);
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
                if (ViewState["changed"] == null)
                {
                    ViewState["changed"] = true;

                }
                return Convert.ToBoolean(ViewState["changed"].ToString());

            }
            set
            {
                ViewState["changed"] = value;
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
                if (ViewState["pagesize"] == null)
                {
                    ViewState["pagesize"] = 10;

                }
                int result = Convert.ToInt32(ViewState["pagesize"]);
                if (result < 1)
                {
                    throw new ArgumentException("ҳ�Ĵ�С�������1��");
                }
                return result;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("ҳ�Ĵ�С�������1��");
                }
                ViewState["pagesize"] = value;
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
                if (ViewState["currentpageindex"] == null)
                {
                    ViewState["currentpageindex"] = 1;

                }
                int result = Convert.ToInt32(ViewState["currentpageindex"]);
                if (result < 1)
                {
                    throw new ArgumentException("��ǰҳ����С��1��");
                }
                return result;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("��ǰҳ����С��1��");
                }
                ViewState["currentpageindex"] = value;
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
                if (ViewState["totalrecordsize"] == null)
                {
                    ViewState["totalrecordsize"] = 0;

                }
                int result = Convert.ToInt32(ViewState["totalrecordsize"]);
                if (result < 0)
                {
                    throw new ArgumentException("��¼������С��0��");
                }
                return result;
            }
            set
            {
                ViewState["totalrecordsize"] = value;
            }

        }
        #endregion

        /// <summary>
        /// ��д��Render����
        /// </summary>
        /// <param name="writer">�����</param>
        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
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
            return base.OnBubbleEvent(source, args);
        }

        /// <summary>
        /// ע��ؼ�Ϊ��Ҫ�ش����¼�
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (this.Changed)
                this.BindData();
            if (this.TotalRecordSize == 0)
            {
                return;
            }
            base.OnPreRender(e);
            //Page.RegisterRequiresPostBack(this);

        }

        /// <summary>
        /// ��д�Ĺ��캯��
        /// </summary>
        protected override void CreateChildControls()
        {
            //base.CreateChildControls ();
            Controls.Clear();
            this.lbFirst = new LinkButton();
            this.lbFirst.ID = "lbFirst";
            lbFirst.Text = this.ButtonStrings.First;
            this.lbFirst.Click += new EventHandler(lbFirst_Click);
            this.Controls.Add(this.lbFirst);

            this.lbPre = new LinkButton();
            this.lbPre.ID = "lbPre";
            this.lbPre.Text = this.ButtonStrings.Pre;
            this.lbPre.Click += new EventHandler(lbPre_Click);
            this.Controls.Add(this.lbPre);

            this.lbNext = new LinkButton();
            this.lbNext.ID = "lbNext";
            this.lbNext.Text = this.ButtonStrings.Next;
            this.lbNext.Click += new EventHandler(lbNext_Click);
            this.Controls.Add(this.lbNext);

            this.lbEnd = new LinkButton();
            this.lbEnd.ID = "lbEnd";
            this.lbEnd.Text = this.ButtonStrings.End;
            this.lbEnd.Click += new EventHandler(lbEnd_Click);
            this.Controls.Add(this.lbEnd);

            this.tbNum = new TextBox();
            this.tbNum.ID = "tbNum";
            this.tbNum.Width = 30;
            this.tbNum.Style.Add("border", "solid 1px black;");
            this.tbNum.Text = this.CurrentPageIndex.ToString();
            this.Controls.Add(this.tbNum);

            this.lbGo = new LinkButton();
            this.lbGo.ID = "lbGo";
            this.lbGo.Text = this.ButtonStrings.Go;
            this.lbGo.Click += new EventHandler(lbGo_Click);
            this.Controls.Add(this.lbGo);
            //this.BindedControl.DataBinding+=new EventHandler(BindControl_DataBinding);



        }

        /// <summary>
        /// Ĭ�Ϲ��캯��
        /// </summary>
        public SimplePager()
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
                return (this.CurrentPageIndex - 1) * this.PageSize;
            }
        }

        /// <summary>
        /// �Ƿ��������ݰ�
        /// </summary>
        [Browsable(true)]
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

                int t = (this.CurrentPageIndex) * this.PageSize - 1;
                return t < this.TotalRecordSize ? t + 1 : this.TotalRecordSize;
            }
        }

        /// <summary>
        /// �ܵ�ҳ��
        /// </summary>
        private int TotalPages
        {
            get
            {
                int temp = this.TotalRecordSize / this.PageSize;
                if (temp == 0)
                    return 1;
                if (this.TotalRecordSize % this.PageSize > 0)
                {
                    temp++;
                }
                return temp;
            }
        }

        /// <summary>
        /// ������Դȡ������ɸѡ����ǰҳ��������
        /// </summary>
        /// <returns>�µ�DataTable</returns>
        private DataTable PreData()
        {
            try
            {
                DataTable dt = this.provider();
                if (dt != null)
                {
                    this.TotalRecordSize = dt.Rows.Count;
                    if (this.TotalPages < this.CurrentPageIndex)
                    {
                        this.CurrentPageIndex--;
                    }
                    Debug.WriteLine("��¼����:" + this.TotalRecordSize);
                    Debug.WriteLine("��ʼ��¼��" + this.StartRow);
                    Debug.WriteLine("������¼��" + this.EndRow);
                    DataTable temp = dt.Clone();
                    for (int i = this.StartRow; i < this.EndRow; i++)
                    {
                        temp.ImportRow(dt.Rows[i]);
                    }
                    return temp;
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
            catch (Exception ex)
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
                int newIndex = Convert.ToInt32(this.tbNum.Text);
                if (newIndex >= 1 && newIndex <= this.TotalPages)
                {
                    this.CurrentPageIndex = newIndex;
                    this.Changed = true;
                    this.BindData();
                }
                else
                {
                    this.tbNum.Text = this.CurrentPageIndex.ToString();
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
            this.CurrentPageIndex = this.TotalPages;
            this.Changed = true;
            this.BindData();
        }

        /// <summary>
        /// �����һҳ�İ�ť�¼�
        /// </summary>
        /// <param name="sender">��һҳ��ť</param>
        /// <param name="e">�¼�����</param>
        private void lbNext_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPages)
                this.CurrentPageIndex++;
            this.Changed = true;
            this.BindData();
        }

        /// <summary>
        /// ���ǰһҳ�İ�ť�¼�
        /// </summary>
        /// <param name="sender">ǰһҳ��ť</param>
        /// <param name="e">�¼�����</param>
        private void lbPre_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
                this.CurrentPageIndex--;
            this.Changed = true;
            this.BindData();
        }

        /// <summary>
        /// �����ҳ�������¼�
        /// </summary>
        /// <param name="sender">��ҳ��ť</param>
        /// <param name="e">�¼�����</param>
        private void lbFirst_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = 1;
            this.Changed = true;
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
            else if (this.Changed)
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
                    if (this.TotalPages == 1)
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
                    this.Changed = false;


                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    throw ex;
                    //throw new ArgumentException("���ṩһ������ת��Ϊdataview������Դ��");
                }
            }
        }
    }
}
