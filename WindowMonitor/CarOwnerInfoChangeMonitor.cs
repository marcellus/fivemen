using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Forms.Monitor;
using System.Windows.Forms;
using FT.Windows.Forms.Monitor;
using FT.DAL;
using System.Data;
using FT.WebServiceInterface.WebService;

namespace WindowMonitor
{
    public class CarOwnerInfoChangeMonitor : BaseMonitor
    {
        protected override void DoTask()
        {
            string sql = "select c_cjh,c_fdjh,c_djzs,c_hmhp,c_hpzl,c_old_phone,c_new_phone,c_new_address,c_new_postcode,c_email from table_person_change_info where i_syn=0";
            DataTable dt = DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmpdb");
            string logstr = string.Empty;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DrvPresonInfoChangeRequest request = new DrvPresonInfoChangeRequest();
                    request.sfzmhm = dt.Rows[i][0] == null ? "" : dt.Rows[i][0].ToString();
                    request.lxdh = dt.Rows[i][1] == null ? "" : dt.Rows[i][1].ToString();
                    request.yzbm = dt.Rows[i][2] == null ? "" : dt.Rows[i][2].ToString();
                    request.lxzs = dt.Rows[i][3] == null ? "" : dt.Rows[i][3].ToString();
                    request.sjhm = dt.Rows[i][4] == null ? "" : dt.Rows[i][4].ToString();
                    request.dzyx = dt.Rows[i][5] == null ? "" : dt.Rows[i][5].ToString();
                    logstr = "正在处理身份证号码为:" + request.sfzmhm + "的信息本案变更！";
                    this.SetHintText(logstr);
                    this.CreateLog(logstr);
                    TmriResponse response = DriverInterface.WritePersonInfoChange(request);
                    if (response.Code == 0)
                    {
                        logstr = "成功处理身份证号码：" + request.sfzmhm;
                        this.SetHintText(logstr);
                        this.CreateLog(logstr);

                    }
                    else
                    {
                        logstr = "失败处理身份证号码：" + request.sfzmhm + ";code:" + response.Code;
                        this.SetHintText(logstr);
                        this.CreateLog(logstr);
                    }
                }

            }
        }
        public CarOwnerInfoChangeMonitor(NotifyIcon icon, int interval, string monitor)
            : base(icon, interval, monitor)
        {
           
        }
    }
}
