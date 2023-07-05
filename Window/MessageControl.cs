// Decompiled with JetBrains decompiler
// Type: ECU_GCS.MessageControl
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ECU_GCS
{
  public class MessageControl : UserControl
  {
    private IContainer components = (IContainer) null;
    private TextBox tb供电电压;
    private GroupBox bg1;
    private GroupBox groupBox2;
    private TextBox tb油压;
    private TextBox tb油泵电流;
    private TextBox tb舵机电压;
    private TextBox tb油泵电压;
    private GroupBox groupBox1;
    private TextBox tb温度2;
    private TextBox tb温度4;
    private TextBox tb温度3;
    private TextBox tb温度1;
    private TextBox tb气压;
    private TextBox tb环境温度;
    private TextBox tb油泵PWM;
    private TextBox tb喷油脉宽2;
    private TextBox tb喷油脉宽1;
    private TextBox tbPWM_OUT3;
    private TextBox tbPWM_OUT2;
    private TextBox tbPWM_OUT1;
    private TextBox tb风门舵机;
    private GroupBox groupBox4;
    private TextBox tbPWM_IN3;
    private TextBox tbPWM_IN2;
    private TextBox tbPWM_IN1;
    private TextBox tb输入油门;
    private GroupBox groupBox5;
    private TextBox tb运行时间;
    private TextBox tb工作模式;
    private TextBox tb引擎转速1;
    private TextBox tb引擎转速2;
    private TextBox tb输出转速;
    private TextBox textBoxAlarm;
    private TextBox tb喷油量2;
    private TextBox tb喷油量1;
    private TextBox tb风门传感器2;
    private TextBox tb风门传感器1;
    private TextBox tb温度6;
    private TextBox tb温度5;

    public MessageControl() => this.InitializeComponent();

    private void MessageControl_Load(object sender, EventArgs e)
    {
      Timer timer = new Timer();
      timer.Interval = 10;
      timer.Tick += new EventHandler(this.Timer_Tick);
      timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e) => this.UpdateMessageDisplay();

    private void UpdateMessageDisplay()
    {
      T2_Content_Common data = C2_Content_Common.Data;
      switch (SetParameter.Language)
      {
        case "en-US":
          this.tbPWM_IN1.Text = this.tbPWM_IN1.Name.Remove(0, 2) + "：" + data.PWM_IN1.ToString("").PadLeft(6) + "%";
          this.tbPWM_IN2.Text = this.tbPWM_IN2.Name.Remove(0, 2) + "：" + data.PWM_IN2.ToString("").PadLeft(6) + "%";
          this.tbPWM_IN3.Text = this.tbPWM_IN3.Name.Remove(0, 2) + "：" + data.PWM_IN3.ToString("").PadLeft(6) + "%";
          this.tbPWM_OUT1.Text = this.tbPWM_OUT1.Name.Remove(0, 2) + "：" + data.PWM_OUT1.ToString("").PadLeft(5) + "%";
          this.tbPWM_OUT2.Text = this.tbPWM_OUT2.Name.Remove(0, 2) + "：" + data.PWM_OUT2.ToString("").PadLeft(5) + "%";
          this.tbPWM_OUT3.Text = this.tbPWM_OUT3.Name.Remove(0, 2) + "：" + data.PWM_OUT3.ToString("").PadLeft(5) + "%";
          this.tb油泵PWM.Text = "PUMP：" + data.PWM_OUT2.ToString("").PadLeft(5) + "%";
          this.tb油压.Text = "Fuel Pre：" + ((float) Math.Round((double) data.pre_oil, 1)).ToString("F1").PadLeft(3) + "bar";
          this.tb供电电压.Text = "Input ：" + ((float) data.vol_power / 10f).ToString("").PadLeft(5) + "V";
          this.tb舵机电压.Text = "Servo ：" + ((float) data.vol_svr / 10f).ToString("").PadLeft(5) + "V";
          this.tb油泵电压.Text = "Pump V：" + ((float) data.vol_pump / 10f).ToString("").PadLeft(5) + "V";
          this.tb油泵电流.Text = "Pump A：" + ((float) data.amp_pump / 10f).ToString("").PadLeft(5) + "A";
          this.tb喷油脉宽1.Text = "INJ1：" + ((float) data.inj1_ms / 100f).ToString("F2").PadLeft(8) + "ms";
          TextBox tb喷油脉宽2_1 = this.tb喷油脉宽2;
          float num1 = (float) data.inj2_ms / 100f;
          string str1 = "INJ2：" + num1.ToString("F2").PadLeft(8) + "ms";
          tb喷油脉宽2_1.Text = str1;
          TextBox tb气压1 = this.tb气压;
          num1 = data.pre_gas / 100f;
          string str2 = "Pre ：" + num1.ToString("F1").PadLeft(5) + "mbar";
          tb气压1.Text = str2;
          this.tb温度1.Text = "Temp1：" + data.tmp0.ToString("").PadLeft(7) + "℃";
          this.tb温度2.Text = "Temp2：" + data.tmp1.ToString("").PadLeft(7) + "℃";
          this.tb温度3.Text = "Temp3：" + data.tmp2.ToString("").PadLeft(7) + "℃";
          this.tb温度4.Text = "Temp4：" + data.tmp3.ToString("").PadLeft(7) + "℃";
          this.tb温度5.Text = "Temp5：" + data.tmp4.ToString("").PadLeft(7) + "℃";
          this.tb温度6.Text = "Temp6：" + data.tmp5.ToString("").PadLeft(7) + "℃";
          this.tb环境温度.Text = "Env Temp：" + data.tmp_env.ToString("").PadLeft(4) + "℃";
          this.tb输入油门.Text = "Thr_In   ：" + data.bus_thr.ToString("").PadLeft(4) + "%";
          this.tb风门舵机.Text = "Thr_Servo：" + data.svr_pwm.ToString("").PadLeft(4) + "%";
          this.tb引擎转速1.Text = "RPM 1：" + data.rpm1.ToString("").PadLeft(7) + "r";
          this.tb引擎转速2.Text = "RPM 2：" + data.rpm2.ToString("").PadLeft(7) + "r";
          this.tb输出转速.Text = "OUT RPM：" + data.rpm_out.ToString("").PadLeft(5) + "r";
          this.tb风门传感器1.Text = "Thr Sen1：" + data.oil1_thr.ToString("").PadLeft(5) + "%";
          this.tb风门传感器2.Text = "Thr Sen2：" + data.oil2_thr.ToString("").PadLeft(5) + "%";
          TextBox tb喷油量1_1 = this.tb喷油量1;
          num1 = (float) data.inj1_mg / 100f;
          string str3 = "Ins F/C 1：" + num1.ToString("F1").PadLeft(1) + "L/h";
          tb喷油量1_1.Text = str3;
          TextBox tb喷油量2_1 = this.tb喷油量2;
          num1 = (float) data.inj2_mg / 100f;
          string str4 = "Ins F/C 2：" + num1.ToString("F1").PadLeft(1) + "L/h";
          tb喷油量2_1.Text = str4;
          string[] strArray1 = new string[5];
          uint num2 = data.eng_run_time / 3600U;
          strArray1[0] = num2.ToString("00");
          strArray1[1] = ":";
          num2 = data.eng_run_time % 3600U / 60U;
          strArray1[2] = num2.ToString("00");
          strArray1[3] = ":";
          num2 = data.eng_run_time % 60U;
          strArray1[4] = num2.ToString("00");
          this.tb运行时间.Text = "Power on：" + string.Concat(strArray1).PadLeft(5);
          string str5 = "null";
          switch (data.mode)
          {
            case 0:
              str5 = "sbus";
              break;
            case 1:
              str5 = "Smart Thr";
              break;
            case 2:
              str5 = "pwm1+2";
              break;
            case 3:
              str5 = "Serial port";
              break;
            case 4:
              str5 = "null";
              break;
            case 5:
              str5 = "Bluetooth";
              break;
          }
          this.tb工作模式.Text = "Mode：" + str5.PadLeft(5);
          break;
        case "zh-TW":
          this.tbPWM_IN1.Text = this.tbPWM_IN1.Name.Remove(0, 2) + "：" + data.PWM_IN1.ToString("").PadLeft(6) + "%";
          this.tbPWM_IN2.Text = this.tbPWM_IN2.Name.Remove(0, 2) + "：" + data.PWM_IN2.ToString("").PadLeft(6) + "%";
          this.tbPWM_IN3.Text = this.tbPWM_IN3.Name.Remove(0, 2) + "：" + data.PWM_IN3.ToString("").PadLeft(6) + "%";
          this.tbPWM_OUT1.Text = this.tbPWM_OUT1.Name.Remove(0, 2) + "：" + data.PWM_OUT1.ToString("").PadLeft(5) + "%";
          this.tbPWM_OUT2.Text = this.tbPWM_OUT2.Name.Remove(0, 2) + "：" + data.PWM_OUT2.ToString("").PadLeft(5) + "%";
          this.tbPWM_OUT3.Text = this.tbPWM_OUT3.Name.Remove(0, 2) + "：" + data.PWM_OUT3.ToString("").PadLeft(5) + "%";
          this.tb油泵PWM.Text = "幫浦PWM：" + data.PWM_OUT2.ToString("").PadLeft(6) + "%";
          this.tb油压.Text = "油壓：" + ((float) Math.Round((double) data.pre_oil, 1)).ToString("F1").PadLeft(7) + "bar";
          this.tb供电电压.Text = "供電電壓：" + ((float) data.vol_power / 10f).ToString("").PadLeft(5) + "V";
          this.tb舵机电压.Text = "伺服機電壓：" + ((float) data.vol_svr / 10f).ToString("").PadLeft(3) + "V";
          this.tb油泵电压.Text = "幫浦電壓：" + ((float) data.vol_pump / 10f).ToString("").PadLeft(5) + "V";
          this.tb油泵电流.Text = "幫浦電流：" + ((float) data.amp_pump / 10f).ToString("").PadLeft(5) + "A";
          this.tb喷油脉宽1.Text = "噴油脈寬1：" + ((float) data.inj1_ms / 100f).ToString("F2").PadLeft(4) + "ms";
          TextBox tb喷油脉宽2_2 = this.tb喷油脉宽2;
          float num3 = (float) data.inj2_ms / 100f;
          string str6 = "噴油脈寬2：" + num3.ToString("F2").PadLeft(4) + "ms";
          tb喷油脉宽2_2.Text = str6;
          TextBox tb气压2 = this.tb气压;
          num3 = data.pre_gas / 100f;
          string str7 = "氣壓：" + num3.ToString("F1").PadLeft(5) + "mbar";
          tb气压2.Text = str7;
          this.tb温度1.Text = "溫度1：" + data.tmp0.ToString("").PadLeft(7) + "℃";
          this.tb温度2.Text = "溫度2：" + data.tmp1.ToString("").PadLeft(7) + "℃";
          this.tb温度3.Text = "溫度3：" + data.tmp2.ToString("").PadLeft(7) + "℃";
          this.tb温度4.Text = "溫度4：" + data.tmp3.ToString("").PadLeft(7) + "℃";
          this.tb温度5.Text = "溫度5：" + data.tmp4.ToString("").PadLeft(7) + "℃";
          this.tb温度6.Text = "溫度6：" + data.tmp5.ToString("").PadLeft(7) + "℃";
          this.tb环境温度.Text = "環境溫度：" + data.tmp_env.ToString("").PadLeft(4) + "℃";
          this.tb输入油门.Text = "輸入油門：" + data.bus_thr.ToString("").PadLeft(5) + "%";
          this.tb风门舵机.Text = "風門伺服機：" + data.svr_pwm.ToString("").PadLeft(3) + "%";
          this.tb引擎转速1.Text = "引擎轉速1：" + data.rpm1.ToString("").PadLeft(5) + "r";
          this.tb引擎转速2.Text = "引擎轉速2：" + data.rpm2.ToString("").PadLeft(5) + "r";
          this.tb输出转速.Text = "輸出轉速：" + data.rpm_out.ToString("").PadLeft(6) + "r";
          this.tb风门传感器1.Text = "風門感測器1：" + data.oil1_thr.ToString("").PadLeft(2) + "%";
          this.tb风门传感器2.Text = "風門感測器2：" + data.oil2_thr.ToString("").PadLeft(2) + "%";
          TextBox tb喷油量1_2 = this.tb喷油量1;
          num3 = (float) data.inj1_mg / 100f;
          string str8 = "油耗1：" + num3.ToString("F2").PadLeft(6) + "L/h";
          tb喷油量1_2.Text = str8;
          TextBox tb喷油量2_2 = this.tb喷油量2;
          num3 = (float) data.inj2_mg / 100f;
          string str9 = "油耗2：" + num3.ToString("F2").PadLeft(6) + "L/h";
          tb喷油量2_2.Text = str9;
          string[] strArray2 = new string[5];
          uint num4 = data.eng_run_time / 3600U;
          strArray2[0] = num4.ToString("00");
          strArray2[1] = ":";
          num4 = data.eng_run_time % 3600U / 60U;
          strArray2[2] = num4.ToString("00");
          strArray2[3] = ":";
          num4 = data.eng_run_time % 60U;
          strArray2[4] = num4.ToString("00");
          this.tb运行时间.Text = "運轉時間：" + string.Concat(strArray2).PadLeft(5);
          string str10 = "null";
          switch (data.mode)
          {
            case 0:
              str10 = "sbus";
              break;
            case 1:
              str10 = "Smart Thr";
              break;
            case 2:
              str10 = "pwm1+2";
              break;
            case 3:
              str10 = "串口";
              break;
            case 4:
              str10 = "null";
              break;
            case 5:
              str10 = "藍牙";
              break;
          }
          this.tb工作模式.Text = "工作模式：" + str10.PadLeft(6);
          break;
        default:
          this.tbPWM_IN1.Text = this.tbPWM_IN1.Name.Remove(0, 2) + "：" + data.PWM_IN1.ToString("").PadLeft(6) + "%";
          this.tbPWM_IN2.Text = this.tbPWM_IN2.Name.Remove(0, 2) + "：" + data.PWM_IN2.ToString("").PadLeft(6) + "%";
          this.tbPWM_IN3.Text = this.tbPWM_IN3.Name.Remove(0, 2) + "：" + data.PWM_IN3.ToString("").PadLeft(6) + "%";
          this.tbPWM_OUT1.Text = this.tbPWM_OUT1.Name.Remove(0, 2) + "：" + data.PWM_OUT1.ToString("").PadLeft(5) + "%";
          this.tbPWM_OUT2.Text = this.tbPWM_OUT2.Name.Remove(0, 2) + "：" + data.PWM_OUT2.ToString("").PadLeft(5) + "%";
          this.tbPWM_OUT3.Text = this.tbPWM_OUT3.Name.Remove(0, 2) + "：" + data.PWM_OUT3.ToString("").PadLeft(5) + "%";
          this.tb油泵PWM.Text = "油泵PWM：" + data.PWM_OUT2.ToString("").PadLeft(6) + "%";
          this.tb供电电压.Text = this.tb供电电压.Name.Remove(0, 2) + "：" + ((float) data.vol_power / 10f).ToString("").PadLeft(5) + "V";
          this.tb舵机电压.Text = this.tb舵机电压.Name.Remove(0, 2) + "：" + ((float) data.vol_svr / 10f).ToString("").PadLeft(5) + "V";
          TextBox tb油泵电压 = this.tb油泵电压;
          string str11 = this.tb油泵电压.Name.Remove(0, 2);
          float num5 = (float) data.vol_pump / 10f;
          string str12 = num5.ToString("").PadLeft(5);
          string str13 = str11 + "：" + str12 + "V";
          tb油泵电压.Text = str13;
          TextBox tb油泵电流 = this.tb油泵电流;
          string str14 = this.tb油泵电流.Name.Remove(0, 2);
          num5 = (float) data.amp_pump / 10f;
          string str15 = num5.ToString("").PadLeft(5);
          string str16 = str14 + "：" + str15 + "A";
          tb油泵电流.Text = str16;
          TextBox tb喷油脉宽1 = this.tb喷油脉宽1;
          string str17 = this.tb喷油脉宽1.Name.Remove(0, 2);
          num5 = (float) data.inj1_ms / 100f;
          string str18 = num5.ToString("F2").PadLeft(4);
          string str19 = str17 + "：" + str18 + "ms";
          tb喷油脉宽1.Text = str19;
          TextBox tb喷油脉宽2_3 = this.tb喷油脉宽2;
          string str20 = this.tb喷油脉宽2.Name.Remove(0, 2);
          num5 = (float) data.inj2_ms / 100f;
          string str21 = num5.ToString("F2").PadLeft(4);
          string str22 = str20 + "：" + str21 + "ms";
          tb喷油脉宽2_3.Text = str22;
          TextBox tb气压3 = this.tb气压;
          string str23 = this.tb气压.Name.Remove(0, 2);
          num5 = data.pre_gas / 100f;
          string str24 = num5.ToString("F1").PadLeft(5);
          string str25 = str23 + "：" + str24 + "mbar";
          tb气压3.Text = str25;
          TextBox tb油压 = this.tb油压;
          string str26 = this.tb油压.Name.Remove(0, 2);
          num5 = (float) Math.Round((double) data.pre_oil, 1);
          string str27 = num5.ToString("F1").PadLeft(7);
          string str28 = str26 + "：" + str27 + "bar";
          tb油压.Text = str28;
          this.tb温度1.Text = this.tb温度1.Name.Remove(0, 2) + "：" + data.tmp0.ToString("").PadLeft(7) + "℃";
          this.tb温度2.Text = this.tb温度2.Name.Remove(0, 2) + "：" + data.tmp1.ToString("").PadLeft(7) + "℃";
          this.tb温度3.Text = this.tb温度3.Name.Remove(0, 2) + "：" + data.tmp2.ToString("").PadLeft(7) + "℃";
          this.tb温度4.Text = this.tb温度4.Name.Remove(0, 2) + "：" + data.tmp3.ToString("").PadLeft(7) + "℃";
          this.tb温度5.Text = "温度5：" + data.tmp4.ToString("").PadLeft(7) + "℃";
          this.tb温度6.Text = "温度6：" + data.tmp5.ToString("").PadLeft(7) + "℃";
          this.tb环境温度.Text = this.tb环境温度.Name.Remove(0, 2) + "：" + data.tmp_env.ToString("").PadLeft(4) + "℃";
          this.tb输入油门.Text = this.tb输入油门.Name.Remove(0, 2) + "：" + data.bus_thr.ToString("").PadLeft(5) + "%";
          this.tb风门舵机.Text = this.tb风门舵机.Name.Remove(0, 2) + "：" + data.svr_pwm.ToString("").PadLeft(5) + "%";
          this.tb引擎转速1.Text = this.tb引擎转速1.Name.Remove(0, 2) + "：" + data.rpm1.ToString("").PadLeft(5) + "r";
          this.tb引擎转速2.Text = this.tb引擎转速2.Name.Remove(0, 2) + "：" + data.rpm2.ToString("").PadLeft(5) + "r";
          this.tb输出转速.Text = this.tb输出转速.Name.Remove(0, 2) + "：" + data.rpm_out.ToString("").PadLeft(6) + "r";
          this.tb风门传感器1.Text = "风门传感器1：" + data.oil1_thr.ToString("").PadLeft(2) + "%";
          this.tb风门传感器2.Text = "风门传感器2：" + data.oil2_thr.ToString("").PadLeft(2) + "%";
          TextBox tb喷油量1_3 = this.tb喷油量1;
          num5 = (float) data.inj1_mg / 100f;
          string str29 = "油耗1：" + num5.ToString("F2").PadLeft(6) + "L/h";
          tb喷油量1_3.Text = str29;
          TextBox tb喷油量2_3 = this.tb喷油量2;
          num5 = (float) data.inj2_mg / 100f;
          string str30 = "油耗2：" + num5.ToString("F2").PadLeft(6) + "L/h";
          tb喷油量2_3.Text = str30;
          string str31 = (data.eng_run_time / 3600U).ToString("00") + ":" + (data.eng_run_time % 3600U / 60U).ToString("00") + ":" + (data.eng_run_time % 60U).ToString("00");
          this.tb运行时间.Text = this.tb运行时间.Name.Remove(0, 2) + "：" + str31.PadLeft(5);
          string str32 = "无";
          switch (data.mode)
          {
            case 0:
              str32 = "sbus";
              break;
            case 1:
              str32 = "Smart Thr";
              break;
            case 2:
              str32 = "pwm1+2";
              break;
            case 3:
              str32 = "串口";
              break;
            case 4:
              str32 = "空";
              break;
            case 5:
              str32 = "蓝牙";
              break;
          }
          this.tb工作模式.Text = this.tb工作模式.Name.Remove(0, 2) + "：" + str32.PadLeft(5);
          break;
      }
      this.textBoxAlarm.Text = "";
      foreach (string str33 in Common.SpeakWarningMessage.currentMessages.ToArray())
      {
        TextBox textBoxAlarm = this.textBoxAlarm;
        textBoxAlarm.Text = textBoxAlarm.Text + str33 + "\r\n";
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MessageControl));
      this.tb供电电压 = new TextBox();
      this.bg1 = new GroupBox();
      this.tb油泵电流 = new TextBox();
      this.tb舵机电压 = new TextBox();
      this.tb油泵电压 = new TextBox();
      this.groupBox2 = new GroupBox();
      this.tb喷油量2 = new TextBox();
      this.tb喷油量1 = new TextBox();
      this.tb风门传感器2 = new TextBox();
      this.tb风门传感器1 = new TextBox();
      this.tb油泵PWM = new TextBox();
      this.tb喷油脉宽2 = new TextBox();
      this.tb喷油脉宽1 = new TextBox();
      this.tb油压 = new TextBox();
      this.groupBox1 = new GroupBox();
      this.tb气压 = new TextBox();
      this.tb环境温度 = new TextBox();
      this.tb温度4 = new TextBox();
      this.tb风门舵机 = new TextBox();
      this.tb温度3 = new TextBox();
      this.tb输入油门 = new TextBox();
      this.tb温度1 = new TextBox();
      this.tb温度2 = new TextBox();
      this.tbPWM_OUT3 = new TextBox();
      this.tbPWM_OUT2 = new TextBox();
      this.tbPWM_OUT1 = new TextBox();
      this.groupBox4 = new GroupBox();
      this.tbPWM_IN3 = new TextBox();
      this.tbPWM_IN2 = new TextBox();
      this.tbPWM_IN1 = new TextBox();
      this.groupBox5 = new GroupBox();
      this.textBoxAlarm = new TextBox();
      this.tb运行时间 = new TextBox();
      this.tb工作模式 = new TextBox();
      this.tb引擎转速1 = new TextBox();
      this.tb引擎转速2 = new TextBox();
      this.tb输出转速 = new TextBox();
      this.tb温度5 = new TextBox();
      this.tb温度6 = new TextBox();
      this.bg1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox5.SuspendLayout();
      this.SuspendLayout();
      this.tb供电电压.BackColor = Color.DeepSkyBlue;
      componentResourceManager.ApplyResources((object) this.tb供电电压, "tb供电电压");
      this.tb供电电压.Name = "tb供电电压";
      this.tb供电电压.ReadOnly = true;
      this.bg1.Controls.Add((Control) this.tb油泵电流);
      this.bg1.Controls.Add((Control) this.tb舵机电压);
      this.bg1.Controls.Add((Control) this.tb油泵电压);
      this.bg1.Controls.Add((Control) this.tb供电电压);
      this.bg1.ForeColor = SystemColors.MenuText;
      componentResourceManager.ApplyResources((object) this.bg1, "bg1");
      this.bg1.Name = "bg1";
      this.bg1.TabStop = false;
      this.tb油泵电流.BackColor = Color.DeepSkyBlue;
      componentResourceManager.ApplyResources((object) this.tb油泵电流, "tb油泵电流");
      this.tb油泵电流.Name = "tb油泵电流";
      this.tb油泵电流.ReadOnly = true;
      this.tb舵机电压.BackColor = Color.DeepSkyBlue;
      componentResourceManager.ApplyResources((object) this.tb舵机电压, "tb舵机电压");
      this.tb舵机电压.Name = "tb舵机电压";
      this.tb舵机电压.ReadOnly = true;
      this.tb油泵电压.BackColor = Color.DeepSkyBlue;
      componentResourceManager.ApplyResources((object) this.tb油泵电压, "tb油泵电压");
      this.tb油泵电压.Name = "tb油泵电压";
      this.tb油泵电压.ReadOnly = true;
      this.groupBox2.Controls.Add((Control) this.tb喷油量2);
      this.groupBox2.Controls.Add((Control) this.tb喷油量1);
      this.groupBox2.Controls.Add((Control) this.tb风门传感器2);
      this.groupBox2.Controls.Add((Control) this.tb风门传感器1);
      this.groupBox2.Controls.Add((Control) this.tb油泵PWM);
      this.groupBox2.Controls.Add((Control) this.tb喷油脉宽2);
      this.groupBox2.Controls.Add((Control) this.tb喷油脉宽1);
      this.groupBox2.Controls.Add((Control) this.tb油压);
      componentResourceManager.ApplyResources((object) this.groupBox2, "groupBox2");
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.TabStop = false;
      this.tb喷油量2.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb喷油量2, "tb喷油量2");
      this.tb喷油量2.Name = "tb喷油量2";
      this.tb喷油量2.ReadOnly = true;
      this.tb喷油量1.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb喷油量1, "tb喷油量1");
      this.tb喷油量1.Name = "tb喷油量1";
      this.tb喷油量1.ReadOnly = true;
      this.tb风门传感器2.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb风门传感器2, "tb风门传感器2");
      this.tb风门传感器2.Name = "tb风门传感器2";
      this.tb风门传感器2.ReadOnly = true;
      this.tb风门传感器1.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb风门传感器1, "tb风门传感器1");
      this.tb风门传感器1.Name = "tb风门传感器1";
      this.tb风门传感器1.ReadOnly = true;
      this.tb油泵PWM.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb油泵PWM, "tb油泵PWM");
      this.tb油泵PWM.Name = "tb油泵PWM";
      this.tb油泵PWM.ReadOnly = true;
      this.tb喷油脉宽2.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb喷油脉宽2, "tb喷油脉宽2");
      this.tb喷油脉宽2.Name = "tb喷油脉宽2";
      this.tb喷油脉宽2.ReadOnly = true;
      this.tb喷油脉宽1.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb喷油脉宽1, "tb喷油脉宽1");
      this.tb喷油脉宽1.Name = "tb喷油脉宽1";
      this.tb喷油脉宽1.ReadOnly = true;
      this.tb油压.BackColor = SystemColors.ActiveCaption;
      componentResourceManager.ApplyResources((object) this.tb油压, "tb油压");
      this.tb油压.Name = "tb油压";
      this.tb油压.ReadOnly = true;
      this.groupBox1.Controls.Add((Control) this.tb温度6);
      this.groupBox1.Controls.Add((Control) this.tb温度5);
      this.groupBox1.Controls.Add((Control) this.tb气压);
      this.groupBox1.Controls.Add((Control) this.tb环境温度);
      this.groupBox1.Controls.Add((Control) this.tb温度4);
      this.groupBox1.Controls.Add((Control) this.tb温度3);
      this.groupBox1.Controls.Add((Control) this.tb温度1);
      this.groupBox1.Controls.Add((Control) this.tb温度2);
      this.groupBox1.ForeColor = SystemColors.MenuText;
      componentResourceManager.ApplyResources((object) this.groupBox1, "groupBox1");
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      this.tb气压.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb气压, "tb气压");
      this.tb气压.Name = "tb气压";
      this.tb气压.ReadOnly = true;
      this.tb环境温度.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb环境温度, "tb环境温度");
      this.tb环境温度.Name = "tb环境温度";
      this.tb环境温度.ReadOnly = true;
      this.tb温度4.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度4, "tb温度4");
      this.tb温度4.Name = "tb温度4";
      this.tb温度4.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.tb风门舵机, "tb风门舵机");
      this.tb风门舵机.Name = "tb风门舵机";
      this.tb风门舵机.ReadOnly = true;
      this.tb温度3.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度3, "tb温度3");
      this.tb温度3.Name = "tb温度3";
      this.tb温度3.ReadOnly = true;
      this.tb输入油门.BackColor = SystemColors.Info;
      componentResourceManager.ApplyResources((object) this.tb输入油门, "tb输入油门");
      this.tb输入油门.Name = "tb输入油门";
      this.tb输入油门.ReadOnly = true;
      this.tb温度1.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度1, "tb温度1");
      this.tb温度1.Name = "tb温度1";
      this.tb温度1.ReadOnly = true;
      this.tb温度2.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度2, "tb温度2");
      this.tb温度2.Name = "tb温度2";
      this.tb温度2.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.tbPWM_OUT3, "tbPWM_OUT3");
      this.tbPWM_OUT3.Name = "tbPWM_OUT3";
      this.tbPWM_OUT3.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.tbPWM_OUT2, "tbPWM_OUT2");
      this.tbPWM_OUT2.Name = "tbPWM_OUT2";
      this.tbPWM_OUT2.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.tbPWM_OUT1, "tbPWM_OUT1");
      this.tbPWM_OUT1.Name = "tbPWM_OUT1";
      this.tbPWM_OUT1.ReadOnly = true;
      this.groupBox4.Controls.Add((Control) this.tbPWM_OUT3);
      this.groupBox4.Controls.Add((Control) this.tbPWM_OUT2);
      this.groupBox4.Controls.Add((Control) this.tbPWM_OUT1);
      this.groupBox4.Controls.Add((Control) this.tb风门舵机);
      this.groupBox4.Controls.Add((Control) this.tb输入油门);
      this.groupBox4.Controls.Add((Control) this.tbPWM_IN3);
      this.groupBox4.Controls.Add((Control) this.tbPWM_IN2);
      this.groupBox4.Controls.Add((Control) this.tbPWM_IN1);
      this.groupBox4.ForeColor = SystemColors.MenuText;
      componentResourceManager.ApplyResources((object) this.groupBox4, "groupBox4");
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.TabStop = false;
      this.tbPWM_IN3.BackColor = SystemColors.Info;
      componentResourceManager.ApplyResources((object) this.tbPWM_IN3, "tbPWM_IN3");
      this.tbPWM_IN3.Name = "tbPWM_IN3";
      this.tbPWM_IN3.ReadOnly = true;
      this.tbPWM_IN2.BackColor = SystemColors.Info;
      componentResourceManager.ApplyResources((object) this.tbPWM_IN2, "tbPWM_IN2");
      this.tbPWM_IN2.Name = "tbPWM_IN2";
      this.tbPWM_IN2.ReadOnly = true;
      this.tbPWM_IN1.BackColor = SystemColors.Info;
      componentResourceManager.ApplyResources((object) this.tbPWM_IN1, "tbPWM_IN1");
      this.tbPWM_IN1.Name = "tbPWM_IN1";
      this.tbPWM_IN1.ReadOnly = true;
      this.groupBox5.Controls.Add((Control) this.textBoxAlarm);
      this.groupBox5.Controls.Add((Control) this.tb运行时间);
      this.groupBox5.Controls.Add((Control) this.tb工作模式);
      this.groupBox5.Controls.Add((Control) this.tb引擎转速1);
      this.groupBox5.Controls.Add((Control) this.tb引擎转速2);
      this.groupBox5.Controls.Add((Control) this.tb输出转速);
      componentResourceManager.ApplyResources((object) this.groupBox5, "groupBox5");
      this.groupBox5.Name = "groupBox5";
      this.groupBox5.TabStop = false;
      this.textBoxAlarm.BackColor = SystemColors.ControlDark;
      componentResourceManager.ApplyResources((object) this.textBoxAlarm, "textBoxAlarm");
      this.textBoxAlarm.ForeColor = Color.Yellow;
      this.textBoxAlarm.Name = "textBoxAlarm";
      this.tb运行时间.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.tb运行时间, "tb运行时间");
      this.tb运行时间.Name = "tb运行时间";
      this.tb运行时间.ReadOnly = true;
      this.tb工作模式.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.tb工作模式, "tb工作模式");
      this.tb工作模式.Name = "tb工作模式";
      this.tb工作模式.ReadOnly = true;
      this.tb引擎转速1.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.tb引擎转速1, "tb引擎转速1");
      this.tb引擎转速1.Name = "tb引擎转速1";
      this.tb引擎转速1.ReadOnly = true;
      this.tb引擎转速2.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.tb引擎转速2, "tb引擎转速2");
      this.tb引擎转速2.Name = "tb引擎转速2";
      this.tb引擎转速2.ReadOnly = true;
      this.tb输出转速.BackColor = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 192);
      componentResourceManager.ApplyResources((object) this.tb输出转速, "tb输出转速");
      this.tb输出转速.Name = "tb输出转速";
      this.tb输出转速.ReadOnly = true;
      this.tb温度5.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度5, "tb温度5");
      this.tb温度5.Name = "tb温度5";
      this.tb温度5.ReadOnly = true;
      this.tb温度6.BackColor = Color.Violet;
      componentResourceManager.ApplyResources((object) this.tb温度6, "tb温度6");
      this.tb温度6.Name = "tb温度6";
      this.tb温度6.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.ControlDark;
      this.Controls.Add((Control) this.groupBox5);
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.bg1);
      this.Name = nameof (MessageControl);
      this.Load += new EventHandler(this.MessageControl_Load);
      this.bg1.ResumeLayout(false);
      this.bg1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox5.ResumeLayout(false);
      this.groupBox5.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
