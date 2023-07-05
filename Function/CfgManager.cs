using System;
using System.Drawing;
using System.Windows.Forms;

namespace ECU_GCS
{
	public class CfgManager
	{
		private int config_count = 102;

		private Timer timer1 = new Timer();

		private Timer timer2 = new Timer();

		public CfgManager()
		{
			this.timer1.Interval = 10;
			this.timer1.Tick += new EventHandler(this.Timer_Tick_Send);
			this.timer1.Start();
			for (int i = 0; i < (int)Common.cfg_value.Length; i++)
			{
				Common.cfg_value[i] = new CfgValue(0f, false);
				Common.cfg_value[i].Index = 0;
				Common.cfg_value[i].ReadValueFinish(0f);
				Common.cfg_value[i].num = 1000;
			}
			this.timer2.Interval = 10;
			this.timer2.Tick += new EventHandler(this.Timer_Tick_Rec);
			this.timer2.Start();
		}

		private void SendConfigContent(byte ind, float value)
		{
			T8_Content_Config content = new T8_Content_Config()
			{
				header0 = 181,
				header1 = 98,
				source = 195,
				target = 161,
				type = C8_Content_Config.Type,
				num = (byte)C8_Content_Config.Length,
				id = Common.Agreement.SendId,
				ack = 0,
				index = ind,
				content = value,
				chk0 = 0,
				chk1 = 0,
				end0 = 13,
				end1 = 10
			};
			byte[] bytes = Agreement_Helper.StructToBytes(content);
			for (int i = 0; i < (int)bytes.Length - 4; i++)
			{
				ref byte numPointer = ref bytes[(int)bytes.Length - 4];
				numPointer = (byte)(numPointer ^ bytes[i]);
				ref byte numPointer1 = ref bytes[(int)bytes.Length - 3];
				numPointer1 = (byte)(numPointer1 ^ bytes[(int)bytes.Length - 4]);
			}
			Common.SerialManager.SendData(bytes);
		}

		private void SendConfigRequest(byte index)
		{
			T7_Request_Config request = new T7_Request_Config()
			{
				header0 = 181,
				header1 = 98,
				source = 195,
				target = 161,
				type = C7_Request_Config.Type,
				num = (byte)C7_Request_Config.Length,
				id = Common.Agreement.SendId,
				ack = 80,
				index = index,
				chk0 = 0,
				chk1 = 0,
				end0 = 13,
				end1 = 10
			};
			byte[] bytes = Agreement_Helper.StructToBytes(request);
			for (int i = 0; i < (int)bytes.Length - 4; i++)
			{
				ref byte numPointer = ref bytes[(int)bytes.Length - 4];
				numPointer = (byte)(numPointer ^ bytes[i]);
				ref byte numPointer1 = ref bytes[(int)bytes.Length - 3];
				numPointer1 = (byte)(numPointer1 ^ bytes[(int)bytes.Length - 4]);
			}
			Common.SerialManager.SendData(bytes);
		}

		private void Timer_Tick_Rec(object sender, EventArgs e)
		{
			if (DateTime.Now.Subtract(C8_Content_Config.RecTime).TotalMilliseconds < 300)
			{
				Common.cfg_value[C8_Content_Config.Data.index].ReadValueFinish(C8_Content_Config.Data.content);
				if ((C8_Content_Config.Data.index >= 12 ? false : C8_Content_Config.Data.index >= 1))
				{
					Common.ConfigTool.ThrOilPanelLoadData(Color.Blue);
				}
				else if ((C8_Content_Config.Data.index >= 23 ? false : C8_Content_Config.Data.index >= 12))
				{
					Common.ConfigTool.ThrOil2PanelLoadData(Color.Blue);
				}
				else if ((C8_Content_Config.Data.index > 33 ? false : C8_Content_Config.Data.index >= 23))
				{
					Common.ConfigTool.ThrExpPanelLoadData(Color.Blue);
				}
				else if ((C8_Content_Config.Data.index > 44 ? false : C8_Content_Config.Data.index >= 34))
				{
					Common.ConfigTool.OilPrePanelLoadData(Color.Blue);
				}
				else if ((C8_Content_Config.Data.index > 49 ? false : C8_Content_Config.Data.index >= 45))
				{
					Common.Cfg_BaseTool.FindJetName();
				}
				if (Common.cfg_value[C8_Content_Config.Data.index].NeedWrite)
				{
					if (Common.cfg_value[C8_Content_Config.Data.index].Value.Equals(C8_Content_Config.Data.content))
					{
						Common.cfg_value[C8_Content_Config.Data.index].WriteValueFinish();
					}
				}
			}
		}

		private void Timer_Tick_Send(object sender, EventArgs e)
		{
			for (int i = 0; i < 102; i++)
			{
				for (int j = 0; j <= 102; j++)
				{
					if (i == Common.cfg_value[j].num)
					{
						if ((Common.cfg_value[j].Name_Save == null ? false : Common.cfg_value[j].Index != 0))
						{
							if (Common.cfg_value[j].NeedWrite)
							{
								if (DateTime.Now.Subtract(Common.SerialManager.sendDateTime).TotalMilliseconds > 100)
								{
									this.SendConfigContent((byte)Common.cfg_value[j].Index, Common.cfg_value[j].Value);
								}
								return;
							}
							else if (Common.cfg_value[j].NeedRead)
							{
								if (DateTime.Now.Subtract(Common.SerialManager.sendDateTime).TotalMilliseconds > 100)
								{
									this.SendConfigRequest((byte)Common.cfg_value[j].Index);
								}
								return;
							}
						}
					}
				}
			}
		}
	}
}