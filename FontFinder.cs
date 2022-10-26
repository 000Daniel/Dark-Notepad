using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DarkNotepad
{
    public class Font_Finder
    {
        System.Drawing.Text.InstalledFontCollection ifc = new System.Drawing.Text.InstalledFontCollection();
        private String[] extensions = new string[] {"Condensed","Light", "Light Condensed", "Light SemiCondensed",
                "SemiBold", "SemiBold Condensed", "SemiBold SemiConden", "SemiCondensed",
            "SemiLight", "SemiLight Condensed", "SemiLight SemiConde", "ExtraLight", "Narrow",
            "Black", "Medium"};
        public bool finishedLoading_ = false;
        SettingsStylize SStylize = SettingsStylize.Default;
        private int ButtonHeight = 26;
        private int ButtonHeightNumbers = 22;
        public FontMenu fm = null;

                //  This function looks through all Font Families and checks if they are
                //  an extension of another font, like 'Arial Black' for 'Arial'.
                //  If the font ins't an extension, the function adds it to the list
                //  and display it as its own font.
        public int findFont(int curFont_, bool finishedLoading, System.Windows.Forms.Label label1)
        {
            try
            {
                finishedLoading_ = finishedLoading;
                if (curFont_ < ifc.Families.Length)
                {
                            //  This foreach loop checks if the font is an extension of another font.
                    foreach (string extension in extensions)
                    {
                        if (!ifc.Families[curFont_].Name.ToLower().Contains(extension.ToLower()))
                            continue;

                        int lastIndex = ifc.Families[curFont_].Name.ToLower().LastIndexOf(extension.ToLower());
                        if (ifc.Families[curFont_].Name.Length != lastIndex + extension.Length)
                            continue;

                        curFont_++;
                        return curFont_;
                    }

                    createButton(null, null, ifc.Families[curFont_].Name, "selectFont",curFont_, fm.SelectionMenu1);
                }
                else if (!finishedLoading)
                {
                    label1.Text = "Font:";
                    finishedLoading = true;
                }
                curFont_++;
                finishedLoading_ = finishedLoading;
                return curFont_;
            }
            catch
            { return curFont_; }
        }

                //  This function looks into all the FontFamilies with a similar name to the main font.
                //  For example 'Arial' would look for 'Arial Black', and check if these extensions
                //  support style options like Bold, Italic, Underline etc'
        public void findFontStyle(Label label2, TextBox textBox1)
        {
            try
            {
                int btnID = 1;
                label2.Text = "Font style: (Loading)";

                FontFamily ff = new FontFamily(textBox1.Text);
                foreach (FontFamily off in ifc.Families)
                {
                    if (!off.Name.ToLower().Contains(ff.Name.ToLower())) continue;

                    foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
                    {
                        if (!off.IsStyleAvailable(style)) continue;

                        string appendThis = String.Format("{0} {1}", off.Name, style.ToString());
                        createButton(null, null, appendThis, "selectStyle",btnID, fm.SelectionMenu2, style);
                        btnID++;

                        appendThis = null;
                    }
                }
                label2.Text = "Font style:";
                return;
            }
            catch { return; }
        }

        public void assignSizes(int[] intArr)
        {
            int ID = 1;
            foreach (int i in intArr)
            {
                createButton(null, null, i.ToString(), "selectSize", ID, fm.SelectionMenu3);
                ID++;
            }
        }

        public void createButton(object sender, EventArgs e, string btnText, string methodName, int curFont_, Panel parentPanel, FontStyle fs = FontStyle.Regular)
        {
            Button btn = new Button();
            int tempButtonHeight = ButtonHeight;
            bool highlight = false;

                    //  the 'parentPanel' checks are being made so that the software would
                    //  know what font to use and which buttons to highlight(selected font).
            if (parentPanel == fm.SelectionMenu1)
            {
                String tempFontName = Settings1.Default.Font.Name;
                foreach (string ex in extensions)
                {
                    if (tempFontName.Contains(ex))
                    {
                        tempFontName = tempFontName.Replace(ex,"").TrimEnd();
                    }
                }
                if (tempFontName == btnText)
                {
                    fm.selectedButton1 = btn;
                    highlight = true;
                }
                btn.Font = new Font(ifc.Families[curFont_].Name, 12F, fs, GraphicsUnit.Point);
                btn.Location = new Point(0, fm.yPosButton);
                fm.yPosButton += tempButtonHeight;
            }
            else if (parentPanel == fm.SelectionMenu2)
            {
                String tempFullFontName = String.Format("{0} {1}",Settings1.Default.Font.Name,Settings1.Default.Font.Style);
                if (tempFullFontName == btnText)
                {
                    fm.selectedButton2 = btn;
                    highlight = true;
                }
                tempFullFontName = String.Empty;
                btn.Font = new Font("Arial", 12F, fs, GraphicsUnit.Point);
                btn.Location = new Point(0, fm.yPosButton2);
                fm.yPosButton2 += tempButtonHeight;
            }
            else if (parentPanel == fm.SelectionMenu3)
            {
                if (Settings1.Default.Font.Size.ToString() == btnText)
                {
                    fm.selectedButton3 = btn;
                    highlight = true;
                }
                tempButtonHeight = ButtonHeightNumbers;
                btn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
                btn.Location = new Point(0, fm.yPosButton3);
                fm.yPosButton3 += tempButtonHeight;
            }
            else
            {
                btn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
                btn.Location = new Point(0, 0);
            }
            btn.Name = btnText;
            btn.Tag = curFont_;
            btn.Size = new Size(parentPanel.Size.Width - SystemInformation.VerticalScrollBarWidth, tempButtonHeight);
            btn.Text = btnText;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.UseCompatibleTextRendering = true;
            btn.UseVisualStyleBackColor = true;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = SStylize.Button_Text;
            if (highlight)
            {
                btn.BackColor = SStylize.Button_Pressed;
                btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                btn.FlatAppearance.MouseOverBackColor = SStylize.Button_Pressed;
            }
            else
            {
                btn.BackColor = SStylize.Background_Highlight;
                btn.FlatAppearance.MouseDownBackColor = SStylize.Button_Pressed;
                btn.FlatAppearance.MouseOverBackColor = SStylize.Background_Highlight;
            }
            btn.Click += (sender2, e2) => fm.invokeMethod(sender, e, methodName, btn);

            parentPanel.Controls.Add(btn);
            btn.BringToFront();
        }
    }
}
