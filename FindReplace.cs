using System;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class FindReplace : Form
    {
        public bool matchCase = false;
        private Notepad dnp = Application.OpenForms.OfType<Notepad>().First();
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
                pictureBox1.Image = dnp.Check2;
            }
            else
            {
                pictureBox1.Image = dnp.Check;
            }
        }

                //  This simple function decides whether the 'matchCase' should be true or false.
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            matchCase = !matchCase;
            Settings1.Default.MatchCase = matchCase;
            Settings1.Default.Save();

            if (matchCase)
            {
                pictureBox1.Image = dnp.Check2;
            }
            else
            {
                pictureBox1.Image = dnp.Check;
            }
        }

        private void FindReplace_Load(object sender, EventArgs e)
        {
            updateThemeColors();
        }

                //  Button1 is responsible for finding the previous matching string in the file.
                //  it works by selecting the last matching string till where the selection is,
                //  (before the selection)
                //  if the user reached the beginning while still trying to find a string the selection
                //  will reset to the last matched string in the file.
        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty) return;

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
                dnp.richTextBox1.Select(TextAnalyze.LastIndexOf(find), find.Length);
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

                //  Button2 is responsible for finding the next matching string in the file.
                //  it works by selecting the first matching string from where the selection is,
                //  (after the selection)
                //  if the user reached the end while still trying to find a string the selection
                //  will reset to the first matched string in the file.
        public void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty) return;

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
                index = dnp.richTextBox1.SelectionStart + dnp.richTextBox1.SelectionLength;
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
                    int oldTextLength = dnp.richTextBox1.SelectedText.Length;
                    dnp.richTextBox1.SelectedText = replaceWith;
                    dnp.richTextBox1.Select(selectStart, replaceWith.Length);

                    richTextAnalyze = dnp.richTextBox1.Text;
                    if (!matchCase)
                    {
                        richTextAnalyze = richTextAnalyze.ToLower();
                    }
                    if (replaceWith.Length - oldTextLength < 0)
                    {
                        index += replaceWith.Length - oldTextLength;
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
                dnp.richTextBox1.Select(TextAnalyze.IndexOf(find) + index, find.Length);

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

                //  Button3(Replace) and Button4(Replace All) rely on the previous buttons to
                //  replace text.
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
                return;
            if (textBox1.Text.ToLower() == textBox2.Text.ToLower() && !matchCase)
                return;

            replaceWith = textBox2.Text;
            button2_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int whileLoopLimit = 500;
            string textBox = dnp.richTextBox1.Text;
            string checkFor = textBox1.Text;
            if (!matchCase)
            {
                textBox = textBox.ToLower();
                checkFor = checkFor.ToLower();
            }

            while (textBox.Contains(checkFor))
            {
                whileLoopLimit--;
                if (whileLoopLimit <= 0)
                    break;

                button3_Click(sender, e);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FindReplace_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
            this.Dispose();
            dnp.richTextBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Settings1.Default.FindNextPrev = textBox1.Text;
            Settings1.Default.Save();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button2_Click(null, null);
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button3_Click(null, null);
                e.Handled = true;
            }
        }

        public void updateThemeColors()
        {
            SettingsStylize SStylize = SettingsStylize.Default;
            BackColor = SStylize.Background;
            ForeColor = SStylize.Text;
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
