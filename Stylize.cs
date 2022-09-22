using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    //  This class will determine what color should each control have.
    //  The user can modify it to their liking, or even reset to default settings.
    //  In each class there is a function called 'updateThemeColors()', this function
    //  is called while the Form is loading or when already loaded.
    //  The only exceptions are the 'Stylize' and 'ColorPicker' classes which will
    //  always have the same theme.
    public partial class Stylize : Form
    {
        private Notepad dnp;
        private SettingsStylize SStyle = SettingsStylize.Default;

        public Stylize()
        {
            InitializeComponent();
        }
        public void Stylize_Load(object sender, EventArgs e)
        {
            SetColor(button1, SStyle.Background);
            SetColor(button2, SStyle.Background_Highlight);
            SetColor(button3, SStyle.Text);
            SetColor(button4, SStyle.Link);
            SetColor(button5, SStyle.Link_Pressed);

            SetColor(button6, SStyle.Button);
            SetColor(button7, SStyle.Button_Highlight);
            SetColor(button8, SStyle.Button_Pressed);
            SetColor(button9, SStyle.Button_Text);
            SetColor(button10, SStyle.Button_Unavailable);
            SetColor(button11, SStyle.Button_Unavailable_Highlight);
            SetColor(button12, SStyle.Button_Unavailable_Pressed);
            SetColor(button13, SStyle.Button_Unavailable_Text);
            SetColor(button14, SStyle.Button_Border);
            SetColor(button16, SStyle.TextBox);
            SetColor(button15, SStyle.TextBox_Text);
            SetColor(button17, SStyle.Text_Error);

            UpdatePreviewWindow();
        }
        private void SetColor(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.FlatAppearance.MouseDownBackColor = color;
            btn.FlatAppearance.MouseOverBackColor = color;
        }
        public void UpdatePreviewWindow()
        {
            panel2.BackColor = button1.BackColor;
            Preview_PanelHighlight.BackColor = button2.BackColor;
            Preview_PanelHighlight2.BackColor = button2.BackColor;

            Preview_Label.ForeColor = button3.BackColor;
            Preview_Label.BackColor = button1.BackColor;
            Preview_LinkLabel.LinkColor = button4.BackColor;
            Preview_LinkLabel.BackColor = button1.BackColor;
            Preview_LinkLabel.ActiveLinkColor = button5.BackColor;
            Preview_LinkLabel.VisitedLinkColor = button4.BackColor;

            Preview_Button.BackColor = button6.BackColor;
            Preview_Button.FlatAppearance.MouseOverBackColor = button7.BackColor;
            Preview_Button.FlatAppearance.MouseDownBackColor = button8.BackColor;
            Preview_Button.ForeColor = button9.BackColor;
            Preview_Button.FlatAppearance.BorderColor = button14.BackColor;
            Preview_UButton.BackColor = button10.BackColor;
            Preview_UButton.FlatAppearance.MouseOverBackColor = button11.BackColor;
            Preview_UButton.FlatAppearance.MouseDownBackColor = button12.BackColor;
            Preview_UButton.ForeColor = button13.BackColor;
            Preview_TextBox.BackColor = button16.BackColor;
            Preview_TextBox.ForeColor = button15.BackColor;
            Preview_ErrorLabel.ForeColor = button17.BackColor;
        }
        private void updateDNT(object sender, EventArgs e)
        {
            if (dnp == null)
            {
                if (Application.OpenForms.OfType<Notepad>().Any())
                {
                    dnp = Application.OpenForms.OfType<Notepad>().First();
                }
            }
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            updateDNT(sender, e);

            if (Application.OpenForms.OfType<ColorPicker>().Any())
            {
                Application.OpenForms.OfType<ColorPicker>().First().Close();
            }

            dnp.Focus();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            SStyle.Background = button1.BackColor;
            SStyle.Background_Highlight = button2.BackColor;
            SStyle.Text = button3.BackColor;
            SStyle.Link = button4.BackColor;
            SStyle.Link_Pressed = button5.BackColor;

            SStyle.Button = button6.BackColor;
            SStyle.Button_Highlight = button7.BackColor;
            SStyle.Button_Pressed = button8.BackColor;
            SStyle.Button_Text = button9.BackColor;
            SStyle.Button_Unavailable= button10.BackColor;
            SStyle.Button_Unavailable_Highlight = button11.BackColor;
            SStyle.Button_Unavailable_Pressed = button12.BackColor;
            SStyle.Button_Unavailable_Text = button13.BackColor;
            SStyle.Button_Border = button14.BackColor;
            SStyle.TextBox = button16.BackColor;
            SStyle.TextBox_Text = button15.BackColor;
            SStyle.Text_Error = button17.BackColor;

            SStyle.Save();

            updateDNT(sender, e);
            dnp.updateThemeColors();
            exitbutton_Click(null, null);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            WarningBox WB = new WarningBox(String.Format("Do you want to reset the theme?"));
            WB.createButton(null, null, "Cancel", "CloseWarningBox", 70);
            WB.createButton(null, null, "Reset", "ResetThemes", 70);
            WB.StartPosition = FormStartPosition.CenterScreen;
            WB.Show();
            WB.BringToFront();
            WB = null;
        }
        public void reset_Theme()
        {
            SStyle.Reset();
            Stylize_Load(null, null);
            updateDNT(null,null);
            dnp.updateThemeColors();
        }

        private void Stylize_Activated(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<WarningBox>().Any())
            {
                Application.OpenForms.OfType<WarningBox>().First().BringToFront();
                return;
            }
            if (Application.OpenForms.OfType<ColorPicker>().Any())
            {
                Application.OpenForms.OfType<ColorPicker>().First().BringToFront();
                return;
            }
        }

        private void open_ColorPicker(Button btn)
        {
            ColorPicker CPicker;

            if (Application.OpenForms.OfType<ColorPicker>().Any())
            {
                CPicker = Application.OpenForms.OfType<ColorPicker>().First();
                CPicker.BringToFront();
                CPicker.Focus();
            }
            else
            {
                CPicker = new ColorPicker(btn);
                CPicker.Show();
                int Xpos = this.Left + ((this.Width - CPicker.Width) / 2);
                int Ypos = this.Top;
                CPicker.Location = new Point(Xpos, Ypos);
                CPicker.BringToFront();
                CPicker.Focus();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button3);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button4);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button5);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button8);
        }
        private void button9_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button9);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button10);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button11);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button12);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button14);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button16);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button15);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button17);
        }
    }
}
