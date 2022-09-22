using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class WarningBox : Form
    {
        private int locationX = 258;
        private int ButtonHeight = 26;
        private Notepad dnp = new Notepad();
        private bool FirstButton = true;
        private SettingsStylize SStylize = SettingsStylize.Default;

        public WarningBox(string comment)
        {
            InitializeComponent();
            updateThemeColors();
            label1.Text = comment;

            comment = null;

            if (Application.OpenForms.OfType<Notepad>().Any())
            {
                dnp = Application.OpenForms.OfType<Notepad>().First();
            }
        }

        public void createButton(object sender, EventArgs e, string btnText, string methodName, int ButtonWidth)
        {

            if (FirstButton)
            {
                locationX = this.Width - 23 - ButtonWidth;
                FirstButton = false;
            }
            else
            {
                locationX -= ButtonWidth + 7;
            }

            Button btn = new Button();

            btn.BackColor = SStylize.Button;
            btn.FlatAppearance.BorderColor = SStylize.Button_Border;
            btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            btn.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btn.Location = new System.Drawing.Point(locationX, 83);
            btn.Name = btnText;
            btn.Size = new System.Drawing.Size(ButtonWidth, ButtonHeight);
            btn.TabIndex = 1;
            btn.Text = btnText;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            btn.UseCompatibleTextRendering = true;
            btn.UseVisualStyleBackColor = true;
            btn.Click += (sender2, e2) => dnp.invokeMethod(sender, e, methodName);

            this.Controls.Add(btn);
            btn.Focus();
            btn.BringToFront();

            btn = null;
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
        public void updateThemeColors()
        {
            this.BackColor = SStylize.Background;
            this.ForeColor = SStylize.Text;
            label1.BackColor = SStylize.Background;
            label1.ForeColor = SStylize.Text;
            panel2.BackColor = SStylize.Background_Highlight;
            int Rvalue = (SStylize.Background.R +
                SStylize.Background_Highlight.R) / 2;
            int Gvalue = (SStylize.Background.G +
                SStylize.Background_Highlight.G) / 2;
            int Bvalue = (SStylize.Background.B +
                SStylize.Background_Highlight.B) / 2;
            if (Rvalue > 255 || Gvalue > 255 || Bvalue > 255 ||
                Rvalue < 0 || Gvalue < 0 || Bvalue < 0)
            {
                panel1.BackColor = SStylize.Button_Highlight;
            }
            else
            {
                panel1.BackColor = Color.FromArgb(Rvalue, Gvalue, Bvalue);
            }
        }
    }
}
