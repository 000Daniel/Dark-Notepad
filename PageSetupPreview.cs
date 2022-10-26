using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DarkNotepad
{
    internal class PageSetupPreview
    {
        public Size picturebox_size;
        public Size page_size;
        public bool Portrait;
        private Bitmap bm;

                //  This generates and returns the preview page image.
        public Bitmap generateImage()
        {
            SettingsStylize SStylize = SettingsStylize.Default;

            if (!Portrait)
            {
                page_size = new Size(page_size.Height, page_size.Width);
            }
            Point page_loc = new Point((picturebox_size.Width - page_size.Width) / 2,
                (picturebox_size.Height - page_size.Height) / 2);

            bm = new Bitmap(picturebox_size.Width, picturebox_size.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bm);

                    //  This draws the general shape of the paper (and its shadow).
            g.FillRectangle(new SolidBrush(SStylize.Background_Highlight), 0, 0, picturebox_size.Width, picturebox_size.Height);
            g.FillRectangle(Brushes.DarkGray, page_loc.X + 8, page_loc.Y + 8, page_size.Width, page_size.Height);
            g.FillRectangle(Brushes.Black, page_loc.X - 1, page_loc.Y - 1, page_size.Width + 2, page_size.Height + 2);
            g.FillRectangle(Brushes.Gray, page_loc.X - 1, page_loc.Y - 1, page_size.Width + 1, page_size.Height + 1);
            g.FillRectangle(Brushes.White, page_loc.X, page_loc.Y, page_size.Width, page_size.Height);

            int MarginsLeft = 0;
            int MarginsRight = 0;
            int MarginsTop = 0;
            int MarginsBottom = 0;
            PageSetup PS;
            if (Application.OpenForms.OfType<PageSetup>().Any())
            {
                PS = Application.OpenForms.OfType<PageSetup>().First();
            }
            else
            {
                PS = new PageSetup();
            }
            try
            {
                MarginsLeft = (int)(float.Parse(PS.textBox1.Text) / 2);
                MarginsRight = (int)(float.Parse(PS.textBox2.Text) / 2);
                MarginsTop = (int)(float.Parse(PS.textBox4.Text) / 2);
                MarginsBottom = (int)(float.Parse(PS.textBox3.Text) / 2);

                        //  This rectangle is the shape of the dotted/dashed line
                        //  that represents the Margins setting.
                Rectangle MarginsRect = new Rectangle(page_loc.X + MarginsLeft,
                    page_loc.Y + MarginsTop,
                    page_size.Width - MarginsLeft - MarginsRight,
                    page_size.Height - MarginsTop - MarginsBottom);
                
                if (MarginsRect.Width <= 1)
                {
                    MarginsRect = new Rectangle(page_loc.X + 20, page_loc.Y + 25,
                    page_size.Width - 40, page_size.Height - 50);
                }
                if (MarginsRect.Height <= 1)
                {
                    MarginsRect = new Rectangle(page_loc.X + 20, page_loc.Y + 25,
                    page_size.Width - 40, page_size.Height - 50);
                }
                float[] dashValues = { 3, 3 };  //  draw 3 pixels and then skip 3 pixels.
                Pen dottedLine = new Pen(Color.DarkGray, 1);
                dottedLine.DashPattern = dashValues;
                g.DrawLine(dottedLine, new Point(MarginsRect.X, MarginsRect.Y)
                    , new Point(MarginsRect.X + MarginsRect.Width, MarginsRect.Y));
                g.DrawLine(dottedLine, new Point(MarginsRect.X, MarginsRect.Y + MarginsRect.Height)
                    , new Point(MarginsRect.X + MarginsRect.Width, MarginsRect.Y + MarginsRect.Height));
                g.DrawLine(dottedLine, new Point(MarginsRect.X, MarginsRect.Y)
                    , new Point(MarginsRect.X, MarginsRect.Y + MarginsRect.Height));
                g.DrawLine(dottedLine, new Point(MarginsRect.X + MarginsRect.Width, MarginsRect.Y)
                    , new Point(MarginsRect.X + MarginsRect.Width, MarginsRect.Y + MarginsRect.Height));

                        //  This writes the text inside the paper.
                for (int i = 0; i < MarginsRect.Height; i += 5)
                {
                    string str1 = "the quick brown fox jumps over";
                    string str2 = "the lazy dog.";
                    string str3 = "More sample text is written here!";

                    if (i >= MarginsRect.Height - 5) break;
                    processString(str1, MarginsRect, i, g);
                    i += 5;
                    if (i >= MarginsRect.Height - 5) break;
                    processString(str2, MarginsRect, i, g);
                    i += 5;
                    if (i >= MarginsRect.Height - 5) break;
                    processString(str3, MarginsRect, i, g);
                    i += 5;
                }
                return bm;
            }
            catch (Exception ex)
            {
                WarningBox WB = new WarningBox(ex.Message);
                WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();

                WB = null;
                return null;
            }
        }
        private void processString(string str1, Rectangle rect, int i, Graphics g)
        {
            Font sFont = new Font("Arial", 4);

            SizeF size = TextRenderer.MeasureText(str1, sFont);
            while (size.Width > rect.Width + 10)
            {
                str1 = str1.Substring(0, str1.LastIndexOf(" "));
                size = TextRenderer.MeasureText(str1, sFont);
            }
            g.DrawString(str1, sFont, Brushes.DimGray, new Point(rect.X, rect.Y + i));
        }
    }
}
