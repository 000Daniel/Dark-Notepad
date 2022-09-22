using System;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class GoTo : Form
    {
        private Notepad dnp;

        public GoTo()
        {
            InitializeComponent();
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            updateDNT(sender, e);
            dnp.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                updateDNT(sender, e);
                label2.Visible = false;

                int line = int.Parse(textBox1.Text);
                if (line <= 0 || line > dnp.richTextBox1.Lines.Count())
                {
                    label2.Visible = true;
                    return;
                }
                updateDNT(sender, e);
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
                WarningBox WB = new WarningBox("Error!\n" + ex.Message);
                WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();
                WB = null;
            }
        }

        private void GoTo_Activated(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<WarningBox>().Any())
            {
                Application.OpenForms.OfType<WarningBox>().First().BringToFront();
                return;
            }
        }

        private void GoTo_Load(object sender, EventArgs e)
        {
            updateDNT(sender, e);
            textBox1.Text = (dnp.richTextBox1.Lines.Count()).ToString();
            updateThemeColors();
        }
        public void updateThemeColors()
        {
            SettingsStylize SStylize = SettingsStylize.Default;
            this.BackColor = SStylize.Background;
            this.ForeColor = SStylize.Text;
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
