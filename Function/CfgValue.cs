// Decompiled with JetBrains decompiler
// Type: ECU_GCS.CfgValue
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ECU_GCS
{
  public class CfgValue
  {
    private Panel panel = new Panel();
    private Label label = new Label();
    private TextBox textBox = new TextBox();
    private Button btnDown = new Button();
    private Button btnUp = new Button();
    private bool needRead = true;
    private bool needWrite = false;
    private bool signWrite = false;
    private float value;
    public int Index;
    public int num;
    public float Step;
    public float Min;
    public float Max;
    public string Name_CN;
    public string Name_CN_TW;
    public string Name_EN;
    public string Name_Save;
    public string Name_6;
    public string Name_5;
    public string Name_4;
    public string Name_3;
    public string Name_2;
    public string Name_1;
    public string name_0;

    public string Name
    {
      get => this.label.Text;
      set => this.label.Text = value;
    }

    public bool NeedRead => this.needRead;

    public bool NeedWrite => this.needWrite;

    public bool SignWrite => this.signWrite;

    public Point Loc
    {
      get => this.panel.Location;
      set => this.panel.Location = value;
    }

    public float Value => this.value;

    public string Name_0
    {
      get => this.name_0;
      set
      {
        this.name_0 = value;
        this.textBox.Text = "-";
        this.textBox.ReadOnly = true;
      }
    }

    public CfgValue(float value, bool visable)
    {
      this.value = value;
      this.ReadValueRequest();
      if (!visable)
        return;
      this.panel.Size = new Size(300, 30);
      this.panel.BackColor = Color.Transparent;
      this.label.Location = new Point(0, 8);
      this.label.Size = new Size(110, 30);
      this.panel.Controls.Add((Control) this.label);
      this.btnDown.Location = new Point(110, 5);
      this.btnDown.Size = new Size(30, 20);
      this.btnDown.Text = "-";
      this.btnDown.Click += new EventHandler(this.BtnDown_Click);
      this.panel.Controls.Add((Control) this.btnDown);
      this.textBox.Text = value.ToString();
      this.textBox.Location = new Point(150, 4);
      this.textBox.Size = new Size(60, 30);
      this.textBox.TextChanged += new EventHandler(this.TextBox_TextChanged);
      this.textBox.KeyDown += new KeyEventHandler(this.TextBox_KeyDown);
      this.textBox.BackColor = Color.Yellow;
      this.panel.Controls.Add((Control) this.textBox);
      this.btnUp.Location = new Point(220, 5);
      this.btnUp.Size = new Size(30, 20);
      this.btnUp.Text = "+";
      this.btnUp.Click += new EventHandler(this.BtnUp_Click);
      this.panel.Controls.Add((Control) this.btnUp);
    }

    public void ReadValueRequest()
    {
      this.needRead = true;
      this.textBox.BackColor = Color.Yellow;
    }

    public void SetValue(float value)
    {
      if ((double) this.value == (double) value)
        return;
      this.value = value;
      this.signWrite = true;
      if (this.Name_0 == null)
        this.textBox.Text = this.value.ToString();
      else if ((double) this.value == 0.0)
        this.textBox.Text = this.Name_0;
      else if ((double) this.value == 1.0)
        this.textBox.Text = this.Name_1;
      else if ((double) this.value == 2.0)
        this.textBox.Text = this.Name_2;
      else if ((double) this.value == 3.0)
        this.textBox.Text = this.Name_3;
      else if ((double) this.value == 4.0)
        this.textBox.Text = this.Name_4;
      else if ((double) this.value == 5.0)
        this.textBox.Text = this.Name_5;
      else if ((double) this.value == 6.0)
        this.textBox.Text = this.Name_6;
    }

    public void ReadValueFinish(float value)
    {
      this.value = value;
      this.signWrite = false;
      if (this.Name_0 == null)
        this.textBox.Text = this.value.ToString();
      else if ((double) this.value == 0.0)
        this.textBox.Text = this.Name_0;
      else if ((double) this.value == 1.0)
        this.textBox.Text = this.Name_1;
      else if ((double) this.value == 2.0)
        this.textBox.Text = this.Name_2;
      else if ((double) this.value == 3.0)
        this.textBox.Text = this.Name_3;
      else if ((double) this.value == 4.0)
        this.textBox.Text = this.Name_4;
      else if ((double) this.value == 5.0)
        this.textBox.Text = this.Name_5;
      else if ((double) this.value == 6.0)
        this.textBox.Text = this.Name_6;
      this.needRead = false;
      this.textBox.BackColor = SystemColors.Window;
    }

    public void WriteValueRequest()
    {
      this.needWrite = true;
      this.signWrite = false;
    }

    public void WriteValueFinish()
    {
      this.needWrite = false;
      this.textBox.BackColor = SystemColors.Window;
    }

    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      if (this.SignWrite)
        this.WriteValueRequest();
      e.Handled = true;
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
      if (this.Name_0 == null)
      {
        try
        {
          this.value = Convert.ToSingle(this.textBox.Text);
          this.signWrite = true;
          if ((double) this.value < (double) this.Min || (double) this.value > (double) this.Max)
            this.textBox.BackColor = Color.Red;
          else
            this.textBox.BackColor = Color.Yellow;
        }
        catch
        {
          this.textBox.BackColor = Color.Red;
        }
      }
      else
      {
        this.signWrite = true;
        if ((double) this.value < (double) this.Min || (double) this.value > (double) this.Max)
          this.textBox.BackColor = Color.Red;
        else
          this.textBox.BackColor = Color.Yellow;
      }
    }

    private void BtnUp_Click(object sender, EventArgs e)
    {
      this.textBox.Focus();
      if (this.Name_0 != null)
      {
        this.value += this.Step;
        this.value = Math.Min(this.value, this.Max);
        this.value = Math.Max(this.value, this.Min);
        if ((double) this.value == 0.0)
          this.textBox.Text = this.Name_0;
        else if ((double) this.value == 1.0)
          this.textBox.Text = this.Name_1;
        else if ((double) this.value == 2.0)
          this.textBox.Text = this.Name_2;
        else if ((double) this.value == 3.0)
          this.textBox.Text = this.Name_3;
        else if ((double) this.value == 4.0)
          this.textBox.Text = this.Name_4;
        else if ((double) this.value == 5.0)
        {
          this.textBox.Text = this.Name_5;
        }
        else
        {
          if ((double) this.value != 6.0)
            return;
          this.textBox.Text = this.Name_6;
        }
      }
      else
      {
        this.value += this.Step;
        this.value = Math.Min(this.value, this.Max);
        this.value = Math.Max(this.value, this.Min);
        this.textBox.Text = this.value.ToString();
      }
    }

    private void BtnDown_Click(object sender, EventArgs e)
    {
      this.textBox.Focus();
      if (this.Name_0 != null)
      {
        this.value -= this.Step;
        this.value = Math.Min(this.value, this.Max);
        this.value = Math.Max(this.value, this.Min);
        if ((double) this.value == 0.0)
          this.textBox.Text = this.Name_0;
        else if ((double) this.value == 1.0)
          this.textBox.Text = this.Name_1;
        else if ((double) this.value == 2.0)
          this.textBox.Text = this.Name_2;
        else if ((double) this.value == 3.0)
          this.textBox.Text = this.Name_3;
        else if ((double) this.value == 4.0)
          this.textBox.Text = this.Name_4;
        else if ((double) this.value == 5.0)
        {
          this.textBox.Text = this.Name_5;
        }
        else
        {
          if ((double) this.value != 6.0)
            return;
          this.textBox.Text = this.Name_6;
        }
      }
      else
      {
        this.value -= this.Step;
        this.value = Math.Min(this.value, this.Max);
        this.value = Math.Max(this.value, this.Min);
        this.textBox.Text = this.value.ToString();
      }
    }

    public void AddToWidnow(Control parent) => parent.Controls.Add((Control) this.panel);
  }
}
