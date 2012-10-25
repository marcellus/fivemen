using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace FT.Commons.Protocol
{
    /// <summary>
    /// SGIP 客户端信息
    /// </summary>
    public class CSGIP_ClientInfo
    {
        /// <summary>
        /// 连接的源节点编号 Bind时取得
        /// </summary>
        public uint SourceNodeNo = 0;
        /// <summary>
        ///状态 0连接但未登录 1已经登录
        /// </summary>
        public System.Byte Status = 0;
        /// <summary>
        /// 连接建立时间
        /// </summary>
        public DateTime ConnectTime;
        /// <summary>
        /// 最后接收到数据的时间
        /// </summary>
        public DateTime LastComTime;
        /// <summary>
        /// 错误记数
        /// </summary>
        public System.UInt32 ErrorCount = 0;
    }
    /// <summary>
    /// SGIP 参数
    /// </summary>
    public class CSGIP_Config
    {
        private string[] Param = null;

        public CSGIP_Config(string[] ParamArray)
        {
            Param = ParamArray;
        }

        public bool CheckParam()
        {
            for (int i = 81; i <= 98; i++)
            {
                if (Param[i] == "")
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 81 源节点编号
        /// </summary>
        public string SourceNodeNo
        {
            get
            {
                return Param[81];
            }
        }
        /// <summary>
        /// 82 序号
        /// </summary>
        public string MessageSN
        {
            get
            {
                return Param[82];
            }
        }
        /// <summary>
        /// 83 SP接入号码 
        /// </summary>
        public string SPNumber
        {
            get
            {
                return Param[83];
            }
        }
        /// <summary>
        ///  84 企业代码
        /// </summary>
        public string CorpId
        {
            get
            {
                return Param[84];
            }
        }
        /// <summary>
        /// 85 状态报告标记
        /// </summary>
        public string ReportFlag
        {
            get
            {
                return Param[85];
            }
        }
        /// <summary>
        /// 86 TP_pid6
        /// </summary>
        public string TP_pid
        {
            get
            {
                return Param[86];
            }
        }
        /// <summary>
        /// 87 TP_udhi
        /// </summary>
        public string TP_udhi
        {
            get
            {
                return Param[87];
            }
        }
        /// <summary>
        /// 88 短消息编码格式
        /// </summary>
        public string MessageCoding
        {
            get
            {
                return Param[88];
            }
        }
        /// <summary>
        /// 89 SP监听端口
        /// </summary>
        public string SPListenPort
        {
            get
            {
                return Param[89];
            }
        }
        /// <summary>
        /// 90 SP登录名称
        /// </summary>
        public string SPLoginName
        {
            get
            {
                return Param[90];
            }
        }
        /// <summary>
        /// 91 SP登录密码
        /// </summary>
        public string SPLoginPwd
        {
            get
            {
                return Param[91];
            }
        }
        /// <summary>
        /// 92 SMG IP
        /// </summary>
        public string SMGIP
        {
            get
            {
                return Param[92];
            }
        }
        /// <summary>
        /// 93 SMG 端口号
        /// </summary>
        public string SMGPort
        {
            get
            {
                return Param[93];
            }
        }
        /// <summary>
        /// 94 SMG登录名称
        /// </summary>
        public string SMGLoginName
        {
            get
            {
                return Param[94];
            }
        }
        /// <summary>
        /// 95 SMG登录密码
        /// </summary>
        public string SMGLoginPwd
        {
            get
            {
                return Param[95];
            }
        }
        /// <summary>
        /// 96 待应答队列超时时间，秒
        /// </summary>
        public string WaitRespTimeout
        {
            get
            {
                return Param[96];
            }
        }
        /// <summary>
        /// 97 待应答队列最大长度
        /// </summary>
        public string WaitQueueMaxCount
        {
            get
            {
                return Param[97];
            }
        }
        /// <summary>
        /// 98 SP服务允许SMG建立的最大连接数
        /// </summary>
        public string SPSeverMaxLink
        {
            get
            {
                return Param[98];
            }
        }

        /// <summary>
        /// 99 业务代码
        /// </summary>
        public string ServiceType
        {
            get
            {
                return Param[99];
            }
        }
    }
    /// <summary>
    /// SGIP 消息ID定义
    /// </summary>
    public enum SGIP_CommandIDs : uint
    {
        SGIP_BIND = 0x1,
        SGIP_BIND_RESP = 0x80000001,
        SGIP_UNBIND = 0x2,
        SGIP_UNBIND_RESP = 0x80000002,
        SGIP_SUBMIT = 0x3,
        SGIP_SUBMIT_RESP = 0x80000003,
        SGIP_DELIVER = 0x4,
        SGIP_DELEVER_RESP = 0x80000004,
        SGIP_REPORT = 0x5,
        SGIP_REPORT_RESP = 0x80000005,
        //SGIP_ADDSP = 0x6,
        //SGIP_ADDSP_RESP = 0x80000006,
        //SGIP_MODIFYSP = 0x7,
        //SGIP_MODIFYSP_RESP = 0x80000007,
        //SGIP_DELETESP = 0x8,
        //SGIP_DELETESP_RESP = 0x80000008,
        //SGIP_QUERYROUTE = 0x9,
        //SGIP_QUERYROUTE_RESP = 0x80000009,
        //SGIP_ADDTELESEG = 0xa,
        //SGIP_ADDTELESEG_RESP = 0x8000000a,
        //SGIP_MODIFYTELESEG = 0xb,
        //SGIP_MODIFYTELESEG_RESP = 0x8000000b,
        //SGIP_DELETETELESEG = 0xc,
        //SGIP_DELETETELESEG_RESP = 0x8000000c,
        //SGIP_ADDSMG = 0xd,
        //SGIP_ADDSMG_RESP = 0x8000000d,
        //SGIP_MODIFYSMG = 0xe,
        //SGIP_MODIFYSMG_RESP = 0x0000000e,
        //SGIP_DELETESMG = 0xf,
        //SGIP_DELETESMG_RESP = 0x8000000f,
        //SGIP_CHECKUSER = 0x10,
        //SGIP_CHECKUSER_RESP = 0x80000010,
        SGIP_USERRPT = 0x11,
        SGIP_USERRPT_RESP = 0x80000011,
        SGIP_TRACE = 0x1000,
        SGIP_TRACE_RESP = 0x80001000,
    }
    /// <summary>
    /// SGIP 计费类别定义
    /// </summary>
    public enum SGIP_FeeTypes : byte
    {
        /// <summary>
        /// 0	“短消息类型”为“发送”，对“计费用户号码”不计信息费，此类话单仅用于核减SP对称的信道费
        /// </summary>
        FreeSend = 0,
        /// <summary>
        /// 1	对“计费用户号码”免费
        /// </summary>
        Free = 1,
        /// <summary>
        /// 2	对“计费用户号码”按条计信息费
        /// </summary>
        RowNumFee = 2,
        /// <summary>
        /// 3	对“计费用户号码”按包月收取信息费
        /// </summary>
        MonthFee = 3,
        /// <summary>
        /// 4	对“计费用户号码”的收费是由SP实现
        /// </summary>
        SpFee = 4,
    }
    /// <summary>
    /// SGIP 错误码定义
    /// </summary>
    public enum SGIP_ErrorCodes : byte
    {
        /// <summary>
        /// 0	无错误，命令正确接收
        /// </summary>
        Success = 0,
        /// <summary>
        /// 1	非法登录，如登录名、口令出错、登录名与口令不符等。
        /// </summary>
        LoginError = 1,
        /// <summary>
        /// 2	重复登录，如在同一TCP/IP连接中连续两次以上请求登录。
        /// </summary>
        Relogon = 2,
        /// <summary>
        /// 3	连接过多，指单个节点要求同时建立的连接数过多。
        /// </summary>
        ConnectionFull = 3,
        /// <summary>
        /// 4	登录类型错，指bind命令中的logintype字段出错。
        /// </summary>
        ErrorLoginType = 4,
        /// <summary>
        /// 5	参数格式错，指命令中参数值与参数类型不符或与协议规定的范围不符。
        /// </summary>
        ParameterError = 5,
        /// <summary>
        /// 6	非法手机号码，协议中所有手机号码字段出现非86130号码或手机号码前未加“86”时都应报错。
        /// </summary>
        TelnumberError = 6,
        /// <summary>
        /// 7	消息ID错
        /// </summary>
        MsgIDError = 7,
        /// <summary>
        /// 8	信息长度错
        /// </summary>
        PackageLengthError = 8,
        /// <summary>
        /// 9	非法序列号，包括序列号重复、序列号格式错误等
        /// </summary>
        SequenceError = 9,
        /// <summary>
        /// 10	非法操作GNS
        /// </summary>
        GnsOperationError = 10,
        /// <summary>
        /// 11	节点忙，指本节点存储队列满或其他原因，暂时不能提供服务的情况
        /// </summary>
        NodeBusy = 11,
        /// <summary>
        /// 21	目的地址不可达，指路由表存在路由且消息路由正确但被路由的节点暂时不能提供服务的情况
        /// </summary>
        NodeCanNotReachable = 21,
        /// <summary>
        /// 22	路由错，指路由表存在路由但消息路由出错的情况，如转错SMG等
        /// </summary>
        RouteError = 22,
        /// <summary>
        /// 23	路由不存在，指消息路由的节点在路由表中不存在
        /// </summary>
        RoutNodeNotExisted = 23,
        /// <summary>
        /// 24	计费号码无效，鉴权不成功时反馈的错误信息
        /// </summary>
        FeeNumberError = 24,
        /// <summary>
        /// 25	用户不能通信（如不在服务区、未开机等情况）
        /// </summary>
        UserCanNotReachable = 25,
        /// <summary>
        /// 26	手机内存不足
        /// </summary>
        HandsetFull = 26,
        /// <summary>
        /// 27	手机不支持短消息
        /// </summary>
        HandsetCanNotRecvSms = 27,
        /// <summary>
        /// 28	手机接收短消息出现错误
        /// </summary>
        HandsetReturnError = 28,
        /// <summary>
        /// 29	不知道的用户
        /// </summary>
        UnknownUser = 29,
        /// <summary>
        /// 30	不提供此功能
        /// </summary>
        NoDevice = 30,
        /// <summary>
        /// 31	非法设备
        /// </summary>
        InvalidateDevice = 31,
        /// <summary>
        /// 32	系统失败
        /// </summary>
        SystemError = 32,
        /// <summary>
        /// 33	短信中心队列满
        /// </summary>
        FullSequence = 33,
        /// <summary>
        /// 未知错误
        /// </summary>
        OtherError = 99,
    }
    /// <summary>
    /// Bind，登录类型。
    /// </summary>
    public enum SGIP_LoginTypes : byte
    {
        /// <summary>
        /// 1：SP向SMG建立的连接，用于发送命令
        /// </summary>
        SpToSmg = 1,
        /// <summary>
        /// 2：SMG向SP建立的连接，用于发送命令
        /// </summary>
        SmgToSp = 2,
        /// <summary>
        /// 3：SMG之间建立的连接，用于转发命令
        /// </summary>
        SmgToSmg = 3,
        /// <summary>
        /// 4：SMG向GNS建立的连接，用于路由表的检索和维护
        /// </summary>
        SmgToGns = 4,
        /// <summary>
        /// 5：GNS向SMG建立的连接，用于路由表的更新
        /// </summary>
        GnsToSmg = 5,
        /// <summary>
        /// 6：主备GNS之间建立的连接，用于主备路由表的一致性
        /// </summary>
        GnsToGns = 6,
        /// <summary>
        /// 11：SP与SMG以及SMG之间建立的测试连接，用于跟踪测试
        /// </summary>
        Test = 11,
        /// <summary>
        /// 其它：保留
        /// </summary>
        Unknown = 0,
    }
    /// <summary>
    /// SGIP 数据类型定义
    /// </summary>
    public enum SGIP_DataTypes
    {
        Uint,
        String,
        Byte,
    }
    /// <summary>
    /// 代收费标志，0：应收；1：实收
    /// </summary>
    public enum SGIP_SubmitAgentFlag : byte
    {
        /// <summary>
        /// 0：应收
        /// </summary>
        SouldIncome = 0,
        /// <summary>
        /// 1：实收
        /// </summary>
        RealIncome = 1,
    }
    /// <summary>
    /// 引起MT消息的原因
    /// </summary>
    public enum SGIP_SubmitMorelatetoMTFlags : byte
    {
        /// <summary>
        /// 0-MO点播引起的第一条MT消息；
        /// </summary>
        VoteFirst = 0,
        /// <summary>
        /// 1-MO点播引起的非第一条MT消息；
        /// </summary>
        VoteNonFirst = 1,
        /// <summary>
        /// 2-非MO点播引起的MT消息；
        /// </summary>
        NormalFirst = 2,
        /// <summary>
        /// 3-系统反馈引起的MT消息。
        /// </summary>
        NormalNonFirst = 3,
    }
    /// <summary>
    /// 状态报告标记
    /// </summary>
    public enum SGIP_SubmitReportFlag : byte
    {
        /// <summary>
        /// 0-该条消息只有最后出错时要返回状态报告
        /// </summary>
        ErrorReport = 0,
        /// <summary>
        /// 1-该条消息无论最后是否成功都要返回状态报告
        /// </summary>
        Always = 1,
        /// <summary>
        /// 2-该条消息不需要返回状态报告
        /// </summary>
        NoReport = 2,
        /// <summary>
        /// 3-该条消息仅携带包月计费信息，不下发给用户，要返回状态报告
        /// </summary>
        MonthReport = 3,
    }
    /// <summary>
    /// 短消息的编码格式。
    /// </summary>
    public enum SGIP_MessageCodings : byte
    {
        /// <summary>
        /// 0：纯ASCII字符串
        /// </summary>
        Ascii = 0,
        /// <summary>
        /// 3：写卡操作
        /// </summary>
        WriteCard = 3,
        /// <summary>
        /// 4：二进制编码
        /// </summary>
        Binary = 4,
        /// <summary>
        /// 8：UCS2编码
        /// </summary>
        Ucs2 = 8,
        /// <summary>
        /// 15: GBK编码
        /// </summary>
        Gbk = 15,
        /// <summary>
        /// 其它参见GSM3.38第4节：SMS Data Coding Scheme
        /// </summary>
        Others = 99,
    }
    /// <summary>
    /// Report命令类型
    /// </summary>
    public enum SGIP_ReportTypes : byte
    {
        /// <summary>
        /// 0：对先前一条Submit命令的状态报告
        /// </summary>
        Submit = 0,
        /// <summary>
        /// 1：对先前一条前转Deliver命令的状态报告
        /// </summary>
        Deliver = 1,
    }
    /// <summary>
    /// 该命令所涉及的短消息的当前执行状态
    /// </summary>
    public enum SGIP_ReportStates : byte
    {
        /// <summary>
        /// 0：发送成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 1：等待发送
        /// </summary>
        Accepted = 1,
        /// <summary>
        /// 2：发送失败
        /// </summary>
        Error = 2,
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class SGIP_PropertyAttribute : Attribute
    {
        private int m_nOrder = 0;
        private bool m_bHeader = false;
        private int m_nTextLength = -1;

        public SGIP_PropertyAttribute(bool bHeader, int nOrder, int nTextLength)
        {
            m_bHeader = bHeader;
            m_nOrder = nOrder;
            m_nTextLength = nTextLength;
        }

        public bool IsHeader
        {
            get { return m_bHeader; }
        }
        public int Order
        {
            get { return m_nOrder; }
        }
        public int Length
        {
            get { return m_nTextLength; }
            set { m_nTextLength = value; }
        }
    }
    public class SGIP_Field
    {
        private PropertyInfo m_ProInfo = null;
        private SGIP_PropertyAttribute m_ProAttribute = null;
        private SGIP_DataTypes m_nDataType = SGIP_DataTypes.String;
        private string m_sValue = "";
        private uint m_nValue = 0;
        private uint m_nLength = 0;
        private SGIP_CommandHead m_CommandHead = null;

        public SGIP_Field(SGIP_CommandHead CommandHead, PropertyInfo ProInfo, SGIP_PropertyAttribute ProAttribute)
        {
            m_CommandHead = CommandHead;
            m_ProInfo = ProInfo;
            m_ProAttribute = ProAttribute;

            Build();
        }

        public uint Length
        {
            get { return m_nLength; }
        }
        public PropertyInfo ProInfo
        {
            get { return m_ProInfo; }
        }
        public SGIP_PropertyAttribute ProAttribute
        {
            get { return m_ProAttribute; }
        }
        public SGIP_DataTypes DataType
        {
            get { return m_nDataType; }
        }
        public string StringValue
        {
            get { return m_sValue; }
        }
        public uint UIntValue
        {
            get { return m_nValue; }
        }

        public bool IsProperty(String str)
        {
            return null != m_ProInfo && null != str &&
                m_ProInfo.Name.Trim().ToLower().Equals(str.Trim().ToLower());
        }

        public void Build()
        {
            if (m_ProInfo.PropertyType != typeof(string))
            {
                m_nValue = Convert.ToUInt32(m_ProInfo.GetValue(m_CommandHead, null));
                m_nDataType = SGIP_DataTypes.Uint;
                m_nLength = 4;

                if ((m_ProInfo.PropertyType == typeof(Enum) || m_ProInfo.PropertyType.BaseType == typeof(Enum)) &&
                     m_ProInfo.PropertyType.GetFields() != null && m_ProInfo.PropertyType.GetFields().Length > 0)
                {
                    if (m_ProInfo.PropertyType.GetFields()[0].FieldType == typeof(byte))
                    {
                        m_nLength = 1;
                        m_nDataType = SGIP_DataTypes.Byte;
                    }
                }
                else if (m_ProInfo.PropertyType == typeof(byte))
                {
                    m_nLength = 1;
                    m_nDataType = SGIP_DataTypes.Byte;
                }
            }
            else
            {
                m_sValue = m_ProInfo.GetValue(m_CommandHead, null) as string;
                m_nDataType = SGIP_DataTypes.String;
                m_nLength = (uint)m_ProAttribute.Length;
            }
        }
    }

    public class SGIP_CommandHead
    {
        private const uint HEAD_LEN = 20;
        private uint m_nMessageLength = 20;
        private SGIP_CommandIDs m_nCommandID = SGIP_CommandIDs.SGIP_BIND;
        private uint m_nSourceNodeNo = 0;
        private uint m_nCreateTime = 0;
        private uint m_nMessageSN = 0;

        public SGIP_CommandHead(SGIP_CommandIDs CommandID)
        {
            m_nCommandID = CommandID;
            m_nCreateTime = uint.Parse(DateTime.Now.ToString("MMddHHmmss"));
        }

        /// <summary>
        /// Message Length	 4	 Integer	消息的总长度(字节)
        /// </summary>
        [SGIP_Property(true, 0, 4)]
        public uint MessageLength
        {
            get { return m_nMessageLength; }
            set { m_nMessageLength = value; }
        }
        /// <summary>
        /// Command ID	     4	 Integer	命令ID
        /// </summary>
        [SGIP_Property(true, 1, 4)]
        public SGIP_CommandIDs CommandID
        {
            get { return m_nCommandID; }
            set { m_nCommandID = value; }
        }
        /// <summary>
        /// 1/3 Sequence Number	 12	 Integer	序列号:命令源节点编号
        /// </summary>
        [SGIP_Property(true, 2, 4)]
        public uint SourceNodeNo
        {
            get { return m_nSourceNodeNo; }
            set { m_nSourceNodeNo = value; }
        }
        /// <summary>
        /// 2/3 Sequence Number	 12	 Integer	序列号:命令产生的时间
        /// </summary>
        [SGIP_Property(true, 3, 4)]
        public uint CreateTime
        {
            get { return m_nCreateTime; }
            set { m_nCreateTime = value; }
        }
        /// <summary>
        /// 3/3 Sequence Number	 12	 Integer	序列号:序号
        /// </summary>
        [SGIP_Property(true, 4, 4)]
        public uint MessageSN
        {
            get { return m_nMessageSN; }
            set { m_nMessageSN = value; }
        }

        public int Package(out byte[] Pack)
        {
            Pack = null;

            try
            {
                byte[] tmp = new byte[2048];

                /*m_nCreateTime = (uint)(DateTime.Now.Month * 100000000 +
                    DateTime.Now.Day * 1000000 + DateTime.Now.Hour * 10000 +
                    DateTime.Now.Minute * 100 + DateTime.Now.Second);*/

                m_nMessageLength = HEAD_LEN;

                List<SGIP_Field> BodyFieldList = GetFields(false);
                if (BodyFieldList == null)
                {
                    Console.WriteLine( "SGIP Package BodyFieldList is null.");
                    return -1;
                }
                foreach (SGIP_Field Field in BodyFieldList)
                {
                    m_nMessageLength += FieldToPack(Field, tmp, m_nMessageLength);
                }

                uint nOffset = 0;
                List<SGIP_Field> HeadFieldList = GetFields(true);
                if (HeadFieldList == null)
                {
                     Console.WriteLine(  "SGIP Package HeadFieldList is null.");
                    return -2;
                }
                foreach (SGIP_Field Field in HeadFieldList)
                {
                    nOffset += FieldToPack(Field, tmp, nOffset);
                }

                Pack = new byte[m_nMessageLength];
                Array.Copy(tmp, 0, Pack, 0, m_nMessageLength);

                return 0;
            }
            catch (Exception e)
            {
                 Console.WriteLine(  "SGIP Package函数异常:" + e.Message);
                return -3;
            }
        }
        public int UnPackage(byte[] Pack)
        {
            try
            {
                uint Offset = 0;

                foreach (SGIP_Field Field in GetFields(true))
                {
                    Offset += PackToField(Field, Pack, Offset);
                }

                foreach (SGIP_Field Field in GetFields(false))
                {
                    Offset += PackToField(Field, Pack, Offset);
                }
            }
            catch (Exception e)
            {
                 Console.WriteLine(  "SGIP UnPackage函数异常:" + e.Message);
                return -1;
            }

            return 0;
        }
        public int CheckHead(byte[] HeadBuffer)
        {
            try
            {
                uint Offset = 0;

                foreach (SGIP_Field Field in GetFields(true))
                {
                    Offset += PackToField(Field, HeadBuffer, Offset);
                }

                if (m_nMessageLength < 20 || m_nMessageLength > 2048 - 20)
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                 Console.WriteLine(  "SGIP CheakHead函数异常:" + e.Message);
                return -1;
            }

            return 0;
        }

        private List<SGIP_Field> GetFields(bool bHeader)
        {
            PropertyInfo[] Fields = new PropertyInfo[255];
            SGIP_PropertyAttribute[] FieldAttributes = new SGIP_PropertyAttribute[255];
            int nCount = 0;

            foreach (PropertyInfo Field in this.GetType().GetProperties())
            {
                bool bFound = false;
                SGIP_PropertyAttribute FieldAttr = null;
                foreach (Attribute attr in Field.GetCustomAttributes(false))
                {
                    if (attr.GetType() == typeof(SGIP_PropertyAttribute))
                    {
                        FieldAttr = attr as SGIP_PropertyAttribute;
                        bFound = true;
                        break;
                    }
                }

                if (bFound && FieldAttr.IsHeader == bHeader)
                {
                    Fields[FieldAttr.Order] = Field;
                    FieldAttributes[FieldAttr.Order] = FieldAttr;

                    nCount++;
                }
            }

            List<SGIP_Field> FieldList = new List<SGIP_Field>();

            for (int nIndex = 0; nIndex < nCount; nIndex++)
            {
                if (Fields[nIndex] == null || FieldAttributes[nIndex] == null)
                {
                    FieldList.Clear();

                    return null;
                }

                FieldList.Add(new SGIP_Field(this, Fields[nIndex], FieldAttributes[nIndex]));
            }

            return FieldList;
        }
        protected virtual uint FieldToPack(SGIP_Field Field, byte[] Pack, uint Offset)
        {
            if (Field.DataType == SGIP_DataTypes.Uint)
            {
                byte[] aa = BitConverter.GetBytes(Field.UIntValue);
                byte[] bArray = new byte[4];
                bArray[3] = (byte)(Field.UIntValue & 0xFF);
                bArray[2] = (byte)((Field.UIntValue >> 8) & 0xFF);
                bArray[1] = (byte)((Field.UIntValue >> 16) & 0xFF);
                bArray[0] = (byte)((Field.UIntValue >> 24) & 0xFF);
                Array.Copy(bArray, 0, Pack, Offset, 4);

                return 4;
            }
            else if (Field.DataType == SGIP_DataTypes.Byte)
            {
                Pack[Offset] = (byte)Field.UIntValue;

                return 1;
            }
            else
            {
                byte[] bStringArray = System.Text.Encoding.ASCII.GetBytes(Field.StringValue);
                for (int i = 0; i < Field.ProAttribute.Length; i++)
                {
                    if (i < bStringArray.Length)
                    {
                        Pack[Offset + i] = bStringArray[i];
                    }
                    else
                    {
                        Pack[Offset + i] = 0;
                    }
                }

                return (uint)Field.ProAttribute.Length;
            }
        }
        protected virtual uint PackToField(SGIP_Field Field, byte[] Pack, uint Offset)
        {
            int nLength = Field.ProAttribute.Length;
            if (Field.DataType == SGIP_DataTypes.Uint)
            {
                uint nValue = 0;
                nValue ^= Pack[Offset + 0];
                nValue = nValue << 8;
                nValue ^= Pack[Offset + 1];
                nValue = nValue << 8;
                nValue ^= Pack[Offset + 2];
                nValue = nValue << 8;
                nValue ^= Pack[Offset + 3];

                Field.ProInfo.SetValue(this, nValue, null);
            }
            else if (Field.DataType == SGIP_DataTypes.Byte)
            {
                byte value = Pack[Offset];
                Field.ProInfo.SetValue(this, value, null);
            }
            else
            {
                int n = 0;
                byte[] tmp = new byte[nLength];
                Array.Copy(Pack, Offset, tmp, 0, nLength);
                foreach (byte b in tmp)
                {
                    if (b == 0)
                    {
                        break;
                    }
                    n++;
                }
                string sValue = "";
                if (n != 0)
                {
                    byte[] tmp1 = new byte[n];
                    for (int i = 0; i < n && i < tmp.Length; i++)
                    {
                        tmp1[i] = tmp[i];
                    }

                    sValue = System.Text.Encoding.ASCII.GetString(tmp1);
                }
                Field.ProInfo.SetValue(this, sValue, null);
            }

            Field.Build();

            return (uint)nLength;
        }
    }
    public class SGIP_Command_Resp : SGIP_CommandHead
    {
        public SGIP_Command_Resp(SGIP_CommandIDs CommandID)
            : base(CommandID + 0x80000000)
        {
        }

        private SGIP_ErrorCodes m_nResult = SGIP_ErrorCodes.Success;
        private string m_sReserve = "";

        /// <summary>
        ///Result	1	Integer	Bind执行命令是否成功。
        /// </summary>
        [SGIP_Property(false, 0, 1)]
        public SGIP_ErrorCodes Result
        {
            get { return m_nResult; }
            set { m_nResult = value; }
        }
        /// <summary>
        ///Reserve	8	Text	保留，扩展用
        /// </summary>
        [SGIP_Property(false, 1, 8)]
        public string Reserve
        {
            get { return m_sReserve; }
            set { m_sReserve = value; }
        }
    }
    public class SGIP_Bind : SGIP_CommandHead
    {
        public SGIP_Bind()
            : base(SGIP_CommandIDs.SGIP_BIND)
        {
        }

        private SGIP_LoginTypes m_nLoginType = SGIP_LoginTypes.Unknown;
        private string m_sLoginName = null;
        private string m_sLoginPassowrd = null;
        private string m_sReserve = null;

        /// <summary>
        ///Login Type	1	Integer	登录类型。
        /// </summary>
        [SGIP_Property(false, 0, 1)]
        public SGIP_LoginTypes LoginType
        {
            get { return m_nLoginType; }
            set { m_nLoginType = value; }
        }
        /// <summary>
        ///Login Name	16	Text	服务器端给客户端分配的登录名
        /// </summary>
        [SGIP_Property(false, 1, 16)]
        public string LoginName
        {
            get { return m_sLoginName; }
            set { m_sLoginName = value; }
        }
        /// <summary>
        ///Login Passowrd	16	Text	服务器端和Login Name对应的密码
        /// </summary>
        [SGIP_Property(false, 2, 16)]
        public string LoginPassowrd
        {
            get { return m_sLoginPassowrd; }
            set { m_sLoginPassowrd = value; }
        }
        /// <summary>
        ///Reserve	8	Text	保留，扩展用
        /// </summary>
        [SGIP_Property(false, 3, 8)]
        public string Reserve
        {
            get { return m_sReserve; }
            set { m_sReserve = value; }
        }
    }
    public class SGIP_Unbind : SGIP_CommandHead
    {
        public SGIP_Unbind()
            : base(SGIP_CommandIDs.SGIP_UNBIND)
        {
        }
    }
    public class SGIP_Submit : SGIP_CommandHead
    {
        public SGIP_Submit()
            : base(SGIP_CommandIDs.SGIP_SUBMIT)
        {
        }

        private string m_sSPNumber = null;
        private string m_sChargeNumber = null;
        private byte m_nUserCount = 1;
        private string m_sUserNumber = null;
        private string m_sCorpId = null;
        private string m_sServiceType = "";
        private SGIP_FeeTypes m_nFeeType = SGIP_FeeTypes.Free;
        private string m_sFeeValue = "0";
        private string m_sGivenValue = "0";
        private SGIP_SubmitAgentFlag m_nAgentFlag = SGIP_SubmitAgentFlag.SouldIncome;
        private SGIP_SubmitMorelatetoMTFlags m_nMorelatetoMTFlag = SGIP_SubmitMorelatetoMTFlags.VoteFirst;
        private byte m_nPriority = 0;
        private string m_sExpireTime = null;
        private string m_sScheduleTime = null;
        private SGIP_SubmitReportFlag m_nReportFlag = SGIP_SubmitReportFlag.NoReport;
        private byte m_nTP_pid = 0;
        private byte m_nTP_udhi = 0;
        private SGIP_MessageCodings m_nMessageCoding = SGIP_MessageCodings.Gbk;
        private byte m_nMessageType = 0;
        private uint m_nSMMessageLength = 0;
        private string m_sMessageContent = null;
        private string m_sReserve = null;

        /// <summary>
        ///SPNumber	21	Text	SP的接入号码
        /// </summary>
        [SGIP_Property(false, 0, 21)]
        public string SPNumber
        {
            get { return m_sSPNumber; }
            set { m_sSPNumber = value; }
        }
        /// <summary>
        ///ChargeNumber	21	Text	付费号码，手机号码前加“86”国别标志；当且仅当群发且对用户收费时为空；如果为空，则该条短消息产生的费用由UserNumber代表的用户支付；如果为全零字符串“000000000000000000000”，表示该条短消息产生的费用由SP支付。
        /// </summary>
        [SGIP_Property(false, 1, 21)]
        public string ChargeNumber
        {
            get { return m_sChargeNumber; }
            set { m_sChargeNumber = value; }
        }
        /// <summary>
        ///UserCount	1	Integer	接收短消息的手机数量，取值范围1至100
        /// </summary>
        [SGIP_Property(false, 2, 1)]
        public byte UserCount
        {
            get { return m_nUserCount; }
            set { m_nUserCount = value; }
        }
        /// <summary>
        ///UserNumber	21	Text	接收该短消息的手机号，该字段重复UserCount指定的次数，手机号码前加“86”国别标志
        /// </summary>
        [SGIP_Property(false, 3, 21)]
        public string UserNumber
        {
            get { return m_sUserNumber; }
            set { m_sUserNumber = value; }
        }
        /// <summary>
        ///CorpId	5	Text	企业代码，取值范围0-99999
        /// </summary>
        [SGIP_Property(false, 4, 5)]
        public string CorpId
        {
            get { return m_sCorpId; }
            set { m_sCorpId = value; }
        }
        /// <summary>
        ///ServiceType	10	Text	业务代码，由SP定义
        /// </summary>
        [SGIP_Property(false, 5, 10)]
        public string ServiceType
        {
            get { return m_sServiceType; }
            set { m_sServiceType = value; }
        }
        /// <summary>
        ///FeeType	1	Integer	计费类型
        /// </summary>
        [SGIP_Property(false, 6, 1)]
        public SGIP_FeeTypes FeeType
        {
            get { return m_nFeeType; }
            set { m_nFeeType = value; }
        }
        /// <summary>
        ///FeeValue	6	Text	取值范围0-99999，该条短消息的收费值，单位为分，由SP定义 对于包月制收费的用户，该值为月租费的值
        /// </summary>
        [SGIP_Property(false, 7, 6)]
        public string FeeValue
        {
            get { return m_sFeeValue; }
            set { m_sFeeValue = value; }
        }
        /// <summary>
        ///GivenValue	6	Text	取值范围0-99999，赠送用户的话费，单位为分，由SP定义，特指由SP向用户发送广告时的赠送话费
        /// </summary>
        [SGIP_Property(false, 8, 6)]
        public string GivenValue
        {
            get { return m_sGivenValue; }
            set { m_sGivenValue = value; }
        }
        /// <summary>
        ///AgentFlag	1	Integer	代收费标志，0：应收；1：实收
        /// </summary>
        [SGIP_Property(false, 9, 1)]
        public SGIP_SubmitAgentFlag AgentFlag
        {
            get { return m_nAgentFlag; }
            set { m_nAgentFlag = value; }
        }
        /// <summary>
        ///MorelatetoMTFlag	1	Integer	引起MT消息的原因0-MO点播引起的第一条MT消息；1-MO点播引起的非第一条MT消息；2-非MO点播引起的MT消息；3-系统反馈引起的MT消息。
        /// </summary>
        [SGIP_Property(false, 10, 1)]
        public SGIP_SubmitMorelatetoMTFlags MorelatetoMTFlag
        {
            get { return m_nMorelatetoMTFlag; }
            set { m_nMorelatetoMTFlag = value; }
        }
        /// <summary>
        ///Priority	1	Integer	优先级0-9从低到高，默认为0
        /// </summary>
        [SGIP_Property(false, 11, 1)]
        public byte Priority
        {
            get { return m_nPriority; }
            set { m_nPriority = value; }
        }
        /// <summary>
        ///ExpireTime	16	Text	短消息寿命的终止时间，如果为空，表示使用短消息中心的缺省值。时间内容为16个字符，格式为”yymmddhhmmsstnnp” ，其中“tnnp”取固定值“032+”，即默认系统为北京时间
        /// </summary>
        [SGIP_Property(false, 12, 16)]
        public string ExpireTime
        {
            get { return m_sExpireTime; }
            set { m_sExpireTime = value; }
        }
        /// <summary>
        ///ScheduleTime	16	Text	短消息定时发送的时间，如果为空，表示立刻发送该短消息。时间内容为16个字符，格式为“yymmddhhmmsstnnp” ，其中“tnnp”取固定值“032+”，即默认系统为北京时间
        /// </summary>
        [SGIP_Property(false, 13, 16)]
        public string ScheduleTime
        {
            get { return m_sScheduleTime; }
            set { m_sScheduleTime = value; }
        }
        /// <summary>
        ///ReportFlag	1	Integer	状态报告标记0-该条消息只有最后出错时要返回状态报告1-该条消息无论最后是否成功都要返回状态报告2-该条消息不需要返回状态报告3-该条消息仅携带包月计费信息，不下发给用户，要返回状态报告其它-保留缺省设置为0
        /// </summary>
        [SGIP_Property(false, 14, 1)]
        public SGIP_SubmitReportFlag ReportFlag
        {
            get { return m_nReportFlag; }
            set { m_nReportFlag = value; }
        }
        /// <summary>
        ///TP_pid	1	Integer	GSM协议类型。详细解释请参考GSM03.40中的9.2.3.9
        /// </summary>
        [SGIP_Property(false, 15, 1)]
        public byte TP_pid
        {
            get { return m_nTP_pid; }
            set { m_nTP_pid = value; }
        }
        /// <summary>
        ///TP_udhi	1	Integer	GSM协议类型。详细解释请参考GSM03.40中的9.2.3.23,仅使用1位，右对齐
        /// </summary>
        [SGIP_Property(false, 16, 1)]
        public byte TP_udhi
        {
            get { return m_nTP_udhi; }
            set { m_nTP_udhi = value; }
        }
        /// <summary>
        ///MessageCoding	1	Integer	短消息的编码格式。0：纯ASCII字符串3：写卡操作4：二进制编码8：UCS2编码15: GBK编码其它参见GSM3.38第4节：SMS Data Coding Scheme
        /// </summary>
        [SGIP_Property(false, 17, 1)]
        public SGIP_MessageCodings MessageCoding
        {
            get { return m_nMessageCoding; }
            set { m_nMessageCoding = value; }
        }
        /// <summary>
        ///MessageType	1	Integer	信息类型：0-短消息信息其它：待定
        /// </summary>
        [SGIP_Property(false, 18, 1)]
        public byte MessageType
        {
            get { return m_nMessageType; }
            set { m_nMessageType = value; }
        }
        /// <summary>
        ///MessageLength	4	Integer	短消息的长度
        /// </summary>
        [SGIP_Property(false, 19, 4)]
        public uint SMMessageLength
        {
            get { return m_nSMMessageLength; }
            set { m_nSMMessageLength = value; }
        }
        /// <summary>
        ///MessageContent	Message Length	Text	短消息的内容
        /// </summary>
        [SGIP_Property(false, 20, -1)]
        public string MessageContent
        {
            get { return m_sMessageContent; }
            set { m_sMessageContent = value; }
        }
        /// <summary>
        ///Reserve	8	Text	保留，扩展用
        /// </summary>
        [SGIP_Property(false, 21, 8)]
        public string Reserve
        {
            get { return m_sReserve; }
            set { m_sReserve = value; }
        }

        protected override uint PackToField(SGIP_Field Field, byte[] Pack, uint Offset)
        {
            if (Field.IsProperty("MessageContent"))
            {
                //Field.ProAttribute.Length = (int)m_nSMMessageLength;

                byte[] buf = new byte[m_nSMMessageLength];
                Array.Copy(Pack, Offset, buf, 0, m_nSMMessageLength);

                if (m_nMessageCoding == SGIP_MessageCodings.Ucs2)
                {
                    m_sMessageContent = Encoding.BigEndianUnicode.GetString(buf, 0, buf.Length);
                }
                else if (m_nMessageCoding == SGIP_MessageCodings.Gbk)
                {
                    m_sMessageContent = Encoding.GetEncoding("gb2312").GetString(buf, 0, buf.Length);
                }
                else
                {
                    m_sMessageContent = Encoding.ASCII.GetString(buf, 0, buf.Length);
                }
                Field.ProAttribute.Length = buf.Length;
                Field.Build();

                return (uint)buf.Length;
            }
            return base.PackToField(Field, Pack, Offset);
        }
        protected override uint FieldToPack(SGIP_Field Field, byte[] Pack, uint Offset)
        {
            if (Field.IsProperty("SMMessageLength"))
            {
                if (m_nMessageCoding == SGIP_MessageCodings.Ucs2)
                {
                    m_nSMMessageLength = (uint)Encoding.BigEndianUnicode.GetByteCount(m_sMessageContent);
                }
                else if (m_nMessageCoding == SGIP_MessageCodings.Gbk)
                {
                    m_nSMMessageLength = (uint)Encoding.GetEncoding("gb2312").GetByteCount(m_sMessageContent);
                }
                else
                {
                    m_nSMMessageLength = (uint)Encoding.ASCII.GetByteCount(m_sMessageContent);
                }
                Field.ProInfo.SetValue(this, m_nSMMessageLength, null);
                Field.Build();
            }
            else if (Field.IsProperty("MessageContent"))
            {
                //Field.ProAttribute.Length = (int)(System.Text.Encoding.Default.GetByteCount(null == m_sMessageContent ? "" : m_sMessageContent)); 
                byte[] buf;
                if (m_nMessageCoding == SGIP_MessageCodings.Ucs2)
                {
                    buf = Encoding.BigEndianUnicode.GetBytes(m_sMessageContent);
                }
                else if (m_nMessageCoding == SGIP_MessageCodings.Gbk)
                {
                    buf = Encoding.GetEncoding("gb2312").GetBytes(m_sMessageContent);
                }
                else
                {
                    buf = Encoding.ASCII.GetBytes(m_sMessageContent);
                }
                Array.Copy(buf, 0, Pack, Offset, buf.Length);
                Field.ProAttribute.Length = buf.Length;

                return (uint)buf.Length;
            }
            else if (Field.IsProperty("ChargeNumber"))
            {
                if (m_sChargeNumber != null && m_sChargeNumber.StartsWith("0000") == false
                    && m_sChargeNumber.Length > 0 && m_sChargeNumber.StartsWith("86") == false)
                {
                    m_sChargeNumber = "86" + m_sChargeNumber;
                }
            }
            else if (Field.IsProperty("UserNumber"))
            {
                if (m_sUserNumber.StartsWith("86") == false)
                {
                    m_sUserNumber = "86" + m_sUserNumber;
                }
            }

            return base.FieldToPack(Field, Pack, Offset);
        }
    }
    public class SGIP_Deliver : SGIP_CommandHead
    {
        public SGIP_Deliver()
            : base(SGIP_CommandIDs.SGIP_DELIVER)
        {
        }

        private string m_sUserNumber = null;
        private string m_sSPNumber = null;
        private byte m_nTP_pid = 0;
        private byte m_nTP_udhi = 0;
        private SGIP_MessageCodings m_nMessageCoding = SGIP_MessageCodings.Gbk;
        private uint m_nSMMessageLength = 0;
        private string m_sMessageContent = null;
        private string m_sReserve = null;

        /// <summary>
        ///UserNumber	21	Text	发送短消息的用户手机号，手机号码前加“86”国别标志
        /// </summary>
        [SGIP_Property(false, 0, 21)]
        public string UserNumber
        {
            get { return m_sUserNumber; }
            set { m_sUserNumber = value; }
        }
        /// <summary>
        ///SPNumber	21	Text	SP的接入号码
        /// </summary>
        [SGIP_Property(false, 1, 21)]
        public string SPNumber
        {
            get { return m_sSPNumber; }
            set { m_sSPNumber = value; }
        }
        /// <summary>
        ///TP_pid	1	Integer	GSM协议类型。详细解释请参考GSM03.40中的9.2.3.9
        /// </summary>
        [SGIP_Property(false, 2, 1)]
        public byte TP_pid
        {
            get { return m_nTP_pid; }
            set { m_nTP_pid = value; }
        }
        /// <summary>
        ///TP_udhi	1	Integer	GSM协议类型。详细解释请参考GSM03.40中的9.2.3.23,仅使用1位，右对齐
        /// </summary>
        [SGIP_Property(false, 3, 1)]
        public byte TP_udhi
        {
            get { return m_nTP_udhi; }
            set { m_nTP_udhi = value; }
        }
        /// <summary>
        ///MessageCoding	1	Integer	短消息的编码格式。
        /// </summary>
        [SGIP_Property(false, 4, 1)]
        public SGIP_MessageCodings MessageCoding
        {
            get { return m_nMessageCoding; }
            set { m_nMessageCoding = value; }
        }
        /// <summary>
        ///MessageLength	4	Integer	短消息的长度
        /// </summary>
        [SGIP_Property(false, 5, 4)]
        public uint SMMessageLength
        {
            get { return m_nSMMessageLength; }
            set { m_nSMMessageLength = value; }
        }
        /// <summary>
        ///MessageContent	Message Length	Text	短消息的内容
        /// </summary>
        [SGIP_Property(false, 6, -1)]
        public string MessageContent
        {
            get { return m_sMessageContent; }
            set { m_sMessageContent = value; }
        }
        /// <summary>
        ///Reserve	8	Text	保留，扩展用
        /// </summary>
        [SGIP_Property(false, 7, 8)]
        public string Reserve
        {
            get { return m_sReserve; }
            set { m_sReserve = value; }
        }

        protected override uint PackToField(SGIP_Field Field, byte[] Pack, uint Offset)
        {
            if (Field.IsProperty("MessageContent"))
            {
                //Field.ProAttribute.Length = (int)this.m_nSMMessageLength;
                if (m_nSMMessageLength <= 0)
                {
                    m_sMessageContent = "";
                    Field.ProAttribute.Length = 0;
                }
                else
                {
                    byte[] buf = new byte[m_nSMMessageLength];
                    Array.Copy(Pack, Offset, buf, 0, m_nSMMessageLength);

                    if (m_nMessageCoding == SGIP_MessageCodings.Ucs2)
                    {
                        m_sMessageContent = Encoding.BigEndianUnicode.GetString(buf, 0, buf.Length);
                    }
                    else if (m_nMessageCoding == SGIP_MessageCodings.Gbk)
                    {
                        m_sMessageContent = Encoding.GetEncoding("gb2312").GetString(buf, 0, buf.Length);
                    }
                    else
                    {
                        m_sMessageContent = Encoding.ASCII.GetString(buf, 0, buf.Length);
                    }
                    Field.ProAttribute.Length = (int)m_nSMMessageLength;
                }
                Field.Build();
                return (uint)Field.ProAttribute.Length;
            }
            return base.PackToField(Field, Pack, Offset);
        }
        protected override uint FieldToPack(SGIP_Field Field, byte[] Pack, uint Offset)
        {
            if (Field.IsProperty("SMMessageLength"))
            {
                if (m_nMessageCoding == SGIP_MessageCodings.Ucs2)
                {
                    m_nSMMessageLength = (uint)Encoding.BigEndianUnicode.GetByteCount(m_sMessageContent);
                }
                else if (m_nMessageCoding == SGIP_MessageCodings.Gbk)
                {
                    m_nSMMessageLength = (uint)Encoding.GetEncoding("gb2312").GetByteCount(m_sMessageContent);
                }
                else
                {
                    m_nSMMessageLength = (uint)Encoding.ASCII.GetByteCount(m_sMessageContent);
                }

                Field.ProInfo.SetValue(this, m_nSMMessageLength, null);
                Field.Build();
            }
            else if (Field.IsProperty("MessageContent"))
            {
                //Field.ProAttribute.Length = (int)(System.Text.Encoding.Default.GetByteCount(null == m_sMessageContent ? "" : m_sMessageContent));
                byte[] buf;
                if (m_nMessageCoding == SGIP_MessageCodings.Ucs2)
                {
                    buf = Encoding.BigEndianUnicode.GetBytes(m_sMessageContent);
                }
                else if (m_nMessageCoding == SGIP_MessageCodings.Gbk)
                {
                    buf = Encoding.GetEncoding("gb2312").GetBytes(m_sMessageContent);
                }
                else
                {
                    buf = Encoding.ASCII.GetBytes(m_sMessageContent);
                }
                Array.Copy(buf, 0, Pack, Offset, buf.Length);
                Field.ProAttribute.Length = buf.Length;

                return (uint)buf.Length;
            }
            return base.FieldToPack(Field, Pack, Offset);
        }
    }
    public class SGIP_Report : SGIP_CommandHead
    {
        public SGIP_Report()
            : base(SGIP_CommandIDs.SGIP_REPORT)
        {
        }

        private uint m_nReportSourceNodeNo = 0;
        private uint m_nReportCreateTime = 0;
        private uint m_nReportMessageSN = 0;
        private SGIP_ReportTypes m_nReportType = SGIP_ReportTypes.Submit;
        private string m_sUserNumber = null;
        private SGIP_ReportStates m_nState = SGIP_ReportStates.Success;
        private SGIP_ErrorCodes m_nErrorCode = 0;
        private string m_Reserve = null;

        /// <summary>
        /// 1/3 Sequence Number	 12	 Integer	序列号:命令源节点编号
        /// </summary>
        [SGIP_Property(false, 0, 4)]
        public uint ReportSourceNodeNo
        {
            get { return m_nReportSourceNodeNo; }
            set { m_nReportSourceNodeNo = value; }
        }
        /// <summary>
        /// 2/3 Sequence Number	 12	 Integer	序列号:命令产生的时间
        /// </summary>
        [SGIP_Property(false, 1, 4)]
        public uint ReportCreateTime
        {
            get { return m_nReportCreateTime; }
            set { m_nReportCreateTime = value; }
        }
        /// <summary>
        /// 3/3 Sequence Number	 12	 Integer	序列号:序号
        /// </summary>
        [SGIP_Property(false, 2, 4)]
        public uint ReportMessageSN
        {
            get { return m_nReportMessageSN; }
            set { m_nReportMessageSN = value; }
        }

        [SGIP_Property(false, 3, 1)]
        public SGIP_ReportTypes ReportType
        {
            get { return m_nReportType; }
            set { m_nReportType = value; }
        }
        /// <summary>
        ///UserNumber	21	Text	接收短消息的手机号，手机号码前加“86”国别标志
        /// </summary>
        [SGIP_Property(false, 4, 21)]
        public string UserNumber
        {
            get { return m_sUserNumber; }
            set { m_sUserNumber = value; }
        }
        /// <summary>
        ///State	1	Integer	该命令所涉及的短消息的当前执行状态
        /// </summary>
        [SGIP_Property(false, 5, 1)]
        public SGIP_ReportStates State
        {
            get { return m_nState; }
            set { m_nState = value; }
        }
        /// <summary>
        ///ErrorCode	1	Integer	当State=2时为错误码值，否则为0
        /// </summary>
        [SGIP_Property(false, 6, 1)]
        public SGIP_ErrorCodes ErrorCode
        {
            get { return m_nErrorCode; }
            set { m_nErrorCode = value; }
        }
        /// <summary>
        ///Reserve	8	Text	保留，扩展用
        /// </summary>
        [SGIP_Property(false, 7, 8)]
        public string Reserve
        {
            get { return m_Reserve; }
            set { m_Reserve = value; }
        }
    }
}
