// Decompiled with JetBrains decompiler
// Type: ECU_GCS.StateWindow
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ECU_GCS
{
  public class StateWindow : Form
  {
    private Timer timer = new Timer();
    private object sendCommandObj = (object) null;
    private uint sendCommandCount = 0;
    private IContainer components = (IContainer) null;
    private Button buttonDownload;
    private TextBox textBox固件版本;
    private TextBox textBox硬件ID;
    private TextBox textBoxECU运行总时长;
    private TextBox textBox引擎运行总时长;
    private TextBox textBox引擎运转总次数;
    private TextBox textBox异常断电次数;
    private Label label1;
    private Label label2;
    private Label labelECU运行总时长;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label3;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private TextBox textBox剩余保养时间;
    private Label label12;
    private TextBox textBoxVer;

    public StateWindow() => this.InitializeComponent();

    private void StateWindow_Load(object sender, EventArgs e)
    {
      this.timer.Interval = 200;
      this.timer.Tick += new EventHandler(this.Timer_Tick);
      this.timer.Start();
      this.buttonDownload.PerformClick();
      this.textBoxVer.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\n";
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (this.sendCommandObj == null)
        return;
      int num1 = 2000;
      if (this.sendCommandCount < 10U)
      {
        this.SendStateRequest();
        ++this.sendCommandCount;
        if (DateTime.Now.Subtract(C6_Content_State.RecTime).TotalMilliseconds < (double) num1)
        {
          this.textBox固件版本.Text = "V" + C6_Content_State.Data.fcu_fw.ToString("");
          this.textBox固件版本.BackColor = SystemColors.Window;
          this.textBox硬件ID.Text = C6_Content_State.Data.fcu_id.ToString("");
          this.textBox硬件ID.BackColor = SystemColors.Window;
          this.textBoxECU运行总时长.Text = ((float) C6_Content_State.Data.ecu_run_sec / 3600f).ToString("F2");
          this.textBoxECU运行总时长.BackColor = SystemColors.Window;
          TextBox textBox引擎运行总时长 = this.textBox引擎运行总时长;
          float num2 = (float) C6_Content_State.Data.eng_run_sec / 3600f;
          string str1 = num2.ToString("F2");
          textBox引擎运行总时长.Text = str1;
          this.textBox引擎运行总时长.BackColor = SystemColors.Window;
          TextBox textBox引擎运转总次数 = this.textBox引擎运转总次数;
          num2 = (float) C6_Content_State.Data.eng_run_cnt / 10000f;
          string str2 = num2.ToString("F2");
          textBox引擎运转总次数.Text = str2;
          this.textBox引擎运转总次数.BackColor = SystemColors.Window;
          this.textBox异常断电次数.Text = C6_Content_State.Data.blackout_cnt.ToString("");
          this.textBox异常断电次数.BackColor = SystemColors.Window;
          this.textBox剩余保养时间.Text = C6_Content_State.Data.maintain_hor.ToString("F2");
          this.textBox剩余保养时间.BackColor = SystemColors.Window;
          ((Control) this.sendCommandObj).BackColor = SystemColors.Control;
          this.sendCommandObj = (object) null;
        }
      }
      else
      {
        ((Control) this.sendCommandObj).BackColor = Color.Red;
        this.sendCommandObj = (object) null;
      }
    }

    private void SendStateRequest()
    {
      byte[] bytes = Agreement_Helper.StructToBytes((object) new T5_Request_State()
      {
        header0 = (byte) 181,
        header1 = (byte) 98,
        source = (byte) 195,
        target = (byte) 161,
        type = C5_Request_State.Type,
        num = (byte) C5_Request_State.Length,
        id = Common.Agreement.SendId,
        ack = (byte) 32,
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

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      base.OnVisibleChanged(e);
      if (!this.Visible)
        return;
      this.buttonDownload.PerformClick();
    }

    private void buttonDownload_Click(object sender, EventArgs e)
    {
      this.sendCommandObj = sender;
      this.sendCommandCount = 0U;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (StateWindow));
      this.buttonDownload = new Button();
      this.textBox固件版本 = new TextBox();
      this.textBox硬件ID = new TextBox();
      this.textBoxECU运行总时长 = new TextBox();
      this.textBox引擎运行总时长 = new TextBox();
      this.textBox引擎运转总次数 = new TextBox();
      this.textBox异常断电次数 = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.labelECU运行总时长 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label3 = new Label();
      this.label7 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.textBox剩余保养时间 = new TextBox();
      this.label12 = new Label();
      this.textBoxVer = new TextBox();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonDownload, "buttonDownload");
      this.buttonDownload.Name = "buttonDownload";
      this.buttonDownload.UseVisualStyleBackColor = true;
      this.buttonDownload.Click += new EventHandler(this.buttonDownload_Click);
      componentResourceManager.ApplyResources((object) this.textBox固件版本, "textBox固件版本");
      this.textBox固件版本.Name = "textBox固件版本";
      componentResourceManager.ApplyResources((object) this.textBox硬件ID, "textBox硬件ID");
      this.textBox硬件ID.Name = "textBox硬件ID";
      componentResourceManager.ApplyResources((object) this.textBoxECU运行总时长, "textBoxECU运行总时长");
      this.textBoxECU运行总时长.Name = "textBoxECU运行总时长";
      componentResourceManager.ApplyResources((object) this.textBox引擎运行总时长, "textBox引擎运行总时长");
      this.textBox引擎运行总时长.Name = "textBox引擎运行总时长";
      componentResourceManager.ApplyResources((object) this.textBox引擎运转总次数, "textBox引擎运转总次数");
      this.textBox引擎运转总次数.Name = "textBox引擎运转总次数";
      componentResourceManager.ApplyResources((object) this.textBox异常断电次数, "textBox异常断电次数");
      this.textBox异常断电次数.Name = "textBox异常断电次数";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.labelECU运行总时长, "labelECU运行总时长");
      this.labelECU运行总时长.Name = "labelECU运行总时长";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.label7, "label7");
      this.label7.Name = "label7";
      componentResourceManager.ApplyResources((object) this.label8, "label8");
      this.label8.Name = "label8";
      componentResourceManager.ApplyResources((object) this.label9, "label9");
      this.label9.Name = "label9";
      componentResourceManager.ApplyResources((object) this.label10, "label10");
      this.label10.Name = "label10";
      componentResourceManager.ApplyResources((object) this.label11, "label11");
      this.label11.Name = "label11";
      componentResourceManager.ApplyResources((object) this.textBox剩余保养时间, "textBox剩余保养时间");
      this.textBox剩余保养时间.Name = "textBox剩余保养时间";
      componentResourceManager.ApplyResources((object) this.label12, "label12");
      this.label12.Name = "label12";
      componentResourceManager.ApplyResources((object) this.textBoxVer, "textBoxVer");
      this.textBoxVer.Name = "textBoxVer";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.textBoxVer);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.textBox剩余保养时间);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.labelECU运行总时长);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textBox异常断电次数);
      this.Controls.Add((Control) this.textBox引擎运转总次数);
      this.Controls.Add((Control) this.textBox引擎运行总时长);
      this.Controls.Add((Control) this.textBoxECU运行总时长);
      this.Controls.Add((Control) this.textBox硬件ID);
      this.Controls.Add((Control) this.textBox固件版本);
      this.Controls.Add((Control) this.buttonDownload);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (StateWindow);
      this.TopMost = true;
      this.Load += new EventHandler(this.StateWindow_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
