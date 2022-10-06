using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
            //  For more help head to: https://github.com/000Daniel
    public partial class ViewHelp : Form
    {
        private Notepad dnp;

        public ViewHelp()
        {
            InitializeComponent();
            updateThemeColors();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            updateDNT(sender, e);
            dnp.Focus();
            dnp.richTextBox1.Focus();
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

                //  This displays the shortcuts.
        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            settingsPanel.Visible = false;
            label1.Text = "Shortcuts:";
        }

                //  This displays the settings.
        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            settingsPanel.Visible = true;
            label1.Text = "Settings:";
        }

        private void ViewHelp_Load(object sender, EventArgs e)
        {
            settingsPanel.Visible = false;
            textBox1.Text = Settings1.Default.CustomBrowserURL;
            button4.Text = Settings1.Default.Encode.ToString();
            updateURL();
            updateRadioButtons();
        }
        private void updateRadioButtons()
        {
            string SearchEngine = Settings1.Default.SearchEngine;

            switch (SearchEngine)
            {
                case "DuckDuckGo":
                    radioButton1.Checked = true;
                    break;
                case "Google":
                    radioButton2.Checked = true;
                    break;
                case "Bing":
                    radioButton3.Checked = true;
                    break;
                case "SearX":
                    radioButton4.Checked = true;
                    break;
                case "Yandex":
                    radioButton5.Checked = true;
                    break;
            }
            if (textBox1.Text != String.Empty)
            {
                disableRadioButtons();
            }
            else
            {
                radioButton1.ForeColor = SettingsStylize.Default.Text;
                radioButton2.ForeColor = SettingsStylize.Default.Text;
                radioButton3.ForeColor = SettingsStylize.Default.Text;
                radioButton4.ForeColor = SettingsStylize.Default.Text;
                radioButton5.ForeColor = SettingsStylize.Default.Text;
            }
        }
        private void disableRadioButtons()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton1.ForeColor = SettingsStylize.Default.Button_Unavailable_Text;
            radioButton2.ForeColor = SettingsStylize.Default.Button_Unavailable_Text;
            radioButton3.ForeColor = SettingsStylize.Default.Button_Unavailable_Text;
            radioButton4.ForeColor = SettingsStylize.Default.Button_Unavailable_Text;
            radioButton5.ForeColor = SettingsStylize.Default.Button_Unavailable_Text;
        }
        private void updateURL()
        {
            if (textBox1.Text != String.Empty)
            {
                disableRadioButtons();
            }
            Settings1 SE = Settings1.Default;

            if (radioButton1.Checked)
            {
                SE.SearchEngine = "DuckDuckGo";
            }
            if (radioButton2.Checked)
            {
                SE.SearchEngine = "Google";
            }
            if (radioButton3.Checked)
            {
                SE.SearchEngine = "Bing";
            }
            if (radioButton4.Checked)
            {
                SE.SearchEngine = "SearX";
            }
            if (radioButton5.Checked)
            {
                SE.SearchEngine = "Yandex";
            }
            SE.CustomBrowserURL = textBox1.Text;
            SE.Save();
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            updateURL();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            updateRadioButtons();
            updateURL();
        }

                //  This button creates a context menu using the 'ContextMenu' script.
                //  This allows the user to change the Encoding (for saving a file).
        private void button4_Click(object sender, EventArgs e)
        {
            ContextMenu cxm = new ContextMenu();
            cxm.ShowInTaskbar = false;
            cxm.panelSize = 136;
            cxm.createButton(sender, e, "ASCII", "Encode1");
            cxm.createButton(sender, e, "Latin1", "Encode2");
            cxm.createButton(sender, e, "UTF-32", "Encode3");
            cxm.createButton(sender, e, "UTF-16 Unicode", "Encode4");
            cxm.createButton(sender, e, "UTF-16 BE", "Encode5");
            cxm.createButton(sender, e, "UTF-8", "Encode6");
            cxm.createButton(sender, e, "UTF-7", "Encode7");

            cxm.Show();

            int Xpos = button4.Location.X + backgroundPanel.Location.X + settingsPanel.Location.X + this.Left + 7;
            int Ypox = button4.Location.Y + backgroundPanel.Location.Y + settingsPanel.Location.Y + button4.Size.Height + 30 + this.Top;
            cxm.Location = new Point(Xpos, Ypox);

            cxm = null;
        }

        public void updateThemeColors()
        {
            SettingsStylize SStylize = SettingsStylize.Default;
            this.BackColor = SStylize.Background;
            this.ForeColor = SStylize.Text;
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
            button3.BackColor = SStylize.Button;
            button3.FlatAppearance.BorderColor = SStylize.Button_Border;
            button3.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;
            button3.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            button3.ForeColor = SStylize.Button_Text;
            button4.BackColor = SStylize.Button;
            button4.ForeColor = SStylize.Text;
            button4.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            button4.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;
            backgroundPanel.BackColor = SStylize.Background_Highlight;
            label1.ForeColor = SStylize.Text;
            label1.BackColor = SStylize.Background_Highlight;
            label2.ForeColor = SStylize.Text;
            label2.BackColor = SStylize.Background_Highlight;
            label3.ForeColor = SStylize.Text;
            label3.BackColor = SStylize.Background_Highlight;
            label4.ForeColor = SStylize.Text;
            label4.BackColor = SStylize.Background_Highlight;
            label5.ForeColor = SStylize.Text;
            label5.BackColor = SStylize.Background_Highlight;
            label6.ForeColor = SStylize.Text;
            label6.BackColor = SStylize.Background_Highlight;
            label9.ForeColor = SStylize.Text;
            label9.BackColor = SStylize.Background_Highlight;
            textBox1.ForeColor = SStylize.Text;
            textBox1.BackColor = SStylize.Background_Highlight;
            flowLayoutPanel1.BackColor = SStylize.Background_Highlight;
            flowLayoutPanel1.ForeColor = SStylize.Text;
            textBox1.BackColor = SStylize.TextBox;
            textBox1.ForeColor = SStylize.TextBox_Text;
        }
    }
}
