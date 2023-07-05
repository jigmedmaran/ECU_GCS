// Decompiled with JetBrains decompiler
// Type: ECU_GCS.SpeakWarningMessage
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Synthesis;
using System.Threading;

namespace ECU_GCS
{
  public class SpeakWarningMessage
  {
    private SpeechSynthesizer speech = new SpeechSynthesizer();
    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    private List<string> warningMessages_cn = new List<string>();
    private List<string> warningMessages_cn_TW = new List<string>();
    private List<string> warningMessages_en = new List<string>();
    public List<string> currentMessages = new List<string>();
    private int currentIndex = 0;
    private string currentMessage = string.Empty;
    private uint lastFlag0;

    public void Start()
    {
      this.InitWarningMessage();
      this.timer.Interval = 3000;
      this.timer.Tick += new EventHandler(this.Timer_Tick);
      this.timer.Start();
    }

    private void InitWarningMessage()
    {
      try
      {
        foreach (string readAllLine in File.ReadAllLines("alarminfo.txt"))
        {
          char[] separator = new char[3]{ ',', '\t', '\r' };
          string[] strArray = readAllLine.Split(separator, StringSplitOptions.RemoveEmptyEntries);
          if (strArray.Length == 4)
          {
            this.warningMessages_cn.Add(strArray[1]);
            this.warningMessages_en.Add(strArray[2]);
            this.warningMessages_cn_TW.Add(strArray[3]);
          }
        }
      }
      catch
      {
      }
    }

    private void UpdateWarningMessage()
    {
      this.currentMessages.Clear();
      T2_Content_Common data = C2_Content_Common.Data;
      for (int index = 0; index < 16; ++index)
      {
        if (((int) data.err_flg & 1 << index) > 0)
        {
          switch (SetParameter.Language)
          {
            case "en-US":
              if (this.warningMessages_en.Count > 0)
              {
                this.currentMessages.Add(this.warningMessages_en[index]);
                break;
              }
              break;
            case "zh-TW":
              if (this.warningMessages_cn_TW.Count > 0)
              {
                this.currentMessages.Add(this.warningMessages_cn_TW[index]);
                break;
              }
              break;
            default:
              if (this.warningMessages_cn.Count > 0)
                this.currentMessages.Add(this.warningMessages_cn[index]);
              break;
          }
        }
      }
      if ((int) data.err_flg == (int) this.lastFlag0)
        return;
      this.currentIndex = 0;
      this.lastFlag0 = (uint) data.err_flg;
    }

    private void SpeechSpeakWarningMessage()
    {
      try
      {
        this.speech.Speak(this.currentMessage);
      }
      catch
      {
      }
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      this.UpdateWarningMessage();
      if (this.currentMessages.Count == 0)
      {
        this.currentMessage = string.Empty;
        this.currentIndex = 0;
      }
      else if (this.currentIndex < this.currentMessages.Count)
      {
        this.currentMessage = this.currentMessages[this.currentIndex];
        ++this.currentIndex;
        if (this.currentIndex >= this.currentMessages.Count)
          this.currentIndex = 0;
      }
      else
      {
        this.currentMessage = string.Empty;
        this.currentIndex = 0;
      }
      if (!(this.currentMessage != string.Empty))
        return;
      new Thread(new ThreadStart(this.SpeechSpeakWarningMessage))
      {
        IsBackground = true
      }.Start();
    }
  }
}
