using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;
using FT.Commons.Bar;
using FT.Commons.Print;
using System.Drawing;
using FT.Commons.Cache;
using FT.Windows.Forms.Domain;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using System.Windows.Forms;
using FT.Windows.Forms;
using FT.Commons.Tools;


namespace Vehicle.Plugins
{
    //class 
    public abstract class BaseVehicleInfoPrinter:ObjectPrinter
    {
        protected static  string[] allowCars=new string[]{"A1","A2","A3","B1","B2","C1","C2","C3","C4","D","E","F","M","N","P"};
        private VehicleInfo vehicle;

        public VehicleInfo Vehicle
        {
          get { return vehicle; }
          set { vehicle = value; }
        }

        public  const int PixelUnit=3;

        private const string Gou = "gou.jpg";

        private Font GouFont;

        protected CompanyInfo comp;

       
        protected string GetNickName()
        {
            
            return comp.NickName;

        }

        protected void PrintExcelF6()
        {
            GoldPrinter.ExcelAccess excel = new GoldPrinter.ExcelAccess();
            string strExcelTemplateFile = Application.StartupPath
                + "/template/" + "注册登记表.xls";
            excel.Open(strExcelTemplateFile);
            excel.IsVisibledExcel = false;
           // excel.SetCellText(5, 7, "R注册登记");
           // excel.SetFont(5, 7, 5, 7, this.GouFont);
            
           
           
            excel.SetCellText(8, 7, " "+vehicle.TecZwpp+vehicle.TecClxh);
            excel.SetCellText(8, 21, " "+vehicle.TecClsbm);
            int row = 10, col = 7;
            switch(vehicle.XuGetFrom)
            {
                    case "购买":
                        row = 10;
                        col = 7;
                        break;
                    case "境外自带":
                        row = 10;
                        col = 8;
                        break;
                    case "继承":
                        row = 10;
                        col =10;
                        break;
                    case "赠予":
                        row = 10;
                        col =14;
                        break;
                    case "协议抵偿债务":
                        row = 10;
                        col =18;
                        break;
                    case "协议离婚":
                        row = 10;
                        col =25;
                        break;
                    case "中奖":
                        row = 10;
                        col =28;
                        break;

                    case "调拨":
                        row = 11;
                        col =7;
                        break;
                    case "资产重组":
                        row = 11;
                        col =8;
                        break;
                    case "资产整体买卖":
                        row = 11;
                        col =10;
                        break;
                    case "仲裁裁决":
                        row = 11;
                        col =18;
                        break;
                    case "法院调解":
                        row = 11;
                        col =25;
                        break;
                    case "法院裁定":
                        row = 11;
                        col =28;
                        break;
                    case "法院判决":
                        row = 12;
                        col =7;
                        break;
                    case "其他":
                        row = 12;
                        col =8;
                        break;
                default:
                    row = 10;
                    col = 7;
                    break;


            }
            excel.SetCellText(row, col, "R" + vehicle.XuGetFrom);
            excel.SetFont(row, col, row, col, this.GouFont);
            


            switch (vehicle.XuUseFor)
            {
                case "非营运":
                    row = 14;
                    col = 7;
                    break;
                case "公路客运":
                    row = 14;
                    col = 8;
                    break;
                case "公交客运":
                    row = 14;
                    col = 10;
                    break;
                case "出租客运":
                    row = 14;
                    col = 15;
                    break;
                case "旅游客运":
                    row = 14;
                    col = 21;
                    break;
                case "租赁":
                    row = 14;
                    col = 27;
                    break;
                case "教练":
                    row = 14;
                    col = 28;
                    break;

                case "幼儿校车":
                    row = 15;
                    col = 7;
                    break;
                case "小学生校车":
                    row = 15;
                    col = 8;
                    break;
                case "其他校车":
                    row = 15;
                    col = 10;
                    break;
                case "货运":
                    row = 15;
                    col = 15;
                    break;
                case "危险化学品运输":
                    row = 15;
                    col = 21;
                    break;
                case "警用":
                    row = 15;
                    col = 28;
                    break;
                case "消防":
                    row = 16;
                    col = 7;
                    break;
                case "救护":
                    row = 16;
                    col = 8;
                    break;
                case "工程救险":
                        row = 16;
                        col =10;
                        break;
                    case "营转非":
                        row = 16;
                        col =15;
                        break;
                    case "出租营转非":
                        row = 16;
                        col = 21;
                        break;
                default:
                    row = 14;
                    col = 7;
                    break;


            }
            excel.SetCellText(row, col, "R" + vehicle.XuUseFor);
            //Microsoft.Office.Interop.Excel.Range rang=excel.GetRange(row, col);
            //rang.Font.Name = "wingdings 2";
            excel.SetFont(row, col, row, col, this.GouFont);
            

            excel.SetCellText(17, 7, " " + vehicle.BaseSyrName);
            excel.SetCellText(18, 7, " " + vehicle.BaseSyrRegAddress);
            excel.SetCellText(19, 7, " " + vehicle.BaseSyrPostCode);
            excel.SetCellText(19, 11, " " + vehicle.BaseSyrPhone);
            excel.SetCellText(20, 7, " " + vehicle.BaseSyrEmail);
            excel.SetCellText(20, 11, " " + vehicle.BaseSyrMobile);

            excel.SetCellText(23, 7, " " + comp.Name);
            excel.SetCellText(25, 7, " " + comp.Address);
            excel.SetCellText(26, 7, " " + comp.PostCode.Substring(0,4)+"00");
            excel.SetCellText(26, 11, " " + comp.Phone);
            excel.SetCellText(27, 7, " " + comp.Email);
            excel.SetCellText(28, 7, " " + vehicle.BaseJbrName);
            excel.SetCellText(28, 11, " " + comp.Phone);

            GlobalPrintSetting printSetting = StaticCacheManager.GetConfig<GlobalPrintSetting>();
            if (printSetting.PrintModel == "直接打")
            {
                excel.Print();
            }
            else
            {
                excel.PrintPreview();
            }
            excel.Close();
        }
        protected void PrintExcelF7()
        {
            if (vehicle.DyHtzbh.Length > 0)
            {
                GoldPrinter.ExcelAccess excel = new GoldPrinter.ExcelAccess();
                string strExcelTemplateFile = Application.StartupPath
                    + "/template/" + "抵押登记表.xls";
                excel.Open(strExcelTemplateFile);
                excel.IsVisibledExcel = false;
                //excel.SetCellText(5, 6, "R"+"抵押登记  □解除抵押登记  □质押  □解除质押");
                //excel.SetFont(5, 6, 5, 6, this.GouFont);
                
                excel.SetCellText(7, 6, " " + vehicle.BaseSyrName);
                excel.SetCellText(8, 6, " " + comp.Name);
                excel.SetCellText(10, 6, " " + comp.Address);
                excel.SetCellText(12, 6, " " + comp.PostCode.Substring(0, 4) + "00");
                excel.SetCellText(12, 12, " " + comp.Phone);
                excel.SetCellText(13, 6, " " + comp.Email);
                excel.SetCellText(14, 6, " " + vehicle.BaseJbrName);
                excel.SetCellText(14, 12, " " + comp.Phone);

                excel.SetCellText(15, 6, " " + vehicle.DyDyqrName);
                excel.SetCellText(17, 6, " " + vehicle.DyDyqrConnAddress);
                excel.SetCellText(18, 6, " " + vehicle.DyDyqrPostCode);
                excel.SetCellText(18, 12, " " + vehicle.DyDyqrPhone);

                excel.SetCellText(20, 6, " " + comp.Name);
                excel.SetCellText(22, 6, " " + comp.Address);
                excel.SetCellText(24, 6, " " + comp.PostCode.Substring(0, 4) + "00");
                excel.SetCellText(24, 12, " " + comp.Phone);
                excel.SetCellText(26, 6, " " + vehicle.DyJbrName);
                excel.SetCellText(26, 12, " " + vehicle.DyDldwPhone);


                GlobalPrintSetting printSetting = StaticCacheManager.GetConfig<GlobalPrintSetting>();
                if (printSetting.PrintModel == "直接打")
                {
                    excel.Print();
                }
                else
                {
                    excel.PrintPreview();
                }
                excel.Close();
            }
            else
            {
                MessageBoxHelper.Show("抵押登记主合同编号为空的时候不打印抵押登记表！");
            }
        }
        protected void PrintExcelF2()
        {
            this.PrintExcelF6();
            if (vehicle.DyHtzbh.Length > 0)
            {
                this.PrintExcelF7();
            }
            
        }

        

