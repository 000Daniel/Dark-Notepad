using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class PageSetup : Form
    {
        private Settings1 settings = Settings1.Default;
        
        public PageSetup()
        {
            InitializeComponent();
            textBox1.Leave += new EventHandler((sender,e) => textBoxGeneral_Leave(sender,e,textBox1));
            textBox2.Leave += new EventHandler((sender,e) => textBoxGeneral_Leave(sender,e,textBox2));
            textBox3.Leave += new EventHandler((sender,e) => textBoxGeneral_Leave(sender,e,textBox3));
            textBox4.Leave += new EventHandler((sender,e) => textBoxGeneral_Leave(sender,e,textBox4));
            textBox1.KeyPress += new KeyPressEventHandler((sender,e) => textBoxGeneral_KeyPress(sender,e,textBox1));
            textBox2.KeyPress += new KeyPressEventHandler((sender,e) => textBoxGeneral_KeyPress(sender,e,textBox2));
            textBox3.KeyPress += new KeyPressEventHandler((sender,e) => textBoxGeneral_KeyPress(sender,e,textBox3));
            textBox4.KeyPress += new KeyPressEventHandler((sender,e) => textBoxGeneral_KeyPress(sender,e,textBox4));
            textBox1.KeyDown += new KeyEventHandler((sender,e) => textBoxGeneral_KeyDown(sender,e,textBox1));
            textBox2.KeyDown += new KeyEventHandler((sender,e) => textBoxGeneral_KeyDown(sender,e,textBox2));
            textBox3.KeyDown += new KeyEventHandler((sender,e) => textBoxGeneral_KeyDown(sender,e,textBox3));
            textBox4.KeyDown += new KeyEventHandler((sender,e) => textBoxGeneral_KeyDown(sender,e,textBox4));
        }
        private void PageSetup_Load(object sender, EventArgs e)
        {
            button1.Text = settings.PS_Size;
            if (settings.PS_Portrait)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox1.Text = settings.PS_Margin1.X.ToString();
            textBox2.Text = settings.PS_Margin1.Y.ToString();
            textBox3.Text = settings.PS_Margin2.X.ToString();
            textBox4.Text = settings.PS_Margin2.Y.ToString();

            textBox5.Text = settings.PS_Header;
            textBox6.Text = settings.PS_Footer;

            updateThemeColors();
            button4_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                //  This saves the new settings.
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                settings.PS_Margin1 = new Point(
                    int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                settings.PS_Margin2 = new Point(
                    int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                settings.PS_Header = textBox5.Text;
                settings.PS_Footer = textBox6.Text;
                settings.PS_Portrait = radioButton1.Checked;
                settings.PS_Size = button1.Text;
                Settings1.Default.Save();
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
            this.Close();
        }

        private void textBoxGeneral_KeyDown(object sender, KeyEventArgs e, TextBox tb)
        {
            if (e.Control && e.KeyValue == (char)Keys.C)
            {
                copyFunc(tb);
            }
            if (e.Control && e.KeyValue == (char)Keys.V)
            {
                pasteFunc(tb);
            }
        }
        private void textBoxGeneral_KeyPress(object sender, KeyPressEventArgs e, TextBox tb)
        {
            string[] legalChar = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (string num in legalChar)
            {
                if (e.KeyChar.ToString() == num
                    || e.KeyChar == (Char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }
        private void pasteFunc(TextBox TB)
        {
            IDataObject id = Clipboard.GetDataObject();
            if (id.GetDataPresent(DataFormats.UnicodeText)
                || id.GetDataPresent(DataFormats.Text)
                || id.GetDataPresent(DataFormats.Html))
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                string txtbxValue = "";
                string[] legalChar = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                foreach (char ch in clipboardText)
                {

                    foreach (string lc in legalChar)
                    {
                        if (ch.ToString().Equals(lc))
                            txtbxValue = txtbxValue + ch;
                    }
                }

                TB.SelectedText = txtbxValue;
            }
        }
        private void copyFunc(TextBox TB)
        {
            if (TB.SelectedText.Length <= 0) return;
            Clipboard.SetText(TB.SelectedText);
        }

                //  This function checks if the text entered in the text boxes(page margins)
                //  is valid or not. If not set the text to 0.
        private void textBoxGeneral_Leave(object sender, EventArgs e, TextBox textBox)
        {
            if (textBox.Text == String.Empty || !int.TryParse(textBox.Text, out int i))
            {
                textBox.Text = "0";
            }
        }

                //  This resizes the preview page.
        public void button4_Click(object sender, EventArgs e)
        {
            Size tempSize = new Size(100,100);

            switch(button1.Text)
            {
                case "A3":
                    tempSize = convertToSize(8.3, 11.7); //    11.7, 16.5
                    label12.Text = "(11.7, 16.5) Inch";
                    break;
                case "A4":
                    tempSize = convertToSize(8.3, 11.7);
                    label12.Text = "(8.3, 11.7) Inch";
                    break;
                case "A5":
                    tempSize = convertToSize(8.3, 11.7); //  5.8, 8.3
                    label12.Text = "(5.8, 8.3) Inch";
                    break;
                case "A6":      //  Out of support.
                    tempSize = convertToSize(8.3, 11.7); //    4.13, 5.83
                    label12.Text = "(4.13, 5.83) Inch";
                    break;
                case "B4":
                    tempSize = convertToSize(8.3,11.8); //    9.84, 13.9
                    label12.Text = "(9.84, 13.9) Inch";
                    break;
                case "B5":
                    tempSize = convertToSize(8.3, 11.8); //    6.93, 9.84
                    label12.Text = "(6.93, 9.84) Inch";
                    break;
                case "Legal":
                    tempSize = convertToSize(8.5, 13.21);
                    label12.Text = "(8.5, 13.21) Inch";
                    break;
                case "Letter":
                    tempSize = convertToSize(8.5, 11);
                    label12.Text = "(8.5, 11) Inch";
                    break;
                case "Ledger":
                    tempSize = convertToSize(7.1, 11);  //      11, 17
                    label12.Text = "(11, 17) Inch";
                    break;
                case "Tabloid":
                    tempSize = convertToSize(11, 7.1);  //      17, 11
                    label12.Text = "(17, 11) Inch";
                    break;
                case "C2":
                    tempSize = convertToSize(11.6, 8.2);  //    25.51,18.03
                    label12.Text = "(25.51,18.03) Inch";
                    break;
                case "C3":
                    tempSize = convertToSize(11, 7.7);  //      18.03, 12.76
                    label12.Text = "(18.03, 12.76) Inch";
                    break;
                case "D0":
                    tempSize = convertToSize(11, 7.7);  //      42.91, 30.35
                    label12.Text = "(42.91, 30.35) Inch";
                    break;
            }

            PageSetupPreview psp = new PageSetupPreview();
            psp.picturebox_size = pictureBox1.Size;
            psp.page_size = tempSize;
            psp.Portrait = radioButton1.Checked;
            pictureBox1.Image = psp.generateImage();
        }
        private Size convertToSize(double x, double y)
        {
            return new Size((int)(x * 11), (int)(y * 11));
        }

                //  This creates a context menu for all supported page sizes.
        private void button1_Click(object sender, EventArgs e)
        {
            ContextMenu cxm = new ContextMenu();
            cxm.ShowInTaskbar = false;
            cxm.panelSize = button1.Width;
            cxm.createButton(sender, e, "A3 (11.7, 16.5)", "PS_PaperSize1");
            cxm.createButton(sender, e, "A4 (8.3 11.7)", "PS_PaperSize2");
            cxm.createButton(sender, e, "A5 (5.8, 8.3)", "PS_PaperSize3");
            //cxm.createButton(sender, e, "A6 (4.13, 5.83)", "PS_PaperSize4");
            cxm.createButton(sender, e, "B4 (9.84, 13.90)", "PS_PaperSize5");
            cxm.createButton(sender, e, "B5 (6.93, 9.84)", "PS_PaperSize6");
            cxm.createButton(sender, e, "Legal (8.50, 13.21)", "PS_PaperSize7");
            cxm.createButton(sender, e, "Letter (8.50, 11.00)", "PS_PaperSize8");
            cxm.createButton(sender, e, "Ledger (11, 17)", "PS_PaperSize9");
            cxm.createButton(sender, e, "Tabloid (17, 11)", "PS_PaperSize10");
            cxm.createButton(sender, e, "C2 (25.51,18.03)", "PS_PaperSize11");
            cxm.createButton(sender, e, "C3 (18.03, 12.76)", "PS_PaperSize12");
            cxm.createButton(sender, e, "D0 (42.91, 30.35)", "PS_PaperSize13");

            cxm.Show();

            int Xpos = button1.Location.X + backgroundPanel1.Location.X + this.Left + 7;
            int Ypox = button1.Location.Y + backgroundPanel1.Location.Y + button1.Size.Height + 30 + this.Top;
            cxm.Location = new Point(Xpos, Ypox);

            cxm = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button4_Click(null, null);
        }

                //  Opens the github page that's about 'Input Values'
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo("https://github.com/000Daniel/Dark-Notepad/blob/main/Documents/Input%20Values.md");
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

        private void PageSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            if (Application.OpenForms.OfType<Notepad>().Any())
            {
                Application.OpenForms.OfType<Notepad>().First().richTextBox1.Focus();
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
            backgroundPanel1.BackColor = SStylize.Background_Highlight;
            backgroundPanel2.BackColor = SStylize.Background_Highlight;
            backgroundPanel3.BackColor = SStylize.Background_Highlight;
            backgroundPanel4.BackColor = SStylize.Background_Highlight;
            textBox1.BackColor = SStylize.TextBox;
            textBox1.ForeColor = SStylize.TextBox_Text;
            textBox2.BackColor = SStylize.TextBox;
            textBox2.ForeColor = SStylize.TextBox_Text;
            textBox3.BackColor = SStylize.TextBox;
            textBox3.ForeColor = SStylize.TextBox_Text;
            textBox4.BackColor = SStylize.TextBox;
            textBox4.ForeColor = SStylize.TextBox_Text;
            textBox5.BackColor = SStylize.TextBox;
            textBox5.ForeColor = SStylize.TextBox_Text;
            textBox6.BackColor = SStylize.TextBox;
            textBox6.ForeColor = SStylize.TextBox_Text;
            linkLabel1.LinkColor = SStylize.Link;
            linkLabel1.ActiveLinkColor = SStylize.Link_Pressed;
            linkLabel1.VisitedLinkColor = SStylize.Link_Pressed;
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
            label7.ForeColor = SStylize.Text;
            label7.BackColor = SStylize.Background_Highlight;
            label8.ForeColor = SStylize.Text;
            label8.BackColor = SStylize.Background_Highlight;
            label9.ForeColor = SStylize.Text;
            label9.BackColor = SStylize.Background;
            label10.ForeColor = SStylize.Text;
            label10.BackColor = SStylize.Background;
            label11.ForeColor = SStylize.Text;
            label11.BackColor = SStylize.Background_Highlight;
            label12.ForeColor = SStylize.Text;
            label12.BackColor = SStylize.Background_Highlight;
            radioButton1.ForeColor = SStylize.Text;
            radioButton1.BackColor = SStylize.Background_Highlight;
            radioButton2.ForeColor = SStylize.Text;
            radioButton2.BackColor = SStylize.Background_Highlight;
        }

        
    }
}
