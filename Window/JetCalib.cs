// Decompiled with JetBrains decompiler
// Type: ECU_GCS.JetCalib
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ECU_GCS
{
  public class JetCalib : Form
  {
    private string[] name = new string[5]
    {
      "jet_wgt_ms1",
      "jet_wgt_ms2",
      "jet_wgt_ms3",
      "jet_wgt_ms4",
      "jet_wgt_ms5"
    };
    private double[] value = new double[5];
    private bool jet_cmd_sta = false;
    private int jet_test_num = 0;
    private IContainer components = (IContainer) null;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private Button button5;
    private Button button6;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox5;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;

    public JetCalib() => this.InitializeComponent();

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
    }

    private void button6_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      if (!Directory.Exists(Application.StartupPath + "\\InjectData"))
        Directory.CreateDirectory(Application.StartupPath + "\\InjectData");
      saveFileDialog.InitialDirectory = Application.StartupPath + "\\InjectData";
      saveFileDialog.FileName = DateTime.Now.ToString("yyyy_MMdd_HHmm") + ".jet";
      saveFileDialog.Filter = "(*.jet)|*.jet";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        this.ExportConfig(saveFileDialog.FileName);
      }
      catch
      {
        int num = (int) MessageBox.Show(saveFileDialog.FileName + "\r\n保存失败");
      }
    }

    private void ExportConfig(string fileName)
    {
      StringBuilder stringBuilder = new StringBuilder();
      this.value[0] = double.Parse(this.textBox1.Text);
      this.value[1] = double.Parse(this.textBox2.Text);
      this.value[2] = double.Parse(this.textBox3.Text);
      this.value[3] = double.Parse(this.textBox4.Text);
      this.value[4] = double.Parse(this.textBox5.Text);
      for (int index = 0; index < 5; ++index)
        stringBuilder.AppendLine(this.name[index] + "\t" + this.value[index].ToString("0.00"));
      File.WriteAllText(fileName, stringBuilder.ToString());
    }

    private void Timer_Tick_Rec(object sender, EventArgs e)
    {
      T2_Content_Common data = C2_Content_Common.Data;
      if (((int) data.sta >> 6 & 1) == 1 && !this.jet_cmd_sta)
      {
        if (this.jet_test_num == 1)
          this.button1.BackColor = Color.Lime;
        else if (this.jet_test_num == 2)
          this.button2.BackColor = Color.Lime;
        else if (this.jet_test_num == 3)
          this.button3.BackColor = Color.Lime;
        else if (this.jet_test_num == 4)
          this.button4.BackColor = Color.Lime;
        else if (this.jet_test_num == 5)
          this.button5.BackColor = Color.Lime;
        this.jet_cmd_sta = true;
      }
      if (((int) data.sta >> 6 & 1) != 0 || !this.jet_cmd_sta)
        return;
      this.button1.BackColor = Color.Gray;
      this.button2.BackColor = Color.Gray;
      this.button3.BackColor = Color.Gray;
      this.button4.BackColor = Color.Gray;
      this.button5.BackColor = Color.Gray;
      this.jet_cmd_sta = false;
    }

    private void SendCommandContent(byte cmd, uint value)
    {
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

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.jet_cmd_sta)
      {
        this.SendCommandContent((byte) 9, 0U);
        this.jet_test_num = 0;
      }
      else
      {
        this.SendCommandContent((byte) 9, 1U);
        this.jet_test_num = 1;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (this.jet_cmd_sta)
      {
        this.SendCommandContent((byte) 9, 0U);
        this.jet_test_num = 0;
      }
      else
      {
        this.jet_test_num = 2;
        this.SendCommandContent((byte) 9, (uint) this.jet_test_num);
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (this.jet_cmd_sta)
      {
        this.SendCommandContent((byte) 9, 0U);
        this.jet_test_num = 0;
      }
      else
      {
        this.jet_test_num = 3;
        this.SendCommandContent((byte) 9, (uint) this.jet_test_num);
      }
    }

    private void button4_Click(object sender, EventArgs e)
    {
      if (this.jet_cmd_sta)
      {
        this.SendCommandContent((byte) 9, 0U);
        this.jet_test_num = 0;
      }
      else
      {
        this.jet_test_num = 4;
        this.SendCommandContent((byte) 9, (uint) this.jet_test_num);
      }
    }

    private void button5_Click(object sender, EventArgs e)
    {
      if (this.jet_cmd_sta)
      {
        this.SendCommandContent((byte) 9, 0U);
        this.jet_test_num = 0;
      }
      else
      {
        this.jet_test_num = 5;
        this.SendCommandContent((byte) 9, (uint) this.jet_test_num);
      }
    }

    private void JetCalib_Load(object sender, EventArgs e)
    {
      Timer timer = new Timer();
      timer.Interval = 10;
      timer.Tick += new EventHandler(this.Timer_Tick_Rec);
      timer.Start();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (JetCalib));
      this.button1 = new Button();
      this.button2 = new Button();
      this.button3 = new Button();
      this.button4 = new Button();
      this.button5 = new Button();
      this.button6 = new Button();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.textBox3 = new TextBox();
      this.textBox4 = new TextBox();
      this.textBox5 = new TextBox();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.button2, "button2");
      this.button2.Name = "button2";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      componentResourceManager.ApplyResources((object) this.button3, "button3");
      this.button3.Name = "button3";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      componentResourceManager.ApplyResources((object) this.button4, "button4");
      this.button4.Name = "button4";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new EventHandler(this.button4_Click);
      componentResourceManager.ApplyResources((object) this.button5, "button5");
      this.button5.Name = "button5";
      this.button5.UseVisualStyleBackColor = true;
      this.button5.Click += new EventHandler(this.button5_Click);
      componentResourceManager.ApplyResources((object) this.button6, "button6");
      this.button6.Name = "button6";
      this.button6.UseVisualStyleBackColor = true;
      this.button6.Click += new EventHandler(this.button6_Click);
      componentResourceManager.ApplyResources((object) this.textBox1, "textBox1");
      this.textBox1.Name = "textBox1";
      componentResourceManager.ApplyResources((object) this.textBox2, "textBox2");
      this.textBox2.Name = "textBox2";
      componentResourceManager.ApplyResources((object) this.textBox3, "textBox3");
      this.textBox3.Name = "textBox3";
      componentResourceManager.ApplyResources((object) this.textBox4, "textBox4");
      this.textBox4.Name = "textBox4";
      componentResourceManager.ApplyResources((object) this.textBox5, "textBox5");
      this.textBox5.Name = "textBox5";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.textBox5);
      this.Controls.Add((Control) this.textBox4);
      this.Controls.Add((Control) this.textBox3);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.button6);
      this.Controls.Add((Control) this.button5);
      this.Controls.Add((Control) this.button4);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = nameof (JetCalib);
      this.Load += new EventHandler(this.JetCalib_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