        /// <summary>
        /// 套打全部-（F1包括F3/F4/F5）
        /// 直接打全部-（F2包括F6/F7/F5）
        /// 套打-申请表（F3）
        /// 套打-抵押表（F4）
        /// 打印－二维条码（F5）
        /// 直接打－申请表（F6）
        /// 直接打－抵押表（F7）
        /// </summary>
        /// <param name="student"></param>
        public BaseVehicleInfoPrinter(VehicleInfo vehicle)
        {
            this.vehicle = vehicle;
            this.GouFont = new Font("Wingdings 2", 10);
            comp = StaticCacheManager.GetConfig<CompanyInfo>();
        }

         //套打-申请表（F3）
        protected void PrintF3()
        {
            this.Draw10String("printf3", new Point(100, 100));
        }
        //套打-抵押表（F4）
        protected void PrintF4()
        {
            this.Draw10String("printf4", new Point(100, 100));
            //this.DrawStringHor("√", check, new Point(width + 93, height));
            //MyGraphics.DrawImageUnscaled(Image.FromFile(Gou), new Point(width + 63, height));
        }

        //打印－二维条码（F5）
        protected void PrintF5()
        {
            this.Draw15String(comp.NickName,new Point(100,100));
            this.Draw15String(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), new Point(100, 150));
            MyGraphics.DrawImage(this.GetQRImage(vehicle.OthDimension), new Rectangle(new Point(100,200), new Size(150, 150)));
            //this.Draw10String("printf5", new Point(100, 100));
        }

