using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;
using PDA.WebReference;
using System.Windows.Forms;

namespace PDA
{
    class DB
    {
        public static string RootPath = @"Program Files\PDA\";
        private string userid = Program.UserID;
        public static string GetWSUrl()
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(DB.RootPath + @"Config\Config.xml");
            XmlNode xmlN = xmlDoc.DocumentElement.SelectSingleNode("WebServices/Url");
            if (xmlN == null)
            {
                return string.Empty;
            }
            else
            {
                return xmlN.InnerText;
            }


        }

        public Service1 GetService()
        {
            string wsurl = GetWSUrl();
            if (string.IsNullOrEmpty(wsurl))
            {
                throw new Exception("WEB 服务器路径配置错误!");
            }
            Service1 service = new Service1();
            service.Url = wsurl;
            return service;
        }
        #region old
        /// <summary>
        /// 根据输入的asn获取对应的信息，包括所有料盘信息
        /// </summary>
        /// <param name="ASNValue"></param>
        /// <returns></returns>
        public DataSet GetASN(string ASNValue)
        {
            try
            {
                Service1 service = GetService();
                return service.getAsnDetail(ASNValue);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将PDA中的ASN数据保存到数据库中
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string SaveASNToServer(DataTable dt)
        {
            try
            {
                Service1 service = GetService();
                if (service.SaveAsn(dt, userid))
                {
                    return "保存成功！";
                }
                else
                {
                    return "保存失败，请检查数据是否正确！";
                }
            }
            catch (Exception ex)
            {
                return "保存失败" + ex.Message;
            }
        }

        /// <summary>
        /// 将PDA中的上架信息保存到数据库
        /// </summary>
        /// <param name="dtDisk"></param>
        /// <param name="dtLOC"></param>
        /// <returns></returns>
        public string SavePutAwayToServer(DataTable dtDisk, DataTable dtLOC, ArrayList al, DataTable dtSku)
        {
            try
            {
                Service1 service = GetService();
                string idList = string.Empty;
                if (al.Count > 0)
                {
                    foreach (object obj in al)
                    {
                        idList += obj.ToString() + ",";
                    }
                    idList = idList.Substring(0, idList.Length - 1);
                }
                if (service.SavePutAway(dtDisk, dtLOC, idList, userid, dtSku))
                {
                    return "保存成功！";
                }
                else
                {
                    return "保存失败，请检查数据是否正确！";
                }
            }
            catch (Exception ex)
            {
                return "保存失败" + ex.Message;
            }
        }

        /// <summary>
        /// 获取上架单及料盘信息
        /// </summary>
        /// <param name="putAwayBillNo"></param>
        /// <returns></returns>
        public DataSet GetPutAway(string putAwayBillNo)
        {
            try
            {
                Service1 service = GetService();
                return service.GetPutAway(putAwayBillNo);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>


        public DataSet GetPick(string PickKey, string loc)
        {
            try
            {
                Service1 service = GetService();
                return service.GetPickData(PickKey, loc);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 保存拣货数据
        /// </summary>
        /// <param name="dtPick"></param>
        /// <param name="dtDisk"></param>
        /// <param name="al"></param>
        /// <returns></returns>
        public string SavePickData(DataTable dtPick, DataTable dtDisk)
        {
            try
            {
                Service1 service = GetService();
                if (service.SavePickData(dtPick, dtDisk, userid))
                {
                    return "保存成功！";
                }
                else
                {
                    return "保存失败，请检查数据是否正确！";
                }
            }
            catch (Exception ex)
            {
                return "保存失败！" + ex.Message;
            }
        }

        /// <summary>
        /// 获得需分盘料盘列表
        /// </summary>
        /// <returns></returns>
        public DataSet GetPartDisk()
        {
            try
            {
                Service1 service = GetService();
                return service.GetPartDisk();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 保存分盘信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string SavePartDisk(DataTable dt)
        {
            try
            {
                Service1 service = GetService();
                if (service.SavePartDisk(dt, userid))
                {
                    return "保存成功！";
                }
                else
                {
                    return "保存失败，请检查数据是否正确！";
                }
            }
            catch (Exception ex)
            {
                return "保存失败！" + ex.Message;
            }
        }

        /// <summary>
        /// 获取退料清点数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataSet GetFeedBackData(string id)
        {
            try
            {
                Service1 service = GetService();
                return service.GetFeedBackData(id);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 保存退料清点数据
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string SaveFeedBackData(DataTable dt)
        {
            try
            {
                Service1 service = GetService();
                if (service.SaveFeedBackData(dt))
                {
                    return "保存成功！";
                }
                else
                {
                    return "保存失败，请检查数据是否正确！";
                }
            }
            catch (Exception ex)
            {
                return "保存失败！" + ex.Message;
            }
        }

        /// <summary>
        /// 湿敏器开封扫描
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAndUpdateDiskForOpen(string id)
        {
            Service1 service = GetService();
            return service.GetAndUpdateDiskForOpen(id, userid);
        }

        /// <summary>
        /// 湿敏器烘烤开始
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAndSaveDiskForBegin(string id, string scantype)
        {
            Service1 service = GetService();
            return service.GetAndSaveDiskForBegin(id, userid, scantype);

        }

        /// <summary>
        /// 湿敏器烘烤结束
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetAndSaveDiskForEnd(string id, string scantype)
        {
            Service1 service = GetService();
            return service.GetAndSaveDiskForEnd(id, userid, scantype);
        }

        /// <summary>
        /// 获取供应商数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetCompany()
        {
            Service1 service = GetService();
            return service.GetCompany();
        }

        /// <summary>
        /// 库存查询
        /// </summary>
        /// <param name="diskid"></param>
        /// <param name="sku"></param>
        /// <param name="dt"></param>
        /// <param name="asn"></param>
        /// <returns></returns>
        public DataSet GetDiskList(string diskid, string sku, DateTime dt, string asn)
        {
            Service1 service = GetService();
            return service.GetDiskList(diskid, sku, dt, asn);
        }

        #endregion
        //公共

        public class ComboBoxDataObject
        {
            private object myText;
            private object myValue;
            public object MyText
            {
                get
                {
                    return myText;
                }
            }
            public object MyValue
            {
                get
                {
                    return myValue;
                }
            }
            public ComboBoxDataObject(object text, object value)
            {
                this.myText = text;
                this.myValue = value;
            }
        }
        /// <summary>
        /// 绑定ComboBox数据源
        /// </summary>
        /// <param name="comboBox">Combox</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="ValueMember">值列名</param>
        /// <param name="DisplayMember">显示列名</param>
        public void BindComboBoxDatasource(System.Windows.Forms.ComboBox comboBox, DataTable dataSource, string ValueMember, string DisplayMember)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                return;
            }
            ArrayList al = new ArrayList();
            foreach (DataRow dr in dataSource.Rows)
            {
                al.Add(new ComboBoxDataObject(dr[DisplayMember], dr[ValueMember]));
            }
            comboBox.DataSource = al;
            comboBox.DisplayMember = "MyText";
            comboBox.ValueMember = "MyValue";
            comboBox.SelectedIndex = 0;
        }
        /// <summary>
        /// 自动设置DataGrid的列宽为平分目前只支持DataTable做数据源
        /// </summary>
        /// <param name="dg">DataGrid</param>
        public void SetDataGridCloumnWidth(DataGrid dg)
        {
            int width = (dg.Width - dg.VisibleColumnCount - 2) / dg.VisibleColumnCount;
            DataGridTableStyle dgts = new DataGridTableStyle();
            if ((dg.DataSource as DataTable).TableName == string.Empty) (dg.DataSource as DataTable).TableName = "TableName1";
            dgts.MappingName = (dg.DataSource as DataTable).TableName;
            for (int i = 0; i < dg.VisibleColumnCount; i++)
            {
                DataGridTextBoxColumn dgtb = new DataGridTextBoxColumn();
                dgtb.MappingName = (dg.DataSource as DataTable).Columns[i].ColumnName;
                dgtb.HeaderText = (dg.DataSource as DataTable).Columns[i].ColumnName;
                dgtb.Width = width;
                dgts.GridColumnStyles.Add(dgtb);
            }
            dg.TableStyles.Clear();
            dg.TableStyles.Add(dgts);
        }
        /// <summary>
        /// 检测当前料盘是否在数据库中存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string IsINDataBase(string id)
        {
            Service1 service = GetService();
            string strReturn = string.Empty;
            strReturn = service.IsInDataBase(id);
            return strReturn;
        }

        /// <summary>
        /// 获取拣货单中当前储位的料盘
        /// </summary>
        /// <param name="PickID"></param>
        /// <param name="Loc"></param>
        /// <returns></returns>
        public DataTable GetPickDisk(string PickID, string Loc)
        {
            Service1 service = GetService();
            return service.GetPickDisk(PickID, Loc);
        }
        public DataSet GetMoveLocData(string loc)
        {
            Service1 service = GetService();
            return service.GetMoveLocData(loc);
        }
        public bool SaveMoveLoc(DataTable dt)
        {
            Service1 service = GetService();
            return service.SaveMoveLoc(dt, userid);
        }

        public DataSet GetMoveLotData(string billid, string lot)
        {
            Service1 service = GetService();
            return service.GetMoveLotData(billid, lot);
        }

        public bool SaveMoveLotData(DataTable dt)
        {
            Service1 service = GetService();
            return service.SaveMoveLotData(dt, userid);
        }
        public DataSet GetUserRightList(string user, string pwd)
        {
            try
            {
                Service1 service = GetService();
                return service.GetUserRight(user, pwd);
            }
            catch
            {
                return null;
            }
        }
        public DataSet GetUserAndFunction()
        {
            try
            {
                Service1 service = GetService();
                return service.GetUserAndFunction();
            }
            catch
            {
                return null;
            }
        }
        public DataSet GetFactoryAndStorage()
        {
            try
            {
                Service1 service = GetService();
                return service.GetFactoryAndStorage();
            }
            catch
            {
                return null;
            }
        }
        public DataSet GetLoc()
        {
            try
            {
                Service1 service = GetService();
                return service.GetLoc();
            }
            catch
            {
                return null;
            }
        }
    }
}
