using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FT.Commons.WebCatcher
{
    /// <summary>
    /// 捕获接口
    /// </summary>
    public interface ICatcher
    {
        #region 主要的接口
        /// <summary>
       /// 获取需要捕获的url数组
       /// </summary>
       /// <returns>url数组或者空</returns>
       List<string> GetUrls();

        /// <summary>
        /// 一次解析,也许要跨页
        /// </summary>
        void ParseOne(string url);

        /// <summary>
        /// 解析全部
        /// </summary>
        void Parse();


        /// <summary>
        /// 写日志到控制台
        /// </summary>
        /// <param name="str"></param>
        void WriteConsole(string str);

      
        /// <summary>
        /// 下载一个url的内容，比如一个网页，一个mp3
        /// </summary>
        /// <param name="url">下载地址</param>
        /// <returns>下载的相对路径</returns>
        string Download(string url);

        /// <summary>
        /// 登陆产生cookie
        /// </summary>
        void LoginGenerateCookie();

        /// <summary>
        /// 登陆
        /// </summary>
        void Login();

        #endregion

        #region 统计使用
        /// <summary>
        /// 获取解析的个数
        /// </summary>
        /// <returns>总共的解析个数</returns>
        int Count();

        /// <summary>
        /// 解析成功的个数
        /// </summary>
        /// <returns></returns>
        int Success();

        /// <summary>
        /// 解析成功的url
        /// </summary>
        /// <returns>解析成功的url</returns>
        List<string> SuccessUrl();

        /// <summary>
        /// 解析失败的个数
        /// </summary>
        /// <returns></returns>
        int Error();

        /// <summary>
        /// 解析失败的url
        /// </summary>
        /// <returns>解析失败的url</returns>
        List<string> ErrorUrl();

        #endregion

        #region 属性设置

        /// <summary>
        /// 是否登陆成功
        /// </summary>
        bool IsLogin
        {
            get;
        }

        /// <summary>
        /// 是否每次都需要登陆
        /// </summary>
        bool LoginEveryTime
        {
            get;
        }

        string UserId
        {
            get;
            
        }
        string Pwd
        {
            get;
           
        }
        #endregion
    }
}
