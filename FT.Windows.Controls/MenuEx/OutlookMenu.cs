/********************************************************************************
* File:OutlookMenu.cs
* Author:austin chen
* Date:2008-4-10
* Copyright (c) fivemen company
*********************************************************************************/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Reflection;

namespace FT.Windows.Controls.MenuEx
{
    ///<summary>
    ///Class <c>OutlookMenu</c>
    ///Description:
    ///</summary>
    public class OutlookMenu : Panel
    {
        protected VScrollBar scroll;
        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookMenu"/> class.
        /// </summary>
        public OutlookMenu()
        {
            scroll = new VScrollBar();
            scroll.Visible = false;
            this.scroll.Scroll += new ScrollEventHandler(scroll_Scroll);
            this.Controls.Add(scroll);
          // selectedColor = this.BackColor;
           // this.Dock = DockStyle.Fill;
            
        }

        private int selectedIndex=-1;

        /// <summary>
        /// Gets or sets the index of the selected.
        /// </summary>
        /// <value>The index of the selected.</value>
        public int SelectedIndex
        {
            get 
            {
                return selectedIndex; 
            }
            set
            {
                Console.WriteLine("set the selectedIndex "+value);
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("coundn't set the selectedIndex < 0!");
                }
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    Redraw();
                }
                
            
            }
        }

       // private Color selectedColor ;


        private int bandHeight = 20;

        /// <summary>
        /// Gets or sets the height of the band.
        /// </summary>
        /// <value>The height of the band.</value>
        public int BandHeight
        {
            get { return bandHeight; }
            set { bandHeight = value; }
        }

        

        /// <summary>
        /// Redraws this instance.
        /// </summary>
        private void Redraw()
        {
           // this.Margin = new Padding(2);
            int pad = 2;
            MenuBand band = null;
            //设置宽度同步
            this.Width = this.Parent.Width;
            //这个是菜单项所拥有的高度
            int selectedBandHeight = this.Parent.Height - (this.Bands.Count * (BandHeight+pad));
            Console.WriteLine("the outlookmenu width "+this.Size.Width+" height "+this.Size.Height);
            for (int i = 0; i < this.Bands.Count; i++)
            {
                //这个是band后一个band的垂直定位
               int vPos = (i <= SelectedIndex) ? BandHeight * i : BandHeight * i + selectedBandHeight;
                //这个是
                //int height = SelectedIndex == i ? selectedBandHeight + BandHeight : BandHeight*i;
               // Console.WriteLine("vPos "+vPos+" height "+height);
                band = this.bands[i];
               // band.BackColor = this.SelectedColor;
                if (i == this.SelectedIndex)
                {
                    
                    band.Location = new Point(0, BandHeight * i);
                    band.Size = new Size(this.Size.Width, selectedBandHeight+this.bandHeight+pad);
                    Console.WriteLine("the band " + band.Caption + " x " + band.Location.X + " y " + band.Location.Y);
                    band.BorderStyle = BorderStyle.FixedSingle;         
                    band.Redraw();
                    Console.WriteLine("band.needHeight="+band.NeedHeight+",band.size.height="+band.Height);
                    if (band.NeedHeight > band.Height)
                    {
                        this.scroll.Location = new Point(this.Width - 2);
                        this.scroll.Maximum = band.NeedHeight - band.Height + band.Margin;
                        this.scroll.Dock = DockStyle.Right;
                        this.scroll.Visible = true;
                        this.scroll.Value = 0;
                            
                    }
                    else
                    {
                        this.scroll.Visible = false;
                    }
                   // band.AutoScroll = true;
                }
                else
                {
                   // band.BackColor = this.BackColor;
                    band.Location = new Point(0, vPos);
                    band.Size = new Size(this.Size.Width, this.bandHeight+pad);
                    Console.WriteLine("the band " + band.Caption + " x " + band.Location.X + " y " + band.Location.Y);
                   // band.BorderStyle = BorderStyle.FixedSingle;
                    band.RedrawHeader();
                }
                
                this.Controls.Add(band);
                
               
            }
        }

        void scroll_Scroll(object sender, ScrollEventArgs e)
        {
            Console.WriteLine("execute scroll event!");
            //this.Bands[this.SelectedIndex].
            for (int i = 1; i < this.Bands[this.SelectedIndex].Controls.Count; i++)
            {
                int x = this.Bands[this.SelectedIndex].Controls[i].Location.X;
                int y = this.Bands[this.SelectedIndex].Controls[i].Location.Y-e.NewValue+e.OldValue;
                this.Bands[this.SelectedIndex].Controls[i].Location = new Point(x,y); ;
            }
            //throw new Exception("The method or operation is not implemented.");
        }
        public void Initialize()
        {
            // parent must exist!
            Parent.SizeChanged += new EventHandler(SizeChangedEvent);
        }

        private void SizeChangedEvent(object sender, EventArgs e)
        {
            //Size = new Size(Size.Width, ((Control)sender).ClientRectangle.Size.Height);
            Console.WriteLine("parent size changed!");
            Redraw();
        }

        protected MenuBands bands;
        /// <summary>
        /// Gets or sets the bands.
        /// </summary>
        /// <value>The bands.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MenuBands Bands
        {
            get 
            {
                return bands; 
            }
            set
            {
                this.bands = value;
            }
        }

    }

    #region MenuBands Finish
    ///<summary>
    ///Class <c>MenuBands</c>
    ///Description:第一次菜单集合
    ///</summary>
    public class MenuBands : CollectionBase
    {

       

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuBands"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public MenuBands()
            : base()
        {
            
        }

        /// <summary>
        /// Gets the <see cref="Fm.Common.Controls.MenuBand"/> at the specified index.
        /// </summary>
        /// <value></value>
        public MenuBand this[int index]
        {
            get { return (MenuBand)List[index]; }
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(MenuBand item)
        {
            List.Add(item);
          //  item.Parent = this.Parent;
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Remove(MenuBand item)
        {
            List.Remove(item);
        }

        /// <summary>
        /// 确定 <see cref="T:System.Collections.IList"></see> 中特定项的索引。
        /// </summary>
        /// <param name="value">要在 <see cref="T:System.Collections.IList"></see> 中查找的 <see cref="T:System.Object"></see>。</param>
        /// <returns>如果在列表中找到，则为 value 的索引；否则为 -1。</returns>
        public int IndexOf(object value)
        {
            return List.IndexOf(value);
        }
    }
    #endregion

    #region MenuInfo Finish
    ///<summary>
    ///Class <c>MenuInfo</c>
    ///Description:菜单领域对象
    ///</summary>
    public class MenuInfo
    {
        private string right;

        /// <summary>
        /// 权限字段，包括add ,delete,modify,print,search
        /// </summary>
        public string Right
        {
            get { return right; }
            set { right = value; }
        }

        /// <summary>
        /// 图片对象
        /// </summary>
        private Image image;

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }
       /// <summary>
        /// 显示文本
       /// </summary>
       

        private string showText;

        /// <summary>
        /// Gets or sets the show text.
        /// </summary>
        /// <value>The show text.</value>
        public string ShowText
        {
            get { return showText; }
            set { showText = value; }
        }
        //应该执行的方法
        private string methodName;

        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        /// <value>The name of the method.</value>
        public string MethodName
        {
            get { return methodName; }
            set { methodName = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuInfo"/> class.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="text">The text.</param>
        /// <param name="method">The method.</param>
        public MenuInfo(Image image, string text, string method,string right)
        {
            this.Image = image;
            this.ShowText = text;
            this.MethodName = method;
            this.Right = right;
        }

    }
    #endregion

    #region PicMenuItem Finish
    ///<summary>
    ///
    ///类描述:
    ///       真正的菜单对象
    ///</summary>
    public class PicMenuItem : Panel
    {

        private PictureBox pic;

        private Label lb;

        private bool mouseEnter;

        public PicMenuItem(MenuInfo info)
        {
            pic = new PictureBox();
            pic.Image = info.Image;
            // pic.Location =
            //  pic.Size = info.Image.Size;
            pic.MouseMove += new MouseEventHandler(OnMouseMove);
            pic.MouseLeave += new EventHandler(OnMouseLeave);
            lb = new Label();
            lb.Text = info.ShowText;
            this.Height = pic.Image.Height + lb.Height+1;
            pic.Click += new EventHandler(pic_Click);
            pic.Tag = info;
           
           // lb.BorderStyle = BorderStyle.FixedSingle;
            //Console.WriteLine("the PicMenuItem "+info.ShowText);
           // Console.WriteLine("image height:"+pic.Image.Height+"image width:"+pic.Image.Width);
           // Console.WriteLine("the pic location x:" + pic.Location.X);
           // Console.WriteLine("the pic location y:" + pic.Location.Y);
          //  Console.WriteLine("the lb location x:" + lb.Location.X);
           // Console.WriteLine("the lb location y:" + lb.Location.Y);
           // this.BackColor = Color.Red;
           // this.BorderStyle = BorderStyle.FixedSingle;
            this.ResetLocation();
            this.Controls.Add(pic);
            this.Controls.Add(lb);
        }

        public void ResetLocation()
        {
            pic.Location = new Point((this.Size.Width - pic.Image.Size.Width) / 2, 1);
            pic.Size = new Size(pic.Image.Width, pic.Image.Height);
            lb.Location = new Point(0, pic.Image.Size.Height + 1);
            lb.Width = this.Width;
            lb.TextAlign = ContentAlignment.MiddleCenter;
        }

        internal static void pic_Click(object sender, EventArgs e)
        {
           
            PictureBox pic = sender as PictureBox;
           // MessageBox.Show(pic.Tag.ToString());
           // MessageBox.Show(.Text);
            Form f=pic.FindForm();
            if(f!=null)
            {
                Type t = f.GetType();
                MenuInfo info=pic.Tag as MenuInfo;
                try
                {
                    t.InvokeMember(info.MethodName, BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, f, new object[] { info.Right });
                }
                catch (MissingMethodException ex)
                {
                    //MessageBoxHelper.Show("找不到方法"+info.MethodName);
                    
                }
            }
            //Console.WriteLine("click the menuItem!"+tmp.Text);
            //throw new Exception("The method or operation is not implemented.");
        }

        private void OnMouseMove(object sender, MouseEventArgs args)
        {
            PictureBox pic = sender as PictureBox;
            if ((args.X < pic.Size.Width - 2) &&
                (args.Y < pic.Size.Width - 2) &&
                (!mouseEnter))
            {
                pic.BackColor = Color.LightCyan;
                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Location = pic.Location - new Size(1, 1);
                mouseEnter = true;
            }
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (mouseEnter)
            {
                pic.BackColor = this.BackColor;
                pic.BorderStyle = BorderStyle.None;
                pic.Location = pic.Location + new Size(1, 1);
                mouseEnter = false;
            }
        }





    }
    #endregion

    #region MenuBand Finish
    ///<summary>
    ///Class <c>MenuBand</c>
    ///Description:第一层菜单
    ///</summary>
    public class MenuBand : Panel
    {

        protected OutlookMenu parent;

        protected PicMenuItems items;


        /// <summary>
        /// Gets the height of the need.
        /// </summary>
        /// <value>The height of the need.</value>
        public int NeedHeight
        {
            get
            {
                Control ctl=this.Controls[this.Controls.Count - 1];
                return ctl.Location.Y+ctl.Height;
            }
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PicMenuItems Items
        {
            get { return items; }
            set
            {
                this.items = value;
            }
        }

        protected int iconSpacing=57;
		protected int margin=0;

        private int index;

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>The index.</value>
        protected int Index
        {
            get { return index; }
            set { index = value; }
        }

        private string caption;

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        /// <summary>
        /// Gets or sets the icon spacing.
        /// </summary>
        /// <value>The icon spacing.</value>
		public int IconSpacing
		{
			get
			{
				return iconSpacing;
			}
            set
            {
                this.iconSpacing = value;
            }
		}

        /// <summary>
        /// 获取或设置控件之间的空间。
        /// </summary>
        /// <value></value>
        /// <returns>表示控件之间的间距的 <see cref="T:System.Windows.Forms.Padding"></see>。</returns>
		public new int Margin
		{
			get
			{
				return margin;
			}
            set
            {
                this.margin = value;
            }
		}

        public void RedrawHeader()
        {
            Console.WriteLine("begin redrawHeader");
            this.Width = this.parent.Size.Width;
            this.Controls.Clear();
            Button btn = new Button();
            btn.Location = new Point(0, 0);
            btn.Text = this.caption;
            btn.Width = this.Size.Width;
            btn.Tag = this.Index;
            btn.Click += new EventHandler(btn_Click);
           
            this.Controls.Add(btn);
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn=(Button)sender;
            OutlookMenu menu = btn.Parent.Parent as OutlookMenu;
            if (menu != null)
            {
                
                menu.SelectedIndex = int.Parse(btn.Tag.ToString());
               
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        public void Redraw()
        {
            this.RedrawHeader();
            if (this.Items != null)
            {
                PicMenuItem item = null;
                int nowY = this.Controls[0].Height;
                for (int i = 0; i < items.Count; i++)
                {
                    item = items[i];
                    item.Location = new Point(0, nowY);
                    nowY += item.Size.Height + margin;
                    item.BackColor = this.BackColor;
                    item.Width = this.Width;
                    item.ResetLocation();
                    this.Controls.Add(item);
                   
                }
               
            }
        }
       
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuBand"/> class.
        /// </summary>
        public MenuBand(string caption, int index,OutlookMenu menu)
		{
            
			BackColor=Color.LightBlue;
			AutoScroll=false;
            this.Caption = caption;
            this.index = index;
            this.parent = menu;
           
            
		}

    }
    #endregion

    #region PicMenuItems Finish
    ///<summary>
    ///Class <c>PicMenuItems</c>
    ///Description:第二层菜单项集合对象
    ///</summary>
    public class PicMenuItems : CollectionBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItems"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public PicMenuItems()
            : base()
        {
            
        }

        /// <summary>
        /// Gets the <see cref="Fm.Common.Controls.MenuItem"/> at the specified index.
        /// </summary>
        /// <value></value>
        public PicMenuItem this[int index]
        {
            get { return (PicMenuItem)List[index]; }
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(PicMenuItem item)
        {
            List.Add(item);
           // item.Location = new Point();
        }



        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Remove(PicMenuItem item)
        {
            List.Remove(item);
        }

        /// <summary>
        /// 确定 <see cref="T:System.Collections.IList"></see> 中特定项的索引。
        /// </summary>
        /// <param name="value">要在 <see cref="T:System.Collections.IList"></see> 中查找的 <see cref="T:System.Object"></see>。</param>
        /// <returns>如果在列表中找到，则为 value 的索引；否则为 -1。</returns>
        public int IndexOf(object value)
        {
            return List.IndexOf(value);
        }
    }
    #endregion

}