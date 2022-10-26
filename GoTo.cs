using System;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class GoTo : Form
    {
        private Notepad dnp = Application.OpenForms.OfType<Notepad>().First();

        public GoTo()
        {
            InitializeComponent();
        }

        private void GoTo_Load(object sender, EventArgs e)
        {
            textBox1.Text = (dnp.richTextBox1.Lines.Count()).ToString();
            updateThemeColors();
        }

                //  This function checks if the user entered a number into the TextBox.
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

            string[] legalChar = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (string num in legalChar)
            {
                if (e.KeyChar.ToString() == num ||
                    e.KeyChar == (Char)Keys.Back ||
                    e.KeyChar == (Char)Keys.Return)
                {
                    e.Handled = false;
                }
            }

            if (e.KeyChar == (Char)Keys.Return)
            {
                button1_Click(sender, e);
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (textBox1.SelectedText.Length <= 0) return;
                    Clipboard.SetText(textBox1.SelectedText);
            }
            if (e.Control && e.KeyCode == Keys.V)
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

                    textBox1.SelectedText = txtbxValue;
                }
            }
        }
                //  This button tries to go to the requested line.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label2.Visible = false;

                int line = int.Parse(textBox1.Text);
                if (line <= 0 || line > dnp.richTextBox1.Lines.Count())
                {
                    label2.Visible = true;
                    return;
                }

                int index = dnp.richTextBox1.GetFirstCharIndexFromLine(line - 1);
                dnp.richTextBox1.SelectionStart = index;
                dnp.richTextBox1.SelectionLength = 0;

                this.TopMost = false;
                this.Close();

                dnp.BringToFront();
                dnp.richTextBox1.Focus();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GoTo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            dnp.richTextBox1.Focus();
        }

        private void GoTo_Activated(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<WarningBox>().Any())
                Application.OpenForms.OfType<WarningBox>().First().BringToFront();
        }

        public void updateThemeColors()
        {
            SettingsStylize SStylize = SettingsStylize.Default;
            BackColor = SStylize.Background;
            ForeColor = SStylize.Text;
            textBox1.BackColor = SStylize.TextBox;
            textBox1.ForeColor = SStylize.TextBox_Text;
            label1.BackColor = SStylize.Background;
            label1.ForeColor = SStylize.Text;
            label2.BackColor = SStylize.Background;
            label2.ForeColor = SStylize.Text_Error;
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
        }
    }
}
