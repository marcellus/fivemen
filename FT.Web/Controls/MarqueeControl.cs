using System;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Collections;

namespace WebControls
{
    //LIST-STYLE-TYPE: disc
    /// <summary>
    /// 公告的列表样式
    /// </summary>
    public enum ListStyle
    {
        /// <summary>
        /// 方块
        /// </summary>
        Square,//square
        /// <summary>
        /// 数字
        /// </summary>
        Decimal,//decimal
        /// <summary>
        /// 实心圆
        /// </summary>
        Disc,//disc
        /// <summary>
        /// 空心圆
        /// </summary>
        Circle,//circle
        /// <summary>
        /// 没有任何模式
        /// </summary>
        None,//none
    }
    /// <summary>
    /// 列表浮动样式
    /// </summary>
    public enum FloatStyle
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 右
        /// </summary>
        Right,
        /// <summary>
        /// 左
        /// </summary>
        Left,
    }
    //direction="down";
    /// <summary>
    /// 公告的滚动方向
    /// </summary>
    public enum MarqueeDirection
    {
        /// <summary>
        /// 向下
        /// </summary>
        Down,
        /// <summary>
        /// 向上
        /// </summary>
        Up,
        /// <summary>
        /// 向右
        /// </summary>
        Right,
        /// <summary>
        /// 向左
        /// </summary>
        Left,
    }
    /// <summary>
    /// 超链接目标
    /// </summary>
    public enum LinkTarget
    {
        Blank,
        Parent,
        Self,
        Top,
        Search,
    }
    /// <summary>
    /// 滚动的行为
    /// </summary>
    public enum ScrollBehavior
    {
        /// <summary>
        /// 交替滚动
        /// </summary>
        Alternate,
        /// <summary>
        /// 滚动到底部停止
        /// </summary>
        Slide,
        /// <summary>
        /// 不停滚动
        /// </summary>
        Scroll,
    }
    /// <summary>
    /// MarqueeControls 的摘要说明。
    /// </summary>
    [ToolboxBitmapAttribute(typeof(MarqueeControls), "MarqueeControls.bmp")]
    [DefaultProperty("Text"),
    ToolboxData("<{0}:MarqueeControls runat=server></{0}:MarqueeControls>")]
    public class MarqueeControls : System.Web.UI.WebControls.WebControl
    {

        private String _defaultContent;
        private MarqueeDirection _dir;
        private ListStyle _listStyle;
        private bool _enableLink;
        private string _prehref;
        private LinkTarget _target;
        private int _loop;
        private int _delay;
        private ScrollBehavior _havior;
        private FloatStyle _float;
        [Browsable(true)]
        [Description("列表浮动样式!")]
        [DefaultValue(FloatStyle.None)]
        public FloatStyle Float
        {
            get
            {
                return this._float;
            }
            set
            {
                this._float = value;
            }
        }
        [Browsable(true)]
        [Description("滚动的行为!")]
        [DefaultValue(ScrollBehavior.Scroll)]
        public ScrollBehavior MyHavior
        {
            get
            {
                return this._havior;
            }
            set
            {
                this._havior = value;
            }
        }

        [Browsable(true)]
        [Description("滚动延迟的时间!")]
        [DefaultValue(50)]
        public int Delay
        {
            get
            {
                return this._delay;
            }
            set
            {
                this._delay = value;
            }
        }
        [Browsable(true)]
        [Description("滚动的次数,-1无限循环")]
        [DefaultValue(-1)]
        public int Loop
        {
            get
            {
                return this._loop;
            }
            set
            {
                if (value < -1)
                {
                    throw new ArgumentException("loop参数不得小于-1");
                }
                this._loop = value;
            }
        }
        [Browsable(true)]
        [Description("链接目标")]
        [DefaultValue(LinkTarget.Blank)]
        public LinkTarget Target
        {
            get
            {
                return this._target;
            }
            set
            {
                if (this.EnableLink)
                {
                    this._target = value;
                }
                else
                {
                    throw new ArgumentException("请先设置EnableLink属性为true");
                }
            }
        }
        [Browsable(true)]
        [Description("默认链接前缀")]
        public string PreHref
        {
            get
            {
                return this._prehref;
            }
            set
            {
                this._prehref = value;
            }
        }
        public MarqueeControls()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        [Browsable(true)]
        [Description("是否打开链接")]
        [DefaultValue(false)]
        public bool EnableLink
        {
            get
            {
                return this._enableLink;
            }
            set
            {
                this._enableLink = value;
            }
        }
        /// <summary>
        /// 公告列表的样式
        /// </summary>
        [Browsable(true)]
        [Description("公告列表的样式!")]
        [DefaultValue(ListStyle.Circle)]
        public ListStyle MyStyle
        {
            get
            {
                return this._listStyle;
            }
            set
            {
                this._listStyle = value;
            }
        }
        /// <summary>
        /// 公告滚动的方向
        /// </summary>
        [Browsable(true)]
        [Description("公告滚动的方向!")]
        [DefaultValue(MarqueeDirection.Down)]
        public MarqueeDirection Direction
        {
            get
            {
                return this._dir;
            }
            set
            {
                this._dir = value;
            }
        }
        /// <summary>
        /// 默认没有公告时候显示的内
        /// </summary>
        [Browsable(true)]
        [Description("默认没有公告时候显示的内容!")]
        [DefaultValue("当前没有公告!")]
        public String DefaultContent
        {
            get
            {
                if (this._defaultContent == string.Empty)
                {
                    throw new ArgumentException("必须设置默认公告的内容!");
                }
                return this._defaultContent;
            }
            set
            {
                this._defaultContent = value;
            }
        }

        /// <summary>
        /// 需要显示的公告数组
        /// </summary>
        [Browsable(false)]
        [Description("需要显示的公告数组")]

        public Hashtable Content
        {
            get
            {
                if (ViewState["content"] == null)
                {
                    //ViewState["content"]=this.DefaultContent;
                    //ViewState["content"]=new string[]{this.DefaultContent};
                    return null;
                }
                //string[] array=ViewState["content"].ToString().Split('-');
                Hashtable array = ViewState["content"] as Hashtable;
                return array;
            }
            set
            {
                ViewState["content"] = value;
                //    StringBuilder sb=new StringBuilder();
                //    foreach(string str in value)
                //    {
                //     sb.Append(str+"-");
                //    }
                //    ViewState["content"]=sb.ToString().TrimEnd('-');
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            foreach (string key in this.Style.Keys)
            {
                this.Attributes.Add(key, this.Style[key]);
            }
            base.OnPreRender(e);

        }


        protected override void Render(HtmlTextWriter writer)
        {
            //writer.RenderBeginTag(HtmlTextWriterTag.Div);
            //   foreach(string key  in this.Style.Keys)
            //   {
            //    writer.AddAttribute(key,this.Style[key]);
            //   }
            //writer.Write(string.Format("<div style='width:{0};height:{1}'>",new object[]{this.Width,this.Height}));
            //writer.

            writer.Write(this.FormatContent());
            //writer.RenderEndTag();
            //base.Render (writer);
            //writer.Write("</div>");
        }

        private const string ConstString = "<marquee direction=\"{0}\" behavior=\"{5}\" scrollDelay=\"{3}\" loop=\"{4}\"  onmouseover=\"this.stop();\" onmouseout=\"this.start();\"><ul style=\"LIST-STYLE-TYPE: {1}\">{2}</ul></marquee>";
        private const string LiString = "<li style=\"float:{1}\">{0}</li>";
        private const string LiAndLinkStr = "<li style=\"float:{3}\"><a href='{0}' target='_{1}'>{2}</a></li>";

        private string FormatContent()
        {
            StringBuilder sb = new StringBuilder();
            if (this.Content != null)
            {
                //    for(int i=0;i<this.Content.Count;i++)
                //    {
                //     sb.AppendFormat(LiString,this.Content[i]);
                //    }
                if (this.EnableLink)
                {
                    foreach (DictionaryEntry de in this.Content)
                    {
                        sb.AppendFormat(LiAndLinkStr, new object[] { this.PreHref + de.Key.ToString(), this.Target, de.Value, this.Float });
                        //Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
                    }
                }
                else
                {

                    foreach (DictionaryEntry de in this.Content)
                    {
                        sb.AppendFormat(LiString, new object[] { de.Value, this.Float });

                    }
                }

                return string.Format(ConstString, new object[] { this.Direction, this.MyStyle, sb.ToString(), this.Delay, this.Loop, this.MyHavior });
            }
            else
            {
                return this.DefaultContent;

            }

        }



    }
}