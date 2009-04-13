using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using FT.Windows.Forms;
using System.Collections;
using FT.Windows.CommonsPlugin;
using FT.Commons.Cache;
using FT.Windows.Forms.Domain;
using FT.Device.IDCard;

namespace DS.Plugins.Student
{
    public partial class StudentBrowser : FT.Windows.Forms.DataBrowseForm
    {
        public StudentBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region �������ʵ�ֵ�
        public StudentBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public StudentBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                
                FT.Windows.CommonsPlugin.BindingHelper.BindProvince(this.cbRegProvince);
                DictManager.BindComeFrom(this.cbComeFrom);
                DictManager.BindBelongArea(this.cbBelongArea);

                this.cbRegProvince.Text=FT.Windows.CommonsPlugin.BindingHelper.GetDefaultProvince();
                this.cbRegCity.Text = FT.Windows.CommonsPlugin.BindingHelper.GetDefaultCity();
               // this.SetAddress();
                
                this.txtDescription.KeyDown+=new KeyEventHandler(txtDescription_KeyDown);
                this.cbSex.SelectedIndex = 0;
               
                this.cbListen.SelectedIndex = 1;
                this.cbMainBody.SelectedIndex = 1;
                this.cbTopBody.SelectedIndex = 1;
                this.cbLeftDownBody.SelectedIndex = 1;
                this.cbRightDownBody.SelectedIndex = 1;
                this.cbColor.SelectedIndex = 1;
                this.cbLearnType.SelectedIndex = 0;
                
                DictManager.BindIdCardType(this.cbIdCardType);
                DictManager.BindNation(this.cbNation);
                DictManager.BindCarTypeDynamic(this.cbNewCarType);
               
                DictManager.BindCarStyle(this.cbNewCarStyle);
                DictManager.BindFromRoute(this.cbFromRoute);
                DictManager.BindHospital(this.cbHospital);
                DS.Plugins.Car.BindingHelper.BindCoach(this.cbCoachName);
                DictManager.BindRecommend(this.cbRecommend);
                

                this.cbNewCarType.SelectedValue = "C1";
                //ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(CarInfo));
                //if (lists.Count > 0)
                //{
                //    //this.cbGroup
                //    this.cbHmhp.DataSource = lists;
                //    this.cbHmhp.DisplayMember = "�������";
                //    this.cbHmhp.ValueMember = "�������";
                //    this.cbHmhp.SelectedIndex = 0;
                //}
                //FT.Windows.CommonsPlugin.Entity.DictManager.BindToCombox(this.cbCarType, "׼�ݳ���");
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// ����ʵ������,��ʵ�������һ��Id������
        /// </summary>
        /// <returns>ʵ�����</returns>
        protected override object GetEntity()
        {
            return new StudentInfo();
            //   return null;
        }
        #endregion

        #region ��֤����

