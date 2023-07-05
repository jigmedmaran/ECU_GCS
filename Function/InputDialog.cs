// Decompiled with JetBrains decompiler
// Type: ECU_GCS.InputDialog
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System.Windows.Forms;

namespace ECU_GCS
{
  public static class InputDialog
  {
    public static DialogResult Show(out string strText)
    {
      string strTemp = string.Empty;
      DialogResult dialogResult = new ClickWindow()
      {
        TextHandler = ((ClickWindow.TextEventHandler) (str => strTemp = str))
      }.ShowDialog();
      strText = strTemp;
      return dialogResult;
    }
  }
}
