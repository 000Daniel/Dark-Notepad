using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DarkNotepad
{
            //  For more help head to: https://github.com/000Daniel
    public partial class ViewHelp : Form
    {
        private Notepad dnp = Application.OpenForms.OfType<Notepad>().First();
        private bool useCustomScrollbar = false;
        private CustomScrollbar_Commands CSC = new CustomScrollbar_Commands();
        public bool VScrollBar4_HoldingUp = false, VScrollBar4_HoldingDown = false;

        public ViewHelp()
        {
            InitializeComponent();
            CSC.dnp = dnp;
            CSC.vh = this;

            useCustomScrollbar = Settings1.Default.CustomScrollbar;
            if (useCustomScrollbar)
            {
                pictureBox1.Image = dnp.Check2;
            }
            else
            {
                pictureBox1.Image = dnp.Check;
            }
            if (Settings1.Default.StatusBar)
            {
                pictureBox2.Image = dnp.Check2;
            }
            else
            {
                pictureBox2.Image = dnp.Check;
            }
            if (dnp.richTextBox1.RightToLeft == RightToLeft.Yes)
            {
                pictureBox3.Image = dnp.Check2;
            }
            else
            {
                pictureBox3.Image = dnp.Check;
            }
            if (Settings1.Default.AddRegistryKey)
            {
                pictureBox4.Image = dnp.Check2;
            }
            else
            {
                pictureBox4.Image = dnp.Check;
            }
            updateThemeColors();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ViewHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            dnp.richTextBox1.Focus();
        }

                //  This displays the shortcuts.
        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            ScrollGraphics();
            settingsPanel.Visible = false;
            label1.Text = "Shortcuts:";
        }

                //  This displays the settings.
        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            ScrollGraphics();
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
            VScrollbar4_Thumb.Left = 1;
            VScrollbar4_Thumb.Width = 15;
            VScrollBar4_ArrowUp.MouseDown += new MouseEventHandler(CSC.VScrollBar4_ArrowUp_MouseDown);
            VScrollBar4_ArrowUp.MouseUp += new MouseEventHandler(CSC.VScrollBar4_ArrowUp_MouseUp);
            VScrollBar4_ArrowUp.Click += new EventHandler(CSC.VScrollBar4_ArrowUp_Click);
            VScrollBar4_ArrowUp.Image = dnp.VSB_Arrow_Up;
            VScrollBar4_ArrowDown.MouseDown += new MouseEventHandler(CSC.VScrollBar4_ArrowDown_MouseDown);
            VScrollBar4_ArrowDown.MouseUp += new MouseEventHandler(CSC.VScrollBar4_ArrowDown_MouseUp);
            VScrollBar4_ArrowDown.Click += new EventHandler(CSC.VScrollBar4_ArrowDown_Click);
            VScrollBar4_ArrowDown.Image = dnp.VSB_Arrow_Down;
            ScrollGraphics();
        }

                //  'ScrollGraphics()' handles the custom scrollbar.
        private void ScrollGraphics()
        {
            if (!useCustomScrollbar)
            {
                VScrollbar4.Visible = false;
                VScrollBar4_ArrowUp.Visible = false;
                VScrollBar4_ArrowDown.Visible = false;
                VScrollbar4_Timer.Enabled = false;
                return;
            }
            if (!VScrollbar4.Visible)
            {
                VScrollbar4.Visible = true;
                VScrollBar4_ArrowUp.Visible = true;
                VScrollBar4_ArrowDown.Visible = true;
                VScrollbar4_Timer.Enabled = true;
            }
            Rectangle rect;
            if (flowLayoutPanel1.Visible)
            {
                rect = new Rectangle(backgroundPanel.Left + flowLayoutPanel1.Left, backgroundPanel.Top + flowLayoutPanel1.Top, flowLayoutPanel1.Width, flowLayoutPanel1.Height);
            }
            else
            {
                rect = new Rectangle(backgroundPanel.Left + settingsPanel.Left, backgroundPanel.Top + settingsPanel.Top, settingsPanel.Width, settingsPanel.Height);
            }
            VScrollbar4.Size = new Size (17, rect.Height - 34);
            VScrollbar4.Location = new Point(rect.Width + rect.Left - 17, rect.Top + 17);
            VScrollBar4_ArrowUp.Location = new Point(rect.Width + rect.Left - 17, rect.Top);
            VScrollBar4_ArrowDown.Location = new Point(rect.Width + rect.Left - 17, rect.Top + rect.Height - 17);
        }
        private void VScrollbar4_Timer_Tick(object sender, EventArgs e)
        {
            if (VScrollBar4_HoldingUp) CSC.VScrollBar4_ArrowUp_Click(null,null);
            if (VScrollBar4_HoldingDown) CSC.VScrollBar4_ArrowDown_Click(null,null);

            IntPtr Hwnd;
            if (flowLayoutPanel1.Visible)
            {
                Hwnd = flowLayoutPanel1.Handle;
            }
            else
            {
                Hwnd = settingsPanel.Handle;
            }

            CSC.ScrollSelection(Hwnd, VScrollbar4_Thumb, VScrollbar4);
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            useCustomScrollbar = !useCustomScrollbar;
            Settings1.Default.CustomScrollbar = useCustomScrollbar;
            Settings1.Default.Save();

            if (useCustomScrollbar)
            {
                pictureBox1.Image = dnp.Check2;
            }
            else
            {
                pictureBox1.Image = dnp.Check;
            }
            ScrollGraphics();
            dnp.ScrollGraphics();
        }
        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            dnp.StatusBarFunc();
            if (Settings1.Default.StatusBar)
            {
                pictureBox2.Image = dnp.Check2;
            }
            else
            {
                pictureBox2.Image = dnp.Check;
            }
        }
        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            dnp.RightToLeftFunc();
            if (dnp.richTextBox1.RightToLeft == RightToLeft.Yes)
            {
                pictureBox3.Image = dnp.Check2;
            }
            else
            {
                pictureBox3.Image = dnp.Check;
            }
        }

        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            Settings1.Default.AddRegistryKey = !Settings1.Default.AddRegistryKey;
            Settings1.Default.Save();

            if (Settings1.Default.AddRegistryKey)
            {
                pictureBox4.Image = dnp.Check2;

                try
                {
                    string batchFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "regkey_repair.bat");
                    if (!File.Exists(batchFilePath))
                    {
                        throw(new Exception("Couldn't find the repair file (regkey_repair.bat).\nPlease reinstall Dark-Notepad to fix this issue."));
                    }
                    Process.Start(new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        Verb = "runas",
                        Arguments = "repair " + Path.GetDirectoryName(Application.ExecutablePath),
                        FileName = batchFilePath,
                    });
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
            else
            {
                pictureBox4.Image = dnp.Check;

                try
                {
                    string batchFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "regkey_repair.bat");
                    if (!File.Exists(batchFilePath))
                    {
                        throw(new Exception("Couldn't find the repair file (regkey_repair.bat).\nPlease reinstall Dark-Notepad to fix this issue."));
                    }
                    Process.Start(new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        Verb = "runas",
                        Arguments = "remove ",
                        FileName = batchFilePath,
                    });
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
            backgroundPanel2.BackColor = SStylize.Background_Highlight;
            BorderPanel.BackColor = SStylize.Background;
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
            label10.ForeColor = SStylize.Text;
            label10.BackColor = SStylize.Background_Highlight;
            label11.ForeColor = SStylize.Text;
            label11.BackColor = SStylize.Background_Highlight;
            label12.ForeColor = SStylize.Text;
            label12.BackColor = SStylize.Background_Highlight;
            label13.ForeColor = SStylize.Text;
            label13.BackColor = SStylize.Background_Highlight;
            label14.ForeColor = SStylize.Text;
            label14.BackColor = SStylize.Background_Highlight;
            label15.ForeColor = SStylize.Text;
            label15.BackColor = SStylize.Background_Highlight;
            label16.ForeColor = SStylize.Text;
            label16.BackColor = SStylize.Background_Highlight;
            label17.ForeColor = SStylize.Text;
            label17.BackColor = SStylize.Background_Highlight;
            textBox1.ForeColor = SStylize.Text;
            textBox1.BackColor = SStylize.Background_Highlight;
            flowLayoutPanel1.BackColor = SStylize.Background_Highlight;
            flowLayoutPanel1.ForeColor = SStylize.Text;
            textBox1.BackColor = SStylize.TextBox;
            textBox1.ForeColor = SStylize.TextBox_Text;
            VScrollbar4.BackColor = SStylize.Scrollbar_Tint;
            VScrollbar4_Thumb.BackColor = SStylize.Scrollbar;
            VScrollBar4_ArrowUp.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar4_ArrowUp.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar4_ArrowUp.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
            VScrollBar4_ArrowDown.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar4_ArrowDown.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar4_ArrowDown.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
        }
    }
}
