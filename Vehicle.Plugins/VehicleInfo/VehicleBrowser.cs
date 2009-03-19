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

namespace Vehicle.Plugins
{
    public partial class VehicleBrowser : FT.Windows.Forms.DataBrowseForm
    {
        private string color = string.Empty;

        private string rlzl = string.Empty;

        private bool readCompleted = false;

        public VehicleBrowser()
        {
            InitializeComponent();
            this.InitComBox();
        }
        #region �������ʵ�ֵ�
        public VehicleBrowser(object entity):base(entity)
        {
            InitializeComponent();
            this.InitComBox();
           
        }
        public VehicleBrowser(object entity, IRefreshParent refresher)
            : base(entity, refresher)
        {
            InitializeComponent();
            this.InitComBox();
        }

        private void InitComBox()
        {
            if (!this.DesignMode)
            {
                if (this.entity == null)
                {
                    this.lbFirstRegDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                BindHelper.BindIdCardType(this.cbBaseDlrIdCardType);
                BindHelper.BindIdCardType(this.cbBaseJbrIdCardType);
                BindHelper.BindIdCardType(this.cbBaseSyrIdCardType);
                BindHelper.BindTempIdType(this.cbBaseSyrTempIdType);
                BindHelper.BindIdCardType(this.cbBaseDlrIdCardType);

                BindHelper.BindUseFor(this.cbXuUseFor);
                BindHelper.BindGetFrom(this.cbXuGetFrom);
                BindHelper.BindHpzl(this.cbXuHmhp);
                BindHelper.BindLlpz(this.cbXuLlpp1);
                BindHelper.BindLlpz(this.cbXuLlpp2);
                BindHelper.BindSyq(this.cbXuSyq);
                BindHelper.BindGzzmmc(this.cbXuGzzm);
                BindHelper.BindBxCompany(this.cbXuBxCompany);
                DictManager.BindBelongArea(this.cbXuBelongArea);
                BindHelper.BindPzhm(this.cb_xu_jkpzhm);
                BindHelper.BindJkpz(this.cbXuJkPzType);

                BindHelper.BindCllx(this.cbTecCllx);
                BindHelper.BindGcJk(this.cbTecGcjk);
                DictManager.BindNation(this.cbTecZzg);
                BindHelper.BindRlzl(this.cbTecRlzl1);
                BindHelper.BindRlzl(this.cbTecRlzl2);
                BindHelper.BindZxxs(this.cbTecZxfs);
                DictManager.BindCarColorDynamic(this.cbTecColor1);
                DictManager.BindCarColorDynamic(this.cbTecColor2);
                DictManager.BindCarColorDynamic(this.cbTecColor3);

                BindHelper.BindIdCardType(this.cbDyDldwIdCardType);
                BindHelper.BindIdCardType(this.cbDyDyqrIdCardType);
                BindHelper.BindIdCardType(this.cbDyJbrIdCardType);
                
                //ArrayList lists = FT.DAL.Orm.SimpleOrmOperator.QueryListAll(typeof(Province));
                //if (lists.Count > 0)
                //{
                    //this.cbgroup
                   // this.cbFatherCodeValue.DataSource = lists;
                   // this.cbFatherCodeValue.DisplayMember = "ʡ������";
                   // this.cbFatherCodeValue.ValueMember = "ʡ�ݴ���";
                   // this.cbFatherCodeValue.SelectedIndex = 0;
               // }
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
            return new VehicleInfo();
            //   return null;
        }
        #endregion

        protected override void BeforeCreateEntity(object entity)
        {
            base.BeforeCreateEntity(entity);
            
        }

        protected override void AfterSuccessCreate()
        {
            OptLog log = new OptLog();
            log.Clsbm = this.txtTecClsbm.Text.Trim();
            log.OpDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OpDetail = "���εǼǳ���ʶ����Ϊ��" + log.Clsbm;
            log.Operator = UserManager.LoginUser.Name;
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
            base.AfterSuccessCreate();
        }

        protected override void AfterSuccessUpdate()
        {
            OptLog log = new OptLog();
            log.Clsbm = this.txtTecClsbm.Text.Trim();
            log.OpDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OpDetail = "�޸�IDΪ:"+this.lbId.Text+"����ʶ����Ϊ��"+log.Clsbm;
            log.Operator = UserManager.LoginUser.Name;
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
            base.AfterSuccessUpdate();
        }

        private void dateXuJkDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPhotoManage_Click(object sender, EventArgs e)
        {
            PhotoManage form = new PhotoManage();
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }

        private void btnPrintApply_Click(object sender, EventArgs e)
        {

        }

        #region ���ɶ�ά���������
        /*        
QTZS21_V1.0 +����(�������ʹ���+ʹ�����ʴ���+����ʶ�����)+�ϸ�֤���+�����ͺ�+����Ʒ��+Ӣ��Ʒ��+�������ʹ���
+����ʶ�����+��������+���쳧����+��Ϻ�ĳ�����ɫ��1-2-3��+�������ڣ���ʽyyyy-mm-dd��+�������ڴ���+���������
+�������ͺ�+����+����+ȼ������(���룿)+������+������+������+ת����ʽ����+�����ڲ���+�����ڲ���+�����ڲ���
+����������+�ְ嵯��Ƭ��+����+���+��̥��+��̥���+ǰ�־�+���־�+������+��������+�˶��ؿ�+׼ǣ��������
+�˶�������+ǰ���ؿ�+�����ؿ�+���������֤�����ƴ���+���������֤������+����������������+��ϵ�绰+ס�����Ŵ���
+ס����ϸ��ַ+��ס֤��+��������+ʹ�����ʴ���+����Ȩ����+��÷�ʽ����+������������+�����������+����ƾ֤����1
+����ƾ֤1���+����ƾ֤����2+����ƾ֤2���+����˰֤�����ƴ���+��˰֤�����+����ƾ֤��+������Ч����+������ֹ����
+���չ�˾����+����ƾ֤���ʹ���+����ƾ֤���+����ǩ������+����ǩע�����ͺ�+����ǩע������ɫ+����ͬ���+��Ѻ��ͬ���
+��ѺȨ�����֤�����ƴ���+��ѺȨ�����֤������+��ѺȨ������������+��ϵ�绰+ס����ϸ��ַ+��������+��ע+���εǼ�����
+���ۼ۸�+���۵�λ����+����Ȩ�˴���λ���֤�����ƴ���+����Ȩ�˴���λ���֤������+����Ȩ�˴���λ����
+����Ȩ�˴���λ��ϵ�绰+����Ȩ�˴���λ��ϸ��ַ+����Ȩ�˾��������֤�����ƴ���+����Ȩ�˾��������֤�����ƺ���
+����Ȩ�˾���������+����Ȩ�˾�������ϸ��ַ+����Ȩ�˴���λ���֤�����ƴ���+����Ȩ�˴���λ���֤������
+����Ȩ�˴���λ����+����Ȩ�˴���λ��ϵ�绰+����Ȩ�˴���λ��ϸ��ַ+����Ȩ�˾��������֤�����ƴ���
+����Ȩ�˾��������֤������+����Ȩ�˾���������+����Ȩ�˾�������ϸ��ַ+����Ƭ�ͺ�+�����ͺţ���+����˾��λ���룿��
         */

        private string ComputeDimension()
        {
            this.ComputeColorAndOil();
            StringBuilder sb = new StringBuilder("QTZS21_V1.0");
            //TODO �����ַ� is_cllx+is_syxz+is_clsbdh
            VehicleHelper.AppendString(sb, VehicleHelper.Encode(this.cbTecCllx.SelectedValue.ToString() + this.cbXuUseFor.SelectedValue.ToString() + this.txtTecClsbm.Text.Trim()));

            VehicleHelper.AppendString(sb, this.txtTecHgzbh.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecClxh.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecZwpp.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecYwpp.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbTecCllx.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtTecClsbm.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecFdjh.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecZzcm.Text.Trim());
            VehicleHelper.AppendString(sb, this.color);
            VehicleHelper.AppendString(sb, this.mtxtTecCcrq.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbTecGcjk.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.cbTecZzg.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtTecFdjxh.Text.Trim());

            VehicleHelper.AppendString(sb, this.txtTecPl.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecGl.Text.Trim());
            VehicleHelper.AppendString(sb, this.rlzl);
            VehicleHelper.AppendString(sb, this.txtTecWkc.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecWkk.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecWkg.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbTecZxfs.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtTecNkc.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecNkk.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecNkg.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecHbdb.Text.Trim());

            VehicleHelper.AppendString(sb, this.txtTecGbtfs.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecZs.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecZj.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecLts.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecLtgg.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecLjq.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecLjh.Text.Trim());

            VehicleHelper.AppendString(sb, this.txtTecZzl.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecZbzl.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecHdzk.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecZqyzl.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecHdzzl.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecZkrsq.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtTecZkrsh.Text.Trim());

            VehicleHelper.AppendString(sb, this.cbBaseSyrIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtBaseSyrIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseSyrName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseSyrPhone.Text.Trim());
            //VehicleHelper.AppendString(sb, this.cbLocalArea_syr);
            //VehicleHelper.AppendString(sb, this.txtConnAddress_syr);
            VehicleHelper.AppendString(sb, this.txtBaseSyrTempId.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseSyrPostCode.Text.Trim());

            VehicleHelper.AppendString(sb, this.cbXuUseFor.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.cbXuSyq.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.cbXuGetFrom.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.cbXuBelongArea.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.cbXuHmhp.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.cbXuLlpp1.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtXuLlppHm1.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbXuLlpp2.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtXuLlppHm2.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbXuGzzm.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtXuGzzmBh.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtXuBxBh.Text.Trim());
            VehicleHelper.AppendString(sb, this.mtxtXuBxBeginDate.Text.Trim());
            VehicleHelper.AppendString(sb, this.mtxtXuBxEndDate.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbXuBxCompany.Text);
            VehicleHelper.AppendString(sb, this.cbXuJkPzType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtXuPzHm.Text.Trim());
            VehicleHelper.AppendString(sb, this.mtxtXuJkDate.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtXuQzcpxh.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtXuVehicleColor.Text.Trim());

            VehicleHelper.AppendString(sb, this.txtDyHtzbh.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDyHtbh.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbDyDyqrIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtDyDyqrIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDyqrName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDyqrPhone.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDyqrConnAddress.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDyqrPostCode.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtXuDescription.Text.Trim());
            VehicleHelper.AppendString(sb, this.lbFirstRegDate.Text);
            VehicleHelper.AppendString(sb, this.txtXuSellPrice.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbXuSellDw.Text.Trim());

            VehicleHelper.AppendString(sb, this.cbBaseDlrIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtBaseDlrIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseDlrName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseDlrPhone.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseDlrConnAddress.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbBaseJbrIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtBaseJbrIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseJbrName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseJbrConnAddress.Text.Trim());

            VehicleHelper.AppendString(sb, this.cbDyDldwIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtDyDldwIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDldwName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDldwPhone.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDldwConnAddress.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbDyJbrIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtDyJbrIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyJbrName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyJbrConnAddress.Text.Trim());
            //TODO ����2���ַ�
            // VehicleHelper.AppendString(sb, zpxh);
            // VehicleHelper.AppendString(sb, CompanyInfoForm.Info.BusId);

            return sb.ToString();



        }
        #endregion

        protected override void BeforeSave(object entity)
        {
            string dimension = this.ComputeDimension();
            FT.Commons.Tools.FormHelper.SetDataToObject(entity, "OthDimension", dimension);
            base.BeforeSave(entity);
            //FT.Commons.Tools.FormHelper.SetDataToObject(entity, "CoachId", this.cbCoachName.SelectedValue.ToString());
        }

        #region ������ɫ��ȼ������
        /// <summary>
        /// �����ɫ��ȼ��
        /// </summary>
        private void ComputeColorAndOil()
        {
            this.ComputeColor();
            this.ComputeOil();
        }
        private void ComputeColor()
        {
            /*string sv_return
color1 = trim(color1)
color2 = trim(color2)
color3 = trim(color3)
setnull(sv_return)
if color1 = 'Y' then 
   return sv_return
end if
if color1 = color2 or color1 = color3 then 
   return sv_return
end if
if color2 = 'Y' and color3 <> 'Y'  then return sv_return
if color2 <> 'Y' and color2 = color3 then 
   return sv_return
end if
sv_return = color1
if color2 <> 'Y' then
   sv_return = sv_return + color2
  if color3 <> 'Y' then
       sv_return = sv_return + color3
   end if
end if
return sv_return*/
            string temp = string.Empty;
            string color1 = this.cbTecColor1.SelectedValue.ToString();
            string color2 = this.cbTecColor2.SelectedValue.ToString();
            string color3 = this.cbTecColor3.SelectedValue.ToString();
            if (color1 == "Y")
            {
                this.color = temp;
                return;
            }
            else if (color1 == color2 || color1 == color3)
            {
                this.color = temp;
                return;
            }
            else if (color2 == "Y" && color3 != "Y")
            {
                this.color = temp;
                return;
            }
            else if (color2 != "Y" && color2 == color3)
            {
                this.color = temp;
                return;
            }
            else
            {
                temp = color1;
            }
            if (color2 != "Y")
                temp += color2;
            if (color3 != "Y")
                temp += color3;
            this.color = temp;
        }



        private void ComputeOil()
        {
            /*
             string sv_return
rlzl1 = trim(rlzl1)
rlzl2 = trim(rlzl2)
setnull(sv_return)
if rlzl1 = rlzl2 then 
   if rlzl1 <> 'Y'	 then
	 return sv_return
   else	 
	return 'Y'
   end if	
else
	if rlzl1 <> 'Y' and rlzl2 <> 'Y' then
	  sv_return = rlzl1 + rlzl2
    elseif rlzl1 = 'Y' and rlzl2 <> 'Y' then
	  sv_return = rlzl2
    elseif rlzl1 <> 'Y' and rlzl2 = 'Y' then
	  sv_return = rlzl1
    end if	  
    return sv_return
end if	
             */
            string rlzl1 = this.cbTecRlzl1.SelectedValue.ToString();
            string rlzl2 = this.cbTecRlzl2.SelectedValue.ToString();
            if (rlzl1 == rlzl2)
            {
                if (rlzl1 != "Y")
                {
                    this.rlzl = string.Empty;
                    return;
                }
                else
                {
                    this.rlzl = "Y";
                    return;
                }
            }
            else
            {
                if (rlzl1 != "Y" && rlzl2 != "Y")
                {
                    this.rlzl = rlzl1 + rlzl2;
                }
                else if (rlzl1 == "Y" && rlzl2 != "Y")
                {
                    this.rlzl = rlzl2;
                }
                else if (rlzl1 != "Y" && rlzl2 == "Y")
                {
                    this.rlzl = rlzl1;
                }
            }
        }
        #endregion

        #region Others


        protected override bool CheckBeforeCreate()
        {
            bool result=this.ExistClsb(this.txtTecClsbm.Text.Trim());
            if (result)
            {
                MessageBoxHelper.Show("�Ѵ�����ͬ�ĳ���ʶ���룡");
            }
            return result;
        }

        private bool ExistClsb(string clsbh)
        {
            object obj=FT.DAL.DataAccessFactory.GetDataAccess().SelectScalar("select count(*) from table_vehicle_temp where tecclsbm='"+clsbh+"'");
            try
            {
                int i = Convert.ToInt32(obj);
                return i > 0;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region ��֤����
        private void txtBaseSyrIdCard_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbBaseSyrIdCardType.SelectedValue.ToString() == "A")
            {
                this.ValidateIdCard(sender, e, false);
            }
            else
            {
                this.ValidateNotNull(sender, e, "��������Ч�����֤�����룡");
            }
        }

        private void txtBaseSyrName_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "��������Ϊ�գ�");
        }

