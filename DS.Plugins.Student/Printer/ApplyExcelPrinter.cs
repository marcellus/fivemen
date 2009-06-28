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
using FT.Commons.Print;

namespace DS.Plugins.Student
{
    public class ApplyExcelPrinter:BaseStudentPrinter
    {
        public ApplyExcelPrinter(StudentInfo student)
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
                //this.PrintExcel(false);
            }
        }

        



        /// <summary>
        /// ֱ�Ӵ�ӡ
        /// </summary>
        public void PrintExcel(bool saveInk)
        {

            GoldPrinter.ExcelAccess excel = new GoldPrinter.ExcelAccess();


            if (!saveInk)
            {

                string strExcelTemplateFile = Application.StartupPath + "/template/" + "��ʻ֤�����";
                strExcelTemplateFile += "-" + this.Student.LearnType + ".xlt";
                //System.IO.Path.GetFullPath(@"��ʻ֤�����.xlt");
                excel.Open(strExcelTemplateFile);
            }//��ģ���ļ�
            else
            {
                string strExcelTemplateFile = Application.StartupPath + "/template/" + "�״�-��ʻ֤�����";
                //System.IO.Path.GetFullPath(@"��ʻ֤�����.xlt");
                strExcelTemplateFile += "-" + this.Student.LearnType + ".xlt";
                excel.Open(strExcelTemplateFile);
                //excel.Open();
            }
            excel.IsVisibledExcel = false;

            Code39 code39 = new Code39();
            code39.WidthCU = 2;
            code39.LineHeight = 20;
            try
            {
                //SizeF titleSize = MyGraphics.MeasureString("1", code39.titleFont);
                code39.Height = code39.topHeight + code39.LineHeight + (int)20;//����ͼƬ�߶�          
                Bitmap map = code39.CreateBarCode(Student.IdCard);
                string pathcode39 = Application.StartupPath + "/tempcode39.jpg";
                ImageHelper.SaveCoderPic(map, pathcode39);
               // map.Save(pathcode39, System.Drawing.Imaging.ImageFormat.Jpeg);
                excel.InsertPicture(3, 1, pathcode39, 155, 26, 0);
            }
            catch (Exception ex)
            {
                //LogFactoryWrapper.Debug("����֤�������к��֣���֧��code39���룡");
            }

            //excel.SetCellText(1, 24, 1, 30, "��У��" + Fm.Windows.Forms.CompanyInfoForm.Info.NickName);
            //excel.SetCellText(2, 24, 2, 30, "��У-" + Fm.Windows.Forms.CompanyInfoForm.Info.NickName);
            // excel.SetCellText(1, 1, "  " + this.name);
            // excel.SetCellText(1, 20, "  " + this.name);
            //excel.SetCellText(1, 21, "  " + this.name);
            CompanyInfo comp = StaticCacheManager.GetConfig<CompanyInfo>();
            excel.SetCellText(1, 22, "��У��" + comp.NickName);
            //excel.SetCellText(1, 23, "  " + this.name);
            // excel.SetCellText(2, 24, 2, 30, "  " + this.name);

            excel.SetCellText(4, 3, 4, 11, "  " + Student.Name);

            excel.SetCellText(4, 14, 4, 15, Student.Sex);
            excel.SetCellText(4, 19, 4, 24, Student.Birthday);
            excel.SetCellText(4, 27, 4, 30, Student.Nation);
            excel.SetCellText(5, 3, 5, 4, Student.IdCardType);
            if (Student.IdCardType.Length < IdCardTypeMaxLen)
            {
                excel.SetFont(5, 3, 6, 4, new Font("����", 15f));
            }


            for (int i = 0; i < Student.IdCard.Length; i++)
            {
                excel.SetCellText(5, 7 + i, Student.IdCard[i].ToString());
            }
            if (Student.TempId.Length > 0)
            {
                excel.SetCellText(6, 3, 6, 4, "��ס֤");

                for (int i = 0; i < Student.TempId.Length; i++)
                {
                    excel.SetCellText(6, 7 + i, Student.TempId[i].ToString());
                }
            }
            excel.SetCellText(7, 3, 7, 24, "  " + Student.RegAddress);
            string connadd=this.GetConnAddress();

            excel.SetCellText(8, 3, 8, 24, "  " + connadd);
            if(connadd.Length<ConnAddressMaxLen)
            {
                excel.SetFont(8, 3, 8, 24, new Font("����", 15f));
            }
            
            excel.SetCellText(9, 3, 9, 13, "  " + Student.Phone);
            excel.SetCellText(9, 18, 9, 24, Student.PostCode);
            excel.SetCellText(10, 11, 10, 17,Student.NewCarType);
            DateTime regDate = System.DateTime.Now;
            if (AllPrinterConfig.GetPrinterConfig().ApplyConfig.PrintApplyDate)
            {
                excel.SetCellText(35, 25, 36, 30, regDate.Year + " �� " + regDate.Month + " �� " + regDate.Day + "��");
            }
            string path = Application.StartupPath + "/temp.jpg";
            if (Student.LearnType == "��ѧ")
            {
                if (AllPrinterConfig.GetPrinterConfig().ApplyConfig.Allow2Dimension)
                {
                    //this.GetQRImage(Student.Dimension).Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ImageHelper.SaveCoderPic(this.GetQRImage(Student.Dimension), path);
                    //excel.InsertPicture(25, 23, path, 110, 110, 5);
                    excel.InsertPicture(27, 16, path, 100, 100, 5);
                }
            }
            else
            {
                excel.SetCellText(10, 25, 10, 30, Student.OldCarType);
                if (AllPrinterConfig.GetPrinterConfig().ApplyConfig.PrintProfile)
                {
                    excel.SetCellText(3, 25, 3, 30, Student.Profile);
                }
            }


            /*if (this.LearnTypeString == "��ѧ")
            {
                if (!this.saveInk)
                {
                    excel.SetCellText(10, 3, "����������");
                }
                else
                {
                    excel.SetCellText(10, 3, "��");
                }
               
            }
            else
            {
                if (!this.saveInk)
                {
                    excel.SetCellText(11, 3, "������׼�ݳ���");
                }
                else
                {
                    excel.SetCellText(11, 3, "��");
                }
                excel.SetCellText(10, 25, 10, 30, this.HaveCarType);
            }
            */
            GlobalPrintSetting printSetting = StaticCacheManager.GetConfig<GlobalPrintSetting>();
            if (printSetting.PrintModel == "ֱ�Ӵ�")
            {
                excel.Print();
            }
            else
            {
                excel.PrintPreview();
            }
            

            excel.Close();
        }
    }
}
