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
        #region 子类必须实现的
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
                   // this.cbFatherCodeValue.DisplayMember = "省份名称";
                   // this.cbFatherCodeValue.ValueMember = "省份代码";
                   // this.cbFatherCodeValue.SelectedIndex = 0;
               // }
                //FT.Windows.CommonsPlugin.Entity.DictManager.BindToCombox(this.cbCarType, "准驾车型");
            }
            //this.cbSex.SelectedIndex = 0;
        }

        /// <summary>
        /// 关联实体的类别,该实体必须有一个Id的属性
        /// </summary>
        /// <returns>实体类别</returns>
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
            log.OpDetail = "初次登记车辆识别码为：" + log.Clsbm;
            log.Operator = UserManager.LoginUser.Name;
            FT.DAL.Orm.SimpleOrmOperator.Create(log);
            base.AfterSuccessCreate();
        }

        protected override void AfterSuccessUpdate()
        {
            OptLog log = new OptLog();
            log.Clsbm = this.txtTecClsbm.Text.Trim();
            log.OpDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.OpDetail = "修改ID为:"+this.lbId.Text+"车辆识别码为："+log.Clsbm;
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

        #region 生成二维条码的数据
        /*        
QTZS21_V1.0 +加密(车辆类型代码+使用性质代码+车辆识别代码)+合格证编号+车辆型号+中文品牌+英文品牌+车辆类型代码
+车辆识别代码+发动机号+制造厂名称+组合后的车身颜色（1-2-3）+出厂日期（格式yyyy-mm-dd）+国产进口代码+制造国代码
+发动机型号+排量+功率+燃料种类(代码？)+外廓长+外廓宽+外廓高+转向形式代码+货箱内部长+货箱内部宽+货箱内部高
+环保达标情况+钢板弹簧片数+轴数+轴距+轮胎数+轮胎规格+前轮距+后轮距+总质量+整备质量+核定载客+准牵引总质量
+核定总质量+前排载客+后排载客+所有人身份证明名称代码+所有人身份证名号码+所有人姓名或名称+联系电话+住所区号代码
+住所详细地址+暂住证号+邮政编码+使用性质代码+所有权代码+获得方式代码+行政区划代码+号牌种类代码+来历凭证代码1
+来历凭证1编号+来历凭证代码2+来历凭证2编号+购置税证明名称代码+纳税证明编号+保险凭证号+保险生效日期+保险终止日期
+保险公司名称+进口凭证类型代码+进口凭证编号+进口签发日期+进口签注厂牌型号+进口签注车身颜色+主合同编号+抵押合同编号
+抵押权人身份证明名称代码+抵押权人身份证明号码+抵押权人姓名或名称+联系电话+住所详细地址+邮政编码+备注+初次登记日期
+销售价格+销售单位名称+所有权人代理单位身份证明名称代码+所有权人代理单位身份证明号码+所有权人代理单位名称
+所有权人代理单位联系电话+所有权人代理单位详细地址+所有权人经办人身份证明名称代码+所有权人经办人身份证明名称号码
+所有权人经办人姓名+所有权人经办人详细地址+代理权人代理单位身份证明名称代码+代理权人代理单位身份证明号码
+代理权人代理单位名称+代理权人代理单位联系电话+代理权人代理单位详细地址+代理权人经办人身份证明名称代码
+代理权人经办人身份证明号码+代理权人经办人姓名+代理权人经办人详细地址+（照片型号+车辆型号？）+（公司单位代码？）
         */

        private string ComputeDimension()
        {
            this.ComputeColorAndOil();
            StringBuilder sb = new StringBuilder("QTZS21_V1.0");
            //TODO 加密字符 is_cllx+is_syxz+is_clsbdh
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
            //TODO 后面2个字符
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

        #region 计算颜色和燃料种类
        /// <summary>
        /// 组合颜色和燃料
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
                MessageBoxHelper.Show("已存在相同的车辆识别码！");
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

        #region 验证输入
        private void txtBaseSyrIdCard_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbBaseSyrIdCardType.SelectedValue.ToString() == "A")
            {
                this.ValidateIdCard(sender, e, false);
            }
            else
            {
                this.ValidateNotNull(sender, e, "请输入有效的身份证明号码！");
            }
        }

        private void txtBaseSyrName_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "姓名不得为空！");
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
                this.ValidateNotNull(sender, e, "请输入有效的身份证明号码！");
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
                this.ValidateNotNull(sender, e, "请输入有效的身份证明号码！");
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
                    this.SetError(sender, "所有权与身份证明名称不符!");
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
            //"保险终止日期应在今天之后!""
            //保险终止日期应在保险生效日期之后!")
            this.ValidateDateMasked(sender, e);
        }

        private void txtXuSellPrice_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNumber(sender, e, false);
        }

        private void txtTecHgzbh_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbTecZzg.Text == "中国" && this.txtTecHgzbh.Text.Trim().Length == 0)
            {
                this.SetError(this.txtTecHgzbh, "请输入");
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
                            this.errorProvider1.SetError(txt, "合法的进口凭证签发日期必须在今天之前1998-01-01年之后!");
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
                        this.errorProvider1.SetError(txt, "请输入格式为yyyy-MM-dd的日期！");
                        e.Cancel = true;

                    }

                }
            }
        }

        private void txtXuVehicleColor_Validating(object sender, CancelEventArgs e)
        {
            if (this.cbTecGcjk.SelectedValue.ToString() != "A" && this.txtXuVehicleColor.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(txtXuVehicleColor, "请输入！");
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
                this.errorProvider1.SetError(txtXuQzcpxh, "请输入！");
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
                this.errorProvider1.SetError(txtTecClsbm, "请输入！");
                e.Cancel = true;
            }
            else
            {
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (str.IndexOf(tmp[i]) == -1)
                    {
                        if (MessageBoxHelper.Confirm("非法的识别码，必须是ABCDEFGHJKLMNPRSTUVWXYZ0123456789！\r\n 是否继续？"))
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
                this.ValidateInteger(sender, e, false, 0, "牵引车必须输入整备质量!");
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
                this.ValidateInteger(sender, e, false, 0, "牵引车必须输入准牵引总质量!");
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
                this.ValidateInteger(sender, e, false, 0, "货车的前排载客至少1人!");
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
                this.ValidateInteger(sender, e, false, 0, "该类车的核定载质量必须输入!");
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
                this.ValidateInteger(sender, e, false, 0, "该类车的核定载客必须输入!");
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
                this.SetError(sender, "请输入有效的车身颜色！");
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
                this.SetError(sender, "请选择有效的燃料种类！");
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
                this.SetError(sender, "排量和功率必须输入一个！");
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

