// Decompiled with JetBrains decompiler
// Type: ECU_GCS.T2_Content_Common
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System.Runtime.InteropServices;

namespace ECU_GCS
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct T2_Content_Common
  {
    public byte header0;
    public byte header1;
    public byte source;
    public byte target;
    public byte type;
    public byte num;
    public uint id;
    public byte ack;
    public byte mode;
    public byte sta;
    public byte sta1;
    public byte bus_thr;
    public byte svr_pwm;
    public ushort rpm_out;
    public ushort rpm1;
    public ushort rpm2;
    public short tmp_env;
    public short tmp0;
    public short tmp1;
    public short tmp2;
    public short tmp3;
    public ushort vol_power;
    public byte vol_svr;
    public byte vol_pump;
    public byte amp_pump;
    public byte madc1;
    public byte madc2;
    public float pre_gas;
    public short pre_alt;
    public byte PWM_IN1;
    public byte PWM_IN2;
    public byte PWM_IN3;
    public byte PWM_OUT1;
    public byte PWM_OUT2;
    public byte PWM_OUT3;
    public float pre_oil;
    public ushort inj1_ms;
    public ushort inj2_ms;
    public ushort inj1_mg;
    public ushort inj2_mg;
    public byte oil1_thr;
    public byte oil2_thr;
    public uint eng_run_time;
    public ushort err_flg;
    public byte yuliu0;
    public byte yuliu1;
    public byte yuliu2;
    public byte yuliu3;
    public short tmp4;
    public short tmp5;
    public byte chk0;
    public byte chk1;
    public byte end0;
    public byte end1;
  }
}
