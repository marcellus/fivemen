using System;
using System.Collections.Generic;
using System.Text;

namespace FT.WebServiceInterface.DrvQuery
{
    public class TestLog

    {
        public static int counter = 1;

        public static void LogStep()
        {
            string sql = "";
            if(counter==1)
            {
                sql = "update table_yuyue_info set c_check_result='" + FT.DAL.DALSecurityTool.TransferInsertField(counter.ToString()) + "' where id=993 ";

            }
            else
            {

                sql = "update table_yuyue_info set c_check_result=c_check_result||'" + FT.DAL.DALSecurityTool.TransferInsertField(counter.ToString()) + "&' where id=993 ";
            }
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);

        }

        public static void Log(string detail)
        {

            string sql = "";
            sql = "update table_yuyue_info set c_check_result='" + FT.DAL.DALSecurityTool.TransferInsertField(detail) + "' where id=992 ";
            
            FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
        }
    }
}