        private void txtBaseSyrPhone_Validating(object sender, CancelEventArgs e)
        {
            this.ValidatePhone(sender, e, false);
        }

        private void txtBaseSyrMobile_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateMobile(sender, e, true);
        }

        private void txtBaseSyrPostCode_Validating(object sender, CancelEventArgs e)
        {
            this.ValidatePostCode(sender, e, false);
        }

        private void txtBaseSyrRegAddress_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        

        private void txtBaseSyrConnAddress_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        private void txtBaseSyrEmail_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateEmail(sender, e,true);
        }

        private void txtBaseDlrIdCard_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbBaseDlrIdCardType.SelectedValue.ToString() == "A")
            {
                this.ValidateIdCard(sender, e, false);
            }
            else
            {
                this.ValidateNotNull(sender, e, "��������Ч�����֤�����룡");
            }
        }

        private void txtBaseDlrName_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        private void txtBaseDlrPhone_Validating(object sender, CancelEventArgs e)
        {
            this.ValidatePhone(sender, e, false);
        }

        private void txtBaseDlrConnAddress_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        private void txtBaseJbrIdCard_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbBaseJbrIdCardType.SelectedValue.ToString() == "A")
            {
                this.ValidateIdCard(sender, e, false);
            }
            else
            {
                this.ValidateNotNull(sender, e, "��������Ч�����֤�����룡");
            }
        }

        private void txtBaseJbrName_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        private void txtBaseJbrConnAddress_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        private void cbXuSyq_Validating(object sender, CancelEventArgs e)
        {
            string idcardtype = this.cbBaseSyrIdCardType.SelectedValue.ToString();
            if (idcardtype == "B" || idcardtype == "J" || idcardtype == "L")
            {
                if (this.cbXuSyq.SelectedValue.ToString() != "1")
                {
                    this.SetError(sender, "����Ȩ�����֤�����Ʋ���!");
                    e.Cancel = true;
                }
                else
                {
                    this.ClearError(sender);
                    e.Cancel = false;
                }
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }

        }

        private void txtXuLlppHm1_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        private void mtxtXuBxBeginDate_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateDateMasked(sender, e);
        }

        private void mtxtXuBxEndDate_Validating(object sender, CancelEventArgs e)
        {
            //"������ֹ����Ӧ�ڽ���֮��!""
            //������ֹ����Ӧ�ڱ�����Ч����֮��!")
            this.ValidateDateMasked(sender, e);
        }

        private void txtXuSellPrice_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, false);
        }

        private void txtTecHgzbh_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbTecZzg.Text == "�й�" && this.txtTecHgzbh.Text.Trim().Length == 0)
            {
                this.SetError(this.txtTecHgzbh, "������");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(this.txtTecHgzbh);
                e.Cancel = false;
            }
        }

        private void mtxtXuJkDate_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbTecGcjk.SelectedValue.ToString() != "A")
            {
                MaskedTextBox txt = sender as MaskedTextBox;
                if (txt != null)
                {

                    try
                    {
                        DateTime dt = Convert.ToDateTime(txt.Text);
                        DateTime dtcompare = new DateTime(1998, 1, 1);
                        if (dt > System.DateTime.Now || dt < dtcompare)
                        {
                            this.errorProvider1.SetError(txt, "�Ϸ��Ľ���ƾ֤ǩ�����ڱ����ڽ���֮ǰ1998-01-01��֮��!");
                            e.Cancel = true;
                        }
                        else
                        {
                            this.errorProvider1.SetError(txt, string.Empty);
                            e.Cancel = false;
                        }
                    }
                    catch
                    {
                        this.errorProvider1.SetError(txt, "�������ʽΪyyyy-MM-dd�����ڣ�");
                        e.Cancel = true;

                    }

                }
            }
        }

        private void txtXuVehicleColor_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbTecGcjk.SelectedValue.ToString() != "A" && this.txtXuVehicleColor.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtXuVehicleColor, "�����룡");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider1.SetError(txtXuVehicleColor, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtXuQzcpxh_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbTecGcjk.SelectedValue.ToString() != "A" && this.txtXuQzcpxh.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtXuQzcpxh, "�����룡");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider1.SetError(txtXuQzcpxh, string.Empty);
                e.Cancel = false;
            }
        }

        private void txtTecZwpp_Validating(object sender, CancelEventArgs e)
        {
                this.ValidateNotNull(sender, e);
        }

        private void txtTecClsbm_Validating(object sender, CancelEventArgs e)
        {
            string str = "ABCDEFGHJKLMNPRSTUVWXYZ0123456789";
            string tmp=this.txtTecClsbm.Text.Trim();
            if (tmp.Length == 0)
            {
                this.errorProvider1.SetError(txtTecClsbm, "�����룡");
                e.Cancel = true;
            }
            else
            {
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (str.IndexOf(tmp[i]) == -1)
                    {
                        if (MessageBoxHelper.Confirm("�Ƿ���ʶ���룬������ABCDEFGHJKLMNPRSTUVWXYZ0123456789��\r\n �Ƿ������"))
                        {
                            break;
                        }
                        else
                        {
                            this.errorProvider1.SetError(this.txtTecClsbm, "");
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                this.errorProvider1.SetError(txtTecClsbm, "");
                e.Cancel = false;
            }
        }

        private void txtTecWkc_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        private void txtTecWkk_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        private void txtTecWkg_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }
        private bool NeedValidateNk()
        {
            string tmp = this.cbTecCllx.SelectedValue.ToString();
            return tmp == "H11" || tmp == "H21" || tmp == "H31" || tmp == "H41"
            || tmp == "N21" || tmp == "G11" || tmp == "G21" || tmp == "G31"
            || tmp == "B11" || tmp == "B21" || tmp == "B31";
        }

        private void txtTecNkc_Validating(object sender, CancelEventArgs e)
        {
            
            TextBox txt=sender as TextBox;
            if(this.NeedValidateNk()||txt.Text.Trim().Length>0)
            {
                this.ValidateInteger(sender, e, true, 0);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel=false;
            }
        }

        private void txtTecNkk_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (this.NeedValidateNk() || txt.Text.Trim().Length > 0)
            {
                this.ValidateInteger(sender, e, true, 0);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtTecNkg_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (this.NeedValidateNk() || txt.Text.Trim().Length > 0)
            {
                this.ValidateInteger(sender, e, true, 0);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtTecZs_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateInteger(sender, e, false, 0);
        }

        private void txtTecZj_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateInteger(sender, e, false, 0);
        }

        private void txtTecLts_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateInteger(sender, e, false, 1);
        }

        private void txtTecLtgg_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e);
        }

        private void txtTecZbzl_Validating(object sender, CancelEventArgs e)
        {
            string tmp = this.cbTecCllx.SelectedValue.ToString();
            if (tmp.StartsWith("Q"))
            {
                this.ValidateInteger(sender, e, false, 0, "ǣ��������������������!");
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtTecZqyzl_Validating(object sender, CancelEventArgs e)
        {
            string tmp = this.cbTecCllx.SelectedValue.ToString();
            if (tmp.StartsWith("Q"))
            {
                this.ValidateInteger(sender, e, false, 0, "ǣ������������׼ǣ��������!");
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtTecZkrsq_Validating(object sender, CancelEventArgs e)
        {
            string tmp = this.cbTecCllx.SelectedValue.ToString();
            if (tmp.StartsWith("H"))
            {
                this.ValidateInteger(sender, e, false, 0, "������ǰ���ؿ�����1��!");
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtTecHdzzl_Validating(object sender, CancelEventArgs e)
        {
            //if left(is_cllx,1) ='H' or left(is_cllx,1) = 'G'
            //or left(is_cllx,1) = 'B' then
		//if isnull(idb_hdzzl) or idb_hdzzl = 0 then

            string tmp = this.cbTecCllx.SelectedValue.ToString();
            if (tmp.StartsWith("H") || tmp.StartsWith("G") || tmp.StartsWith("B"))
            {
                this.ValidateInteger(sender, e, false, 0, "���೵�ĺ˶���������������!");
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }

        }

        private void txtTecHdzk_Validating(object sender, CancelEventArgs e)
        {
            string tmp = this.cbTecCllx.SelectedValue.ToString();
            if (tmp!="M14"&&(tmp.StartsWith("K") || tmp.StartsWith("D") || tmp.StartsWith("M")))
            {
                this.ValidateInteger(sender, e, false, 0, "���೵�ĺ˶��ؿͱ�������!");
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private bool NeedCheckDyr()
        {
            return this.txtDyDyHtbh.Text.Length > 0;
        }

        private void txtDyDyHtbh_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidateNotNull(sender, e);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyDyqrIdCard_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr()&&this.cbDyDyqrIdCardType.SelectedValue.ToString()=="A")
            {
                this.ValidateIdCard(sender, e,false);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyDyqrName_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidateNotNull(sender, e);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyDyqrPhone_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidatePhoneOrMobile(sender, e,false);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyDyqrConnAddress_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidateNotNull(sender, e);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyDyqrPostCode_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidatePostCode(sender, e,false);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyDldwIdCard_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr() && this.cbDyDldwIdCardType.SelectedValue.ToString() == "A")
            {
                this.ValidateIdCard(sender, e, false);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyJbrIdCard_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr() && this.cbDyJbrIdCardType.SelectedValue.ToString() == "A")
            {
                this.ValidateIdCard(sender, e, false);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyDldwName_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidateNotNull(sender, e);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyDldwConnAddress_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidateNotNull(sender, e);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyJbrName_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidateNotNull(sender, e);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyJbrConnAddress_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidateNotNull(sender, e);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtDyDldwPhone_Validating(object sender, CancelEventArgs e)
        {
            if (this.NeedCheckDyr())
            {
                this.ValidatePhoneOrMobile(sender, e, false);
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void cbTecColor1_Validating(object sender, CancelEventArgs e)
        {
            this.ComputeColor();
            if (color.Length == 0)
            {
                this.SetError(sender, "��������Ч�ĳ�����ɫ��");
                e.Cancel = false;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void cbTecRlzl1_Validating(object sender, CancelEventArgs e)
        {
            this.ComputeOil();
            if (this.rlzl.Length == 0)
            {
                this.SetError(sender, "��ѡ����Ч��ȼ�����࣡");
                e.Cancel = false;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void txtTecPl_Validating(object sender, CancelEventArgs e)
        {
            string pl = this.txtTecPl.Text.Trim();
            string gl = this.txtTecGl.Text.Trim();
            if (pl == string.Empty && gl == string.Empty)
            {
                this.SetError(sender, "�����͹��ʱ�������һ����");
                e.Cancel = false;
            }
            else
            {
                if (gl != string.Empty)
                {
                    this.ValidateInteger(this.txtTecGl, e, false, 0);
                }
                else if (pl != string.Empty)
                {
                    this.ValidateInteger(this.txtTecPl, e, false, 0);
                }
                else
                {
                    this.ClearError(sender);
                    e.Cancel = false;
                }
            }
        }
        #endregion


    }
}

