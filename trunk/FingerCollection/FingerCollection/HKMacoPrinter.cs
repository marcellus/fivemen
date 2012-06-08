using System;
using System.Collections.Generic;
using System.Text;
using FT.Commons.Print;
using FT.Commons.Bar;
using FT.Commons.Tools;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace FingerCollection
{
    public class HKMacoPrinter : ObjectPrinter
    {

        private string idcard;
        private string name;

        public HKMacoPrinter(string idcard,string name)
        {
            this.idcard = idcard;
            this.name = name;
        }


        public override int GetTotalPage()
        {
            return 1;
        }

        public override System.Drawing.Image Paint()
        {
            throw new NotImplementedException();
        }

        public override void PaintPrinter()
        {
            if (this.GetCurrentPage() ==1)
            {
                this.PrintViewClient();
            }
        }

        public void PrintViewClient()
        {
            SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
            Code39 code39 = new Code39();
            code39.WidthCU = 2;
            code39.LineHeight = 20;
            try
            {
                this.Draw11String(name,new Point(config.LeftPoint+5,config.TopPoint));
                SizeF titleSize = MyGraphics.MeasureString("1", code39.titleFont);
                code39.Height = code39.topHeight + code39.LineHeight + (int)titleSize.Height;//定义图片高度          
                Bitmap map = code39.CreateBarCode(this.idcard);
                string path = Application.StartupPath + "/tempcode39.jpg";
                ImageHelper.SaveCoderPic(map, path);
                Image imagetest2 = Image.FromFile(path);
                Image imagetmp2 = new System.Drawing.Bitmap(imagetest2);

                MyGraphics.DrawImage(imagetmp2,config.LeftPoint, config.TopPoint+20);
                imagetest2.Dispose();
                File.Delete(path);
                imagetmp2.Dispose();
            }
            catch (Exception ex)
            {
                //LogFactoryWrapper.Debug("由于证件号码有汉字，不支持code39编码！");
            }
        }
    }
}
