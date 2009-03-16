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

namespace Vehicle.Plugins
{

    /// <summary>
    /// Description:
    /// ������ ���Ź�����
    /// </summary>
    public class VehiclePhotoAccess
    {



        private IDataAccess access;

        /// <summary>
        /// ��������Դ��Դ��IDataAccess����,����ɸ���
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

        /// <summary>
        /// ����һ��������Ƭ��Ϣ
        /// </summary>
        /// <param name="info">������Ƭ��Ϣ</param>
        /// <returns>�Ƿ�ɹ�����</returns>
        public bool Add(VehiclePhoto info)
        {
            string sql = "insert into table_vehicle_photo(cn_classical,cn_type,suffix) values('" +
                DALSecurityTool.TransferInsertField(info.Cn_Classical) + "','" +
                DALSecurityTool.TransferInsertField(info.Cn_Type) + "','" +
                DALSecurityTool.TransferInsertField(info.Suffix) + "')";
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
        /// ɾ��һ��������Ƭ���Ѷ�Ӧ�ĵǼ���Ϣ������Ϊnull
        /// </summary>
        /// <param name="info">������Ƭ��Ϣ</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public bool Delete(VehiclePhoto info)
        {
            string[] array = new string[1];
            array[0] = "delete from table_vehicle_photo where id=" + info.Id;
            //array[1] = "update cardetail where photoid=" + info.Id;
            return this.access.ExecuteTransaction(array);
        }

        /// <summary>
        /// ��ȡ���¼����table_vehicle_photo����
        /// </summary>
        /// <returns></returns>
        public VehiclePhoto GetLasted()
        {
            string sql = "select top 1 id,cn_classical,cn_type,picture,suffix from table_vehicle_photo order by id desc";
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
            string sql = "select id,cn_classical,cn_type,picture,suffix from table_vehicle_photo " + condition + " order by cn_classical,cn_type";
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
        /// ��DataRow����һ��table_vehicle_photo����
        /// </summary>
        /// <param name="dr">DataRow����</param>
        /// <returns>һ��table_vehicle_photo����</returns>
        private static VehiclePhoto GetFromDataRow(DataRow dr)
        {
            VehiclePhoto temp = new VehiclePhoto();
            temp.Id = dr["id"].ToString();
            temp.Cn_Classical = dr["cn_classical"].ToString();
            temp.Cn_Type = dr["cn_type"].ToString();
            temp.Suffix = dr["suffix"].ToString();
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
