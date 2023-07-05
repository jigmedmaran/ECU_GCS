// Decompiled with JetBrains decompiler
// Type: ECU_GCS.C0_Request_Null
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.Runtime.InteropServices;

namespace ECU_GCS
{
  public static class C0_Request_Null
  {
    public static T0_Request_Null Data;
    public static byte Type = 0;
    public static int Length = Marshal.SizeOf<T0_Request_Null>(C0_Request_Null.Data);
    public static DateTime RecTime = DateTime.MinValue;
  }
}
