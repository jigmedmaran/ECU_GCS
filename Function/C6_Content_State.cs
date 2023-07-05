// Decompiled with JetBrains decompiler
// Type: ECU_GCS.C6_Content_State
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.Runtime.InteropServices;

namespace ECU_GCS
{
  public static class C6_Content_State
  {
    public static T6_Content_State Data;
    public static byte Type = 6;
    public static int Length = Marshal.SizeOf<T6_Content_State>(C6_Content_State.Data);
    public static DateTime RecTime = DateTime.MinValue;
  }
}
