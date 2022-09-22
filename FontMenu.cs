using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class FontMenu : Form
    {
        private int curFont = 0;
        private bool finishedLoading = false;
        private bool finishedLoadingSyles = false;
        InstalledFontCollection ifc = new InstalledFontCollection();
        private String[] extensions = new string[] {"Condensed","Light", "Light Condensed", "Light SemiCondensed",
                "SemiBold", "SemiBold Condensed", "SemiBold SemiConden", "SemiCondensed",
            "SemiLight", "SemiLight Condensed", "SemiLight SemiConde", "ExtraLight", "Narrow",
            "Black", "Medium"};
        private String[] StyleExtensions = new string[] {"Regular", "Bold", "Italic",
            "Underline", "Strikeout"};
        private Color Bcolor;
        private Color Fcolor;
        private Font settingsFont;

        public FontMenu()
        {
            InitializeComponent();
        }

        private void FontMenu_Load(object sender, EventArgs e)
        {
            Bcolor = richTextBox1.BackColor;
            Fcolor = richTextBox1.ForeColor;

            settingsFont = Settings1.Default.Font;
            textBox1.Text = Settings1.Default.Font.Name;
            textBox2.Text = Settings1.Default.Font.Style.ToString();
            textBox3.Text = Settings1.Default.Font.Size.ToString();
            label1.Text = "Font: (Loading)";
            label2.Text = "Font style: (Loading)";
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
            updateThemeColors();
            UpdatePreviewText();
        }

        private void FontFinder_Tick(object sender, EventArgs e)
        {
            if (richTextBox1.ZoomFactor != 1)
            {
                richTextBox1.ZoomFactor = 1;
            }

            if (curFont <= ifc.Families.Length - 1)
            {
                //  This foreach loop checks if the font is an extension of another font.
                foreach (string extension in extensions)
                {
                    if (ifc.Families[curFont].Name.ToLower().Contains(extension.ToLower()))
                    {
                        int lastIndex = ifc.Families[curFont].Name.ToLower().LastIndexOf(extension.ToLower());
                        if (ifc.Families[curFont].Name.Length == lastIndex + extension.Length)
                        {
                            curFont++;
                            return;
                        }
                    }
                }

                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.AppendText(ifc.Families[curFont].Name);

                richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(richTextBox1.Lines.Count() - 1);
                richTextBox1.SelectionLength = richTextBox1.Lines[richTextBox1.Lines.Count() - 1].Length;
                richTextBox1.SelectionFont = new Font(ifc.Families[curFont], 12F);
                if (curFont != ifc.Families.Length - 1)
                {
                    richTextBox1.AppendText("\n");
                }
            }
            else if (!finishedLoading)
            {
                label1.Text = "Font:";
                finishedLoading = true;
            }
            curFont++;
        }

        private void FontFinder2_Tick(object sender, EventArgs e)
        {
            if (curFont <= ifc.Families.Length - 1)
            {
                //  This foreach loop checks if the font is an extension of another font.
                foreach (string extension in extensions)
                {
                    if (ifc.Families[curFont].Name.ToLower().Contains(extension.ToLower()))
                    {
                        int lastIndex = ifc.Families[curFont].Name.ToLower().LastIndexOf(extension.ToLower());
                        if (ifc.Families[curFont].Name.Length == lastIndex + extension.Length)
                        {
                            curFont++;
                            return;
                        }
                    }
                }

                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.AppendText(ifc.Families[curFont].Name);

                richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(richTextBox1.Lines.Count() - 1);
                richTextBox1.SelectionLength = richTextBox1.Lines[richTextBox1.Lines.Count() - 1].Length;
                richTextBox1.SelectionFont = new Font(ifc.Families[curFont], 12F);
                if (curFont != ifc.Families.Length - 1)
                {
                    richTextBox1.AppendText("\n");
                }
            }
            else if (!finishedLoading)
            {
                label1.Text = "Font:";
                finishedLoading = true;
            }
            curFont++;
        }

        private void FontFinder3_Tick(object sender, EventArgs e)
        {
            if (curFont <= ifc.Families.Length - 1)
            {
                //  This foreach loop checks if the font is an extension of another font.
                foreach (string extension in extensions)
                {
                    if (ifc.Families[curFont].Name.ToLower().Contains(extension.ToLower()))
                    {
                        int lastIndex = ifc.Families[curFont].Name.ToLower().LastIndexOf(extension.ToLower());
                        if (ifc.Families[curFont].Name.Length == lastIndex + extension.Length)
                        {
                            curFont++;
                            return;
                        }
                    }
                }

                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.AppendText(ifc.Families[curFont].Name);

                richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(richTextBox1.Lines.Count() - 1);
                richTextBox1.SelectionLength = richTextBox1.Lines[richTextBox1.Lines.Count() - 1].Length;
                richTextBox1.SelectionFont = new Font(ifc.Families[curFont], 12F);
                if (curFont != ifc.Families.Length - 1)
                {
                    richTextBox1.AppendText("\n");
                }
            }
            else if (!finishedLoading)
            {
                label1.Text = "Font:";
                finishedLoading = true;
            }
            curFont++;
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (!finishedLoading)
            {
                textBox1.Focus();
                return;
            }
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            if (!finishedLoading)
            {
                textBox1.Focus();
                return;
            }
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!finishedLoading)
            {
                textBox1.Focus();
                return;
            }

            int lineIndex = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
            richTextBox1.SelectionStart = richTextBox1.GetFirstCharIndexFromLine(lineIndex);
            richTextBox1.SelectionLength = richTextBox1.Lines[lineIndex].Length;

            if (richTextBox1.SelectedText == String.Empty) return;
            textBox1.Text = richTextBox1.SelectedText;
            settingsFont = new Font(textBox1.Text, settingsFont.Size, FontStyle.Regular);
            UpdatePreviewText();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FontStyleFinder.Enabled = true;
        }

        private void FontStyleFinder_Tick(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            label2.Text = "Font style: (Loading)";

            try
            {
                FontFamily ff2 = new FontFamily(textBox1.Text);
            }
            catch
            {
                return;
            }

            FontFamily ff = new FontFamily(textBox1.Text);
            foreach (FontFamily off in ifc.Families)
            {
                if (!off.Name.ToLower().Contains(ff.Name.ToLower()))
                {
                    continue;
                }
                foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
                {
                    if (off.IsStyleAvailable(style))
                    {
                        int selectionStart = richTextBox2.Text.Length;
                        richTextBox2.SelectionStart = selectionStart;
                        string appendThis = String.Format("{0} {1}", off.Name, style.ToString());
                        richTextBox2.AppendText(appendThis);

                        richTextBox2.SelectionStart = selectionStart;
                        richTextBox2.SelectionLength = appendThis.Length;
                        richTextBox2.SelectionFont = new Font("Arial", 12F, style);
                        richTextBox2.AppendText("\n");

                        appendThis = null;
                    }
                }
            }
            label2.Text = "Font style:";
            finishedLoadingSyles = true;
            FontStyleFinder.Enabled = false;
        }

        private void richTextBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (!finishedLoadingSyles)
            {
                textBox2.Focus();
                return;
            }

            int lineIndex = richTextBox2.GetLineFromCharIndex(richTextBox2.SelectionStart);
            richTextBox2.SelectionStart = richTextBox2.GetFirstCharIndexFromLine(lineIndex);
            richTextBox2.SelectionLength = richTextBox2.Lines[lineIndex].Length;

            if (richTextBox2.SelectedText == String.Empty) return;
            textBox2.Text = richTextBox2.SelectedText;

            string regularFont = "";
            string styleOfFont = "";

            foreach (string extension in StyleExtensions)
            {
                if (textBox2.Text.ToLower().Contains(extension.ToLower()))
                {
                    regularFont = textBox2.Text.Substring(0, textBox2.Text.ToLower().LastIndexOf(extension.ToLower())).Trim();
                    styleOfFont = textBox2.Text.Substring(regularFont.Length).Trim();
                }
            }
            if (regularFont == String.Empty || styleOfFont == String.Empty) return;

            FontStyle fs = (FontStyle)Enum.Parse(typeof(FontStyle), styleOfFont);
            settingsFont = new Font(regularFont, settingsFont.Size, fs);

            regularFont = null;
            styleOfFont = null;
            UpdatePreviewText();
        }

        private void UpdatePreviewText()
        {
            preview_label.Font = settingsFont;

            int Xpos = Sample_Text_Panel.Size.Width / 2
                - preview_label.Size.Width / 2;
            int Ypos = Sample_Text_Panel.Size.Height / 2
                - preview_label.Size.Height / 2;

            preview_label.Location = new Point(Xpos, Ypos);
        }

        private void richTextBox3_MouseUp(object sender, MouseEventArgs e)
        {
            int lineIndex = richTextBox3.GetLineFromCharIndex(richTextBox3.SelectionStart);
            richTextBox3.SelectionStart = richTextBox3.GetFirstCharIndexFromLine(lineIndex);
            richTextBox3.SelectionLength = richTextBox3.Lines[lineIndex].Length;

            if (richTextBox3.SelectedText == String.Empty) return;
            textBox3.Text = richTextBox3.SelectedText;
            settingsFont = new Font(settingsFont.FontFamily, int.Parse(textBox3.Text), settingsFont.Style);
            UpdatePreviewText();
        }

        private void scrollWithArrows(object sender, KeyEventArgs e, RichTextBox rtb, TextBox tb, bool fromTextBox = false)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (!fromTextBox)
                    e.Handled = true;
                tb.Focus();
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                rtb.Focus();
                int selectedCurrentLine = rtb.GetLineFromCharIndex(rtb.SelectionStart);
                if (selectedCurrentLine >= rtb.Lines.Count() - 1) return;

                rtb.SelectionStart = rtb.GetFirstCharIndexFromLine(selectedCurrentLine + 1);
                switch (rtb.Name)
                {
                    case "richTextBox1":
                        richTextBox1_MouseUp(sender, null);
                        break;
                    case "richTextBox2":
                        richTextBox2_MouseUp(sender, null);
                        break;
                    case "richTextBox3":
                        richTextBox3_MouseUp(sender, null);
                        break;
                }

            }
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                rtb.Focus();
                int selectedCurrentLine = rtb.GetLineFromCharIndex(rtb.SelectionStart);
                if (selectedCurrentLine <= 0) return;

                rtb.SelectionStart = rtb.GetFirstCharIndexFromLine(selectedCurrentLine - 1);
                switch (rtb.Name)
                {
                    case "richTextBox1":
                        richTextBox1_MouseUp(sender, null);
                        break;
                    case "richTextBox2":
                        richTextBox2_MouseUp(sender, null);
                        break;
                    case "richTextBox3":
                        richTextBox3_MouseUp(sender, null);
                        break;
                }
            }
        }
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            scrollWithArrows(sender, e, richTextBox1, textBox1);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            scrollWithArrows(sender, e, richTextBox1, textBox1, true);
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            scrollWithArrows(sender, e, richTextBox2, textBox2);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            scrollWithArrows(sender, e, richTextBox2, textBox2, true);
        }

        private void richTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            scrollWithArrows(sender, e, richTextBox3, textBox3);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            scrollWithArrows(sender, e, richTextBox3, textBox3, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings1.Default.Font = settingsFont;
            Settings1.Default.Save();
            Notepad dnp = new Notepad();
            if (Application.OpenForms.OfType<Notepad>().Any())
            {
                dnp = Application.OpenForms.OfType<Notepad>().First();
                dnp.UpdateTextFont();
                dnp = null;
            }
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo("ms-settings:fonts");
                proc.UseShellExecute = true;
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error!:\n" + ex.Message);
            }
        }

        public void updateThemeColors()
        {
            SettingsStylize SStylize = SettingsStylize.Default;
            this.BackColor = SStylize.Background;
            this.ForeColor = SStylize.Text;
            label1.BackColor = SStylize.Background;
            label1.ForeColor = SStylize.Text;
            label2.BackColor = SStylize.Background;
            label2.ForeColor = SStylize.Text;
            label3.BackColor = SStylize.Background;
            label3.ForeColor = SStylize.Text;
            textBox1.BackColor = SStylize.TextBox;
            textBox1.ForeColor = SStylize.TextBox_Text;
            textBox2.BackColor = SStylize.TextBox;
            textBox2.ForeColor = SStylize.TextBox_Text;
            textBox3.BackColor = SStylize.TextBox;
            textBox3.ForeColor = SStylize.TextBox_Text;
            richTextBox1.BackColor = SStylize.TextBox;
            richTextBox1.ForeColor = SStylize.TextBox_Text;
            richTextBox2.BackColor = SStylize.TextBox;
            richTextBox2.ForeColor = SStylize.TextBox_Text;
            richTextBox3.BackColor = SStylize.TextBox;
            richTextBox3.ForeColor = SStylize.TextBox_Text;
            button1.BackColor = SStylize.Button;
            button1.FlatAppearance.BorderColor = SStylize.Button_Border;
            button1.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;
            button1.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            button1.ForeColor = SStylize.Button_Text;
            button2.BackColor = SStylize.Button;
            button2.FlatAppearance.BorderColor = SStylize.Button_Border;
            button2.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;
            button2.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            button2.ForeColor = SStylize.Button_Text;
            linkLabel1.BackColor = SStylize.Background;
            linkLabel1.LinkColor = SStylize.Link;
            linkLabel1.VisitedLinkColor = SStylize.Link_Pressed;
            linkLabel1.ActiveLinkColor = SStylize.Link_Pressed;
            preview_label.BackColor = SStylize.Background;
            preview_label.ForeColor = SStylize.Text;
            groupBox1.BackColor = SStylize.Background;
            groupBox1.ForeColor = SStylize.Text;
            Sample_Text_Panel.BackColor = SStylize.Background;
        }
    }
}