        protected void DrawTitle(Point p)
        {
            Font font = new Font("黑体",15);
            this.DrawStringHor(this.GetNickName(), font, p);
        }

        protected void DrawTitleDefault()
        {
            this.DrawTitle(new System.Drawing.Point(540, 80));
        }


        protected Image GetQRImage(string data)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;


            try
            {
                //14 2920bit/8=365byte 16 3624/8=453byte 18 4504=536byte 20 5352=669byte
                qrCodeEncoder.QRCodeScale = Int16.Parse(System.Configuration.ConfigurationManager.AppSettings["QRCodeScale"]);
            }
            catch (Exception ex)
            {
                //LogFactoryWrapper.StreamError(ex);
                qrCodeEncoder.QRCodeScale = 2;
            }


            try
            {
                //14 2920bit/8=365byte 16 3624/8=453byte 18 4504=536byte 20 5352=669byte
                qrCodeEncoder.QRCodeVersion = Int16.Parse(System.Configuration.ConfigurationManager.AppSettings["QRCodeVersion"]);
            }
            catch (Exception ex)
            {
                //LogFactoryWrapper.StreamError(ex);
                qrCodeEncoder.QRCodeVersion = 16;
            }


            string errorCorrect = "M";
            if (errorCorrect == "L")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            else if (errorCorrect == "M")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            else if (errorCorrect == "Q")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
            else if (errorCorrect == "H")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;

            Image image;
            //,System.Text.Encoding.UTF8
            int length = data.Length;
            image = qrCodeEncoder.Encode(data, System.Text.Encoding.GetEncoding("gb2312"));
            return image;
        }

    }
}
