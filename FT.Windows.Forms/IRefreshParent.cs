using System;
using System.Collections.Generic;
using System.Text;

namespace FT.Windows.Forms
{
    /// <summary>
    /// ˢ�¸���Ľӿڣ���Ҫ���޸ĺ���ӵ�ʱ��ˢ�¸��ര�ڻ������
    /// Ҳ����ѯʱ�����ò�ѯ������
    /// </summary>
    public interface IRefreshParent
    {
        /// <summary>
        /// ����һ��ʵ�嵽���ര��
        /// </summary>
        /// <param name="entity"></param>
        void Update(object entity);
        /// <summary>
        /// ���һ��ʵ�嵽���ര��
        /// </summary>
        /// <param name="entity"></param>
        void Add(object entity);
        /// <summary>
        /// ���ò�ѯ�������
        /// </summary>
        /// <param name="conditions"></param>
        void SetConditions(string conditions);
    }
}
