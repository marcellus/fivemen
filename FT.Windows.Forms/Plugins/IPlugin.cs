using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms;

namespace FT.Windows.Forms.Plugins
{
    /// <summary>
    /// ����ӿ�
    /// </summary>
    public interface IPlugin:IAppUnit
    {
        /// <summary>
        /// ע�뵽��������
        /// </summary>
        /// <param name="form">�����壬����toolstrip��menustrip��statusstrip��basetabcontrol</param>
        void Emmit(BaseMainForm form);

        /// <summary>
        /// �����ʼ������Ҫ�Ǽ���Ƿ�������ݿ�����û�о�ִ�д���
        /// </summary>
        void Init();
    }
}
