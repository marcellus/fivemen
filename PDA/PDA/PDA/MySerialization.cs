using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace PDA
{
    public interface IMySerializable
    {
        void UpdateDataSource();
        DataSet GetDataSource();
    }
    public class MySerialization
    {
        public static void Serialize(IMySerializable sourceObject, string filePath)
        {
            if (sourceObject == null) { throw new Exception("待序列化对象为空！"); }
            if (string.IsNullOrEmpty(filePath)) { throw new Exception("文件路径为空！"); }
            try
            {
                sourceObject.UpdateDataSource();
                DataSet ds = sourceObject.GetDataSource();
                FileInfo fi = new FileInfo(filePath);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                if (fi.Exists)
                {
                    DataSet dsOld = DeSerialize(filePath);
                    for (int i = 0; i < dsOld.Tables.Count; i++)
                    {
                        if (ds.Tables.Count > i)
                        {
                            foreach (DataRow dr in ds.Tables[i].Rows)
                            {
                                DataRow drOld = dsOld.Tables[i].NewRow();
                                drOld.ItemArray = (object[])dr.ItemArray.Clone();
                                dsOld.Tables[i].Rows.Add(drOld);
                            }
                        }
                    }
                    ds = dsOld;
                }
                ds.WriteXml(filePath, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                Exception e = new Exception("写入文件失败！", ex);
                throw e;
            }
        }
        public static DataSet DeSerialize(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) { throw new Exception("文件路径为空！"); }
            try
            {
                DataSet ds = new DataSet();
                FileInfo fi = new FileInfo(filePath);
                if (!fi.Exists) { throw new Exception("文件已被删除！"); }
                ds.ReadXml(filePath, XmlReadMode.ReadSchema);
                fi.CopyTo(filePath + ".bak", true);
                fi.Delete();
                return ds;
            }
            catch (Exception ex)
            {
                Exception e = new Exception("读取文件失败！", ex);
                throw e;
            }
        }
    }
}
