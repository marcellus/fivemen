using System;
using System.Collections.Generic;
using System.Text;
using FT.DAL.Oracle;
using FT.DAL;
using System.Data;

namespace FT.WebServiceInterface.DrvQuery
{
    public class ZhZwQueryHelper
    {

        public static DataTable GetDataTable(string idcard)
        {
            string sql = "select t.*,decode(lesson_finish,0,'未完成',1,'已完成') lesson_result,decode(train_finish,0,'未完成',1,'已完成') train_result from fp_student t ";
            sql += " where idcard='" + idcard + "'";
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
            if (dt != null && dt.Rows.Count == 1)
            {
                string sql2 = "select idcard,type from FP_APPROVE where idcard='"+idcard+"'";
                DataTable dt2 = DataAccessFactory.GetDataAccess().SelectDataTable(sql2, "tmp");
                if (dt2 != null)
                {
                    DataRow dr = null;
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        dr = dt2.Rows[i];
                        if (dr["type"].ToString() == "上课")
                        {
                            dt.Rows[0]["lesson_result"] = "已完成";
                        }
                        else if (dr["type"].ToString() == "入场训练")
                        {
                            dt.Rows[0]["train_result"] = "已完成";
                        }
                    }
                }
            }

            return dt;
        }
    }

    
}
