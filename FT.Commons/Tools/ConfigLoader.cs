using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FT.Commons.Cache;

namespace FT.Commons.Tools
{
    public class ConfigLoader<T>
    {
        private Form parent;
        
        public ConfigLoader(Form form)
        {
            this.parent=form;
            this.parent.Load += new EventHandler(parent_Load);
        }

        void parent_Load(object sender, EventArgs e)
        {
            Load();
        }

        protected string GetConfigFileName()
        {
            return typeof(T).Name;
        }

        /// <summary>
        /// �����ʱ����Զ����µ�������
        /// </summary>
        public void SaveConfig()
        {
            T config = StaticCacheManager.GetConfig<T>();
            FormHelper.GetDataFromForm(this.parent, config);
            StaticCacheManager.SaveConfig<T>(config);

        }


        /// <summary>
        /// �ӻ��������룬���û�о��ȴ������ļ�������
        /// </summary>
        public void Load()
        {
            
            T config = StaticCacheManager.GetConfig<T>();
            FormHelper.SetDataToForm(this.parent, config);
            
        }

    }
}
