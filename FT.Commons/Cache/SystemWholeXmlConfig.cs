using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace FT.Commons.Cache
{
    /// <summary>
    /// 系统全局的xml系统参数配置
    /// </summary>
    [Serializable]
    public class SystemWholeXmlConfig : ISerializable
    {
        public SystemWholeXmlConfig()
        {

        }
         #region ISerializable 成员

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("Key", Key);
            info.AddValue("Value", Value);
            info.AddValue("Description", Description);
            info.AddValue("Valid", Valid);
        }


        protected SystemWholeXmlConfig(SerializationInfo info, StreamingContext context)
        {
            this.Id = info.GetInt32("Id");
            this.Key = info.GetString("Key");
            this.Value = info.GetString("Value");
            this.Description = info.GetString("Description");
            this.Valid = info.GetInt32("Valid");
        }

        #endregion
        private int id;

        /// <summary>
        ///  参数的索引ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string key;

        /// <summary>
        /// 参数的关键字，格式如System_DrvHelperSystem_Default_Glbm
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        private string value;

        /// <summary>
        /// 对应key的参数具体值
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int valid;

        /// <summary>
        /// 参数是否有效，0无效，1有效
        /// </summary>
        public int Valid
        {
            get { return valid; }
            set { valid = value; }
        }
    }
}
