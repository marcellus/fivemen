using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FT.Commons.Tools;
using System.Collections;

namespace FT.NotePad
{
    public partial class ThingEditor : UserControl
    {
        public ThingEditor()
        {
            InitializeComponent();
        }

        private Thing currentThing;

        private TreeNode currentNode;

        private void editor1_Load(object sender, EventArgs e)
        {

        }

        private void ThingEditor_Load(object sender, EventArgs e)
        {
            if(!this.DesignMode)
            {
                this.CreateDefaultNode();
            }
        }

        private TreeNode CreateSecondNode(string type,int parentid)
        {
            TreeNode temp;
            temp = new TreeNode();
            temp.Text = type;
            Thing tmp = new Thing();
            tmp.Id = parentid;
            temp.Tag = tmp;
            temp.ImageIndex = 1;
            temp.SelectedImageIndex = 1;
            return temp;
        }

        private void ExpandFolder(TreeNode node)
        {
            if(node!=null)
            {
                Thing thing=node.Tag as Thing;
                string sql = "select id,c_title,d_notedate,c_context,i_parent_id,i_node_type from table_things where i_parent_id='"+thing.Id+"' order by id asc";
                DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        node.Nodes.Insert(0, this.BuildNodeFromDr(dt.Rows[i]));
                    }
                }
                node.Expand();
            }
        }

        private TreeNode BuildNodeFromDr(DataRow dr)
        {
            TreeNode node = new TreeNode();
            int type = Convert.ToInt32(dr[5].ToString());
            Thing thing = new Thing();
            thing.Id = Convert.ToInt32(dr[0].ToString());
            thing.NodeType = type;
            thing.NoteDate = Convert.ToDateTime(dr[2].ToString());
            thing.Title = dr[1].ToString();
            thing.ParentId = Convert.ToInt32(dr[4].ToString());
            thing.Context = dr[3].ToString();
            node.ToolTipText = dr[2].ToString();
            node.Text = thing.Title;
            node.Tag = thing;
            int imageindex = 1;
            if (type == (int)ThingType.Folder)
            {
                imageindex = 2;
                string sql = "select count(*) from table_things where i_parent_id='" + thing.Id + "'";

                object obj = FT.DAL.DataAccessFactory.GetDataAccess().SelectScalar(sql);
                int tmp = Convert.ToInt32(obj);
                if (tmp > 0)
                {
                    node.Text += "(" + tmp + ")";

                }
            }
            else if (type == (int)ThingType.Schedule)
            {
                imageindex = 3;

            }
            else if (type == (int)ThingType.Task)
            {
                imageindex = 4;
            }
            else if (type == (int)ThingType.JustThing)
            {
                imageindex = 5;
            }

            node.ImageIndex = imageindex;
            node.SelectedImageIndex = imageindex;
            return node;
        }

        private void CreateNodeFromDr(TreeNode top, DataRow dr)
        {
            if(dr!=null)
            {
                TreeNode node = this.BuildNodeFromDr(dr);
                Thing thing = node.Tag as Thing;
                if(thing.ParentId==-2)
                {
                    top.Nodes[0].Nodes.Insert(0, node);
                }
                else if (thing.ParentId == -3)
                {
                    top.Nodes[1].Nodes.Insert(0, node);
                }
                else if (thing.ParentId == -4)
                {
                    top.Nodes[2].Nodes.Insert(0, node);
                }
            }
        }

        private void CreateDefaultNode()
        {
            this.treeView1.ImageList = this.imageList1;
            TreeNode top = new TreeNode("我的记事本");
            top.Tag = "-1";
            top.ImageIndex = 0;
            top.SelectedImageIndex = 0;
            top.Nodes.Add(this.CreateSecondNode("计划书",-2));
            top.Nodes.Add(this.CreateSecondNode("代办事项",-3));
            top.Nodes.Add(this.CreateSecondNode("记事",-4));

            this.treeView1.HideSelection = false;
            this.treeView1.LabelEdit = true;
            this.treeView1.ShowNodeToolTips = true;

            this.treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            this.treeView1.DoubleClick += new EventHandler(treeView1_DoubleClick);
            this.treeView1.KeyDown += new KeyEventHandler(treeView1_KeyDown);
            this.treeView1.AfterLabelEdit += new NodeLabelEditEventHandler(treeView1_AfterLabelEdit);
            this.treeView1.MouseClick += new MouseEventHandler(treeView1_MouseClick);
            string sql = "select id,c_title,d_notedate,c_context,i_parent_id,i_node_type from table_things where i_parent_id in ('-2','-3','-4') order by id asc";
            DataTable dt = FT.DAL.DataAccessFactory.GetDataAccess().SelectDataTable(sql, "tmp");
            if(dt!=null)
            {
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                    CreateNodeFromDr(top,dt.Rows[i]);
                }
            }
            top.ExpandAll();
            this.treeView1.Nodes.Add(top);
           
            
        }

        void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Right)
            {
                object tmpObj = this.treeView1.GetNodeAt(this.treeView1.PointToClient(Cursor.Position));
                if (tmpObj != null)
                {
                    TreeNode temp = tmpObj as TreeNode;
                    this.treeView1.SelectedNode = temp;

                }
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode temp = this.treeView1.SelectedNode;
            if (temp != null)
            {

                
                Thing thing=temp.Tag as Thing;
                if(e.Label!=null&&e.Label.Length>0)
                thing.Title = e.Label;
                FT.DAL.Orm.SimpleOrmOperator.Update(thing);


            }
        }

        void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.F2)
            {
                TreeNode temp = this.treeView1.SelectedNode;
                if (temp != null)
                {
                    Thing thing = temp.Tag as Thing;
                    if(thing!=null&&thing.Id>0)
                    temp.BeginEdit();
                   // temp.EndEdit();

                }

            }
            
        }

        void treeView1_DoubleClick(object sender, EventArgs e)
        {
            object tmpObj = this.treeView1.GetNodeAt(this.treeView1.PointToClient(Cursor.Position));
            if (tmpObj != null)
            {
                TreeNode temp = tmpObj as TreeNode;
                if (temp.ImageIndex == 2&&temp.Nodes.Count==0)
                {

                    this.ExpandFolder(temp);
                }

            }
        }

        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            object tmpObj = this.treeView1.GetNodeAt(this.treeView1.PointToClient(Cursor.Position));
            if (tmpObj != null)
            {
                TreeNode temp = tmpObj as TreeNode;
                if(temp.ImageIndex>2)
                {

                    this.ShowThing(temp);
                }
                
            }
        }



        private void ShowThing(TreeNode temp)
        {
            if (temp != null)
            {
                Thing thing = temp.Tag as Thing;
                if(this.currentThing==null)
                {
                    //this.currentThing = thing;
                    //this.currentNode = temp;
                }
                else
                {
                    //this.currentNode.BackColor = this.treeView1.BackColor;
                    this.currentThing.Context = this.editor1.DocumentText;
                    if (this.currentThing.Id < 1)
                    {
                        if (FT.DAL.Orm.SimpleOrmOperator.Create(this.currentThing))
                        {
                            this.currentNode.Tag = this.currentThing;
                        }
                    }
                    else
                    {
                        if (FT.DAL.Orm.SimpleOrmOperator.Update(this.currentThing))
                        {
                            this.currentNode.Tag = this.currentThing;
                        }

                    }
                }


                
                this.currentNode = temp;
                 this.currentThing = thing;
                 this.editor1.DocumentText = thing.Context;
                
                 //this.currentNode.BackColor = this.treeView1.BackColor;
            }
            
        }

        private TreeNode CreateSubNode(TreeNode parent,ThingType type,string text)
        {
            TreeNode temp;
            temp = new TreeNode();
            temp.Text = text;
            Thing thing = new Thing();
            thing.NoteDate = System.DateTime.Now;
            Thing tmp = parent.Tag as Thing;

            thing.ParentId = tmp.Id;
            thing.Title = text;
            thing.NodeType = (int)type;
            int imageindex = 1;
            if (type == ThingType.Folder)
            {
                imageindex = 2;
            }
            else if (type == ThingType.Schedule)
            {
                imageindex = 3;

                thing.Context=this.editor1.GetTemplateContext("我的计划任务.html");

            }
            else if (type == ThingType.Task)
            {
                imageindex = 4;
                thing.Context = this.editor1.GetTemplateContext("我的待办事项.html");
            }
            else if (type == ThingType.JustThing)
            {
                imageindex = 5;
                thing.Context = this.editor1.GetTemplateContext("我的记事.html");
            }
            FT.DAL.Orm.SimpleOrmOperator.Create(thing);
            temp.Tag =thing;
            

            temp.ImageIndex = imageindex;
            temp.SelectedImageIndex = imageindex;


            this.ShowThing(temp);
            return temp;
        }

        private void 新建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node=this.treeView1.SelectedNode;
            if (node.ImageIndex != 0 && node.ImageIndex < 3)
            {
                TreeNode sub=this.CreateSubNode(node,ThingType.Folder,"新建文件夹");
                node.Nodes.Insert(0, sub);
                this.treeView1.SelectedNode = sub;
            }
        }

        private void 新增计划书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node.ImageIndex != 0 && node.ImageIndex < 3)
            {
                TreeNode sub = this.CreateSubNode(node, ThingType.Schedule, "新增计划书");
                node.Nodes.Insert(0, sub);
                this.treeView1.SelectedNode = sub;
            }
        }

        private void 新增代办事项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node.ImageIndex != 0 && node.ImageIndex<3)
            {
                TreeNode sub = this.CreateSubNode(node, ThingType.Task, "新增代办事项");
                node.Nodes.Insert(0, sub);
                this.treeView1.SelectedNode = sub;

            }
        }

        private void 新增记事ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node.ImageIndex != 0 && node.ImageIndex < 3)
            {
                TreeNode sub = this.CreateSubNode(node, ThingType.JustThing, "新增记事");
                node.Nodes.Insert(0, sub);
                this.treeView1.SelectedNode = sub;

            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node.ImageIndex > 1)
            {
                if(node.ImageIndex==2&&MessageBoxHelper.Confirm("确定要删除整个文件夹吗？"))
                {
                    if(this.RemoveAllNode(node))
                    node.Parent.Nodes.Remove(node);
                }
                else if(MessageBoxHelper.Confirm("确定要删除吗？"))
                {
                    if (this.RemoveAllNode(node))
                    node.Parent.Nodes.Remove(node);
                }

            }
        }

        private bool RemoveAllNode(TreeNode node)
        {
            Thing thing = node.Tag as Thing;
            string sql = "delete from table_things where ";
            if (thing.NodeType == (int)ThingType.Folder)
            {
                sql += " id=" + thing.Id + " or i_parent_id='" + thing.Id + "'";

            }
            else
            {
                sql += " id=" + thing.Id + "";
            }
            return FT.DAL.DataAccessFactory.GetDataAccess().ExecuteSql(sql);
        }

        private void 展开节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if(node!=null)
            node.Expand();
        }

        private void 收缩节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            if (node != null)
            node.Collapse();
        }
    }
}
