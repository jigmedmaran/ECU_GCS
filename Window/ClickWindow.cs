// Decompiled with JetBrains decompiler
// Type: ECU_GCS.ClickWindow
// Assembly: ECU_GCS, Version=1.0.2.2, Culture=neutral, PublicKeyToken=null
// MVID: 4AB9C9F1-17D5-4990-AB25-69949DD24666
// Assembly location: D:\Business\OneDrive\Spatial_Collect\2.Agencies\1.Innoflight\10.Software\EFI SW V1.0\ECU_GCS.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ECU_GCS
{
  public class ClickWindow : Form
  {
    public ClickWindow.TextEventHandler TextHandler;
    private IContainer components = (IContainer) null;
    private TextBox txtString;
    private Button btnOK;
    private Button btnCancel;

    public ClickWindow() => this.InitializeComponent();

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (this.TextHandler == null)
        return;
      this.TextHandler(this.txtString.Text);
      this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;

    private void txtString_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ('\r' != e.KeyChar || this.TextHandler == null)
        return;
      this.TextHandler(this.txtString.Text);
      this.DialogResult = DialogResult.OK;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txtString = new TextBox();
      this.btnOK = new Button();
      this.btnCancel = new Button();
      this.SuspendLayout();
      this.txtString.Location = new Point(25, 26);
      this.txtString.Name = "txtString";
      this.txtString.Size = new Size(199, 21);
      this.txtString.TabIndex = 2;
      this.txtString.KeyPress += new KeyPressEventHandler(this.txtString_KeyPress);
      this.btnOK.Location = new Point(25, 77);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new Size(75, 23);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "确定";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new EventHandler(this.btnOK_Click);
      this.btnCancel.Location = new Point(149, 77);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "取消";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(248, 123);
      this.Controls.Add((Control) this.btnCancel);
      this.Controls.Add((Control) this.btnOK);
      this.Controls.Add((Control) this.txtString);
      this.Name = nameof (ClickWindow);
      this.Text = nameof (ClickWindow);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate void TextEventHandler(string strText);
  }
}
