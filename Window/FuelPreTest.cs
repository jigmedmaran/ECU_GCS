using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ECU_GCS
{
	public class FuelPreTest : Form
	{
		private bool cmd_sta = false;

		private float valve_ms;

		private float value_rpm;

		private IContainer components = null;

		private TextBox tb_rpm;

		private Label label4;

		private Label label3;

		private TextBox tb_ms;

		private Label label1;

		private Label label2;

		private Button bt_cmd;

		public FuelPreTest()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!this.cmd_sta)
			{
				try
				{
					this.valve_ms = float.Parse(this.tb_ms.Text);
					if ((this.valve_ms < 0.5f ? false : this.valve_ms <= 20f))
					{
						this.tb_ms.BackColor = Color.White;
					}
					else
					{
						this.tb_ms.BackColor = Color.Red;
						return;
					}
				}
				catch
				{
					this.tb_ms.BackColor = Color.Red;
					return;
				}
				try
				{
					this.value_rpm = float.Parse(this.tb_rpm.Text);
					if ((this.value_rpm < 100f ? false : this.value_rpm <= 20000f))
					{
						this.tb_rpm.BackColor = Color.White;
					}
					else
					{
						this.tb_rpm.BackColor = Color.Red;
						return;
					}
				}
				catch
				{
					this.tb_rpm.BackColor = Color.Red;
					return;
				}
				this.SendCommandContent(11, 1, float.Parse(this.tb_ms.Text), float.Parse(this.tb_rpm.Text));
			}
			else
			{
				this.SendCommandContent(11, 0, 0f, 0f);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void FuelPreTest_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			base.Hide();
		}

		private void FuelPreTest_Load(object sender, EventArgs e)
		{
			Timer timer = new Timer()
			{
				Interval = 10
			};
			timer.Tick += new EventHandler(this.Timer_Tick_Rec);
			timer.Start();
		}

		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(FuelPreTest));
			this.tb_rpm = new TextBox();
			this.label4 = new Label();
			this.label3 = new Label();
			this.tb_ms = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.bt_cmd = new Button();
			base.SuspendLayout();
			resources.ApplyResources(this.tb_rpm, "tb_rpm");
			this.tb_rpm.Name = "tb_rpm";
			this.tb_rpm.TextChanged += new EventHandler(this.tb_rpm_TextChanged);
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			resources.ApplyResources(this.tb_ms, "tb_ms");
			this.tb_ms.Name = "tb_ms";
			this.tb_ms.TextChanged += new EventHandler(this.tb_ms_TextChanged);
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			resources.ApplyResources(this.bt_cmd, "bt_cmd");
			this.bt_cmd.Name = "bt_cmd";
			this.bt_cmd.UseVisualStyleBackColor = true;
			this.bt_cmd.Click += new EventHandler(this.button1_Click);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.tb_rpm);
			base.Controls.Add(this.tb_ms);
			base.Controls.Add(this.bt_cmd);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "FuelPreTest";
			base.FormClosing += new FormClosingEventHandler(this.FuelPreTest_FormClosing);
			base.Load += new EventHandler(this.FuelPreTest_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private void SendCommandContent(byte cmd, uint value, float dat0, float dat1)
		{
			T18_Content_Command2 content = new T18_Content_Command2()
			{
				header0 = 181,
				header1 = 98,
				source = 195,
				target = 161,
				type = C18_Content_Command2.Type,
				num = (byte)C18_Content_Command2.Length,
				id = Common.Agreement.SendId,
				ack = 80,
				cmd = cmd,
				content = value,
				content0 = dat0,
				content1 = dat1,
				chk0 = 0,
				chk1 = 0,
				end0 = 13,
				end1 = 10
			};
			byte[] bytes = Agreement_Helper.StructToBytes(content);
			for (int i = 0; i < (int)bytes.Length - 4; i++)
			{
				ref byte numPointer = ref bytes[(int)bytes.Length - 4];
				numPointer = (byte)(numPointer ^ bytes[i]);
				ref byte numPointer1 = ref bytes[(int)bytes.Length - 3];
				numPointer1 = (byte)(numPointer1 ^ bytes[(int)bytes.Length - 4]);
			}
			Common.SerialManager.SendData(bytes);
		}

		private void tb_ms_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.valve_ms = float.Parse(this.tb_ms.Text);
				if ((this.valve_ms < 0.5f ? false : this.valve_ms <= 20f))
				{
					this.tb_ms.BackColor = Color.White;
				}
				else
				{
					this.tb_ms.BackColor = Color.Red;
				}
			}
			catch
			{
				this.tb_ms.BackColor = Color.Red;
			}
		}

		private void tb_rpm_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.value_rpm = float.Parse(this.tb_rpm.Text);
				if ((this.value_rpm < 100f ? false : this.value_rpm <= 20000f))
				{
					this.tb_rpm.BackColor = Color.White;
				}
				else
				{
					this.tb_rpm.BackColor = Color.Red;
				}
			}
			catch
			{
				this.tb_rpm.BackColor = Color.Red;
			}
		}

		private void Timer_Tick_Rec(object sender, EventArgs e)
		{
			if ((C2_Content_Common.Data.sta1 & 1) != 1)
			{
				this.bt_cmd.BackColor = Color.Gray;
				if (SetParameter.Language == "en-US")
				{
					this.bt_cmd.Text = "Start";
				}
				else if (SetParameter.Language != "zh-TW")
				{
					this.bt_cmd.Text = "开始";
				}
				else
				{
					this.bt_cmd.Text = "開始";
				}
				this.cmd_sta = false;
			}
			else
			{
				this.bt_cmd.BackColor = Color.Lime;
				if (SetParameter.Language == "en-US")
				{
					this.bt_cmd.Text = "Stop";
				}
				else if (SetParameter.Language != "zh-TW")
				{
					this.bt_cmd.Text = "停止";
				}
				else
				{
					this.bt_cmd.Text = "停止";
				}
				this.cmd_sta = true;
			}
		}
	}
}