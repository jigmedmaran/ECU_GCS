using ECU_GCS.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Forms;

namespace ECU_GCS.Window
{
	public class RpmControl : UserControl
	{
		private float minValue = 0f;

		private float maxValue = 100f;

		private float changeValue = 0f;

		private Color pinColor = Color.FromArgb(191, 148, 28);

		private Color markColor = Color.FromArgb(250, 250, 250);

		private string unitText = "W";

		private string _midText = "RPM";

		private int minunit = 1;

		private int autoDiameter = 200;

		private float multiple = 1f;

		private int intervalValue;

		private float diameter;

		private float @value;

		private const int Speed = 10;

		private int speedtime = 10;

		private Image dashboardImage;

		private System.Timers.Timer SystemTimer = new System.Timers.Timer();

		private IContainer components = null;

		private System.Windows.Forms.Timer timer1;

		[Category("自定义属性")]
		[Description("仪表盘上变化的值")]
		public float ChangeValue
		{
			get
			{
				return this.changeValue;
			}
			set
			{
				this.changeValue = value;
			}
		}

		[Category("自定义属性")]
		[Description("仪表盘上刻度字的颜色")]
		public Color MarkColor
		{
			get
			{
				return this.markColor;
			}
			set
			{
				this.markColor = value;
			}
		}

