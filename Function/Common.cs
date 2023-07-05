// Decompiled with JetBrains decompiler
// Type: ECU_GCS.Common
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

namespace ECU_GCS
{
  public static class Common
  {
    public static Agreement Agreement = new Agreement();
    public static SerialPortManager SerialManager = new SerialPortManager();
    public static CfgValue[] cfg_value = new CfgValue[103];
    public static CfgManager cfg_manager = new CfgManager();
    public static SpeakWarningMessage SpeakWarningMessage = new SpeakWarningMessage();
    public static Cfg_Base Cfg_BaseTool = new Cfg_Base();
    public static ConfigWindow ConfigTool = new ConfigWindow();
    public static FuelPreTest FuelPreTestTool = new FuelPreTest();
    public static JetCalib JetCalibTool = new JetCalib();
    public static MessageControl MessageTool = new MessageControl();
    public static CommandControl CommandTool = new CommandControl();
    public static CommandControl CommandTool2 = new CommandControl();
    public static DataReplayWindow DataReplayTool = new DataReplayWindow();
    public static StateWindow StateTool = new StateWindow();
    public static AdcCalib AdcCalibTool = new AdcCalib();

    public static string StatusStr { get; set; }
  }
}
