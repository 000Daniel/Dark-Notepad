using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
            //  This class is responsible for picking a color for the 'Stylize' class.
            //  The user can choose a color with a number(textboxes) with a slider(TrackBars)
            //  or with the Color Spectrum(Picturebox).
            //  The Color Spectrum is custom made.
    public partial class ColorPicker : Form
    {
        private Stylize St;
        private Button global_btn;
        public ColorPicker(Button btn)
        {
            InitializeComponent();
            global_btn = btn;

            textBox1.Text = btn.BackColor.R.ToString();
            textBox2.Text = btn.BackColor.G.ToString();
            textBox3.Text = btn.BackColor.B.ToString();
            textBox1_TextChanged(null, null);
            textBox2_TextChanged(null, null);
            textBox3_TextChanged(null, null);
        }
        private void updateSt(object sender, EventArgs e)
        {
            if (St == null)
            {
                if (Application.OpenForms.OfType<Stylize>().Any())
                {
                    St = Application.OpenForms.OfType<Stylize>().First();
                }
            }
        }

                //  This function looks into where the mouse is on the Color Spectrum,
                //  and picks that color.
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    Bitmap pixelData = (Bitmap)pictureBox1.Image;

                    if (e.X >= pixelData.Width || e.Y >= pixelData.Height
                        || e.X < 0 || e.Y < 0) return;

                    Color clr = pixelData.GetPixel(e.X, e.Y);

                    textBox1.Text = clr.R.ToString();
                    textBox2.Text = clr.G.ToString();
                    textBox3.Text = clr.B.ToString();

                    updatePreviewColor();
                }catch{}
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1_MouseMove(sender, e);
        }
        private void updatePreviewColor()
        {
            try
            {
                panel1.BackColor = Color.FromArgb(trackBar1.Value,
                    trackBar2.Value,
                    trackBar3.Value);
            }catch{}
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = trackBar3.Value.ToString();
        }

                //  This function makes sure that the user did not enter values that are too high.
                //  It also updates the 'Track Bars' and color preview.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox1.Text) > 255)
                {
                    textBox1.Text = "255";
                }
                if (int.Parse(textBox1.Text) < 0)
                {
                    textBox1.Text = "0";
                }
                
                trackBar1.Value = int.Parse(textBox1.Text);
            }
            catch{}
            updatePreviewColor();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox2.Text) > 255)
                {
                    textBox2.Text = "255";
                }
                if (int.Parse(textBox2.Text) < 0)
                {
                    textBox2.Text = "0";
                }
                trackBar2.Value = int.Parse(textBox2.Text);
            }
            catch{}
            updatePreviewColor();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBox3.Text) > 255)
                {
                    textBox3.Text = "255";
                }
                if (int.Parse(textBox3.Text) < 0)
                {
                    textBox3.Text = "0";
                }
                trackBar3.Value = int.Parse(textBox3.Text);
            }
            catch{}
            updatePreviewColor();
        }

                //  These functions check whether the user has entered numbers into the textboxes.
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = checkChar(e);
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = checkChar(e);
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = checkChar(e);
        }
        private bool checkChar(KeyPressEventArgs e)
        {
            string[] legalChar = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (string num in legalChar)
            {
                if (e.KeyChar.ToString() == num ||
                    e.KeyChar == (Char)Keys.Back)
                {
                    return false;
                }
            }
            return true;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Dispose();
            updateSt(sender, e);
            St.Focus();
        }

        private void Apply_Button_Click(object sender, EventArgs e)
        {
            updateSt(sender, e);

            if (St != null)
            {
                global_btn.BackColor = panel1.BackColor;
                global_btn.FlatAppearance.MouseOverBackColor = panel1.BackColor;
                global_btn.FlatAppearance.MouseDownBackColor = panel1.BackColor;
                St.UpdatePreviewWindow();
            }
            this.Dispose();
            St.Focus();
        }
    }
}
