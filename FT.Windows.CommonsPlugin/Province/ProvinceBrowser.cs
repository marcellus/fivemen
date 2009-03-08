using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Windows.Forms;
using System.Collections;

namespace FT.Windows.CommonsPlugin
{
    public partial class ProvinceBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public ProvinceBrowser()
        {
            InitializeComponent();
        }
        #region �������ʵ�ֵ�
        public ProvinceBrowser(object entity):base(entity)
        {
            InitializeComponent();
            
           
        }
        public ProvinceBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            
        }

       

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new Province();
            //   return null;
        }
        #endregion

        private void txtText_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "ʡ�����Ʋ���Ϊ�գ�");
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "ʡ�ݴ��벻��Ϊ�գ�");
        }
    }
}

