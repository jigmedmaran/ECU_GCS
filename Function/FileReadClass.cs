// Decompiled with JetBrains decompiler
// Type: ECU_GCS.FileReadClass
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ECU_GCS
{
  public class FileReadClass
  {
    private string _FileName;
    private int _Process;
    private List<string> _Titles;
    private List<uint> _Types;
    private List<double[]> _Data;

    public string FileName => this._FileName;

    public int Process => this._Process;

    public List<string> Titles => this._Titles;

    public List<uint> Types => this._Types;

    public List<double[]> Data => this._Data;

    public void Read(string fileName)
    {
      this._FileName = fileName;
      new Thread(new ThreadStart(this.convert)).Start();
    }

    private bool get_bit(byte b, int index) => ((int) b & 1 << index) > 0;

    private void convert()
    {
      this._Titles = new List<string>();
      this._Types = new List<uint>();
      this._Data = new List<double[]>();
      this._Process = 10;
      StreamReader streamReader = new StreamReader(this.FileName);
      int num1 = 0;
      while (true)
      {
        string str = streamReader.ReadLine();
        num1 += str.Length;
        if (num1 <= 30000)
        {
          string[] strArray = str.Split(new char[4]
          {
            ' ',
            '\r',
            '\n',
            char.MinValue
          }, StringSplitOptions.RemoveEmptyEntries);
          if (strArray.Length == 2)
          {
            this._Titles.Add(strArray[0]);
            try
            {
              this._Types.Add(Convert.ToUInt32(strArray[1]));
            }
            catch
            {
            }
          }
        }
        else
          break;
      }
      streamReader.Close();
      this._Process = 10;
      FileStream input = new FileStream(this.FileName, FileMode.Open);
      BinaryReader binaryReader = new BinaryReader((Stream) input);
      int length = (int) input.Length;
      byte[] numArray1 = binaryReader.ReadBytes(length);
      binaryReader.Close();
      input.Close();
      this._Process = 20;
      List<int> intList = new List<int>();
      for (int index = 30000; index + 3 < length; ++index)
      {
        if (numArray1[index] == (byte) 33 && numArray1[index + 1] == (byte) 64 && numArray1[index + 2] == (byte) 35 && numArray1[index + 3] == (byte) 36)
          intList.Add(index);
      }
      intList.Add(length);
      this._Process = 30;
      for (int index1 = 0; index1 < intList.Count - 1; ++index1)
      {
        List<byte> byteList1 = new List<byte>();
        for (int index2 = intList[index1]; index2 < intList[index1 + 1]; ++index2)
          byteList1.Add(numArray1[index2]);
        byte[] array = byteList1.ToArray();
        BitConverter.ToUInt32(array, 0);
        int uint32_1 = (int) BitConverter.ToUInt32(array, 4);
        int uint32_2 = (int) BitConverter.ToUInt32(array, 8);
        int num2 = (uint32_2 + 7) / 8;
        List<byte> byteList2 = new List<byte>();
        for (int index3 = 0; index3 < num2; ++index3)
          byteList2.Add(array[12 + index3]);
        int startIndex = 12 + num2;
        double[] numArray2 = new double[this._Types.Count];
        for (int index4 = 0; index4 < uint32_2; ++index4)
        {
          if (this.get_bit(byteList2[index4 / 8], index4 % 8))
          {
            switch (this._Types[index4])
            {
              case 0:
                numArray2[index4] = (double) array[startIndex];
                ++startIndex;
                continue;
              case 1:
                numArray2[index4] = (double) array[startIndex];
                ++startIndex;
                continue;
              case 2:
                numArray2[index4] = (double) BitConverter.ToUInt16(array, startIndex);
                startIndex += 2;
                continue;
              case 3:
                numArray2[index4] = (double) BitConverter.ToInt16(array, startIndex);
                startIndex += 2;
                continue;
              case 4:
                numArray2[index4] = (double) BitConverter.ToUInt32(array, startIndex);
                startIndex += 4;
                continue;
              case 5:
                numArray2[index4] = (double) BitConverter.ToInt32(array, startIndex);
                startIndex += 4;
                continue;
              case 6:
                numArray2[index4] = (double) BitConverter.ToSingle(array, startIndex);
                startIndex += 4;
                continue;
              case 7:
                numArray2[index4] = (double) BitConverter.ToUInt64(array, startIndex);
                startIndex += 8;
                continue;
              case 8:
                numArray2[index4] = (double) BitConverter.ToInt64(array, startIndex);
                startIndex += 8;
                continue;
              case 9:
                numArray2[index4] = BitConverter.ToDouble(array, startIndex);
                startIndex += 8;
                continue;
              default:
                continue;
            }
          }
          else
            numArray2[index4] = this._Data[index1 - 1][index4];
        }
        this._Data.Add(numArray2);
        this._Process = 40 + 30 * index1 / (intList.Count - 1);
      }
      this._Process = 100;
    }

    private enum Colors
    {
      U8,
      I8,
      U16,
      I16,
      U32,
      I32,
      F32,
      U64,
      I64,
      F64,
    }
  }
}
