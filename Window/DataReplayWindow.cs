using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ECU_GCS
{
	public class DataReplayWindow : Form
	{
		private FileReadClass FileRead = new FileReadClass();

		private Timer timer = new Timer();

		private Timer timer_play = new Timer();

		private DateTime play_tic = DateTime.Now;

		private uint file_open_flag = 0;

		private bool run_flag = false;

		private uint cnt;

		private int cnt2;

		private uint play_flag = 0;

		private int data_n = 100;

		private int time_n = 5;

		private int speed_value = 1;

		private int fgdata_index = 0;

		private int fgdata_index_max = 0;

		private int start_index = 0;

		private int end_index = 0;

		private string filename;

		private const int length = 0;

		private string fileName = string.Empty;

		private int a_tic = 0;

		private IContainer components = null;

		private Button buttonPlay;

		private Button buttonOpenFile;

		private TextBox textBoxFileName;

		private Label label6;

		private Label label5;

		private Label label4;

		private Label labelNow;

		private Label label8;

		private TrackBar trackBaNow;

		private Label labelEnd;

		private Label label2;

		private ProgressBar progressBarPercent;

		private TrackBar trackBar_speed;

		public DataReplayWindow()
		{
			this.InitializeComponent();
			this.progressBarPercent.Visible = false;
			this.timer.Interval = 100;
			this.timer.Tick += new EventHandler(this.Timer_Tick);
			this.timer.Start();
			this.timer_play.Interval = 10;
			this.timer_play.Tick += new EventHandler(this.Timer_Play);
			this.timer_play.Start();
		}

		private void buttonOpenFile_Click(object sender, EventArgs e)
		{
			try
			{
				this.play_flag = 0;
				OpenFileDialog dialong = new OpenFileDialog()
				{
					Filter = "(*.d)|*.d"
				};
				if (dialong.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this.textBoxFileName.Text = "";
					this.run_flag = false;
					this.timer.Start();
					this.filename = dialong.FileName;
					this.FileRead.Read(dialong.FileName);
					this.progressBarPercent.Visible = true;
				}
			}
			catch
			{
			}
		}

		private void buttonPlay_Click(object sender, EventArgs e)
		{
			if (this.FileRead.Data != null)
			{
				if (this.play_flag != 1)
				{
					this.play_flag = 1;
					if (SetParameter.Language == "en-US")
					{
						this.buttonPlay.Text = "Suspend";
					}
					else if (SetParameter.Language != "zh-TW")
					{
						this.buttonPlay.Text = "暂停";
					}
					else
					{
						this.buttonPlay.Text = "暫停";
					}
				}
				else
				{
					this.play_flag = 0;
					if (SetParameter.Language == "en-US")
					{
						this.buttonPlay.Text = "Play";
					}
					else if (SetParameter.Language != "zh-TW")
					{
						this.buttonPlay.Text = "播放";
					}
					else
					{
						this.buttonPlay.Text = "播放";
					}
				}
			}
			else if (SetParameter.Language == "en-US")
			{
				MessageBox.Show("Please open the data file first");
			}
			else if (SetParameter.Language != "zh-TW")
			{
				MessageBox.Show("请先打开数据文件");
			}
			else
			{
				MessageBox.Show("請先打開資料檔案");
			}
		}

		private void DataReplayWindow_Load(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private double FindData(int index, string name)
		{
			double res = 0;
			int IndexOf_name = this.FileRead.Titles.ToList<string>().IndexOf(name);
			if ((IndexOf_name < 0 ? false : index < this.FileRead.Data.Count))
			{
				res = this.FileRead.Data[index][IndexOf_name];
			}
			return res;
		}

		private void get_send_data(int index)
		{
			Common.StatusStr = "记录回放";
			Common.SerialManager.EnableReceive = false;
			C2_Content_Common.Data.mode = (byte)this.FindData(index, "eng_cfg.mode");
			byte[] flg = new byte[] { (byte)this.FindData(index, "eng_0.cdi_enable"), (byte)this.FindData(index, "eng_1.cdi_enable"), (byte)this.FindData(index, "eng_dat.pump_enable"), (byte)this.FindData(index, "eng_0.oil_enable"), (byte)this.FindData(index, "bus.fly"), (byte)this.FindData(index, "sys.ver"), (byte)this.FindData(index, "eng_dat.jet_test"), (byte)this.FindData(index, "eng_0.ext_two_flg") };
			C2_Content_Common.Data.sta = (byte)((byte)(flg[0] & 1) | (byte)(flg[1] & 1) << 1 | (byte)(flg[2] & 1) << 2 | (byte)(flg[3] & 1) << 3 | (byte)(flg[4] & 1) << 4 | (byte)(flg[5] & 1) << 5 | (byte)(flg[6] & 1) << 6 | (byte)(flg[7] & 1) << 7);
			C2_Content_Common.Data.bus_thr = (byte)(this.FindData(index, "bus.thr_in") / 10);
			C2_Content_Common.Data.svr_pwm = (byte)(this.FindData(index, "bus.thr_exp") / 10);
			C2_Content_Common.Data.rpm_out = (ushort)this.FindData(index, "eng_dat.rpm_show");
			C2_Content_Common.Data.rpm1 = (ushort)this.FindData(index, "eng_0.rpm_val");
			C2_Content_Common.Data.rpm2 = (ushort)this.FindData(index, "eng_1.rpm_val");
			C2_Content_Common.Data.tmp_env = (short)this.FindData(index, "ms.correct_tmp");
			C2_Content_Common.Data.tmp0 = (short)this.FindData(index, "eng_dat.temp1");
			C2_Content_Common.Data.tmp1 = (short)this.FindData(index, "eng_dat.temp2");
			C2_Content_Common.Data.tmp2 = (short)this.FindData(index, "eng_dat.temp3");
			C2_Content_Common.Data.tmp3 = (short)this.FindData(index, "eng_dat.temp4");
			C2_Content_Common.Data.vol_power = (ushort)(this.FindData(index, "adc.vol_power_lpf") * 10);
			C2_Content_Common.Data.vol_svr = (byte)(this.FindData(index, "adc.vol_svr") * 10);
			C2_Content_Common.Data.vol_pump = (byte)(this.FindData(index, "adc.vol_out") * 10);
			C2_Content_Common.Data.amp_pump = (byte)(this.FindData(index, "adc.amp_pump_lpf") * 10);
			C2_Content_Common.Data.madc1 = (byte)(this.FindData(index, "adc.vol_adc1") * 10);
			C2_Content_Common.Data.madc2 = (byte)(this.FindData(index, "adc.vol_adc2") * 10);
			C2_Content_Common.Data.pre_gas = (float)this.FindData(index, "ms.pre");
			C2_Content_Common.Data.pre_alt = (short)this.FindData(index, "ms.alt_lpf");
			C2_Content_Common.Data.PWM_IN1 = (byte)(this.FindData(index, "bus.pwm_in1_per") / 10);
			C2_Content_Common.Data.PWM_IN2 = (byte)(this.FindData(index, "bus.pwm_in2_per") / 10);
			C2_Content_Common.Data.PWM_IN3 = (byte)(this.FindData(index, "bus.pwm_in3_per") / 10);
			C2_Content_Common.Data.PWM_OUT1 = (byte)this.FileRead.Data[index][this.FileRead.Titles.ToList<string>().IndexOf("bus.thr_out_pwm1")];
			C2_Content_Common.Data.PWM_OUT2 = (byte)this.FileRead.Data[index][this.FileRead.Titles.ToList<string>().IndexOf("bus.thr_out_pwm2")];
			C2_Content_Common.Data.PWM_OUT3 = (byte)this.FileRead.Data[index][this.FileRead.Titles.ToList<string>().IndexOf("bus.thr_out_pwm3")];
			C2_Content_Common.Data.pre_oil = (float)this.FindData(index, "adc.vol_adc3");
			C2_Content_Common.Data.inj1_ms = (ushort)(this.FindData(index, "eng_0.oil_ms_show") * 100);
			C2_Content_Common.Data.inj2_ms = (ushort)(this.FindData(index, "eng_1.oil_ms_show") * 100);
			C2_Content_Common.Data.inj1_mg = (ushort)(this.FindData(index, "eng_0.oil_mg_total") * 100);
			C2_Content_Common.Data.inj2_mg = (ushort)(this.FindData(index, "eng_1.oil_mg_total") * 100);
			C2_Content_Common.Data.eng_run_time = (ushort)this.FindData(index, "eng_dat.pcb_run_sec");
			C2_Content_Common.Data.err_flg = (ushort)this.FindData(index, "chk.flg0_chk_err");
		}

		private void InitializeComponent()
		{
			ComponentResourceManager resources = new ComponentResourceManager(typeof(DataReplayWindow));
			this.buttonPlay = new Button();
			this.buttonOpenFile = new Button();
			this.textBoxFileName = new TextBox();
			this.label6 = new Label();
			this.label5 = new Label();
			this.label4 = new Label();
			this.labelNow = new Label();
			this.label8 = new Label();
			this.trackBaNow = new TrackBar();
			this.labelEnd = new Label();
			this.label2 = new Label();
			this.progressBarPercent = new ProgressBar();
			this.trackBar_speed = new TrackBar();
			((ISupportInitialize)this.trackBaNow).BeginInit();
			((ISupportInitialize)this.trackBar_speed).BeginInit();
			base.SuspendLayout();
			resources.ApplyResources(this.buttonPlay, "buttonPlay");
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new EventHandler(this.buttonPlay_Click);
			resources.ApplyResources(this.buttonOpenFile, "buttonOpenFile");
			this.buttonOpenFile.Name = "buttonOpenFile";
			this.buttonOpenFile.UseVisualStyleBackColor = true;
			this.buttonOpenFile.Click += new EventHandler(this.buttonOpenFile_Click);
			resources.ApplyResources(this.textBoxFileName, "textBoxFileName");
			this.textBoxFileName.Name = "textBoxFileName";
			this.textBoxFileName.ReadOnly = true;
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			resources.ApplyResources(this.labelNow, "labelNow");
			this.labelNow.Name = "labelNow";
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			resources.ApplyResources(this.trackBaNow, "trackBaNow");
			this.trackBaNow.Maximum = 1000;
			this.trackBaNow.Name = "trackBaNow";
			this.trackBaNow.Scroll += new EventHandler(this.trackBaNow_Scroll);
			resources.ApplyResources(this.labelEnd, "labelEnd");
			this.labelEnd.Name = "labelEnd";
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			resources.ApplyResources(this.progressBarPercent, "progressBarPercent");
			this.progressBarPercent.Name = "progressBarPercent";
			resources.ApplyResources(this.trackBar_speed, "trackBar_speed");
			this.trackBar_speed.Maximum = 8;
			this.trackBar_speed.Minimum = 1;
			this.trackBar_speed.Name = "trackBar_speed";
			this.trackBar_speed.Value = 1;
			this.trackBar_speed.Scroll += new EventHandler(this.trackBar_speed_Scroll);
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.trackBar_speed);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.progressBarPercent);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.labelNow);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.trackBaNow);
			base.Controls.Add(this.labelEnd);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.buttonPlay);
			base.Controls.Add(this.buttonOpenFile);
			base.Controls.Add(this.textBoxFileName);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DataReplayWindow";
			base.Opacity = 0.8;
			base.TopMost = true;
			base.Load += new EventHandler(this.DataReplayWindow_Load);
			((ISupportInitialize)this.trackBaNow).EndInit();
			((ISupportInitialize)this.trackBar_speed).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			Common.SerialManager.EnableReceive = true;
			Common.StatusStr = "";
			this.timer.Stop();
			e.Cancel = true;
			this.play_flag = 0;
			if (SetParameter.Language == "en-US")
			{
				this.buttonPlay.Text = "Play";
			}
			else if (SetParameter.Language != "zh-TW")
			{
				this.buttonPlay.Text = "播放";
			}
			else
			{
				this.buttonPlay.Text = "播放";
			}
			base.Hide();
		}

		private string sec_to_hms(long duration)
		{
			TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(duration));
			string str = "";
			if (ts.Hours > 0)
			{
				str = string.Concat(new string[] { string.Format("{0:00}", ts.Hours), ":", string.Format("{0:00}", ts.Minutes), ":", string.Format("{0:00}", ts.Seconds) });
			}
			if ((ts.Hours != 0 ? false : ts.Minutes > 0))
			{
				str = string.Concat("00:", string.Format("{0:00}", ts.Minutes), ":", string.Format("{0:00}", ts.Seconds));
			}
			if ((ts.Hours != 0 ? false : ts.Minutes == 0))
			{
				str = string.Concat("00:00:", string.Format("{0:00}", ts.Seconds));
			}
			return str;
		}

		[DllImport("winmm", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern void timeBeginPeriod(int t);

		[DllImport("winmm", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern uint timeEndPeriod(int t);

		[DllImport("winmm", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern uint timeGetTime();

		private void Timer_Play(object sender, EventArgs e)
		{
			TimeSpan timeSpan = DateTime.Now.Subtract(this.play_tic);
			int deta = timeSpan.Milliseconds / 100;
			if (this.a_tic != deta)
			{
				this.a_tic = deta;
				this.timerfunction();
			}
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			this.progressBarPercent.Value = this.FileRead.Process;
			if (this.FileRead.Process != 100)
			{
				this.file_open_flag = 0;
			}
			else if (this.file_open_flag == 0)
			{
				this.file_open_flag = 1;
				this.fgdata_index_max = this.FileRead.Data.Count;
				this.end_index = this.fgdata_index_max;
				this.labelEnd.Text = this.sec_to_hms((long)(this.fgdata_index_max / 10));
				this.start_index = 0;
				this.fgdata_index = 0;
				this.progressBarPercent.Visible = false;
				if (SetParameter.Language == "en-US")
				{
					this.textBoxFileName.Text = string.Concat("Successfully opened：", Path.GetFileName(this.filename));
					this.buttonPlay.Text = "Play";
				}
				else if (SetParameter.Language != "zh-TW")
				{
					this.textBoxFileName.Text = string.Concat("成功打开：", Path.GetFileName(this.filename));
					this.buttonPlay.Text = "播放";
				}
				else
				{
					this.textBoxFileName.Text = string.Concat("成功打開：", Path.GetFileName(this.filename));
					this.buttonPlay.Text = "播放";
				}
				this.play_flag = 0;
				this.trackBaNow.Value = 0;
			}
		}

		private void timerfunction()
		{
			if (this.play_flag == 1)
			{
				this.get_send_data(this.fgdata_index);
				Action<int> action1 = (int data1) => {
					this.labelNow.Text = this.sec_to_hms((long)(data1 / 10));
					this.trackBaNow.Value = data1 * 1000 / this.fgdata_index_max;
				};
				base.Invoke(action1, new object[] { this.fgdata_index });
				this.fgdata_index += this.speed_value;
				if (this.fgdata_index > this.fgdata_index_max)
				{
					this.fgdata_index = this.fgdata_index_max;
					this.play_flag = 0;
				}
			}
		}

		private void trackBaNow_Scroll(object sender, EventArgs e)
		{
			this.fgdata_index = this.trackBaNow.Value * this.fgdata_index_max / 1000;
			this.labelNow.Text = this.sec_to_hms((long)(this.fgdata_index / 10));
		}

		private void trackBar_speed_Scroll(object sender, EventArgs e)
		{
			switch (this.trackBar_speed.Value)
			{
				case 1:
				{
					this.speed_value = 1;
					break;
				}
				case 2:
				{
					this.speed_value = 5;
					break;
				}
				case 3:
				{
					this.speed_value = 10;
					break;
				}
				case 4:
				{
					this.speed_value = 20;
					break;
				}
				case 5:
				{
					this.speed_value = 30;
					break;
				}
				case 6:
				{
					this.speed_value = 40;
					break;
				}
				case 7:
				{
					this.speed_value = 50;
					break;
				}
				case 8:
				{
					this.speed_value = 60;
					break;
				}
			}
			this.label5.Text = this.speed_value.ToString("f2");
		}
	}
}