using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace WebControls
{
    

    public class LayoutContainer:Control,INamingContainer
    {
        public LayoutContainer()
        {this.ID = "Page";}
    }

    public class DefaultPagerLayout : ITemplate
    {
        private ImageButton Next;
        private ImageButton First;
        private ImageButton Last;
        private ImageButton Previous;
        private Panel Pager;

        public DefaultPagerLayout()
        {
            Next = new ImageButton();
            First = new ImageButton();
            Last = new ImageButton();
            Previous = new ImageButton();
            Pager = new Panel();

            Next.ID = "Next"; Next.AlternateText = "下一页"; Next.ImageUrl = "play2.gif";
            First.ID = "First"; First.AlternateText = "首页"; First.ImageUrl = "play2L_dis.gif";
            Last.ID = "Last"; Last.AlternateText = "末页"; Last.ImageUrl = "play2_dis.gif";
            Previous.ID = "Previous"; Previous.AlternateText = "上一页"; Previous.ImageUrl = "play2L.gif";
            Pager.ID = "Pager";
        }
        public void InstantiateIn(Control control)
        {
            control.Controls.Clear();
            Table table = new Table();
            table.BorderWidth = Unit.Pixel(0);
            table.CellSpacing = 1;
            table.CellPadding = 0;
            TableRow row = new TableRow();
            row.VerticalAlign = VerticalAlign.Top;
            table.Rows.Add(row);
            TableCell cell = new TableCell();
            cell.HorizontalAlign = HorizontalAlign.Right;
            cell.VerticalAlign = VerticalAlign.Middle;
            cell.Controls.Add(First);
            cell.Controls.Add(Previous);
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.HorizontalAlign = HorizontalAlign.Center;
            cell.Controls.Add(Pager);
            row.Cells.Add(cell);
            cell = new TableCell();
            cell.VerticalAlign = VerticalAlign.Middle;
            cell.Controls.Add(Next);
            cell.Controls.Add(Last);
            row.Cells.Add(cell);

            control.Controls.Add(table);
        }
    }


}
