using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms;
using FT.Windows.Forms.Plugins;
using FT.Commons.Tools;
using FT.Commons.WebCatcher;
using FT.DAL;
using System.Windows.Forms;

namespace FT.Lottery
{
    [Plugin(ChangeLogPath = "changlog.txt", Company = "Fight Together", Developer = "deadshot123",
        Email = "cbw123_1984@163,com", MainVersion = "1.0", Name = "×ÔÖú²©²Ê¹¤¾ß", Tel = "15814584509", Url = "http://deadshot123.cnblogs.com")]
    public class LotteryPlugin : AbstractWindowPlugin
    {


        public override void EmmitMenu()
        {
            this.AddToMenu("×ÔÖú²©²Ê").DropDownItems.Add(this.BuildSubMenu("²ÊÆ±·ÖÎö",typeof(LotteryParse)));
            this.IsEmmitSeparator = true;
        }

        public override void EmmitToolBar()
        {
            this.AddTopTool(FT.Lottery.Properties.Resource.car, "²ÊÆ±·ÖÎö", typeof(LotteryParse));
            //throw new Exception("The method or operation is not implemented.");
        }
    }
}
