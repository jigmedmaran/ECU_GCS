// Decompiled with JetBrains decompiler
// Type: ECU_GCS.AdcCalib
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ECU_GCS
{
  public class AdcCalib : Form
  {
    private bool adj_cmd_sta = false;
    private byte sendCommandType = 0;
    private object sendCommandObj;
    private DateTime sendCommandDateTime = DateTime.Now;
    private IContainer components = (IContainer) null;
    private Button btn_adc1_min;
    private Button btn_adc1_max;
    private Button btn_adc2_min;
    private Button btn_adc2_max;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Button btn_svr;

    public AdcCalib() => this.InitializeComponent();

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (this.sendCommandType <= (byte) 0)
        return;
      int num = 500;
      if (DateTime.Now.Subtract(this.sendCommandDateTime).TotalMilliseconds < (double) num)
      {
        if (C18_Content_Command.RecTime > this.sendCommandDateTime)
        {
          if (C18_Content_Command.Data.cmd == (byte) 0)
          {
            if (this.sendCommandObj is Button)
              ((Control) this.sendCommandObj).BackColor = Color.Red;
          }
          else if (this.sendCommandObj is Button)
            ((Control) this.sendCommandObj).BackColor = Color.Green;
          this.sendCommandType = (byte) 0;
          this.sendCommandObj = (object) null;
        }
        else if (this.sendCommandObj is Button)
          ((Control) this.sendCommandObj).BackColor = Color.Blue;
      }
      else if (this.sendCommandType > (byte) 0)
      {
        if (this.sendCommandObj is Button)
          ((Control) this.sendCommandObj).BackColor = Color.Yellow;
        this.sendCommandType = (byte) 0;
        this.sendCommandObj = (object) null;
      }
    }

    private void Timer_Tick_Rec(object sender, EventArgs e)
    {
      T2_Content_Common data = C2_Content_Common.Data;
      if (((int) data.sta >> 3 & 1) == 1 && !this.adj_cmd_sta)
      {
        this.btn_svr.BackColor = Color.Lime;
        this.adj_cmd_sta = true;
      }
      if (((int) data.sta >> 3 & 1) == 0 && this.adj_cmd_sta)
      {
        this.btn_svr.BackColor = Color.Gray;
        this.adj_cmd_sta = false;
      }
      if (((int) data.sta >> 4 & 1) != 0)
        return;
      this.btn_svr.BackColor = Color.Red;
    }

    private void SendCommandContent(byte cmd, uint value)
    {
      this.sendCommandType = cmd;
      this.sendCommandDateTime = DateTime.Now;
      byte[] bytes = Agreement_Helper.StructToBytes((object) new T18_Content_Command()
      {
        header0 = (byte) 181,
        header1 = (byte) 98,
        source = (byte) 195,
        target = (byte) 161,
        type = C18_Content_Command.Type,
        num = (byte) C18_Content_Command.Length,
        id = Common.Agreement.SendId,
        ack = (byte) 80,
        cmd = cmd,
        content = value,
        chk0 = (byte) 0,
        chk1 = (byte) 0,
        end0 = (byte) 13,
        end1 = (byte) 10
      });
      for (int index = 0; index < bytes.Length - 4; ++index)
      {
        bytes[bytes.Length - 4] ^= bytes[index];
        bytes[bytes.Length - 3] ^= bytes[bytes.Length - 4];
      }
      Common.SerialManager.SendData(bytes);
    }

    private void AdcCalib_Load(object sender, EventArgs e)
    {
      Timer timer1 = new Timer();
      timer1.Interval = 10;
      timer1.Tick += new EventHandler(this.Timer_Tick_Rec);
      timer1.Start();
      Timer timer2 = new Timer();
      timer2.Interval = 10;
      timer2.Tick += new EventHandler(this.Timer_Tick);
      timer2.Start();
    }

    private void btn_adc1_min_Click(object sender, EventArgs e)
    {
      MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
      switch (SetParameter.Language)
      {
        case "en-US":
          if (MessageBox.Show("Please confirm that the sensor1 is in the lowest position?", "Sensor 1 Calibration", buttons) == DialogResult.OK)
          {
            this.SendCommandContent((byte) 10, 1U);
            break;
          }
          break;
        case "zh-TW":
          if (MessageBox.Show("請確認感測器1位於最低位置？", "感測器1校準", buttons) == DialogResult.OK)
          {
            this.SendCommandContent((byte) 10, 1U);
            break;
          }
          break;
        default:
          if (MessageBox.Show("请确认传感器1位于最低位置?", "传感器1校准", buttons) == DialogResult.OK)
            this.SendCommandContent((byte) 10, 1U);
          break;
      }
      this.sendCommandObj = sender;
    }

    private void btn_adc1_max_Click(object sender, EventArgs e)
    {
      MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
      switch (SetParameter.Language)
      {
        case "en-US":
          if (MessageBox.Show("Please confirm that sensor 1 is in the highest position?", "Sensor 1 Calibration", buttons) == DialogResult.OK)
          {
            this.SendCommandContent((byte) 10, 2U);
            break;
          }
          break;
        case "zh-TW":
          if (MessageBox.Show("請確認感測器1位於最高位置？", "感測器1校準", buttons) == DialogResult.OK)
          {
            this.SendCommandContent((byte) 10, 2U);
            break;
          }
          break;
        default:
          if (MessageBox.Show("请确认传感器1位于最高位置?", "传感器1校准", buttons) == DialogResult.OK)
            this.SendCommandContent((byte) 10, 2U);
          break;
      }
      this.sendCommandObj = sender;
    }

    private void btn_adc2_min_Click(object sender, EventArgs e)
    {
      MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
      switch (SetParameter.Language)
      {
        case "en-US":
          if (MessageBox.Show("Please confirm that the sensor2 is in the lowest position?", "Sensor 2 Calibration", buttons) == DialogResult.OK)
          {
            this.SendCommandContent((byte) 10, 3U);
            break;
          }
          break;
        case "zh-TW":
          if (MessageBox.Show("請確認感測器2位於最低位置？", "感測器2校準", buttons) == DialogResult.OK)
          {
            this.SendCommandContent((byte) 10, 3U);
            break;
          }
          break;
        default:
          if (MessageBox.Show("请确认传感器2位于最低位置?", "传感器2校准", buttons) == DialogResult.OK)
            this.SendCommandContent((byte) 10, 3U);
          break;
      }
      this.sendCommandObj = sender;
    }

    private void btn_adc2_max_Click(object sender, EventArgs e)
    {
      MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
      switch (SetParameter.Language)
      {
        case "en-US":
          if (MessageBox.Show("Please confirm that sensor 2 is in the highest position?", "Sensor 2 Calibration", buttons) == DialogResult.OK)
          {
            this.SendCommandContent((byte) 10, 4U);
            break;
          }
          break;
        case "zh-TW":
          if (MessageBox.Show("請確認感測器2位於最高位置？", "感測器2校準", buttons) == DialogResult.OK)
          {
            this.SendCommandContent((byte) 10, 4U);
            break;
          }
          break;
        default:
          if (MessageBox.Show("请确认传感器2位于最高位置?", "传感器2校准", buttons) == DialogResult.OK)
            this.SendCommandContent((byte) 10, 4U);
          break;
      }
      this.sendCommandObj = sender;
    }

    private void btn_svr_Click(object sender, EventArgs e)
    {
      if (!this.adj_cmd_sta)
        this.SendCommandContent((byte) 10, 5U);
      else
        this.SendCommandContent((byte) 10, 6U);
      this.sendCommandObj = sender;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AdcCalib));
      this.btn_adc1_min = new Button();
      this.btn_adc1_max = new Button();
      this.btn_adc2_min = new Button();
      this.btn_adc2_max = new Button();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.btn_svr = new Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.btn_adc1_min, "btn_adc1_min");
      this.btn_adc1_min.Name = "btn_adc1_min";
      this.btn_adc1_min.UseVisualStyleBackColor = true;
      this.btn_adc1_min.Click += new EventHandler(this.btn_adc1_min_Click);
      componentResourceManager.ApplyResources((object) this.btn_adc1_max, "btn_adc1_max");
      this.btn_adc1_max.Name = "btn_adc1_max";
      this.btn_adc1_max.UseVisualStyleBackColor = true;
      this.btn_adc1_max.Click += new EventHandler(this.btn_adc1_max_Click);
      componentResourceManager.ApplyResources((object) this.btn_adc2_min, "btn_adc2_min");
      this.btn_adc2_min.Name = "btn_adc2_min";
      this.btn_adc2_min.UseVisualStyleBackColor = true;
      this.btn_adc2_min.Click += new EventHandler(this.btn_adc2_min_Click);
      componentResourceManager.ApplyResources((object) this.btn_adc2_max, "btn_adc2_max");
      this.btn_adc2_max.Name = "btn_adc2_max";
      this.btn_adc2_max.UseVisualStyleBackColor = true;
      this.btn_adc2_max.Click += new EventHandler(this.btn_adc2_max_Click);
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      this.groupBox1.Controls.Add((Control) this.btn_adc1_min);
      this.groupBox1.Controls.Add((Control) this.btn_adc1_max);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.label2);
      componentResourceManager.ApplyResources((object) this.groupBox1, "groupBox1");
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      this.groupBox2.Controls.Add((Control) this.btn_adc2_min);
      this.groupBox2.Controls.Add((Control) this.btn_adc2_max);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.label3);
      componentResourceManager.ApplyResources((object) this.groupBox2, "groupBox2");
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.TabStop = false;
      componentResourceManager.ApplyResources((object) this.btn_svr, "btn_svr");
      this.btn_svr.Name = "btn_svr";
      this.btn_svr.UseVisualStyleBackColor = true;
      this.btn_svr.Click += new EventHandler(this.btn_svr_Click);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.btn_svr);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.Name = nameof (AdcCalib);
      this.TopMost = true;
      this.Load += new EventHandler(this.AdcCalib_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
