using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class FindReplace : Form
    {
        public bool matchCase = false;
        private Notepad dnp;
        private int index;
        private bool overrideIndex = true;
        private string replaceWith = string.Empty;
        public FindReplace()
        {
            InitializeComponent();

            matchCase = Settings1.Default.MatchCase;
            textBox1.Text = Settings1.Default.FindNextPrev;

            if (matchCase)
            {
                pictureBox1.Image = Resource1.DarkCheck2;
            }
            else
            {
                pictureBox1.Image = Resource1.DarkCheck;
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            matchCase = !matchCase;
            Settings1.Default.MatchCase = matchCase;
            Settings1.Default.Save();

            if (matchCase)
            {
                pictureBox1.Image = Resource1.DarkCheck2;
                return;
            }
            pictureBox1.Image = Resource1.DarkCheck;

            return;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void FindReplace_Load(object sender, EventArgs e)
        {
            updateDNT(sender, e);
            updateThemeColors();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty) return;

            updateDNT(sender, e);
            string richTextAnalyze = dnp.richTextBox1.Text;
            string find = textBox1.Text;
            if (!matchCase)
            {
                richTextAnalyze = richTextAnalyze.ToLower();
                find = find.ToLower();
            }

            if (!richTextAnalyze.Contains(find))
            {
                label4.Text = String.Format("Cannot find \"{0}\"", textBox1.Text);
                label4.Visible = true;
                if (!this.Visible)
                {
                    WarningBox WB = new WarningBox(String.Format("Cannot find \"{0}\"", textBox1.Text));
                    WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                    WB.StartPosition = FormStartPosition.CenterScreen;
                    WB.Show();
                    WB.BringToFront();
                    WB = null;
                }
                return;
            }
            label4.Visible = false;

            if (overrideIndex)
            {
                index = dnp.richTextBox1.SelectionStart;
                overrideIndex = false;
            }

            if (index < 0)
                index = dnp.richTextBox1.Text.Length;

            string TextAnalyze = richTextAnalyze.Substring(0, index);
            if (TextAnalyze.Contains(find))
            {
                dnp.richTextBox1.SelectionStart = TextAnalyze.LastIndexOf(find);
                dnp.richTextBox1.SelectionLength = find.Length;

                dnp.richTextBox1.Focus();

                index = dnp.richTextBox1.SelectionStart;
            }
            else
            {
                index = dnp.richTextBox1.Text.Length;
                button1_Click(sender, e);
            }
            richTextAnalyze = null;
            TextAnalyze = null;
            find = null;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty) return;

            updateDNT(sender, e);

            string richTextAnalyze = dnp.richTextBox1.Text;
            string find = textBox1.Text;
            if (!matchCase)
            {
                richTextAnalyze = richTextAnalyze.ToLower();
                find = find.ToLower();
            }

            if (!richTextAnalyze.Contains(find))
            {
                label4.Text = String.Format("Cannot find \"{0}\"", textBox1.Text);
                label4.Visible = true;
                if (!this.Visible)
                {
                    WarningBox WB = new WarningBox(String.Format("Cannot find \"{0}\"", textBox1.Text));
                    WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                    WB.StartPosition = FormStartPosition.CenterScreen;
                    WB.Show();
                    WB.BringToFront();
                    WB = null;
                }
                return;
            }
            label4.Visible = false;

            if (overrideIndex)
            {
                index = dnp.richTextBox1.SelectionStart
                    + dnp.richTextBox1.SelectionLength;
                overrideIndex = false;
            }

            if (replaceWith != string.Empty)
            {
                string replaceText = dnp.richTextBox1.SelectedText;
                int selectStart = dnp.richTextBox1.SelectionStart;

                if (!matchCase)
                {
                    replaceText = replaceText.ToLower();
                }
                if (replaceText == find)
                {
                    dnp.richTextBox1.SelectedText = replaceWith;
                    dnp.richTextBox1.SelectionStart = selectStart;
                    dnp.richTextBox1.SelectionLength = replaceWith.Length;

                    richTextAnalyze = dnp.richTextBox1.Text;
                    if (!matchCase)
                    {
                        richTextAnalyze = richTextAnalyze.ToLower();
                    }
                }

                replaceText = null;
                replaceWith = string.Empty;
            }

            if (index > dnp.richTextBox1.Text.Length)
                index = 0;


            string TextAnalyze = richTextAnalyze.Substring(index);
            if (TextAnalyze.Contains(find))
            {
                dnp.richTextBox1.SelectionStart = TextAnalyze.IndexOf(find) + index;
                dnp.richTextBox1.SelectionLength = find.Length;

                dnp.richTextBox1.Focus();

                index = dnp.richTextBox1.SelectionStart + find.Length;
            }
            else
            {
                index = 0;
                button2_Click(sender, e);
            }
            richTextAnalyze = null;
            TextAnalyze = null;
            find = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            replaceWith = textBox2.Text;
            button2_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int whileLoopLimit = 500;
            if (matchCase)
            {
                while (dnp.richTextBox1.Text.Contains(textBox1.Text))
                {
                    whileLoopLimit--;
                    if (whileLoopLimit <= 0)
                        break;
                    button3_Click(sender, e);
                }
            }
            else
            {
                while (dnp.richTextBox1.Text.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    whileLoopLimit--;
                    if (whileLoopLimit <= 0)
                        break;
                    button3_Click(sender, e);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Settings1.Default.FindNextPrev = textBox1.Text;
            Settings1.Default.Save();
        }

        public void updateThemeColors()
        {
            SettingsStylize SStylize = SettingsStylize.Default;
            this.BackColor = SStylize.Background;
            this.ForeColor = SStylize.Text;
            textBox1.BackColor = SStylize.TextBox;
            textBox1.ForeColor = SStylize.TextBox_Text;
            textBox2.BackColor = SStylize.TextBox;
            textBox2.ForeColor = SStylize.TextBox_Text;
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
            button4.FlatAppearance.BorderColor = SStylize.Button_Border;
            button4.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;
            button4.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            button4.ForeColor = SStylize.Button_Text;
            button5.BackColor = SStylize.Button;
            button5.FlatAppearance.BorderColor = SStylize.Button_Border;
            button5.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;
            button5.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            button5.ForeColor = SStylize.Button_Text;
            label1.BackColor = SStylize.Background;
            label1.ForeColor = SStylize.Text;
            label2.BackColor = SStylize.Background;
            label2.ForeColor = SStylize.Text;
            label3.BackColor = SStylize.Background;
            label3.ForeColor = SStylize.Text;
            label4.BackColor = SStylize.Background;
            label4.ForeColor = SStylize.Text_Error;
        }
    }
}
