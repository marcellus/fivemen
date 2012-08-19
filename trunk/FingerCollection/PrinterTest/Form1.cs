using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using FT.Windows.ExternalTool.DevTools;
using HiPiaoInterface;

namespace PrinterTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEspon532PrinterTest_Click(object sender, EventArgs e)
        {
           
           Form form=new  Epson532SerialPrinterTest();
           // Form form = new ShowColorForm();
           form.ShowDialog();
        }

        private void btnWindowPrinterTest_Click(object sender, EventArgs e)
        {
            Form form = new WindowPrinterTest();
            form.ShowDialog();
        }

        private void btnTemplatePrinterTest_Click(object sender, EventArgs e)
        {
            Form form = new TemplatePrinterTestForm();
            form.ShowDialog();
        }

        private void btnLPT_Click(object sender, EventArgs e)
        {
            Form form = new EpsonParallelPrinterTest();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalHardwareTools.OpenHotPrinter();
            TicketPrintObject ticket = new HiPiaoInterface.TicketPrintObject();
            ticket.Seat = "9排5号";
            ticket.MovieName = "超人归来";
            ticket.Cinema = "模拟影院";
            ticket.TicketId = "0000FED001";
            ticket.RoomName = "2号厅";
            ticket.Price = 25;
            ticket.PrintTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ticket.PlayTime = "11:30";
            ticket.PlayDate = System.DateTime.Now.ToString("yyyy.MM.dd");
            //ticket.Movie = new MovieObject();
            GlobalHardwareTools.ticket = ticket;
            GlobalHardwareTools.PrintTicket();
            GlobalHardwareTools.CloseHotPrinter();
        }
    }
}
