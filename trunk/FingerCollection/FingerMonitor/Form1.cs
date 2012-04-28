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
            SystemConfig config = StaticCacheManager.GetConfig<SystemConfig>();

        }

        protected override void OnActivated(EventArgs e)
        {
            this.Hide();
        }

        public const string OptUserConst = "指纹导入工具";

       

      
        public void ImportFinger(SystemConfig config)
        {
            bool isSuccess = true;

            //string tmp = "找到监控目录，进行指纹导入！";
            //this.CreateLog(tmp);
            //this.SetHintText(tmp);

            IDataAccess accessOracle = new OracleDataHelper(config.TnsName, config.OraUser, config.OraPwd);
            
            DirectoryInfo dir = new DirectoryInfo(config.MonitorPath);
            DirectoryInfo[] dirsub = dir.GetDirectories();
            DirectoryInfo dirTmp = null;
            FileInfo[] files=null;
            FileInfo file = null;
            IDataAccess accessAccess = null;
            //进行数据插入到fp_student中
            int reNum = 0;
            string schoolName = "";
            string lshs = "";
            for (int k = 0; k < dirsub.Length; k++)
            {
                dirTmp = dirsub[k];
                if (dirTmp.FullName.Contains("bakpath")) continue;
                files = dirTmp.GetFiles();
                for (int m = 0; m < files.Length; m++)
                {
                    reNum = 0;
                    file = files[m];
                    if (!file.FullName.EndsWith(".mdb")) continue;
                    SetHintText(string.Format("{0} 处理中...",file.Name));
                    accessAccess = new AccessDataHelper(file.FullName, "Admin", "");
                    string sql = "select * from table_local_finger_record";
                    DataTable dtUser = accessAccess.SelectDataTable(sql, "uploaduser");
                    //sql = "select * from USER_INFO_UPLOAD";
                    //DataTable dtUserInfo = accessAccess.SelectDataTable(sql, "USER_INFO_UPLOAD");
                    //sql = "select * from ENROLL_TEMP_UPLOAD";
                    // DataTable dtFingerInfo = accessAccess.SelectDataTable(sql, "ENROLL_TEMP_UPLOAD");

                    if (dtUser == null) continue;

                    //DataRow dr;
                    string idcard;
                    string schoolCode;
                    string carType;
                    string studentName;
                    int localType;
                    foreach (DataRow row in dtUser.Rows)
                    {
                        if (StringHelper.isNullOrBlank(row["c_idcard"])||StringHelper.isNullOrBlank (row["c_school_code"])|| 
                            StringHelper.isNullOrBlank( row["c_car_type"])||StringHelper.isNullOrBlank( row["c_student_type"])||
                            StringHelper.isNullOrBlank(row["c_name"])
                            )
                        {
                            string log = string.Format("学员:{0}资料不全,不能导入", row["c_idcard"]);
                            this.CreateLog(log);
                            continue;
                        }
                        idcard = row["c_idcard"].ToString().Trim();
                        schoolCode = row["c_school_code"].ToString().Trim();
                        carType = row["c_car_type"].ToString().Trim();
                        localType = Convert.ToInt16(row["c_student_type"].ToString());
                        schoolName = row["c_school_name"].ToString();
                        studentName=row["c_name"].ToString();
                        //if (row["c_lsh"] == null || string.IsNullOrEmpty(row["c_lsh"].ToString())) continue;
                        sql = string.Format("select * from fp_student_cleared where idcard='{0}' and school_code='{1}' and car_type='{2}' and localtype={3}", 
                            idcard
                            ,schoolCode
                            ,carType
                            ,localType
                        );
                        DataTable dtCleared = accessOracle.SelectDataTable(sql, "FP_STUDENT_CLEARED");
                        if (dtCleared != null && dtCleared.Rows.Count > 0) {
                            string log = string.Format("学员:{0}曾在 {1} 报考 {2} 车型,并已经完成课程 ,不能导入"
                             ,idcard   
                             ,schoolName
                             ,carType
                            );
                            this.CreateLog(log);
                            continue;
                        }
                        sql = string.Format("select * from USER_INFO_UPLOAD where USER_ID='{0}'", idcard);
                        DataTable dtUserInfoOne = accessAccess.SelectDataTable(sql, "USER_INFO_UPLOAD");
                        sql = string.Format("select * from ENROLL_TEMP_UPLOAD where USER_ID='{0}'", idcard);
                        DataTable dtFingerInfoOne = accessAccess.SelectDataTable(sql, "ENROLL_TEMP_UPLOAD");
                        if (dtUserInfoOne == null || dtUserInfoOne.Rows.Count == 0 || dtFingerInfoOne == null || dtFingerInfoOne.Rows.Count == 0)
                        {
                            string log = string.Format("{1} 学员:{0}缺少指纹数据 ,不能导入"
                             , idcard
                             , schoolName
                             , carType
                            );
                            this.CreateLog(log);
                            continue;
                        }
                        DataRow rowFingerInfo = dtFingerInfoOne.Rows[0];
                        DataRow rowUserInfo = dtUserInfoOne.Rows[0];
                        schoolName = row["c_school_name"].ToString();
                        FpStudentObject thisStudent = FpStudentObject.loadbyIdCard(accessOracle,idcard);
                        if (thisStudent == null)
                        {
                            sql = string.Format("insert into fp_student(idcard,name,school_code,school_name,localtype,car_type,lsh,create_time,creater) " +
                                               "values ('{0}','{1}','{2}','{3}',{4},'{5}','{6}',to_date('{7}','yyyy-MM-dd'),'{8}')"
                                               , row["c_idcard"] //0
                                               , row["c_name"]  //1
                                               , row["c_school_code"]  //2
                                               , row["c_school_name"]  //3
                                               , row["c_student_type"]  //4
                                               , row["c_car_type"]  //5
                                               , row["c_lsh"]  //6
                                               , row["c_pxrq"]  //7
                                               , "remote"    //8
                            );
                            if (!accessOracle.ExecuteSql(sql))
                            {
                                string log = string.Format("{1} 学员:{0}身份信息写入失败 ,请检查数据有效性"
                                 , idcard
                                 , schoolName
                                 , carType
                                );
                                this.CreateLog(log);
                                continue;
                            }
                        }
                        else {
                            String updateSet = string.Empty;
                            String msg = string.Empty;
                            String msgPattern=" {0} 由{1}更新为{2} ,";
                            string lsh = StringHelper.isNullOrBlank(row["c_lsh"]) ? string.Empty : row["c_lsh"].ToString();
                            if (lsh!=string.Empty && thisStudent.LSH != lsh) {
                               
                                msg += string.Format(msgPattern, "受理号",thisStudent.LSH,lsh);
                                updateSet += string.Format(" {0} = '{1}' ", "lsh", lsh);
                                //thisStudent.LSH = lsh;
                            }
                            if (thisStudent.NAME != studentName) {
                                msg += string.Format(msgPattern, "姓名", thisStudent.NAME, studentName);
                                updateSet += string.Format(" {0} = '{1}' ", "name", studentName);
                                //thisStudent.NAME = studentName;
                            }
                            if(thisStudent.CAR_TYPE!=carType){
                                msg += string.Format(msgPattern, "车型", thisStudent.CAR_TYPE, carType);
                                updateSet += string.Format(" {0} = '{1}' ", "car_type",carType );
                               //thisStudent.CAR_TYPE=carType;
                            }
                            if (thisStudent.LOCALTYPE != localType) {
                                msg += string.Format(msgPattern, "类型", thisStudent.LOCALTYPE, localType);
                                updateSet += string.Format(" {0} = {1} ", "localtype", localType);
                                //thisStudent.LOCALTYPE = localType;
                            }
                            if (updateSet != string.Empty) {
                                sql = string.Format("update fp_student set {0} where idcard='{1}' ", updateSet, idcard);
                                if (accessOracle.ExecuteSql(sql))
                                {
                                    string log = string.Format("{0} 学员 {1} 资料更新:{2}", schoolName, idcard, msg);
                                    CreateLog(log);
                                }
                                
                            }
                            continue;
                        }
                        string sql1 = string.Format("insert into USER_INFO(USER_ID,MODIFY_TIME,CREATE_TIME) values ('{0}','{1}','{2}')",
                            rowUserInfo["USER_ID"]
                            , rowUserInfo["MODIFY_TIME"]
                            , rowUserInfo["CREATE_TIME"]
                        );
                        string sql2 = string.Format("insert into enroll_temp(USER_ID,AUTHEN_INFO,VERSION,SERVICE_TYPE,SERVICE_CODE,REVOKE_TIME"
                        + ",TEMP_TYPE,TEMP_SIZE,TEMPLATE,CREATE_TIME,MODIFY_TIME)"
                        + " values('{0}','{1}',{2},{3},'{4}','{5}',{6},{7},{8},'{9}','{10}')",
                           rowFingerInfo["USER_ID"]   //0
                           , rowFingerInfo["AUTHEN_INFO"]  //1 
                           , rowFingerInfo["VERSION"]   //2
                           , rowFingerInfo["SERVICE_TYPE"]  //3
                           , rowFingerInfo["SERVICE_CODE"]  //4
                           , rowFingerInfo["REVOKE_TIME"]  //5
                           , rowFingerInfo["TEMP_TYPE"]   //6
                           , rowFingerInfo["TEMP_SIZE"]  //7
                           , ":TEMPLATE"  //8
                           , rowFingerInfo["CREATE_TIME"]  //9
                           , rowFingerInfo["MODIFY_TIME"] //10
                        );
                        byte[] expbyte = (byte[])rowFingerInfo["TEMPLATE"];
                        DbParameter param = new OracleParameter("TEMPLATE", System.Data.OracleClient.OracleType.Blob, expbyte.Length);
                        param.Value = expbyte;

                        if (accessOracle.ExecuteSql(sql1) && accessOracle.ExecuteSqlByParam(sql2, param))
                        {
                            string log = string.Format("成功导入 {1} 学员:{0} 车型:{2}"
                           , idcard
                           , schoolName
                           , carType
                            );
                            this.CreateLog(log);
                            lshs +=  row["c_lsh"].ToString()+",";
                            reNum++;
                        }
                       
                        
                      }

                    /*
                    if (dtUser != null &&dtFingerInfo!=null&& dtUser.Rows.Count > 0)
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

                                sql = string.Format("insert into table_upload_finger_record select * from  table_local_finger_record where c_idcard='{0}'", dr["c_idcard"]);
                                if (!accessAccess.ExecuteSql(sql))
                                {
                                    // continue;
                                }


                                sql = string.Format("delete from table_local_finger_record where c_idcard='{0}'", dr["c_idcard"]);
                                if (!accessAccess.ExecuteSql(sql))
                                {
                                    //  continue; 
                                }

                                sql = string.Format("update table_upload_finger_record set c_upload_time='" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where c_idcard='{0}'", dr["c_idcard"]);

                                if (!accessAccess.ExecuteSql(sql))
                                {
                                    // continue; 
                                }
                                //sql = string.Format("insert into table_upload_finger_record select * from  table_local_finger_record where c_idcard='{0}'", dr["c_idcard"]);



                                reNum++;
                            }
                            else
                            {
                                sql = string.Format("delete from table_local_finger_record where c_idcard='{0}'", dr["c_idcard"]);
                                if (!accessAccess.ExecuteSql(sql))
                                {
                                    //  continue; 
                                }
                            }



                        }
                            

                       
                    }

                }
                     */
                    
                    try
                    {
                        if (File.Exists(config.MonitorPath + "\\bakpath\\" + file.Name))
                        {
                            File.Delete(config.MonitorPath + "\\bakpath\\" + file.Name);
                        }
                        file.MoveTo(config.MonitorPath + "\\bakpath\\" + file.Name);
                        file.Delete();
                    }
                    catch (IOException ioe)
                    {
                        file.Delete();
                    }


                    if (reNum > 0)
                    {
                        string msg = string.Format("导入 {0} {1}条指纹记录,受理号包括:{2}",  schoolName, reNum,lshs.Trim(','));
                        //MessageBoxHelper.Show(DateTime.Now.ToString()+" "+msg);
                        this.SetHintText("处理完毕！");
                        this.CreateLog(msg);
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
            SimpleOrmOperator.InitDataAccess(null);
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

        private void tsmiStudentReport_Click(object sender, EventArgs e)
        {
            Form form = new StudentRecordStatisForm();
            form.Show();
        }
    }
}
