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

namespace DS.Plugins.Student
{
    public abstract class BaseStudentPrinter:ObjectPrinter
    {
        protected static  string[] allowCars=new string[]{"A1","A2","A3","B1","B2","C1","C2","C3","C4","D","E","F","M","N","P"};
        private StudentInfo student;

        public const int ConnAddressMaxLen = 25;
        public const int IdCardTypeMaxLen = 6;
        //public const int TempIdTypeMaxLen = 5;

        public  const int PixelUnit=3;

        private const string Gou = "gou.jpg";

        public string GetConnAddress()
        {
            string result = this.Student.ConnAddress;
            if(student.BelongXiang.Length>0)
            {
                result+= "-" + Student.BelongXiang + "-" + Student.BelongCun;
            }
             if(student.BelongCun.Length>0)
            {
                result+=  "-" + Student.BelongCun;
            }
            return result;
        }

        protected string GetNickName()
        {
            CompanyInfo comp = StaticCacheManager.GetConfig<CompanyInfo>();
            return comp.NickName;

        }

        public StudentInfo Student
        {
            get { return student; }
            set { student = value; }
        }

        /// <summary>
        /// 套打-全部6张(F1)
        /// 套打-机动车驾驶培训记录*3(F2)(完成)
        /// 套打-机动车驾驶人身体条件证明(F3)(开发区完成)
        /// 套打-机动车驾驶员培训学员登记表(F4)(完成)
        /// 套打-机动车学习驾驶员登记表(F5)
        /// 套打-科目三考试成绩表(F6)(完成)
        /// 套打-机动车驾驶人档案(F7)(超过A4,无法测试)
        /// </summary>
        /// <param name="student"></param>
        public BaseStudentPrinter(StudentInfo student)
        {
            this.student = student;
        }
        /*
         套打-全部6张(F1)
套打-机动车驾驶培训记录*3(F2)
套打-机动车驾驶人身体条件证明(F3)
套打-机动车驾驶员培训学员登记表(F4)
套打-机动车学习驾驶员登记表(F5)
套打-科目三考试成绩表(F6)
套打-机动车驾驶人档案(F7)
         */
        protected void PrintF2()
        {
            F2PrinterConfig config=AllPrinterConfig.GetPrinterConfig().F2Config;
            int height = ( config.Left-config.Right ) * PixelUnit  -690;
            int width = (config.Down - config.Up) * PixelUnit + 900;
            int sep = 47;


            //驾校简称
            this.DrawStringVerAndHor("驾校：" + this.GetNickName(), new Font("黑体",15), new Point(width, height-50));


            height += sep;
            //姓名
            this.DrawStringVerAndHor(Student.Name, body15Font, new Point(width - 670, height));
            //性别
            this.DrawStringVerAndHor(Student.Sex, body15Font, new Point(width - 500, height));

            //身份证明号码
            this.DrawStringVerAndHor(Student.IdCard, body15Font, new Point(width - 350, height));

            //入学时间
            if (config.PrintDate)
            {
                this.DrawStringVerAndHor(Convert.ToDateTime(Student.BaoMingDate).ToString("yyyy-MM-dd"), body14Font, new Point(width - 70, height));
            }

            height += sep;
            //家庭住址
            this.DrawStringVerAndHor(Student.RegAddress, body11Font, new Point(width - 670, height));

            // 联系方式
            this.DrawStringVerAndHor(Student.Mobile, body15Font, new Point(width - 260, height));

            height += sep +10;
            int len = allowCars.Length;
            Font check = new Font("宋体", 20);
            width -= 660;
            //申请车型
            if (config.CheckC1&&student.NewCarType.ToUpper() == "C1")
            {
                if (Student.NewCarStyle.IndexOf("轿") != -1)
                {
                    this.DrawStringVerAndHor("J", check, new Point(width + 50 * (5), height));
                }
                else if (Student.NewCarStyle.IndexOf("货") != -1)
                {
                    this.DrawStringVerAndHor("H", check, new Point(width + 50 * (5) , height));
                }
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    if (Student.NewCarType == allowCars[i])
                    {
                        // "√"
                        this.DrawStringVerAndHor("√", check, new Point(width +48 * (i) - (i / 2) * 6, height));
                        //this.DrawImageVerAndHor(Gou, new Point(width + 48 * (i) - (i / 2) * 6, height));
                        break;
                    }
                }
            }
        }

