using System;
using System.Collections.Generic;
using System.Text;

namespace SystemPlugin
{
    public class StudentPlugin:DS.Plugins.Student.SynStudentInfoPlugin
    {
        public StudentPlugin(FT.DAL.IDataAccess dataAccess)
            : base(dataAccess)
        {
        }
        public override bool AddStudent(DS.Plugins.Student.StudentAllInfo info)
        {
            if (info != null && this.dataAccess != null)
            {
                #region sqlserver测试
                /* 
                * string sql = "insert into students(id_card,name,sex,birthday) values('" +
                    Fm.DAL.DALSecurityTool.TransferInsertField(info.IdCard)+"','"+
                    Fm.DAL.DALSecurityTool.TransferInsertField(info.Name) + "','"+
                    Fm.DAL.DALSecurityTool.TransferInsertField(info.Sex) + "','"+
                    Fm.DAL.DALSecurityTool.TransferInsertField(info.Birthday) + "')";
                */
                #endregion
                #region 顺景
                /*
                string sql = "insert into Member(UserName,sex,Birth,Nationality,Card"
                    + ",Uaddress,Taddress,Phone,Zip,RegDate,Grade,Receivables) values('" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Name) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Sex) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Birthday) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.NationString) + "','" +
                                  // FT.DAL.DALSecurityTool.TransferInsertField(info.IdCardTypeString == "居民身份证" ? "身份证" : info.IdCardTypeString) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.IdCard) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.RegAddress) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.ConnAddress) + "','" +
                                   //FT.DAL.DALSecurityTool.TransferInsertField("同上") + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Phone1) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.PostCode) + "','" +
                                   //FT.DAL.DALSecurityTool.TransferInsertField(info.Recommender) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.RegDate!=null&&info.RegDate.Length>0?info.RegDate:System.DateTime.Now.ToString("yyyy-MM-dd")) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.CarTypeCode) + "'," +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Fee == string.Empty ? "0" : info.Fee) + ")";
                 */
                #endregion

                #region 珠海万里
                /*
                string sql1 = "select isnull(max(stucode),0)+1 from jc_student";
                object obj = this.dataAccess.SelectScalar(sql1);
                int id =(int)obj;
                string sql = "insert into jc_student(zdjlflag,zdjl2flag,jyflag,txflag,fzflag,feestandard,feefact,free22,stucode,stuname,sex,signupdate,signupstyle,alreadydlcode,nowdlcode,idno,telno)"
                +" values(0,0,0,0,0,"+
                 FT.DAL.DALSecurityTool.TransferInsertField(info.Fee == string.Empty ? "0" : info.Fee) + ""+","+
                  FT.DAL.DALSecurityTool.TransferInsertField(info.Fee == string.Empty ? "0" : info.Fee) + "" +",'" +
                   FT.DAL.DALSecurityTool.TransferInsertField(info.RegAddress) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(id.ToString().PadLeft(8,'0')) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Name) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Sex) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.RegDate != null && info.RegDate.Length > 0 ? info.RegDate : System.DateTime.Now.ToString("yyyy-MM-dd")) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.LearnType=="初学"?"初驾":"增驾") + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.OldCarType) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.CarTypeCode) + "','" +
                                  
                    // FT.DAL.DALSecurityTool.TransferInsertField(info.IdCardTypeString == "居民身份证" ? "身份证" : info.IdCardTypeString) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.IdCard) + "','" +

                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Phone1) + "'" +
                                  
                    //FT.DAL.DALSecurityTool.TransferInsertField(info.Recommender) + "','" +
                                   
                                   
                                  // FT.DAL.DALSecurityTool.TransferInsertField(info.Fee == string.Empty ? "0" : info.Fee) 
                                    ")";
                 */
                #endregion

                #region 珠海柏宁

                string sql1 = "select isnull(max(编号),0)+1 from student";
                object obj = this.dataAccess.SelectScalar(sql1);
                int id = (int)obj;
                string sql = "insert into student (已发证,状态,已审核,ck_id,地址,编号,姓名,性别,报名日期,报考车型,教练,身份证号,手机,办公电话,住址)"
                + " values(0,'正常',0,0,'" +
                
                   FT.DAL.DALSecurityTool.TransferInsertField(info.RegAddress) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(id.ToString().PadLeft(6, '0')) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Name) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Sex) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.RegDate != null && info.RegDate.Length > 0 ? info.RegDate : System.DateTime.Now.ToString("yyyy-MM-dd")) + "','" +
                                  // FT.DAL.DALSecurityTool.TransferInsertField(info.LearnType == "初学" ? "初驾" : "增驾") + "','" +
                                  // FT.DAL.DALSecurityTool.TransferInsertField(info.OldCarType) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.CarTypeCode) + "','','" +

