using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.UI;


namespace WebControls
{
    //public class PageToolsDesigner : System.ComponentModel.
    //{
    //    override  
        
    //}
   // [ToolboxItemFilter("System.Web.UI",ToolboxItemFilterType.Require),Designer(typeof(WebControls.PageToolsDesigner))]
     partial  class PageTools : Component
    {
        private Page _page;

        [Browsable(true)]
        [DefaultValue(null)]
        public Page OwnerPage
        {
            get
            {
                return this._page;
            }
            set
            {
                this._page = value;
            }
        }
        public PageTools()
        {
            InitializeComponent();
        }

        public PageTools(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
