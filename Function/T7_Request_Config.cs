// Decompiled with JetBrains decompiler
// Type: ECU_GCS.T7_Request_Config
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System.Runtime.InteropServices;

namespace ECU_GCS
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct T7_Request_Config
  {
    public byte header0;
    public byte header1;
    public byte source;
    public byte target;
    public byte type;
    public byte num;
    public uint id;
    public byte ack;
    public byte index;
    public byte chk0;
    public byte chk1;
    public byte end0;
    public byte end1;
  }
}
