// Decompiled with JetBrains decompiler
// Type: ECU_GCS.Agreement
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.Collections.Generic;
using System.Management;

namespace ECU_GCS
{
  public class Agreement
  {
    private List<byte> buffer = new List<byte>();
    private DateTime recTime = new DateTime();
    private byte recType = 0;
    private uint recCount = 0;
    private uint sendId = 40086487;

    public DateTime RecTime => this.recTime;

    public byte RecType => this.recType;

    public uint RecCount => this.recCount;

    public uint SendId => this.sendId;

    public void InitSendID()
    {
      foreach (ManagementObject instance in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
      {
        if ((bool) instance["IPEnabled"])
        {
          string[] strArray = instance["MacAddress"].ToString().Split(new char[3]
          {
            ':',
            ',',
            ' '
          }, StringSplitOptions.RemoveEmptyEntries);
          List<byte> byteList = new List<byte>();
          for (int index = 0; index < strArray.Length; ++index)
            this.sendId = (uint) ((ulong) this.sendId ^ (ulong) ((int) Convert.ToByte(strArray[index], 16) << index * 8));
        }
      }
    }

    public void UpdateData(byte[] bytes)
    {
      this.buffer.AddRange((IEnumerable<byte>) bytes);
      while (this.buffer.Count > 14)
      {
        if (this.buffer[0] != (byte) 181 || this.buffer[1] != (byte) 98 || this.buffer[2] != (byte) 161 || this.buffer[3] != (byte) 195 || this.buffer[5] < (byte) 15 || this.buffer[10] != (byte) 80)
        {
          this.buffer.RemoveAt(0);
        }
        else
        {
          if (this.buffer.Count < (int) this.buffer[5])
            break;
          if (this.buffer[(int) this.buffer[5] - 2] != (byte) 13 || this.buffer[(int) this.buffer[5] - 1] != (byte) 10)
          {
            this.buffer.RemoveAt(0);
          }
          else
          {
            this.recTime = DateTime.Now;
            this.recType = this.buffer[4];
            ++this.recCount;
            if ((int) this.recType == (int) C2_Content_Common.Type && this.buffer.Count >= C2_Content_Common.Length)
            {
              this.buffer.CopyTo(0, C2_Content_Common.Bin, 0, C2_Content_Common.Length);
              object data = (object) C2_Content_Common.Data;
              Agreement_Helper.BytesToStruct(this.buffer.ToArray(), ref data, 0);
              C2_Content_Common.Data = (T2_Content_Common) data;
              this.buffer.RemoveRange(0, C2_Content_Common.Length);
              C2_Content_Common.RecTime = DateTime.Now;
            }
            else if ((int) this.recType == (int) C6_Content_State.Type && this.buffer.Count >= C6_Content_State.Length)
            {
              object data = (object) C6_Content_State.Data;
              Agreement_Helper.BytesToStruct(this.buffer.ToArray(), ref data, 0);
              C6_Content_State.Data = (T6_Content_State) data;
              this.buffer.RemoveRange(0, C6_Content_State.Length);
              C6_Content_State.RecTime = DateTime.Now;
            }
            else if ((int) this.recType == (int) C8_Content_Config.Type && this.buffer.Count >= C8_Content_Config.Length)
            {
              object data = (object) C8_Content_Config.Data;
              Agreement_Helper.BytesToStruct(this.buffer.ToArray(), ref data, 0);
              C8_Content_Config.Data = (T8_Content_Config) data;
              this.buffer.RemoveRange(0, C8_Content_Config.Length);
              C8_Content_Config.RecTime = DateTime.Now;
            }
            else if ((int) this.recType == (int) C18_Content_Command.Type && this.buffer.Count >= C18_Content_Command.Length)
            {
              object data = (object) C18_Content_Command.Data;
              Agreement_Helper.BytesToStruct(this.buffer.ToArray(), ref data, 0);
              C18_Content_Command.Data = (T18_Content_Command) data;
              this.buffer.RemoveRange(0, C18_Content_Command.Length);
              C18_Content_Command.RecTime = DateTime.Now;
            }
            if (this.buffer.Count > 0)
              this.buffer.RemoveAt(0);
          }
        }
      }
    }
  }
}
