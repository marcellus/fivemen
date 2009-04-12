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
using FT.Windows.Forms.Domain;
using FT.Commons.Cache;
using FT.Commons.Bar;
using FT.Device.IDCard;

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
                
                this.txtBaseJbrConnAddress.KeyDown += new KeyEventHandler(txtBaseJbrConnAddress_KeyDown);
                
                this.txtXuQzcpxh.KeyDown += new KeyEventHandler(txtXuQzcpxh_KeyDown);

                
                this.txtTecZkrsh.KeyDown += new KeyEventHandler(txtTecZkrsh_KeyDown);
                this.txtXuDescription.KeyDown += new KeyEventHandler(txtXuDescription_KeyDown);
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
                DictManager.BindBelongAreaDynamic(this.cbBaseSyrConnArea);
                DictManager.BindBelongAreaDynamic(this.cbBaseSyrRegArea);

                BindHelper.BindPzhm(this.cb_xu_jkpzhm);
                BindHelper.BindJkpz(this.cbXuJkPzType);

                BindHelper.BindSellDw(this.cbXuSellDw);

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

        void txtXuDescription_KeyDown(object sender, KeyEventArgs e)
        {
            this.cbXuJkPzType.Focus();
            //throw new Exception("The method or operation is not implemented.");
        }

        void txtTecZkrsh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tabControl1.SelectedIndex = 3;
                // e.
                this.txtDyHtzbh.Focus();
            }
        }

        void txtXuQzcpxh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tabControl1.SelectedIndex = 2;
                // e.
                this.txtTecHgzbh.Focus();
            }
        }

        void txtBaseJbrConnAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tabControl1.SelectedIndex = 1;
                // e.
                this.cbXuUseFor.Focus();
            }
            //throw new Exception("The method or operation is not implemented.");
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
            F2ExcelPrinter printer = new F2ExcelPrinter(this.entity as VehicleInfo);
            printer.PaintPrinter();
        }

        #region 生成二维条码的数据
        /*        
QTZS21_V1.0 +加密(车辆类型代码+使用性质代码+车辆识别代码)+合格证编号+车辆型号+中文品牌+英文品牌+车辆类型代码
+车辆识别代码+发动机号+制造厂名称+组合后的车身颜色（1-2-3）+出厂日期（格式yyyy-mm-dd）+国产进口代码+制造国代码
+发动机型号+排量+功率+燃料种类(代码？)+外廓长+外廓宽+外廓高+转向形式代码+货箱内部长+货箱内部宽+货箱内部高
+环保达标情况+钢板弹簧片数+轴数+轴距+轮胎数+轮胎规格+前轮距+后轮距+总质量+整备质量+核定载客+准牵引总质量
+核定总质量+前排载客+后排载客+所有人身份证明名称代码+所有人身份证名号码+所有人姓名或名称+联系电话+住所区号代码
+住所详细地址+暂住证号+邮政编码+使用性质代码+所有权代码+获得方式代码+行政区划代码+号牌种类代码+来历凭证代码1
+来历凭证1编号+来历凭证代码2+来历凭证2编号+购置税证明名称代码+纳税证明编号+保险凭证号+保险生效日期(非19000101)
+保险终止日期（非19000101）
+保险公司名称+进口凭证类型代码+进口凭证编号+进口签发日期（非19000101）+进口签注厂牌型号+进口签注车身颜色+主合同编号+抵押合同编号
+抵押权人身份证明名称代码+抵押权人身份证明号码+抵押权人姓名或名称+联系电话+住所详细地址+邮政编码+备注+初次登记日期（yyyy-MM-dd）
+销售价格+销售单位名称+所有权人代理单位身份证明名称代码+所有权人代理单位身份证明号码+所有权人代理单位名称
+所有权人代理单位联系电话+所有权人代理单位详细地址+所有权人经办人身份证明名称代码+所有权人经办人身份证明名称号码
+所有权人经办人姓名+所有权人经办人详细地址+代理权人代理单位身份证明名称代码+代理权人代理单位身份证明号码
+代理权人代理单位名称+代理权人代理单位联系电话+代理权人代理单位详细地址+代理权人经办人身份证明名称代码
+代理权人经办人身份证明号码+代理权人经办人姓名+代理权人经办人详细地址+
         +邮寄地址区号+邮寄详细地址+所有人联系手机+所有人联系的电子邮箱+（照片型号+车辆型号？）+（公司单位代码？）
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
            VehicleHelper.AppendString(sb, this.cbBaseSyrRegArea.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtBaseSyrRegAddress.Text.Trim());
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
            VehicleHelper.AppendString(sb, Convert.ToDateTime(this.lbFirstRegDate.Text).ToString("yyyy-MM-dd"));
            VehicleHelper.AppendString(sb, this.txtXuSellPrice.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbXuSellDw.Text.Trim());

            VehicleHelper.AppendString(sb, this.cbBaseDlrIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtBaseDlrIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseDlrName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseDlrPhone.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseDlrConnAddress.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbBaseJbrIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.cbBaseJbrIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseJbrName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseJbrConnAddress.Text.Trim());

            VehicleHelper.AppendString(sb, this.cbDyDldwIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.txtDyDldwIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDldwName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDldwPhone.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyDldwConnAddress.Text.Trim());
            VehicleHelper.AppendString(sb, this.cbDyJbrIdCardType.SelectedValue.ToString());
            VehicleHelper.AppendString(sb, this.cbDyJbrIdCard.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyJbrName.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtDyJbrConnAddress.Text.Trim());

            VehicleHelper.AppendString(sb, this.cbBaseSyrConnArea.SelectedValue.ToString().Trim());
            VehicleHelper.AppendString(sb, this.txtBaseSyrConnAddress.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseSyrMobile.Text.Trim());
            VehicleHelper.AppendString(sb, this.txtBaseSyrEmail.Text.Trim());
            //TODO 后面2个字符
            VehicleHelper.AppendString(sb, this.lbPhotoXh.Text.Trim());
            CompanyInfo comp = StaticCacheManager.GetConfig<CompanyInfo>();
            VehicleHelper.AppendString(sb,comp.No);

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
            return !result;
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
            try
            {
                DateTime begin = Convert.ToDateTime(this.mtxtXuBxBeginDate.Text);
                this.ValidateDateMaskedLarge(sender, e,begin);
            }
            catch
            {
                this.SetError(sender,"输入的日期必须大于保险开始日期");
                e.Cancel = true;
            }
            
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
            if (this.cbTecGcjk.SelectedValue.ToString() != "A" && this.cbTecGcjk.SelectedValue.ToString() != "H" && this.txtXuQzcpxh.Text.Trim().Length == 0)
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

        private void txtTecZzl_Validating(object sender, CancelEventArgs e)
        {
            string tmp = this.cbTecCllx.SelectedValue.ToString();
            if (!(tmp.StartsWith("N") || tmp.StartsWith("T") || tmp.StartsWith("M")))
            {
                this.ValidateInteger(sender, e, false, 399, "该类车的总质量不应小于400!");
            }
            else
            {
                this.ValidateNotNull(sender, e,"必须输入总质量！");
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

        private void VehicleBrowser_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.txtBaseJbrConnAddress.KeyDown -= new KeyEventHandler(FormHelper.EnterToTab);
                this.txtXuQzcpxh.KeyDown -= new KeyEventHandler(FormHelper.EnterToTab);
                this.txtTecZkrsh.KeyDown -= new KeyEventHandler(FormHelper.EnterToTab);
                this.txtXuDescription.KeyDown -= new KeyEventHandler(FormHelper.EnterToTab);
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                if (config.ReadHgz)
                {
                    if (!reader.StartWatching())
                    {
                        MessageBoxHelper.Show("启动条码监听失败！");
                    }
                    else
                    {
                        reader.RegisterProcesser(ProcessText);
                    }
                }
                if (config.UseCardReader)
                {
                    idReader = new IDCardReaderHelper(new De_ReadICCardComplete(ReadIdCardComplete), config.CardReaderInterval);
                }
                CompanyInfo comp = FT.Commons.Cache.StaticCacheManager.GetConfig<CompanyInfo>();
                this.txtBaseDlrConnAddress.Text = comp.Address;
                this.txtBaseDlrIdCard.Text = comp.BusId;
                this.txtBaseDlrName.Text = comp.Name;
                this.txtBaseDlrPhone.Text = comp.Phone;

                //this.cbXuSellDw.Text = comp.Name;

                this.txtDyDldwConnAddress.Text = comp.Address;
                this.txtDyDldwIdCard.Text = comp.BusId;
                this.txtDyDldwName.Text = comp.Name;
                this.txtDyDldwPhone.Text = comp.Phone;
                //this.xuhao = this.lbPhotoXh.Text.Trim();
            }
        }

        private void ReadIdCardComplete(IDCard card)
        {
            if (card != null)
            {
                this.cbBaseSyrIdCardType.SelectedIndex = 0;
                this.txtBaseSyrIdCard.Text = card.IDC;
                this.txtBaseSyrConnAddress.Text = card.ADDRESS;
                this.txtBaseSyrRegAddress.Text = card.ADDRESS;
                //card.REGORG
                this.txtBaseSyrName.Text = card.Name;
            }
        }

        private string GetGbtf(string key)
        {
            int pos = key.IndexOf("/");
            if (pos == -1)
            {
                return string.Empty;
            }
            else
            {
                string[] datatmp2 = key.Replace("/", "+").Replace("-", "").Split('+');
                int sum = 0;
                for (int i = datatmp2.Length; i > 0; i--)
                {

                    try
                    {
                        sum += Convert.ToInt32(datatmp2[i]);
                    }
                    catch
                    {
                    }
                }
                return sum.ToString();
            }
        }

        private IDCardReaderHelper idReader;

        private void ProcessText(string text)
        {
            if (text == null || text.Length == 0||text.IndexOf("|")==-1)
            {
                return;
            }
            if (text[0] == 13)
            {
                text = text.Substring(1);
            }
            string[] data = text.Split('|');
            if (text.StartsWith("HGFOZ"))
            {
                this.ProcessFmz(data);
            }
            else if (text.StartsWith("ZCCCH"))
            {
                this.ProcessWhole(data);
            }
            else if (text.StartsWith("QTZS21_V1.0"))
            {
                this.ProcessDimension(data);
            }
        }
        private void ProcessDimension(string[] data)
        {
            /*        
QTZS21_V1.0 +加密(车辆类型代码+使用性质代码+车辆识别代码)+合格证编号+车辆型号+中文品牌+英文品牌+车辆类型代码
+车辆识别代码+发动机号+制造厂名称+组合后的车身颜色（1-2-3）+出厂日期（格式yyyy-mm-dd）+国产进口代码+制造国代码
+发动机型号+排量+功率+燃料种类(代码？)+外廓长+外廓宽+外廓高+转向形式代码+货箱内部长+货箱内部宽+货箱内部高
+环保达标情况+钢板弹簧片数+轴数+轴距+轮胎数+轮胎规格+前轮距+后轮距+总质量+整备质量+核定载客+准牵引总质量
+核定总质量+前排载客+后排载客+所有人身份证明名称代码+所有人身份证名号码+所有人姓名或名称+联系电话+住所区号代码
+住所详细地址+暂住证号+邮政编码+使用性质代码+所有权代码+获得方式代码+行政区划代码+号牌种类代码+来历凭证代码1
+来历凭证1编号+来历凭证代码2+来历凭证2编号+购置税证明名称代码+纳税证明编号+保险凭证号+保险生效日期(非19000101)
+保险终止日期（非19000101）
+保险公司名称+进口凭证类型代码+进口凭证编号+进口签发日期（非19000101）+进口签注厂牌型号+进口签注车身颜色+主合同编号+抵押合同编号
+抵押权人身份证明名称代码+抵押权人身份证明号码+抵押权人姓名或名称+联系电话+住所详细地址+邮政编码+备注+初次登记日期（yyyy-MM-dd）
+销售价格+销售单位名称+所有权人代理单位身份证明名称代码+所有权人代理单位身份证明号码+所有权人代理单位名称
+所有权人代理单位联系电话+所有权人代理单位详细地址+所有权人经办人身份证明名称代码+所有权人经办人身份证明名称号码
+所有权人经办人姓名+所有权人经办人详细地址+代理权人代理单位身份证明名称代码+代理权人代理单位身份证明号码
+代理权人代理单位名称+代理权人代理单位联系电话+代理权人代理单位详细地址+代理权人经办人身份证明名称代码
+代理权人经办人身份证明号码+代理权人经办人姓名+代理权人经办人详细地址+
         +邮寄地址区号+邮寄详细地址+所有人联系手机+所有人联系的电子邮箱+（照片型号+车辆型号？）+（公司单位代码？）
         */
            this.txtTecHgzbh.Text = data[2];
            this.txtTecClxh.Text = data[3];
            this.txtTecZwpp.Text = data[4];
            this.txtTecYwpp.Text = data[5];
            this.cbTecCllx.SelectedValue = data[6];

            this.txtTecClsbm.Text = data[7];
            this.txtTecFdjh.Text = data[8];
            this.txtTecZzcm.Text = data[9];
            string tmp2 = data[10];
            if (tmp2.Length == 1)
            {
                this.cbTecColor1.SelectedValue = tmp2;
            }
            else if (tmp2.Length == 2)
            {
                this.cbTecColor1.SelectedValue = tmp2[0].ToString();
                this.cbTecColor2.SelectedValue = tmp2[1].ToString();
            }
            else if (tmp2.Length == 3)
            {
                this.cbTecColor1.SelectedValue = tmp2[0].ToString();
                this.cbTecColor2.SelectedValue = tmp2[1].ToString();
                this.cbTecColor3.SelectedValue = tmp2[2].ToString();
            }


            //VehicleHelper.AppendString(sb, this.color);
            this.mtxtTecCcrq.Text = data[11];
            this.cbTecGcjk.SelectedValue = data[12];
            this.cbTecZzg.SelectedValue = data[13];
            this.txtTecFdjxh.Text = data[14];

            this.txtTecPl.Text = data[15];
            this.txtTecGl.Text = data[16];
            string tmp = data[17];
            if (tmp.Length == 1)
            {
                this.cbTecRlzl1.SelectedValue = tmp;
            }
            else if (tmp.Length == 2)
            {
                this.cbTecRlzl1.SelectedValue = tmp[0].ToString();
                this.cbTecRlzl2.SelectedValue = tmp[1].ToString();
            }
            //VehicleHelper.AppendString(sb, this.rlzl);
            this.txtTecWkc.Text = data[18];
            this.txtTecWkk.Text = data[19];
            this.txtTecWkg.Text = data[20];

            this.cbTecZxfs.SelectedValue = data[21];
            this.txtTecNkc.Text = data[22];
            this.txtTecNkk.Text = data[23];
            this.txtTecNkg.Text = data[24];
            this.txtTecHbdb.Text = data[25];

            this.txtTecGbtfs.Text = data[26];
            this.txtTecZs.Text = data[27];
            this.txtTecZj.Text = data[28];
            this.txtTecLts.Text = data[29];
            this.txtTecLtgg.Text = data[30];
            this.txtTecLjq.Text = data[31];
            this.txtTecLjh.Text = data[32];

            this.txtTecZzl.Text = data[33];
            this.txtTecZbzl.Text = data[34];
            this.txtTecHdzk.Text = data[35];
            this.txtTecZqyzl.Text = data[36];
            this.txtTecHdzzl.Text = data[37];
            this.txtTecZkrsq.Text = data[38];
            this.txtTecZkrsh.Text = data[39];

            this.cbBaseSyrIdCardType.SelectedValue = data[40];
            this.txtBaseSyrIdCard.Text = data[41];
            this.txtBaseSyrName.Text = data[42];
            this.txtBaseSyrPhone.Text = data[43];
            this.cbBaseSyrRegArea.SelectedValue = data[44];
            this.txtBaseSyrRegAddress.Text = data[45];
            this.txtBaseSyrTempId.Text = data[46];
            this.txtBaseSyrPostCode.Text = data[47];

            this.cbXuUseFor.SelectedValue = data[48];
            this.cbXuSyq.SelectedValue = data[49];
            this.cbXuGetFrom.SelectedValue = data[50];
            this.cbXuBelongArea.SelectedValue = data[51];
            this.cbXuHmhp.SelectedValue = data[52];
            this.cbXuLlpp1.SelectedValue = data[53];
            this.txtXuLlppHm1.Text = data[54];
            this.cbXuLlpp2.SelectedValue = data[55];
            this.txtXuLlppHm2.Text = data[56];
            this.cbXuGzzm.SelectedValue = data[57];
            this.txtXuGzzmBh.Text = data[58];
            this.txtXuBxBh.Text = data[59];
            this.mtxtXuBxBeginDate.Text = data[60];

            this.mtxtXuBxEndDate.Text = data[61];
            this.cbXuBxCompany.Text = data[62];
            this.cbXuJkPzType.SelectedValue = data[63];
            this.txtXuPzHm.Text = data[64];
            this.mtxtXuJkDate.Text = data[65];
            this.txtXuQzcpxh.Text = data[66];
            this.txtXuVehicleColor.Text = data[67];

            this.txtDyHtzbh.Text = data[68];
            this.txtDyDyHtbh.Text = data[69];
            this.cbDyDyqrIdCardType.SelectedValue = data[70];
            this.txtDyDyqrIdCard.Text = data[71];
            this.txtDyDyqrName.Text = data[72];
            this.txtDyDyqrPhone.Text = data[73];
            this.txtDyDyqrConnAddress.Text = data[74];
            this.txtDyDyqrPostCode.Text = data[75];
            this.txtXuDescription.Text = data[76];
            this.lbFirstRegDate.Text = data[77];
            this.txtXuSellPrice.Text = data[78];
            this.cbXuSellDw.Text = data[79];

            this.cbBaseDlrIdCardType.SelectedValue = data[80];
            this.txtBaseDlrIdCard.Text = data[81];
            this.txtBaseDlrName.Text = data[82];
            this.txtBaseDlrPhone.Text = data[83];
            this.txtBaseDlrConnAddress.Text = data[84];
            this.cbBaseJbrIdCardType.SelectedValue = data[85];
            this.cbBaseJbrIdCard.Text = data[86];
            this.txtBaseJbrName.Text = data[87];
            this.txtBaseJbrConnAddress.Text = data[88];

            this.cbDyDldwIdCardType.SelectedValue = data[89];
            this.txtDyDldwIdCard.Text = data[90];
            this.txtDyDldwName.Text = data[91];
            this.txtDyDldwPhone.Text = data[92];
            this.txtDyDldwConnAddress.Text = data[93];
            this.cbDyJbrIdCardType.SelectedValue = data[94];
            this.cbDyJbrIdCard.Text = data[95];
            this.txtDyJbrName.Text = data[96];
            this.txtDyJbrConnAddress.Text = data[97];


            this.cbBaseSyrConnArea.SelectedValue = data[98];
            this.txtBaseSyrConnAddress.Text = data[99];
            this.txtBaseSyrMobile.Text = data[100];
            this.txtBaseSyrEmail.Text = data[101];
            this.lbPhotoXh.Text = data[102];
        }

        private void ProcessWhole(string[] data)
        {
            string tmp = data[1];
            string mtmp2 = string.Empty;
            int pos = 0;
            if (tmp == "QX")
            {
                this.txtTecHgzbh.Text = data[2];
                this.txtTecZzcm.Text = data[4];
                this.mtxtTecCcrq.Text = data[49];
                mtmp2 = data[7];
                pos = mtmp2.IndexOf("/");
                if (pos != -1)
                {
                    this.txtTecZwpp.Text = mtmp2.Substring(0, pos);
                    this.txtTecYwpp.Text = mtmp2.Substring(pos);
                }
                else
                {
                    this.txtTecZwpp.Text = mtmp2;
                }
                this.txtTecClxh.Text=data[8];
                this.txtTecClsbm.Text = data[13] + data[14];
                this.txtTecFdjh.Text = data[15].Substring(data[17].Length);
                this.txtTecFdjxh.Text=data[16];
                mtmp2 = data[17];
                pos = mtmp2.Length;
                if (pos >=2)
                {
                    this.cbTecColor1.SelectedValue = mtmp2.Substring(0, 1);
                    this.cbTecColor2.SelectedValue = mtmp2.Substring(1, 1);
                }
                else
                {
                    if (mtmp2 == string.Empty)
                    {
                        this.cbTecColor1.SelectedValue = "Y";
                        this.cbTecColor2.SelectedValue = "Y";
                    }
                    else
                    {
                        this.cbTecColor1.SelectedValue = mtmp2;
                    }
                }
                this.txtTecHbdb.Text = data[18];
                try
                {
                    if (Convert.ToInt32(data[19]) > 9999)
                    {

                    }
                    else
                    {
                        this.txtTecPl.Text = data[19];
                    }
                }
                catch
                {
                }
                mtmp2 = data[20];
                pos = mtmp2.IndexOf("/");
                if (pos != -1)
                {
                    this.txtTecGl.Text = mtmp2.Substring(0,pos);
                }
                else
                {
                    this.txtTecGl.Text=mtmp2;
                }
                this.cbTecZxfs.Text = data[21];
                mtmp2 = data[22];
                pos = mtmp2.IndexOf("/");
                if (pos != -1)
                {
                    this.txtTecLjq.Text = mtmp2.Substring(0, pos);
                }
                else
                {
                    this.txtTecLjq.Text = mtmp2;
                }
                this.txtTecZs.Text = data[29];

                mtmp2 = data[23];
                pos = mtmp2.IndexOf("/");
                if (pos != -1)
                {
                    string[] datatmp = mtmp2.Split('/');
                    if (data[29] == "3")
                    {
                        this.txtTecLjh.Text = datatmp[0];
                    }
                    else
                    {
                        this.txtTecLjh.Text = datatmp[datatmp.Length - 1];
                    }
                }
                else if(mtmp2.IndexOf("+")!=-1)
                {
                    string[] datatmp2 = mtmp2.Split('+');
                    int hlj = 0;
                    for (int i = datatmp2.Length; i > 0; i--)
                    {

                        try
                        {
                            hlj += Convert.ToInt32(datatmp2[i]);
                        }
                        catch
                        {
                        }
                    }
                    this.txtTecLjh.Text = hlj.ToString();
                }
                else if (mtmp2.IndexOf("+") != -1)
                {
                    this.txtTecLjh.Text = mtmp2;
                }
                this.txtTecLts.Text = data[24];
                this.txtTecLtgg.Text = data[25];
                this.txtTecGbtfs.Text = this.GetGbtf(data[26]);
                this.txtTecZj.Text = data[27];
                this.txtTecWkc.Text = data[30];
                this.txtTecWkk.Text = data[31];
                this.txtTecWkg.Text = data[32];
                this.txtTecNkc.Text = data[33];
                this.txtTecNkk.Text = data[34];
                this.txtTecNkg.Text = data[35];
                this.txtTecZzl.Text = data[36];
                this.txtTecHdzzl.Text = data[37];
                this.txtTecZbzl.Text = data[38];
                this.txtTecZqyzl.Text = data[40];
                this.txtTecHdzk.Text = data[41];

                mtmp2 = data[43];
                pos = mtmp2.IndexOf("/");
                if (pos != -1)
                {
                    this.txtTecZkrsq.Text = mtmp2.Substring(0, pos);
                    this.txtTecZkrsh.Text = mtmp2.Substring(pos);
                }
                else
                {
                    this.txtTecZkrsq.Text = mtmp2;
                }



            }
            /*if is_hgzlx = "ZCCCH" then 
	
	   ll_count = upperbound(gs_rlzl)	
        tab_1.tabpage_2.ddlb_rlzl1.setredraw(false)
        for li_i = 1 to ll_count
	     li_3 = pos(gs_rlzl[li_i],is_rlzl1,1)
	     if li_3 > 0 then
	        tab_1.tabpage_2.ddlb_rlzl1.text = gs_rlzl[li_i]
	     end if
        next	

        for li_i = 1 to ll_count
	     li_3 = pos(gs_rlzl[li_i],is_rlzl2,1)
	     if li_3 > 0 then
	        tab_1.tabpage_2.ddlb_rlzl2.text = gs_rlzl[li_i]
	     end if
        next	
	
	   ll_count = upperbound(gs_zxxs)	
        tab_1.tabpage_2.ddlb_zxxs.setredraw(false)
        for li_i = 1 to ll_count
	     li_3 = pos(gs_zxxs[li_i],is_zxxs,1)
	     if li_3 > 0 then
	        tab_1.tabpage_2.ddlb_zxxs.text = gs_zxxs[li_i]
	     end if
        next	
	
	   	
	end if
  //读取的是简化合格证
     if is_qx_jh_dp  = "JH" then
	   is_hgzbh = ls_xx[3]	
	   is_zzcmc = ls_xx[5]	
	   id_ccrq = date(ls_xx[50])	
	   ls_temp = ls_xx[8]
	   li_1 = pos(ls_temp,'/',1)
	   if li_1 > 0 then
	      is_clpp1 = left(ls_temp,li_1 - 1)	
	      is_clpp2 = mid(ls_temp,li_1+ 1)
	   else
		is_clpp1 = ls_temp
	   end if	
	   is_clxh = ls_xx[9]	
	   is_clsbdh = ls_xx[14]	+ ls_xx[15]
	   select count(*) into :li_ydj from vehicle_temp where clsbdh = :is_clsbdh;
		if sqlca.sqlcode < 0 then
			messagebox("提示","操作登记表失败!")
			return 1
		end if
		if li_ydj > 0 then
			messagebox("提示","该车辆识别代号的机动车已存在!")
			return 1
		end if			
        idb_cwkc = double(ls_xx[31])
	   idb_cwkk = double(ls_xx[32])
	   idb_cwkg = double(ls_xx[33])
	   idb_hxnbc = double(ls_xx[34])
	   idb_hxnbk = double(ls_xx[35])
	   idb_hxnbg = double(ls_xx[36])
	   idb_zzl = double(ls_xx[37])
	   idb_hdzzl = double(ls_xx[38])	
	   idb_zbzl = double(ls_xx[39])	
        idb_zqyzl = double(ls_xx[41])
	   idb_hdzk = double(ls_xx[42])  
        ls_temp = ls_xx[44]	
	   li_1 = pos(ls_temp,'+',1)
	   if li_1 > 0 then	
	      idb_qpzk = double(left(ls_temp,li_1 - 1))	
	      idb_hpzk = double(mid(ls_temp,li_1+ 1))	
	   else
		idb_qpzk = double(ls_temp)	
	   end if
	   tab_1.tabpage_2.sle_hgzbh.displayonly = true
	   tab_1.tabpage_2.sle_zzcmc.displayonly = true
        tab_1.tabpage_2.em_ccrq.displayonly = true
	   tab_1.tabpage_2.sle_clpp1.displayonly = true
	   tab_1.tabpage_2.sle_clpp2.displayonly = true
	   tab_1.tabpage_2.sle_clxh.displayonly = true
	   tab_1.tabpage_2.sle_clsbdh.displayonly = true
//	   tab_1.tabpage_2.sle_fdjh.displayonly = true
//	   tab_1.tabpage_2.sle_fdjxh.displayonly = true
//	   tab_1.tabpage_2.ddlb_rlzl1.enabled = false
//	   tab_1.tabpage_2.ddlb_rlzl2.enabled = false	
//	   tab_1.tabpage_2.sle_hbdbqk.displayonly = true
//	   tab_1.tabpage_2.em_pl.displayonly = true
//	   tab_1.tabpage_2.em_gl.displayonly = true
//	   tab_1.tabpage_2.ddlb_zxxs.enabled = false
//	   tab_1.tabpage_2.em_qlj.displayonly = true
//	   tab_1.tabpage_2.em_hlj.displayonly = true	
//	   tab_1.tabpage_2.em_lts.displayonly = true
//	   tab_1.tabpage_2.sle_ltgg.displayonly = true
//	   tab_1.tabpage_2.em_gbthps.displayonly = true	
//	   tab_1.tabpage_2.em_zj.displayonly = true	
//	   tab_1.tabpage_2.em_zs.displayonly = true	
	   tab_1.tabpage_2.em_cwkc.displayonly = true
	   tab_1.tabpage_2.em_cwkk.displayonly = true	
	   tab_1.tabpage_2.em_cwkg.displayonly = true	
	   tab_1.tabpage_2.em_hxnbc.displayonly = true	
	   tab_1.tabpage_2.em_hxnbk.displayonly = true
	   tab_1.tabpage_2.em_hxnbg.displayonly = true
	   tab_1.tabpage_2.em_zzl.displayonly = true	
	   tab_1.tabpage_2.em_hdzzl.displayonly = true
	   tab_1.tabpage_2.em_zbzl.displayonly = true
//	   tab_1.tabpage_2.em_zqyzl.displayonly = true	
	   tab_1.tabpage_2.em_hdzk.displayonly = true
	   tab_1.tabpage_2.em_qpzk.displayonly = true
	   tab_1.tabpage_2.em_hpzk.displayonly = true	
		
	   tab_1.tabpage_2.sle_hgzbh.text = is_hgzbh
	   tab_1.tabpage_2.sle_zzcmc.text = is_zzcmc
        tab_1.tabpage_2.em_ccrq.text =string(id_ccrq)
	   tab_1.tabpage_2.sle_clpp1.text = is_clpp1
	   tab_1.tabpage_2.sle_clpp2.text = is_clpp2
	   tab_1.tabpage_2.sle_clxh.text = is_clxh
	   tab_1.tabpage_2.sle_clsbdh.text = is_clsbdh
//	   tab_1.tabpage_2.sle_fdjh.text = is_fdjh
//	   tab_1.tabpage_2.sle_fdjxh.text = is_fdjxh
//	   ll_count = upperbound(gs_rlzl)	
//        tab_1.tabpage_2.ddlb_rlzl1.setredraw(false)
//        for li_i = 1 to ll_count
//	     li_3 = pos(gs_rlzl[li_i],is_rlzl1,1)
//	     if li_3 > 0 then
//	        tab_1.tabpage_2.ddlb_rlzl1.text = gs_rlzl[li_i]
//	     end if
//        next	
//	   tab_1.tabpage_2.ddlb_rlzl1.setredraw(true)	  
//	   tab_1.tabpage_2.ddlb_rlzl2.setredraw(false)
//        for li_i = 1 to ll_count
//	     li_3 = pos(gs_rlzl[li_i],is_rlzl2,1)
//	     if li_3 > 0 then
//	        tab_1.tabpage_2.ddlb_rlzl2.text = gs_rlzl[li_i]
//	     end if
//        next	
//	   tab_1.tabpage_2.ddlb_rlzl2.setredraw(true)	 
//	    tab_1.tabpage_2.sle_hbdbqk.text = is_hbdbqk
//	   tab_1.tabpage_2.em_pl.text = string(idb_pl)
//	   tab_1.tabpage_2.em_gl.text = string(idb_gl)
//	   ll_count = upperbound(gs_zxxs)	
//        tab_1.tabpage_2.ddlb_zxxs.setredraw(false)
//        for li_i = 1 to ll_count
//	     li_3 = pos(gs_zxxs[li_i],is_zxxs,1)
//	     if li_3 > 0 then
//	        tab_1.tabpage_2.ddlb_zxxs.text = gs_zxxs[li_i]
//	     end if
//        next	
//	   tab_1.tabpage_2.ddlb_zxxs.setredraw(true)	  	
//	   tab_1.tabpage_2.em_qlj.text =  string(idb_qlj)
//	   tab_1.tabpage_2.em_hlj.text =  string(idb_hlj)
//	   tab_1.tabpage_2.em_lts.text =  string(idb_lts)
//	   tab_1.tabpage_2.sle_ltgg.text = string(is_ltgg)
//	   tab_1.tabpage_2.em_gbthps.text =  string(idb_gbthps)
//	   tab_1.tabpage_2.em_zj.text =  string(idb_zj)
//	   tab_1.tabpage_2.em_zs.text =  string(idb_zs)
	   tab_1.tabpage_2.em_cwkc.text =  string(idb_cwkc)
	   tab_1.tabpage_2.em_cwkk.text =  string(idb_cwkk)
	   tab_1.tabpage_2.em_cwkg.text =  string(idb_cwkg)
	   tab_1.tabpage_2.em_hxnbc.text =  string(idb_hxnbc)
	   tab_1.tabpage_2.em_hxnbk.text =  string(idb_hxnbk)
	   tab_1.tabpage_2.em_hxnbg.text =  string(idb_hxnbg)
	   tab_1.tabpage_2.em_zzl.text =  string(idb_zzl)
	   tab_1.tabpage_2.em_hdzzl.text = string(idb_hdzzl)
	   tab_1.tabpage_2.em_zbzl.text = string(idb_zbzl)
//	   tab_1.tabpage_2.em_zqyzl.text = string(idb_zqyzl)
	   tab_1.tabpage_2.em_hdzk.text = string(idb_hdzk)
	   tab_1.tabpage_2.em_qpzk.text = string(idb_qpzk)
	   tab_1.tabpage_2.em_hpzk.text = string(idb_hpzk)	
        messagebox("提示","请继续读取底盘合格证信息！")
   end if
    //读取的是底盘合格证
    if is_qx_jh_dp = "DP" and is_clxh = "" then
	  messagebox("提示","请先读取整车合格证信息！")	
    elseif is_qx_jh_dp =  "DP" and is_clxh <> "" then
       is_fdjh = ls_xx[13]
       is_fdjxh = ls_xx[14]
	  ls_temp = ls_xx[15]
	  li_1 = len(ls_temp)
	   if li_1 >= 2 then	
	      is_rlzl = left(ls_temp,1)
	      is_rlzl = mid(ls_temp,2,1)
	   else
		is_rlzl = ls_temp
		if ls_temp = "" then
		    is_rlzl1 = "Y"
		    is_rlzl2 = "Y"
		else
			is_rlzl1 = ls_temp
			is_rlzl2 = "Y"	 
		end if
	   end if	
       is_hbdbqk = ls_xx[16]
	  idb_pl = double(ls_xx[17])
	  if idb_pl > 9999 then setnull(idb_pl)
	  ls_temp = ls_xx[18]
	  li_1 = pos(ls_temp,'/',1)
	  if li_1 > 0 then
		  idb_gl = double(left(ls_xx[18],li_1 -1))
	  else	
		  idb_gl = double(ls_xx[18])	
	  end if
	  is_zxxs = ls_xx[19]
	  ls_temp = ls_xx[20]
	   li_1 = pos(ls_temp,'/',1)
	   if li_1 > 0 then	
		  idb_qlj = double(left(ls_temp,li_1 - 1))	
	   else
	      idb_qlj = double(ls_temp)	
	   end if			
	  idb_zs = double(ls_xx[27])
       ls_temp = ls_xx[21]
	   if len(trim(ls_temp)) = 0 then idb_hlj = double(ls_temp)	
	   li_1 = pos(ls_temp,'/',1)
	   if li_1 > 0 then
		 i = 1
          li_2 = 0
          do until li_1 = 0
	          ls_hlj[i] = mid(ls_temp,li_2 + 1,li_1 - 1 - li_2)
	          li_2 = li_1
	          li_1 = pos(ls_temp,'/',li_2 + 1)
	          i ++
          loop
          ls_hlj[i] = mid(ls_temp,li_2 + 1) 	
	      if idb_zs = 3 then
			idb_hlj = double(ls_hlj[1])	
		  else
		     idb_hlj = double(ls_hlj[i -1])	
	       end if
		elseif pos(ls_temp,'+',1) > 0 then	
			 li_1 = pos(ls_temp,'+',1)
		      i = 1
               li_2 = 0
               do until li_1 = 0
				  ls_hlj[i] = mid(ls_temp,li_2 + 1,li_1  - 1 - li_2)
  			      li_2 = li_1
				  li_1 = pos(ls_temp,'+',li_2 + 1)
				 i ++
			 loop
		      ls_hlj[i] = mid(ls_temp,li_2 + 1)
			  for li_1 = 1 to i 
				if isnumber(ls_hlj[li_1])  then   idb_hlj = idb_hlj + double(ls_hlj[li_1])	
			 next	
		else
			idb_hlj = double(ls_temp)
		end if		
	  idb_lts=double(ls_xx[22])
       is_ltgg=ls_xx[23]
       idb_gbthps = gf_get_gbthps(ls_xx[24])
       idb_zj = gf_get_zj(ls_xx[25])
      // idb_zs = double(ls_xx[27])
       if ls_xx[7] = "二类底盘" then
	     ls_temp = ls_xx[35]	
	     li_1 = pos(ls_temp,'+',1)
		if li_1 > 0 then   
	        idb_qpzk = double(left(ls_temp,li_1))	
	        idb_hpzk = double(mid(ls_temp,li_1+ 1))
		else
		   idb_qpzk = double(ls_temp)
		end if
	   end if
//	   tab_1.tabpage_2.sle_hgzbh.displayonly = true
//	   tab_1.tabpage_2.sle_zzcmc.displayonly = true
//        tab_1.tabpage_2.em_ccrq.displayonly = true
//	   tab_1.tabpage_2.sle_clpp1.displayonly = true
//	   tab_1.tabpage_2.sle_clpp2.displayonly = true
//	   tab_1.tabpage_2.sle_clxh.displayonly = true
//	   tab_1.tabpage_2.sle_clsbdh.displayonly = true
	   tab_1.tabpage_2.sle_fdjh.displayonly = true
	   tab_1.tabpage_2.sle_fdjxh.displayonly = true
	   tab_1.tabpage_2.ddlb_rlzl1.enabled = false
	   tab_1.tabpage_2.ddlb_rlzl2.enabled = false	
	   tab_1.tabpage_2.sle_hbdbqk.displayonly = true
	   tab_1.tabpage_2.em_pl.displayonly = true
	   tab_1.tabpage_2.em_gl.displayonly = true
//	   tab_1.tabpage_2.ddlb_zxxs.enabled = false
	   tab_1.tabpage_2.em_qlj.displayonly = true
	   tab_1.tabpage_2.em_hlj.displayonly = true	
	   tab_1.tabpage_2.em_lts.displayonly = true
	   tab_1.tabpage_2.sle_ltgg.displayonly = true
	   tab_1.tabpage_2.em_gbthps.displayonly = true	
	   tab_1.tabpage_2.em_zj.displayonly = true	
	   tab_1.tabpage_2.em_zs.displayonly = true	
//	   tab_1.tabpage_2.em_cwkc.displayonly = true
//	   tab_1.tabpage_2.em_cwkk.displayonly = true	
//	   tab_1.tabpage_2.em_cwkg.displayonly = true	
//	   tab_1.tabpage_2.em_hxnbc.displayonly = true	
//	   tab_1.tabpage_2.em_hxnbk.displayonly = true
//	   tab_1.tabpage_2.em_hxnbg.displayonly = true
//	   tab_1.tabpage_2.em_zzl.displayonly = true	
//	   tab_1.tabpage_2.em_hdzzl.displayonly = true
//	   tab_1.tabpage_2.em_zbzl.displayonly = true
//	   tab_1.tabpage_2.em_zqyzl.displayonly = true	
//	   tab_1.tabpage_2.em_hdzk.displayonly = true
	   tab_1.tabpage_2.em_qpzk.displayonly = true
	   tab_1.tabpage_2.em_hpzk.displayonly = true
	   
//	   tab_1.tabpage_2.sle_hgzbh.text = is_hgzbh
//	   tab_1.tabpage_2.sle_zzcmc.text = is_zzcmc
//        tab_1.tabpage_2.em_ccrq.text =string(id_ccrq)
//	   tab_1.tabpage_2.sle_clpp1.text = is_clpp1
//	   tab_1.tabpage_2.sle_clpp2.text = is_clpp2
//	   tab_1.tabpage_2.sle_clxh.text = is_clxh
//	   tab_1.tabpage_2.sle_clsbdh.text = is_clsbdh
	   tab_1.tabpage_2.sle_fdjh.text = is_fdjh
	   tab_1.tabpage_2.sle_fdjxh.text = is_fdjxh
	   ll_count = upperbound(gs_rlzl)	
        tab_1.tabpage_2.ddlb_rlzl1.setredraw(false)
        for li_i = 1 to ll_count
	     li_3 = pos(gs_rlzl[li_i],is_rlzl1,1)
	     if li_3 > 0 then
	        tab_1.tabpage_2.ddlb_rlzl1.text = gs_rlzl[li_i]
	     end if
        next	
	   tab_1.tabpage_2.ddlb_rlzl1.setredraw(true)	  
	   tab_1.tabpage_2.ddlb_rlzl2.setredraw(false)
        for li_i = 1 to ll_count
	     li_3 = pos(gs_rlzl[li_i],is_rlzl2,1)
	     if li_3 > 0 then
	        tab_1.tabpage_2.ddlb_rlzl2.text = gs_rlzl[li_i]
	     end if
        next	
	   tab_1.tabpage_2.ddlb_rlzl2.setredraw(true)	 
	    tab_1.tabpage_2.sle_hbdbqk.text = is_hbdbqk
	   tab_1.tabpage_2.em_pl.text = string(idb_pl)
	   tab_1.tabpage_2.em_gl.text = string(idb_gl)
//	   ll_count = upperbound(gs_zxxs)	
//        tab_1.tabpage_2.ddlb_zxxs.setredraw(false)
//        for li_i = 1 to ll_count
//	     li_3 = pos(gs_zxxs[li_i],is_zxxs,1)
//	     if li_3 > 0 then
//	        tab_1.tabpage_2.ddlb_zxxs.text = gs_zxxs[li_i]
//	     end if
//        next	
//	   tab_1.tabpage_2.ddlb_zxxs.setredraw(true)	  	
	   tab_1.tabpage_2.em_qlj.text =  string(idb_qlj)
	   tab_1.tabpage_2.em_hlj.text =  string(idb_hlj)
	   tab_1.tabpage_2.em_lts.text =  string(idb_lts)
	   tab_1.tabpage_2.sle_ltgg.text = string(is_ltgg)
	   tab_1.tabpage_2.em_gbthps.text =  string(idb_gbthps)
	   tab_1.tabpage_2.em_zj.text =  string(idb_zj)
	   tab_1.tabpage_2.em_zs.text =  string(idb_zs)
//	   tab_1.tabpage_2.em_cwkc.text =  string(idb_cwkc)
//	   tab_1.tabpage_2.em_cwkk.text =  string(idb_cwkk)
//	   tab_1.tabpage_2.em_cwkg.text =  string(idb_cwkg)
//	   tab_1.tabpage_2.em_hxnbc.text =  string(idb_hxnbc)
//	   tab_1.tabpage_2.em_hxnbk.text =  string(idb_hxnbk)
//	   tab_1.tabpage_2.em_hxnbg.text =  string(idb_hxnbg)
//	   tab_1.tabpage_2.em_zzl.text =  string(idb_zzl)
//	   tab_1.tabpage_2.em_hdzzl.text = string(idb_hdzzl)
//	   tab_1.tabpage_2.em_zbzl.text = string(idb_zbzl)
//	   tab_1.tabpage_2.em_zqyzl.text = string(idb_zqyzl)
//	   tab_1.tabpage_2.em_hdzk.text = string(idb_hdzk)
	   tab_1.tabpage_2.em_qpzk.text = string(idb_qpzk)
	   tab_1.tabpage_2.em_hpzk.text = string(idb_hpzk)	
	end if		  
end if
//发动机型号不能为多值的判断
if pos(is_fdjxh,',') > 0  or pos(is_fdjxh,'，') > 0  then
   messagebox("提示","发动机型号不能为多值!")
   return -1
end if	

if ( is_hgzlx <> "ZCCCH"  and is_qx_jh_dp  <> "JH" and is_qx_jh_dp <> "DP") or isnull(is_hgzlx) then  
	is_checkread =  '0'
else
    is_checkread =  '1'
end if	
return 1
end event*/
        }

        private void ProcessFmz(string[] data)
        {
            this.cbXuJkPzType.Text = "罚没证明书";
            this.txtXuPzHm.Text = data[2];
            this.txtXuQzcpxh.Text = data[3];
            this.txtXuVehicleColor.Text = data[4];
            this.txtTecFdjh.Text = data[5];
            this.txtTecClsbm.Text = data[6];
            this.mtxtTecCcrq.Text = data[7];
            this.mtxtXuJkDate.Text = data[11];
        }

        private void cbRegArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dict dict=this.cbBaseSyrRegArea.SelectedItem as Dict;
            if (dict != null)
            {
                this.txtBaseSyrRegAddress.Text = dict.Description;
            }
        }

        private void cbConnArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dict dict = this.cbBaseSyrConnArea.SelectedItem as Dict;
            if (dict != null)
            {
                this.txtBaseSyrConnAddress.Text = dict.Description;
            }
        }

        public string GetXuhao()
        {
            return this.lbPhotoXh.Text.Trim();
        }
        public void SetXuhao(string xuhao)
        {
            this.lbPhotoXh.Text = xuhao;
        }

        private void btnPhotoInfo_Click(object sender, EventArgs e)
        {
            PhotoSelector form = new PhotoSelector(this,this.lbPhotoXh.Text.Trim(),this.txtTecZwpp.Text,this.txtTecClxh.Text);
            form.ShowDialog();
            
        }

        private SimpleBarReader reader = new SimpleBarReader();

        private void VehicleBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reader.IsOpen)
            {
                reader.StopWatching();
            }
        }

        private void cbBaseJbrIdCard_TextChanged(object sender, EventArgs e)
        {
            string tmp = this.cbBaseJbrIdCard.Text;
            if (tmp.Length == 6)
            {
                this.cbBaseJbrIdCard.DataSource = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Jbr>("where c_idcard like '" + tmp + "%'");
                this.cbBaseJbrIdCard.DisplayMember = "身份证明号码";
            }
        }

        private void cbBaseJbrIdCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Jbr jbr = this.cbBaseJbrIdCard.SelectedValue as Jbr;
            if (jbr != null)
            {
                this.txtBaseJbrConnAddress.Text = jbr.Address;
                this.txtBaseJbrName.Text = jbr.Name;
               
            }
        }

        private void cbDyJbrIdCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            Jbr jbr = this.cbDyJbrIdCard.SelectedValue as Jbr;
            if (jbr != null)
            {
                this.txtDyJbrConnAddress.Text = jbr.Address;
                this.txtDyJbrName.Text = jbr.Name;

            }
        }

        private void cbDyJbrIdCard_TextChanged(object sender, EventArgs e)
        {
            string tmp = this.cbDyJbrIdCard.Text;
            if (tmp.Length == 6)
            {
                this.cbDyJbrIdCard.DataSource = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Jbr>("where c_idcard like '" + tmp + "%'");
                this.cbDyJbrIdCard.DisplayMember = "身份证明号码";
            }
        }

        private void txtTecZzcm_Validating(object sender, CancelEventArgs e)
        {
                this.ValidateNotNull(sender, e, "请输入制造厂名称！");
        }

        private void txtTecClxh_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateNotNull(sender, e, "请输入车辆型号！");
        }

        private void txtTecFdjh_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtTecFdjxh_Validating(object sender, CancelEventArgs e)
        {
            string tmp = this.txtTecFdjxh.Text.Trim();
            if (tmp.Length == 0 && tmp != "无")
            {
                this.SetError(sender, "请输入有效的发动机型号，没有的输入“无”!");
                e.Cancel = true;
            }
            else
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
        }

        private void mtxtTecCcrq_Validating(object sender, CancelEventArgs e)
        {
            this.ValidateDateMaskedBetween(sender, e,new DateTime(1980,1,1),System.DateTime.Now);
        }

        private void cbTecGcjk_Validating(object sender, CancelEventArgs e)
        {
            object zzg = this.cbTecZzg.SelectedValue;
            object gcjk=this.cbTecGcjk.SelectedValue;
            if (zzg != null && gcjk != null)
            {
                string zzgs = zzg.ToString();
                string gcjks = gcjk.ToString();
                if (zzgs == "156" && (gcjks != "A" && gcjks != "H"))
                {
                    this.SetError(sender, "国产进口与制造国矛盾!");
                    e.Cancel = true;

                }
                else if (zzgs != "156" && (gcjks == "A" || gcjks == "H"))
                {
                    this.SetError(sender, "国产进口与制造国矛盾!");
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

        private void cbTecCllx_Validating(object sender, CancelEventArgs e)
        {
            string cllx = this.cbTecCllx.SelectedValue.ToString();
            string hpzl = this.cbXuHmhp.SelectedValue.ToString();
            if (VehicleHelper.ValidateHpzl(hpzl, cllx))
            {
                this.ClearError(sender);
                e.Cancel = false;
            }
            else
            {
                this.SetError(sender, "号牌种类与车辆类型不符!");
                e.Cancel = true;
            }
        }

        

        


    }
}

