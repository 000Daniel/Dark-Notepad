using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class FontMenu : Form
    {
        private int curFont = 0;
        private bool finishedLoading = false;
        public String[] StyleExtensions = new string[] {"Regular", "Bold", "Italic",
            "Underline", "Strikeout"};
        private int[] sizesArray = {8,9,10,11,12,14,16,18,20,22,24,26,28,36,48,72};
        private Font settingsFont;
        SettingsStylize SStylize = SettingsStylize.Default;
        public Button selectedButton1 = new Button();
        public Button selectedButton2 = new Button();
        public Button selectedButton3 = new Button();
        public int yPosButton = 0, yPosButton2 = 0, yPosButton3 = 0;

        private CustomScrollbar_Commands CSC = new CustomScrollbar_Commands();
        public bool VScrollBar1_HoldingUp = false, VScrollBar1_HoldingDown = false,
                VScrollBar2_HoldingUp = false, VScrollBar2_HoldingDown = false,
                VScrollBar3_HoldingUp = false, VScrollBar3_HoldingDown = false;

        public FontMenu()
        {
            InitializeComponent();
            CSC.dnp = Application.OpenForms.OfType<Notepad>().First();
            CSC.fm = this;
            KeyPreview = true;
        }
        private void FontMenu_Load(object sender, EventArgs e)
        {
            Notepad dnp = Application.OpenForms.OfType<Notepad>().First();
            settingsFont = Settings1.Default.Font;
            textBox1.Text = Settings1.Default.Font.Name;
            textBox2.Text = Settings1.Default.Font.Style.ToString();
            textBox3.Text = Settings1.Default.Font.Size.ToString();
            VScrollbar1_Thumb.Left = 1;
            VScrollbar1_Thumb.Width = 15;
            VScrollbar2_Thumb.Left = 1;
            VScrollbar2_Thumb.Width = 15;
            VScrollbar3_Thumb.Left = 1;
            VScrollbar3_Thumb.Width = 15;

            VScrollBar1_ArrowUp.MouseDown += new MouseEventHandler(CSC.VScrollBar1_ArrowUp_MouseDown);
            VScrollBar1_ArrowUp.MouseUp += new MouseEventHandler(CSC.VScrollBar1_ArrowUp_MouseUp);
            VScrollBar1_ArrowUp.Click += new EventHandler(CSC.VScrollBar1_ArrowUp_Click);
            VScrollBar1_ArrowUp.Image = dnp.VSB_Arrow_Up;
            VScrollBar1_ArrowDown.MouseDown += new MouseEventHandler(CSC.VScrollBar1_ArrowDown_MouseDown);
            VScrollBar1_ArrowDown.MouseUp += new MouseEventHandler(CSC.VScrollBar1_ArrowDown_MouseUp);
            VScrollBar1_ArrowDown.Click += new EventHandler(CSC.VScrollBar1_ArrowDown_Click);
            VScrollBar1_ArrowDown.Image = dnp.VSB_Arrow_Down;

            VScrollBar2_ArrowUp.MouseDown += new MouseEventHandler(CSC.VScrollBar2_ArrowUp_MouseDown);
            VScrollBar2_ArrowUp.MouseUp += new MouseEventHandler(CSC.VScrollBar2_ArrowUp_MouseUp);
            VScrollBar2_ArrowUp.Click += new EventHandler(CSC.VScrollBar2_ArrowUp_Click);
            VScrollBar2_ArrowUp.Image = dnp.VSB_Arrow_Up;
            VScrollBar2_ArrowDown.MouseDown += new MouseEventHandler(CSC.VScrollBar2_ArrowDown_MouseDown);
            VScrollBar2_ArrowDown.MouseUp += new MouseEventHandler(CSC.VScrollBar2_ArrowDown_MouseUp);
            VScrollBar2_ArrowDown.Click += new EventHandler(CSC.VScrollBar2_ArrowDown_Click);
            VScrollBar2_ArrowDown.Image = dnp.VSB_Arrow_Down;

            VScrollBar3_ArrowUp.MouseDown += new MouseEventHandler(CSC.VScrollBar3_ArrowUp_MouseDown);
            VScrollBar3_ArrowUp.MouseUp += new MouseEventHandler(CSC.VScrollBar3_ArrowUp_MouseUp);
            VScrollBar3_ArrowUp.Click += new EventHandler(CSC.VScrollBar3_ArrowUp_Click);
            VScrollBar3_ArrowUp.Image = dnp.VSB_Arrow_Up;
            VScrollBar3_ArrowDown.MouseDown += new MouseEventHandler(CSC.VScrollBar3_ArrowDown_MouseDown);
            VScrollBar3_ArrowDown.MouseUp += new MouseEventHandler(CSC.VScrollBar3_ArrowDown_MouseUp);
            VScrollBar3_ArrowDown.Click += new EventHandler(CSC.VScrollBar3_ArrowDown_Click);
            VScrollBar3_ArrowDown.Image = dnp.VSB_Arrow_Down;

            label1.Text = "Font: (Loading)";
            label2.Text = "Font style: (Loading)";
            SelectionMenu1.AutoScroll = false;
            this.SetStyle(ControlStyles.StandardDoubleClick, false);
            Font_Finder ff = new Font_Finder();
            ff.fm = this;
            ff.assignSizes(sizesArray);
            Scrollbar_Graphics();
            updateThemeColors();
            UpdatePreviewText();
        }

                //  Scrollbar_Graphics() and VScrollbar_Timer_Tick() are both responsible
                //  for the custom scrollbars' visuals.
        private void Scrollbar_Graphics()
        {
            if (!Settings1.Default.CustomScrollbar)
            {
                VScrollbar1.Visible = false;
                VScrollBar1_ArrowUp.Visible = false;
                VScrollBar1_ArrowDown.Visible = false;
                VScrollbar2.Visible = false;
                VScrollBar2_ArrowUp.Visible = false;
                VScrollBar2_ArrowDown.Visible = false;
                VScrollbar3.Visible = false;
                VScrollBar3_ArrowUp.Visible = false;
                VScrollBar3_ArrowDown.Visible = false;
                return;
            }

            if (!VScrollbar1.Visible)
            {
                VScrollbar1.Visible = true;
                VScrollbar2.Visible = true;
                VScrollbar3.Visible = true;
            }
            VScrollbar1.Size = new Size (17, SelectionMenu1.Height - 34);
            VScrollbar1.Location = new Point(SelectionMenu1.Width + SelectionMenu1.Left - 17, SelectionMenu1.Top + 17);
            VScrollBar1_ArrowUp.Location = new Point(SelectionMenu1.Width + SelectionMenu1.Left - 17, SelectionMenu1.Top);
            VScrollBar1_ArrowDown.Location = new Point(SelectionMenu1.Width + SelectionMenu1.Left - 17, SelectionMenu1.Top + SelectionMenu1.Height - 17);
            VScrollbar2.Size = new Size (17, SelectionMenu2.Height - 34);
            VScrollbar2.Location = new Point(SelectionMenu2.Width + SelectionMenu2.Left - 17, SelectionMenu2.Top + 17);
            VScrollBar2_ArrowUp.Location = new Point(SelectionMenu2.Width + SelectionMenu2.Left - 17, SelectionMenu2.Top);
            VScrollBar2_ArrowDown.Location = new Point(SelectionMenu2.Width + SelectionMenu2.Left - 17, SelectionMenu2.Top + SelectionMenu2.Height - 17);
            VScrollbar3.Size = new Size (17, SelectionMenu3.Height - 34);
            VScrollbar3.Location = new Point(SelectionMenu3.Width + SelectionMenu3.Left - 17, SelectionMenu3.Top + 17);
            VScrollBar3_ArrowUp.Location = new Point(SelectionMenu3.Width + SelectionMenu3.Left - 17, SelectionMenu3.Top);
            VScrollBar3_ArrowDown.Location = new Point(SelectionMenu3.Width + SelectionMenu3.Left - 17, SelectionMenu3.Top + SelectionMenu3.Height - 17);
        }

                //  This timer sets the size of the 'Scroll Thumb' of the scrollbars.
                //  it also scrolls if the user is pressing the scroll arrows.
        private void VScrollbar_Timer_Tick(object sender, EventArgs e)
        {
            CSC.ScrollSelection(SelectionMenu1.Handle,VScrollbar1_Thumb,VScrollbar1);
            CSC.ScrollSelection(SelectionMenu2.Handle,VScrollbar2_Thumb,VScrollbar2);
            CSC.ScrollSelection(SelectionMenu3.Handle,VScrollbar3_Thumb,VScrollbar3);

            if (VScrollBar1_HoldingUp) CSC.VScrollBar1_ArrowUp_Click(null,null);
            if (VScrollBar1_HoldingDown) CSC.VScrollBar1_ArrowDown_Click(null,null);
            if (VScrollBar2_HoldingUp) CSC.VScrollBar2_ArrowUp_Click(null,null);
            if (VScrollBar2_HoldingDown) CSC.VScrollBar2_ArrowDown_Click(null,null);
            if (VScrollBar3_HoldingUp) CSC.VScrollBar3_ArrowUp_Click(null,null);
            if (VScrollBar3_HoldingDown) CSC.VScrollBar3_ArrowDown_Click(null,null);
        }

                //  These FontFinder timers exist to speedup the process of finding and displaying
                //  all the available fonts.
        private void FontFinder_Tick(object sender, EventArgs e)
        {
            Font_Finder ff = new Font_Finder();
            ff.fm = this;
            curFont = ff.findFont(curFont, finishedLoading, label1);
            finishedLoading = ff.finishedLoading_;
            if (finishedLoading)
            {
                FontFinder.Dispose();
                FontFinder2.Dispose();
                FontFinder3.Dispose();
                SelectionMenu1.AutoScroll = true;
            }
        }
        private void FontFinder2_Tick(object sender, EventArgs e)
        {
            Font_Finder ff = new Font_Finder();
            ff.fm = this;
            curFont = ff.findFont(curFont, finishedLoading, label1);
        }
        private void FontFinder3_Tick(object sender, EventArgs e)
        {
            Font_Finder ff = new Font_Finder();
            ff.fm = this;
            curFont = ff.findFont(curFont, finishedLoading, label1);
        }
        public void selectFont(object[] args)
        {
            Button btnFont = (Button)args[0];
            textBox1.Text = btnFont.Font.Name;
            settingsFont = new Font(textBox1.Text, settingsFont.Size, FontStyle.Regular);
            UpdatePreviewText();
        }
        public void selectStyle(object[] args)
        {
            Button btnFont = (Button)args[0];
            textBox2.Text = btnFont.Text;

            string regularFont = String.Empty, styleOfFont = String.Empty;

            foreach (string extension in StyleExtensions)
            {
                if (textBox2.Text.ToLower().Contains(extension.ToLower()))
                {
                    regularFont = textBox2.Text.Substring(0, textBox2.Text.ToLower().LastIndexOf(extension.ToLower())).Trim();
                    styleOfFont = textBox2.Text.Substring(regularFont.Length).Trim();
                    break;
                }
            }
            if (regularFont == String.Empty || styleOfFont == String.Empty) return;

            FontStyle fs = (FontStyle)Enum.Parse(typeof(FontStyle), styleOfFont);
            settingsFont = new Font(regularFont, settingsFont.Size, fs);

            regularFont = null;
            styleOfFont = null;
            UpdatePreviewText();
        }
        public void selectSize(object[] args)
        {
            Button btnFont = (Button)args[0];
            textBox3.Text = btnFont.Text;
            int parsedNum = 0;
            if (textBox3.Text == String.Empty || !int.TryParse(textBox3.Text, out parsedNum)) return;
            if (parsedNum <= 0 || parsedNum > 500) return;

            settingsFont = new Font(settingsFont.FontFamily, parsedNum, settingsFont.Style);
            UpdatePreviewText();
            
        }
        public void invokeMethod(object sender, EventArgs e, string methodname, Button btn)
        {
            //  This switch statement handles the selected buttons lists.
            switch (methodname)
            {
                case "selectFont":
                    selectedButton1.BackColor = SStylize.Background_Highlight;
                    selectedButton1.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                    selectedButton1.FlatAppearance.MouseOverBackColor = SStylize.Background_Highlight;
                    selectedButton1 = btn;
                    break;
                case "selectStyle":
                    selectedButton2.BackColor = SStylize.Background_Highlight;
                    selectedButton2.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                    selectedButton2.FlatAppearance.MouseOverBackColor = SStylize.Background_Highlight;
                    selectedButton2 = btn;
                    break;
                case "selectSize":
                    selectedButton3.BackColor = SStylize.Background_Highlight;
                    selectedButton3.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                    selectedButton3.FlatAppearance.MouseOverBackColor = SStylize.Background_Highlight;
                    selectedButton3 = btn;
                    break;
            }
            

            btn.BackColor = SStylize.Button_Pressed;
            btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            btn.FlatAppearance.MouseOverBackColor = SStylize.Button_Pressed;
            System.Reflection.MethodInfo mi = this.GetType().GetMethod(methodname);
            mi.Invoke(this, new object[] { new Button[] { btn } });
        }
                        //  This, like 'FontFinder timers' exist to find all the extensions/styles of a font.
        private void FontStyleFinder_Tick(object sender, EventArgs e)
        {
            List<Button> btns = new List<Button>(SelectionMenu2.Controls.OfType<Button>());
            foreach (Button b in btns)
            {
                b.Dispose();
            }

            yPosButton2 = 0;
            Font_Finder ff = new Font_Finder();
            ff.fm = this;
            ff.findFontStyle(label2, textBox1);
            FontStyleFinder.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FontStyleFinder.Enabled = true;
            if (!textBox1.Focused) return;
            foreach (Button btn in SelectionMenu1.Controls.OfType<Button>())
            {
                if (btn.Text == textBox1.Text)
                {
                    selectedButton1.BackColor = SStylize.Background_Highlight;
                    selectedButton1.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                    selectedButton1.FlatAppearance.MouseOverBackColor = SStylize.Background_Highlight;
                    btn.BackColor = SStylize.Button_Pressed;
                    btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                    btn.FlatAppearance.MouseOverBackColor = SStylize.Button_Pressed;
                    selectedButton1 = btn;

                    settingsFont = new Font(textBox1.Text, settingsFont.Size, FontStyle.Regular);
                    UpdatePreviewText();
                    break;
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!textBox2.Focused) return;
            foreach (Button btn in SelectionMenu2.Controls.OfType<Button>())
            {
                if (btn.Text == textBox2.Text)
                {
                    selectedButton2.BackColor = SStylize.Background_Highlight;
                    selectedButton2.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                    selectedButton2.FlatAppearance.MouseOverBackColor = SStylize.Background_Highlight;
                    btn.BackColor = SStylize.Button_Pressed;
                    btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                    btn.FlatAppearance.MouseOverBackColor = SStylize.Button_Pressed;
                    selectedButton2 = btn;

                    selectStyle(new object[] { btn });
                    break;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!textBox3.Focused) return;
            foreach (Button btn in SelectionMenu2.Controls.OfType<Button>())
            {
                if (btn.Text == textBox3.Text)
                {
                    selectedButton3.BackColor = SStylize.Background_Highlight;
                    selectedButton3.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                    selectedButton3.FlatAppearance.MouseOverBackColor = SStylize.Background_Highlight;
                    btn.BackColor = SStylize.Button_Pressed;
                    btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                    btn.FlatAppearance.MouseOverBackColor = SStylize.Button_Pressed;
                    selectedButton3 = btn;
                    break;
                }
            }
            Button btn_size = new Button();
            btn_size.Text = textBox3.Text;
            selectSize(new object[] { btn_size });
            UpdatePreviewText();
        }

                //  This handles the preview of the Font.
                //  The font might get larger or smaller so there's a need to move it around to
                //  fit in the center of the preview box.
        private void UpdatePreviewText()
        {
            preview_label.Font = settingsFont;

            int Xpos = Sample_Text_Panel.Size.Width / 2
                - preview_label.Size.Width / 2;
            int Ypos = Sample_Text_Panel.Size.Height / 2
                - preview_label.Size.Height / 2;

            preview_label.Location = new Point(Xpos, Ypos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings1.Default.Font = settingsFont;
            Settings1.Default.Save();
            
            if (Application.OpenForms.OfType<Notepad>().Any())
            {
                Notepad dnp = Application.OpenForms.OfType<Notepad>().First();
                dnp.updateTextFont();
                dnp = null;
            }
            this.Close();
        }

        private void FontMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            if (Application.OpenForms.OfType<Notepad>().Any())
            {
                Application.OpenForms.OfType<Notepad>().First().richTextBox1.Focus();
            }
        }

        //  This opens the 'Fonts settings' in windows.
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
                WarningBox WB = new WarningBox(ex.Message);
                WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();
                WB = null;
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
            SelectionMenu1.BackColor = SStylize.Background_Highlight;
            textBox1.BackColor = SStylize.TextBox;
            textBox1.ForeColor = SStylize.TextBox_Text;
            textBox2.BackColor = SStylize.TextBox;
            textBox2.ForeColor = SStylize.TextBox_Text;
            textBox3.BackColor = SStylize.TextBox;
            textBox3.ForeColor = SStylize.TextBox_Text;
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
            SelectionMenu1.BackColor = SStylize.Background_Highlight;
            SelectionMenu2.BackColor = SStylize.Background_Highlight;
            SelectionMenu3.BackColor = SStylize.Background_Highlight;
            VScrollbar1.BackColor = SStylize.Scrollbar_Tint;
            VScrollbar1_Thumb.BackColor = SStylize.Scrollbar;
            VScrollBar1_ArrowUp.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar1_ArrowUp.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar1_ArrowUp.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
            VScrollBar1_ArrowDown.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar1_ArrowDown.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar1_ArrowDown.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
            VScrollbar2.BackColor = SStylize.Scrollbar_Tint;
            VScrollbar2_Thumb.BackColor = SStylize.Scrollbar;
            VScrollBar2_ArrowUp.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar2_ArrowUp.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar2_ArrowUp.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
            VScrollBar2_ArrowDown.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar2_ArrowDown.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar2_ArrowDown.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
            VScrollbar3.BackColor = SStylize.Scrollbar_Tint;
            VScrollbar3_Thumb.BackColor = SStylize.Scrollbar;
            VScrollBar3_ArrowUp.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar3_ArrowUp.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar3_ArrowUp.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
            VScrollBar3_ArrowDown.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar3_ArrowDown.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar3_ArrowDown.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Tint;
        }
    }
}
