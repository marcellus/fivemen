using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Collections;
using FT.Windows.CommonsPlugin;

namespace Vehicle.Plugins
{
    public partial class PhotoSelector : Form
    {
        public PhotoSelector()
        {
            InitializeComponent();
        }
        private VehicleBrowser parentForm;

        private string xuhao;
        private string oldpinp;
        private string oldxh;

        public PhotoSelector(VehicleBrowser parent,string oldxuhao,string oldpinp,string oldxh)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.xuhao = oldxuhao;
            this.oldpinp = oldpinp;
            this.oldxh = oldxh;
            if (!this.DesignMode)
            {
                Vehicle.Plugins.BindHelper.BindZwpp(this.cbClassical);
                this.cbClassical.Text = oldpinp;
                this.cbType.Text = oldxh;
                this.Search();
                VehiclePhoto temp=null;
                for (int i = 0; i < this.photos.Count; i++)
                {
                    temp = this.photos[i] as VehiclePhoto;
                    if (temp.XuHao == this.xuhao)
                    {
                        this.listView1.Items[i].Selected = true;
                        break;
                    }
                }
                //this.cbClassical.DropDownStyle = ComboBoxStyle.DropDown;

            }
        }

        private void PhotoSelector_Load(object sender, EventArgs e)
        {
            
        }

        private void cbClassical_SelectedValueChanged(object sender, EventArgs e)
        {
            cbType.DataSource = null;
            ArrayList list = FT.DAL.Orm.SimpleOrmOperator.QueryConditionList<Dict>("where c_valid='有效' and  c_grouptype='车辆型号' and c_description='" + this.cbClassical.Text.Trim() + "'");
            //Vehicle.Plugins.BindHelper.BindClxh(this.cbType);

            cbType.DisplayMember = "数据文本";
            cbType.ValueMember = "数据代码";
            this.cbType.DataSource = list;
            this.cbType.DropDownStyle = ComboBoxStyle.DropDown;
            this.cbType.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }

        private void Search()
        {
            string classical = this.cbClassical.Text.Trim();
            string type = this.cbType.Text.Trim();
            if (classical == string.Empty && type == string.Empty)
            {
               // MessageBoxHelper.Show("请至少选择一个条件再查询！");
                return;

            }
            string condition = "where 1=1 ";
            if (classical != string.Empty)
            {
                condition += " and cn_classical like '%" + classical + "%'";
            }
            if (type != string.Empty && type != "请选择")
            {
                condition += " and cn_type like '%" + type + "%'";
            }
            VehiclePhotoAccess access = new VehiclePhotoAccess();
            this.photos = access.SearchList(condition);
            this.ReloadCollection();
        }
        private ArrayList photos = new ArrayList();

        /// <summary>
        /// 重新获取查询结果集合数据到ListView上
        /// </summary>
        private void ReloadCollection()
        {
            this.listView1.Items.Clear();
            VehiclePhoto temp = null;
            for (int i = 0; i < this.photos.Count; i++)
            {
                temp = this.photos[i] as VehiclePhoto;
                this.listView1.Items.Add(new ListViewItem(new string[] { temp.Cn_Classical, temp.Cn_Type }));

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices != null && this.listView1.SelectedIndices.Count == 1)
            {
                VehiclePhoto temp = this.photos[this.listView1.SelectedIndices[0]] as VehiclePhoto;
                this.picPhoto.Image = temp.Picture;
                this.cbClassical.Text = temp.Cn_Classical;
                //this.cbType.Text = temp.Cn_Type;
                // this.suffix = temp.Suffix;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                string tmpxuhao = ((VehiclePhoto)this.photos[this.listView1.SelectedIndices[0]]).XuHao;
                if (tmpxuhao != this.parentForm.GetXuhao() && MessageBoxHelper.Confirm("照片发生改变，确定吗？"))
                {
                    this.parentForm.SetXuhao(tmpxuhao);
                    this.Close();
                }

            }
            else
            {
                MessageBoxHelper.Show("请先选择一张车辆照片！");
            }
        }
    }
}