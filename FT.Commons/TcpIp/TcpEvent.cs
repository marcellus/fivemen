using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.TcpIp
{
   /// <summary> 
    /// 网络通讯事件模型委托 
    /// </summary> 
    public delegate void TcpEvent(object sender, TcpEventArgs e); 

    /// <summary> 
    /// 服务器程序的事件参数,包含了激发该事件的会话对象 
    /// </summary> 
    public class TcpEventArgs : EventArgs
    {

        #region 字段

        /// <summary> 
        /// 客户端与服务器之间的会话 
        /// </summary> 
        private Customer _client;

        #endregion

        #region 构造函数
        /// <summary> 
        /// 构造函数 
        /// </summary> 
        /// <param name="client">客户端会话</param> 
        public TcpEventArgs(Customer client)
        {
            if (null == client)
            {
                throw (new ArgumentNullException());
            }

            _client = client;
        }
        #endregion

        #region 属性

        /// <summary> 
        /// 获得激发该事件的会话对象 
        /// </summary> 
        public Customer Client
        {
            get
            {
                return _client;
            }

        }

        #endregion
    }
}
