using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.Data;
using System.Reflection;

namespace WebControls
{
    public class CommonPager:System.Web.UI.WebControls.WebControl
    {

        private string _bindcontrol;
        private ITemplate _layout;
        private int _results;
        private int _resultsperpage;
        private Style SelectedPager;
        private Style UnselectedPager;
        private AdapterCollection _adapters;
        private bool _isdatasensitive;
        private Control _boundcontrol;
        private LayoutContainer _container;
        private ImageButton Next;
        private ImageButton First;
        private ImageButton Last;
        private ImageButton Previous;
        private Panel Holder;

        private int StartRow;

        private PropertyInfo _datasource;

        private AdapterBuilder _builder;

        

        public Style SelectedPagerStyle
        {
            get
            {
                return SelectedPager;
            }
            set
            {
                SelectedPager = value;
            }
        }

        public Style UnSelectedPagerStyle
        {
            get
            {
                return UnselectedPager;
            }
            set
            {
                UnselectedPager = value;
            }
        }
        public Control BoundControl
        {
            get
            {
                return _boundcontrol;
            }
        }
        public string BindToControl
        {
            get
            {
                if (_bindcontrol == null)
                    throw new NullReferenceException("在使用分页控件之前，请先通过设置BindToControl属性绑定到一个控件。");
                return _bindcontrol;
            }
            set { _bindcontrol = value; }
        }

        [TemplateContainer(typeof(LayoutContainer))]
        public ITemplate Layout
        {
            get { return (_layout == null) ? new DefaultPagerLayout() : _layout; }
            set { _layout = value; }
        }

        public int CurrentPage
        {
            get
            {
                string cur = (string)ViewState["CurrentPage"];
                return (cur == string.Empty || cur == null) ? 1 : int.Parse(cur);
            }
            set
            {
                ViewState["CurrentPage"] = value.ToString();
            }
        }

        public int PagersToShow
        {
            get { return _results; }
            set { _results = value; }
        }

        public int ResultsToShow
        {
            get { return _resultsperpage; }
            set { _resultsperpage = value; }
        }
        private int PagerSequence
        {
            get
            {
                return Convert.ToInt32
                (Math.Ceiling((double)CurrentPage / (double)PagersToShow));
            }
        }

        private int NumberOfPagersToGenerate
        {
            get { return PagerSequence * PagersToShow; }
        }

        private int TotalPagesToShow
        {
            get { return Convert.ToInt32(Math.Ceiling((double)TotalResults / (double)_resultsperpage)); }
        }
        public int TotalResults
        {
            get { return _builder.Adapter.TotalCount; }
        }

        private void GeneratePagers(WebControl control)
        {
            control.Controls.Clear();
            int pager = (PagerSequence - 1) * PagersToShow + 1;

            for (; pager <= NumberOfPagersToGenerate && pager <= TotalPagesToShow; pager++)
            {
                LinkButton link = new LinkButton();
                link.Text = pager.ToString();
                link.ID = pager.ToString();
                link.Click += new EventHandler(this.Pager_Click);
                if (link.ID.Equals(CurrentPage.ToString()))
                    link.MergeStyle(SelectedPagerStyle);
                else
                    link.MergeStyle(UnSelectedPagerStyle);

                control.Controls.Add(link);
                control.Controls.Add(new LiteralControl(" "));
            }
        }

        private void GeneratePagers()
        {
            GeneratePagers(Holder);
        }

        private void Pager_Click(object sender, System.EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            CurrentPage = int.Parse(button.ID);
            RaiseEvent(PageChanged, this, new PageChangedEventArgs(CurrentPage, PagedEventInvoker.Pager));
            Update();
        }

        private void Next_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (CurrentPage < TotalPagesToShow)
                CurrentPage++;
            RaiseEvent(PageChanged, this, new PageChangedEventArgs(CurrentPage, PagedEventInvoker.Next));
            Update();
        }

