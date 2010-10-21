using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using PDA;

namespace PDA
{
    /// <summary>
    /// ASNTest 的摘要说明
    /// </summary>
    [TestClass]
    public class ASNTest
    {
        public ASNTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            TestASNInitialize();
        }

        private TestContext testContextInstance;
        public DataSet ds;
        public ASN a;
        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试属性
        //
        // 编写测试时，还可使用以下附加属性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        public void TestASNInitialize()
        {
            ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            dt.Columns.Add("SKU",typeof(string));
            dt.Columns.Add("Count", typeof(int));
            dt.Columns.Add("ScanCount", typeof(int));
            dt.Columns.Add("ScanFinish", typeof(int));
            dt.Columns.Add("BillNo", typeof(string));
            dt.Columns.Add("BillRowNo", typeof(string));
            dt.Columns.Add("casecnt", typeof(int));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dr["SKU"] = "SKU1";
            dr["Count"] = 100;
            dr["ScanCount"] = 0;
            dr["ScanFinish"] = 0;
            dr["BillNo"] = "ASN1";
            dr["BillRowNo"] = "ASNRow1";
            dr["casecnt"] = 10;
            a = new ASN(ds);
        }
        [TestMethod]
        public void TestScan()
        {
            //
            // TODO: 在此	添加测试逻辑
            //
            Assert.AreEqual(Types.ScanInfo.Successful, a.DiskScan("DISK1", false));
            Assert.AreEqual(Types.ScanInfo.Successful, a.SKUScan("SKU1", DateTime.Now));
            Assert.AreEqual(a.Dsiks["DISK1"].BillNo, "ASN1");
            Assert.AreEqual(a.Dsiks["DISK1"].BillRowNo, "ASNRow1");
            Assert.AreEqual(a.Dsiks["DISK1"].Count, 10);
            Assert.AreEqual(a.Dsiks["DISK1"].IsScaned, true);
        }
    }
}
