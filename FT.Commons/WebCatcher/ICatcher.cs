using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FT.Commons.WebCatcher
{
    /// <summary>
    /// ����ӿ�
    /// </summary>
    public interface ICatcher
    {
        #region ��Ҫ�Ľӿ�
        /// <summary>
       /// ��ȡ��Ҫ�����url����
       /// </summary>
       /// <returns>url������߿�</returns>
       List<string> GetUrls();

        /// <summary>
        /// һ�ν���,Ҳ��Ҫ��ҳ
        /// </summary>
        void ParseOne();

        /// <summary>
        /// ��½����cookie
        /// </summary>
        void LoginGenerateCookie();

        /// <summary>
        /// ��½
        /// </summary>
        void Login();

        #endregion

        #region ͳ��ʹ��
        /// <summary>
        /// ��ȡ�����ĸ���
        /// </summary>
        /// <returns>�ܹ��Ľ�������</returns>
        int Count();

        /// <summary>
        /// �����ɹ��ĸ���
        /// </summary>
        /// <returns></returns>
        int Success();

        /// <summary>
        /// �����ɹ���url
        /// </summary>
        /// <returns>�����ɹ���url</returns>
        List<string> SuccessUrl();

        /// <summary>
        /// ����ʧ�ܵĸ���
        /// </summary>
        /// <returns></returns>
        int Error();

        /// <summary>
        /// ����ʧ�ܵ�url
        /// </summary>
        /// <returns>����ʧ�ܵ�url</returns>
        List<string> ErrorUrl();

        #endregion

        #region ��������

        /// <summary>
        /// �Ƿ��½�ɹ�
        /// </summary>
        bool IsLogin
        {
            get;
        }

        /// <summary>
        /// �Ƿ�ÿ�ζ���Ҫ��½
        /// </summary>
        bool LoginEveryTime
        {
            get;
        }

        string UserId
        {
            get;
            set;
        }
        string Pwd
        {
            get;
            set;
        }
        #endregion
    }
}
