// Decompiled with JetBrains decompiler
// Type: ECU_GCS.Window.UCThermometer
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ECU_GCS.Window
{
  public class UCThermometer : UserControl
  {
    private Color glassTubeColor = Color.FromArgb(211, 211, 211);
    private Color mercuryColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
    private Decimal minValue = 0M;
    private Decimal maxValue = 100M;
    private float m_value = 10f;
    private int splitCount = 0;
    private TemperatureUnit leftTemperatureUnit = TemperatureUnit.C;
    private TemperatureUnit rightTemperatureUnit = TemperatureUnit.C;
    private Rectangle m_rectWorking;
    private Rectangle m_rectLeft;
    private Rectangle m_rectRight;
    private IContainer components = (IContainer) null;

    [Description("玻璃管颜色")]
    [Category("自定义")]
    public Color GlassTubeColor
    {
      get => this.glassTubeColor;
      set
      {
        this.glassTubeColor = value;
        this.Refresh();
      }
    }

    [Description("水印颜色")]
    [Category("自定义")]
    public Color MercuryColor
    {
      get => this.mercuryColor;
      set
      {
        this.mercuryColor = value;
        this.Refresh();
      }
    }

    [Description("左侧刻度最小值")]
    [Category("自定义")]
    public Decimal MinValue
    {
      get => this.minValue;
      set
      {
        this.minValue = value;
        this.Refresh();
      }
    }

    [Description("左侧刻度最大值")]
    [Category("自定义")]
    public Decimal MaxValue
    {
      get => this.maxValue;
      set
      {
        this.maxValue = value;
        this.Refresh();
      }
    }

    [Description("左侧刻度值")]
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

    [Description("刻度分隔份数")]
    [Category("自定义")]
    public int SplitCount
    {
      get => this.splitCount;
      set
      {
        if (value <= 0)
          return;
        this.splitCount = value;
        this.Refresh();
      }
    }

    [Description("获取或设置控件显示的文字的字体")]
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

    [Description("获取或设置控件的文字及刻度颜色")]
    [Category("自定义")]
    public override Color ForeColor
    {
      get => base.ForeColor;
      set
      {
        base.ForeColor = value;
        this.Refresh();
      }
    }

    [Description("左侧刻度单位，不可为none")]
    [Category("自定义")]
    public TemperatureUnit LeftTemperatureUnit
    {
      get => this.leftTemperatureUnit;
      set
      {
        if (value == TemperatureUnit.None)
          return;
        this.leftTemperatureUnit = value;
        this.Refresh();
      }
    }

    [Description("右侧刻度单位，当为none时，不显示")]
    [Category("自定义")]
    public TemperatureUnit RightTemperatureUnit
    {
      get => this.rightTemperatureUnit;
      set
      {
        this.rightTemperatureUnit = value;
        this.Refresh();
      }
    }

    public UCThermometer()
    {
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.Selectable, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.AutoScaleMode = AutoScaleMode.None;
      this.SizeChanged += new EventHandler(this.UCThermometer_SizeChanged);
      this.Size = new Size(60, 200);
    }

    private void UCThermometer_SizeChanged(object sender, EventArgs e)
    {
      this.m_rectWorking = new Rectangle(this.Width / 2 - this.Width / 8, this.Width / 4, this.Width / 4, this.Height - this.Width / 2);
      this.m_rectLeft = new Rectangle(0, this.m_rectWorking.Top + this.m_rectWorking.Width / 2, (this.Width - this.Width / 4) / 2 - 2, this.m_rectWorking.Height - this.m_rectWorking.Width * 2);
      this.m_rectRight = new Rectangle(0, 0, 0, 0);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      Graphics graphics = e.Graphics;
      GraphicsPath path = new GraphicsPath();
      path.AddLine(this.m_rectWorking.Left, this.m_rectWorking.Bottom, this.m_rectWorking.Left, this.m_rectWorking.Top + this.m_rectWorking.Width / 2);
      path.AddArc(new Rectangle(this.m_rectWorking.Left, this.m_rectWorking.Top, this.m_rectWorking.Width, this.m_rectWorking.Width), 180f, 180f);
      path.AddLine(this.m_rectWorking.Right, this.m_rectWorking.Top + this.m_rectWorking.Width / 2, this.m_rectWorking.Right, this.m_rectWorking.Bottom);
      path.CloseAllFigures();
      graphics.FillPath((Brush) new SolidBrush(this.glassTubeColor), path);
      Rectangle rect1 = new Rectangle(this.Width / 2 - this.m_rectWorking.Width, this.m_rectWorking.Bottom - this.m_rectWorking.Width - 2, this.m_rectWorking.Width * 2, this.m_rectWorking.Width * 2);
      graphics.FillEllipse((Brush) new SolidBrush(this.glassTubeColor), rect1);
      graphics.FillEllipse((Brush) new SolidBrush(this.mercuryColor), new Rectangle(rect1.Left + 4, rect1.Top + 4, rect1.Width - 8, rect1.Height - 8));
      if (this.splitCount != 0)
      {
        Decimal num1 = (this.maxValue - this.minValue) / (Decimal) this.splitCount;
        Decimal num2 = (Decimal) (this.m_rectLeft.Height / this.splitCount);
        for (int index1 = 0; index1 <= this.splitCount; ++index1)
        {
          graphics.DrawLine(new Pen((Brush) new SolidBrush(this.ForeColor), 1f), new PointF((float) (this.m_rectLeft.Left + 2), (float) ((Decimal) this.m_rectLeft.Bottom - num2 * (Decimal) index1)), new PointF((float) this.m_rectLeft.Right, (float) ((Decimal) this.m_rectLeft.Bottom - num2 * (Decimal) index1)));
          string str1 = (this.minValue + num1 * (Decimal) index1).ToString("0.##");
          SizeF sizeF1 = graphics.MeasureString(str1, this.Font);
          graphics.DrawString(str1, this.Font, (Brush) new SolidBrush(this.ForeColor), new PointF((float) this.m_rectLeft.Left, (float) ((double) this.m_rectLeft.Bottom - (double) (float) num2 * (double) index1 - (double) sizeF1.Height - 1.0)));
          if (this.rightTemperatureUnit != 0)
          {
            graphics.DrawLine(new Pen((Brush) new SolidBrush(Color.Black), 1f), new PointF((float) (this.m_rectRight.Left + 2), (float) ((Decimal) this.m_rectRight.Bottom - num2 * (Decimal) index1)), new PointF((float) this.m_rectRight.Right, (float) ((Decimal) this.m_rectRight.Bottom - num2 * (Decimal) index1)));
            string str2 = this.GetRightValue(this.minValue + num1 * (Decimal) index1).ToString("0.##");
            SizeF sizeF2 = graphics.MeasureString(str2, this.Font);
            graphics.DrawString(str2, this.Font, (Brush) new SolidBrush(this.ForeColor), new PointF((float) ((double) this.m_rectRight.Right - (double) sizeF2.Width - 1.0), (float) ((double) this.m_rectRight.Bottom - (double) (float) num2 * (double) index1 - (double) sizeF2.Height - 1.0)));
          }
          if (index1 != this.splitCount)
          {
            if (num2 > 40M)
            {
              Decimal num3 = num2 / 10M;
              for (int index2 = 1; index2 < 10; ++index2)
              {
                if (index2 == 5)
                {
                  graphics.DrawLine(new Pen((Brush) new SolidBrush(this.ForeColor), 1f), new PointF((float) (this.m_rectLeft.Right - 10), (float) ((double) this.m_rectLeft.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num3 * (double) index2)), new PointF((float) this.m_rectLeft.Right, (float) ((double) this.m_rectLeft.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num3 * (double) index2)));
                  if (this.rightTemperatureUnit != 0)
                    graphics.DrawLine(new Pen((Brush) new SolidBrush(this.ForeColor), 1f), new PointF((float) (this.m_rectRight.Left + 10), (float) ((double) this.m_rectRight.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num3 * (double) index2)), new PointF((float) this.m_rectRight.Left, (float) ((double) this.m_rectRight.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num3 * (double) index2)));
                }
                else
                {
                  graphics.DrawLine(new Pen((Brush) new SolidBrush(this.ForeColor), 1f), new PointF((float) (this.m_rectLeft.Right - 5), (float) ((double) this.m_rectLeft.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num3 * (double) index2)), new PointF((float) this.m_rectLeft.Right, (float) ((double) this.m_rectLeft.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num3 * (double) index2)));
                  if (this.rightTemperatureUnit != 0)
                    graphics.DrawLine(new Pen((Brush) new SolidBrush(this.ForeColor), 1f), new PointF((float) (this.m_rectRight.Left + 5), (float) ((double) this.m_rectRight.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num3 * (double) index2)), new PointF((float) this.m_rectRight.Left, (float) ((double) this.m_rectRight.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num3 * (double) index2)));
                }
              }
            }
            else if (num2 > 10M)
            {
              graphics.DrawLine(new Pen((Brush) new SolidBrush(this.ForeColor), 1f), new PointF((float) (this.m_rectLeft.Right - 5), (float) ((double) this.m_rectLeft.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num2 / 2.0)), new PointF((float) this.m_rectLeft.Right, (float) ((double) this.m_rectLeft.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num2 / 2.0)));
              if (this.rightTemperatureUnit != 0)
                graphics.DrawLine(new Pen((Brush) new SolidBrush(this.ForeColor), 1f), new PointF((float) (this.m_rectRight.Left + 5), (float) ((double) this.m_rectRight.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num2 / 2.0)), new PointF((float) this.m_rectRight.Left, (float) ((double) this.m_rectRight.Bottom - (double) (float) num2 * (double) index1 - (double) (float) num2 / 2.0)));
            }
          }
        }
      }
      string unitChar1 = this.GetUnitChar(this.leftTemperatureUnit);
      graphics.DrawString(unitChar1, this.Font, (Brush) new SolidBrush(this.ForeColor), new PointF((float) (this.m_rectLeft.Left + 2), 2f));
      if (this.rightTemperatureUnit != 0)
      {
        string unitChar2 = this.GetUnitChar(this.rightTemperatureUnit);
        SizeF sizeF = graphics.MeasureString(unitChar2, this.Font);
        graphics.DrawString(unitChar2, this.Font, (Brush) new SolidBrush(this.ForeColor), new PointF((float) (this.m_rectRight.Right - 2) - sizeF.Width, 2f));
      }
      float num = this.Value / (float) (this.maxValue - this.minValue) * (float) this.m_rectLeft.Height;
      RectangleF rect2 = new RectangleF((float) (this.m_rectWorking.Left + 4), (float) this.m_rectLeft.Top + ((float) this.m_rectLeft.Height - num), (float) (this.m_rectWorking.Width - 8), num + (float) (this.m_rectWorking.Height - this.m_rectWorking.Width / 2 - this.m_rectLeft.Height));
      graphics.FillRectangle((Brush) new SolidBrush(this.mercuryColor), rect2);
      SizeF sizeF3 = graphics.MeasureString(this.m_value.ToString("0.##"), this.Font);
      graphics.DrawString(this.m_value.ToString("0.##"), this.Font, (Brush) new SolidBrush(Color.White), new PointF((float) rect1.Left + (float) (((double) rect1.Width - (double) sizeF3.Width) / 2.0), (float) ((double) rect1.Top + ((double) rect1.Height - (double) sizeF3.Height) / 2.0 + 1.0)));
    }

    private string GetUnitChar(TemperatureUnit unit)
    {
      string unitChar = "℃";
      switch (unit)
      {
        case TemperatureUnit.C:
          unitChar = "℃";
          break;
        case TemperatureUnit.F:
          unitChar = "℉";
          break;
        case TemperatureUnit.K:
          unitChar = "K";
          break;
        case TemperatureUnit.R:
          unitChar = "°R";
          break;
        case TemperatureUnit.Re:
          unitChar = "°Re";
          break;
      }
      return unitChar;
    }

    private Decimal GetRightValue(Decimal decValue)
    {
      Decimal rightValue = decValue;
      switch (this.leftTemperatureUnit)
      {
        case TemperatureUnit.F:
          rightValue = (decValue - 32M) / 1.8M;
          break;
        case TemperatureUnit.K:
          rightValue = decValue - 273M;
          break;
        case TemperatureUnit.R:
          rightValue = decValue / 0.5555555555555555555555555556M - 273.15M;
          break;
        case TemperatureUnit.Re:
          rightValue = decValue / 1.25M;
          break;
      }
      switch (this.rightTemperatureUnit)
      {
        case TemperatureUnit.C:
          return rightValue;
        case TemperatureUnit.F:
          return 1.8M * rightValue + 32M;
        case TemperatureUnit.K:
          return rightValue + 273M;
        case TemperatureUnit.R:
          return (rightValue + 273.15M) * 0.5555555555555555555555555556M;
        case TemperatureUnit.Re:
          return rightValue * 1.25M;
        default:
          return decValue;
      }
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
      this.Name = nameof (UCThermometer);
      this.Size = new Size(118, 275);
      this.ResumeLayout(false);
    }
  }
}
