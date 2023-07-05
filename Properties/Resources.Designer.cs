// Decompiled with JetBrains decompiler
// Type: ECU_GCS.Properties.Resources
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ECU_GCS.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (ECU_GCS.Properties.Resources.resourceMan == null)
          ECU_GCS.Properties.Resources.resourceMan = new ResourceManager("ECU_GCS.Properties.Resources", typeof (ECU_GCS.Properties.Resources).Assembly);
        return ECU_GCS.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => ECU_GCS.Properties.Resources.resourceCulture;
      set => ECU_GCS.Properties.Resources.resourceCulture = value;
    }

    internal static Bitmap Ellipse => (Bitmap) ECU_GCS.Properties.Resources.ResourceManager.GetObject(nameof (Ellipse), ECU_GCS.Properties.Resources.resourceCulture);
  }
}