        protected void PrintF3()
        {
            F3PrinterConfig config = AllPrinterConfig.GetPrinterConfig().F3Config;
            //this.Draw13String(Fm.Windows.Forms.CompanyInfoForm.Info.NickName, new System.Drawing.Point(610, 75));
            this.DrawTitle(new System.Drawing.Point(610, 75));
            int height = (config.Down - config.Up) * PixelUnit + 272;
            int width = (config.Right - config.Left) * PixelUnit + 170;
            int sep = 36;

            this.Draw15String(Student.Name, new Point(width, height));
            this.Draw15String(Student.Sex, new Point(width + 170, height));
            this.Draw15String(Convert.ToDateTime(Student.Birthday).ToString("yyyy-MM-dd"), new Point(width + 300, height));
            this.Draw15String(Student.Nation, new Point(width + 550, height));
            height += sep;
            this.Draw15String(Student.IdCardType, new Point(width, height));

            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;

            for (int i = 0; i < Student.IdCard.Length; i++)
            {
                MyGraphics.DrawString(Student.IdCard[i].ToString(), body15Font, blackBrush, new RectangleF(width+216 + 22 * i, height - 6, 22, 35), stringFormat);
                //MyGraphics.DrawString(idCard[i].ToString(), body9Font, blackBrush, new RectangleF(445 + 19 * i , height - 6, 19, 35), stringFormat);
                // MyGraphics.DrawRectangle(blackPen, 332 + 17 * i + (i / 2) * 1, height - 7, 17, 36);+ (i / 2) * 1
                // this.Draw15String(idCard[i].ToString(), new Point(334 + i * tempIdSep, height));
            }
            height += sep + 5;
            this.Draw15String(Student.NewCarType, new Point(width + 150, height));
            if (config.PrintProfile&&student.LearnType=="增驾")
            {
                this.Draw15String(Student.Profile, new Point(width + 300, height));
            }
            height += sep - 5;
            Font check = new Font("宋体", 20);
            this.DrawStringHor("√", check, new Point(width + 93, height));
            //MyGraphics.DrawImageUnscaled(Image.FromFile(Gou), new Point(width + 63, height));
        }
        protected void PrintF4()
        {
            F4PrinterConfig config = AllPrinterConfig.GetPrinterConfig().F4Config;
            int height = (config.Down - config.Up) * PixelUnit+130;
            int width = (config.Right - config.Left) * PixelUnit + 170;
            int sep = 55;
            //this.Draw13String(Fm.Windows.Forms.CompanyInfoForm.Info.NickName, new System.Drawing.Point(width + 70, height - 5));
            this.DrawTitle(new System.Drawing.Point(width + 70, height - 5));
            height += sep;
            this.Draw15String(Student.Name, new Point(width, height));
            this.Draw15String(Student.Sex, new Point(width + 200, height));
            DateTime date = Convert.ToDateTime(Student.Birthday);
            this.Draw15String(date.Year.ToString(), new Point(width + 350, height));
            this.Draw15String(date.Month.ToString(), new Point(width + 412, height));

            height += sep;
            this.Draw15String(Student.IdCard, new Point(width, height));
            height += sep;

            if (Student.RegAddress.Length >= ConnAddressMaxLen)
            {
                this.Draw9String(Student.RegAddress, new Point(width, height));
            }
            else
            {
                this.Draw15String(Student.RegAddress, new Point(width, height));
            }
            

            height += sep;
            this.Draw15String(Student.Mobile, new Point(width, height));

            // height += sep;
            if ( student.LearnType == "增驾")
            {
                this.Draw15String(Student.OldCarType, new Point(width + 300, height));
            }
            height += sep - 15;
            //车辆类型打钩
            //申请车型

            Font check = new Font("宋体", 20);
            if (config.CheckC1 && student.NewCarType.ToUpper() == "C1")
            {
                Point tmp = new Point(width + 211, height + 35 );
                if (Student.NewCarStyle.IndexOf("轿") != -1)
                {
                    this.DrawStringHor("J", check, tmp);
                }
                else if (Student.NewCarStyle.IndexOf("货") != -1)
                {
                    this.DrawStringHor("H", check, tmp);
                }
            }
            else
            {
                for (int i = 0; i < allowCars.Length; i++)
                {
                    if (Student.NewCarType == allowCars[i])
                    {
                        // "√"
                        this.DrawStringHor("√", check, new Point(width + 211 + 65 * (i % 5), height + 35 * (i / 5)));
                        //MyGraphics.DrawImageUnscaled(Image.FromFile(Gou), new Point(width + 211 + 65 * (i % 5), height + 35 * (i / 5)));
                        break;
                    }
                }
            }

            //this.DrawStringHor("√", check, new Point(width + 60, height + 50));
            //MyGraphics.DrawImage(Image.FromFile(Gou), new Point(width + 60, height + 50));
            DateTime regDate = Convert.ToDateTime(Student.BaoMingDate);
            height = 700;
            if (config.PrintDate)
            {
                this.Draw15String(regDate.Year.ToString(), new Point(width, height));
                this.Draw15String(regDate.Month.ToString(), new Point(width + 90, height));
                this.Draw15String(regDate.Day.ToString(), new Point(width + 140, height));
            }
        }
        protected void PrintF6()
        {
            int height = 215;
            int width = 250;
            int sep = 35;

        }

