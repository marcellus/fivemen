using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Windows.Forms.NoUser;
using FT.Commons.Cache;
using FT.Windows.Forms.SimpleLog;
using FT.Commons.Tools;
using System.IO;
using System.Text.RegularExpressions;
using log4net;
using System.Xml;
using FT.Windows.ExternalTool;
using FingerMonitor.Config;
using FT.DAL.Orm;
using FT.DAL.Oracle;
using FT.DAL;
using FT.DAL.Access;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.OracleClient;

namespace FingerMonitor
{
    public partial class Form1 : Form
    {
        protected static ILog log = log4net.LogManager.GetLogger("FT.Commons.Tools");
        //protected static ILog log = log4net.LogManager.GetLogger("tools");

        /// <summary>
        /// 调试日志
        /// </summary>
        /// <param name="obj"></param>
        protected static void Debug(object obj)
        {
            if (log != null && log.IsDebugEnabled)
            {
                log.Debug(obj);
            }
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="obj"></param>
        protected static void Info(object obj)
        {
            if (log != null && log.IsInfoEnabled)
            {
                log.Info(obj);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnActivated(EventArgs e)
        {
            this.Hide();
        }

        public const string OptUserConst = "指纹导入工具";

       

      
        public void ImportFinger(SystemConfig config)
        {
            bool isSuccess = true;

            string tmp = "找到监控目录，进行指纹导入！";
            this.CreateLog(tmp);
            this.SetHintText(tmp);

            IDataAccess accessOracle = new OracleDataHelper(config.TnsName, config.OraUser, config.OraPwd);
            DirectoryInfo dir = new DirectoryInfo(config.MonitorPath);
            DirectoryInfo[] dirsub = dir.GetDirectories();
            DirectoryInfo dirTmp = null;
            IDataAccess accessAccess = null;
            for (int k = 0; k < dirsub.Length; k++)
            {
                dirTmp = dirsub[k];
                accessAccess = new AccessDataHelper(dirTmp.FullName + "//db.mdb", "Admin", "");
                string sql = "select * from table_local_finger_record";
                DataTable dtUser = accessAccess.SelectDataTable(sql, "uploaduser");
                sql = "select * from USER_INFO_UPLOAD";
                DataTable dtUserInfo = accessAccess.SelectDataTable(sql, "USER_INFO_UPLOAD");
                sql = "select * from ENROLL_TEMP_UPLOAD";
                DataTable dtFingerInfo = accessAccess.SelectDataTable(sql, "ENROLL_TEMP_UPLOAD");

                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    DataRow dr;
                    string idcard;

                    for (int i = 0; i < dtUserInfo.Rows.Count; i++)
                    {

                        dr = dtUserInfo.Rows[i];
                        idcard = dr["USER_ID"].ToString();
                        this.CreateLog("正在处理用户信息" + idcard);
                        this.SetHintText("正在处理用户信息" + idcard);
                        sql = "insert into USER_INFO(USER_ID,MODIFY_TIME,CREATE_TIME)"
                        + " values('" +
                           dr["USER_ID"] + "','" +
                            dr["MODIFY_TIME"] + "','" +
                           dr["CREATE_TIME"] + "')";
                        if (accessOracle.ExecuteSql(sql))
                        {
                            accessAccess.ExecuteSql("delete from USER_INFO_UPLOAD where USER_ID='" + idcard + "'");
                        }
                        else
                        {
                            //已经存在该用户信息
                            accessAccess.ExecuteSql("delete from USER_INFO_UPLOAD where USER_ID='" + idcard + "'");
                        }



                    }
                    for (int i = 0; i < dtFingerInfo.Rows.Count; i++)
                    {

                        dr = dtFingerInfo.Rows[i];
                        idcard = dr["USER_ID"].ToString();
                        this.SetHintText("正在处理指纹信息" + idcard);
                        sql = "insert into enroll_temp(USER_ID,AUTHEN_INFO,VERSION,SERVICE_TYPE,SERVICE_CODE,REVOKE_TIME"
                        + ",TEMP_TYPE,TEMP_SIZE,TEMPLATE,CREATE_TIME,MODIFY_TIME)"
                        + " values('" +
                         dr["USER_ID"]
                        + "','" +
                         dr["AUTHEN_INFO"] + "'," +
                          dr["VERSION"] + "," +
                           dr["SERVICE_TYPE"] + "," +
                            dr["SERVICE_CODE"] + ",'" +
                             dr["REVOKE_TIME"] + "'," +
                              dr["TEMP_TYPE"] + "," +
                               dr["TEMP_SIZE"] + ",:TEMPLATE,'" +
                                 dr["CREATE_TIME"] + "','" +
                                  dr["MODIFY_TIME"] + "')";
                        byte[] expbyte = (byte[])dr["TEMPLATE"];
                        DbParameter param = new OracleParameter("TEMPLATE", System.Data.OracleClient.OracleType.Blob, expbyte.Length);
                        //DbParameter param = new OleDbParameter();
                        //param.ParameterName="TEMPLATE";

                        //param.DbType=System.Data.OleDb.OleDbType.Binary;
                        // param.DbType = System.Data.OracleClient.OracleType.Blob;
                        // param.Size=expbyte.Length;
                        param.Value = expbyte;


                        if (accessOracle.ExecuteSqlByParam(sql, param))
                        // if (accessOracle.ExecuteSql(sql))
                        {
                            accessAccess.ExecuteSql("delete from ENROLL_TEMP_UPLOAD where USER_ID='" + idcard + "'");
                        }
                        else
                        {
                            //已经存在该用户指纹信息
                            accessAccess.ExecuteSql("delete from ENROLL_TEMP_UPLOAD where USER_ID='" + idcard + "'");
                        }

                    }



                    //进行数据插入到fp_student中
                    int reNum = 0;
                    string schoolName = "";

                    for (int i = 0; i < dtUser.Rows.Count; i++)
                    {


                        dr = dtUser.Rows[i];
                        if (dr["c_lsh"] == null || string.IsNullOrEmpty(dr["c_lsh"].ToString())) continue;
                        schoolName = dr["c_school_name"].ToString();
                        sql = string.Format("insert into fp_student(idcard,name,school_code,school_name,localtype,car_type,lsh) " +
                                           "values ('{0}','{1}','{2}','{3}',{4},'{5}','{6}')"
                                           , dr["c_idcard"]
                                           , dr["c_name"]
                                           , dr["c_school_code"]
                                           , dr["c_school_name"]
                                           , dr["c_student_type"]
                                           , dr["c_car_type"]
                                           , dr["c_lsh"]
                                           );

                        // sql = "insert into fp_student(idcard,name)"
                        // + " values('" +
                        //   dr["c_idcard"] + "','" +
                        //驾校名称
                        // dr["c_school_name"] + "','" +
                        //驾校代码
                        //dr["c_school_code"] + "','" +
                        //学生类别
                        //dr["c_student_type"] + "','" +
                        //培训审核日期
                        //dr["c_pxrq"] + "','" +
                        //学习车型
                        //dr["c_car_type"] + "','" +
                        // dr["c_name"] + "','" +
                        //    dr["c_name"] + "')";
                        if (accessOracle.ExecuteSql(sql))
                        {

                            sql = string.Format("insert into table_upload_finger_record(c_idcard,c_name,c_school_code,c_school_name,c_student_type,c_car_type,c_lsh) " +
                              "values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')"
                                , dr["c_idcard"]
                                , dr["c_name"]
                                , dr["c_school_code"]
                                , dr["c_school_name"]
                                , dr["c_student_type"]
                                , dr["c_car_type"]
                                , dr["c_lsh"]
                              );

                            if (!accessAccess.ExecuteSql(sql))
                            {
                                // continue; 
                            }



                            sql = string.Format("delete from table_local_finger_record where c_idcard='{0}'", dr["c_idcard"]);
                            if (!accessAccess.ExecuteSql(sql))
                            {
                                //  continue; 
                            }

                            sql = string.Format("update table_local_finger_record set c_upload_time='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where c_idcard='{0}'", dr["c_idcard"]);

                            if (!accessAccess.ExecuteSql(sql))
                            {
                                // continue; 
                            }
                            //sql = string.Format("insert into table_upload_finger_record select * from  table_local_finger_record where c_idcard='{0}'", dr["c_idcard"]);



                            reNum++;
                        }



                    }
                    if (reNum > 0)
                    {
                        MessageBoxHelper.Show(string.Format("{0}  导入 {1} {2}条指纹记录", DateTime.Now.ToString(), schoolName, reNum));
                        this.SetHintText("处理完毕！");
                        this.CreateLog("导入指纹完毕！");
                    }


                }
            }
            
            


           

        }

        private String GetTextInXml(string xml, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode node = doc.SelectSingleNode(xpath);
            if (node != null)
            {
                return node.InnerText;
            }
            return string.Empty;
        }

        public void SetHintText(String str)
        {
            this.notifyIcon1.Text = "驾驶人指纹上传监控软件-" + str;
        }

        /// <summary>
        /// 是否接口有效
        /// </summary>
        private bool InterfaceEnabled = true;

        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (this.InterfaceEnabled)
            {
                SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
                if (FileHelper.CheckDirExists(config.MonitorPath))
                {
                    this.ImportFinger(config);
                }
                else
                {

                }

                timer1.Start();
            }

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = "<?xml version=\"1.0\" encoding=\"GBK\" ?> "
+ "<response><head><code>integer</code>"
+ "<message>String</message>"
+ "</head>"
+ "<body>"
+ "	    <rownum>int</rownum>"
+ "	    <item>"
 + "<hpzl>string</hpzl>"
 + "<hphm>string</hphm>"
 + "<zp>string</zp>"
+ "</item>"
+ "</body>"
+ "</response>";
            Console.WriteLine(this.GetTextInXml(str, "//code"));
            Console.WriteLine(this.GetTextInXml(str, "//message"));
            Console.WriteLine(this.GetTextInXml(str, "//body"));
            Console.WriteLine(this.GetTextInXml(str, "//rownum"));
            Console.WriteLine(this.GetTextInXml(str, "//zp"));

            Form form = new Form();
            Control editor = new FT.Windows.Controls.Editor();
            editor.Dock = DockStyle.Fill;
            form.Controls.Add(editor);
            form.Show();
        }

        private void 图片转换测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image2Base64Test form = new Image2Base64Test();
            form.ShowInTaskbar = true;
            form.ShowDialog();
        }

        private void 查看日志ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NoUserHelper.ShowLogs();
        }

        private void 清空日志ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NoUserHelper.ClearLogs();
        }

        private void 系统设置ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form form = new SystemConfigForm();
            form.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NoUserHelper.About();
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NoUserHelper.Quit();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();
            timer1.Interval = config.MonitorTimes;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            this.CreateLog("系统初启动");
        }

        public void CreateLog(string detail)
        {
            CustomLog log = new CustomLog();
            log.OptDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OptDetail = detail;
            log.OptUser = OptUserConst;
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
        }

        private void 指纹比对ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
