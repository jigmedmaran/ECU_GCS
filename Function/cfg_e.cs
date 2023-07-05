// Decompiled with JetBrains decompiler
// Type: ECU_GCS.cfg_e
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

namespace ECU_GCS
{
  internal enum cfg_e
  {
    cfg_oil1_thr0 = 1,
    cfg_oil1_thr10 = 2,
    cfg_oil1_thr20 = 3,
    cfg_oil1_thr30 = 4,
    cfg_oil1_thr40 = 5,
    cfg_oil1_thr50 = 6,
    cfg_oil1_thr60 = 7,
    cfg_oil1_thr70 = 8,
    cfg_oil1_thr80 = 9,
    cfg_oil1_thr90 = 10, // 0x0000000A
    cfg_oil1_thr100 = 11, // 0x0000000B
    cfg_oil2_thr0 = 12, // 0x0000000C
    cfg_oil2_thr10 = 13, // 0x0000000D
    cfg_oil2_thr20 = 14, // 0x0000000E
    cfg_oil2_thr30 = 15, // 0x0000000F
    cfg_oil2_thr40 = 16, // 0x00000010
    cfg_oil2_thr50 = 17, // 0x00000011
    cfg_oil2_thr60 = 18, // 0x00000012
    cfg_oil2_thr70 = 19, // 0x00000013
    cfg_oil2_thr80 = 20, // 0x00000014
    cfg_oil2_thr90 = 21, // 0x00000015
    cfg_oil2_thr100 = 22, // 0x00000016
    cfg_exp_thr0 = 23, // 0x00000017
    cfg_exp_thr10 = 24, // 0x00000018
    cfg_exp_thr20 = 25, // 0x00000019
    cfg_exp_thr30 = 26, // 0x0000001A
    cfg_exp_thr40 = 27, // 0x0000001B
    cfg_exp_thr50 = 28, // 0x0000001C
    cfg_exp_thr60 = 29, // 0x0000001D
    cfg_exp_thr70 = 30, // 0x0000001E
    cfg_exp_thr80 = 31, // 0x0000001F
    cfg_exp_thr90 = 32, // 0x00000020
    cfg_exp_thr100 = 33, // 0x00000021
    oil_pre_thr0 = 34, // 0x00000022
    oil_pre_thr10 = 35, // 0x00000023
    oil_pre_thr20 = 36, // 0x00000024
    oil_pre_thr30 = 37, // 0x00000025
    oil_pre_thr40 = 38, // 0x00000026
    oil_pre_thr50 = 39, // 0x00000027
    oil_pre_thr60 = 40, // 0x00000028
    oil_pre_thr70 = 41, // 0x00000029
    oil_pre_thr80 = 42, // 0x0000002A
    oil_pre_thr90 = 43, // 0x0000002B
    oil_pre_thr100 = 44, // 0x0000002C
    jet_wgt_ms1 = 45, // 0x0000002D
    jet_wgt_ms2 = 46, // 0x0000002E
    jet_wgt_ms3 = 47, // 0x0000002F
    jet_wgt_ms4 = 48, // 0x00000030
    jet_wgt_ms5 = 49, // 0x00000031
    cfg_servo_pwm_min = 50, // 0x00000032
    cfg_servo_pwm_max = 51, // 0x00000033
    cfg_oil_forward_ms = 52, // 0x00000034
    idle_thr = 53, // 0x00000035
    cfg_extra_factor = 54, // 0x00000036
    tmp_limit = 55, // 0x00000037
    tmp_coe = 56, // 0x00000038
    inject1_match_rpm = 57, // 0x00000039
    inject2_match_rpm = 58, // 0x0000003A
    pwm_in1_min = 59, // 0x0000003B
    pwm_in1_max = 60, // 0x0000003C
    pwm_in2_min = 61, // 0x0000003D
    temp_balance_coe = 62, // 0x0000003E
    pwm_in2_max = 63, // 0x0000003F
    pwm_out1_min = 64, // 0x00000040
    pwm_out1_max = 65, // 0x00000041
    pwm_out1_mode = 66, // 0x00000042
    pwm_out2_min = 67, // 0x00000043
    pwm_out2_max = 68, // 0x00000044
    oil_total_coe = 69, // 0x00000045
    pwm_out3_min = 70, // 0x00000046
    pwm_out3_max = 71, // 0x00000047
    temp_balance_en = 72, // 0x00000048
    pwm_out3_pid_p = 73, // 0x00000049
    pwm_out3_pid_i = 74, // 0x0000004A
    pwm_out3_pid_d = 75, // 0x0000004B
    pwm_out3_target_temp = 76, // 0x0000004C
    pwm_out3_temp_channel = 77, // 0x0000004D
    rpm_gear_ratio = 78, // 0x0000004E
    sbus_thr_channel = 79, // 0x0000004F
    sbus_mode_channel = 80, // 0x00000050
    sbus_start_channel = 81, // 0x00000051
    maintenance_hor = 82, // 0x00000052
    rpm_en = 83, // 0x00000053
    temp_correct_en = 84, // 0x00000054
    pre_correct_en = 85, // 0x00000055
    cfg_oil_cnt = 86, // 0x00000056
    cfg_servo_pwm_rev = 87, // 0x00000057
    pwm_in1_rev = 88, // 0x00000058
    jet_cab_en = 89, // 0x00000059
    pwm_out2_rev = 90, // 0x0000005A
    pwm_out3_rev = 91, // 0x0000005B
    inject_mach_position_sensor = 92, // 0x0000005C
    reserveb1 = 93, // 0x0000005D
    reserveb2 = 94, // 0x0000005E
    reserveb3 = 95, // 0x0000005F
    smart_thr = 96, // 0x00000060
    reserveb5 = 97, // 0x00000061
    reserveb6 = 98, // 0x00000062
    reserveb7 = 99, // 0x00000063
    reserveb8 = 100, // 0x00000064
    reserveb9 = 101, // 0x00000065
    reserveb10 = 102, // 0x00000066
  }
}
