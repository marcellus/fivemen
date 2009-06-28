using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Bar;
using System.Drawing;
using System.Windows.Forms;
using FT.Commons.Cache;
using FT.Windows.Forms;
using FT.Windows.Forms.Domain;
using FT.Commons.Tools;

namespace DS.Plugins.Student
{
    public class ApplyPrinter:BaseStudentPrinter
    {
        public ApplyPrinter(StudentInfo student)
            : base(student)
        {
        }
        public override int GetTotalPage()
        {
            return 1;
        }

        public override System.Drawing.Image Paint()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override void PaintPrinter()
        {
            if (this.GetCurrentPage() == 1)
            {
                this.PrintApply();
            }
        }

        private void PrintApply()
        {
            ApplyPrinterConfig config = AllPrinterConfig.GetPrinterConfig().ApplyConfig;
            int height = (config.Down - config.Up) * BaseStudentPrinter.PixelUnit + 140;
            //int sep = 35;
            int sep = 31;
            // int width = 132;
            int width = (config.Right - config.Left) * BaseStudentPrinter.PixelUnit + 90;

            //16,2
            //MyGraphics.DrawImage(this.GetQRImage(this.GetQRString()),new Point(620,860));
            //14,2
            if (Student.LearnType == "初学")
            {
                if (config.Allow2Dimension)
                {
                    string path = Application.StartupPath + "/temp.jpg";
                    //string path = Application.StartupPath + "/tempcode39.jpg";
                    ImageHelper.SaveCoderPic(this.GetQRImage(Student.Dimension),path);
                   // MyGraphics.DrawImage(Image.FromFile(path), new Rectangle(new Point(516 + width, 720 + height), new Size(150, 150)));
                    MyGraphics.DrawImage(Image.FromFile(path), new Rectangle(new Point(480 + width, 740 + height), new Size(130, 130)));
                }
            }
            DateTime regDate = System.DateTime.Now;
            if (config.PrintApplyDate)
            {
                this.Draw10String(regDate.Year + "   " + regDate.Month + "  " + regDate.Day, new Point(width + 567, height + 920));
            }
            //MyGraphics.DrawImage(this.GetQRImage(this.GetQRString()), new Point(320, 460));
            //画出驾校简称
            //MyGraphics.DrawRectangle(blackPen, 600, 10, 680, 30);
            //this.DrawStringHor("驾校简称：" + Fm.Windows.Forms.CompanyInfoForm.Info.NickName,  new Point(605, 55));
            // this.Draw11String("驾校简称：" + Fm.Windows.Forms.CompanyInfoForm.Info.NickName, new Point(605,55));
            CompanyInfo comp = StaticCacheManager.GetConfig<CompanyInfo>();
            this.DrawStringHor("驾校：" + comp.NickName, new Font("黑体", 15), new Point(480 + width, height - 120));
            // 画出身份证明号码的一维条码



            Code39 code39 = new Code39();
            code39.WidthCU = 2;
            code39.LineHeight = 20;
            try
            {
                SizeF titleSize = MyGraphics.MeasureString("1", code39.titleFont);
                code39.Height = code39.topHeight + code39.LineHeight + (int)titleSize.Height;//定义图片高度          
                Bitmap map = code39.CreateBarCode(Student.IdCard);
                string path = Application.StartupPath + "/tempcode39.jpg";
                ImageHelper.SaveCoderPic(map, path);
                MyGraphics.DrawImage(Image.FromFile(path), new RectangleF(width - 40, height - 46, 240, 30));
            }
            catch (Exception ex)
            {
                //LogFactoryWrapper.Debug("由于证件号码有汉字，不支持code39编码！");
            }

            if (config.PrintProfile && Student.LearnType != "初学")
            {
                this.Draw15String(Student.Profile, new Point(width + 555, height - 34));//+75
            }


            this.Draw15String(Student.Name, new Point(width, height));//+75
            this.Draw15String(Student.Sex, new Point(319 + width, height));
            this.Draw15String(Student.Birthday, new Point(width + 436, height));
            this.Draw15String(Student.Nation, new Point(606 + width, height));



            height += sep - 2;
            if (Student.IdCardType.Length < IdCardTypeMaxLen)
            {
                this.Draw15String(Student.IdCardType, new Point(width, height + 5));
            }
            else
            {
                this.Draw9String(Student.IdCardType, new Point(width, height + 5));
            }
            
            //画身份证号码
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;
            for (int i = 0; i < Student.IdCard.Length; i++)
            {
                //MyGraphics.DrawString(idCard[i].ToString(), body11Font, blackBrush, new RectangleF(332 + 17 * i+(i/2)*1, height - 7, 17, 35), stringFormat);
                MyGraphics.DrawString(Student.IdCard[i].ToString(), body15Font, blackBrush, new RectangleF(width + 165 + 22 * i + (i / 6) * 1, height - 7, 22, 35), stringFormat);
                // MyGraphics.DrawRectangle(blackPen, 332 + 17 * i + (i / 2) * 1, height - 7, 17, 36);
                // this.Draw11String(idCard[i].ToString(), new Point(334 + i * tempIdSep, height));
            }
            //画像片
            //if (this.picture != null)
            //{
                //MyGraphics.DrawImage(this.picture, new RectangleF(647, 175, 137, 168));
                //MyGraphics.DrawImage(this.picture, new RectangleF(653, 175, 134, 170));
            //}

            height += sep - 3;
            //画暂住证明

            if (Student.TempId!=null&&Student.TempId != string.Empty)
            {
                if (Student.IdCardType.Length < IdCardTypeMaxLen)
                {
                    this.Draw15String("暂住证", new Point(width, height + 5));
                }
                else
                {
                    this.Draw9String("暂住证", new Point(width, height + 5));
                }
                
                for (int i = 0; i < Student.TempId.Length; i++)
                {
                    MyGraphics.DrawString(Student.TempId[i].ToString(), body15Font, blackBrush, new RectangleF(width + 165 + 21 * i + (i / 2) * 1, height - 5, 21, 35), stringFormat);
                }
            }
            height += sep + 5;
            this.Draw15String(Student.RegAddress, new Point(width, height));

            height += sep + 5;
            string connadd = this.GetConnAddress();
            if (connadd.Length >= ConnAddressMaxLen)
            {
                this.Draw9String(this.GetConnAddress(), new Point(width, height));
            }
            else{
            this.Draw15String(this.GetConnAddress(), new Point(width, height));
        }
            height += sep + 6;
            this.Draw15String(Student.Phone, new Point(width, height));
            this.Draw15String(Student.PostCode, new Point(410 + 100, height));

            height += sep + 10;
            //this.Draw11String(this.allowCar, new Point(470, height));
            this.Draw15String(Student.NewCarType, new Point(400, height));
            //为增驾或者初学打钩
            Font check = new Font("宋体", 20);
            if (Student.LearnType == "初学")
            {
                // this.Draw11String("√", new Point(width+18, height+2));
                this.DrawStringHor("√", check, new Point(width - 18, height + 1));
            }
            else
            {
                //this.Draw11String("√", new Point(width+18, height+sep-1));
                this.DrawStringHor("√", check, new Point(width - 18, height + sep - 1));
                this.Draw15String(Student.OldCarType, new Point(568 + width, height));
            }
        }

        
       
    }
}
