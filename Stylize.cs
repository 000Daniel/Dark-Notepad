using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
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
        public Notepad dnp = Application.OpenForms.OfType<Notepad>().First();
        private SettingsStylize SStyle = SettingsStylize.Default;

        public Stylize()
        {
            InitializeComponent();
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
            SetColor(button18, SStyle.Scrollbar);
            SetColor(button19, SStyle.Scrollbar_Icon_Background);
            SetColor(button20, SStyle.Scrollbar_Tint);
            SetColor(button21, SStyle.Scrollbar_Icon);
            SetColor(button23, SStyle.Scrollbar_Icon_Tint);
            SetColor(button24, SStyle.Status);
            SetColor(button25, SStyle.Status_Text);
            SetColor(button22, SStyle.Status_Splitter);

            UpdatePreviewWindow();
        }
        private void SetColor(Button btn, Color color)
        {
            if (btn == null) return;
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
            Preview_PanelHighlight3.BackColor = button2.BackColor;
            Preview_PanelHighlight4.BackColor = button2.BackColor;
            Preview_StatusSplitter.BackColor = button22.BackColor;

            Preview_Label.ForeColor = button3.BackColor;
            Preview_Label.BackColor = button1.BackColor;
            Preview_LinkLabel.LinkColor = button4.BackColor;
            Preview_LinkLabel.BackColor = button1.BackColor;
            Preview_LinkLabel.ActiveLinkColor = button5.BackColor;
            Preview_LinkLabel.VisitedLinkColor = button4.BackColor;

            Preview_RichTextBox.ForeColor = button3.BackColor;
            Preview_RichTextBox.BackColor = button1.BackColor;
            Preview_Scrollbar.BackColor = button20.BackColor;
            Preview_Scrollbar_Thumb.BackColor = button18.BackColor;
            Preview_IconButton.ForeColor = button21.BackColor;
            Preview_IconButton.BackColor = button19.BackColor;
            Preview_IconButton.FlatAppearance.MouseOverBackColor = button19.BackColor;
            Preview_IconButton.FlatAppearance.MouseDownBackColor = button23.BackColor;
            Preview_Label3.ForeColor = button3.BackColor;
            Preview_Label3.BackColor = button1.BackColor;

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

            Preview_Label2.ForeColor = button25.BackColor;
            Preview_Label2.BackColor = button24.BackColor;
            Preview_StatusPanel.BackColor = button24.BackColor;
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Stylize_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.OfType<ColorPicker>().Any())
                Application.OpenForms.OfType<ColorPicker>().First().Close();
            this.Dispose();
            dnp.richTextBox1.Focus();
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
            SStyle.Scrollbar = button18.BackColor;
            SStyle.Scrollbar_Icon_Background = button19.BackColor;
            SStyle.Scrollbar_Tint = button20.BackColor;
            SStyle.Scrollbar_Icon = button21.BackColor;
            SStyle.Scrollbar_Icon_Tint = button23.BackColor;
            SStyle.Status_Splitter = button22.BackColor;
            SStyle.Status = button24.BackColor;
            SStyle.Status_Text = button25.BackColor;

            SStyle.Save();

            dnp.updateThemeColors();
            dnp.CreateCustomIcons();
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
            dnp.CreateCustomIcons();
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
        private void button18_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button18);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button19);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button20);
        }
        private void button21_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button21);
        }
        private void button22_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button22);
        }
        private void button23_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button23);
        }
        private void button24_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button24);
        }
        private void button25_Click(object sender, EventArgs e)
        {
            open_ColorPicker(button25);
        }

                //  This function imports the stylizing settings from a file.
        private void Import_Button_Click(object sender, EventArgs e)
        {
                    //  'ImportThemeDir' exists so that if the user imports a theme the
                    //  default directory would be the themes or executable folders.
            string def_path = Settings1.Default.ImportThemeDir;
            if (def_path == string.Empty)
            {
                string temp_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "themes");
                if (Directory.Exists(temp_path))
                {
                    def_path = temp_path;
                } else
                {
                    def_path = Path.GetDirectoryName(Application.ExecutablePath);
                }
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Theme Config |*.config|All Files |*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Import Theme";
            ofd.InitialDirectory = def_path;
            if (ofd.ShowDialog() == DialogResult.Cancel) return;

            Settings1.Default.ImportThemeDir = Path.GetDirectoryName(ofd.FileName);
            bool foundVersion = false;

            try
            {
                        //  It checks each line and breaks it into two parts.
                        //  'lineStyle' - which element should be changed.
                        //  'lineColor' - with what color.
                foreach (string line in File.ReadLines(ofd.FileName))
                {
                    if (line == String.Empty) continue;
                    string lineStyle = line.Substring(0, line.IndexOf("/"));
                    string lineColor = line.Substring(line.IndexOf("/") + 1);
                    Button btn = null;
                    Color clr = Color.Black;

                    switch (lineStyle)
                    {
                        case "Version":
                            foundVersion = true;

                            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                            string ver_str = String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
                            if (lineColor.Equals(ver_str)) break;

                            WarningBox WB = new WarningBox("Theme is from a different version of Dark Notepad!\nTheme may be incompatible.");
                            WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                            WB.StartPosition = FormStartPosition.CenterScreen;
                            WB.Show();
                            WB.BringToFront();

                            WB = null;
                            break;
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
                        case "Scrollbar":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button18;
                            break;
                        case "Scrollbar_Tint":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button20;
                            break;
                        case "Scrollbar_Icon":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button21;
                            break;
                        case "Scrollbar_Icon_Background":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button19;
                            break;
                        case "Scrollbar_Icon_Tint":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button23;
                            break;
                        case "Status":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button24;
                            break;
                        case "Status_Text":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button25;
                            break;
                        case "Status_Splitter":
                            clr = ColorTranslator.FromHtml(lineColor);
                            btn = button22;
                            break;
                    }
                    SetColor(btn, clr);
                }
                UpdatePreviewWindow();
            }
            catch (Exception ex)
            {
                WarningBox WB = new WarningBox(ex.Message);
                WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();

                WB = null;
                Stylize_Load(null,null);
            }
            if (!foundVersion)
            {
                WarningBox WB = new WarningBox("Couldn't find theme version!\nTheme may be incompatible.");
                WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();

                WB = null;
            }
        }

                //  This exports the currently saved theme into a file.
        private void Export_Button_Click(object sender, EventArgs e)
        {
            try
            {
                        //  'ExportThemeDir' exists so that if the user exports a theme the
                        //  default directory would be the themes or executable folders.
                string def_path = Settings1.Default.ExportThemeDir;
                if (def_path == string.Empty)
                {
                    string temp_path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "themes");
                    if (Directory.Exists(temp_path))
                    {
                        def_path = temp_path;
                    }
                    else
                    {
                        def_path = Path.GetDirectoryName(Application.ExecutablePath);
                    }
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Theme Config |*.config|All Files |*.*";
                sfd.FilterIndex = 1;
                sfd.Title = "Export Theme";
                sfd.InitialDirectory = def_path;

                if (sfd.ShowDialog() == DialogResult.Cancel) return;
                Settings1.Default.ExportThemeDir = Path.GetDirectoryName(sfd.FileName);

                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string ver_str = String.Format("{0}.{1}.{2}",version.Major,version.Minor,version.Build);
                string[] themeConfig = {
                "Version/" + ver_str,
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
                "Text_Error/" + colorFormat(button17),
                "Scrollbar/" + colorFormat(button18),
                "Scrollbar_Tint/" + colorFormat(button20),
                "Scrollbar_Icon/" + colorFormat(button21),
                "Scrollbar_Icon_Background/" + colorFormat(button19),
                "Scrollbar_Icon_Tint/" + colorFormat(button23),
                "Status/" + colorFormat(button24),
                "Status_Text/" + colorFormat(button25),
                "Status_Splitter/" + colorFormat(button22)};

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
                WarningBox WB = new WarningBox(ex.Message);
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
