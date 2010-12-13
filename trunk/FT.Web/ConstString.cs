using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Web
{
    public class ConstString
    {
        /***************************************************************
                             Dictionary Tables 
        ***************************************************************/

        #region 物品管理模块所需要的类型定义
        public const int FactoryType = 200;//操作供应商类别
        public const int DepartmentType = 201;//操作部门类型
        public const int StoreType = 300;//操作库存
        public const int Add = 0;//增加的日志类型
        public const int Delete = 1;//删除的日志类型
        public const int Update = 2;//修改的日志类型
        public const int OpComplete = 0;//操作完成
        public const int OpFailed = 1;//操作失败
        #endregion 

        /***************************************************************
                          The End Of Dictionary Tables 
        ***************************************************************/


        /***************************************************************
                             Page Rights
        ***************************************************************/

        #region 物品管理模块中的权限定义
        public const int OnlyCanSeeSelf = 200;//查看本地物品
        public const int OnlyCanSeeAll = 201;//查看全部物品
        public const int CanUpdateSelf = 202;//修改本地物品 暂无用
        public const int CanUpdateAll = 203;//修改全部物品  暂无用
        public const int TypeManage = 204;//类型管理权限
        public const int StoreTypeManage=205;//库存物品类型管理
        public const int StoreManage = 206;//库存管理
        public const int FactoryManage = 207;//厂商管理
        public const int StoreEdit = 208;//物资管理-库存管理的增、删和修改权限
        public const int MessageManage = 501;//留言管理
        public const int NewsManage = 100;//新闻管理
        public const int TypeResume = 602;//简历管理
        public const int TypePosition = 601;//职位管理
        public const int BackManage = 400;//后台管理
        public const int RoleManage = 401;//角色管理
        public const int UserManage = 402;//人员管理
        public const int Anounct = 800;//公告管理
        public const int Link = 801;//连接管理
        public const int DBManage = 802;//数据库管理
        public const int Project = 803;//工程管理
        public const int FileManage = 804;//fck上传文件管理

        public const int EMail = 900;//拥有EMail

      

        #endregion 

        /***************************************************************
                          The End Of Page Rights 
        ***************************************************************/

        #region 报表头数组
        public static  string[] FactoryReportHeader=new string[]{"编号","分类","厂商名称","地址","联系人","联系电话","备注"};
        #endregion
    }
}
