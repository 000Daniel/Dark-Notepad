using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class AboutMenu : Form
    {
        public AboutMenu()
        {
            InitializeComponent();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            label7.Text = String.Format("Version {0}.{1}.{2}",version.Major,version.Minor,version.Build);
            updateThemeColors();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            if (Application.OpenForms.OfType<Notepad>().Any())
            {
                Application.OpenForms.OfType<Notepad>().First().richTextBox1.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo("https://github.com/000Daniel");
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

        private void updateThemeColors()
        {
            SettingsStylize SStylize = SettingsStylize.Default;
            BackColor = SStylize.Background;
            ForeColor = SStylize.Text;
            panel1.BackColor = SStylize.Background_Highlight;
            label1.BackColor = SStylize.Background;
            label1.ForeColor = SStylize.Text;
            label2.BackColor = SStylize.Background;
            label2.ForeColor = SStylize.Text;
            label3.BackColor = SStylize.Background;
            label3.ForeColor = SStylize.Text;
            label4.BackColor = SStylize.Background;
            label4.ForeColor = SStylize.Text;
            label5.BackColor = SStylize.Background;
            label5.ForeColor = SStylize.Text;
            label6.BackColor = SStylize.Background;
            label6.ForeColor = SStylize.Text;
            label7.BackColor = SStylize.Background;
            label7.ForeColor = SStylize.Text;
            label8.BackColor = SStylize.Background;
            label8.ForeColor = SStylize.Text;
            button2.BackColor = SStylize.Button;
            button2.FlatAppearance.BorderColor = SStylize.Button_Border;
            button2.FlatAppearance.MouseOverBackColor = SStylize.Button_Highlight;
            button2.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
            button2.ForeColor = SStylize.Button_Text;
            linkLabel1.LinkColor = SStylize.Link;
            linkLabel1.VisitedLinkColor = SStylize.Link_Pressed;
            linkLabel1.ActiveLinkColor = SStylize.Link_Pressed;
        }
    }
}
