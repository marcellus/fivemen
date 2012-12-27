using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HiPiaoTerminal.UserControlEx;
using HiPiaoTerminal.ConfigModel;
using HiPiaoInterface;

namespace HiPiaoTerminal.Maintain
{
    public partial class ManagerMoreSettingPanel : MaintainParentPanel
    {
        public ManagerMoreSettingPanel()
        {
            InitializeComponent();
        }

        private void btnCancelSave_Click(object sender, EventArgs e)
        {
            GlobalTools.ReturnMaintain();
        }

        private void btnKeepSave_Click(object sender, EventArgs e)
        {
            try
            {
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                config.UseHardwareKeyboard = this.checkUseHardKeyboard.Checked;
                config.UseMaskPanel = this.checkUseMask.Checked;
                config.UseRfid = this.checkAllowRfid.Checked;
                config.UseVirtualKeyboard = this.checkVitualKeyboard.Checked;
                config.UnOperationTime = Convert.ToInt32(this.txtUnOperationTime.Text);
                config.Province = this.cbProvince.Text;
                config.City = this.cbCity.Text;
                config.CityId = this.cbCity.SelectedValue.ToString();
                config.CinemaId = this.cbCinema.SelectedValue.ToString();
                config.Cinema = this.cbCinema.Text;

                config.UpdateMovieTime = Convert.ToInt32( this.txtRefreshCacheTime.Text) ;
                config.PrinterType = this.cbPrinterType.Text;

                config.FullScreenSecond = Convert.ToInt32(this.txtFullScreenSecond.Text);

                config.AllowNumberKeyboard = this.checkAllowNumberKeyboard.Checked;
                config.IsDingXin = this.checkIsDingXin.Checked;
                config.AdSeconds = Convert.ToInt32(this.txtAdSeconds.Text);

                config.FullScreenAddWidth = Convert.ToInt32(this.txtFullScreenAddWidth.Text);
                config.AllowFullScreen = this.checkAllowFullScreen.Checked;

                FT.Commons.Cache.StaticCacheManager.SaveConfig<SystemConfig>(config);



                this.lbReturnMsg.Text = "修改成功！";
            }
            catch
            {
                GlobalTools.Pop("设置时间不是数字！");
            }
        }

        private void ManagerMoreSettingPanel_Load(object sender, EventArgs e)
        {
            try
            {
                SystemConfig config = FT.Commons.Cache.StaticCacheManager.GetConfig<SystemConfig>();
                this.checkUseHardKeyboard.Checked = config.UseHardwareKeyboard;
                this.checkUseMask.Checked = config.UseMaskPanel;
                this.checkAllowRfid.Checked = config.UseRfid;
                this.checkVitualKeyboard.Checked = config.UseVirtualKeyboard;
                this.txtUnOperationTime.Text = config.UnOperationTime.ToString();
                this.cbProvince.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbProvince.DataSource = HiPiaoCache.GetProvince();
                this.cbProvince.DisplayMember = "Name";
                this.cbProvince.Text = config.Province;
                this.cbCity.Text = config.City;
                this.cbCinema.Text = config.Cinema;
                this.txtRefreshCacheTime.Text = config.UpdateMovieTime.ToString();
                this.cbPrinterType.Text = config.PrinterType;
                this.txtFullScreenSecond.Text = config.FullScreenSecond.ToString();

                this.checkAllowNumberKeyboard.Checked=config.AllowNumberKeyboard;
                this.checkIsDingXin.Checked = config.IsDingXin;
                this.txtAdSeconds.Text = config.AdSeconds.ToString();
                this.txtFullScreenAddWidth.Text = config.FullScreenAddWidth.ToString();

                this.checkAllowFullScreen.Checked = config.AllowFullScreen;

            }
            catch
            {

            }
        }

        private void cbProvince_TextChanged(object sender, EventArgs e)
        {
            string province = this.cbProvince.Text;
            if (province.Length > 0)
            {
                this.cbCity.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbCity.DataSource = HiPiaoCache.GetCitys(province);
                this.cbCity.DisplayMember = "Name";
                this.cbCity.ValueMember = "McityId";
            }
        }

        private void cbCity_TextChanged(object sender, EventArgs e)
        {
            string city = this.cbCity.Text;
            if (city.Length > 0)
            {
                string province = this.cbProvince.Text;
                this.cbCinema.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbCinema.DataSource = HiPiaoCache.GetCinemas(province, city);
                this.cbCinema.DisplayMember = "Name";
                this.cbCinema.ValueMember = "Cinemanumber";
            }
        }

        private void cbCinema_TextChanged(object sender, EventArgs e)
        {
            string cinema = this.cbCinema.Text;
            if (cinema.Length > 0)
            {
                CinemaObject cinemaObject = this.cbCinema.SelectedItem as CinemaObject;
                if (cinemaObject != null)
                {
                    this.lbAddress.Text = "地址：" + cinemaObject.Address + " 电话： " + cinemaObject.Tel;
                }
               
            }
        }
    }
}