                    // FT.DAL.DALSecurityTool.TransferInsertField(info.IdCardTypeString == "居民身份证" ? "身份证" : info.IdCardTypeString) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.IdCard) + "','" +

                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Phone1) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Phone2) + "','" +

                                   FT.DAL.DALSecurityTool.TransferInsertField(info.ConnAddress) + "'" +

                    //FT.DAL.DALSecurityTool.TransferInsertField(info.Recommender) + "','" +


                                  // FT.DAL.DALSecurityTool.TransferInsertField(info.Fee == string.Empty ? "0" : info.Fee) 
                                    ")";
                #endregion

                return this.dataAccess.ExecuteSql(sql);
            }
            return false;
        }

        public override bool DeleteStudent(DS.Plugins.Student.StudentAllInfo info)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override bool UpdateStudent(DS.Plugins.Student.StudentAllInfo info)
        {
            if (info != null && this.dataAccess != null)
            {
                #region sqlserver测试
                /* 
                * string sql = "insert into students(id_card,name,sex,birthday) values('" +
                    Fm.DAL.DALSecurityTool.TransferInsertField(info.IdCard)+"','"+
                    Fm.DAL.DALSecurityTool.TransferInsertField(info.Name) + "','"+
                    Fm.DAL.DALSecurityTool.TransferInsertField(info.Sex) + "','"+
                    Fm.DAL.DALSecurityTool.TransferInsertField(info.Birthday) + "')";
                */
                #endregion
                #region 顺景
                /*
                string sql = "update Member set UserName='" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.Name) + "',sex='" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.Sex) + "',Birth='" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.Birthday) + "',Nationality='" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.NationString) + "', Uaddress='" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.RegAddress) + "',Taddress='" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.ConnAddress) + "',Phone='" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.Phone1) + "',Zip='" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.PostCode) + "',RegDate='" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.RegDate) + "',Grade='" +
                      FT.DAL.DALSecurityTool.TransferInsertField(info.CarTypeCode) + "',Receivables=" +
                     FT.DAL.DALSecurityTool.TransferInsertField(info.Fee == string.Empty ? "0" : info.Fee) + " where Card='" +

                     FT.DAL.DALSecurityTool.TransferInsertField(info.IdCard) + "'";
                 */
                #endregion

                #region 珠海万里

                string sql = "update jc_student set stuname='',sex,signupdate,signupstyle,alreadydlcode,nowdlcode,idno,telno) values('" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Name) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Sex) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.RegDate != null && info.RegDate.Length > 0 ? info.RegDate : System.DateTime.Now.ToString("yyyy-MM-dd")) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.LearnType == "初学" ? "初驾" : "增驾") + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.OldCarType) + "'," +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.CarTypeCode) + "'," +

                    // FT.DAL.DALSecurityTool.TransferInsertField(info.IdCardTypeString == "居民身份证" ? "身份证" : info.IdCardTypeString) + "','" +
                                   FT.DAL.DALSecurityTool.TransferInsertField(info.IdCard) + "','" +

                                   FT.DAL.DALSecurityTool.TransferInsertField(info.Phone1) + "','" +

                    //FT.DAL.DALSecurityTool.TransferInsertField(info.Recommender) + "','" +


                                  // FT.DAL.DALSecurityTool.TransferInsertField(info.Fee == string.Empty ? "0" : info.Fee) 
                                  ")";
                #endregion
                return true;
               // return this.dataAccess.ExecuteSql(sql);
            }
            return false;
        }
    }
}