        private void Previous_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            if (CurrentPage > 1)
                CurrentPage--;
            RaiseEvent(PageChanged, this, new PageChangedEventArgs(CurrentPage, PagedEventInvoker.Previous));
            Update();
        }
        private void First_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            CurrentPage = 1;
            RaiseEvent(PageChanged, this, new PageChangedEventArgs(CurrentPage, PagedEventInvoker.First));
            Update();
        }

        private void Last_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            CurrentPage = TotalPagesToShow;
            RaiseEvent(PageChanged, this, new PageChangedEventArgs(CurrentPage, PagedEventInvoker.Last));
            Update();
        }

        private void Update()
        {
            if (!HasParentControlCalledDataBinding) return;
            ApplyDataSensitivityRules();
            BindParent();
            BoundControl.DataBind();
        }

        public bool IsDataSensitive
        {
            get { return _isdatasensitive; }
            set { _isdatasensitive = value; }
        }

        private bool IsPagerVisible
        {
            get { return (TotalPagesToShow != 1) && IsDataSensitive; }
        }

        private bool IsPreviousVisible
        {
            get
            {
                return (!IsDataSensitive) ? true :
                (CurrentPage != 1);
            }
        }

        private bool IsNextVisible
        {
            get
            {
                return (!IsDataSensitive) ? true :
                (CurrentPage != TotalPagesToShow);
            }
        }

        private void ApplyDataSensitivityRules()
        {
            FirstButton.Visible = IsPreviousVisible;
            PreviousButton.Visible = IsPreviousVisible;
            LastButton.Visible = IsNextVisible;
            NextButton.Visible = IsNextVisible;
            if (IsPagerVisible) GeneratePagers();
        }





        protected override void OnInit(EventArgs e)
        {
            _boundcontrol = Parent.FindControl(BindToControl);
            BoundControl.DataBinding += new EventHandler(BoundControl_DataBound);
            InstantiateTemplate();
            Controls.Add(_container);
            base.OnInit(e);

        }

        private void InstantiateTemplate()
        {
            _container = new LayoutContainer();
            Layout.InstantiateIn(_container);
            First = (ImageButton)_container.FindControl("First");
            Previous = (ImageButton)_container.FindControl("Previous");
            Next = (ImageButton)_container.FindControl("Next");
            Last = (ImageButton)_container.FindControl("Last");
            Holder = (Panel)_container.FindControl("Pager");
            this.First.Click += new System.Web.UI.ImageClickEventHandler(this.First_Click);
            this.Last.Click += new System.Web.UI.ImageClickEventHandler(this.Last_Click);
            this.Next.Click += new System.Web.UI.ImageClickEventHandler(this.Next_Click);
            this.Previous.Click += new System.Web.UI.ImageClickEventHandler(this.Previous_Click);
        }
        private void BindParent()
        {
            _datasource.GetSetMethod().Invoke(BoundControl,
            new object[] { _builder.Adapter.GetPagedData(StartRow, ResultsToShow * CurrentPage) });
        }

        public ImageButton FirstButton { get { return First; } }
        public ImageButton LastButton { get { return Last; } }
        public ImageButton PreviousButton { get { return Previous; } }
        public ImageButton NextButton { get { return Next; } }



        private void BoundControl_DataBound(object sender, System.EventArgs e)
        {
            if (HasParentControlCalledDataBinding) return;
            Type type = sender.GetType();
            _datasource = type.GetProperty("DataSource");
            if (_datasource == null)
                throw new NotSupportedException("分页控件要求表现控件必需包含一个DataSource。");
            object data = _datasource.GetGetMethod().Invoke(sender, null);
            _builder = Adapters[data.GetType()];
            if (_builder == null)
                throw new NullReferenceException("没有安装适当的适配器来处理下面的数据源类型：" + data.GetType());
            _builder.Source = data;

            ApplyDataSensitivityRules();
            BindParent();
            RaiseEvent(DataUpdate, this);
        }


        public AdapterCollection Adapters
        {
            get { return _adapters; }
        }

        private bool HasParentControlCalledDataBinding
        {
            get { return _builder != null; }
        }


        //BoundControl_DataBound方法利用HasParentControlCalledDataBinding检查是否已经创建了Builder，

        //如果是，则不再执行寻找适当Builder的操作。Adapters表的初始化在构造函数中完成： 

        public CommonPager()
        {
            SelectedPager = new System.Web.UI.WebControls.Style();
            UnselectedPager = new System.Web.UI.WebControls.Style();
            _adapters = new AdapterCollection();
            _adapters.Add(typeof(DataTable), new DataTableAdapterBuilder());
            _adapters.Add(typeof(DataView), new DataViewAdapterBuilder());
        }

        public event PageDelegate PageChanged;
        public event EventHandler DataUpdate;

        private void RaiseEvent(EventHandler e, object sender)
        {
            this.RaiseEvent(e, this, null);
        }

        private void RaiseEvent(EventHandler e, object sender, PageChangedEventArgs args)
        {
            if (e != null)
            {
                e(sender, args);
            }
        }
        private void RaiseEvent(PageDelegate e, object sender)
        {
            this.RaiseEvent(e, this, null);
        }

        private void RaiseEvent(PageDelegate e, object sender, PageChangedEventArgs args)
        {
            if (e != null)
            {
                e(sender, args);
            }
        }



    }
    public delegate void PageDelegate(object sender, PageChangedEventArgs e);

    public enum PagedEventInvoker { Next, Previous, First, Last, Pager }

    public class PageChangedEventArgs : EventArgs
    {
        private int newpage;
        private Enum invoker;

        public PageChangedEventArgs(int newpage)
            : base()
        {
            this.newpage = newpage;
        }
        public PageChangedEventArgs(int newpage, PagedEventInvoker invoker)
        {
            this.newpage = newpage;
            this.invoker = invoker;
        }
        public int NewPage { get { return newpage; } }
        public Enum EventInvoker { get { return invoker; } }
    }
}