        protected void PrintF7()
        {
            int height = 215;
            int width = 250;
            int sep = 35;

        }

        protected void PrintF8()
        {
            int height = 215;
            int width = 250;
            int sep = 35;

        }

        protected void PrintF9()
        {
            int height = 215;
            int width = 250;
            int sep = 35;

        }

        protected void PrintF5()
        {
            F6PrinterConfig config = AllPrinterConfig.GetPrinterConfig().F6Config;
            int height = (config.Down - config.Up) * PixelUnit+215;
            int width = (config.Right - config.Left) * PixelUnit +250;
            int sep = 36;
            this.DrawTitleDefault();
            height += sep;
            this.Draw15String(Student.Name, new Point(width, height));
            this.Draw15String(Student.Sex, new Point(width + 300, height));
            height += sep + 5;
            if (Student.ExamId != null && Student.ExamId.Length > 0)
            {
                this.Draw15String(Student.ExamId, new Point(width, height));
            }
            else if (config.ExamIdPrefix.Length > 0)
            {
                this.Draw15String(config.ExamIdPrefix, new Point(width, height));
            }
            height += sep;
            this.Draw15String(Student.IdCard, new Point(width, height));
            height += sep + 5;
            //this.Draw13String(Fm.Windows.Forms.CompanyInfoForm.Info.NickName, new System.Drawing.Point(width, height));
            if (config.PrintCompany)
            {
                this.Draw15String(this.GetNickName(), new System.Drawing.Point(width, height));
                //this.DrawTitle(new System.Drawing.Point(width, height));
            }
            string tmp = Student.NewCarType;
            if (tmp.ToUpper()=="C1"&&config.CheckC1)
            {
                if (Student.NewCarStyle.IndexOf("轿") != -1)
                {
                    tmp += "轿";
                }
                else if (Student.NewCarStyle.IndexOf("货") != -1)
                {
                    tmp += "货";
                }
            }
            this.Draw15String(tmp, new Point(width + 300, height));
            height += sep;
            if (config.ExamAddress.Length > 0)
            {
                this.Draw15String(config.ExamAddress, new Point(width, height));
            }
        }

        protected void DrawTitle(Point p)
        {
            Font font = new Font("黑体",15);
            this.DrawStringHor("驾校："+this.GetNickName(), font, p);
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
