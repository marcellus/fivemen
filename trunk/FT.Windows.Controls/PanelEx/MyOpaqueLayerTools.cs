using System;
using System.Collections.Generic;
using System.Text;
using FT.Windows.Controls.PanelEx;
using System.Windows.Forms;
using System.Drawing;

namespace FT.Windows.Controls.PanelEx
{
    public class MyOpaqueLayerTools
    {
        private static MyOpaqueLayer m_OpaqueLayer = null;//半透明蒙板层

        /// <summary>
        /// 显示遮罩层
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="alpha">透明度</param>
        /// <param name="isShowLoadingImage">是否显示图标</param>
        public static void ShowOpaqueLayer(Control control, int alpha, bool isShowLoadingImage)
        {
            try
            {
                if (m_OpaqueLayer == null)
                {
                    m_OpaqueLayer = new MyOpaqueLayer(alpha, isShowLoadingImage);
                    m_OpaqueLayer.BackColor = Color.FromArgb(117, 117, 117);
                   
                }
                control.Controls.Add(m_OpaqueLayer);
                m_OpaqueLayer.Dock = DockStyle.Fill;
                m_OpaqueLayer.BringToFront();
                m_OpaqueLayer.Enabled = true;
                m_OpaqueLayer.Visible = true;
            }
            catch { }
        }

        /// <summary>
        /// 隐藏遮罩层
        /// </summary>
        public static void HideOpaqueLayer()
        {
            try
            {
                if (m_OpaqueLayer != null)
                {
                    m_OpaqueLayer.Visible = false;
                    m_OpaqueLayer.Enabled = false;
                    if (m_OpaqueLayer.Parent != null)
                    {
                        Control ctr = m_OpaqueLayer.Parent;
                        ctr.Controls.Remove(m_OpaqueLayer);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

    }
}
