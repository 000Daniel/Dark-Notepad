using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    public partial class AboutMenu : Form
    {
        private Notepad dnp;

        public AboutMenu()
        {
            InitializeComponent();
            updateThemeColors();
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
                Debug.WriteLine("Error!:\n" + ex.Message);
            }
        }

        private void updateThemeColors()
        {
            SettingsStylize SStylize = SettingsStylize.Default;
            this.BackColor = SStylize.Background;
            this.ForeColor = SStylize.Text;
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
