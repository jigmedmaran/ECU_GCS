// Decompiled with JetBrains decompiler
// Type: ECU_GCS.SetParameter
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System.IO;
using System.Text;

namespace ECU_GCS
{
  public static class SetParameter
  {
    private static string fileName = "setparameter.txt";
    public static string Language = "en-US";
    public static string ChkBox1 = "false";
    public static string ChkBox2 = "false";
    public static string ChkBox3 = "false";
    public static string ChkBox4 = "false";
    public static string ChkBox5 = "false";
    public static string ChkBox6 = "false";
    public static string ChkBox7 = "false";
    public static string ChkBox8 = "false";
    public static string ChkBox9 = "false";
    public static string ChkBox10 = "false";
    public static string ChkBox11 = "false";

    public static void Load()
    {
      if (!File.Exists(SetParameter.fileName))
        return;
      foreach (string readAllLine in File.ReadAllLines(SetParameter.fileName))
      {
        char[] chArray = new char[1]{ ' ' };
        string[] strArray = readAllLine.Split(chArray);
        if (strArray.Length == 2)
        {
          if (strArray[0] == "Language")
            SetParameter.Language = strArray[1];
          else if (strArray[0] == "ChkBox1")
            SetParameter.ChkBox1 = strArray[1];
          else if (strArray[0] == "ChkBox2")
            SetParameter.ChkBox2 = strArray[1];
          else if (strArray[0] == "ChkBox3")
            SetParameter.ChkBox3 = strArray[1];
          else if (strArray[0] == "ChkBox4")
            SetParameter.ChkBox4 = strArray[1];
          else if (strArray[0] == "ChkBox5")
            SetParameter.ChkBox5 = strArray[1];
          else if (strArray[0] == "ChkBox6")
            SetParameter.ChkBox6 = strArray[1];
          else if (strArray[0] == "ChkBox7")
            SetParameter.ChkBox7 = strArray[1];
          else if (strArray[0] == "ChkBox8")
            SetParameter.ChkBox8 = strArray[1];
          else if (strArray[0] == "ChkBox9")
            SetParameter.ChkBox9 = strArray[1];
          else if (strArray[0] == "ChkBox10")
            SetParameter.ChkBox10 = strArray[1];
          else if (strArray[0] == "ChkBox11")
            SetParameter.ChkBox11 = strArray[1];
        }
      }
    }

    public static void Save()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("Language " + SetParameter.Language.ToString());
      stringBuilder.AppendLine("ChkBox1 " + SetParameter.ChkBox1.ToString());
      stringBuilder.AppendLine("ChkBox2 " + SetParameter.ChkBox2.ToString());
      stringBuilder.AppendLine("ChkBox3 " + SetParameter.ChkBox3.ToString());
      stringBuilder.AppendLine("ChkBox4 " + SetParameter.ChkBox4.ToString());
      stringBuilder.AppendLine("ChkBox5 " + SetParameter.ChkBox5.ToString());
      stringBuilder.AppendLine("ChkBox6 " + SetParameter.ChkBox6.ToString());
      stringBuilder.AppendLine("ChkBox7 " + SetParameter.ChkBox7.ToString());
      stringBuilder.AppendLine("ChkBox8 " + SetParameter.ChkBox8.ToString());
      stringBuilder.AppendLine("ChkBox9 " + SetParameter.ChkBox9.ToString());
      stringBuilder.AppendLine("ChkBox10 " + SetParameter.ChkBox10.ToString());
      stringBuilder.AppendLine("ChkBox11 " + SetParameter.ChkBox11.ToString());
      File.WriteAllText(SetParameter.fileName, stringBuilder.ToString());
    }
  }
}
