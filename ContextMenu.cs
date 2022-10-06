﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
            //  This class is called and created mainly from 'Form1' class.
            //  This class contains 'createButton()', 'createCheckedButton()', 'createPanelLine()'
            //  functions which together allow the Developer to add and remove whatever controls they
            //  want during runtime, this class is a modular Context menu.
            //  Each button also calls by name a method/function from 'From1' class.
    public partial class ContextMenu : Form
    {
        private int locationY = 1;
        private int ButtonHeight = 26;
        private Notepad dnp = new Notepad(String.Empty);
        public bool busy = false;
        public int panelSize = 231;
        SettingsStylize SStylize = SettingsStylize.Default;

        public ContextMenu()
        {
            InitializeComponent();

            if (Application.OpenForms.OfType<Notepad>().Any())
            {
                dnp = Application.OpenForms.OfType<Notepad>().First();
            }

            this.BackColor = SStylize.Background;
        }

        private void updateFormSize(object sender, EventArgs e)
        {
            this.Height = locationY + 3;
            this.Width = panelSize;
            BorderPanel1.Size = new Size(this.Width, 1);
            BorderPanel2.Size = new Size(this.Width, 1);
            BorderPanel2.Location = new Point(0, this.Height - 1);
            BorderPanel3.Size = new Size(1, this.Height - 2);
            BorderPanel4.Size = new Size(1, this.Height - 2);
            BorderPanel4.Location = new Point(this.Width - 1, 1);

            foreach (Panel pnl in this.Controls.OfType<Panel>())
            {
                pnl.BringToFront();
            }
            foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
            {
                pb.BringToFront();
            }

            this.Update();
        }

        public void createCheckedButton(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.Image = global::DarkNotepad.Resource1.DarkCheck2;
            pb.Location = new System.Drawing.Point(6, locationY + 6);
            pb.Size = new Size(13, 13);
            pb.Name = "pictureBox1";
            pb.TabIndex = 3;
            pb.TabStop = false;
            pb.Enabled = false;
            this.Controls.Add(pb);
        }

        public void createButton(object sender, EventArgs e, string btnText, string methodName, bool enabled = true, bool BTNchecked = false)
        {
            Button btn = new Button();

            btn.FlatAppearance.BorderColor = SStylize.Background;
            btn.BackColor = SStylize.Background;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btn.Location = new System.Drawing.Point(1, locationY);
            btn.Name = btnText;
            btn.Size = new System.Drawing.Size(panelSize - 2, ButtonHeight);
            btn.TabIndex = 2;
            btn.Text = "     " + btnText;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.UseCompatibleTextRendering = true;
            btn.UseVisualStyleBackColor = true;
            if (enabled)
            {
                btn.Click += (sender2, e2) => dnp.invokeMethod(sender, e, methodName);
                btn.ForeColor = SStylize.Button_Text;
                btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                btn.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;

            }
            else
            {
                btn.ForeColor = SStylize.Button_Unavailable_Text;
                btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Unavailable_Pressed;
                btn.FlatAppearance.MouseOverBackColor = SStylize.Button_Unavailable_Highlight;
            }
            if (BTNchecked)
            {
                createCheckedButton(sender, e);
            }

            this.Controls.Add(btn);
            btn.BringToFront();
            btn = null;

            locationY += ButtonHeight - 2;
            updateFormSize(sender, e);
        }

        public void createPanelLine(object sender, EventArgs e, int offset)
        {
            Panel pnl = new Panel();

            pnl.BackColor = SStylize.Background_Highlight;
            pnl.Location = new System.Drawing.Point(offset, locationY + 3);
            pnl.Name = "BorderPanel1";
            pnl.Size = new System.Drawing.Size(panelSize - (offset * 2), 1);
            pnl.TabIndex = 0;

            this.Controls.Add(pnl);
            pnl = null;

            locationY += 3;
            updateFormSize(sender, e);
        }

        private void ContextMenu_Deactivate(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Notepad>().Any())
            {
                dnp = Application.OpenForms.OfType<Notepad>().First();
                timer1.Enabled = false;
                timer1.Dispose();
            }
        }
    }
}
