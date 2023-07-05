// Decompiled with JetBrains decompiler
// Type: ECU_GCS.Agreement_Helper
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.Runtime.InteropServices;

namespace ECU_GCS
{
  public static class Agreement_Helper
  {
    public static void BytesToStruct(byte[] bytearray, ref object obj, int startoffset)
    {
      int num1 = Marshal.SizeOf(obj);
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      obj = Marshal.PtrToStructure(num2, obj.GetType());
      Marshal.Copy(bytearray, startoffset, num2, num1);
      obj = Marshal.PtrToStructure(num2, obj.GetType());
      Marshal.FreeHGlobal(num2);
    }

    public static byte[] StructToBytes(object structObj)
    {
      int length = Marshal.SizeOf(structObj);
      byte[] destination = new byte[length];
      IntPtr num = Marshal.AllocHGlobal(length);
      Marshal.StructureToPtr(structObj, num, false);
      Marshal.Copy(num, destination, 0, length);
      Marshal.FreeHGlobal(num);
      return destination;
    }
  }
}
