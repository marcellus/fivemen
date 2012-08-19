using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace FT.Windows.ExternalTool.DevTools
{
    public partial class ShowColorForm : Form
    {
        public ShowColorForm()
        {
            InitializeComponent();
            this.Text = "ShowColor程序";
            this.ClientSize = new Size(800, 600);
            this.Paint += new PaintEventHandler(this.PaintForm);
            this.SizeChanged += new EventHandler(this.RefreshForm);

        }

        private void RefreshForm(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void PaintForm(object sender, PaintEventArgs e)
        {
            PropertyInfo[] props;
            props = typeof(Brushes).GetProperties();
            const int numGroup = 4;
            BrushWithName[][] brushGroups = new BrushWithName[numGroup][];
            int brushCount = 0;
            int brushEachGroup = props.Length / numGroup;
            for (int i = 0; i < numGroup; ++i)
            {
                BrushWithName[] brushSubGroup;
                brushSubGroup = new BrushWithName[brushEachGroup];
                brushEachGroup = brushSubGroup.Length;
                for (int j = 0; j < brushSubGroup.Length && brushCount < props.Length; ++j, ++brushCount)
                {
                    brushSubGroup[j].Value = (Brush)props[brushCount].GetValue(null, null);
                    brushSubGroup[j].Name = props[brushCount].Name;
                }
                brushGroups[i] = brushSubGroup;
            }
            Size clientSize = this.Size;
            Size blockSize = new Size(clientSize.Width / numGroup, clientSize.Height / brushEachGroup);
            Point location = new Point();
            for (int i = 0; i < brushGroups.Length; ++i)
            {
                for (int j = 0; j < brushGroups[i].Length; ++j)
                {
                    Graphics g = e.Graphics;
                    if (brushGroups[i][j].Value == null) continue;
                    g.FillRectangle(brushGroups[i][j].Value, new Rectangle(location, blockSize));
                    if (blockSize.Height > 10)
                    {
                        Font font = new Font("宋体", 10);
                        string output = brushGroups[i][j].Name;
                        g.DrawString(output, font, Brushes.Black, location);
                    }
                    location.Offset(0, blockSize.Height);
                }
                location = new Point(location.X + blockSize.Width, 0);
            }
        }


    }

    public struct BrushWithName
    {
        public Brush Value;
        public String Name;
    }



}
