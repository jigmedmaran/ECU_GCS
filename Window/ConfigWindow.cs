// Decompiled with JetBrains decompiler
// Type: ECU_GCS.ConfigWindow
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace ECU_GCS
{
  public class ConfigWindow : Form
  {
    private int oil1_cfg_cnt = 11;
    private int oil2_cfg_cnt = 11;
    private int exp_cfg_cnt = 11;
    private int pre_cfg_cnt = 11;
    private int oil1_cfg_begin = 1;
    private int oil2_cfg_begin = 12;
    private int exp_cfg_begin = 23;
    private int pre_cfg_begin = 34;
    private int config_begin = 1;
    private int config_count = 102;
    private Timer timer1 = new Timer();
    private Timer timer2 = new Timer();
    private Timer timer3 = new Timer();
    private int a = 51;
    private BoxObj box = new BoxObj(0.0, 10.0, 0.001, 10.0, Color.Black, Color.Black);
    private BoxObj box4 = new BoxObj(0.0, 10.0, 0.001, 10.0, Color.Black, Color.Black);
    private BoxObj box2 = new BoxObj(0.0, 100.0, 0.001, 100.0, Color.Black, Color.Black);
    private BoxObj box3 = new BoxObj(0.0, 100.0, 0.001, 100.0, Color.Black, Color.Black);
    private ZedGraphControl ThrOilGraph = new ZedGraphControl();
    private bool ThrOilMove = false;
    private int ThrOilIndex = 0;
    private ZedGraphControl ThrOil2Graph = new ZedGraphControl();
    private bool ThrOil2Move = false;
    private int ThrOil2Index = 0;
    private ZedGraphControl ThrExpGraph = new ZedGraphControl();
    private bool ThrExpMove = false;
    private int ThrExpIndex = 0;
    private ZedGraphControl OilPreGraph = new ZedGraphControl();
    private bool OilPreMove = false;
    private int OilPreIndex = 0;
    private IContainer components = (IContainer) null;
    private Button buttonUpload;
    private Button buttonDownload;
    private Panel panel1;
    private Panel panel2;
    private ComboBox comboBoxOilSelectThr;
    private TextBox textBoxOilWhenThr;
    private Button button风门重置;
    private Panel panel3;
    private GroupBox 喷油曲线;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Button btn_reset_oil_pre;
    private Panel panel_right;
    private GroupBox groupBox5;
    private Panel panel4;
    private ComboBox comboBoxOilSelectThr2;
    private TextBox textBoxOilWhenThr2;
    private TextBox tb引擎转速1;
    private TextBox tb引擎转速2;
    private TextBox tb喷油脉宽1;
    private TextBox tb喷油脉宽2;
    private TextBox tb温度1;
    private TextBox tb温度2;
    private TextBox tb温度3;
    private TextBox tb温度4;
    private TextBox tb油压;
    private TextBox tb风门舵机;
    private CheckBox checkBox1;
    private CheckBox checkBox2;
    private CheckBox checkBox3;
    private CheckBox checkBox4;
    private CheckBox checkBox5;
    private CheckBox checkBox6;
    private CheckBox checkBox7;
    private CheckBox checkBox8;
    private CheckBox checkBox9;
    private CheckBox checkBox10;
    private CheckBox checkBox11;

    private Point get_loc(int row, int num) => new Point(29 + num / row * 300, 5 + num % row * 29);

    public ConfigWindow()
    {
      this.InitializeComponent();
      this.ThrOilPanelInit();
      this.ThrOil2PanelInit();
      this.ThrExpPanelInit();
      this.OilPrePanelInit();
      this.timer2.Interval = 10;
      this.timer2.Tick += new EventHandler(this.Timer_Tick_Rec);
      this.timer2.Start();
      this.timer3.Interval = 10;
      this.timer3.Tick += new EventHandler(this.Timer_Tick_Show);
      this.timer3.Start();
    }

    private void ThrOilPanelInit()
    {
      double[] y = new double[11];
      double[] x = new double[11]
      {
        0.0,
        10.0,
        20.0,
        30.0,
        40.0,
        50.0,
        60.0,
        70.0,
        80.0,
        90.0,
        100.0
      };
      GraphPane graphPane = this.ThrOilGraph.GraphPane;
      graphPane.Title.Text = "";
      graphPane.XAxis.Title.Text = "";
      graphPane.YAxis.Title.Text = "";
      graphPane.Chart.Fill = new Fill(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 245), Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 190), 90f);
      graphPane.XAxis.Scale.Min = -1.0;
      graphPane.XAxis.Scale.Max = 101.0;
      graphPane.XAxis.MinSpace = 10f;
      graphPane.YAxis.Scale.Min = 0.0;
      graphPane.YAxis.Scale.Max = 10.0;
      graphPane.YAxis.MinSpace = 0.5f;
      graphPane.XAxis.MajorGrid.IsVisible = true;
      graphPane.YAxis.MajorGrid.IsVisible = true;
      graphPane.AddCurve("", x, y, Color.Red, SymbolType.Default).Symbol.Fill = new Fill(Color.Red);
      this.box.ZOrder = ZOrder.F_BehindGrid;
      this.ThrOilGraph.GraphPane.GraphObjList.Add((GraphObj) this.box);
      this.panel1.Controls.Add((Control) this.ThrOilGraph);
      this.ThrOilGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(this.ThrOilZedGraph_PointValueEvent);
      ((Control) this.ThrOilGraph).MouseMove += new MouseEventHandler(this.ThrOilZedGraph_MouseMove);
      this.ThrOilGraph.AutoSize = true;
      this.ThrOilGraph.IsShowContextMenu = false;
      this.ThrOilGraph.IsEnableHPan = false;
      this.ThrOilGraph.IsEnableVPan = false;
      this.ThrOilGraph.IsEnableSelection = true;
      this.ThrOilGraph.IsEnableZoom = false;
      this.ThrOilGraph.IsShowPointValues = true;
      this.ThrOilGraph.Dock = DockStyle.Fill;
      this.ThrOilGraph.AxisChange();
      this.ThrOilPanelLoadData(Color.Blue);
      this.textBoxOilWhenThr.Text = "0";
      this.comboBoxOilSelectThr.Items.Clear();
      this.comboBoxOilSelectThr.Items.AddRange(new object[11]
      {
        (object) " 0%",
        (object) "10%",
        (object) "20%",
        (object) "30%",
        (object) "40%",
        (object) "50%",
        (object) "60%",
        (object) "70%",
        (object) "80%",
        (object) "90%",
        (object) "100%"
      });
      int num = 1;
      for (int index1 = 0; index1 <= 100; index1 += 10)
      {
        int index2 = num++;
        Common.cfg_value[index2] = new CfgValue(0.0f, false);
        Common.cfg_value[index2].Step = 0.1f;
        Common.cfg_value[index2].Min = 0.0f;
        Common.cfg_value[index2].Max = 10f;
        Common.cfg_value[index2].Name_Save = "inj1_quantity(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Index = index2;
        Common.cfg_value[index2].num = this.a++;
      }
    }

    private void ThrOilPanelLoadZero()
    {
      for (int index = 0; index < this.oil1_cfg_cnt; ++index)
      {
        Common.cfg_value[this.oil1_cfg_begin + index].SetValue(0.0f);
        this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y = 0.0;
      }
      this.ThrOilGraph.GraphPane.CurveList[0].Color = Color.Red;
      this.ThrOilGraph.Refresh();
    }

    public void ThrOilPanelLoadData(Color displayColor)
    {
      for (int index = 0; index < this.oil1_cfg_cnt; ++index)
        this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y = (double) Common.cfg_value[this.oil1_cfg_begin + index].Value;
      this.ThrOilGraph.GraphPane.CurveList[0].Color = displayColor;
      this.ThrOilGraph.Refresh();
    }

    private void ThrOilZedGraph_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.ThrOilMove)
        return;
      if (Control.MouseButtons == MouseButtons.Left)
      {
        double y;
        this.ThrOilGraph.GraphPane.ReverseTransform(new PointF((float) e.X, (float) e.Y), out double _, out y);
        y = y > 10.0 ? 10.0 : (y < 0.0 ? 0.0 : y);
        double num = Math.Round(y, 2);
        if (this.checkBox1.Checked && this.ThrOilIndex == 0 || this.checkBox2.Checked && this.ThrOilIndex == 1 || this.checkBox3.Checked && this.ThrOilIndex == 2 || this.checkBox4.Checked && this.ThrOilIndex == 3 || this.checkBox5.Checked && this.ThrOilIndex == 4 || this.checkBox6.Checked && this.ThrOilIndex == 5 || this.checkBox7.Checked && this.ThrOilIndex == 6 || this.checkBox8.Checked && this.ThrOilIndex == 7 || this.checkBox9.Checked && this.ThrOilIndex == 8 || this.checkBox10.Checked && this.ThrOilIndex == 9 || this.checkBox11.Checked && this.ThrOilIndex == 10)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[this.ThrOilIndex].Y = num;
          Common.cfg_value[this.oil2_cfg_begin + this.ThrOilIndex].SetValue((float) num);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
        }
        this.ThrOilGraph.GraphPane.CurveList[0].Points[this.ThrOilIndex].Y = num;
        Common.cfg_value[this.oil1_cfg_begin + this.ThrOilIndex].SetValue((float) num);
        this.ThrOilGraph.GraphPane.CurveList[0].Color = Color.Red;
        this.ThrOilGraph.Refresh();
      }
      else
      {
        this.ThrOilMove = false;
        this.Upload();
      }
    }

    private string ThrOilZedGraph_PointValueEvent(
      ZedGraphControl sender,
      GraphPane pane,
      CurveItem curve,
      int iPt)
    {
      if (Control.MouseButtons == MouseButtons.Left && !this.ThrOilMove)
      {
        this.ThrOilMove = true;
        this.ThrOilIndex = iPt;
      }
      return this.ThrOilGraph.GraphPane.CurveList[0].Points[iPt].Y.ToString("0.00");
    }

    private void ThrOil2PanelInit()
    {
      double[] y = new double[11];
      double[] x = new double[11]
      {
        0.0,
        10.0,
        20.0,
        30.0,
        40.0,
        50.0,
        60.0,
        70.0,
        80.0,
        90.0,
        100.0
      };
      GraphPane graphPane = this.ThrOil2Graph.GraphPane;
      graphPane.Title.Text = "";
      graphPane.XAxis.Title.Text = "";
      graphPane.YAxis.Title.Text = "";
      graphPane.Chart.Fill = new Fill(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 245), Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 190), 90f);
      graphPane.XAxis.Scale.Min = -1.0;
      graphPane.XAxis.Scale.Max = 101.0;
      graphPane.XAxis.MinSpace = 10f;
      graphPane.YAxis.Scale.Min = 0.0;
      graphPane.YAxis.Scale.Max = 10.0;
      graphPane.YAxis.MinSpace = 0.5f;
      graphPane.XAxis.MajorGrid.IsVisible = true;
      graphPane.YAxis.MajorGrid.IsVisible = true;
      graphPane.AddCurve("", x, y, Color.Red, SymbolType.Default).Symbol.Fill = new Fill(Color.Red);
      this.box.ZOrder = ZOrder.F_BehindGrid;
      this.ThrOil2Graph.GraphPane.GraphObjList.Add((GraphObj) this.box4);
      this.panel4.Controls.Add((Control) this.ThrOil2Graph);
      this.ThrOil2Graph.PointValueEvent += new ZedGraphControl.PointValueHandler(this.ThrOil2ZedGraph_PointValueEvent);
      ((Control) this.ThrOil2Graph).MouseMove += new MouseEventHandler(this.ThrOil2ZedGraph_MouseMove);
      this.ThrOil2Graph.AutoSize = true;
      this.ThrOil2Graph.IsShowContextMenu = false;
      this.ThrOil2Graph.IsEnableHPan = false;
      this.ThrOil2Graph.IsEnableVPan = false;
      this.ThrOil2Graph.IsEnableSelection = true;
      this.ThrOil2Graph.IsEnableZoom = false;
      this.ThrOil2Graph.IsShowPointValues = true;
      this.ThrOil2Graph.Dock = DockStyle.Fill;
      this.ThrOil2Graph.AxisChange();
      this.ThrOil2PanelLoadData(Color.Blue);
      this.textBoxOilWhenThr2.Text = "0";
      this.comboBoxOilSelectThr2.Items.Clear();
      this.comboBoxOilSelectThr2.Items.AddRange(new object[11]
      {
        (object) " 0%",
        (object) "10%",
        (object) "20%",
        (object) "30%",
        (object) "40%",
        (object) "50%",
        (object) "60%",
        (object) "70%",
        (object) "80%",
        (object) "90%",
        (object) "100%"
      });
      int num = 12;
      for (int index1 = 0; index1 <= 100; index1 += 10)
      {
        int index2 = num++;
        Common.cfg_value[index2] = new CfgValue(0.0f, false);
        Common.cfg_value[index2].Step = 0.1f;
        Common.cfg_value[index2].Min = 0.0f;
        Common.cfg_value[index2].Max = 10f;
        Common.cfg_value[index2].Name_Save = "inj2_quantity(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Index = index2;
        Common.cfg_value[index2].num = this.a++;
      }
    }

    private void ThrOil2PanelLoadZero()
    {
      for (int index = 0; index < this.oil2_cfg_cnt; ++index)
      {
        Common.cfg_value[this.oil2_cfg_begin + index].SetValue(0.0f);
        this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = 0.0;
      }
      this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
      this.ThrOil2Graph.Refresh();
    }

    public void ThrOil2PanelLoadData(Color displayColor)
    {
      for (int index = 0; index < this.oil2_cfg_cnt; ++index)
        this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = (double) Common.cfg_value[this.oil2_cfg_begin + index].Value;
      this.ThrOil2Graph.GraphPane.CurveList[0].Color = displayColor;
      this.ThrOil2Graph.Refresh();
    }

    private void ThrOil2ZedGraph_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.ThrOil2Move)
        return;
      if (Control.MouseButtons == MouseButtons.Left)
      {
        double y;
        this.ThrOil2Graph.GraphPane.ReverseTransform(new PointF((float) e.X, (float) e.Y), out double _, out y);
        y = y > 10.0 ? 10.0 : (y < 0.0 ? 0.0 : y);
        double num = Math.Round(y, 2);
        if (this.checkBox1.Checked && this.ThrOil2Index == 0 || this.checkBox2.Checked && this.ThrOil2Index == 1 || this.checkBox3.Checked && this.ThrOil2Index == 2 || this.checkBox4.Checked && this.ThrOil2Index == 3 || this.checkBox5.Checked && this.ThrOil2Index == 4 || this.checkBox6.Checked && this.ThrOil2Index == 5 || this.checkBox7.Checked && this.ThrOil2Index == 6 || this.checkBox8.Checked && this.ThrOil2Index == 7 || this.checkBox9.Checked && this.ThrOil2Index == 8 || this.checkBox10.Checked && this.ThrOil2Index == 9 || this.checkBox11.Checked && this.ThrOil2Index == 10)
        {
          this.ThrOilGraph.GraphPane.CurveList[0].Points[this.ThrOil2Index].Y = num;
          Common.cfg_value[this.oil1_cfg_begin + this.ThrOil2Index].SetValue((float) num);
          this.ThrOilGraph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOilGraph.Refresh();
        }
        this.ThrOil2Graph.GraphPane.CurveList[0].Points[this.ThrOil2Index].Y = num;
        Common.cfg_value[this.oil2_cfg_begin + this.ThrOil2Index].SetValue((float) num);
        this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
        this.ThrOil2Graph.Refresh();
      }
      else
      {
        this.ThrOil2Move = false;
        this.Upload();
      }
    }

    private string ThrOil2ZedGraph_PointValueEvent(
      ZedGraphControl sender,
      GraphPane pane,
      CurveItem curve,
      int iPt)
    {
      if (Control.MouseButtons == MouseButtons.Left && !this.ThrOil2Move)
      {
        this.ThrOil2Move = true;
        this.ThrOil2Index = iPt;
      }
      return this.ThrOil2Graph.GraphPane.CurveList[0].Points[iPt].Y.ToString("0.00");
    }

    private void ThrExpPanelInit()
    {
      double[] y = new double[11];
      double[] x = new double[11]
      {
        0.0,
        10.0,
        20.0,
        30.0,
        40.0,
        50.0,
        60.0,
        70.0,
        80.0,
        90.0,
        100.0
      };
      double[] numArray1 = new double[2];
      double[] numArray2 = new double[2]{ 0.0, 10.0 };
      GraphPane graphPane = this.ThrExpGraph.GraphPane;
      graphPane.Title.Text = "";
      graphPane.XAxis.Title.Text = "";
      graphPane.YAxis.Title.Text = "";
      graphPane.Chart.Fill = new Fill(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 245), Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 190), 90f);
      graphPane.XAxis.Scale.Min = -1.0;
      graphPane.XAxis.Scale.Max = 101.0;
      graphPane.XAxis.MinSpace = 10f;
      graphPane.YAxis.Scale.Min = 0.0;
      graphPane.YAxis.Scale.Max = 100.0;
      graphPane.YAxis.MinSpace = 20f;
      graphPane.XAxis.MajorGrid.IsVisible = true;
      graphPane.YAxis.MajorGrid.IsVisible = true;
      LineItem lineItem = graphPane.AddCurve("", x, y, Color.Red, SymbolType.Default);
      this.box2.ZOrder = ZOrder.F_BehindGrid;
      this.ThrExpGraph.GraphPane.GraphObjList.Add((GraphObj) this.box2);
      lineItem.Symbol.Fill = new Fill(Color.Red);
      this.panel2.Controls.Add((Control) this.ThrExpGraph);
      this.ThrExpGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(this.ThrExpZedGraph_PointValueEvent);
      ((Control) this.ThrExpGraph).MouseMove += new MouseEventHandler(this.ThrExpZedGraph_MouseMove);
      this.ThrExpGraph.AutoSize = true;
      this.ThrExpGraph.IsShowContextMenu = false;
      this.ThrExpGraph.IsEnableHPan = false;
      this.ThrExpGraph.IsEnableVPan = false;
      this.ThrExpGraph.IsEnableSelection = true;
      this.ThrExpGraph.IsEnableZoom = false;
      this.ThrExpGraph.IsShowPointValues = true;
      this.ThrExpGraph.Dock = DockStyle.Fill;
      this.ThrExpGraph.AxisChange();
      int num = 23;
      for (int index1 = 0; index1 <= 100; index1 += 10)
      {
        int index2 = num++;
        Common.cfg_value[index2] = new CfgValue(0.0f, false);
        Common.cfg_value[index2].Step = 1f;
        Common.cfg_value[index2].Min = 0.0f;
        Common.cfg_value[index2].Max = 100f;
        Common.cfg_value[index2].Name = "映射值（" + index1.ToString() + "%）";
        Common.cfg_value[index2].Name_CN = "风门映射(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Name_CN_TW = "風門映射(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Name_EN = "Servo mapping(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Name_Save = "servo_mapping(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Index = index2;
        Common.cfg_value[index2].num = this.a++;
      }
    }

    private void ThrExpPanelLoadZero()
    {
      for (int index = 0; index < this.exp_cfg_cnt; ++index)
      {
        Common.cfg_value[this.exp_cfg_begin + index].SetValue(0.0f);
        this.ThrExpGraph.GraphPane.CurveList[0].Points[index].Y = 0.0;
      }
      this.ThrExpGraph.GraphPane.CurveList[0].Color = Color.Red;
      this.ThrExpGraph.Refresh();
    }

    private void ThrExpPanelLoadDefault()
    {
      for (int index = 0; index < this.exp_cfg_cnt; ++index)
      {
        Common.cfg_value[this.exp_cfg_begin + index].SetValue((float) (index * 10));
        this.ThrExpGraph.GraphPane.CurveList[0].Points[index].Y = (double) (index * 10);
      }
      this.ThrExpGraph.GraphPane.CurveList[0].Color = Color.Red;
      this.ThrExpGraph.Refresh();
    }

    public void ThrExpPanelLoadData(Color displayColor)
    {
      for (int index = 0; index < this.exp_cfg_cnt; ++index)
        this.ThrExpGraph.GraphPane.CurveList[0].Points[index].Y = (double) Common.cfg_value[this.exp_cfg_begin + index].Value;
      this.ThrExpGraph.GraphPane.CurveList[0].Color = displayColor;
      this.ThrExpGraph.Refresh();
    }

    private void ThrExpZedGraph_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.ThrExpMove)
        return;
      if (Control.MouseButtons == MouseButtons.Left)
      {
        double y;
        this.ThrExpGraph.GraphPane.ReverseTransform(new PointF((float) e.X, (float) e.Y), out double _, out y);
        y = y > 100.0 ? 100.0 : (y < 0.0 ? 0.0 : y);
        double num = Math.Round(y, 0);
        Common.cfg_value[this.exp_cfg_begin + this.ThrExpIndex].SetValue((float) num);
        this.ThrExpGraph.GraphPane.CurveList[0].Points[this.ThrExpIndex].Y = num;
        this.ThrExpGraph.GraphPane.CurveList[0].Color = Color.Red;
        this.ThrExpGraph.Refresh();
      }
      else
      {
        this.ThrExpMove = false;
        this.Upload();
      }
    }

    private string ThrExpZedGraph_PointValueEvent(
      ZedGraphControl sender,
      GraphPane pane,
      CurveItem curve,
      int iPt)
    {
      if (Control.MouseButtons == MouseButtons.Left && !this.ThrExpMove)
      {
        this.ThrExpMove = true;
        this.ThrExpIndex = iPt;
      }
      return this.ThrExpGraph.GraphPane.CurveList[0].Points[iPt].Y.ToString("0.00");
    }

    private void OilPrePanelInit()
    {
      double[] y = new double[11];
      double[] x = new double[11]
      {
        0.0,
        10.0,
        20.0,
        30.0,
        40.0,
        50.0,
        60.0,
        70.0,
        80.0,
        90.0,
        100.0
      };
      GraphPane graphPane = this.OilPreGraph.GraphPane;
      graphPane.Title.Text = "";
      graphPane.XAxis.Title.Text = "";
      graphPane.YAxis.Title.Text = "";
      graphPane.Chart.Fill = new Fill(Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 245), Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 190), 90f);
      graphPane.XAxis.Scale.Min = -1.0;
      graphPane.XAxis.Scale.Max = 101.0;
      graphPane.XAxis.MinSpace = 10f;
      graphPane.YAxis.Scale.Min = 0.0;
      graphPane.YAxis.Scale.Max = 100.0;
      graphPane.YAxis.MinSpace = 20f;
      graphPane.XAxis.MajorGrid.IsVisible = true;
      graphPane.YAxis.MajorGrid.IsVisible = true;
      graphPane.AddCurve("", x, y, Color.Red, SymbolType.Default).Symbol.Fill = new Fill(Color.Red);
      this.box3.ZOrder = ZOrder.F_BehindGrid;
      this.OilPreGraph.GraphPane.GraphObjList.Add((GraphObj) this.box3);
      this.panel3.Controls.Add((Control) this.OilPreGraph);
      this.OilPreGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(this.OilPreZedGraph_PointValueEvent);
      ((Control) this.OilPreGraph).MouseMove += new MouseEventHandler(this.OilPreZedGraph_MouseMove);
      this.OilPreGraph.AutoSize = true;
      this.OilPreGraph.IsShowContextMenu = false;
      this.OilPreGraph.IsEnableHPan = false;
      this.OilPreGraph.IsEnableVPan = false;
      this.OilPreGraph.IsEnableSelection = true;
      this.OilPreGraph.IsEnableZoom = false;
      this.OilPreGraph.IsShowPointValues = true;
      this.OilPreGraph.Dock = DockStyle.Fill;
      this.OilPreGraph.AxisChange();
      int num = 34;
      for (int index1 = 0; index1 <= 100; index1 += 10)
      {
        int index2 = num++;
        Common.cfg_value[index2] = new CfgValue(0.0f, false);
        Common.cfg_value[index2].Step = 1f;
        Common.cfg_value[index2].Min = 0.0f;
        Common.cfg_value[index2].Max = 100f;
        Common.cfg_value[index2].Name = "油压值（" + index1.ToString() + "%）";
        Common.cfg_value[index2].Name_CN = "油压值(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Name_CN_TW = "油壓值(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Name_EN = "Oil pressure(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Name_Save = "oil_pre(" + index1.ToString() + "%)";
        Common.cfg_value[index2].Index = index2;
        Common.cfg_value[index2].num = this.a++;
      }
    }

    private void OilPrePanelLoadZero()
    {
      for (int index = 0; index < this.pre_cfg_cnt; ++index)
      {
        Common.cfg_value[this.pre_cfg_begin + index].SetValue(0.0f);
        this.OilPreGraph.GraphPane.CurveList[0].Points[index].Y = 0.0;
      }
      this.OilPreGraph.GraphPane.CurveList[0].Color = Color.Red;
      this.OilPreGraph.Refresh();
    }

    private void OilPrePanelLoadDefault()
    {
      for (int index = 0; index < this.pre_cfg_cnt; ++index)
      {
        Common.cfg_value[this.pre_cfg_begin + index].SetValue(80f);
        this.OilPreGraph.GraphPane.CurveList[0].Points[index].Y = 80.0;
      }
      this.OilPreGraph.GraphPane.CurveList[0].Color = Color.Red;
      this.OilPreGraph.Refresh();
    }

    public void OilPrePanelLoadData(Color displayColor)
    {
      for (int index = 0; index < this.pre_cfg_cnt; ++index)
        this.OilPreGraph.GraphPane.CurveList[0].Points[index].Y = (double) Common.cfg_value[this.pre_cfg_begin + index].Value;
      this.OilPreGraph.GraphPane.CurveList[0].Color = displayColor;
      this.OilPreGraph.Refresh();
    }

    private void OilPreZedGraph_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this.OilPreMove)
        return;
      if (Control.MouseButtons == MouseButtons.Left)
      {
        double y;
        this.OilPreGraph.GraphPane.ReverseTransform(new PointF((float) e.X, (float) e.Y), out double _, out y);
        y = y > 100.0 ? 100.0 : (y < 0.0 ? 0.0 : y);
        double num = Math.Round(y, 0);
        Common.cfg_value[this.pre_cfg_begin + this.OilPreIndex].SetValue((float) num);
        this.OilPreGraph.GraphPane.CurveList[0].Points[this.OilPreIndex].Y = num;
        this.OilPreGraph.GraphPane.CurveList[0].Color = Color.Red;
        this.OilPreGraph.Refresh();
      }
      else
      {
        this.OilPreMove = false;
        this.Upload();
      }
    }

    private string OilPreZedGraph_PointValueEvent(
      ZedGraphControl sender,
      GraphPane pane,
      CurveItem curve,
      int iPt)
    {
      if (Control.MouseButtons == MouseButtons.Left && !this.OilPreMove)
      {
        this.OilPreMove = true;
        this.OilPreIndex = iPt;
      }
      return this.OilPreGraph.GraphPane.CurveList[0].Points[iPt].Y.ToString("0.00");
    }

    private void ConfigWindow_Load(object sender, EventArgs e) => this.panel_right.Controls.Add((Control) Common.CommandTool2);

    private void Timer_Tick_Show(object sender, EventArgs e)
    {
      T2_Content_Common data = C2_Content_Common.Data;
      if (this.box.Location.X != (double) data.yuliu0)
      {
        this.box.Location.X = (double) data.yuliu0;
        this.ThrOilGraph.Refresh();
      }
      if (this.box4.Location.X != (double) data.yuliu1)
      {
        this.box4.Location.X = (double) data.yuliu1;
        this.ThrOil2Graph.Refresh();
      }
      if (this.box3.Location.X != (double) data.svr_pwm)
      {
        this.box3.Location.X = (double) data.svr_pwm;
        this.OilPreGraph.Refresh();
      }
      if (this.box2.Location.X != (double) data.bus_thr)
      {
        this.box2.Location.X = (double) data.bus_thr;
        this.ThrExpGraph.Refresh();
      }
      for (int index = 0; index < this.oil1_cfg_cnt; ++index)
      {
        if ((double) Common.cfg_value[index + this.oil1_cfg_begin].Value != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOilGraph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y = (double) Common.cfg_value[this.oil1_cfg_begin + index].Value;
          this.ThrOilGraph.Refresh();
        }
      }
      for (int index = 0; index < this.oil2_cfg_cnt; ++index)
      {
        if ((double) Common.cfg_value[index + this.oil2_cfg_begin].Value != this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = (double) Common.cfg_value[this.oil2_cfg_begin + index].Value;
          this.ThrOil2Graph.Refresh();
        }
      }
      for (int index = 0; index < this.pre_cfg_cnt; ++index)
      {
        if ((double) Common.cfg_value[index + this.pre_cfg_begin].Value != this.OilPreGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.OilPreGraph.GraphPane.CurveList[0].Color = Color.Red;
          this.OilPreGraph.GraphPane.CurveList[0].Points[index].Y = (double) Common.cfg_value[this.pre_cfg_begin + index].Value;
          this.OilPreGraph.Refresh();
        }
      }
      for (int index = 0; index < this.exp_cfg_cnt; ++index)
      {
        if ((double) Common.cfg_value[index + this.exp_cfg_begin].Value != this.ThrExpGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrExpGraph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrExpGraph.GraphPane.CurveList[0].Points[index].Y = (double) Common.cfg_value[this.exp_cfg_begin + index].Value;
          this.ThrExpGraph.Refresh();
        }
      }
      this.UpdateMessageDisplay();
    }

    private void UpdateMessageDisplay()
    {
      T2_Content_Common data = C2_Content_Common.Data;
      switch (SetParameter.Language)
      {
        case "en-US":
          this.tb油压.Text = "Fuel Pre：" + ((float) Math.Round((double) data.pre_oil, 1)).ToString("F1").PadLeft(3);
          this.tb喷油脉宽1.Text = "INJ1：" + ((float) data.inj1_ms / 100f).ToString("F2").PadLeft(5) + "ms";
          this.tb喷油脉宽2.Text = "INJ2：" + ((float) data.inj2_ms / 100f).ToString("F2").PadLeft(5) + "ms";
          this.tb温度1.Text = "Temp1：" + data.tmp0.ToString("").PadLeft(4) + "℃";
          this.tb温度2.Text = "Temp2：" + data.tmp1.ToString("").PadLeft(4) + "℃";
          this.tb温度3.Text = "Temp3：" + data.tmp2.ToString("").PadLeft(4) + "℃";
          this.tb温度4.Text = "Temp4：" + data.tmp3.ToString("").PadLeft(4) + "℃";
          this.tb风门舵机.Text = "Servo：" + data.svr_pwm.ToString("").PadLeft(5) + "%";
          this.tb引擎转速1.Text = "RPM 1：" + data.rpm1.ToString("").PadLeft(5);
          this.tb引擎转速2.Text = "RPM 2：" + data.rpm2.ToString("").PadLeft(5);
          break;
        case "zh-TW":
          this.tb油压.Text = "油壓：" + ((float) Math.Round((double) data.pre_oil, 1)).ToString("F1").PadLeft(4) + "bar";
          this.tb喷油脉宽1.Text = "噴油1：" + ((float) data.inj1_ms / 100f).ToString("F2").PadLeft(1) + "ms";
          this.tb喷油脉宽2.Text = "噴油2：" + ((float) data.inj2_ms / 100f).ToString("F2").PadLeft(1) + "ms";
          this.tb温度1.Text = "溫度1：" + data.tmp0.ToString("").PadLeft(4) + "℃";
          this.tb温度2.Text = "溫度2：" + data.tmp1.ToString("").PadLeft(4) + "℃";
          this.tb温度3.Text = "溫度3：" + data.tmp2.ToString("").PadLeft(4) + "℃";
          this.tb温度4.Text = "溫度4：" + data.tmp3.ToString("").PadLeft(4) + "℃";
          this.tb风门舵机.Text = "風門：" + data.svr_pwm.ToString("").PadLeft(6) + "%";
          this.tb引擎转速1.Text = "轉速1：" + data.rpm1.ToString("").PadLeft(5) + "r";
          this.tb引擎转速2.Text = "轉速2：" + data.rpm2.ToString("").PadLeft(5) + "r";
          break;
        default:
          this.tb油压.Text = "油压：" + ((float) Math.Round((double) data.pre_oil, 1)).ToString("F1").PadLeft(4) + "bar";
          this.tb喷油脉宽1.Text = "喷油1：" + ((float) data.inj1_ms / 100f).ToString("F2").PadLeft(1) + "ms";
          this.tb喷油脉宽2.Text = "喷油2：" + ((float) data.inj2_ms / 100f).ToString("F2").PadLeft(1) + "ms";
          this.tb温度1.Text = "温度1：" + data.tmp0.ToString("").PadLeft(4) + "℃";
          this.tb温度2.Text = "温度2：" + data.tmp1.ToString("").PadLeft(4) + "℃";
          this.tb温度3.Text = "温度3：" + data.tmp2.ToString("").PadLeft(4) + "℃";
          this.tb温度4.Text = "温度4：" + data.tmp3.ToString("").PadLeft(4) + "℃";
          this.tb风门舵机.Text = "风门：" + data.svr_pwm.ToString("").PadLeft(6) + "%";
          this.tb引擎转速1.Text = "转速1：" + data.rpm1.ToString("").PadLeft(5) + "r";
          this.tb引擎转速2.Text = "转速2：" + data.rpm2.ToString("").PadLeft(5) + "r";
          break;
      }
    }

    private void Timer_Tick_Rec(object sender, EventArgs e)
    {
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      this.timer1.Stop();
      this.timer2.Stop();
      this.timer3.Stop();
      e.Cancel = true;
      this.Hide();
    }

    private void buttonUpload_Click(object sender, EventArgs e)
    {
      for (int index = 1; index <= 44; ++index)
      {
        if (Common.cfg_value[index].SignWrite && !Common.cfg_value[index].NeedRead)
          Common.cfg_value[index].WriteValueRequest();
      }
      this.timer3.Start();
      this.timer1.Start();
      this.timer2.Start();
    }

    private void Upload()
    {
      for (int index = 1; index <= 44; ++index)
      {
        if (Common.cfg_value[index].SignWrite && !Common.cfg_value[index].NeedRead)
          Common.cfg_value[index].WriteValueRequest();
      }
      this.timer1.Start();
      this.timer2.Start();
    }

    private void buttonDownload_Click(object sender, EventArgs e)
    {
      this.ThrOilPanelLoadZero();
      this.ThrOil2PanelLoadZero();
      this.ThrExpPanelLoadZero();
      this.OilPrePanelLoadZero();
      for (int index = 1; index <= 44; ++index)
      {
        if (Common.cfg_value[index].Index != 0)
          Common.cfg_value[index].ReadValueRequest();
      }
      this.timer1.Start();
      this.timer2.Start();
    }

    private void comboBoxOilSelectThr_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBoxOilSelectThr.SelectedIndex < 0)
        return;
      this.textBoxOilWhenThr.Text = Common.cfg_value[this.oil1_cfg_begin + this.comboBoxOilSelectThr.SelectedIndex].Value.ToString();
    }

    private void textBoxOilWhenThr_TextChanged(object sender, EventArgs e)
    {
      try
      {
        float single = Convert.ToSingle(this.textBoxOilWhenThr.Text);
        if ((double) single < 0.0 || (double) single > 10.0)
          this.textBoxOilWhenThr.BackColor = Color.Red;
        else
          this.textBoxOilWhenThr.BackColor = SystemColors.Window;
        if (this.comboBoxOilSelectThr.SelectedIndex < 0 || (double) single == (double) Common.cfg_value[this.oil1_cfg_begin + this.comboBoxOilSelectThr.SelectedIndex].Value)
          return;
        if (this.checkBox1.Checked && this.comboBoxOilSelectThr.SelectedIndex == 0 || this.checkBox2.Checked && this.comboBoxOilSelectThr.SelectedIndex == 1 || this.checkBox3.Checked && this.comboBoxOilSelectThr.SelectedIndex == 2 || this.checkBox4.Checked && this.comboBoxOilSelectThr.SelectedIndex == 3 || this.checkBox5.Checked && this.comboBoxOilSelectThr.SelectedIndex == 4 || this.checkBox6.Checked && this.comboBoxOilSelectThr.SelectedIndex == 5 || this.checkBox7.Checked && this.comboBoxOilSelectThr.SelectedIndex == 6 || this.checkBox8.Checked && this.comboBoxOilSelectThr.SelectedIndex == 7 || this.checkBox9.Checked && this.comboBoxOilSelectThr.SelectedIndex == 8 || this.checkBox10.Checked && this.comboBoxOilSelectThr.SelectedIndex == 9 || this.checkBox11.Checked && this.comboBoxOilSelectThr.SelectedIndex == 10)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[this.comboBoxOilSelectThr.SelectedIndex].Y = (double) single;
          Common.cfg_value[this.oil2_cfg_begin + this.comboBoxOilSelectThr.SelectedIndex].SetValue(single);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
        }
        this.ThrOilGraph.GraphPane.CurveList[0].Points[this.comboBoxOilSelectThr.SelectedIndex].Y = (double) single;
        Common.cfg_value[this.oil1_cfg_begin + this.comboBoxOilSelectThr.SelectedIndex].SetValue(single);
        this.ThrOilGraph.GraphPane.CurveList[0].Color = Color.Red;
        this.ThrOilGraph.Refresh();
      }
      catch
      {
        this.textBoxOilWhenThr.BackColor = Color.Red;
      }
    }

    private void comboBoxOilSelectThr2_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.comboBoxOilSelectThr2.SelectedIndex < 0)
        return;
      this.textBoxOilWhenThr2.Text = Common.cfg_value[this.oil2_cfg_begin + this.comboBoxOilSelectThr2.SelectedIndex].Value.ToString();
    }

    private void textBoxOilWhenThr2_TextChanged(object sender, EventArgs e)
    {
      try
      {
        float single = Convert.ToSingle(this.textBoxOilWhenThr2.Text);
        if ((double) single < 0.0 || (double) single > 10.0)
          this.textBoxOilWhenThr2.BackColor = Color.Red;
        else
          this.textBoxOilWhenThr2.BackColor = SystemColors.Window;
        if (this.comboBoxOilSelectThr2.SelectedIndex < 0 || (double) single == (double) Common.cfg_value[this.oil2_cfg_begin + this.comboBoxOilSelectThr2.SelectedIndex].Value)
          return;
        if (this.checkBox1.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 0 || this.checkBox2.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 1 || this.checkBox3.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 2 || this.checkBox4.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 3 || this.checkBox5.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 4 || this.checkBox6.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 5 || this.checkBox7.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 6 || this.checkBox8.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 7 || this.checkBox9.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 8 || this.checkBox10.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 9 || this.checkBox11.Checked && this.comboBoxOilSelectThr2.SelectedIndex == 10)
        {
          this.ThrOilGraph.GraphPane.CurveList[0].Points[this.comboBoxOilSelectThr2.SelectedIndex].Y = (double) single;
          Common.cfg_value[this.oil1_cfg_begin + this.comboBoxOilSelectThr2.SelectedIndex].SetValue(single);
          this.ThrOilGraph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOilGraph.Refresh();
        }
        this.ThrOil2Graph.GraphPane.CurveList[0].Points[this.comboBoxOilSelectThr2.SelectedIndex].Y = (double) single;
        Common.cfg_value[this.oil2_cfg_begin + this.comboBoxOilSelectThr2.SelectedIndex].SetValue(single);
        this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
        this.ThrOil2Graph.Refresh();
      }
      catch
      {
        this.textBoxOilWhenThr2.BackColor = Color.Red;
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.ThrExpPanelLoadDefault();
      this.Upload();
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      this.OilPrePanelLoadDefault();
      this.Upload();
    }

    public void change_language(string lng)
    {
      switch (lng)
      {
        case "zh-CN":
          for (int configBegin = this.config_begin; configBegin <= this.config_count; ++configBegin)
          {
            if (Common.cfg_value[configBegin].Name != null && Common.cfg_value[configBegin].Index != 0)
              Common.cfg_value[configBegin].Name = Common.cfg_value[configBegin].Name_CN;
          }
          break;
        case "zh-TW":
          for (int configBegin = this.config_begin; configBegin <= this.config_count; ++configBegin)
          {
            if (Common.cfg_value[configBegin].Name != null && Common.cfg_value[configBegin].Index != 0)
              Common.cfg_value[configBegin].Name = Common.cfg_value[configBegin].Name_CN_TW;
          }
          break;
        case "en-US":
          for (int configBegin = this.config_begin; configBegin <= this.config_count; ++configBegin)
          {
            if (Common.cfg_value[configBegin].Name != null && Common.cfg_value[configBegin].Index != 0)
              Common.cfg_value[configBegin].Name = Common.cfg_value[configBegin].Name_EN;
          }
          break;
      }
    }

    private void ConfigWindow_Layout(object sender, LayoutEventArgs e)
    {
      this.timer1.Start();
      this.timer2.Start();
      this.timer3.Start();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      int index = 0;
      if (this.checkBox1.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox1 = "true";
      }
      else
        SetParameter.ChkBox1 = "false";
    }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
      int index = 1;
      if (this.checkBox2.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox2 = "true";
      }
      else
        SetParameter.ChkBox2 = "false";
    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {
      int index = 2;
      if (this.checkBox3.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox3 = "true";
      }
      else
        SetParameter.ChkBox3 = "false";
    }

    private void checkBox4_CheckedChanged(object sender, EventArgs e)
    {
      int index = 3;
      if (this.checkBox4.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox4 = "true";
      }
      else
        SetParameter.ChkBox4 = "false";
    }

    private void checkBox5_CheckedChanged(object sender, EventArgs e)
    {
      int index = 4;
      if (this.checkBox5.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox5 = "true";
      }
      else
        SetParameter.ChkBox5 = "false";
    }

    private void checkBox6_CheckedChanged(object sender, EventArgs e)
    {
      int index = 5;
      if (this.checkBox6.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox6 = "true";
      }
      else
        SetParameter.ChkBox6 = "false";
    }

    private void checkBox7_CheckedChanged(object sender, EventArgs e)
    {
      int index = 6;
      if (this.checkBox7.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox7 = "true";
      }
      else
        SetParameter.ChkBox7 = "false";
    }

    private void checkBox8_CheckedChanged(object sender, EventArgs e)
    {
      int index = 7;
      if (this.checkBox8.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox8 = "true";
      }
      else
        SetParameter.ChkBox8 = "false";
    }

    private void checkBox9_CheckedChanged(object sender, EventArgs e)
    {
      int index = 8;
      if (this.checkBox9.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox9 = "true";
      }
      else
        SetParameter.ChkBox9 = "false";
    }

    private void checkBox10_CheckedChanged(object sender, EventArgs e)
    {
      int index = 9;
      if (this.checkBox10.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox10 = "true";
      }
      else
        SetParameter.ChkBox10 = "false";
    }

    private void checkBox11_CheckedChanged(object sender, EventArgs e)
    {
      int index = 10;
      if (this.checkBox11.Checked)
      {
        if (this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y != this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y)
        {
          this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y = this.ThrOilGraph.GraphPane.CurveList[0].Points[index].Y;
          Common.cfg_value[this.oil2_cfg_begin + index].SetValue((float) this.ThrOil2Graph.GraphPane.CurveList[0].Points[index].Y);
          this.ThrOil2Graph.GraphPane.CurveList[0].Color = Color.Red;
          this.ThrOil2Graph.Refresh();
          this.Upload();
        }
        SetParameter.ChkBox11 = "true";
      }
      else
        SetParameter.ChkBox11 = "false";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ConfigWindow));
      this.buttonUpload = new Button();
      this.buttonDownload = new Button();
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.comboBoxOilSelectThr = new ComboBox();
      this.textBoxOilWhenThr = new TextBox();
      this.button风门重置 = new Button();
      this.panel3 = new Panel();
      this.喷油曲线 = new GroupBox();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.btn_reset_oil_pre = new Button();
      this.panel_right = new Panel();
      this.tb引擎转速1 = new TextBox();
      this.tb引擎转速2 = new TextBox();
      this.tb喷油脉宽1 = new TextBox();
      this.tb温度4 = new TextBox();
      this.tb温度2 = new TextBox();
      this.tb油压 = new TextBox();
      this.tb喷油脉宽2 = new TextBox();
      this.tb温度1 = new TextBox();
      this.tb温度3 = new TextBox();
      this.tb风门舵机 = new TextBox();
      this.groupBox5 = new GroupBox();
      this.panel4 = new Panel();
      this.comboBoxOilSelectThr2 = new ComboBox();
      this.textBoxOilWhenThr2 = new TextBox();
      this.checkBox1 = new CheckBox();
      this.checkBox2 = new CheckBox();
      this.checkBox3 = new CheckBox();
      this.checkBox4 = new CheckBox();
      this.checkBox5 = new CheckBox();
      this.checkBox6 = new CheckBox();
      this.checkBox7 = new CheckBox();
      this.checkBox8 = new CheckBox();
      this.checkBox9 = new CheckBox();
      this.checkBox10 = new CheckBox();
      this.checkBox11 = new CheckBox();
      this.喷油曲线.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.panel_right.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonUpload, "buttonUpload");
      this.buttonUpload.Name = "buttonUpload";
      this.buttonUpload.UseVisualStyleBackColor = true;
      this.buttonUpload.Click += new EventHandler(this.buttonUpload_Click);
      componentResourceManager.ApplyResources((object) this.buttonDownload, "buttonDownload");
      this.buttonDownload.Name = "buttonDownload";
      this.buttonDownload.UseVisualStyleBackColor = true;
      this.buttonDownload.Click += new EventHandler(this.buttonDownload_Click);
      componentResourceManager.ApplyResources((object) this.panel1, "panel1");
      this.panel1.Name = "panel1";
      componentResourceManager.ApplyResources((object) this.panel2, "panel2");
      this.panel2.Name = "panel2";
      this.comboBoxOilSelectThr.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxOilSelectThr.FormattingEnabled = true;
      this.comboBoxOilSelectThr.Items.AddRange(new object[21]
      {
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items1"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items2"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items3"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items4"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items5"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items6"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items7"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items8"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items9"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items10"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items11"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items12"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items13"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items14"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items15"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items16"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items17"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items18"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items19"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr.Items20")
      });
      componentResourceManager.ApplyResources((object) this.comboBoxOilSelectThr, "comboBoxOilSelectThr");
      this.comboBoxOilSelectThr.Name = "comboBoxOilSelectThr";
      this.comboBoxOilSelectThr.SelectedIndexChanged += new EventHandler(this.comboBoxOilSelectThr_SelectedIndexChanged);
      componentResourceManager.ApplyResources((object) this.textBoxOilWhenThr, "textBoxOilWhenThr");
      this.textBoxOilWhenThr.Name = "textBoxOilWhenThr";
      this.textBoxOilWhenThr.TextChanged += new EventHandler(this.textBoxOilWhenThr_TextChanged);
      componentResourceManager.ApplyResources((object) this.button风门重置, "button风门重置");
      this.button风门重置.Name = "button风门重置";
      this.button风门重置.UseVisualStyleBackColor = true;
      this.button风门重置.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.panel3, "panel3");
      this.panel3.Name = "panel3";
      this.喷油曲线.Controls.Add((Control) this.panel1);
      this.喷油曲线.Controls.Add((Control) this.comboBoxOilSelectThr);
      this.喷油曲线.Controls.Add((Control) this.textBoxOilWhenThr);
      componentResourceManager.ApplyResources((object) this.喷油曲线, "喷油曲线");
      this.喷油曲线.Name = "喷油曲线";
      this.喷油曲线.TabStop = false;
      this.groupBox1.Controls.Add((Control) this.panel2);
      this.groupBox1.Controls.Add((Control) this.button风门重置);
      componentResourceManager.ApplyResources((object) this.groupBox1, "groupBox1");
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      this.groupBox2.Controls.Add((Control) this.btn_reset_oil_pre);
      this.groupBox2.Controls.Add((Control) this.panel3);
      componentResourceManager.ApplyResources((object) this.groupBox2, "groupBox2");
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.TabStop = false;
      componentResourceManager.ApplyResources((object) this.btn_reset_oil_pre, "btn_reset_oil_pre");
      this.btn_reset_oil_pre.Name = "btn_reset_oil_pre";
      this.btn_reset_oil_pre.UseVisualStyleBackColor = true;
      this.btn_reset_oil_pre.Click += new EventHandler(this.button1_Click_1);
      this.panel_right.BackColor = SystemColors.ControlDark;
      this.panel_right.Controls.Add((Control) this.tb引擎转速1);
      this.panel_right.Controls.Add((Control) this.tb引擎转速2);
      this.panel_right.Controls.Add((Control) this.buttonUpload);
      this.panel_right.Controls.Add((Control) this.tb喷油脉宽1);
      this.panel_right.Controls.Add((Control) this.buttonDownload);
      this.panel_right.Controls.Add((Control) this.tb温度4);
      this.panel_right.Controls.Add((Control) this.tb温度2);
      this.panel_right.Controls.Add((Control) this.tb油压);
      this.panel_right.Controls.Add((Control) this.tb喷油脉宽2);
      this.panel_right.Controls.Add((Control) this.tb温度1);
      this.panel_right.Controls.Add((Control) this.tb温度3);
      this.panel_right.Controls.Add((Control) this.tb风门舵机);
      componentResourceManager.ApplyResources((object) this.panel_right, "panel_right");
      this.panel_right.Name = "panel_right";
      this.tb引擎转速1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.tb引擎转速1, "tb引擎转速1");
      this.tb引擎转速1.Name = "tb引擎转速1";
      this.tb引擎转速1.ReadOnly = true;
      this.tb引擎转速2.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.tb引擎转速2, "tb引擎转速2");
      this.tb引擎转速2.Name = "tb引擎转速2";
      this.tb引擎转速2.ReadOnly = true;
      this.tb喷油脉宽1.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb喷油脉宽1, "tb喷油脉宽1");
      this.tb喷油脉宽1.Name = "tb喷油脉宽1";
      this.tb喷油脉宽1.ReadOnly = true;
      this.tb温度4.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度4, "tb温度4");
      this.tb温度4.Name = "tb温度4";
      this.tb温度4.ReadOnly = true;
      this.tb温度2.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度2, "tb温度2");
      this.tb温度2.Name = "tb温度2";
      this.tb温度2.ReadOnly = true;
      this.tb油压.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb油压, "tb油压");
      this.tb油压.Name = "tb油压";
      this.tb油压.ReadOnly = true;
      this.tb喷油脉宽2.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb喷油脉宽2, "tb喷油脉宽2");
      this.tb喷油脉宽2.Name = "tb喷油脉宽2";
      this.tb喷油脉宽2.ReadOnly = true;
      this.tb温度1.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度1, "tb温度1");
      this.tb温度1.Name = "tb温度1";
      this.tb温度1.ReadOnly = true;
      this.tb温度3.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度3, "tb温度3");
      this.tb温度3.Name = "tb温度3";
      this.tb温度3.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.tb风门舵机, "tb风门舵机");
      this.tb风门舵机.Name = "tb风门舵机";
      this.tb风门舵机.ReadOnly = true;
      this.groupBox5.Controls.Add((Control) this.panel4);
      this.groupBox5.Controls.Add((Control) this.comboBoxOilSelectThr2);
      this.groupBox5.Controls.Add((Control) this.textBoxOilWhenThr2);
      componentResourceManager.ApplyResources((object) this.groupBox5, "groupBox5");
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.TabStop = false;
      componentResourceManager.ApplyResources((object) this.panel4, "panel4");
      this.panel4.Name = "panel4";
      this.comboBoxOilSelectThr2.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxOilSelectThr2.FormattingEnabled = true;
      this.comboBoxOilSelectThr2.Items.AddRange(new object[21]
      {
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items1"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items2"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items3"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items4"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items5"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items6"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items7"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items8"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items9"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items10"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items11"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items12"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items13"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items14"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items15"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items16"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items17"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items18"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items19"),
        (object) componentResourceManager.GetString("comboBoxOilSelectThr2.Items20")
      });
      componentResourceManager.ApplyResources((object) this.comboBoxOilSelectThr2, "comboBoxOilSelectThr2");
      this.comboBoxOilSelectThr2.Name = "comboBoxOilSelectThr2";
      this.comboBoxOilSelectThr2.SelectedIndexChanged += new EventHandler(this.comboBoxOilSelectThr2_SelectedIndexChanged);
      componentResourceManager.ApplyResources((object) this.textBoxOilWhenThr2, "textBoxOilWhenThr2");
      this.textBoxOilWhenThr2.Name = "textBoxOilWhenThr2";
      this.textBoxOilWhenThr2.TextChanged += new EventHandler(this.textBoxOilWhenThr2_TextChanged);
      componentResourceManager.ApplyResources((object) this.checkBox1, "checkBox1");
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox2, "checkBox2");
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.UseVisualStyleBackColor = true;
      this.checkBox2.CheckedChanged += new EventHandler(this.checkBox2_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox3, "checkBox3");
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.CheckedChanged += new EventHandler(this.checkBox3_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox4, "checkBox4");
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.UseVisualStyleBackColor = true;
      this.checkBox4.CheckedChanged += new EventHandler(this.checkBox4_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox5, "checkBox5");
      this.checkBox5.Name = "checkBox5";
      this.checkBox5.UseVisualStyleBackColor = true;
      this.checkBox5.CheckedChanged += new EventHandler(this.checkBox5_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox6, "checkBox6");
      this.checkBox6.Name = "checkBox6";
      this.checkBox6.UseVisualStyleBackColor = true;
      this.checkBox6.CheckedChanged += new EventHandler(this.checkBox6_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox7, "checkBox7");
      this.checkBox7.Name = "checkBox7";
      this.checkBox7.UseVisualStyleBackColor = true;
      this.checkBox7.CheckedChanged += new EventHandler(this.checkBox7_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox8, "checkBox8");
      this.checkBox8.Name = "checkBox8";
      this.checkBox8.UseVisualStyleBackColor = true;
      this.checkBox8.CheckedChanged += new EventHandler(this.checkBox8_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox9, "checkBox9");
      this.checkBox9.Name = "checkBox9";
      this.checkBox9.UseVisualStyleBackColor = true;
      this.checkBox9.CheckedChanged += new EventHandler(this.checkBox9_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox10, "checkBox10");
      this.checkBox10.Name = "checkBox10";
      this.checkBox10.UseVisualStyleBackColor = true;
      this.checkBox10.CheckedChanged += new EventHandler(this.checkBox10_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBox11, "checkBox11");
      this.checkBox11.Name = "checkBox11";
      this.checkBox11.UseVisualStyleBackColor = true;
      this.checkBox11.CheckedChanged += new EventHandler(this.checkBox11_CheckedChanged);
      this.AcceptButton = (IButtonControl) this.buttonUpload;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.checkBox11);
      this.Controls.Add((Control) this.checkBox10);
      this.Controls.Add((Control) this.checkBox9);
      this.Controls.Add((Control) this.checkBox8);
      this.Controls.Add((Control) this.checkBox7);
      this.Controls.Add((Control) this.checkBox6);
      this.Controls.Add((Control) this.checkBox5);
      this.Controls.Add((Control) this.checkBox4);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.groupBox5);
      this.Controls.Add((Control) this.panel_right);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.喷油曲线);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ConfigWindow);
      this.ShowInTaskbar = false;
      this.Load += new EventHandler(this.ConfigWindow_Load);
      this.Layout += new LayoutEventHandler(this.ConfigWindow_Layout);
      this.喷油曲线.ResumeLayout(false);
      this.喷油曲线.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.panel_right.ResumeLayout(false);
      this.panel_right.PerformLayout();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
