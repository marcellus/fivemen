using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Orm;

namespace FT.Web.Bll.SystemConfig
{
    

    /// <summary>
    ///SystemConfigEntity 的摘要说明
    /// </summary>
    [SimpleTable("yuantuo_system_config")]
    [Alias("系统配置表")]
    [Serializable]
    public class SystemConfigEntity
    {
        public SystemConfigEntity()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        [SimplePK]
        public int Id;

        public int 编号
        {
            get { return Id; }
            set { Id = value; }
        }

        [SimpleColumn(Column = "printlogourl")]
        [Alias("打印logo地址")]
        public String PrintLogoUrl;

        public String 打印logo地址
        {
            get { return PrintLogoUrl; }
            set { PrintLogoUrl = value; }
        }


        [SimpleColumn(Column = "printlogox")]
        [Alias("打印logo地址X")]
        public int PrintLogoX;

        public int 打印logo地址X
        {
            get { return PrintLogoX; }
            set { PrintLogoX = value; }
        }

        [SimpleColumn(Column = "printlogoy")]
        [Alias("打印logo地址Y")]
        public int PrintLogoY;

        public int 打印logo地址Y
        {
        
            get { return PrintLogoY; }
            set { PrintLogoY = value; }
        }
        [SimpleColumn(Column = "realroadconditionurl")]
        [Alias("实时路况地址")]
        public String RealRoadConditionurl;

        public String 实时路况地址
        {
            get { return RealRoadConditionurl; }
            set { RealRoadConditionurl = value; }
        }
        [SimpleColumn(Column = "adurl")]
        [Alias("流媒体地址")]
        public String AdUrl;

        public String 流媒体地址
        {
            get { return AdUrl; }
            set { AdUrl = value; }
        }
        [SimpleColumn(Column = "voipurl")]
        [Alias("VOIP地址")]
        public String VoipUrl;

        public String VOIP地址
        {
            get { return VoipUrl; }
            set { VoipUrl = value; }
        }

        
    }

}
