// Decompiled with JetBrains decompiler
// Type: ECU_GCS.Cfg_Base
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace ECU_GCS
{
  public class Cfg_Base : Form
  {
    private int a = 0;
    private IContainer components = (IContainer) null;
    private GroupBox groupBox3;
    private Button buttonUpload;
    private Button buttonDownload;
    private GroupBox groupBox4;
    private Label label_jet_name;
    private Button btn_select_inj;

    public Cfg_Base()
    {
      this.InitializeComponent();
      this.InitializeConfigValue();
    }

    private Point get_loc(int row, int num) => new Point(30 + num / row * 300, 5 + num % row * 30);

    private void InitializeConfigValue()
    {
      int row = 19;
      int index1 = 97;
      Common.cfg_value[index1] = new CfgValue(0.0f, true);
      Common.cfg_value[index1].Index = index1;
      Common.cfg_value[index1].Step = 10f;
      Common.cfg_value[index1].Min = 0.0f;
      Common.cfg_value[index1].Max = 2500f;
      Common.cfg_value[index1].Name = "熄火位置";
      Common.cfg_value[index1].Name_CN = "熄火位置";
      Common.cfg_value[index1].Name_CN_TW = "熄火位置";
      Common.cfg_value[index1].Name_EN = "Servo Close";
      Common.cfg_value[index1].Name_Save = "cfg_servo_pwm_close";
      Common.cfg_value[index1].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index1].num = this.a;
      Common.cfg_value[index1].AddToWidnow((Control) this);
      ++this.a;
      int index2 = 50;
      Common.cfg_value[index2] = new CfgValue(0.0f, true);
      Common.cfg_value[index2].Index = index2;
      Common.cfg_value[index2].Step = 10f;
      Common.cfg_value[index2].Min = 0.0f;
      Common.cfg_value[index2].Max = 2500f;
      Common.cfg_value[index2].Name = "舵机最小 ";
      Common.cfg_value[index2].Name_CN = "舵机最小";
      Common.cfg_value[index2].Name_CN_TW = "伺服機最小";
      Common.cfg_value[index2].Name_EN = "Servo Min";
      Common.cfg_value[index2].Name_Save = "cfg_servo_pwm_min";
      Common.cfg_value[index2].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index2].num = this.a;
      Common.cfg_value[index2].AddToWidnow((Control) this);
      ++this.a;
      int index3 = 51;
      Common.cfg_value[index3] = new CfgValue(0.0f, true);
      Common.cfg_value[index3].Index = index3;
      Common.cfg_value[index3].Step = 10f;
      Common.cfg_value[index3].Min = 0.0f;
      Common.cfg_value[index3].Max = 2500f;
      Common.cfg_value[index3].Name = "舵机最大 ";
      Common.cfg_value[index3].Name_CN = "舵机最大";
      Common.cfg_value[index3].Name_CN_TW = "伺服機最大";
      Common.cfg_value[index3].Name_EN = "Servo Max";
      Common.cfg_value[index3].Name_Save = "cfg_servo_pwm_max";
      Common.cfg_value[index3].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index3].num = this.a;
      Common.cfg_value[index3].AddToWidnow((Control) this);
      ++this.a;
      int index4 = 87;
      Common.cfg_value[index4] = new CfgValue(0.0f, true);
      Common.cfg_value[index4].Index = index4;
      Common.cfg_value[index4].Step = 1f;
      Common.cfg_value[index4].Min = 0.0f;
      Common.cfg_value[index4].Max = 1f;
      Common.cfg_value[index4].Name = "舵机反向";
      Common.cfg_value[index4].Name_CN = "舵机输出反向";
      Common.cfg_value[index4].Name_CN_TW = "伺服機輸出反向";
      Common.cfg_value[index4].Name_EN = "Servo Reverse";
      Common.cfg_value[index4].Name_Save = "cfg_servo_pwm_rev";
      Common.cfg_value[index4].Name_0 = "Disable";
      Common.cfg_value[index4].Name_1 = "Enable";
      Common.cfg_value[index4].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index4].num = this.a;
      Common.cfg_value[index4].AddToWidnow((Control) this);
      ++this.a;
      int index5 = 52;
      Common.cfg_value[index5] = new CfgValue(0.0f, true);
      Common.cfg_value[index5].Index = index5;
      Common.cfg_value[index5].Step = 0.1f;
      Common.cfg_value[index5].Min = 0.0f;
      Common.cfg_value[index5].Max = 10f;
      Common.cfg_value[index5].Name = "喷油提前时间";
      Common.cfg_value[index5].Name_CN = "喷油提前时间";
      Common.cfg_value[index5].Name_CN_TW = "噴油提前時間";
      Common.cfg_value[index5].Name_EN = "Inject Advance";
      Common.cfg_value[index5].Name_Save = "cfg_oil_forward_ms";
      Common.cfg_value[index5].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index5].num = this.a;
      Common.cfg_value[index5].AddToWidnow((Control) this);
      ++this.a;
      int index6 = 54;
      Common.cfg_value[index6] = new CfgValue(0.0f, true);
      Common.cfg_value[index6].Index = index6;
      Common.cfg_value[index6].Step = 1f;
      Common.cfg_value[index6].Min = 0.0f;
      Common.cfg_value[index6].Max = 20f;
      Common.cfg_value[index6].Name = "热车喷油系数";
      Common.cfg_value[index6].Name_CN = "热车喷油系数";
      Common.cfg_value[index6].Name_CN_TW = "暖車噴油係數";
      Common.cfg_value[index6].Name_EN = "Start Inject Coe";
      Common.cfg_value[index6].Name_Save = "cfg_extra_factor";
      Common.cfg_value[index6].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index6].num = this.a;
      Common.cfg_value[index6].AddToWidnow((Control) this);
      ++this.a;
      int index7 = 69;
      Common.cfg_value[index7] = new CfgValue(0.0f, true);
      Common.cfg_value[index7].Index = index7;
      Common.cfg_value[index7].Step = 0.01f;
      Common.cfg_value[index7].Min = 0.8f;
      Common.cfg_value[index7].Max = 1.2f;
      Common.cfg_value[index7].Name = "整体喷油系数";
      Common.cfg_value[index7].Name_CN = "整体喷油系数";
      Common.cfg_value[index7].Name_CN_TW = "整體噴油係數";
      Common.cfg_value[index7].Name_EN = "All Inject Coe";
      Common.cfg_value[index7].Name_Save = "oil_total_coe";
      Common.cfg_value[index7].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index7].num = this.a;
      Common.cfg_value[index7].AddToWidnow((Control) this);
      ++this.a;
      int index8 = 86;
      Common.cfg_value[index8] = new CfgValue(0.0f, true);
      Common.cfg_value[index8].Index = index8;
      Common.cfg_value[index8].Step = 1f;
      Common.cfg_value[index8].Min = 0.0f;
      Common.cfg_value[index8].Max = 200f;
      Common.cfg_value[index8].Name = "气压补偿系数%";
      Common.cfg_value[index8].Name_CN = "气压补偿系数%";
      Common.cfg_value[index8].Name_CN_TW = "气压补偿系数%";
      Common.cfg_value[index8].Name_EN = "Pre Correct Coe%";
      Common.cfg_value[index8].Name_Save = "pre_correct_coe";
      Common.cfg_value[index8].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index8].num = this.a;
      Common.cfg_value[index8].AddToWidnow((Control) this);
      ++this.a;
      int index9 = 83;
      Common.cfg_value[index9] = new CfgValue(0.0f, true);
      Common.cfg_value[index9].Index = index9;
      Common.cfg_value[index9].Step = 1f;
      Common.cfg_value[index9].Min = 0.0f;
      Common.cfg_value[index9].Max = 1f;
      Common.cfg_value[index9].Name = "转速有效电平";
      Common.cfg_value[index9].Name_CN = "转速有效电平";
      Common.cfg_value[index9].Name_CN_TW = "轉速有效電位";
      Common.cfg_value[index9].Name_EN = "RPM Electricity";
      Common.cfg_value[index9].Name_Save = "rpm_en";
      Common.cfg_value[index9].Name_0 = "Low";
      Common.cfg_value[index9].Name_1 = "High";
      Common.cfg_value[index9].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index9].num = this.a;
      Common.cfg_value[index9].AddToWidnow((Control) this);
      ++this.a;
      int index10 = 57;
      Common.cfg_value[index10] = new CfgValue(0.0f, true);
      Common.cfg_value[index10].Index = index10;
      Common.cfg_value[index10].Step = 1f;
      Common.cfg_value[index10].Min = 1f;
      Common.cfg_value[index10].Max = 2f;
      Common.cfg_value[index10].Name = "喷嘴1对应通道";
      Common.cfg_value[index10].Name_CN = "喷嘴1对应通道";
      Common.cfg_value[index10].Name_CN_TW = "噴嘴1對應通道";
      Common.cfg_value[index10].Name_EN = "Inject1 Match Chn";
      Common.cfg_value[index10].Name_Save = "inject1_match_rpm";
      Common.cfg_value[index10].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index10].num = this.a;
      Common.cfg_value[index10].AddToWidnow((Control) this);
      ++this.a;
      int index11 = 58;
      Common.cfg_value[index11] = new CfgValue(0.0f, true);
      Common.cfg_value[index11].Index = index11;
      Common.cfg_value[index11].Step = 1f;
      Common.cfg_value[index11].Min = 1f;
      Common.cfg_value[index11].Max = 2f;
      Common.cfg_value[index11].Name = "喷嘴2对应通道";
      Common.cfg_value[index11].Name_CN = "喷嘴2对应通道";
      Common.cfg_value[index11].Name_CN_TW = "噴嘴2對應通道";
      Common.cfg_value[index11].Name_EN = "Inject2 Match Chn";
      Common.cfg_value[index11].Name_Save = "inject2_match_rpm";
      Common.cfg_value[index11].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index11].num = this.a;
      Common.cfg_value[index11].AddToWidnow((Control) this);
      ++this.a;
      int index12 = 94;
      Common.cfg_value[index12] = new CfgValue(0.0f, true);
      Common.cfg_value[index12].Index = index12;
      Common.cfg_value[index12].Step = 1f;
      Common.cfg_value[index12].Min = 0.0f;
      Common.cfg_value[index12].Max = 3f;
      Common.cfg_value[index12].Name = "喷嘴1温度通道";
      Common.cfg_value[index12].Name_CN = "喷嘴1温度通道";
      Common.cfg_value[index12].Name_CN_TW = "噴嘴1溫度通道";
      Common.cfg_value[index12].Name_EN = "Inject1 Temp Chn";
      Common.cfg_value[index12].Name_0 = "None";
      Common.cfg_value[index12].Name_1 = "T1";
      Common.cfg_value[index12].Name_2 = "T1&T2";
      Common.cfg_value[index12].Name_3 = "T5";
      Common.cfg_value[index12].Name_Save = "inject1_match_temp";
      Common.cfg_value[index12].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index12].num = this.a;
      Common.cfg_value[index12].AddToWidnow((Control) this);
      ++this.a;
      int index13 = 95;
      Common.cfg_value[index13] = new CfgValue(0.0f, true);
      Common.cfg_value[index13].Index = index13;
      Common.cfg_value[index13].Step = 1f;
      Common.cfg_value[index13].Min = 0.0f;
      Common.cfg_value[index13].Max = 3f;
      Common.cfg_value[index13].Name = "喷嘴2温度通道";
      Common.cfg_value[index13].Name_CN = "喷嘴2温度通道";
      Common.cfg_value[index13].Name_CN_TW = "噴嘴2溫度通道";
      Common.cfg_value[index13].Name_EN = "Inject2 Temp Chn";
      Common.cfg_value[index13].Name_0 = "None";
      Common.cfg_value[index13].Name_1 = "T3";
      Common.cfg_value[index13].Name_2 = "T3&T4";
      Common.cfg_value[index13].Name_3 = "T6";
      Common.cfg_value[index13].Name_Save = "inject2_match_temp";
      Common.cfg_value[index13].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index13].num = this.a;
      Common.cfg_value[index13].AddToWidnow((Control) this);
      ++this.a;
      int index14 = 78;
      Common.cfg_value[index14] = new CfgValue(0.0f, true);
      Common.cfg_value[index14].Index = index14;
      Common.cfg_value[index14].Step = 1f;
      Common.cfg_value[index14].Min = 0.0f;
      Common.cfg_value[index14].Max = 1000f;
      Common.cfg_value[index14].Name = "转速齿比 ";
      Common.cfg_value[index14].Name_CN = "转速齿比";
      Common.cfg_value[index14].Name_CN_TW = "轉速齒比";
      Common.cfg_value[index14].Name_EN = "Rpm Gear Ratio";
      Common.cfg_value[index14].Name_Save = "rpm_gear_ratio";
      Common.cfg_value[index14].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index14].num = this.a;
      Common.cfg_value[index14].AddToWidnow((Control) this);
      ++this.a;
      int index15 = 84;
      Common.cfg_value[index15] = new CfgValue(0.0f, true);
      Common.cfg_value[index15].Index = index15;
      Common.cfg_value[index15].Step = 1f;
      Common.cfg_value[index15].Min = 0.0f;
      Common.cfg_value[index15].Max = 1f;
      Common.cfg_value[index15].Name = "过温保护使能";
      Common.cfg_value[index15].Name_CN = "过温保护使能";
      Common.cfg_value[index15].Name_CN_TW = "超溫保護功能";
      Common.cfg_value[index15].Name_EN = "Overheat Protect";
      Common.cfg_value[index15].Name_Save = "temp_correct_en";
      Common.cfg_value[index15].Name_0 = "Disable";
      Common.cfg_value[index15].Name_1 = "Enable";
      Common.cfg_value[index15].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index15].num = this.a;
      Common.cfg_value[index15].AddToWidnow((Control) this);
      ++this.a;
      int index16 = 55;
      Common.cfg_value[index16] = new CfgValue(0.0f, true);
      Common.cfg_value[index16].Index = index16;
      Common.cfg_value[index16].Step = 1f;
      Common.cfg_value[index16].Min = 0.0f;
      Common.cfg_value[index16].Max = 1000f;
      Common.cfg_value[index16].Name = "保护温度";
      Common.cfg_value[index16].Name_CN = "限制温度";
      Common.cfg_value[index16].Name_CN_TW = "超溫保護閥值";
      Common.cfg_value[index16].Name_EN = "Overheat Temperature";
      Common.cfg_value[index16].Name_Save = "tmp_limit";
      Common.cfg_value[index16].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index16].num = this.a;
      Common.cfg_value[index16].AddToWidnow((Control) this);
      ++this.a;
      int index17 = 56;
      Common.cfg_value[index17] = new CfgValue(0.0f, true);
      Common.cfg_value[index17].Index = index17;
      Common.cfg_value[index17].Step = 0.01f;
      Common.cfg_value[index17].Min = 0.0f;
      Common.cfg_value[index17].Max = 1f;
      Common.cfg_value[index17].Name = "保护补偿系数";
      Common.cfg_value[index17].Name_CN = "过温保护补偿系数";
      Common.cfg_value[index17].Name_CN_TW = "超溫保護補償係數";
      Common.cfg_value[index17].Name_EN = "Overheat Protect Coe";
      Common.cfg_value[index17].Name_Save = "tmp_coe";
      Common.cfg_value[index17].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index17].num = this.a;
      Common.cfg_value[index17].AddToWidnow((Control) this);
      ++this.a;
      int index18 = 72;
      Common.cfg_value[index18] = new CfgValue(0.0f, true);
      Common.cfg_value[index18].Index = index18;
      Common.cfg_value[index18].Step = 1f;
      Common.cfg_value[index18].Min = 0.0f;
      Common.cfg_value[index18].Max = 1f;
      Common.cfg_value[index18].Name = "温度平衡功能";
      Common.cfg_value[index18].Name_CN = "温度平衡功能";
      Common.cfg_value[index18].Name_CN_TW = "溫度平衡功能";
      Common.cfg_value[index18].Name_EN = "Temp Balance Fun";
      Common.cfg_value[index18].Name_Save = "temp_balance_en";
      Common.cfg_value[index18].Name_0 = "Disable";
      Common.cfg_value[index18].Name_1 = "Enable";
      Common.cfg_value[index18].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index18].num = this.a;
      Common.cfg_value[index18].AddToWidnow((Control) this);
      ++this.a;
      int index19 = 62;
      Common.cfg_value[index19] = new CfgValue(0.0f, true);
      Common.cfg_value[index19].Index = index19;
      Common.cfg_value[index19].Step = 0.01f;
      Common.cfg_value[index19].Min = 0.0f;
      Common.cfg_value[index19].Max = 1f;
      Common.cfg_value[index19].Name = "温度平衡系数";
      Common.cfg_value[index19].Name_CN = "温度平衡系数";
      Common.cfg_value[index19].Name_CN_TW = "溫度平衡係數";
      Common.cfg_value[index19].Name_EN = "Temp Balance Coe";
      Common.cfg_value[index19].Name_Save = "temp_balance_coe";
      Common.cfg_value[index19].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index19].num = this.a;
      Common.cfg_value[index19].AddToWidnow((Control) this);
      ++this.a;
      int index20 = 96;
      Common.cfg_value[index20] = new CfgValue(0.0f, true);
      Common.cfg_value[index20].Index = index20;
      Common.cfg_value[index20].Step = 1f;
      Common.cfg_value[index20].Min = 0.0f;
      Common.cfg_value[index20].Max = 1f;
      Common.cfg_value[index20].Name = "智能油门";
      Common.cfg_value[index20].Name_CN = "智能油门";
      Common.cfg_value[index20].Name_CN_TW = "智慧油門";
      Common.cfg_value[index20].Name_EN = "Smart Throttle";
      Common.cfg_value[index20].Name_Save = "smart_throttle";
      Common.cfg_value[index20].Name_0 = "Disable";
      Common.cfg_value[index20].Name_1 = "Enable";
      Common.cfg_value[index20].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index20].num = this.a;
      Common.cfg_value[index20].AddToWidnow((Control) this);
      ++this.a;
      int index21 = 59;
      Common.cfg_value[index21] = new CfgValue(0.0f, true);
      Common.cfg_value[index21].Index = index21;
      Common.cfg_value[index21].Step = 10f;
      Common.cfg_value[index21].Min = 0.0f;
      Common.cfg_value[index21].Max = 2500f;
      Common.cfg_value[index21].Name = "PWM 输入1最小";
      Common.cfg_value[index21].Name_CN = "PWM输入1最小";
      Common.cfg_value[index21].Name_CN_TW = "PWM輸入1最小";
      Common.cfg_value[index21].Name_EN = "PWM In1 Min";
      Common.cfg_value[index21].Name_Save = "pwm_in1_min";
      Common.cfg_value[index21].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index21].num = this.a;
      Common.cfg_value[index21].AddToWidnow((Control) this);
      ++this.a;
      int index22 = 60;
      Common.cfg_value[index22] = new CfgValue(0.0f, true);
      Common.cfg_value[index22].Index = index22;
      Common.cfg_value[index22].Step = 10f;
      Common.cfg_value[index22].Min = 0.0f;
      Common.cfg_value[index22].Max = 2500f;
      Common.cfg_value[index22].Name = "PWM 输入1最大";
      Common.cfg_value[index22].Name_CN = "PWM输入1最大";
      Common.cfg_value[index22].Name_CN_TW = "PWM輸入1最大";
      Common.cfg_value[index22].Name_EN = "PWM In1 Max";
      Common.cfg_value[index22].Name_Save = "pwm_in1_max";
      Common.cfg_value[index22].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index22].num = this.a;
      Common.cfg_value[index22].AddToWidnow((Control) this);
      ++this.a;
      int index23 = 88;
      Common.cfg_value[index23] = new CfgValue(0.0f, true);
      Common.cfg_value[index23].Index = index23;
      Common.cfg_value[index23].Step = 1f;
      Common.cfg_value[index23].Min = 0.0f;
      Common.cfg_value[index23].Max = 1f;
      Common.cfg_value[index23].Name = "PWM 输入1反向";
      Common.cfg_value[index23].Name_CN = "PWM输入1反向";
      Common.cfg_value[index23].Name_CN_TW = "PWM輸入1反向";
      Common.cfg_value[index23].Name_EN = "PWM In1 Rev";
      Common.cfg_value[index23].Name_Save = "pwm_in1_rev";
      Common.cfg_value[index23].Name_0 = "Disable";
      Common.cfg_value[index23].Name_1 = "Enable";
      Common.cfg_value[index23].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index23].num = this.a;
      Common.cfg_value[index23].AddToWidnow((Control) this);
      ++this.a;
      int index24 = 61;
      Common.cfg_value[index24] = new CfgValue(0.0f, true);
      Common.cfg_value[index24].Index = index24;
      Common.cfg_value[index24].Step = 10f;
      Common.cfg_value[index24].Min = 0.0f;
      Common.cfg_value[index24].Max = 2500f;
      Common.cfg_value[index24].Name = "PWM 输入2最小";
      Common.cfg_value[index24].Name_CN = "PWM输入2最小";
      Common.cfg_value[index24].Name_CN_TW = "PWM輸入2最小";
      Common.cfg_value[index24].Name_EN = "PWM In2 Min";
      Common.cfg_value[index24].Name_Save = "pwm_in2_min";
      Common.cfg_value[index24].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index24].num = this.a;
      Common.cfg_value[index24].AddToWidnow((Control) this);
      ++this.a;
      int index25 = 63;
      Common.cfg_value[index25] = new CfgValue(0.0f, true);
      Common.cfg_value[index25].Index = index25;
      Common.cfg_value[index25].Step = 10f;
      Common.cfg_value[index25].Min = 0.0f;
      Common.cfg_value[index25].Max = 2500f;
      Common.cfg_value[index25].Name = "PWM 输入2最大";
      Common.cfg_value[index25].Name_CN = "PWM输入2最大";
      Common.cfg_value[index25].Name_CN_TW = "PWM輸入2最大";
      Common.cfg_value[index25].Name_EN = "PWM In2 Max";
      Common.cfg_value[index25].Name_Save = "pwm_in2_max";
      Common.cfg_value[index25].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index25].num = this.a;
      Common.cfg_value[index25].AddToWidnow((Control) this);
      ++this.a;
      int index26 = 79;
      Common.cfg_value[index26] = new CfgValue(0.0f, true);
      Common.cfg_value[index26].Index = index26;
      Common.cfg_value[index26].Step = 1f;
      Common.cfg_value[index26].Min = 1f;
      Common.cfg_value[index26].Max = 12f;
      Common.cfg_value[index26].Name = "Sbus油门通道";
      Common.cfg_value[index26].Name_CN = "Sbus油门通道";
      Common.cfg_value[index26].Name_CN_TW = "Sbus油門通道";
      Common.cfg_value[index26].Name_EN = "Sbus Thr Chn";
      Common.cfg_value[index26].Name_Save = "sbus_thr_channel";
      Common.cfg_value[index26].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index26].num = this.a;
      Common.cfg_value[index26].AddToWidnow((Control) this);
      ++this.a;
      int index27 = 80;
      Common.cfg_value[index27] = new CfgValue(0.0f, true);
      Common.cfg_value[index27].Index = index27;
      Common.cfg_value[index27].Step = 1f;
      Common.cfg_value[index27].Min = 1f;
      Common.cfg_value[index27].Max = 12f;
      Common.cfg_value[index27].Name = "Sbus模式通道";
      Common.cfg_value[index27].Name_CN = "Sbus模式通道";
      Common.cfg_value[index27].Name_CN_TW = "Sbus模式通道";
      Common.cfg_value[index27].Name_EN = "Sbus Mode Chn";
      Common.cfg_value[index27].Name_Save = "sbus_mode_channel";
      Common.cfg_value[index27].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index27].num = this.a;
      Common.cfg_value[index27].AddToWidnow((Control) this);
      ++this.a;
      int index28 = 81;
      Common.cfg_value[index28] = new CfgValue(0.0f, true);
      Common.cfg_value[index28].Index = index28;
      Common.cfg_value[index28].Step = 1f;
      Common.cfg_value[index28].Min = 1f;
      Common.cfg_value[index28].Max = 12f;
      Common.cfg_value[index28].Name = "Sbus启动通道";
      Common.cfg_value[index28].Name_CN = "Sbus启动通道";
      Common.cfg_value[index28].Name_CN_TW = "Sbus啟動通道";
      Common.cfg_value[index28].Name_EN = "Sbus Start Chn";
      Common.cfg_value[index28].Name_Save = "sbus_start_channel";
      Common.cfg_value[index28].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index28].num = this.a;
      Common.cfg_value[index28].AddToWidnow((Control) this);
      ++this.a;
      int index29 = 66;
      Common.cfg_value[index29] = new CfgValue(0.0f, true);
      Common.cfg_value[index29].Index = index29;
      Common.cfg_value[index29].Step = 1f;
      Common.cfg_value[index29].Min = 0.0f;
      Common.cfg_value[index29].Max = 1f;
      Common.cfg_value[index29].Name = "PWM输出1模式";
      Common.cfg_value[index29].Name_CN = "PWM输出1模式";
      Common.cfg_value[index29].Name_CN_TW = "PWM輸出1模式";
      Common.cfg_value[index29].Name_EN = "PWM Out1 Mode";
      Common.cfg_value[index29].Name_0 = "H/L";
      Common.cfg_value[index29].Name_1 = "PWM";
      Common.cfg_value[index29].Name_Save = "pwm_out1_mode";
      Common.cfg_value[index29].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index29].num = this.a;
      Common.cfg_value[index29].AddToWidnow((Control) this);
      ++this.a;
      int index30 = 64;
      Common.cfg_value[index30] = new CfgValue(0.0f, true);
      Common.cfg_value[index30].Index = index30;
      Common.cfg_value[index30].Step = 10f;
      Common.cfg_value[index30].Min = 0.0f;
      Common.cfg_value[index30].Max = 2500f;
      Common.cfg_value[index30].Name = "PWM输出1最小";
      Common.cfg_value[index30].Name_CN = "PWM输出1最小";
      Common.cfg_value[index30].Name_CN_TW = "PWM輸出1最小";
      Common.cfg_value[index30].Name_EN = "PWM Out1 Min";
      Common.cfg_value[index30].Name_Save = "pwm_out1_min";
      Common.cfg_value[index30].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index30].num = this.a;
      Common.cfg_value[index30].AddToWidnow((Control) this);
      ++this.a;
      int index31 = 65;
      Common.cfg_value[index31] = new CfgValue(0.0f, true);
      Common.cfg_value[index31].Index = index31;
      Common.cfg_value[index31].Step = 10f;
      Common.cfg_value[index31].Min = 0.0f;
      Common.cfg_value[index31].Max = 2500f;
      Common.cfg_value[index31].Name = "PWM 输出1最大";
      Common.cfg_value[index31].Name_CN = "PWM输出1最大";
      Common.cfg_value[index31].Name_CN_TW = "PWM輸出1最大";
      Common.cfg_value[index31].Name_EN = "PWM Out1 Max";
      Common.cfg_value[index31].Name_Save = "pwm_out1_max";
      Common.cfg_value[index31].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index31].num = this.a;
      Common.cfg_value[index31].AddToWidnow((Control) this);
      ++this.a;
      int index32 = 67;
      Common.cfg_value[index32] = new CfgValue(0.0f, true);
      Common.cfg_value[index32].Index = index32;
      Common.cfg_value[index32].Step = 10f;
      Common.cfg_value[index32].Min = 0.0f;
      Common.cfg_value[index32].Max = 2500f;
      Common.cfg_value[index32].Name = "PWM 输出2最小";
      Common.cfg_value[index32].Name_CN = "PWM输出2最小";
      Common.cfg_value[index32].Name_CN_TW = "PWM輸出2最小";
      Common.cfg_value[index32].Name_EN = "PWM Out2 Min";
      Common.cfg_value[index32].Name_Save = "pwm_out2_min";
      Common.cfg_value[index32].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index32].num = this.a;
      Common.cfg_value[index32].AddToWidnow((Control) this);
      ++this.a;
      int index33 = 68;
      Common.cfg_value[index33] = new CfgValue(0.0f, true);
      Common.cfg_value[index33].Index = index33;
      Common.cfg_value[index33].Step = 10f;
      Common.cfg_value[index33].Min = 0.0f;
      Common.cfg_value[index33].Max = 2500f;
      Common.cfg_value[index33].Name = "PWM 输出2最大";
      Common.cfg_value[index33].Name_CN = "PWM输出2最大";
      Common.cfg_value[index33].Name_CN_TW = "PWM輸出2最大";
      Common.cfg_value[index33].Name_EN = "PWM Out2 Max";
      Common.cfg_value[index33].Name_Save = "pwm_out2_max";
      Common.cfg_value[index33].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index33].num = this.a;
      Common.cfg_value[index33].AddToWidnow((Control) this);
      ++this.a;
      int index34 = 90;
      Common.cfg_value[index34] = new CfgValue(0.0f, true);
      Common.cfg_value[index34].Index = index34;
      Common.cfg_value[index34].Step = 1f;
      Common.cfg_value[index34].Min = 0.0f;
      Common.cfg_value[index34].Max = 1f;
      Common.cfg_value[index34].Name = "PWM输出2反向";
      Common.cfg_value[index34].Name_CN = "PWM输出2反向";
      Common.cfg_value[index34].Name_CN_TW = "PWM輸出2反向";
      Common.cfg_value[index34].Name_EN = "PWM Out2 Rev";
      Common.cfg_value[index34].Name_Save = "pwm_out2_rev";
      Common.cfg_value[index34].Name_0 = "Disable";
      Common.cfg_value[index34].Name_1 = "Enable";
      Common.cfg_value[index34].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index34].num = this.a;
      Common.cfg_value[index34].AddToWidnow((Control) this);
      ++this.a;
      int index35 = 70;
      Common.cfg_value[index35] = new CfgValue(0.0f, true);
      Common.cfg_value[index35].Index = index35;
      Common.cfg_value[index35].Step = 10f;
      Common.cfg_value[index35].Min = 0.0f;
      Common.cfg_value[index35].Max = 2500f;
      Common.cfg_value[index35].Name = "PWM输出3最小";
      Common.cfg_value[index35].Name_CN = "PWM输出3最小";
      Common.cfg_value[index35].Name_CN_TW = "PWM輸出3最小";
      Common.cfg_value[index35].Name_EN = "PWM Out3 Min";
      Common.cfg_value[index35].Name_Save = "pwm_out3_min";
      Common.cfg_value[index35].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index35].num = this.a;
      Common.cfg_value[index35].AddToWidnow((Control) this);
      ++this.a;
      int index36 = 71;
      Common.cfg_value[index36] = new CfgValue(0.0f, true);
      Common.cfg_value[index36].Index = index36;
      Common.cfg_value[index36].Step = 10f;
      Common.cfg_value[index36].Min = 0.0f;
      Common.cfg_value[index36].Max = 2500f;
      Common.cfg_value[index36].Name = "PWM输出3最大";
      Common.cfg_value[index36].Name_CN = "PWM输出3最大";
      Common.cfg_value[index36].Name_CN_TW = "PWM輸出3最大";
      Common.cfg_value[index36].Name_EN = "PWM Out3 Max";
      Common.cfg_value[index36].Name_Save = "pwm_out3_max";
      Common.cfg_value[index36].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index36].num = this.a;
      Common.cfg_value[index36].AddToWidnow((Control) this);
      ++this.a;
      int index37 = 91;
      Common.cfg_value[index37] = new CfgValue(0.0f, true);
      Common.cfg_value[index37].Index = index37;
      Common.cfg_value[index37].Step = 1f;
      Common.cfg_value[index37].Min = 0.0f;
      Common.cfg_value[index37].Max = 1f;
      Common.cfg_value[index37].Name = "PWM输出3反向";
      Common.cfg_value[index37].Name_CN = "PWM输出3反向";
      Common.cfg_value[index37].Name_CN_TW = "PWM輸出3反向";
      Common.cfg_value[index37].Name_EN = "PWM Out3 Rev";
      Common.cfg_value[index37].Name_Save = "pwm_out3_rev";
      Common.cfg_value[index37].Name_0 = "Disable";
      Common.cfg_value[index37].Name_1 = "Enable";
      Common.cfg_value[index37].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index37].num = this.a;
      Common.cfg_value[index37].AddToWidnow((Control) this);
      ++this.a;
      int index38 = 73;
      Common.cfg_value[index38] = new CfgValue(0.0f, true);
      Common.cfg_value[index38].Index = index38;
      Common.cfg_value[index38].Step = 1f;
      Common.cfg_value[index38].Min = -1000f;
      Common.cfg_value[index38].Max = 1000f;
      Common.cfg_value[index38].Name = "PWM输出3 P";
      Common.cfg_value[index38].Name_CN = "PWM输出3 P";
      Common.cfg_value[index38].Name_CN_TW = "PWM輸出3 P";
      Common.cfg_value[index38].Name_EN = "PWM Out3 pid_p";
      Common.cfg_value[index38].Name_Save = "pwm_out3_pid_p";
      Common.cfg_value[index38].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index38].num = this.a;
      Common.cfg_value[index38].AddToWidnow((Control) this);
      ++this.a;
      int index39 = 74;
      Common.cfg_value[index39] = new CfgValue(0.0f, true);
      Common.cfg_value[index39].Index = index39;
      Common.cfg_value[index39].Step = 1f;
      Common.cfg_value[index39].Min = -1000f;
      Common.cfg_value[index39].Max = 1000f;
      Common.cfg_value[index39].Name = "PWM 输出3 I";
      Common.cfg_value[index39].Name_CN = "PWM输出3 I";
      Common.cfg_value[index39].Name_CN_TW = "PWM輸出3 I";
      Common.cfg_value[index39].Name_EN = "PWM Out3 pid_i";
      Common.cfg_value[index39].Name_Save = "pwm_out3_pid_i";
      Common.cfg_value[index39].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index39].num = this.a;
      Common.cfg_value[index39].AddToWidnow((Control) this);
      ++this.a;
      int index40 = 76;
      Common.cfg_value[index40] = new CfgValue(0.0f, true);
      Common.cfg_value[index40].Index = index40;
      Common.cfg_value[index40].Step = 1f;
      Common.cfg_value[index40].Min = 0.0f;
      Common.cfg_value[index40].Max = 250f;
      Common.cfg_value[index40].Name = "环境目标温度";
      Common.cfg_value[index40].Name_CN = "环境目标温度";
      Common.cfg_value[index40].Name_CN_TW = "環境目標溫度";
      Common.cfg_value[index40].Name_EN = "Target Temp";
      Common.cfg_value[index40].Name_Save = "pwm_out3_target_temp";
      Common.cfg_value[index40].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index40].num = this.a;
      Common.cfg_value[index40].AddToWidnow((Control) this);
      ++this.a;
      int index41 = 77;
      Common.cfg_value[index41] = new CfgValue(0.0f, true);
      Common.cfg_value[index41].Index = index41;
      Common.cfg_value[index41].Step = 1f;
      Common.cfg_value[index41].Min = 0.0f;
      Common.cfg_value[index41].Max = 6f;
      Common.cfg_value[index41].Name = "环境温度通道";
      Common.cfg_value[index41].Name_CN = "环境温度通道";
      Common.cfg_value[index41].Name_CN_TW = "環境溫度通道";
      Common.cfg_value[index41].Name_EN = "Temp Chn";
      Common.cfg_value[index41].Name_0 = "None";
      Common.cfg_value[index41].Name_1 = "T1";
      Common.cfg_value[index41].Name_2 = "T2";
      Common.cfg_value[index41].Name_3 = "T3";
      Common.cfg_value[index41].Name_4 = "T4";
      Common.cfg_value[index41].Name_5 = "T5";
      Common.cfg_value[index41].Name_6 = "T6";
      Common.cfg_value[index41].Name_Save = "pwm_out3_temp_channel";
      Common.cfg_value[index41].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index41].num = this.a;
      Common.cfg_value[index41].AddToWidnow((Control) this);
      ++this.a;
      int index42 = 93;
      Common.cfg_value[index42] = new CfgValue(0.0f, true);
      Common.cfg_value[index42].Index = index42;
      Common.cfg_value[index42].Step = 1f;
      Common.cfg_value[index42].Min = 0.0f;
      Common.cfg_value[index42].Max = 1f;
      Common.cfg_value[index42].Name = "PWM调压泵";
      Common.cfg_value[index42].Name_CN = "PWM调压泵";
      Common.cfg_value[index42].Name_CN_TW = "PWM調壓泵";
      Common.cfg_value[index42].Name_EN = "Regulating Pump";
      Common.cfg_value[index42].Name_Save = "pwm_pump";
      Common.cfg_value[index42].Name_0 = "Disable";
      Common.cfg_value[index42].Name_1 = "Enable";
      Common.cfg_value[index42].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index42].num = this.a;
      Common.cfg_value[index42].AddToWidnow((Control) this);
      ++this.a;
      int index43 = 101;
      Common.cfg_value[index43] = new CfgValue(0.0f, true);
      Common.cfg_value[index43].Index = index43;
      Common.cfg_value[index43].Step = 1f;
      Common.cfg_value[index43].Min = -1000f;
      Common.cfg_value[index43].Max = 1000f;
      Common.cfg_value[index43].Name = "PWM输出2 P";
      Common.cfg_value[index43].Name_CN = "PWM输出2 P";
      Common.cfg_value[index43].Name_CN_TW = "PWM輸出2 P";
      Common.cfg_value[index43].Name_EN = "PWM Out2 pid_p";
      Common.cfg_value[index43].Name_Save = "pwm_out2_pid_p";
      Common.cfg_value[index43].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index43].num = this.a;
      Common.cfg_value[index43].AddToWidnow((Control) this);
      ++this.a;
      int index44 = 102;
      Common.cfg_value[index44] = new CfgValue(0.0f, true);
      Common.cfg_value[index44].Index = index44;
      Common.cfg_value[index44].Step = 1f;
      Common.cfg_value[index44].Min = -1000f;
      Common.cfg_value[index44].Max = 1000f;
      Common.cfg_value[index44].Name = "PWM 输出2 I";
      Common.cfg_value[index44].Name_CN = "PWM输出2 I";
      Common.cfg_value[index44].Name_CN_TW = "PWM輸出2 I";
      Common.cfg_value[index44].Name_EN = "PWM Out2 pid_i";
      Common.cfg_value[index44].Name_Save = "pwm_out2_pid_i";
      Common.cfg_value[index44].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index44].num = this.a;
      Common.cfg_value[index44].AddToWidnow((Control) this);
      ++this.a;
      int index45 = 98;
      Common.cfg_value[index45] = new CfgValue(0.0f, true);
      Common.cfg_value[index45].Index = index45;
      Common.cfg_value[index45].Step = 0.1f;
      Common.cfg_value[index45].Min = 0.0f;
      Common.cfg_value[index45].Max = 10f;
      Common.cfg_value[index45].Name = "油压最低电压";
      Common.cfg_value[index45].Name_CN = "油压最低电压";
      Common.cfg_value[index45].Name_CN_TW = "油壓最低電壓";
      Common.cfg_value[index45].Name_EN = "Min Fuel Pre Vol";
      Common.cfg_value[index45].Name_Save = "min_oil_v";
      Common.cfg_value[index45].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index45].num = this.a;
      Common.cfg_value[index45].AddToWidnow((Control) this);
      ++this.a;
      int index46 = 99;
      Common.cfg_value[index46] = new CfgValue(0.0f, true);
      Common.cfg_value[index46].Index = index46;
      Common.cfg_value[index46].Step = 0.1f;
      Common.cfg_value[index46].Min = 0.0f;
      Common.cfg_value[index46].Max = 10f;
      Common.cfg_value[index46].Name = "油压最高电压";
      Common.cfg_value[index46].Name_CN = "油压最高电压";
      Common.cfg_value[index46].Name_CN_TW = "油壓最高電壓";
      Common.cfg_value[index46].Name_EN = "Max Fuel Pre Vol";
      Common.cfg_value[index46].Name_Save = "max_oil_v";
      Common.cfg_value[index46].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index46].num = this.a;
      Common.cfg_value[index46].AddToWidnow((Control) this);
      ++this.a;
      int index47 = 100;
      Common.cfg_value[index47] = new CfgValue(0.0f, true);
      Common.cfg_value[index47].Index = index47;
      Common.cfg_value[index47].Step = 0.1f;
      Common.cfg_value[index47].Min = 0.0f;
      Common.cfg_value[index47].Max = 10f;
      Common.cfg_value[index47].Name = "最大油压";
      Common.cfg_value[index47].Name_CN = "最大油压";
      Common.cfg_value[index47].Name_CN_TW = "最大油壓";
      Common.cfg_value[index47].Name_EN = "Max Fuel Pre";
      Common.cfg_value[index47].Name_Save = "max_oil_pre";
      Common.cfg_value[index47].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index47].num = this.a;
      Common.cfg_value[index47].AddToWidnow((Control) this);
      ++this.a;
      int index48 = 92;
      Common.cfg_value[index48] = new CfgValue(0.0f, true);
      Common.cfg_value[index48].Index = index48;
      Common.cfg_value[index48].Step = 1f;
      Common.cfg_value[index48].Min = 0.0f;
      Common.cfg_value[index48].Max = 6f;
      Common.cfg_value[index48].Name = "位置传感器";
      Common.cfg_value[index48].Name_CN = "位置传感器";
      Common.cfg_value[index48].Name_CN_TW = "位置感測器";
      Common.cfg_value[index48].Name_EN = "Position Sensor";
      Common.cfg_value[index48].Name_Save = "inject_mach_position_sensor";
      Common.cfg_value[index48].Name_0 = "Disable";
      Common.cfg_value[index48].Name_1 = "S1";
      Common.cfg_value[index48].Name_2 = "S2";
      Common.cfg_value[index48].Name_3 = "S1&S2";
      Common.cfg_value[index48].Name_4 = "S1_M";
      Common.cfg_value[index48].Name_5 = "S2_M";
      Common.cfg_value[index48].Name_6 = "S1&S2_M";
      Common.cfg_value[index48].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index48].num = this.a;
      Common.cfg_value[index48].AddToWidnow((Control) this);
      ++this.a;
      int index49 = 82;
      Common.cfg_value[index49] = new CfgValue(0.0f, true);
      Common.cfg_value[index49].Index = index49;
      Common.cfg_value[index49].Step = 1f;
      Common.cfg_value[index49].Min = -1f;
      Common.cfg_value[index49].Max = 1000f;
      Common.cfg_value[index49].Name = "保养时间(h)";
      Common.cfg_value[index49].Name_CN = "保养时间(h)";
      Common.cfg_value[index49].Name_CN_TW = "保養時間(h)";
      Common.cfg_value[index49].Name_EN = "Maintenance Hour";
      Common.cfg_value[index49].Name_Save = "maintenance_hor";
      Common.cfg_value[index49].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index49].num = this.a;
      Common.cfg_value[index49].AddToWidnow((Control) this);
      ++this.a;
      int index50 = 89;
      Common.cfg_value[index50] = new CfgValue(0.0f, true);
      Common.cfg_value[index50].Index = index50;
      Common.cfg_value[index50].Step = 1f;
      Common.cfg_value[index50].Min = 0.0f;
      Common.cfg_value[index50].Max = 1f;
      Common.cfg_value[index50].Name = "使用标定喷嘴";
      Common.cfg_value[index50].Name_CN = "喷嘴设置";
      Common.cfg_value[index50].Name_CN_TW = "噴嘴設定";
      Common.cfg_value[index50].Name_EN = "Injection Setting";
      Common.cfg_value[index50].Name_Save = "jet_cab_en";
      Common.cfg_value[index50].Name_0 = "Default";
      Common.cfg_value[index50].Name_1 = "Custom";
      Common.cfg_value[index50].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index50].num = this.a;
      Common.cfg_value[index50].AddToWidnow((Control) this);
      ++this.a;
      int index51 = 45;
      Common.cfg_value[index51] = new CfgValue(0.0f, true);
      Common.cfg_value[index51].Index = index51;
      Common.cfg_value[index51].Step = 0.01f;
      Common.cfg_value[index51].Min = 0.0f;
      Common.cfg_value[index51].Max = 500f;
      Common.cfg_value[index51].Name = "1.0ms喷油量";
      Common.cfg_value[index51].Name_CN = "1.0ms喷油量";
      Common.cfg_value[index51].Name_CN_TW = "1.0ms噴油量";
      Common.cfg_value[index51].Name_EN = "1.0ms Weight";
      Common.cfg_value[index51].Name_Save = "jet_wgt_ms1";
      Common.cfg_value[index51].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index51].num = this.a;
      Common.cfg_value[index51].AddToWidnow((Control) this);
      ++this.a;
      int index52 = 46;
      Common.cfg_value[index52] = new CfgValue(0.0f, true);
      Common.cfg_value[index52].Index = index52;
      Common.cfg_value[index52].Step = 0.01f;
      Common.cfg_value[index52].Min = 0.0f;
      Common.cfg_value[index52].Max = 500f;
      Common.cfg_value[index52].Name = "1.2ms喷油量";
      Common.cfg_value[index52].Name_CN = "1.2ms喷油量";
      Common.cfg_value[index52].Name_CN_TW = "1.2ms噴油量";
      Common.cfg_value[index52].Name_EN = "1.2ms Weight";
      Common.cfg_value[index52].Name_Save = "jet_wgt_ms2";
      Common.cfg_value[index52].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index52].num = this.a;
      Common.cfg_value[index52].AddToWidnow((Control) this);
      ++this.a;
      int index53 = 47;
      Common.cfg_value[index53] = new CfgValue(0.0f, true);
      Common.cfg_value[index53].Index = index53;
      Common.cfg_value[index53].Step = 0.01f;
      Common.cfg_value[index53].Min = 0.0f;
      Common.cfg_value[index53].Max = 500f;
      Common.cfg_value[index53].Name = "1.5ms喷油量";
      Common.cfg_value[index53].Name_CN = "1.5ms喷油量";
      Common.cfg_value[index53].Name_CN_TW = "1.5ms噴油量";
      Common.cfg_value[index53].Name_EN = "1.5ms Weight";
      Common.cfg_value[index53].Name_Save = "jet_wgt_ms3";
      Common.cfg_value[index53].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index53].num = this.a;
      Common.cfg_value[index53].AddToWidnow((Control) this);
      ++this.a;
      int index54 = 48;
      Common.cfg_value[index54] = new CfgValue(0.0f, true);
      Common.cfg_value[index54].Index = index54;
      Common.cfg_value[index54].Step = 0.01f;
      Common.cfg_value[index54].Min = 0.0f;
      Common.cfg_value[index54].Max = 500f;
      Common.cfg_value[index54].Name = "2.0ms喷油量";
      Common.cfg_value[index54].Name_CN = "2.0ms喷油量";
      Common.cfg_value[index54].Name_CN_TW = "2.0ms噴油量";
      Common.cfg_value[index54].Name_EN = "2.0ms Weight";
      Common.cfg_value[index54].Name_Save = "jet_wgt_ms4";
      Common.cfg_value[index54].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index54].num = this.a;
      Common.cfg_value[index54].AddToWidnow((Control) this);
      ++this.a;
      int index55 = 49;
      Common.cfg_value[index55] = new CfgValue(0.0f, true);
      Common.cfg_value[index55].Index = index55;
      Common.cfg_value[index55].Step = 0.01f;
      Common.cfg_value[index55].Min = 0.0f;
      Common.cfg_value[index55].Max = 500f;
      Common.cfg_value[index55].Name = "5.0ms喷油量";
      Common.cfg_value[index55].Name_CN = "5.0ms喷油量";
      Common.cfg_value[index55].Name_CN_TW = "5.0ms噴油量";
      Common.cfg_value[index55].Name_EN = "5.0ms Weight";
      Common.cfg_value[index55].Name_Save = "jet_wgt_ms5";
      Common.cfg_value[index55].Loc = this.get_loc(row, this.a);
      Common.cfg_value[index55].num = this.a;
      Common.cfg_value[index55].AddToWidnow((Control) this);
      ++this.a;
    }

    private void Cfg_Base_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
    }

    private void buttonUpload_Click(object sender, EventArgs e)
    {
      for (int index = 45; index <= 102; ++index)
      {
        if (Common.cfg_value[index].SignWrite && !Common.cfg_value[index].NeedRead)
          Common.cfg_value[index].WriteValueRequest();
      }
    }

    private void buttonDownload_Click(object sender, EventArgs e)
    {
      for (int index = 45; index <= 102; ++index)
      {
        if (Common.cfg_value[index].Index != 0)
          Common.cfg_value[index].ReadValueRequest();
      }
    }

    private void btn_select_inj_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = Application.StartupPath + "\\InjectData";
        openFileDialog.Filter = "(*.jet)|*.jet";
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        if (this.ImportConfig(openFileDialog.FileName))
        {
          this.label_jet_name.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
        }
        else
        {
          int num = (int) MessageBox.Show(openFileDialog.FileName + "\r\n打开失败");
        }
      }
    }

    public void FindJetName()
    {
      try
      {
        string[] files = Directory.GetFiles(Application.StartupPath + "\\InjectData", "*.jet");
        int num = 0;
        for (int index1 = 0; index1 < files.Length; ++index1)
        {
          string path = files[index1];
          if (File.Exists(path))
          {
            try
            {
              foreach (string readAllLine in File.ReadAllLines(path))
              {
                char[] chArray = new char[1]{ '\t' };
                string[] strArray = readAllLine.Split(chArray);
                if (strArray.Length == 2)
                {
                  for (int index2 = 45; index2 <= 49; ++index2)
                  {
                    if (strArray[0] == Common.cfg_value[index2].Name_Save)
                    {
                      if (Common.cfg_value[index2].Name_Save != "" && Common.cfg_value[index2].Index != 0)
                      {
                        if ((double) Convert.ToSingle(strArray[1]) != (double) Common.cfg_value[index2].Value)
                        {
                          this.label_jet_name.Text = "...";
                          break;
                        }
                        ++num;
                        break;
                      }
                      break;
                    }
                  }
                }
              }
              if (num == 5)
              {
                this.label_jet_name.Text = Path.GetFileNameWithoutExtension(files[index1]);
                break;
              }
            }
            catch
            {
            }
          }
        }
      }
      catch
      {
      }
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
            for (int index = 0; index <= 102; ++index)
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

    private void Cfg_Base_Load(object sender, EventArgs e)
    {
    }

    public static void DrawRoundRectangle(Graphics g, Pen pen, Rectangle rect, int cornerRadius)
    {
      using (GraphicsPath roundedRectanglePath = Cfg_Base.CreateRoundedRectanglePath(rect, cornerRadius))
        g.DrawPath(pen, roundedRectanglePath);
    }

    public static void FillRoundRectangle(
      Graphics g,
      Brush brush,
      Rectangle rect,
      int cornerRadius)
    {
      using (GraphicsPath roundedRectanglePath = Cfg_Base.CreateRoundedRectanglePath(rect, cornerRadius))
        g.FillPath(brush, roundedRectanglePath);
    }

    internal static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
    {
      GraphicsPath roundedRectanglePath = new GraphicsPath();
      roundedRectanglePath.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180f, 90f);
      roundedRectanglePath.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
      roundedRectanglePath.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270f, 90f);
      roundedRectanglePath.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
      roundedRectanglePath.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0.0f, 90f);
      roundedRectanglePath.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
      roundedRectanglePath.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90f, 90f);
      roundedRectanglePath.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
      roundedRectanglePath.CloseFigure();
      return roundedRectanglePath;
    }

    private void MyDrawRoundRect(Graphics g, int num_l, int num_s, int num_e)
    {
      int x = 20 + (num_l - 1) * 300;
      int y = 6 + (num_s - 1) * 30;
      Pen pen = new Pen(Color.Green, 2f);
      Cfg_Base.DrawRoundRectangle(g, pen, new Rectangle(x, y, 270, (num_e - num_s + 1) * 30 - 3), 15);
    }

    private void Cfg_Base_Paint(object sender, PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;
      this.MyDrawRoundRect(graphics, 1, 1, 4);
      this.MyDrawRoundRect(graphics, 1, 5, 8);
      this.MyDrawRoundRect(graphics, 1, 9, 14);
      this.MyDrawRoundRect(graphics, 1, 15, 19);
      this.MyDrawRoundRect(graphics, 2, 1, 4);
      this.MyDrawRoundRect(graphics, 2, 5, 6);
      this.MyDrawRoundRect(graphics, 2, 7, 9);
      this.MyDrawRoundRect(graphics, 2, 10, 12);
      this.MyDrawRoundRect(graphics, 2, 13, 15);
      this.MyDrawRoundRect(graphics, 2, 16, 19);
      this.MyDrawRoundRect(graphics, 3, 1, 3);
      this.MyDrawRoundRect(graphics, 3, 4, 9);
      this.MyDrawRoundRect(graphics, 3, 10, 11);
      this.MyDrawRoundRect(graphics, 3, 12, 17);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Cfg_Base));
      this.groupBox3 = new GroupBox();
      this.buttonUpload = new Button();
      this.buttonDownload = new Button();
      this.groupBox4 = new GroupBox();
      this.label_jet_name = new Label();
      this.btn_select_inj = new Button();
      this.groupBox3.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.SuspendLayout();
      this.groupBox3.Controls.Add((Control) this.buttonUpload);
      this.groupBox3.Controls.Add((Control) this.buttonDownload);
      componentResourceManager.ApplyResources((object) this.groupBox3, "groupBox3");
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.TabStop = false;
      componentResourceManager.ApplyResources((object) this.buttonUpload, "buttonUpload");
      this.buttonUpload.Name = "buttonUpload";
      this.buttonUpload.UseVisualStyleBackColor = true;
      this.buttonUpload.Click += new EventHandler(this.buttonUpload_Click);
      componentResourceManager.ApplyResources((object) this.buttonDownload, "buttonDownload");
      this.buttonDownload.Name = "buttonDownload";
      this.buttonDownload.UseVisualStyleBackColor = true;
      this.buttonDownload.Click += new EventHandler(this.buttonDownload_Click);
      this.groupBox4.Controls.Add((Control) this.label_jet_name);
      this.groupBox4.Controls.Add((Control) this.btn_select_inj);
      componentResourceManager.ApplyResources((object) this.groupBox4, "groupBox4");
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.TabStop = false;
      componentResourceManager.ApplyResources((object) this.label_jet_name, "label_jet_name");
      this.label_jet_name.Name = "label_jet_name";
      componentResourceManager.ApplyResources((object) this.btn_select_inj, "btn_select_inj");
      this.btn_select_inj.Name = "btn_select_inj";
      this.btn_select_inj.UseVisualStyleBackColor = true;
      this.btn_select_inj.Click += new EventHandler(this.btn_select_inj_Click);
      this.AcceptButton = (IButtonControl) this.buttonUpload;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.groupBox4);
      this.Controls.Add((Control) this.groupBox3);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.Name = nameof (Cfg_Base);
      this.FormClosing += new FormClosingEventHandler(this.Cfg_Base_FormClosing);
      this.Load += new EventHandler(this.Cfg_Base_Load);
      this.Paint += new PaintEventHandler(this.Cfg_Base_Paint);
      this.groupBox3.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
