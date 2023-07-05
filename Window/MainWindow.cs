// Decompiled with JetBrains decompiler
// Type: ECU_GCS.MainWindow
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using ECU_GCS.Window;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace ECU_GCS
{
  public class MainWindow : Form
  {
    private float rpm_show;
    private float oil_per_show;
    private IContainer components = (IContainer) null;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private Panel panelUp;
    private Panel panelMessage;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem toolStripMenuItemCom;
    private ToolStripMenuItem toolStripMenuItemData;
    private ToolStripMenuItem 参数ToolStripMenuItem;
    private UCMeter ucMeter1;
    private UCThermometer ucThermometer1;
    private UCThermometer ucThermometer4;
    private UCThermometer ucThermometer3;
    private UCThermometer ucThermometer2;
    private UCMeter ucMeter2;
    private ToolStripMenuItem 回放ToolStripMenuItem;
    private ToolStripStatusLabel toolStripStatusLabel2;
    private StatusStrip statusStrip1;
    private ToolStripMenuItem 状态ToolStripMenuItem;
    private ToolStripMenuItem 喷嘴校准ToolStripMenuItem;
    private Panel panel2;
    private ToolStripMenuItem 语言ToolStripMenuItem;
    private ToolStripMenuItem 英文ToolStripMenuItem;
    private ToolStripMenuItem 中文简体ToolStripMenuItem;
    private ToolStripMenuItem 中文繁体ToolStripMenuItem;
    private Panel panel_right;
    private Panel panel_left;
    private ToolStripMenuItem 传感器校准ToolStripMenuItem;
    private ToolStripMenuItem 基准配置ToolStripMenuItem;
    private ToolStripMenuItem 参数调整ToolStripMenuItem;
    private ToolStripMenuItem 导出配置ToolStripMenuItem;
    private ToolStripMenuItem 导入配置ToolStripMenuItem;
    private UCThermometer ucThermometer6;
    private UCThermometer ucThermometer5;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private ToolStripMenuItem 油压测试ToolStripMenuItem;

    public MainWindow()
    {
      SetParameter.Load();
      Thread.CurrentThread.CurrentUICulture = new CultureInfo(SetParameter.Language);
      this.InitializeComponent();
      this.UpdateLanguage();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
      this.TimerStart();
      Common.Agreement.InitSendID();
      Common.SpeakWarningMessage.Start();
      this.panel_left.Controls.Add((Control) Common.MessageTool);
      this.panel_right.Controls.Add((Control) Common.CommandTool);
    }

    private void TimerStart()
    {
      System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      timer.Interval = 10;
      timer.Tick += new EventHandler(this.Timer_Tick);
      timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (Common.SerialManager.GetPortState())
        this.toolStripMenuItemCom.BackColor = Color.Blue;
      else
        this.toolStripMenuItemCom.BackColor = Color.Red;
      this.toolStripMenuItemCom.Text = Common.SerialManager.GetPortName();
      TimeSpan timeSpan = DateTime.Now.Subtract(Common.Agreement.RecTime);
      if (timeSpan.TotalMilliseconds < 50.0)
      {
        this.toolStripMenuItemData.BackColor = Color.Blue;
      }
      else
      {
        timeSpan = DateTime.Now.Subtract(Common.Agreement.RecTime);
        if (timeSpan.TotalMilliseconds < 1000.0)
          this.toolStripMenuItemData.BackColor = Color.Gray;
        else
          this.toolStripMenuItemData.BackColor = Color.Red;
      }
      string str1 = ((IEnumerable<string>) Directory.GetCurrentDirectory().Split('\\')).Last<string>();
      DateTime now = DateTime.Now;
      string str2 = now.ToString("yyyy_MMdd_HHmm_ss_fff");
      this.Text = str1 + " " + str2;
      this.toolStripStatusLabel2.Text = Common.StatusStr;
      T2_Content_Common data = C2_Content_Common.Data;
      now = DateTime.Now;
      timeSpan = now.Subtract(Common.Agreement.RecTime);
      if (timeSpan.TotalMilliseconds < 100.0)
      {
        if (((int) data.sta >> 5 & 1) == 0)
        {
          switch (SetParameter.Language)
          {
            case "en-US":
              Common.StatusStr = "Advance";
              break;
            case "zh-TW":
              Common.StatusStr = "Advance";
              break;
            default:
              Common.StatusStr = "Advance";
              break;
          }
        }
        else
        {
          switch (SetParameter.Language)
          {
            case "en-US":
              Common.StatusStr = "Hardware version error";
              break;
            case "zh-TW":
              Common.StatusStr = "硬體版本錯誤！";
              break;
            default:
              Common.StatusStr = "硬件版本错误！";
              break;
          }
          Common.SerialManager.SerialPortClose();
        }
      }
      this.rpm_show = (float) ((double) this.rpm_show * 0.89999997615814209 + 0.10000000149011612 * (double) data.rpm_out);
      this.oil_per_show = data.pre_oil;
      this.ucMeter1.Value = (float) Math.Round((double) this.rpm_show / 1000.0, 3);
      this.ucMeter2.Value = (float) Math.Round((double) this.oil_per_show, 1);
      this.ucThermometer1.Value = (float) data.tmp0;
      this.ucThermometer2.Value = (float) data.tmp1;
      this.ucThermometer3.Value = (float) data.tmp2;
      this.ucThermometer4.Value = (float) data.tmp3;
      this.ucThermometer5.Value = (float) data.tmp4;
      this.ucThermometer6.Value = (float) data.tmp5;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      Common.SerialManager.SerialPortClose();
      base.OnFormClosing(e);
    }

    private void 参数ToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void 回放ToolStripMenuItem_Click(object sender, EventArgs e) => Common.DataReplayTool.Show();

    private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
    }

    private void 状态ToolStripMenuItem_Click(object sender, EventArgs e) => Common.StateTool.Show();

    private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) => Common.SerialManager.SerialPortClose();

    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) => Common.SerialManager.SerialPortClose();

    private void 喷嘴校准ToolStripMenuItem_Click_1(object sender, EventArgs e) => Common.JetCalibTool.Show();

    private void UpdateLanguage()
    {
      Common.ConfigTool.change_language(SetParameter.Language);
      this.ApplyResource(new ComponentResourceManager(typeof (ConfigWindow)), (Control) Common.ConfigTool);
      this.ApplyResource(new ComponentResourceManager(typeof (MainWindow)), (Control) this);
      this.ApplyResource(new ComponentResourceManager(typeof (MessageControl)), (Control) Common.MessageTool);
      ComponentResourceManager res = new ComponentResourceManager(typeof (CommandControl));
      this.ApplyResource(res, (Control) Common.CommandTool);
      this.ApplyResource(res, (Control) Common.CommandTool2);
      this.ApplyResource(new ComponentResourceManager(typeof (DataReplayWindow)), (Control) Common.DataReplayTool);
      this.ApplyResource(new ComponentResourceManager(typeof (StateWindow)), (Control) Common.StateTool);
      this.ApplyResource(new ComponentResourceManager(typeof (AdcCalib)), (Control) Common.AdcCalibTool);
      this.ApplyResource(new ComponentResourceManager(typeof (JetCalib)), (Control) Common.JetCalibTool);
      this.ApplyResource(new ComponentResourceManager(typeof (Cfg_Base)), (Control) Common.Cfg_BaseTool);
      this.ApplyResource(new ComponentResourceManager(typeof (FuelPreTest)), (Control) Common.FuelPreTestTool);
    }

    private void ApplyResource(ComponentResourceManager res, Control frm)
    {
      try
      {
        foreach (Control control in (ArrangedElementCollection) frm.Controls)
        {
          res.ApplyResources((object) control, control.Name);
          switch (control)
          {
            case DataGridView _:
              IEnumerator enumerator1 = ((DataGridView) control).Columns.GetEnumerator();
              try
              {
                while (enumerator1.MoveNext())
                {
                  DataGridViewColumn current = (DataGridViewColumn) enumerator1.Current;
                  res.ApplyResources((object) current, current.Name);
                }
                break;
              }
              finally
              {
                if (enumerator1 is IDisposable disposable)
                  disposable.Dispose();
              }
            case MenuStrip _:
              IEnumerator enumerator2 = ((ToolStrip) control).Items.GetEnumerator();
              try
              {
                while (enumerator2.MoveNext())
                {
                  ToolStripMenuItem current = (ToolStripMenuItem) enumerator2.Current;
                  res.ApplyResources((object) current, current.Name);
                  foreach (ToolStripMenuItem dropDownItem1 in (ArrangedElementCollection) current.DropDownItems)
                  {
                    res.ApplyResources((object) dropDownItem1, dropDownItem1.Name);
                    foreach (ToolStripMenuItem dropDownItem2 in (ArrangedElementCollection) dropDownItem1.DropDownItems)
                      res.ApplyResources((object) dropDownItem2, dropDownItem2.Name);
                  }
                }
                break;
              }
              finally
              {
                if (enumerator2 is IDisposable disposable)
                  disposable.Dispose();
              }
            case ToolStrip _:
              IEnumerator enumerator3 = (control as ToolStrip).Items.GetEnumerator();
              try
              {
                while (enumerator3.MoveNext())
                {
                  ToolStripItem current = (ToolStripItem) enumerator3.Current;
                  res.ApplyResources((object) current, current.Name);
                }
                break;
              }
              finally
              {
                if (enumerator3 is IDisposable disposable)
                  disposable.Dispose();
              }
          }
          if (control is Panel || control is PictureBox || control is GroupBox || control is TabControl || control is TabPage || control is SplitContainer)
            this.ApplyResource(res, control);
        }
      }
      catch
      {
      }
    }

    private void 中文繁体ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-TW");
      SetParameter.Language = "zh-TW";
      this.UpdateLanguage();
      SetParameter.Save();
    }

    private void 英文ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
      SetParameter.Language = "en-US";
      SetParameter.Save();
      this.UpdateLanguage();
    }

    private void 中文简体ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
      SetParameter.Language = "zh-CN";
      this.UpdateLanguage();
      SetParameter.Save();
    }

    private void 中文繁体ToolStripMenuItem_Click_1(object sender, EventArgs e)
    {
      Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-TW");
      SetParameter.Language = "zh-TW";
      this.UpdateLanguage();
      SetParameter.Save();
    }

    private bool ImportConfig(string fileName)
    {
      if (!File.Exists(fileName))
        return false;
      try
      {
        foreach (string readAllLine in File.ReadAllLines(fileName))
        {
          char[] chArray = new char[1]{ '\t' };
          string[] strArray = readAllLine.Split(chArray);
          if (strArray.Length == 2)
          {
            for (int index = 1; index <= 102; ++index)
            {
              if (strArray[0] == Common.cfg_value[index].Name_Save)
              {
                if (Common.cfg_value[index].Name_Save != "" && Common.cfg_value[index].Index != 0)
                {
                  Common.cfg_value[index].SetValue(Convert.ToSingle(strArray[1]));
                  break;
                }
                break;
              }
            }
          }
        }
        return true;
      }
      catch
      {
        return false;
      }
    }

    private void ExportConfig(string fileName)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 1; index <= 102; ++index)
      {
        if (Common.cfg_value[index].Name_Save != null && Common.cfg_value[index].Index != 0)
          stringBuilder.AppendLine(Common.cfg_value[index].Name_Save + "\t" + Common.cfg_value[index].Value.ToString("0.00"));
      }
      File.WriteAllText(fileName, stringBuilder.ToString());
    }

    private void 传感器校准ToolStripMenuItem_Click(object sender, EventArgs e) => Common.AdcCalibTool.Show();

    private void 基准配置ToolStripMenuItem_Click(object sender, EventArgs e) => Common.Cfg_BaseTool.Show();

    private void 参数调整ToolStripMenuItem_Click(object sender, EventArgs e) => Common.ConfigTool.Show();

    private void panelMessage_Paint(object sender, PaintEventArgs e)
    {
    }

    private bool cfg_val_data_over()
    {
      for (int index1 = 0; index1 < 102; ++index1)
      {
        for (int index2 = 0; index2 <= 102; ++index2)
        {
          if (index1 == Common.cfg_value[index2].num && Common.cfg_value[index2].Name_Save != null && Common.cfg_value[index2].Index != 0 && (Common.cfg_value[index2].NeedWrite || Common.cfg_value[index2].NeedRead))
            return false;
        }
      }
      return true;
    }

    private void 导出配置ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.cfg_val_data_over())
      {
        switch (SetParameter.Language)
        {
          case "en-US":
            int num1 = (int) MessageBox.Show("Please wait for all data to be read");
            break;
          case "zh-TW":
            int num2 = (int) MessageBox.Show("請等待數據全部讀取完成");
            break;
          default:
            int num3 = (int) MessageBox.Show("请等待数据全部读取完成");
            break;
        }
      }
      else
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.FileName = DateTime.Now.ToString("yyyy_MMdd_HHmm") + "_ECU_F.config";
        saveFileDialog.Filter = "(*.config)|*.config";
        saveFileDialog.RestoreDirectory = true;
        if (saveFileDialog.ShowDialog() != DialogResult.OK)
          return;
        try
        {
          this.ExportConfig(saveFileDialog.FileName);
        }
        catch
        {
          int num4 = (int) MessageBox.Show(saveFileDialog.FileName + "\r\n导出失败");
        }
      }
    }

    private void 导入配置ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.Filter = "(*.config)|*.config";
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() != DialogResult.OK || this.ImportConfig(openFileDialog.FileName))
          return;
        int num = (int) MessageBox.Show(openFileDialog.FileName + "\r\n打开失败");
      }
    }

    private void 油压测试ToolStripMenuItem_Click(object sender, EventArgs e) => Common.FuelPreTestTool.Show();

    private void 极限设置ToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainWindow));
      this.toolStripStatusLabel1 = new ToolStripStatusLabel();
      this.panelUp = new Panel();
      this.menuStrip1 = new MenuStrip();
      this.toolStripMenuItemCom = new ToolStripMenuItem();
      this.toolStripMenuItemData = new ToolStripMenuItem();
      this.参数ToolStripMenuItem = new ToolStripMenuItem();
      this.基准配置ToolStripMenuItem = new ToolStripMenuItem();
      this.参数调整ToolStripMenuItem = new ToolStripMenuItem();
      this.导出配置ToolStripMenuItem = new ToolStripMenuItem();
      this.导入配置ToolStripMenuItem = new ToolStripMenuItem();
      this.回放ToolStripMenuItem = new ToolStripMenuItem();
      this.状态ToolStripMenuItem = new ToolStripMenuItem();
      this.喷嘴校准ToolStripMenuItem = new ToolStripMenuItem();
      this.传感器校准ToolStripMenuItem = new ToolStripMenuItem();
      this.油压测试ToolStripMenuItem = new ToolStripMenuItem();
      this.语言ToolStripMenuItem = new ToolStripMenuItem();
      this.英文ToolStripMenuItem = new ToolStripMenuItem();
      this.中文简体ToolStripMenuItem = new ToolStripMenuItem();
      this.中文繁体ToolStripMenuItem = new ToolStripMenuItem();
      this.panelMessage = new Panel();
      this.panel_right = new Panel();
      this.panel_left = new Panel();
      this.panel2 = new Panel();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.ucMeter2 = new UCMeter();
      this.ucMeter1 = new UCMeter();
      this.ucThermometer6 = new UCThermometer();
      this.ucThermometer5 = new UCThermometer();
      this.ucThermometer4 = new UCThermometer();
      this.ucThermometer3 = new UCThermometer();
      this.ucThermometer2 = new UCThermometer();
      this.ucThermometer1 = new UCThermometer();
      this.toolStripStatusLabel2 = new ToolStripStatusLabel();
      this.statusStrip1 = new StatusStrip();
      this.panelUp.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.panelMessage.SuspendLayout();
      this.panel2.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      this.toolStripStatusLabel1.ForeColor = Color.Red;
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      componentResourceManager.ApplyResources((object) this.toolStripStatusLabel1, "toolStripStatusLabel1");
      this.panelUp.Controls.Add((Control) this.menuStrip1);
      componentResourceManager.ApplyResources((object) this.panelUp, "panelUp");
      this.panelUp.Name = "panelUp";
      this.menuStrip1.BackColor = SystemColors.ActiveBorder;
      componentResourceManager.ApplyResources((object) this.menuStrip1, "menuStrip1");
      this.menuStrip1.GripStyle = ToolStripGripStyle.Visible;
      this.menuStrip1.ImageScalingSize = new Size(20, 20);
      this.menuStrip1.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.toolStripMenuItemCom,
        (ToolStripItem) this.toolStripMenuItemData,
        (ToolStripItem) this.参数ToolStripMenuItem,
        (ToolStripItem) this.回放ToolStripMenuItem,
        (ToolStripItem) this.状态ToolStripMenuItem,
        (ToolStripItem) this.喷嘴校准ToolStripMenuItem,
        (ToolStripItem) this.传感器校准ToolStripMenuItem,
        (ToolStripItem) this.油压测试ToolStripMenuItem,
        (ToolStripItem) this.语言ToolStripMenuItem
      });
      this.menuStrip1.Name = "menuStrip1";
      componentResourceManager.ApplyResources((object) this.toolStripMenuItemCom, "toolStripMenuItemCom");
      this.toolStripMenuItemCom.Name = "toolStripMenuItemCom";
      componentResourceManager.ApplyResources((object) this.toolStripMenuItemData, "toolStripMenuItemData");
      this.toolStripMenuItemData.Name = "toolStripMenuItemData";
      this.参数ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.基准配置ToolStripMenuItem,
        (ToolStripItem) this.参数调整ToolStripMenuItem,
        (ToolStripItem) this.导出配置ToolStripMenuItem,
        (ToolStripItem) this.导入配置ToolStripMenuItem
      });
      componentResourceManager.ApplyResources((object) this.参数ToolStripMenuItem, "参数ToolStripMenuItem");
      this.参数ToolStripMenuItem.Name = "参数ToolStripMenuItem";
      this.参数ToolStripMenuItem.Click += new EventHandler(this.参数ToolStripMenuItem_Click);
      this.基准配置ToolStripMenuItem.Name = "基准配置ToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.基准配置ToolStripMenuItem, "基准配置ToolStripMenuItem");
      this.基准配置ToolStripMenuItem.Click += new EventHandler(this.基准配置ToolStripMenuItem_Click);
      this.参数调整ToolStripMenuItem.Name = "参数调整ToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.参数调整ToolStripMenuItem, "参数调整ToolStripMenuItem");
      this.参数调整ToolStripMenuItem.Click += new EventHandler(this.参数调整ToolStripMenuItem_Click);
      this.导出配置ToolStripMenuItem.Name = "导出配置ToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.导出配置ToolStripMenuItem, "导出配置ToolStripMenuItem");
      this.导出配置ToolStripMenuItem.Click += new EventHandler(this.导出配置ToolStripMenuItem_Click);
      this.导入配置ToolStripMenuItem.Name = "导入配置ToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.导入配置ToolStripMenuItem, "导入配置ToolStripMenuItem");
      this.导入配置ToolStripMenuItem.Click += new EventHandler(this.导入配置ToolStripMenuItem_Click);
      componentResourceManager.ApplyResources((object) this.回放ToolStripMenuItem, "回放ToolStripMenuItem");
      this.回放ToolStripMenuItem.Name = "回放ToolStripMenuItem";
      this.回放ToolStripMenuItem.Click += new EventHandler(this.回放ToolStripMenuItem_Click);
      componentResourceManager.ApplyResources((object) this.状态ToolStripMenuItem, "状态ToolStripMenuItem");
      this.状态ToolStripMenuItem.Name = "状态ToolStripMenuItem";
      this.状态ToolStripMenuItem.Click += new EventHandler(this.状态ToolStripMenuItem_Click);
      componentResourceManager.ApplyResources((object) this.喷嘴校准ToolStripMenuItem, "喷嘴校准ToolStripMenuItem");
      this.喷嘴校准ToolStripMenuItem.Name = "喷嘴校准ToolStripMenuItem";
      this.喷嘴校准ToolStripMenuItem.Click += new EventHandler(this.喷嘴校准ToolStripMenuItem_Click_1);
      componentResourceManager.ApplyResources((object) this.传感器校准ToolStripMenuItem, "传感器校准ToolStripMenuItem");
      this.传感器校准ToolStripMenuItem.Name = "传感器校准ToolStripMenuItem";
      this.传感器校准ToolStripMenuItem.Click += new EventHandler(this.传感器校准ToolStripMenuItem_Click);
      componentResourceManager.ApplyResources((object) this.油压测试ToolStripMenuItem, "油压测试ToolStripMenuItem");
      this.油压测试ToolStripMenuItem.Name = "油压测试ToolStripMenuItem";
      this.油压测试ToolStripMenuItem.Click += new EventHandler(this.油压测试ToolStripMenuItem_Click);
      this.语言ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.英文ToolStripMenuItem,
        (ToolStripItem) this.中文简体ToolStripMenuItem,
        (ToolStripItem) this.中文繁体ToolStripMenuItem
      });
      componentResourceManager.ApplyResources((object) this.语言ToolStripMenuItem, "语言ToolStripMenuItem");
      this.语言ToolStripMenuItem.Name = "语言ToolStripMenuItem";
      this.英文ToolStripMenuItem.Name = "英文ToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.英文ToolStripMenuItem, "英文ToolStripMenuItem");
      this.英文ToolStripMenuItem.Click += new EventHandler(this.英文ToolStripMenuItem_Click);
      this.中文简体ToolStripMenuItem.Name = "中文简体ToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.中文简体ToolStripMenuItem, "中文简体ToolStripMenuItem");
      this.中文简体ToolStripMenuItem.Click += new EventHandler(this.中文简体ToolStripMenuItem_Click);
      this.中文繁体ToolStripMenuItem.Name = "中文繁体ToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.中文繁体ToolStripMenuItem, "中文繁体ToolStripMenuItem");
      this.中文繁体ToolStripMenuItem.Click += new EventHandler(this.中文繁体ToolStripMenuItem_Click_1);
      this.panelMessage.Controls.Add((Control) this.panel_right);
      this.panelMessage.Controls.Add((Control) this.panel_left);
      this.panelMessage.Controls.Add((Control) this.panel2);
      componentResourceManager.ApplyResources((object) this.panelMessage, "panelMessage");
      this.panelMessage.Name = "panelMessage";
      componentResourceManager.ApplyResources((object) this.panel_right, "panel_right");
      this.panel_right.Name = "panel_right";
      componentResourceManager.ApplyResources((object) this.panel_left, "panel_left");
      this.panel_left.Name = "panel_left";
      this.panel2.BackColor = Color.Gray;
      this.panel2.Controls.Add((Control) this.label6);
      this.panel2.Controls.Add((Control) this.label5);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.ucMeter2);
      this.panel2.Controls.Add((Control) this.ucMeter1);
      this.panel2.Controls.Add((Control) this.ucThermometer6);
      this.panel2.Controls.Add((Control) this.ucThermometer5);
      this.panel2.Controls.Add((Control) this.ucThermometer4);
      this.panel2.Controls.Add((Control) this.ucThermometer3);
      this.panel2.Controls.Add((Control) this.ucThermometer2);
      this.panel2.Controls.Add((Control) this.ucThermometer1);
      componentResourceManager.ApplyResources((object) this.panel2, "panel2");
      this.panel2.Name = "panel2";
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.ucMeter2, "ucMeter2");
      this.ucMeter2.BoundaryLineColor = Color.Black;
      this.ucMeter2.ExternalRoundColor = Color.Black;
      this.ucMeter2.FacValue = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.ucMeter2.FixedText = "";
      this.ucMeter2.FixedText2 = "";
      this.ucMeter2.InsideRoundColor = SystemColors.ButtonFace;
      this.ucMeter2.MaxValue = new Decimal(new int[4]
      {
        4,
        0,
        0,
        0
      });
      this.ucMeter2.MeterDegrees = 240;
      this.ucMeter2.MinValue = new Decimal(new int[4]);
      this.ucMeter2.Name = "ucMeter2";
      this.ucMeter2.PointerColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
      this.ucMeter2.ScaleColor = Color.White;
      this.ucMeter2.ScaleValueColor = Color.White;
      this.ucMeter2.SplitCount = 4;
      this.ucMeter2.TextColor = Color.White;
      this.ucMeter2.TextFont = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 134);
      this.ucMeter2.TextLocation = MeterTextLocation.Bottom;
      this.ucMeter2.Value = 0.0f;
      componentResourceManager.ApplyResources((object) this.ucMeter1, "ucMeter1");
      this.ucMeter1.BoundaryLineColor = Color.Black;
      this.ucMeter1.ExternalRoundColor = Color.Black;
      this.ucMeter1.FacValue = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.ucMeter1.FixedText = "";
      this.ucMeter1.FixedText2 = "x1000";
      this.ucMeter1.InsideRoundColor = SystemColors.ButtonFace;
      this.ucMeter1.MaxValue = new Decimal(new int[4]
      {
        8,
        0,
        0,
        0
      });
      this.ucMeter1.MeterDegrees = 240;
      this.ucMeter1.MidText = "RPM";
      this.ucMeter1.MinValue = new Decimal(new int[4]);
      this.ucMeter1.Name = "ucMeter1";
      this.ucMeter1.PointerColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
      this.ucMeter1.ScaleColor = Color.White;
      this.ucMeter1.ScaleValueColor = Color.White;
      this.ucMeter1.SplitCount = 8;
      this.ucMeter1.TextColor = Color.White;
      this.ucMeter1.TextFont = new Font("微软雅黑", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 134);
      this.ucMeter1.TextLocation = MeterTextLocation.Bottom;
      this.ucMeter1.Value = 0.0f;
      this.ucThermometer6.GlassTubeColor = Color.FromArgb(211, 211, 211);
      this.ucThermometer6.LeftTemperatureUnit = TemperatureUnit.C;
      componentResourceManager.ApplyResources((object) this.ucThermometer6, "ucThermometer6");
      this.ucThermometer6.MaxValue = new Decimal(new int[4]
      {
        800,
        0,
        0,
        0
      });
      this.ucThermometer6.MercuryColor = Color.Red;
      this.ucThermometer6.MinValue = new Decimal(new int[4]);
      this.ucThermometer6.Name = "ucThermometer6";
      this.ucThermometer6.RightTemperatureUnit = TemperatureUnit.None;
      this.ucThermometer6.SplitCount = 5;
      this.ucThermometer6.Value = 0.0f;
      this.ucThermometer5.GlassTubeColor = Color.FromArgb(211, 211, 211);
      this.ucThermometer5.LeftTemperatureUnit = TemperatureUnit.C;
      componentResourceManager.ApplyResources((object) this.ucThermometer5, "ucThermometer5");
      this.ucThermometer5.MaxValue = new Decimal(new int[4]
      {
        800,
        0,
        0,
        0
      });
      this.ucThermometer5.MercuryColor = Color.Red;
      this.ucThermometer5.MinValue = new Decimal(new int[4]);
      this.ucThermometer5.Name = "ucThermometer5";
      this.ucThermometer5.RightTemperatureUnit = TemperatureUnit.None;
      this.ucThermometer5.SplitCount = 5;
      this.ucThermometer5.Value = 0.0f;
      this.ucThermometer4.GlassTubeColor = Color.FromArgb(211, 211, 211);
      this.ucThermometer4.LeftTemperatureUnit = TemperatureUnit.C;
      componentResourceManager.ApplyResources((object) this.ucThermometer4, "ucThermometer4");
      this.ucThermometer4.MaxValue = new Decimal(new int[4]
      {
        250,
        0,
        0,
        0
      });
      this.ucThermometer4.MercuryColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
      this.ucThermometer4.MinValue = new Decimal(new int[4]);
      this.ucThermometer4.Name = "ucThermometer4";
      this.ucThermometer4.RightTemperatureUnit = TemperatureUnit.None;
      this.ucThermometer4.SplitCount = 5;
      this.ucThermometer4.Value = 0.0f;
      this.ucThermometer3.GlassTubeColor = Color.FromArgb(211, 211, 211);
      this.ucThermometer3.LeftTemperatureUnit = TemperatureUnit.C;
      componentResourceManager.ApplyResources((object) this.ucThermometer3, "ucThermometer3");
      this.ucThermometer3.MaxValue = new Decimal(new int[4]
      {
        250,
        0,
        0,
        0
      });
      this.ucThermometer3.MercuryColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
      this.ucThermometer3.MinValue = new Decimal(new int[4]);
      this.ucThermometer3.Name = "ucThermometer3";
      this.ucThermometer3.RightTemperatureUnit = TemperatureUnit.None;
      this.ucThermometer3.SplitCount = 5;
      this.ucThermometer3.Value = 0.0f;
      this.ucThermometer2.GlassTubeColor = Color.FromArgb(211, 211, 211);
      this.ucThermometer2.LeftTemperatureUnit = TemperatureUnit.C;
      componentResourceManager.ApplyResources((object) this.ucThermometer2, "ucThermometer2");
      this.ucThermometer2.MaxValue = new Decimal(new int[4]
      {
        250,
        0,
        0,
        0
      });
      this.ucThermometer2.MercuryColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
      this.ucThermometer2.MinValue = new Decimal(new int[4]);
      this.ucThermometer2.Name = "ucThermometer2";
      this.ucThermometer2.RightTemperatureUnit = TemperatureUnit.None;
      this.ucThermometer2.SplitCount = 5;
      this.ucThermometer2.Value = 0.0f;
      this.ucThermometer1.ForeColor = SystemColors.ControlText;
      this.ucThermometer1.GlassTubeColor = Color.FromArgb(211, 211, 211);
      this.ucThermometer1.LeftTemperatureUnit = TemperatureUnit.C;
      componentResourceManager.ApplyResources((object) this.ucThermometer1, "ucThermometer1");
      this.ucThermometer1.MaxValue = new Decimal(new int[4]
      {
        250,
        0,
        0,
        0
      });
      this.ucThermometer1.MercuryColor = Color.FromArgb((int) byte.MaxValue, 77, 59);
      this.ucThermometer1.MinValue = new Decimal(new int[4]);
      this.ucThermometer1.Name = "ucThermometer1";
      this.ucThermometer1.RightTemperatureUnit = TemperatureUnit.None;
      this.ucThermometer1.SplitCount = 5;
      this.ucThermometer1.Value = 0.0f;
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      componentResourceManager.ApplyResources((object) this.toolStripStatusLabel2, "toolStripStatusLabel2");
      this.statusStrip1.ImageScalingSize = new Size(20, 20);
      this.statusStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripStatusLabel2
      });
      componentResourceManager.ApplyResources((object) this.statusStrip1, "statusStrip1");
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.ItemClicked += new ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.panelMessage);
      this.Controls.Add((Control) this.panelUp);
      this.Controls.Add((Control) this.statusStrip1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.Name = nameof (MainWindow);
      this.FormClosing += new FormClosingEventHandler(this.MainWindow_FormClosing);
      this.FormClosed += new FormClosedEventHandler(this.MainWindow_FormClosed);
      this.Load += new EventHandler(this.MainWindow_Load);
      this.panelUp.ResumeLayout(false);
      this.panelUp.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.panelMessage.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
