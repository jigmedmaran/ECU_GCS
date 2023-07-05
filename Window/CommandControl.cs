// Decompiled with JetBrains decompiler
// Type: ECU_GCS.CommandControl
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ECU_GCS
{
  public class CommandControl : UserControl
  {
    private bool cdi1_sta;
    private bool cdi2_sta;
    private bool pump_sta;
    private bool hot_car_sta;
    private int thr_ctrl = 0;
    private byte sendCommandType = 0;
    private object sendCommandObj;
    private DateTime sendCommandDateTime = DateTime.Now;
    private IContainer components = (IContainer) null;
    private Button button喷油;
    private TrackBar trackBarImportThr;
    private Label labelImportThr;
    private Button button熄火;
    private Button buttonCDI1;
    private Button button油泵;
    private Button buttonCDI2;
    private GroupBox 控制;
    private Label label3;
    private Button button_down;
    private Button button_up;
    private Button button启动;

    public CommandControl() => this.InitializeComponent();

    private void CommandControl_Load(object sender, EventArgs e)
    {
      Timer timer = new Timer();
      timer.Interval = 10;
      timer.Tick += new EventHandler(this.Timer_Tick_Rec);
      timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (this.sendCommandType <= (byte) 0)
        return;
      int num = 300;
      if (DateTime.Now.Subtract(this.sendCommandDateTime).TotalMilliseconds < (double) num)
      {
        if (C18_Content_Command.RecTime > this.sendCommandDateTime)
        {
          if (C18_Content_Command.Data.cmd == (byte) 0)
          {
            if (!(this.sendCommandObj is Button))
              ;
          }
          else if (!(this.sendCommandObj is Button))
            ;
          this.sendCommandType = (byte) 0;
          this.sendCommandObj = (object) null;
        }
        else if (!(this.sendCommandObj is Button))
          ;
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
      if (sys_data_c.thr_value != this.trackBarImportThr.Value)
      {
        this.trackBarImportThr.Value = sys_data_c.thr_value;
        this.labelImportThr.Text = this.trackBarImportThr.Value.ToString() + "%";
      }
      T2_Content_Common data = C2_Content_Common.Data;
      if (((int) data.sta & 1) == 1 && !this.cdi1_sta)
      {
        this.buttonCDI1.BackColor = Color.Lime;
        this.cdi1_sta = true;
      }
      if (((int) data.sta & 1) == 0 && this.cdi1_sta)
      {
        this.buttonCDI1.BackColor = Color.Gray;
        this.cdi1_sta = false;
      }
      if (((int) data.sta >> 1 & 1) == 1 && !this.cdi2_sta)
      {
        this.buttonCDI2.BackColor = Color.Lime;
        this.cdi2_sta = true;
      }
      if (((int) data.sta >> 1 & 1) == 0 && this.cdi2_sta)
      {
        this.buttonCDI2.BackColor = Color.Gray;
        this.cdi2_sta = false;
      }
      if (((int) data.sta >> 2 & 1) == 1 && !this.pump_sta)
      {
        this.button油泵.BackColor = Color.Lime;
        this.pump_sta = true;
      }
      if (((int) data.sta >> 2 & 1) == 0 && this.pump_sta)
      {
        this.button油泵.BackColor = Color.Gray;
        this.pump_sta = false;
      }
      if (((int) data.sta >> 7 & 1) == 1 && !this.hot_car_sta)
      {
        this.button喷油.BackColor = Color.Lime;
        this.hot_car_sta = true;
      }
      if (((int) data.sta >> 7 & 1) != 0 || !this.hot_car_sta)
        return;
      this.button喷油.BackColor = Color.Gray;
      this.hot_car_sta = false;
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

    private void button启动喷油_Click(object sender, EventArgs e)
    {
      this.SendCommandContent((byte) 5, 1U);
      this.sendCommandObj = sender;
    }

    private void trackBarImportThr_Scroll(object sender, EventArgs e)
    {
      this.labelImportThr.Text = this.trackBarImportThr.Value.ToString() + "%";
      sys_data_c.thr_value = this.trackBarImportThr.Value;
      this.SendCommandContent((byte) 6, (uint) (this.trackBarImportThr.Value * 10));
    }

    private void trackBarImportThr_MouseUp(object sender, MouseEventArgs e)
    {
      sys_data_c.thr_value = this.trackBarImportThr.Value;
      this.SendCommandContent((byte) 6, (uint) (this.trackBarImportThr.Value * 10));
    }

    private void button熄火停车_Click(object sender, EventArgs e)
    {
      this.SendCommandContent((byte) 4, 0U);
      this.sendCommandObj = sender;
    }

    private void button_up_Click(object sender, EventArgs e)
    {
      this.thr_ctrl = this.trackBarImportThr.Value;
      this.thr_ctrl += 10;
      if (this.thr_ctrl < this.trackBarImportThr.Maximum)
      {
        this.trackBarImportThr.Value = this.thr_ctrl;
      }
      else
      {
        this.trackBarImportThr.Value = this.trackBarImportThr.Maximum;
        this.thr_ctrl = this.trackBarImportThr.Value;
      }
      sys_data_c.thr_value = this.trackBarImportThr.Value;
      this.labelImportThr.Text = this.trackBarImportThr.Value.ToString() + "%";
      this.SendCommandContent((byte) 6, (uint) (this.trackBarImportThr.Value * 10));
    }

    private void button_down_Click(object sender, EventArgs e)
    {
      this.thr_ctrl = this.trackBarImportThr.Value;
      this.thr_ctrl -= 10;
      if (this.thr_ctrl > this.trackBarImportThr.Minimum)
      {
        this.trackBarImportThr.Value = this.thr_ctrl;
      }
      else
      {
        this.trackBarImportThr.Value = this.trackBarImportThr.Minimum;
        this.thr_ctrl = this.trackBarImportThr.Value;
      }
      sys_data_c.thr_value = this.trackBarImportThr.Value;
      this.labelImportThr.Text = this.trackBarImportThr.Value.ToString() + "%";
      this.SendCommandContent((byte) 6, (uint) (this.trackBarImportThr.Value * 10));
    }

    private void buttonCDI1_Click(object sender, EventArgs e)
    {
      if (this.cdi1_sta)
        this.SendCommandContent((byte) 1, 0U);
      else
        this.SendCommandContent((byte) 1, 1U);
    }

    private void buttonCDI2_Click(object sender, EventArgs e)
    {
      if (this.cdi2_sta)
        this.SendCommandContent((byte) 2, 0U);
      else
        this.SendCommandContent((byte) 2, 1U);
    }

    private void button油泵_Click(object sender, EventArgs e)
    {
      if (this.pump_sta)
        this.SendCommandContent((byte) 3, 0U);
      else
        this.SendCommandContent((byte) 3, 1U);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CommandControl));
      this.button喷油 = new Button();
      this.trackBarImportThr = new TrackBar();
      this.labelImportThr = new Label();
      this.button熄火 = new Button();
      this.buttonCDI1 = new Button();
      this.button油泵 = new Button();
      this.buttonCDI2 = new Button();
      this.控制 = new GroupBox();
      this.button_down = new Button();
      this.button_up = new Button();
      this.label3 = new Label();
      this.button启动 = new Button();
      this.trackBarImportThr.BeginInit();
      this.控制.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.button喷油, "button喷油");
      this.button喷油.Name = "button喷油";
      this.button喷油.UseVisualStyleBackColor = true;
      this.button喷油.Click += new EventHandler(this.button启动喷油_Click);
      componentResourceManager.ApplyResources((object) this.trackBarImportThr, "trackBarImportThr");
      this.trackBarImportThr.LargeChange = 10;
      this.trackBarImportThr.Maximum = 100;
      this.trackBarImportThr.Name = "trackBarImportThr";
      this.trackBarImportThr.TickFrequency = 10;
      this.trackBarImportThr.Scroll += new EventHandler(this.trackBarImportThr_Scroll);
      this.trackBarImportThr.MouseUp += new MouseEventHandler(this.trackBarImportThr_MouseUp);
      componentResourceManager.ApplyResources((object) this.labelImportThr, "labelImportThr");
      this.labelImportThr.Name = "labelImportThr";
      componentResourceManager.ApplyResources((object) this.button熄火, "button熄火");
      this.button熄火.Name = "button熄火";
      this.button熄火.UseVisualStyleBackColor = true;
      this.button熄火.Click += new EventHandler(this.button熄火停车_Click);
      componentResourceManager.ApplyResources((object) this.buttonCDI1, "buttonCDI1");
      this.buttonCDI1.Name = "buttonCDI1";
      this.buttonCDI1.UseVisualStyleBackColor = true;
      this.buttonCDI1.Click += new EventHandler(this.buttonCDI1_Click);
      componentResourceManager.ApplyResources((object) this.button油泵, "button油泵");
      this.button油泵.Name = "button油泵";
      this.button油泵.UseVisualStyleBackColor = true;
      this.button油泵.Click += new EventHandler(this.button油泵_Click);
      componentResourceManager.ApplyResources((object) this.buttonCDI2, "buttonCDI2");
      this.buttonCDI2.Name = "buttonCDI2";
      this.buttonCDI2.UseVisualStyleBackColor = true;
      this.buttonCDI2.Click += new EventHandler(this.buttonCDI2_Click);
      componentResourceManager.ApplyResources((object) this.控制, "控制");
      this.控制.Controls.Add((Control) this.button_down);
      this.控制.Controls.Add((Control) this.button_up);
      this.控制.Controls.Add((Control) this.label3);
      this.控制.Controls.Add((Control) this.buttonCDI1);
      this.控制.Controls.Add((Control) this.labelImportThr);
      this.控制.Controls.Add((Control) this.button喷油);
      this.控制.Controls.Add((Control) this.button启动);
      this.控制.Controls.Add((Control) this.button熄火);
      this.控制.Controls.Add((Control) this.button油泵);
      this.控制.Controls.Add((Control) this.trackBarImportThr);
      this.控制.Controls.Add((Control) this.buttonCDI2);
      this.控制.Name = "控制";
      this.控制.TabStop = false;
      componentResourceManager.ApplyResources((object) this.button_down, "button_down");
      this.button_down.Name = "button_down";
      this.button_down.UseVisualStyleBackColor = true;
      this.button_down.Click += new EventHandler(this.button_down_Click);
      componentResourceManager.ApplyResources((object) this.button_up, "button_up");
      this.button_up.Name = "button_up";
      this.button_up.UseVisualStyleBackColor = true;
      this.button_up.Click += new EventHandler(this.button_up_Click);
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.button启动, "button启动");
      this.button启动.Name = "button启动";
      this.button启动.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ControlDark;
      this.Controls.Add((Control) this.控制);
      this.Name = nameof (CommandControl);
      this.Load += new EventHandler(this.CommandControl_Load);
      this.trackBarImportThr.EndInit();
      this.控制.ResumeLayout(false);
      this.控制.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
