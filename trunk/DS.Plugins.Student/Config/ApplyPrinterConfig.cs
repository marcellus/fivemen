using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Plugins.Student
{
    /// <summary>
    /// 套打申请表的设置
    /// </summary>
    [Serializable]
    public class ApplyPrinterConfig:FT.Commons.PrinterEx.BatchPrintConfig
    {
        /// <summary>
        /// 是否打印答案
        /// </summary>
        public bool PrintProfile;

        /// <summary>
        /// 是否允许打印二维条码,默认有打
        /// </summary>
        public bool Allow2Dimension=true;
        /// <summary>
        /// 是否允许打印乡镇村居委，如果不打为false，默认不打
        /// </summary>
        public bool PrintXiangCun = false;


        /// <summary>
        /// 是否允许打印入学时间
        /// </summary>
        public bool PrintApplyDate = false;
        /// <summary>
        /// 是否打印的时候必须填写体检信息
        /// </summary>
        public bool IsBodyCheck = false;

        

        /// <summary>
        /// 驾校简称向下多少毫米
        /// </summary>
        public int NameDown=0;

        /// <summary>
        /// 驾校简称向左多少毫米
        /// </summary>
        public int NameLeft=0;

       
    }
}
