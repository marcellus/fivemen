using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.Product
{
    [SimpleTable("yuantuo_product_info")]
    [Alias("产品表")]
    [Serializable]
    public class ProductInfo
    {
        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "no")]
        [Alias("产品序号")]
        public String No;

        public String 产品序号
        {
            get { return No; }
            set { No = value; }
        }


        [SimpleColumn(Column = "name")]
        [Alias("产品名称")]
        public String Name;

        public String 产品名称
        {
            get { return Name; }
            set { Name = value; }
        }


        [SimpleColumn(Column = "price")]
        [Alias("产品价格")]
        public double Price;

        public double 产品价格
        {
            get { return Price; }
            set { Price = value; }
        }


        [SimpleColumn(Column = "des")]
        [Alias("产品备注")]
        public String Des;

        public String 产品备注
        {
            get { return Des; }
            set { Des = value; }
        }


        [SimpleColumn(Column = "imgs")]
        [Alias("产品展示图片路径")]
        public String Imgs;

        public String 产品展示图片路径
        {
            get { return Imgs; }
            set { Imgs = value; }
        }


        [SimpleColumn(Column = "ordernum")]
        [Alias("产品排序")]
        public int OrderNum;

        public int 产品排序
        {
            get { return OrderNum; }
            set { OrderNum = value; }
        }

        [SimpleColumn(Column = "producttypeid")]
        [Alias("产品类别ID")]
        public int ProductTypeId;

        public int 产品类别ID
        {
            get { return ProductTypeId; }
            set { ProductTypeId = value; }
        }


        [SimpleColumn(Column = "imgmain")]
        [Alias("产品主展示图片")]
        public String ImgMain;

        public String 产品主展示图片
        {
            get { return ImgMain; }
            set { ImgMain = value; }
        }


        [SimpleColumn(Column = "status")]
        [Alias("产品状态")]
        public int Status;

        public int 产品状态
        {
            get { return Status; }
            set { Status = value; }
        }


        [SimpleColumn(Column = "pinpai")]
        [Alias("产品品牌")]
        public String PinPai;

        public String 产品品牌
        {
            get { return PinPai; }
            set { PinPai = value; }
        }

        [SimpleColumn(Column = "guige")]
        [Alias("产品规格")]
        public String GuiGe;

        public String 产品规格
        {
            get { return GuiGe; }
            set { GuiGe = value; }
        }


        [SimpleColumn(Column = "chandi")]
        [Alias("产品场地")]
        public String ChanDi;

        public String 产品场地
        {
            get { return ChanDi; }
            set { ChanDi = value; }
        }

        [SimpleColumn(Column = "production")]
        [Alias("产品介绍")]
        public String Production;

        public String 产品介绍
        {
            get { return Production; }
            set { Production = value; }
        }


        [SimpleColumn(Column = "getproductdays")]
        [Alias("取货天数")]
        public int GetProductDays;

        public int 取货天数
        {
            get { return GetProductDays; }
            set { GetProductDays = value; }
        }


        [SimpleColumn(Column = "seetimes")]
        [Alias("浏览次数")]
        public int SeeTimes;

        public int 浏览次数
        {
            get { return SeeTimes; }
            set { SeeTimes = value; }
        }

    }
}