		[Category("自定义属性")]
		[Description("仪表盘上显示的最大值")]
		public float MaxValue
		{
			get
			{
				return this.maxValue;
			}
			set
			{
				if (value > this.MinValue)
				{
					this.maxValue = value;
				}
				else
				{
					MessageBox.Show("最大值不能低于最小值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		[Category("自定义属性")]
		[DefaultValue("RPM")]
		[Description("标题")]
		public string MidText
		{
			get
			{
				return this._midText;
			}
			set
			{
				this._midText = value;
			}
		}

		[Category("自定义属性")]
		[Description("单位关联文本,默认1")]
		public int MinUnit
		{
			get
			{
				return this.minunit;
			}
			set
			{
				this.minunit = value;
			}
		}

		[Category("自定义属性")]
		[Description("仪表盘显示的最小值")]
		public float MinValue
		{
			get
			{
				return this.minValue;
			}
			set
			{
				if (value < this.MaxValue)
				{
					this.minValue = value;
				}
				else
				{
					MessageBox.Show("最小值不能超过最大值！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		[Category("自定义属性")]
		[Description("仪表盘上指针的颜色")]
		public Color PinColor
		{
			get
			{
				return this.pinColor;
			}
			set
			{
				this.pinColor = value;
			}
		}

		[Category("自定义属性")]
		[Description("单位关联文本")]
		public string UnitText
		{
			get
			{
				return this.unitText;
			}
			set
			{
				this.unitText = value;
			}
		}

		public RpmControl()
		{
			this.InitializeComponent();
			base.SetStyle(ControlStyles.UserPaint, true);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
			base.UpdateStyles();
			this.dashboardImage = Resources.Ellipse;
			this.InitialCanvas();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void drawBackImage()
		{
			if ((this.multiple == 0f ? false : this.dashboardImage != null))
			{
				Bitmap bit = new Bitmap(base.Width, base.Height);
				Graphics gp = Graphics.FromImage(bit);
				gp.SmoothingMode = SmoothingMode.HighQuality;
				float cerX = (float)(base.Width / 2);
				float cerY = (float)(base.Height / 2);
				float radius = this.diameter / 2f;
				gp.TranslateTransform(cerX, cerY);
				gp.DrawImage(this.dashboardImage, -radius, -radius, this.diameter, this.diameter);
				System.Drawing.Font uintFont = new System.Drawing.Font("微软雅黑", 50f * this.multiple, FontStyle.Bold);
				SizeF sfut = gp.MeasureString(this.MidText, uintFont);
				Color uintColor = Color.FromArgb(42, 57, 89);
				gp.DrawString(this.MidText, uintFont, new SolidBrush(uintColor), -sfut.Width / 2f, -sfut.Height / 2f);
				System.Drawing.Font scaleFont = new System.Drawing.Font("宋体", 9f * this.multiple, FontStyle.Bold);
				float startRad = 270f;
				float sweepShot = 0f;
				Color c1 = this.MarkColor;
				float radiusSpacing = radius - 30f * this.multiple;
				for (int i = 0; i < 5; i++)
				{
					int tempValue = i * this.intervalValue;
					SizeF tempSf = gp.MeasureString(tempValue.ToString(), scaleFont);
					double rad = (double)(sweepShot + startRad) * 3.14159265358979 / 180;
					float px = (float)((double)radiusSpacing * Math.Cos(rad));
					float py = (float)((double)radiusSpacing * Math.Sin(rad));
					if (sweepShot == 0f)
					{
						gp.DrawString(tempValue.ToString(), scaleFont, Brushes.Wheat, px - tempSf.Width / 2f, py - tempSf.Height / 2f);
					}
					else if (sweepShot == 30f)
					{
						gp.DrawString(tempValue.ToString(), scaleFont, new SolidBrush(c1), px - tempSf.Width / 2f, py - tempSf.Height / 2f);
					}
					else if (sweepShot == 60f)
					{
						gp.DrawString(tempValue.ToString(), scaleFont, new SolidBrush(c1), px - tempSf.Width + 8f * this.multiple, py - tempSf.Height / 2f + 5f * this.multiple);
					}
					else if (sweepShot == 90f)
					{
						gp.DrawString(tempValue.ToString(), scaleFont, new SolidBrush(c1), px - tempSf.Width + 8f * this.multiple, py - tempSf.Height / 2f);
					}
					else if (sweepShot == 120f)
					{
						gp.DrawString(tempValue.ToString(), scaleFont, new SolidBrush(c1), px - tempSf.Width + 8f * this.multiple, py - tempSf.Height / 2f);
					}
					sweepShot += 30f;
				}
				startRad = 270f;
				sweepShot = 0f;
				for (int i = 0; i < 5; i++)
				{
					int tempValue = -i * this.intervalValue;
					SizeF tempSf = gp.MeasureString(tempValue.ToString(), scaleFont);
					double rad = (double)(sweepShot + startRad) * 3.14159265358979 / 180;
					float px = (float)((double)radiusSpacing * Math.Cos(rad));
					float py = (float)((double)radiusSpacing * Math.Sin(rad));
					if (sweepShot == -30f)
					{
						gp.DrawString(tempValue.ToString(), scaleFont, Brushes.Red, px - tempSf.Width / 2f, py - tempSf.Height / 2f);
					}
					else if (sweepShot == -60f)
					{
						gp.DrawString(tempValue.ToString(), scaleFont, Brushes.Red, px - 8f * this.multiple, py - tempSf.Height / 2f + 5f * this.multiple);
					}
					else if (sweepShot == -90f)
					{
						gp.DrawString(tempValue.ToString(), scaleFont, Brushes.Red, px - 8f * this.multiple, py - tempSf.Height / 2f);
					}
					else if (sweepShot == -120f)
					{
						gp.DrawString(tempValue.ToString(), scaleFont, Brushes.Red, px - 8f * this.multiple, py - tempSf.Height / 2f);
					}
					sweepShot -= 30f;
				}
				gp.Dispose();
				this.BackgroundImage = bit;
			}
		}

		private void Drawing(Graphics g)
		{
			string text;
			if (this.multiple != 0f)
			{
				Bitmap bit = new Bitmap(base.Width, base.Height);
				Graphics gp = Graphics.FromImage(bit);
				gp.SmoothingMode = SmoothingMode.HighQuality;
				float cerX = (float)(base.Width / 2);
				float cerY = (float)(base.Height / 2);
				float radius = this.diameter / 2f;
				gp.TranslateTransform(cerX, cerY);
				float sweepShot = (float)(this.@value / this.MaxValue * 120f);
				float tempvalue = this.@value / (float)this.MinUnit;
				System.Drawing.Font strFont = new System.Drawing.Font("微软雅黑", 13f * this.multiple, FontStyle.Bold);
				text = (this.MinUnit < 1000 ? string.Concat(tempvalue.ToString("f1"), this.UnitText) : string.Concat(tempvalue.ToString("f1"), "k", this.UnitText));
				SizeF sf = gp.MeasureString(text, strFont);
				gp.DrawString(text, strFont, new SolidBrush(Color.FromArgb(216, 224, 241)), -sf.Width / 2f, 30f * this.multiple);
				gp.FillEllipse(new SolidBrush(this.PinColor), -5, -5, 10, 10);
				gp.RotateTransform(sweepShot);
				gp.DrawLine(new Pen(this.PinColor, 3f), 0f, 20f * this.multiple, 0f, -radius + 15f * this.multiple);
				gp.Dispose();
				g.DrawImage(bit, 0, 0);
			}
		}

		public void InitialCanvas()
		{
			if (base.Width <= base.Height)
			{
				this.diameter = (float)(base.Width - 6);
			}
			else
			{
				this.diameter = (float)(base.Height - 6);
			}
			if (this.diameter >= 1f)
			{
				this.multiple = (float)this.diameter / (float)this.autoDiameter;
				this.intervalValue = (int)((this.MaxValue - this.minValue) / 4f / (float)this.MinUnit);
				this.drawBackImage();
			}
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			base.SuspendLayout();
			this.timer1.Interval = 1;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.MinimumSize = new System.Drawing.Size(100, 100);
			base.Name = "RpmControl";
			base.Size = new System.Drawing.Size(200, 200);
			base.Load += new EventHandler(this.MetalDashboardUserCtrl_Load);
			base.Paint += new PaintEventHandler(this.MetalDashboardUserCtrl_Paint);
			base.Resize += new EventHandler(this.MetalDashboardUserCtrl_Resize);
			base.ResumeLayout(false);
		}

		private void MetalDashboardUserCtrl_Load(object sender, EventArgs e)
		{
			this.timer1.Interval = 1;
			this.timer1.Start();
		}

		private void MetalDashboardUserCtrl_Paint(object sender, PaintEventArgs e)
		{
			this.Drawing(e.Graphics);
		}

		private void MetalDashboardUserCtrl_Resize(object sender, EventArgs e)
		{
			this.InitialCanvas();
			this.Refresh();
		}

		private void SystemTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			if (this.ChangeValue > this.@value)
			{
				float tempc = this.ChangeValue - this.@value;
				float tempx = tempc / (float)this.speedtime;
				if (this.speedtime > 0)
				{
					this.speedtime--;
					this.@value += tempx;
				}
				if (this.speedtime == 0)
				{
					this.speedtime = 10;
				}
				base.Invoke(new Action(() => this.Refresh()));
			}
			else if (this.ChangeValue < this.@value)
			{
				float tempc = this.@value - this.ChangeValue;
				float tempx = tempc / (float)this.speedtime;
				if (this.speedtime > 0)
				{
					this.speedtime--;
					this.@value -= tempx;
				}
				if (this.speedtime == 0)
				{
					this.speedtime = 10;
				}
				base.Invoke(new Action(() => this.Refresh()));
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (this.ChangeValue > this.@value)
			{
				float tempc = this.ChangeValue - this.@value;
				float tempx = tempc / (float)this.speedtime;
				if (this.speedtime > 0)
				{
					this.speedtime--;
					this.@value += tempx;
				}
				if (this.speedtime == 0)
				{
					this.speedtime = 10;
				}
				this.Refresh();
			}
			else if (this.ChangeValue < this.@value)
			{
				float tempc = this.@value - this.ChangeValue;
				float tempx = tempc / (float)this.speedtime;
				if (this.speedtime > 0)
				{
					this.speedtime--;
					this.@value -= tempx;
				}
				if (this.speedtime == 0)
				{
					this.speedtime = 10;
				}
				this.Refresh();
			}
		}
	}
}