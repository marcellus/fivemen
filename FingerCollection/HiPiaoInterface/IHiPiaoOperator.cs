using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    public interface IHiPiaoOperator
    {

        bool CheckUserName(string name);
        bool CheckMobile(string mobile);

        TicketPrintObject GetTicket(string mobile, string valid);
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="uid">用户姓名</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        UserObject Login(string uid, string pwd);

        bool UpdatePwd(UserObject user, string newPwd);

        TicketObject BuyTicket(UserObject user,CinemaObject cinema, MovieObject movie,DateTime playTime);

        UserObject Register(string uid, string pwd, string mobile);

        ReturnObject PrintTicket(UserObject user, TicketObject ticket);


    }
}
