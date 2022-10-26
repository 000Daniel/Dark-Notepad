
namespace DarkNotepad
{
    partial class ContextMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContextMenu));
            this.BorderPanel1 = new System.Windows.Forms.Panel();
            this.BorderPanel2 = new System.Windows.Forms.Panel();
            this.BorderPanel3 = new System.Windows.Forms.Panel();
            this.BorderPanel4 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BorderPanel1
            // 
            this.BorderPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BorderPanel1.Location = new System.Drawing.Point(0, 0);
            this.BorderPanel1.Name = "BorderPanel1";
            this.BorderPanel1.Size = new System.Drawing.Size(229, 1);
            this.BorderPanel1.TabIndex = 0;
            // 
            // BorderPanel2
            // 
            this.BorderPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BorderPanel2.Location = new System.Drawing.Point(0, 540);
            this.BorderPanel2.Name = "BorderPanel2";
            this.BorderPanel2.Size = new System.Drawing.Size(229, 1);
            this.BorderPanel2.TabIndex = 1;
            // 
            // BorderPanel3
            // 
            this.BorderPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BorderPanel3.Location = new System.Drawing.Point(0, 1);
            this.BorderPanel3.Name = "BorderPanel3";
            this.BorderPanel3.Size = new System.Drawing.Size(1, 538);
            this.BorderPanel3.TabIndex = 1;
            // 
            // BorderPanel4
            // 
            this.BorderPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BorderPanel4.Location = new System.Drawing.Point(228, 1);
            this.BorderPanel4.Name = "BorderPanel4";
            this.BorderPanel4.Size = new System.Drawing.Size(1, 538);
            this.BorderPanel4.TabIndex = 2;
            // 
            // ContextMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(231, 540);
            this.Controls.Add(this.BorderPanel4);
            this.Controls.Add(this.BorderPanel3);
            this.Controls.Add(this.BorderPanel2);
            this.Controls.Add(this.BorderPanel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ContextMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ContextMenu";
            this.Deactivate += new System.EventHandler(this.ContextMenu_Deactivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContextMenu_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BorderPanel1;
        private System.Windows.Forms.Panel BorderPanel2;
        private System.Windows.Forms.Panel BorderPanel3;
        private System.Windows.Forms.Panel BorderPanel4;
    }
}