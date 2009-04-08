using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Text;
using System.Runtime.InteropServices;

namespace MyChatServer
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		static string connstring;
	//	private Thread thread;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		//private Socket tempsocket;
		private TcpListener listener;
		private Socket tmpSocket;
		//���ͻ���������
		private System.Data.OracleClient.OracleConnection oconn;
		private System.Data.OracleClient.OracleCommand ocommand;
		static int MaxNum=100;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		//clients���鱣�ֵ�ǰ���ߵ�client����
		static ArrayList clients=new ArrayList();
		private int mouseX;
		private System.Windows.Forms.Button button3;
		private int mouseY;

		//*дini�ļ�
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section,string key,string val,string filePath);
		//��ini�ļ�
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder retVal,int size,string filePath);

		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(280, 400);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "��������";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4});
			this.listView1.Location = new System.Drawing.Point(8, 40);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(680, 192);
			this.listView1.TabIndex = 3;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "���";
			this.columnHeader1.Width = 114;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "����";
			this.columnHeader2.Width = 146;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "����";
			this.columnHeader3.Width = 157;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "IP";
			this.columnHeader4.Width = 176;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 240);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(680, 152);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "";
			// 
			// button4
			// 
			this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
			this.button4.Location = new System.Drawing.Point(683, 3);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(19, 19);
			this.button4.TabIndex = 17;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
			this.pictureBox3.Location = new System.Drawing.Point(416, 0);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(288, 24);
			this.pictureBox3.TabIndex = 14;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(360, 0);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(208, 24);
			this.pictureBox2.TabIndex = 13;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(704, 32);
			this.pictureBox1.TabIndex = 12;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			// 
			// button3
			// 
			this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
			this.button3.Location = new System.Drawing.Point(664, 3);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(19, 19);
			this.button3.TabIndex = 16;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Form1
			// 
			this.AcceptButton = this.button1;
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.ClientSize = new System.Drawing.Size(704, 437);
			this.ControlBox = false;
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		
		private void Broadcast(string message)
		{
			//�����е�ǰ�����û�������Ϣ
			for(int i=0;i<clients.Count;i++)
			{
				Client client=(Client)clients[i];
				SendToClient(client,message);
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(this.button1.Text=="��������")
			{
				try
				{
//					IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
					IPAddress ipAdd=IPAddress.Parse(GetIniData("data","serverip"));
//					for(int i=0;i<ipHost.AddressList.Length;i++)
//					{
//						ipAdd = ipHost.AddressList[0];//��ȡ��������IP
//						string tempip=ipAdd.ToString();
//						if(ipAdd.ToString().StartsWith("10.236.80."))
//							break;
//						if(i==ipHost.AddressList.Length-1)
//						{
//							this.textBox1.AppendText("δ�ҵ�80���Σ�\r\n");
//							return;
//						}
//					}
					if(ipAdd!=null)
					{
//					IPAddress ipAdd=IPAddress.Parse("10.236.80.6");
					//�����������׽���
					listener=new TcpListener(ipAdd,int.Parse(GetIniData("data","serverport")));
					//��ʼ�����������˿�
					listener.Start();
					this.textBox1.AppendText("�������Ѿ����������ڼ���"+ipAdd.ToString()+":"+int.Parse(GetIniData("data","serverport"))+"\r\n");
					//this.listBox1.Items.Add("�������Ѿ����������ڼ���"+"10.236.80.145"+":"+"9999");
					//����һ���̣߳�ִ��this.StartListen,��һ�������Ľ�����ִ��ȷ����ͻ����ӵĲ���
					Thread thread= new Thread(new ThreadStart(this.StartListen)); 
					thread.Start();
						this.button1.Text="ֹͣ����";
					}
				}
				catch(Exception ex)
				{
					this.textBox1.AppendText(ex.ToString().Trim('\0')+"\r\n");
					//this.listBox1.Items.Add(ex.ToString());
				}
			}
			else
			{
				this.button1.Text="��������";
				try
				{
					//todo: ֹͣ����
					if(this.tmpSocket!=null)
						this.tmpSocket.Close();
					this.listener.Stop();
					this.textBox1.AppendText("�������Ѿ��رռ�����\r\n");
					this.Remove_All();
					
					//Application.ExitThread();
					//Application.Exit();			
				}
				catch(Exception ex)
				{
					MessageBox.Show(this,ex.ToString(),"��ť������������");
					this.Remove_All();
				}

			}
		
		}
		//**********************************�Ƴ���������************************************//
		private void Remove_All()
		{
			for(int i=0;i<clients.Count;i++)
			{
				Client client=(Client)clients[i];
				if(!client.ClientSocket.Connected)
				{
					client.ClientSocket.Close();
					
				}
				
			}
			clients.Clear();
			this.listView1.Items.Clear();

		}
		/// <summary>
		/// StartListener()���������µ��߳��н��еģ�����Ҫ���ڵ����ֵ�һ���ͻ��������ʱ��
		/// ȷ����ͻ��˵����ӣ���ȴ��������һ���µ��߳�������͸ÿͻ��˵���Ϣ����
		/// </summary>
		private void StartListen()
		{
			bool flag=true;
			while(flag)
			{
				try
				{
					//�����յ�һ���ͻ�������ʱ��ȷ����ͻ��˵�����
					Socket socket = listener.AcceptSocket();
					//��tmpSocket���淢������Ŀͻ���ʵ��
					tmpSocket=socket;
					if(clients.Count>=MaxNum)
					{
						tmpSocket.Close();
					}
					else
					{
						//����һ���µ��̣߳�ִ�з���this.ServiceClient,�����û���Ӧ������
						Thread clientService=new Thread(new ThreadStart(this.ServiceClient));
						clientService.Start();
					}

				}
				catch(Exception ex)
				{
					if(tmpSocket!=null)
						tmpSocket.Close();
					flag=false;
					this.textBox1.AppendText(ex.Message.ToString().Trim('\0')+"\r\n");
					//this.listBox1.Items.Add(ex.ToString());
				}
			}
		}

		//************��ȡ������Ϣ***********//
		public static string GetIniData(string session,string key)
		{
			string path = Application.StartupPath + "\\set.ini";
			System.Text.StringBuilder str = new StringBuilder(255);
			int i = GetPrivateProfileString(session,key,"",str,255,path);
			return str.ToString();
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

			
		
		}

		//************��ȡ�û��б�***********//
		private string Get_User()
		{
			string result="";
			for(int i=0;i<this.listView1.Items.Count;i++)
			{
				//this.listView1.Items[i].SubItems[1].Text+
				result+=this.listView1.Items[i].SubItems[0].Text+"|"+this.listView1.Items[i].SubItems[1].Text+"("+this.listView1.Items[i].SubItems[2].Text+")|"+this.listView1.Items[i].SubItems[3].Text+"|";
			}
			return result;
		}
		//************�ͻ��˱�ʶ��***********//
		public class Client
		{
			string name;
			string group;
			string ip;
			Socket clSocket;

			public Client(string _name,string _group,string _ip,Socket _socket)
			{
				name=_name;
				group=_group;
				ip=_ip;
				clSocket=_socket;
			}

			public string Name
			{
				get
				{
					return name;
				}
				set
				{
					name=value;
				}
			}

			public string Group
			{
				get
				{
					return group;
				}
				set
				{
					group=value;
				}
			}
			public string Ip
			{
				get
				{
					return ip;
				}
				set
				{
					ip=value;
				}
			}


			public Socket ClientSocket
			{
				get
				{
					return clSocket;
				}
				set 
				{
					clSocket=value;
				}
			}
		}

		//************���ض��ͻ��˷�����Ϣ***********//
		private void SendToClient(Client client,string msg)
		{
			System.Byte[] message=System.Text.Encoding.Unicode.GetBytes(msg);//.ASCII.GetBytes(msg.ToCharArray());
			client.ClientSocket.Send(message,message.Length,0);
			lock(this.textBox1)
			{
				this.textBox1.AppendText("���������͸����"+client.Group+"������"+client.Name+"���ݣ�"+msg+"\r\n");
			}
		}


		private void ServiceClient()
		{
			//����һ��byte���飬���ڽ��մӿͻ��˷��͹��������ݣ�ÿ�����ܽ���ҵ����ݰ�����󳤶���1024���ֽ�
			
			Socket clientSocket = tmpSocket;
			bool keepConnect=true;
			//��ѭ�����ϵ���ͻ��˽��н�����֪���ͻ��˷�����exit�����

			while(keepConnect)
			{
				try
				{
					byte[] buff=new byte[1024];
					clientSocket.Receive(buff);
					//���ַ�����ת�����ַ���
					string message=System.Text.Encoding.Unicode.GetString(buff).Trim('\0');//.ASCII.GetString(buff);
					lock(this.textBox1)
					{
						this.textBox1.AppendText(message.Trim('\0')+"\r\n");
					}
					//this.listBox1.Items.Add(message);
					string[] temp=message.Trim('\0').Split('|');
					if(message.StartsWith("ADDUSER"))
					{
						//string[] temp=message.Split(';');
						this.Broadcast(message);	
						Client s=new Client(temp[4],temp[2],temp[1],clientSocket);
						clients.Add(s);
						string[] temp1=new string[4];
						temp1[0]=temp[2];
						temp1[1]=temp[3];
						temp1[2]=temp[4];
						temp1[3]=temp[1];
						lock(this.listView1)
						{
							this.listView1.Items.Add(new ListViewItem(temp1));	
						}
						string temp2="LISTALL|"+this.Get_User();
						this.SendToClient(s,temp2);
//						for(int i=0;i<clients.Count;i++)
//						{
//							Client client=(Client)clients[i];
//							if(client.Ip==temp[1].Trim())
//							{
//								string temp2="LISTALL|"+this.Get_User();					
//								SendToClient(client,temp2);
//							}
//						}		
					
					}
					else if(message.StartsWith("REMOVEUSER"))
					{
						//this.Record_Chat_Log("",System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"),temp[2],"ȫ��","ȫ��");
						for(int i=0;i<clients.Count;i++)
						{
							Client client=(Client)clients[i];
							if(client.Ip==temp[1].Trim('\0')&&client.Name==temp[2].Trim('\0'))
							{
								clients.RemoveAt(i);
								client.ClientSocket.Close();
								break;
							}
						}
						lock(this.listView1)
						{
							for(int i=0;i<this.listView1.Items.Count;i++)
							{
								//string io=this.listView1.Items[i].SubItems[3].Text;
								//string ioe=temp[1].Trim('\0');
								if(this.listView1.Items[i].SubItems[3].Text==temp[1].Trim('\0')&&this.listView1.Items[i].SubItems[2].Text==temp[2].Trim('\0'))
								{	
									this.listView1.Items.RemoveAt(i);
									break;
								}
							}
						}
						this.Broadcast(message);

					}
					else if(message.StartsWith("ALL"))
					{
						//int tempint=temp[1].IndexOf("��");
						string tempdate=System.DateTime.Now.ToShortDateString()+" "+System.DateTime.Now.ToLongTimeString();
						this.Record_Chat_Log(temp[1],tempdate,temp[2],"ȫ��","ȫ��");
						this.Broadcast(tempdate+"->\r\n"+temp[1].Trim());
					}
					else if(message.StartsWith("PRIVATETO"))
					{
						string tempdate=System.DateTime.Now.ToShortDateString()+" "+System.DateTime.Now.ToLongTimeString();
						for(int i=0;i<clients.Count;i++)
						{
							Client client=(Client)clients[i];
							
							if((client.Ip==temp[1].Trim()&&client.Name==temp[2].Trim())||client.Group=="�೤��"||client.Group=="����Ա��")
							{
								//int tempint=temp[3].IndexOf("��");
								SendToClient(client,tempdate+"->\r\n"+temp[3]);
								if(client.Group!="�೤��"&&client.Group!="����Ա��")
									this.Record_Chat_Log(temp[3],tempdate,temp[4],client.Group,client.Name);
							}
							
						}
					}
					else if(message.StartsWith("GROUPTO"))
					{
						//int tempint=temp[2].IndexOf("��");
						string tempdate=System.DateTime.Now.ToShortDateString()+" "+System.DateTime.Now.ToLongTimeString();
						this.Record_Chat_Log(temp[2],tempdate,temp[3],temp[1].Trim(),"ȫ��");
						for(int i=0;i<clients.Count;i++)
						{
							Client client=(Client)clients[i];
							if(client.Group==temp[1].Trim()||client.Group.Trim()=="�೤��"||client.Group=="����Ա��")
							{
								
								SendToClient(client,tempdate+"->\r\n"+temp[2]);
								
							}
						}
					}

				}
				catch
				{
					clientSocket.Close();
					keepConnect=false;
					this.Remove_Exception_User();
				}
				
			}
		}

		//*************************ȥ���쳣�˳��Ŀͻ���************************//
		private void Remove_Exception_User()
		{
			for(int i=0;i<clients.Count;i++)
			{
				Client client=(Client)clients[i];
				if(!client.ClientSocket.Connected)
				{
					clients.RemoveAt(i);
					lock(this.listView1)
					{
						for(int j=0;j<this.listView1.Items.Count;j++)
						{
							//string io=this.listView1.Items[i].SubItems[3].Text;
							//string ioe=temp[1].Trim('\0');
							if(this.listView1.Items[j].SubItems[3].Text==client.Ip&&this.listView1.Items[j].SubItems[2].Text==client.Name)
							{	
								this.listView1.Items.RemoveAt(j);
								break;
							}
						}
					}
					this.Broadcast("REMOVEUSER|"+client.Ip+"|"+client.Name);
				}
				
			}
			
		}
//****************************��¼�����¼***********************************//
		private void Record_Chat_Log(string message,string sendtime,string workerid,string groups,string members)
		{
			oconn= new OracleConnection(connstring);
			int messagebegin=message.IndexOf("˵��");
			string message1=message.Substring(messagebegin+2,message.Length-messagebegin-2);
			try
			{
				oconn.Open();
				string str="insert into t_message values('"+message1+"',to_date('"+sendtime+"','yyyy-MM-dd hh24:mi:ss'),'"+workerid+"','"+groups+"','"+members+"',nvl((select max(record_id) from t_message),0)+1)";
				ocommand=new OracleCommand(str,oconn);
				ocommand.ExecuteNonQuery();
				ocommand.Dispose();
				oconn.Close();
				
			}
			catch
			{
				oconn.Close();
			}


		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			connstring = "data source="+GetIniData("data","database")+";user id="+GetIniData("data","user")+";password="+ GetIniData("data","pwd");
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
//			if(MessageBox.Show("ȷ��Ҫ�˳�ϵͳ��","��ʾ��",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk)==DialogResult.No)
//			{					
//				return;
//			}
//			else
//			{
//				try
//				{
//					if(this.listener!=null)
//						this.listener.Stop();
//					if(this.tmpSocket.Connected)
//						this.tmpSocket.Close();
//					Application.Exit();
//				}
//				catch//(Exception ex)
//				{
//					if(this.listener!=null)
//						this.listener.Stop();
//					if(this.tmpSocket.Connected)
//						this.tmpSocket.Close();
//					//MessageBox.Show(this,ex.ToString(),"�رմ��������������");
//					Application.Exit();
//				}
//			}
			if(this.button1.Text=="ֹͣ����")
			{
				MessageBox.Show("��ֹͣ������Ȼ�����˳�ϵͳ","��ʾ��");
				return;
			}
			if(MessageBox.Show("ȷ��Ҫ�˳�ϵͳ��","��ʾ��",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk)==DialogResult.No)
			{					
				return;
			}
			else
			{
				try
				{
					if(this.tmpSocket!=null)
						this.tmpSocket.Close();		
					if(this.listener!=null)
						this.listener.Stop();					
					//Application.Exit();
					//Application.ExitThread();
					this.Remove_All();
					this.Kill_By_Name("MyChatServer");
				}
				catch(Exception)
				{
					if(this.tmpSocket!=null)
						this.tmpSocket.Close();
					if(this.listener!=null)
						this.listener.Stop();			
					//					MessageBox.Show(this,ex.ToString(),"�رմ���ֹͣ��������");
					//Application.Exit();
					//Application.ExitThread();
					this.Remove_All();
					this.Kill_By_Name("MyChatServer");
				}
			}
		}

		private void Kill_By_Name(string processname)
		{
			System.Diagnostics.Process[] process=System.Diagnostics.Process.GetProcessesByName(processname);
			foreach(System.Diagnostics.Process  p in process)
			{
				p.Kill();
			}
		}

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left) 
			{
				this.mouseX = e.X;
				this.mouseY = e.Y;
			}
		}

		private void Form1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			if(e.Button == MouseButtons.Left) 
			{
				//this.Top = Control.MousePosition.Y -this.mouseY- SystemInformation.FrameBorderSize.Height - SystemInformation.CaptionHeight;
				//this.Left = Control.MousePosition.X - this.mouseX- SystemInformation.FrameBorderSize.Width;
				this.Top = Control.MousePosition.Y -this.mouseY;
				this.Left = Control.MousePosition.X - this.mouseX;
			}
		
		}

		private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left) 
			{
				this.Top = Control.MousePosition.Y -this.mouseY;
				this.Left = Control.MousePosition.X - this.mouseX;
			}
		
		}

		private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			if(e.Button == MouseButtons.Left) 
			{
				this.mouseX = e.X;
				this.mouseY = e.Y;
			}
		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.WindowState=System.Windows.Forms.FormWindowState.Minimized;
		}

	}
}
