﻿// Decompiled with JetBrains decompiler
// Type: ECU_GCS.C7_Request_Config
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.Runtime.InteropServices;

namespace ECU_GCS
{
  public static class C7_Request_Config
  {
    public static T7_Request_Config Data;
    public static byte Type = 7;
    public static int Length = Marshal.SizeOf<T7_Request_Config>(C7_Request_Config.Data);
    public static DateTime RecTime = DateTime.MinValue;
  }
}
