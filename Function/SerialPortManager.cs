// Decompiled with JetBrains decompiler
// Type: ECU_GCS.SerialPortManager
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.IO.Ports;
using System.Threading;

namespace ECU_GCS
{
  public class SerialPortManager
  {
    private SerialPort port = new SerialPort();
    private bool forceReset = true;
    private int index = 0;
    private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    public DateTime sendDateTime = DateTime.MinValue;
    private Thread thread = (Thread) null;

    public bool EnableReceive { get; set; }

    public bool GetPortState() => this.port.IsOpen;

    public string GetPortName() => this.port.PortName;

    public SerialPortManager() => this.SerialPortInit();

    private void SerialPortInit()
    {
      this.timer.Interval = 1000;
      this.timer.Tick += new EventHandler(this.Timer_Tick);
      this.timer.Start();
      this.EnableReceive = true;
    }

    private void SerialPortReset()
    {
      try
      {
        string[] portNames = SerialPort.GetPortNames();
        if (portNames.Length == 0)
          return;
        this.port.DataReceived -= new SerialDataReceivedEventHandler(this.Port_DataReceived);
        this.port.Dispose();
        this.port = new SerialPort();
        this.port.DataReceived += new SerialDataReceivedEventHandler(this.Port_DataReceived);
        this.port.PortName = portNames[this.index];
        this.port.BaudRate = 9600;
        this.port.DataBits = 8;
        this.port.StopBits = StopBits.One;
        this.port.Parity = Parity.None;
        this.port.ReadBufferSize = 256;
        this.port.ReadTimeout = 1000;
        this.port.Open();
      }
      catch
      {
      }
    }

    private void SendTickRequest()
    {
      byte[] bytes = Agreement_Helper.StructToBytes((object) new T0_Request_Null()
      {
        header0 = (byte) 181,
        header1 = (byte) 98,
        source = (byte) 195,
        target = (byte) 161,
        type = C0_Request_Null.Type,
        num = (byte) C0_Request_Null.Length,
        id = Common.Agreement.SendId,
        ack = (byte) 0,
        chk0 = (byte) 0,
        chk1 = (byte) 0,
        end0 = (byte) 13,
        end1 = (byte) 10
      });
      for (int index = 0; index < bytes.Length - 4; ++index)
      {
        bytes[bytes.Length - 4] ^= bytes[index];
        bytes[bytes.Length - 3] ^= bytes[bytes.Length - 4];
      }
      Common.SerialManager.SendData(bytes);
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (!this.EnableReceive)
        return;
      TimeSpan timeSpan = DateTime.Now.Subtract(Common.Agreement.RecTime);
      if (timeSpan.TotalMilliseconds < 1000.0)
      {
        this.forceReset = false;
      }
      else
      {
        timeSpan = DateTime.Now.Subtract(Common.Agreement.RecTime);
        if (timeSpan.TotalMilliseconds > 3000.0)
          this.forceReset = true;
      }
      if (!this.port.IsOpen)
        this.forceReset = true;
      if (this.forceReset && (this.thread == null || this.thread.ThreadState == ThreadState.Stopped))
      {
        if (this.index == 0)
        {
          string[] portNames = SerialPort.GetPortNames();
          if (portNames.Length != 0)
            this.index = portNames.Length - 1;
        }
        else if (this.index > 0)
          --this.index;
        this.thread = new Thread(new ThreadStart(this.SerialPortReset));
        this.thread.Start();
      }
      timeSpan = DateTime.Now.Subtract(this.sendDateTime);
      if (timeSpan.TotalMilliseconds <= 3100.0)
        return;
      this.SendTickRequest();
    }

    private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      try
      {
        SerialPort serialPort = (SerialPort) sender;
        int bytesToRead = serialPort.BytesToRead;
        if (bytesToRead < 256)
        {
          byte[] numArray = new byte[bytesToRead];
          serialPort.Read(numArray, 0, numArray.Length);
          if (!this.EnableReceive)
            return;
          Common.Agreement.UpdateData(numArray);
        }
        else
          serialPort.DiscardInBuffer();
      }
      catch
      {
      }
    }

    public void SendData(byte[] data)
    {
      if (this.EnableReceive && this.GetPortState())
      {
        if (DateTime.Now.Subtract(Common.Agreement.RecTime).TotalMilliseconds < 1000.0)
        {
          try
          {
            this.port.Write(data, 0, data.Length);
          }
          catch
          {
          }
        }
      }
      this.sendDateTime = DateTime.Now;
    }

    public void SerialPortClose()
    {
      try
      {
        this.port.Close();
        this.port.Dispose();
      }
      catch
      {
      }
    }
  }
}
