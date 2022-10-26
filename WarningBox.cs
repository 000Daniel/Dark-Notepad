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

        private bool FirstButton = true;
        public bool finishedLoading = false;

        private Notepad dnp = Application.OpenForms.OfType<Notepad>().First();
        private SettingsStylize SStylize = SettingsStylize.Default;

        public WarningBox(string comment)
        {
            InitializeComponent();
            updateThemeColors();

            label1.Text = comment;
            comment = null;

            finishedLoading = true;
        }

                //  This function allows the Developer to add however many buttons needed.
                //  These buttons call for a method by name on 'Form1'.
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
            btn.ForeColor = SStylize.Button_Text;
            btn.FlatAppearance.BorderColor = SStylize.Button_Border;
            btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            btn.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn.Location = new Point(locationX, 83);
            btn.Name = btnText;
            btn.Size = new Size(ButtonWidth, ButtonHeight);
            btn.TabIndex = 1;
            btn.Text = btnText;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.UseCompatibleTextRendering = true;
            btn.UseVisualStyleBackColor = true;
            btn.Click += (sender2, e2) => dnp.invokeMethod(sender, e, methodName);

            Controls.Add(btn);
            btn.Focus();
            btn.BringToFront();

            btn = null;
        }

        public void updateThemeColors()
        {
            BackColor = SStylize.Background;
            ForeColor = SStylize.Text;
            label1.BackColor = SStylize.Background;
            label1.ForeColor = SStylize.Text;
            panel2.BackColor = SStylize.Background_Highlight;

                    //  This results in a color thats a blend between 'Background' and
                    //  'Background_Highlight'.
            int Rvalue = (SStylize.Background.R + SStylize.Background_Highlight.R) / 2;
            int Gvalue = (SStylize.Background.G + SStylize.Background_Highlight.G) / 2;
            int Bvalue = (SStylize.Background.B + SStylize.Background_Highlight.B) / 2;
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
