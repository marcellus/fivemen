using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL;
using System.Collections;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Data.OleDb;
using FT.Windows.Forms.Domain;

namespace Vehicle.Plugins
{

    /// <summary>
    /// Description:
    /// 类描述 部门管理类
    /// </summary>
    public class VehiclePhotoAccess
    {

        public object ExecuteScalar(string sql)
        {
            return access.SelectScalar(sql);
        }

        private IDataAccess access;

        /// <summary>
        /// 设置数据源来源的IDataAccess对象,子类可覆盖
        /// </summary>
        /// <value>The access.</value>
        protected virtual IDataAccess Access
        {
            get { return access; }
            set { access = value; }
        }

        public VehiclePhotoAccess()
        {
            this.access = DataAccessFactory.GetDataAccess();
        }

        public string GetXuHao()
        {
            CompanyInfo info = FT.Commons.Cache.StaticCacheManager.GetConfig<CompanyInfo>();
            object obj=this.access.SelectScalar("select max(xuhao) from table_vehicle_photo");
            if (obj == null||Convert.IsDBNull(obj))
            {
                return info.No + "00001";
            }
            else
            {
                string no = obj.ToString();
                int i=Convert.ToInt32(no.Substring(no.Length-5,5));
                i++;
                return info.No+string.Format("{0:00000}", i);
            }
        }

        /// <summary>
        /// 增加一个车辆照片信息
        /// </summary>
        /// <param name="info">车辆照片信息</param>
        /// <returns>是否成功增加</returns>
        public bool Add(VehiclePhoto info)
        {
            info.XuHao = this.GetXuHao();
            string sql = "insert into table_vehicle_photo(cn_classical,cn_type,suffix,xuhao) values('" +
                DALSecurityTool.TransferInsertField(info.Cn_Classical) + "','" +
                DALSecurityTool.TransferInsertField(info.Cn_Type) + "','" +
                DALSecurityTool.TransferInsertField(info.Suffix) + "','" +
                DALSecurityTool.TransferInsertField(info.XuHao) + "')";
            return this.access.ExecuteSql(sql);

        }

        public bool UpdateImage(string id, Image image)
        {
            MemoryStream s = new MemoryStream();
            image.Save(s, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] b = s.ToArray();
            string sql = "update table_vehicle_photo set picture=@pic where id=" + id;
            OleDbParameter par = new OleDbParameter("@pic", OleDbType.Binary);
            par.Value = b;
            return DataAccessFactory.GetDataAccess().ExecuteSqlByParam(sql, par);

        }
        /// <summary>
        /// 删除一个车辆照片并把对应的登记信息关联改为null
        /// </summary>
        /// <param name="info">车辆照片信息</param>
        /// <returns>是否成功</returns>
        public bool Delete(VehiclePhoto info)
        {
            string[] array = new string[1];
            array[0] = "delete from table_vehicle_photo where id=" + info.Id;
            //array[1] = "update cardetail where photoid=" + info.Id;
            return this.access.ExecuteTransaction(array);
        }

        /// <summary>
        /// 获取最新加入的table_vehicle_photo对象
        /// </summary>
        /// <returns></returns>
        public VehiclePhoto GetLasted()
        {
            string sql = "select top 1 id,cn_classical,cn_type,picture,suffix,xuhao from table_vehicle_photo order by id desc";
            DataTable dt = this.access.SelectDataTable(sql, "table_vehicle_photo");
            if (dt != null && dt.Rows.Count == 1)
            {
                return GetFromDataRow(dt.Rows[0]);

            }
            return null;
        }

        public ArrayList SearchList(string condition)
        {
            ArrayList list = new ArrayList();
            string sql = "select id,cn_classical,cn_type,picture,suffix,xuhao from table_vehicle_photo " + condition + " order by cn_classical,cn_type";
            DataTable dt = this.access.SelectDataTable(sql, "table_vehicle_photo");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(VehiclePhotoAccess.GetFromDataRow(dr));
                }
            }
            return list;
        }


        /// <summary>
        /// 从DataRow生成一个table_vehicle_photo对象
        /// </summary>
        /// <param name="dr">DataRow对象</param>
        /// <returns>一个table_vehicle_photo对象</returns>
        private static VehiclePhoto GetFromDataRow(DataRow dr)
        {
            VehiclePhoto temp = new VehiclePhoto();
            temp.Id = dr["id"].ToString();
            temp.Cn_Classical = dr["cn_classical"].ToString();
            temp.Cn_Type = dr["cn_type"].ToString();
            temp.Suffix = dr["suffix"].ToString();
            temp.XuHao = dr["xuhao"].ToString();
            if (dr["picture"] != null && !(dr["picture"] is DBNull))
            {
                byte[] by = (byte[])dr["picture"];

                MemoryStream mss = new MemoryStream(by);

                temp.Picture = Image.FromStream(mss);
            }
            return temp;

        }

    }
}
