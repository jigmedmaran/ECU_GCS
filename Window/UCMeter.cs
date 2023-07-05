// Decompiled with JetBrains decompiler
// Type: ECU_GCS.Window.UCMeter
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using ECU_GCS.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ECU_GCS.Window
{
  public class UCMeter : UserControl
  {
    private int splitCount = 10;
    private int meterDegrees = 150;
    private Decimal facValue = 1M;
    private Decimal minValue = 0M;
    private Decimal maxValue = 100M;
    private float m_value = 0.0f;
    private MeterTextLocation textLocation = MeterTextLocation.None;
    private string fixedText;
    private string fixedText2;
    private Font textFont = Control.DefaultFont;
    private Color externalRoundColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
    private Color insideRoundColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
    private Color boundaryLineColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
    private Color scaleColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
    private Color scaleValueColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
    private Color pointerColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
    private Color textColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
    private string _midText = "Bar";
    private int autoDiameter = 200;
    private float multiple = 1f;
    private float diameter;
    private Rectangle m_rectWorking;
    private Image dashboardImage;
    private IContainer components = (IContainer) null;

    [Description("分隔刻度数量，>1")]
    [Category("自定义")]
    public int SplitCount
    {
      get => this.splitCount;
      set
      {
        if (value < 1)
          return;
        this.splitCount = value;
        this.Refresh();
      }
    }

    [Description("表盘跨度角度，0-360")]
    [Category("自定义")]
    public int MeterDegrees
    {
      get => this.meterDegrees;
      set
      {
        if (value > 360 || value <= 0)
          return;
        this.meterDegrees = value;
        this.Refresh();
      }
    }

    [Description("放大倍数")]
    [Category("自定义")]
    public Decimal FacValue
    {
      get => this.facValue;
      set
      {
        this.facValue = value;
        this.Refresh();
      }
    }

    [Description("最小值,<MaxValue")]
    [Category("自定义")]
    public Decimal MinValue
    {
      get => this.minValue;
      set
      {
        if (value >= this.maxValue)
          return;
        this.minValue = value;
        this.Refresh();
      }
    }

    [Description("最大值,>MinValue")]
    [Category("自定义")]
    public Decimal MaxValue
    {
      get => this.maxValue;
      set
      {
        if (value <= this.minValue)
          return;
        this.maxValue = value;
        this.Refresh();
      }
    }

    [Description("刻度字体")]
    [Category("自定义")]
    public override Font Font
    {
      get => base.Font;
      set
      {
        base.Font = value;
        this.Refresh();
      }
    }

    [Description("值，>=MinValue并且<=MaxValue")]
    [Category("自定义")]
    public float Value
    {
      get => this.m_value;
      set
      {
        this.m_value = value;
        this.Refresh();
      }
    }

    [Description("值和固定文字显示位置")]
    [Category("自定义")]
    public MeterTextLocation TextLocation
    {
      get => this.textLocation;
      set
      {
        this.textLocation = value;
        this.Refresh();
      }
    }

    [Description("固定文字")]
    [Category("自定义")]
    public string FixedText
    {
      get => this.fixedText;
      set
      {
        this.fixedText = value;
        this.Refresh();
      }
    }

    [Description("固定文字2")]
    [Category("自定义")]
    public string FixedText2
    {
      get => this.fixedText2;
      set
      {
        this.fixedText2 = value;
        this.Refresh();
      }
    }

    [Description("值和固定文字字体")]
    [Category("自定义")]
    public Font TextFont
    {
      get => this.textFont;
      set
      {
        this.textFont = value;
        this.Refresh();
      }
    }

    [Description("外圆颜色")]
    [Category("自定义")]
    public Color ExternalRoundColor
    {
      get => this.externalRoundColor;
      set
      {
        this.externalRoundColor = value;
        this.Refresh();
      }
    }

    [Description("内圆颜色")]
    [Category("自定义")]
    public Color InsideRoundColor
    {
      get => this.insideRoundColor;
      set
      {
        this.insideRoundColor = value;
        this.Refresh();
      }
    }

    [Description("边界线颜色")]
    [Category("自定义")]
    public Color BoundaryLineColor
    {
      get => this.boundaryLineColor;
      set
      {
        this.boundaryLineColor = value;
        this.Refresh();
      }
    }

    [Description("刻度颜色")]
    [Category("自定义")]
    public Color ScaleColor
    {
      get => this.scaleColor;
      set
      {
        this.scaleColor = value;
        this.Refresh();
      }
    }

    [Description("刻度值文字颜色")]
    [Category("自定义")]
    public Color ScaleValueColor
    {
      get => this.scaleValueColor;
      set
      {
        this.scaleValueColor = value;
        this.Refresh();
      }
    }

    [Description("指针颜色")]
    [Category("自定义")]
    public Color PointerColor
    {
      get => this.pointerColor;
      set
      {
        this.pointerColor = value;
        this.Refresh();
      }
    }

    [Description("值和固定文字颜色")]
    [Category("自定义")]
    public Color TextColor
    {
      get => this.textColor;
      set
      {
        this.textColor = value;
        this.Refresh();
      }
    }

    [Category("自定义")]
    [Description("标题")]
    [DefaultValue("Bar")]
    public string MidText
    {
      get => this._midText;
      set => this._midText = value;
    }

    public UCMeter()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer, true);
      this.UpdateStyles();
      this.SizeChanged += new EventHandler(this.UCMeter1_SizeChanged);
      this.AutoScaleMode = AutoScaleMode.None;
      this.Size = new Size(350, 200);
      this.dashboardImage = (Image) Resources.Ellipse;
      this.InitialCanvas();
    }

    public void InitialCanvas()
    {
      this.diameter = this.Width <= this.Height ? (float) (this.Width - 6) : (float) (this.Height - 6);
      if ((double) this.diameter < 1.0)
        return;
      this.multiple = this.diameter / (float) this.autoDiameter;
      int num = (int) (22.0 * (double) this.multiple);
      this.m_rectWorking = new Rectangle(20, 20, (int) this.diameter - 40, (int) this.diameter - 40);
      this.m_rectWorking = new Rectangle(num / 2, num / 2, (int) this.diameter - num, (int) this.diameter - num);
      this.drawBackImage();
    }

    public void drawBackImage()
    {
      if ((double) this.multiple == 0.0 || this.dashboardImage == null)
        return;
      Bitmap bitmap = new Bitmap(this.Width, this.Height);
      Graphics graphics = Graphics.FromImage((Image) bitmap);
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      float dx = (float) (this.Width / 2);
      float dy = (float) (this.Height / 2);
      float num = this.diameter / 2f;
      graphics.TranslateTransform(dx, dy);
      graphics.DrawImage(this.dashboardImage, -num, -num, this.diameter, this.diameter);
      graphics.Dispose();
      this.BackgroundImage = (Image) bitmap;
    }

    private void UCMeter1_SizeChanged(object sender, EventArgs e)
    {
      this.InitialCanvas();
      this.Refresh();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      Graphics graphics = e.Graphics;
      float num1 = (float) (-90 - this.meterDegrees / 2 + 360);
      float num2 = this.diameter / 2f;
      float dx = (float) (this.Width / 2) - num2;
      float dy = (float) (this.Height / 2) - num2;
      graphics.TranslateTransform(dx, dy);
      Font font1 = new Font("微软雅黑", 50f * this.multiple, FontStyle.Bold);
      SizeF sizeF1 = graphics.MeasureString(this._midText, font1);
      Color color = Color.FromArgb(42, 57, 89);
      graphics.DrawString(this._midText, font1, (Brush) new SolidBrush(color), (float) (this.m_rectWorking.Left + this.m_rectWorking.Width / 2) - sizeF1.Width / 2f, (float) (this.m_rectWorking.Top + this.m_rectWorking.Height / 2) - sizeF1.Height / 2f);
      int num3 = this.splitCount * 2;
      float num4 = (float) this.meterDegrees / (float) num3;
      for (int index = 0; index <= num3; ++index)
      {
        float num5 = (float) (((double) num1 + (double) num4 * (double) index - 180.0) % 360.0);
        float num6 = (float) (this.m_rectWorking.Top + this.m_rectWorking.Width / 2) - (float) (this.m_rectWorking.Width / 2) * (float) Math.Sin(Math.PI * ((double) num5 / 180.0));
        float num7 = (float) this.m_rectWorking.Left + ((float) (this.m_rectWorking.Width / 2) - (float) (this.m_rectWorking.Width / 2) * (float) Math.Cos(Math.PI * ((double) num5 / 180.0)));
        float num8 = 0.0f;
        float num9 = 0.0f;
        if (index % 2 == 0)
        {
          num8 = (float) (this.m_rectWorking.Top + this.m_rectWorking.Width / 2) - (float) (this.m_rectWorking.Width / 2 - 10) * (float) Math.Sin(Math.PI * ((double) num5 / 180.0));
          num9 = (float) this.m_rectWorking.Left + ((float) (this.m_rectWorking.Width / 2) - (float) (this.m_rectWorking.Width / 2 - 10) * (float) Math.Cos(Math.PI * ((double) num5 / 180.0)));
          if (this.meterDegrees != 360 || index != num3)
          {
            Decimal num10 = this.minValue + (this.maxValue - this.minValue) / (Decimal) num3 * (Decimal) index;
            SizeF sizeF2 = graphics.MeasureString(num10.ToString("0.##"), this.Font);
            float y = (float) ((double) this.m_rectWorking.Top - (double) sizeF2.Height / 2.0 + (double) (this.m_rectWorking.Width / 2) - (double) (this.m_rectWorking.Width / 2 - 20) * Math.Sin(Math.PI * ((double) num5 / 180.0)));
            float x = (float) ((double) this.m_rectWorking.Left - (double) sizeF2.Width / 2.0 + ((double) (this.m_rectWorking.Width / 2) - (double) (this.m_rectWorking.Width / 2 - 20) * Math.Cos(Math.PI * ((double) num5 / 180.0))));
            graphics.DrawString(num10.ToString("0.##"), this.Font, (Brush) new SolidBrush(this.scaleValueColor), x, y);
          }
        }
        else
        {
          num8 = (float) (this.m_rectWorking.Top + this.m_rectWorking.Width / 2) - (float) (this.m_rectWorking.Width / 2 - 5) * (float) Math.Sin(Math.PI * ((double) num5 / 180.0));
          num9 = (float) this.m_rectWorking.Left + ((float) (this.m_rectWorking.Width / 2) - (float) (this.m_rectWorking.Width / 2 - 5) * (float) Math.Cos(Math.PI * ((double) num5 / 180.0)));
        }
      }
      Font font2 = new Font("微软雅黑", 13f * this.multiple, FontStyle.Bold);
      if (this.textLocation != 0)
      {
        string str = ((float) this.facValue * this.m_value).ToString("0.##");
        SizeF sizeF3 = graphics.MeasureString(str, font2);
        float y1 = (float) (this.m_rectWorking.Top + this.m_rectWorking.Width * 5 / 6) - sizeF3.Height / 2f;
        float x1 = (float) (this.m_rectWorking.Left + this.m_rectWorking.Width / 2) - sizeF3.Width / 2f;
        graphics.DrawString(str, font2, (Brush) new SolidBrush(Color.FromArgb(216, 224, 241)), new PointF(x1, y1));
        if (!string.IsNullOrEmpty(this.fixedText))
        {
          string fixedText = this.fixedText;
          sizeF3 = graphics.MeasureString(fixedText, font2);
          float y2 = (float) (this.m_rectWorking.Top + this.m_rectWorking.Width * 3 / 4) + sizeF3.Height / 4f;
          float x2 = (float) (this.m_rectWorking.Left + this.m_rectWorking.Width / 2) - sizeF3.Width / 2f;
          graphics.DrawString(fixedText, font2, (Brush) new SolidBrush(Color.FromArgb(216, 224, 241)), new PointF(x2, y2));
        }
        if (!string.IsNullOrEmpty(this.fixedText2))
        {
          string fixedText2 = this.fixedText2;
          sizeF3 = graphics.MeasureString(fixedText2, this.textFont);
          float y3 = (float) (this.m_rectWorking.Top + this.m_rectWorking.Width / 6) + sizeF3.Height / 4f;
          float x3 = (float) (this.m_rectWorking.Left + this.m_rectWorking.Width / 2) - sizeF3.Width / 2f;
          graphics.DrawString(fixedText2, this.textFont, (Brush) new SolidBrush(Color.FromArgb(216, 224, 241)), new PointF(x3, y3));
          string s = "r/min";
          graphics.DrawString(s, this.textFont, (Brush) new SolidBrush(Color.FromArgb(216, 224, 241)), new PointF(x3, y3 + sizeF3.Height));
        }
      }
      graphics.FillEllipse((Brush) new SolidBrush(Color.FromArgb(100, (int) this.pointerColor.R, (int) this.pointerColor.G, (int) this.pointerColor.B)), new Rectangle(this.m_rectWorking.Left + this.m_rectWorking.Width / 2 - 10, this.m_rectWorking.Top + this.m_rectWorking.Width / 2 - 10, 20, 20));
      graphics.FillEllipse(Brushes.Red, new Rectangle(this.m_rectWorking.Left + this.m_rectWorking.Width / 2 - 5, this.m_rectWorking.Top + this.m_rectWorking.Width / 2 - 5, 10, 10));
      float num11 = (float) (((double) num1 + (double) (this.m_value - (float) this.minValue) / (double) (float) (this.maxValue - this.minValue) * (double) this.meterDegrees - 180.0) % 360.0);
      float y1_1 = (float) (this.m_rectWorking.Top + this.m_rectWorking.Width / 2) - (float) (this.m_rectWorking.Width / 2 - 30) * (float) Math.Sin(Math.PI * ((double) num11 / 180.0));
      float x1_1 = (float) this.m_rectWorking.Left + ((float) (this.m_rectWorking.Width / 2) - (float) (this.m_rectWorking.Width / 2 - 30) * (float) Math.Cos(Math.PI * ((double) num11 / 180.0)));
      graphics.DrawLine(new Pen((Brush) new SolidBrush(this.pointerColor), 3f), x1_1, y1_1, (float) (this.m_rectWorking.Left + this.m_rectWorking.Width / 2), (float) (this.m_rectWorking.Top + this.m_rectWorking.Width / 2));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Name = nameof (UCMeter);
      this.Size = new Size(273, 267);
      this.ResumeLayout(false);
    }
  }
}
