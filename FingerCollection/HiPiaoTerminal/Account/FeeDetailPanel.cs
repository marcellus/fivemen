using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using HiPiaoInterface;

namespace HiPiaoTerminal.Account
{
    public partial class FeeDetailPanel : UserControl
    {
        public FeeDetailPanel()
        {
            InitializeComponent();
            
        }

        private void SetNextButton(bool flag)
        {
            if (flag)
            {
                this.btnNextPage.BackgroundImage = Properties.Resources.Account_NextPage_Active;
            }
            else
            {
                this.btnNextPage.BackgroundImage = Properties.Resources.Account_NextPage_NotActive;
            }

        }

        private void SetPreButton(bool flag)
        {
            if (flag)
            {
                this.btnPrePage.BackgroundImage = Properties.Resources.Account_PrePage_Active;
            }
            else
            {
                this.btnPrePage.BackgroundImage = Properties.Resources.Account_PrePage_NotActive;
            }

        }

        private List<BuyRecordObject> lists=new List<BuyRecordObject>();

        public void SetBuyLists(List<BuyRecordObject> buys)
        {
            this.lists = buys;
            this.currentIndex = 0;
            int row = 0;
            if (lists.Count > 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    this.SetRow(i + 1, this.lists[i],i);
                }
            }
            else
            {
                for (int i = 0; i < this.lists.Count; i++)
                {
                    this.SetRow(i + 1, this.lists[i],i);
                    row++;
                }
                for (int i = row; i <= 6; i++)
                {
                    this.SetRow(i, null,-1);
                }
            }
            this.lbFeeDetailHeader.Text = string.Format("消费详情 （{0}）", buys.Count.ToString());

            SetPageButton();
        }

        private int currentIndex = 0;

        private void SetPageButton()
        {
            if (currentIndex - 6 >= 0)
            {
                this.SetPreButton(true);
            }
            else
            {
                this.SetPreButton(false);
            }
            if (currentIndex + 6 < this.lists.Count)
            {
                this.SetNextButton(true);
            }
            else
            {
                this.SetNextButton(false);
            }
        }

        private void btnPrePage_Click(object sender, EventArgs e)
        {

            if (currentIndex ==0)
            {
                return;
            }
            currentIndex = currentIndex - 6;
            int row = 0;
            for (int i = currentIndex; i < lists.Count; i++)
            {
                this.SetRow(row + 1, this.lists[i],i);
                row++;
                if (row == 6)
                {
                    break;
                }
            }
            
            SetPageButton();
        }

       

        private void SetRow(int row,BuyRecordObject record,int listIndex)
        {
            Console.WriteLine(string.Format("row:{0},listIndex{1}",row,listIndex));
            if (row < 1 || row > 6)
            {
                return;
            }
            Label lb1 = this.Controls["panelRow"+row.ToString()+"Col1"].Controls["lbRow" + row.ToString() + "Col1"] as Label;
            Label lb2 = this.Controls["panelRow" + row.ToString() + "Col2"].Controls["lbRow" + row.ToString() + "Col2"] as Label;
            Label lb3 = this.Controls["panelRow" + row.ToString() + "Col2"].Controls["lbRow" + row.ToString() + "Col3"] as Label;
            Label lb4 = this.Controls["panelRow" + row.ToString() + "Col3"].Controls["lbRow" + row.ToString() + "Col4"] as Label;
            if (record != null&&lb1!=null)
            {
                lb1.Text =  record.BuyTime.ToString("yyyy-MM-dd HH:mm");
                //listIndex.ToString() + "-"+
                lb2.Text = string.Format("《{0}》 {1} 张 {2}元/张",record.Tickets[0].Movie.Name,record.Tickets.Count.ToString(),record.Tickets[0].Price.ToString());
                lb3.Text = record.Tickets[0].Seat.Room.Name+"-"+record.Tickets[0].Seat.Room.Cinema.Name + "-" ;
                lb4.Text = record.TotalPrice.ToString();

            }
            else
            {
                lb1.Text = lb2.Text = lb3.Text = lb4.Text = string.Empty;
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentIndex + 6 > this.lists.Count)
            {
                return;
            }
            int row = 0;
            currentIndex += 6;
            for (int i = currentIndex; i < lists.Count; i++)
            {
                this.SetRow(++row, this.lists[i],i);
                if (row == 6)
                {
                    //currentIndex = i - 6;
                    break;
                }

            }
            if (row != 6)
            {
                //currentIndex = this.lists.Count - row;
                this.SetNextButton(false);

                for (int i = ++row; i <= 6; i++)
                {
                    this.SetRow(i, null, -1);
                }

            }
           
            SetPageButton();
        }
    }
}
