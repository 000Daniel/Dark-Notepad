using System;
using System.Drawing;
using System.IO;
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

        private void updateDNT(object sender, EventArgs e)
        {
            if (dnp != null) return;
            if (Application.OpenForms.OfType<Notepad>().Any())
                dnp = Application.OpenForms.OfType<Notepad>().First();
        }

                //  This loads the current settings to a button (to preview the color).
                // (loads from 'SettingsStylize.settings')
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

                //  This updates the preview window with the new settings.
                //  (this includes settings that have'nt been saved)
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

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            updateDNT(sender, e);

            if (Application.OpenForms.OfType<ColorPicker>().Any())
                Application.OpenForms.OfType<ColorPicker>().First().Close();

            dnp.Focus();
        }

                //  This saves the new theme settings to 'SettingsStylize.settings'.
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

        public void Reset_Click(object sender, EventArgs e)
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
            }
        }

                //  When the user clicks on a button(color preview) the Color Picker opens.
                //  Once the user clicks 'Apply' the button here gets updated with the new color.
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

                //  This function imports the stylizing settings from a file.
        private void Import_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Theme Config |*.config|All Files |*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Import Theme";
            if (ofd.ShowDialog() == DialogResult.Cancel) return;
            if (File.ReadLines(ofd.FileName).Count() < 17)
            {
                WarningBox WB = new WarningBox("Config file could not be loaded!\nFile may be corrupt");
                WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();

                WB = null;
                return;
            }

            try
            {
                        //  It checks each line and breaks it into two parts.
                        //  'lineStyle' - which element should be changed.
                        //  'lineColor' - with what color.
                foreach (string line in File.ReadLines(ofd.FileName))
                {
                    string lineStyle = line.Substring(0, line.IndexOf("/"));
                    string lineColor = line.Substring(line.IndexOf("/") + 1);
                    Button btn = null;
                    Color clr = Color.Black;

                    switch (lineStyle)
                    {
                        case "Background":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button1;
                            break;
                        case "Background_Highlight":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button2;
                            break;
                        case "Text":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button3;
                            break;
                        case "Link":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button4;
                            break;
                        case "Link_Pressed":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button5;
                            break;
                        case "Button":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button6;
                            break;
                        case "Button_Highlight":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button7;
                            break;
                        case "Button_Pressed":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button8;
                            break;
                        case "Button_Text":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button9;
                            break;
                        case "Button_Unavailable":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button10;
                            break;
                        case "Button_Unavailable_Highlight":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button11;
                            break;
                        case "Button_Unavailable_Pressed":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button12;
                            break;
                        case "Button_Unavailable_Text":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button13;
                            break;
                        case "Button_Border":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button14;
                            break;
                        case "TextBox_Text":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button15;
                            break;
                        case "TextBox":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button16;
                            break;
                        case "Text_Error":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button17;
                            break;
                    }

                    SetColor(btn, clr);
                }
                UpdatePreviewWindow();
            }
            catch (Exception ex)
            {
                WarningBox WB = new WarningBox(String.Format("{0}", ex.Message));
                WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();

                WB = null;
                Stylize_Load(null,null);
            }
        }

                //  This exports the currently saved theme into a file.
        private void Export_Button_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Theme Config |*.config|All Files |*.*";
                sfd.FilterIndex = 1;
                sfd.Title = "Export Theme";

                if (sfd.ShowDialog() == DialogResult.Cancel) return;

                string[] themeConfig = {
                "Background/" + colorFormat(button1),
                "Background_Highlight/" + colorFormat(button2),
                "Text/" + colorFormat(button3),
                "Link/" + colorFormat(button4),
                "Link_Pressed/" + colorFormat(button5),
                "Button/" + colorFormat(button6),
                "Button_Highlight/" + colorFormat(button7),
                "Button_Pressed/" + colorFormat(button8),
                "Button_Text/" + colorFormat(button9),
                "Button_Unavailable/" + colorFormat(button10),
                "Button_Unavailable_Highlight/" + colorFormat(button11),
                "Button_Unavailable_Pressed/" + colorFormat(button12),
                "Button_Unavailable_Text/" + colorFormat(button13),
                "Button_Border/" + colorFormat(button14),
                "TextBox_Text/" + colorFormat(button15),
                "TextBox/" + colorFormat(button16),
                "Text_Error/" + colorFormat(button17)};

                StreamWriter sw = new StreamWriter(File.Create(sfd.FileName));
                foreach (string str in themeConfig)
                {
                    sw.Write(str + "\n");
                }

                sw.Dispose();
                sfd.Dispose();
            }
            catch (Exception ex)
            {
                WarningBox WB = new WarningBox(String.Format("{0}", ex.Message));
                WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();

                WB = null;
            }
        }

                //  This function returns a string of the RGB values formatted like this: "x,x,x".
        private string colorFormat(Button btn)
        {
            return String.Format("{0},{1},{2}", btn.BackColor.R, btn.BackColor.G, btn.BackColor.B);
        }
    }
}
