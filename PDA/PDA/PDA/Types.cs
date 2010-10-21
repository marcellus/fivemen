using System;

using System.Collections.Generic;
using System.Text;

namespace PDA
{
    public class Types
    {
        public enum ScanInfo
        {
            /// <summary>
            /// 扫描失败
            /// </summary>
            ScanError = -6,
            /// <summary>
            /// 该料盘不在该库位中
            /// </summary>
            NotInLoc = -5,
            /// <summary>
            /// 该料盘不在本次扫描计划中
            /// </summary>
            NotInBill = -4,
            /// <summary>
            /// 该料盘未扫描，不能撤消
            /// </summary>
            NotScan = -3,
            /// <summary>
            /// 该料盘已扫描，不能重复扫描
            /// </summary>
            RepeatScan = -2,
            /// <summary>
            /// 超出物料已扫描数量，不能撤消
            /// </summary>
            Underflow = -1,
            /// <summary>
            /// 扫描成功
            /// </summary>
            Successful = 0,
            /// <summary>
            /// 超出物料计划扫描数量，扫描失败
            /// </summary>
            Overflow = 1,
            /// <summary>
            /// 分盘数量不等于锁定数量
            /// </summary>
            PartCountError = 2,
            /// <summary>
            /// 子盘已扫描
            /// </summary>
            PartSubReScan = 3,
            /// <summary>
            /// 所扫库位非指导库位
            /// </summary>
            NotExpectedLoc = 4,
            /// <summary>
            /// 超出整盘数量
            /// </summary>
            OverflowFullDisk = 5,
            /// <summary>
            /// 新批次错误
            /// </summary>
            NotExpectedLot=6
        }

        public static string ScanInfoMessage(ScanInfo info)
        {
            switch (info)
            {
                case ScanInfo.Successful:
                    return string.Empty;
                case ScanInfo.ScanError:
                    return "扫描失败，请重试！";
                case ScanInfo.NotInLoc:
                    return "该料盘对应库位错误，扫描失败！";
                case ScanInfo.NotInBill:
                    return "该料盘不在本次扫描计划中！";
                case ScanInfo.NotScan:
                    return "该料盘未扫描，不能撤消！";
                case ScanInfo.RepeatScan:
                    return "该料盘已扫描，不能重复扫描！";
                case ScanInfo.Underflow:
                    return "超出物料已扫描数量，不能撤消！";
                case ScanInfo.Overflow:
                    return "超出物料计划扫描数量，扫描失败！";
                case ScanInfo.PartCountError:
                    return "分盘数量与锁定数量不一致！";
                case ScanInfo.PartSubReScan:
                    return "该子盘已扫描，扫描失败！";
                case ScanInfo.NotExpectedLoc:
                    return "所扫库位非指导库位";
                case ScanInfo.OverflowFullDisk:
                    return "超出可扫整盘数量！";
                case ScanInfo.NotExpectedLot:
                    return "新批次号错误！";
                default:
                    return string.Empty;
            }
        }
        public static string ScanInfoMessage(ScanInfo info, bool isUndo)
        {
            if (isUndo && info == ScanInfo.Successful)
            {
                return "撤消成功！";
            }
            return ScanInfoMessage(info);
        }
        /// <summary>
        /// 当前操作类型
        /// </summary>
        [Flags()]
        public enum ActionType
        {
            /// <summary>
            /// 收货
            /// </summary>
            ASN = 1,
            /// <summary>
            /// 上架
            /// </summary>
            PutAway = 2,
            /// <summary>
            /// 操作库位
            /// </summary>
            Loc = 4,
            /// <summary>
            /// 拣货
            /// </summary>
            Pick = 8,
            /// <summary>
            /// 分盘
            /// </summary>
            Part = 16,
            /// <summary>
            /// 退料
            /// </summary>
            Return = 32,
            /// <summary>
            /// 公共（拆封、烧烤开始、结束）
            /// </summary>
            Common = 64,
            /// <summary>
            /// 移库
            /// </summary>
            MoveLoc = 128,
            /// <summary>
            /// 移储
            /// </summary>
            MoveLot=256,
        }
    }
}
