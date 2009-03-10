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
        /// 保存的时候会自动更新到缓存中
        /// </summary>
        public void SaveConfig()
        {
            T config = StaticCacheManager.GetConfig<T>();
            FormHelper.GetDataFromForm(this.parent, config);
            StaticCacheManager.SaveConfig<T>(config);

        }


        /// <summary>
        /// 从缓存中载入，如果没有就先从配置文件中载入
        /// </summary>
        public void Load()
        {
            
            T config = StaticCacheManager.GetConfig<T>();
            FormHelper.SetDataToForm(this.parent, config);
            
        }

    }
}
