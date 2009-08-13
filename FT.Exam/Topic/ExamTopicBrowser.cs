using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms;

namespace FT.Exam
{
    public partial class ExamTopicBrowser : FT.Windows.Forms.DataBrowseForm
    {
       public ExamTopicBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region �������ʵ�ֵ�
        public ExamTopicBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public ExamTopicBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("key");
                dt.Columns.Add("value");
                dt.Rows.Add(new string[] { "1", "1:�ж���" });
                dt.Rows.Add(new string[] { "2", "2:ѡ����" });
                this.cbTopicTypeValue.DataSource = dt;
                this.cbTopicTypeValue.DropDownStyle = ComboBoxStyle.DropDown;
                this.cbTopicTypeValue.ValueMember = "key";
                this.cbTopicTypeValue.DisplayMember = "value";
            }
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new ExamTopic();
            
        }
        #endregion
    }
}

