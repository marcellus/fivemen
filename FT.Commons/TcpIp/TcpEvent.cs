using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Commons.TcpIp
{
   /// <summary> 
    /// ����ͨѶ�¼�ģ��ί�� 
    /// </summary> 
    public delegate void TcpEvent(object sender, TcpEventArgs e); 

    /// <summary> 
    /// ������������¼�����,�����˼������¼��ĻỰ���� 
    /// </summary> 
    public class TcpEventArgs : EventArgs
    {

        #region �ֶ�

        /// <summary> 
        /// �ͻ����������֮��ĻỰ 
        /// </summary> 
        private Customer _client;

        #endregion

        #region ���캯��
        /// <summary> 
        /// ���캯�� 
        /// </summary> 
        /// <param name="client">�ͻ��˻Ự</param> 
        public TcpEventArgs(Customer client)
        {
            if (null == client)
            {
                throw (new ArgumentNullException());
            }

            _client = client;
        }
        #endregion

        #region ����

        /// <summary> 
        /// ��ü������¼��ĻỰ���� 
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