        private void txtHeight_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "��߱��������֣�", true);
        }

        private void txtLeftEye_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "�������������֣�", true);
        }

        private void txtRightEye_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, "�������������֣�", true);
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tabControl1.SelectedIndex = 1;
                // e.
                this.txtHeight.Focus();
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "��������Ϊ�գ�");
        }

        private void txtTempId_Validating(object sender, CancelEventArgs e)
        {
            //this.ValidateNotNull(sender, e, "��ס֤����Ϊ�գ�");
        }

        private void txtIdCard_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbIdCardType.SelectedIndex == 0)
            {
                this.ValidateIdCard(sender, e, false);
            }
        }

        private void txtPostCode_Validating(object sender, CancelEventArgs e)
        {
            this.ValidatePostCode(sender, e, "��������ȷ���������룡", false);
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "��ϵ�绰1����Ϊ�գ�");
        }

        private void txtRegAddress_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "סַ��ַ����Ϊ�գ�");
        }

        private void txtConnAddress_Validating(object sender, CancelEventArgs e)
        {
                this.ValidateNotNull(sender, e, "��ϵ��ַ����Ϊ�գ�");
            }
        #endregion

        #region ������������
        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        private string ComputeDimension()
        {
            CompanyInfo comp=StaticCacheManager.GetConfig<CompanyInfo>();

            ProgramRegConfig reg=StaticCacheManager.GetConfig<ProgramRegConfig>();

            string idtypecode=this.cbIdCardType.SelectedValue.ToString();
            string areacode = this.cbBelongArea.SelectedValue.ToString();
            string car = this.cbNewCarType.SelectedValue.ToString();
            int sexcode=(this.cbSex.SelectedIndex+1);
            string id = StudentHelper.TransIdCard(idtypecode, this.txtIdCard.Text.Trim());
            StringBuilder sb = new StringBuilder("jsyxx");
            StudentHelper.AppendString(sb, StudentHelper.Encode(id +car + areacode));
            StudentHelper.AppendString(sb, id);
            StudentHelper.AppendString(sb, idtypecode);
            StudentHelper.AppendString(sb, this.txtName.Text.Trim());
            StudentHelper.AppendString(sb, sexcode.ToString());
            StudentHelper.AppendString(sb, this.dateBirthday.Value.ToString("yyyy-MM-dd"));
            StudentHelper.AppendString(sb, this.cbNation.SelectedValue.ToString());
            StudentHelper.AppendString(sb, this.cbRegArea.SelectedValue.ToString());
            StudentHelper.AppendString(sb, this.txtRegAddress.Text.Trim());

            StudentHelper.AppendString(sb, areacode);
            StudentHelper.AppendString(sb, this.txtConnAddress.Text.Trim());
            StudentHelper.AppendString(sb, this.txtPostCode.Text.Trim());
            StudentHelper.AppendString(sb, this.txtPhone.Text.Trim());
            StudentHelper.AppendString(sb, areacode);
            StudentHelper.AppendString(sb, car);
            StudentHelper.AppendString(sb, this.cbComeFrom.SelectedValue.ToString());
            StudentHelper.AppendString(sb, this.txtTempId.Text.Trim());

            StudentHelper.AppendString(sb, comp.No);//38?ѧУ���� jxmc ��У����
            StudentHelper.AppendString(sb, this.cbCoachName.Text);//��������ã� ����Ա1 
            StudentHelper.AppendString(sb, this.txtHeight.Text.Trim());
            StudentHelper.AppendString(sb, this.txtLeftEye.Text.Trim());
            StudentHelper.AppendString(sb, this.txtRightEye.Text.Trim());
            //0Ϊ���ϸ�1 Ϊ�ϸ� �ϸ��combox�����ǣ�
            StudentHelper.AppendString(sb, this.cbColor.SelectedIndex.ToString());
            StudentHelper.AppendString(sb, this.cbListen.SelectedIndex.ToString());
            StudentHelper.AppendString(sb, this.cbTopBody.SelectedIndex.ToString());

            StudentHelper.AppendString(sb, this.cbLeftDownBody.SelectedIndex.ToString());
            StudentHelper.AppendString(sb, this.cbRightDownBody.SelectedIndex.ToString());
            StudentHelper.AppendString(sb, this.cbMainBody.SelectedIndex.ToString());
            StudentHelper.AppendString(sb, this.cbHospital.Text);//ҽԺ��Ż���ҽԺ������Ϣ�� ���ҽԺ����
            StudentHelper.AppendString(sb, this.dateCheckDate.Value.ToString("yyyy-MM-dd"));
            StudentHelper.AppendString(sb, reg.RightCode.Replace("-", "").Replace("��", ""));
            Console.WriteLine("��ά�������ݣ�" + sb.ToString());
            return sb.ToString();
        }
        #endregion

        #region �����

        private bool CheckBirthDay(int beginage, int endage)
        {
            DateTime begin = this.dateBirthday.Value.AddYears(beginage);
            DateTime end = this.dateBirthday.Value.AddYears(endage + 1);
            DateTime now = System.DateTime.Now.AddYears(1);
            return now > begin && now < end;
        }

        /// <summary>
        /// ��֤����
        /// </summary>
        /// <returns></returns>
        private bool CheckRegAddress()
        {
            if (this.cbNation.SelectedValue == null)
            {
                MessageBoxHelper.Show("����ֻ��ѡ�񣬲������䣡");
                this.tabControl1.SelectedIndex = 0;
                this.cbNation.Focus();
                return false;
            }
            if (this.cbRegProvince.SelectedValue == null)
            {
                MessageBoxHelper.Show("��ѡ��������֤��ʡ�ݣ�");
                this.tabControl1.SelectedIndex = 0;
                this.cbRegProvince.Focus();
                return false;
            }
            if (this.cbRegCity.SelectedValue == null)
            {
                MessageBoxHelper.Show("��ѡ��������֤��������");
                this.tabControl1.SelectedIndex = 0;
                this.cbRegCity.Focus();
                return false;
            }
            if (this.cbRegArea.SelectedValue == null)
            {
                MessageBoxHelper.Show("��ѡ��������֤��������");
                this.tabControl1.SelectedIndex = 0;
                this.cbRegArea.Focus();
                return false;
            }

            if (!this.CheckBirthDay(18, 70))
            {
                MessageBoxHelper.Show("�����ʻ֤�����������18�굽70��֮�䣡");
                this.tabControl1.SelectedIndex = 0;
                this.dateBirthday.Focus();
                return false;
            }

            int height = 0;
            AllPrinterConfig config = AllPrinterConfig.GetPrinterConfig();
            if (config.ApplyConfig.IsBodyCheck)
            {
                try
                {
                    height = int.Parse(this.txtHeight.Text.ToString());
                    if (height == 0)
                    {
                        MessageBoxHelper.Show("��߱������0��");
                        this.tabControl1.SelectedIndex = 1;
                        this.txtHeight.Focus();
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    height = 0;
                    MessageBoxHelper.Show("��߱�����������");
                    this.tabControl1.SelectedIndex = 1;
                    this.txtHeight.Focus();
                    return false;
                }


            }

            string car = this.cbNewCarType.Text;
            if (car == "C1" || car == "C2" || car == "F")
            {
                if (!this.CheckBirthDay(18, 70))
                {
                    MessageBoxHelper.Show("���복��C1��C2��Fʱ�����������18��70����֮�䣡");
                    
                    this.tabControl1.SelectedIndex = 0;
                    this.cbNewCarType.Focus();
                    return false;
                }
            }
            if (car == "C3" || car == "C4" || car == "D" || car == "E" || car == "M")
            {
                if (!this.CheckBirthDay(18, 60))
                {
                    MessageBoxHelper.Show("���복��C3��C4��D��E��Mʱ�����������18��60����֮�䣡");
                    this.tabControl1.SelectedIndex = 0;
                    this.cbNewCarType.Focus();
                    return false;
                }
            }
            if (car == "B1" || car == "B2" || car == "A3" || car == "N" || car == "P")
            {
                if (!this.CheckBirthDay(21, 50))
                {
                    MessageBoxHelper.Show("���복��B1��B2��A3��N��Pʱ�����������21��50����֮�䣡");
                    this.tabControl1.SelectedIndex = 0;
                    this.cbNewCarType.Focus();
                    return false;
                }
            }
            if (car == "A2")
            {
                if (!this.CheckBirthDay(24, 50))
                {
                    MessageBoxHelper.Show("���복��A2ʱ�����������24��50����֮�䣡");
                    this.tabControl1.SelectedIndex = 0;
                    this.cbNewCarType.Focus();
                    return false;
                }
            }
            if (car == "A1")
            {
                if (!this.CheckBirthDay(26, 50))
                {
                    MessageBoxHelper.Show("���복��A1ʱ�����������26��50����֮�䣡");
                    this.tabControl1.SelectedIndex = 0;
                    this.cbNewCarType.Focus();
                    return false;
                }
            }
            decimal stature;
            try
            {
                stature = height;
                if (car == "A1" || car == "A2" || car == "A3" || car == "B2" || car == "N")
                {
                    if (config.ApplyConfig.IsBodyCheck && stature < 155)
                    {
                        MessageBoxHelper.Show("���복��A1��A2��A3��B2��Nʱ���������155�������ϣ�");
                        this.tabControl1.SelectedIndex = 1;
                        this.txtHeight.Focus();
                        return false;
                    }
                }
                if (car == "B1")
                {
                    if (config.ApplyConfig.IsBodyCheck && stature < 150)
                    {
                        MessageBoxHelper.Show("���복��B1ʱ���������150�������ϣ�");
                        this.tabControl1.SelectedIndex = 1;
                        this.txtHeight.Focus();
                        return false;
                    }
                }
            }
            catch
            {
                MessageBoxHelper.Show("��߱���Ϊ����");
                this.tabControl1.SelectedIndex = 1;
                this.txtHeight.Focus();
                return false;
            }


            if (config.ApplyConfig.IsBodyCheck)
            {
                double leftEye = 0;
                try
                {
                    leftEye = double.Parse(this.txtLeftEye.Text.ToString());
                }
                catch
                {
                    MessageBoxHelper.Show("����������Ϊ����");
                    this.tabControl1.SelectedIndex = 1;
                    this.txtLeftEye.Focus();
                    return false;
                }
                double rightEye = 0;
                try
                {
                    rightEye = double.Parse(this.txtRightEye.Text.ToString());
                }
                catch
                {
                    MessageBoxHelper.Show("����������Ϊ����");
                    this.tabControl1.SelectedIndex = 1;
                    this.txtRightEye.Focus();
                    return false;
                }
                int dec = int.Parse(System.Configuration.ConfigurationManager.AppSettings["EyeDecimal"]);
                int temp = 1;
                if (dec == 0)
                {
                    temp *= 10;
                }
                if (car == "A1" || car == "A2" || car == "A3" || car == "B1" || car == "B2" || car == "N" || car == "P")
                {

                    if (leftEye < 5.0 * temp || rightEye < 5.0 * temp)
                    {
                        MessageBoxHelper.Show("���복��" + car + "ʱ����������������" + 5.0 * temp + "����");
                        this.tabControl1.SelectedIndex = 1;
                        this.txtLeftEye.Focus();
                        return false;
                    }
                }
                else
                {
                    if (leftEye < 4.9 * temp || rightEye < 4.9 * temp)
                    {
                        MessageBoxHelper.Show("���복��" + car + "ʱ����������������" + 4.9 * temp + "����");
                        this.tabControl1.SelectedIndex = 1;
                        this.txtRightEye.Focus();
                        return false;
                    }
                }
                if (this.cbLeftDownBody.SelectedIndex == 0 && this.cbNewCarType.Text != "C2")
                {
                    MessageBoxHelper.Show("����֫���ϸ���ֻ������C2��");
                    this.tabControl1.SelectedIndex = 1;
                    this.cbLeftDownBody.Focus();
                    return false;
                }

                if (this.cbHospital.Text.Trim() == string.Empty)
                {
                    MessageBoxHelper.Show("�����������ҽԺ��");
                    this.tabControl1.SelectedIndex = 1;
                    this.cbHospital.Focus();
                    return false;
                }
            }
            return true;
        }
        protected override bool CheckBeforeCreate()
        {
            return this.CheckRegAddress();
        }
        protected override bool CheckBeforeUpdate()
        {
            return this.CheckRegAddress();
        }

        protected override void BeforeSave(object entity)
        {
            string dimension = this.ComputeDimension();
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "Dimension", dimension);
            base.BeforeSave(entity);
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "CoachId", this.cbCoachName.SelectedValue.ToString());
        }

        protected override void BeforeCreateEntity(object entity)
        {
            base.BeforeCreateEntity(entity);
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "BaoMingDate", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        #endregion


        #region ��������
        private void InitByIdCard(string idcard)
        {
            this.cbRegProvince.SelectedValue = IDCardHelper.GetProvince(idcard);
            if (this.cbRegProvince.SelectedValue == null)
            {
                MessageBoxHelper.Show("��֤������������������ֶ�ѡ��");
                return;
                //this.cbArea.SelectedIndex = 0;
            }
            //Constant.InitCity(this.cbCity, this.cbProvince.SelectedValue.ToString());
            this.cbRegCity.SelectedValue = IDCardHelper.GetCity(idcard);
            if (this.cbRegCity.SelectedValue == null)
            {
                MessageBoxHelper.Show("��֤������������������ֶ�ѡ��");

                return;
                //this.cbArea.SelectedIndex = 0;
            }
            //Constant.InitAreaCode(this.cbArea, this.cbCity.SelectedValue.ToString());
            this.cbRegArea.SelectedValue = IDCardHelper.GetArea(idcard);

            if (this.cbRegArea.SelectedValue == null)
            {
                MessageBoxHelper.Show("��֤������������������ֶ�ѡ��");

                return;
                //this.cbArea.SelectedIndex = 0;
            }
            else
            {
                this.cbBelongArea.SelectedValue = this.cbRegArea.SelectedValue;
                if (this.cbBelongArea.SelectedValue == null)
                {
                    this.cbBelongArea.SelectedIndex = 0;
                }
            }
        }


        private void cbRegProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            FT.Windows.CommonsPlugin.BindingHelper.BindCity(this.cbRegCity,this.cbRegProvince.SelectedValue.ToString());
            this.SetAddress();
        }

        private void cbRegCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            object obj=this.cbRegCity.SelectedValue;
            if(obj!=null)
            {
                FT.Windows.CommonsPlugin.BindingHelper.BindArea(this.cbRegArea, obj.ToString());
            }
            this.SetAddress();
        }

        private void cbBelongArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string area = this.cbBelongArea.Text;
            if (area != null)
            {
                FT.Windows.CommonsPlugin.BindingHelper.BindXiang(this.cbBelongXiang, area);
            }
            this.txtConnAddress.Text = FT.Windows.CommonsPlugin.BindingHelper.GetAreaPrefix() + this.cbBelongArea.Text;
        }

        private void cbBelongXiang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string area = this.cbBelongArea.Text;
            string xiang = this.cbBelongXiang.Text;
            if (xiang != null&&xiang.Length>0)
            {
                FT.Windows.CommonsPlugin.BindingHelper.BindCun(this.cbBelongCun, area,xiang);
            }
        }

        private void SetAddress()
        {
            this.txtRegAddress.Text = this.cbRegProvince.Text + this.cbRegCity.Text + this.cbRegArea.Text;

        }

        private void cbRegArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbRegArea_TextChanged(object sender, EventArgs e)
        {
            this.SetAddress();
            this.SetStudentFrom();
            this.cbBelongArea.Text = this.cbRegArea.Text;
        }

        /// <summary>
        /// ����֤�������ж�ѧ����Դ�Ǳ��ػ������
        /// </summary>
        private void SetStudentFrom()
        {
            if (this.cbRegCity.SelectedValue != null)
            {
                string str = this.cbRegCity.SelectedValue.ToString().Substring(0, 4);
                if (this.cbBelongArea.SelectedValue != null)
                {
                    string belong = this.cbBelongArea.SelectedValue.ToString().Substring(0, 4);
                    if (belong == str)
                    {
                        this.cbComeFrom.SelectedIndex = 0;//����
                    }
                    else
                    {
                        this.cbComeFrom.SelectedIndex = 1;//���
                    }
                }
            }
            else
            {
                this.cbComeFrom.SelectedIndex = 0;//����
            }
        }

        

        #endregion


        #region ��ʼ������
        private IDCardReaderHelper reader = null;
        private void AfterReadIdCard(IDCard card)
        {
            //TODO,�������������ʵ��
            this.txtName.Text = card.Name;
            this.txtIdCard.Text = card.IDC;
            this.InitByIdCard(this.txtIdCard.Text);
            this.txtRegAddress.Text=this.txtConnAddress.Text = card.ADDRESS;
            this.dateBirthday.Value = card.BIRTH;
            this.cbSex.Text = IDCardHelper.GetSexName(card.IDC);
        }
        private void StudentBrowser_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                IDCardConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<IDCardConfig>();
                if (config.UseIDCard)
                    reader = new IDCardReaderHelper(new De_ReadICCardComplete(AfterReadIdCard));
                this.txtDescription.KeyDown -= new KeyEventHandler(FormHelper.EnterToTab);
                if (this.entity != null)
                {
                    object city = FormHelper.GetObjectValue(this.entity, "RegCity");
                    object area = FormHelper.GetObjectValue(this.entity, "RegArea");
                    object regaddress = FormHelper.GetObjectValue(this.entity, "RegAddress");
                    object connaddress = FormHelper.GetObjectValue(this.entity, "ConnAddress");
                    object cun = FormHelper.GetObjectValue(this.entity, "BelongCun");
                    object xiang = FormHelper.GetObjectValue(this.entity, "BelongXiang");
                    if (city != null)
                    {
                        this.cbRegCity.Text = city.ToString();
                    }
                    if (area != null)
                    {
                        this.cbRegArea.Text = area.ToString();
                    }
                    if (regaddress != null)
                    {
                        this.txtRegAddress.Text = regaddress.ToString();
                    }
                    if (connaddress != null)
                    {
                        this.txtConnAddress.Text = connaddress.ToString();
                    }
                    if (xiang != null)
                    {
                        this.cbBelongXiang.Text = xiang.ToString();
                    }
                    if (cun != null)
                    {
                        this.cbBelongCun.Text = cun.ToString();
                    }

                }
                else
                {
                    this.SetAddress();
                }
            }
        }
        #endregion

        #region ����
        private void txtRegAddress_TextChanged(object sender, EventArgs e)
        {
            if (this.txtRegAddress.Text.StartsWith(FT.Windows.CommonsPlugin.BindingHelper.GetAreaPrefix()))
            {
                this.txtConnAddress.Text = this.txtRegAddress.Text;
            }
        }

        private void txtIdCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter&&this.cbIdCardType.SelectedIndex==0)
            {
                string id = this.txtIdCard.Text.Trim();
                if (this.lbId.Text.Length == 0)
                {
                    ArrayList students = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<StudentInfo>(" where c_state<>'�ϸ��ҵ' and c_state<>'��ѧ' and c_idcard='"+id+"'");
                    if (students != null && students.Count > 0)
                    {
                        MessageBoxHelper.Show("���֤��Ϊ"+id+"��ѧԱ������ѧ״̬,׼����ȡ��ǰ��Ϣ��");
                        StudentInfo student = students[0] as StudentInfo;
                        FormHelper.SetDataToForm(this, student);
                        this.entity = student;

                    }
                    else
                    {
                        students = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<StudentInfo>(" where (c_state='�ϸ��ҵ' or c_state='��ѧ') and c_idcard='" + id + "'");
                        if (students != null && students.Count > 0)
                        {
                            MessageBoxHelper.Show("���֤��Ϊ" + id + "��ѧԱ�����ڱ�Уѧϰ��,׼����ȡ������Ϣ��");
                            StudentInfo student1 = students[0] as StudentInfo;
                            FormHelper.SetDataToForm(this, student1);
                            this.lbId.Text = string.Empty;
                            this.lbBaoMingDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            this.lbState.Text = "��ʼ����";
                            this.cbLearnType.SelectedIndex = 1;
                            this.txtExamDate.Text = string.Empty;
                            this.txtExamId.Text = string.Empty;
                            this.txtHeight.Text = string.Empty;
                            this.txtLeftEye.Text = string.Empty;
                            this.txtRightEye.Text = string.Empty;
                            this.lbPrintedState.Text = "δ��ӡ";

                        }
                        else if (id.Length != 0)//��ѧԱ
                        {
                            try
                            {
                                this.InitByIdCard(id);
                                this.dateBirthday.Value = IDCardHelper.GetBirthday(id);
                                this.cbSex.Text = IDCardHelper.GetSexName(id);
                            }
                            catch (Exception ex)
                            {
                                //this.SetError(sender, "�ֻ������ʽ����");
                                //MessageBoxHelper.Show("����:"+ex.Message);
                            }
                        }
                        
                    }
                    
                }
                
            }
        }

        private void cbIdCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbIdCardType.SelectedIndex == 0)
            {
                this.cbSex.Enabled = false;
                this.dateBirthday.Enabled = false;
            }
            else
            {
                this.cbSex.Enabled = true;
                this.dateBirthday.Enabled = true;
            }
        }

        private void txtExamDate_Validating(object sender, CancelEventArgs e)
        {
            string date = this.txtExamDate.Text.Trim();
            if (date.Length > 0)
            {
                try
                {
                    Convert.ToDateTime(date);
                    this.ClearError(sender);
                    e.Cancel = false;
                }
                catch
                {
                    this.SetError(sender, "���ڸ�ʽ������yyyy-MM-dd!");
                    e.Cancel = true;
                }
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }
        #endregion

        #region ѧ�ѣ����Ե����
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbId.Text.Trim().Length > 0 && this.lbId.Text.Trim() != "0")
            {
                if (this.tabControl1.SelectedIndex == 2)
                {
                    this.ViewFees();
                }
                else if (this.tabControl1.SelectedIndex == 3)
                {
                    this.ViewExam();
                }
            }
        }

        private void ViewExam()
        {
            TabPage tb = this.tabControl1.TabPages[3];
            if (tb.Controls.Count == 0)
            {
                StudentExamSearch exams = new StudentExamSearch();
                exams.AllowCustomeSearch = false;
                exams.Dock = DockStyle.Fill;
                exams.InitBeforeAdd += new ProcessObjectDelegate(exam_InitBeforeAdd);
                tb.Controls.Add(exams);
                exams.ClearColumns();
                exams.CreateColumn("����", 80);
                exams.CreateColumn("���֤������", 120);
                exams.CreateColumn("��������",100);
                exams.CreateColumn("���Կ�Ŀ", 100);
                exams.CreateColumn("���Գɼ�", 100);
                exams.CreateColumn("���Խ��");
                // this.Width += 30;
                exams.SetConditions("c_idcard='" + this.txtIdCard.Text.Trim() + "'");
            }
        }

        void exam_InitBeforeAdd(ref object entity)
        {
            StudentExam tmp = new StudentExam();
            tmp.AllowExamDate = this.txtExamDate.Text.Trim();
            tmp.CoachName = this.cbCoachName.Text;
            tmp.ExamId = this.txtExamId.Text.Trim();
            tmp.IdCard = this.txtIdCard.Text.Trim();
            tmp.Name = this.txtName.Text.Trim();
            tmp.NewCarType = this.cbNewCarType.Text;
            tmp.StudentId = this.lbId.Text;
            entity = tmp;

            //entity = this.entity;
            //throw new Exception("The method or operation is not implemented.");
        }

        private void ViewFees()
        {


            TabPage tb = this.tabControl1.TabPages[2];
            if (tb.Controls.Count == 0)
            {
                StudentFeeSearch fees = new StudentFeeSearch();
                fees.AllowCustomeSearch = false;
                fees.Dock = DockStyle.Fill;
                fees.InitBeforeAdd += new ProcessObjectDelegate(fees_InitBeforeAdd);
                tb.Controls.Add(fees);
                fees.ClearColumns();
                fees.CreateColumn("����", 80);
                fees.CreateColumn("���֤������", 120);
                fees.CreateColumn("����ʱ��", 140);
                fees.CreateColumn("���ý��", 80);
                fees.CreateColumn("�������");
                // this.Width += 30;
                fees.SetConditions("c_idcard='" + this.txtIdCard.Text.Trim() + "'");
            }

        }

        void fees_InitBeforeAdd(ref object entity)
        {
            StudentFee tmp = new StudentFee();
            tmp.IdCard = this.txtIdCard.Text.Trim();
            tmp.Name = this.txtName.Text.Trim();
            entity = tmp;
            //throw new Exception("The method or operation is not implemented.");
        }
        #endregion

        #region ��ѧ����
        private void btnQuit_Click(object sender, EventArgs e)
        {
            if (this.lbId.Text.Length == 0)
            {
                MessageBoxHelper.Show("���ȱ��������ѧ��");
                return;
            }
            else
            {
                StudentInfo student=this.entity as StudentInfo;
                if (student != null)
                {
                    if (student.State == "�ϸ��ҵ")
                    {
                        MessageBoxHelper.Show("�ϸ��ҵ��ѧ���޷���ѧ��");
                        return;
                    }
                    student.State = "��ѧ";
                    if (FT.DAL.Orm.SimpleOrmOperator.Update(student))
                    {
                        MessageBoxHelper.Show("��ѧ�ɹ���");
                        this.lbState.Text = "��ѧ";
                        if (this.refresher != null)
                        {
                            refresher.Update(this.entity);
                        }
                        
                    }
                }
            }
        }
        #endregion
    }
}


