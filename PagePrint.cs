using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DarkNotepad
{
    internal class PagePrint
    {
        private PrintDialog printDialog1;
        private PrintDocument printDocument1;
        private Notepad dnp;

        private string[] Header = new string[4];
        private string[] Footer = new string[4];

        private StringReader myReader;
        private string nextLine = "";

        private string rtbText;
        private Font rtbFont;

        private int PageLine = 1;

        public void Start(string rtbText_, Font rtbFont_)
        {
            if (Application.OpenForms.OfType<Notepad>().Any())
            {
                dnp = Application.OpenForms.OfType<Notepad>().First();
            }
            else
            {
                Application.Exit();
            }
            rtbText = rtbText_;
            rtbFont = rtbFont_;
            Header[0] = Settings1.Default.PS_Header;
            Footer[0] = Settings1.Default.PS_Footer;
            printDialog1 = new PrintDialog();
            printDocument1 = new PrintDocument();
            printDialog1.UseEXDialog = true;
            printDocument1.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            printDocument1.BeginPrint += (o,e) =>
            {
                if (printDocument1.PrintController.IsPreview)
                    return;
                
                WarningBox WB = new WarningBox("Printing...");
                WB.Text = "Printing";
                WB.StartPosition = FormStartPosition.CenterScreen;

                Stopwatch sw = new Stopwatch();
                sw.Start();  
                while (!WB.finishedLoading)
                {
                    if (sw.ElapsedMilliseconds > 5000)
                        break;
                }
                WB.Show();
                WB.BringToFront();
                WB = null;
                sw.Stop();
                sw = null;
            };
            printDocument1.EndPrint += (o, e) =>
            {
                if (printDocument1.PrintController.IsPreview)
                    return;

                if (Application.OpenForms.OfType<WarningBox>().Any(form => form.Text == "Printing"))
                    Application.OpenForms.OfType<WarningBox>().First(form => form.Text == "Printing").Dispose();
            };

            PrintEvents(null, null);
        }
                    //  This function setups the page settings before printing.
        protected void PrintEvents(object sender, EventArgs e)
        {
            Settings1 settings = Settings1.Default;

            printDocument1.DefaultPageSettings.Margins.Left = settings.PS_Margin1.X * 4;
            printDocument1.DefaultPageSettings.Margins.Right = settings.PS_Margin1.Y * 4;
            printDocument1.DefaultPageSettings.Margins.Top = settings.PS_Margin1.Y * 4;
            printDocument1.DefaultPageSettings.Margins.Bottom = settings.PS_Margin1.X * 4;
            printDocument1.DefaultPageSettings.Landscape = !settings.PS_Portrait;
            printDocument1.DocumentName = String.Format("{0} - Notepad", dnp.fileName);

            switch (settings.PS_Size)
            {
                case "A3":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A3", 1170, 1650);
                    break;
                case "A4":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A4", 830, 1170);
                    break;
                case "A5":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A5", 583, 830);
                    break;
                case "A6":  //  Out of support!
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("A6", 413, 583);
                    break;
                case "B4":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("B4", 984, 1390);
                    break;
                case "B5":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("B5", 693, 984);
                    break;
                case "C2":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("C2", 2551, 1803);
                    break;
                case "C3":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("C3", 1803, 1276);
                    break;
                case "D0":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("D0", 4291, 3035);
                    break;
                case "Legal":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Legal", 850, 1321);
                    break;
                case "Letter":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Letter", 850, 1100);
                    break;
                case "Ledger":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Ledger", 1100, 1700);
                    break;
                case "Tabloid":
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 1700, 1100);
                    break;
            }

            printDialog1.Document = printDocument1;
            myReader = new StringReader(rtbText);
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

                    //  This function formats(the contents) and prints the Document.
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float rightMargin = ev.MarginBounds.Right;
            string line = null;

            Font printFont = rtbFont;
            SolidBrush myBrush = new SolidBrush(Color.Black);

                    // Work out the number of lines per page, using the MarginBounds.
            linesPerPage = ((printDocument1.DefaultPageSettings.PaperSize.Height - Settings1.Default.PS_Margin2.X * 4
                - Settings1.Default.PS_Margin2.Y * 4 - 30) / printFont.GetHeight(ev.Graphics));

                    //  These lines print the 'Header' and the 'Footer' if they are
                    //  not empty.
                    //  Both in header and footer arrays:
                    //  0 - represents the entire string unedited.
                    //  1 - every text that should be written on the right.
                    //  2 - every text that should be written in the center.
                    //  3 - every text that should be written on the left.
            if (Header[0] != String.Empty)
            {
                Header = checkTextCommands(Header[0]);
                StringFormat Align = new StringFormat();
                yPosition = Settings1.Default.PS_Margin2.Y * 4 + (count * printFont.GetHeight(ev.Graphics));

                if (Header[1] != String.Empty)
                {
                    Align.Alignment = StringAlignment.Near;
                    ev.Graphics.DrawString(Header[1], printFont, myBrush, leftMargin, yPosition, Align);
                }
                if (Header[2] != String.Empty)
                {
                    Align.Alignment = StringAlignment.Center;
                    ev.Graphics.DrawString(Header[2], printFont, myBrush, printDocument1.DefaultPageSettings.PaperSize.Width / 2, yPosition, Align);
                }
                if (Header[3] != String.Empty)
                {
                    Align.Alignment = StringAlignment.Far;
                    int paperWidth = printDocument1.DefaultPageSettings.PaperSize.Width;
                    ev.Graphics.DrawString(Header[3], printFont, myBrush, paperWidth - (paperWidth - rightMargin), yPosition, Align);
                }
                count++;
            }
            if (Footer[0] != String.Empty)
            {
                Footer = checkTextCommands(Footer[0]);
                StringFormat Align = new StringFormat();
                yPosition = printDocument1.DefaultPageSettings.PaperSize.Height - Settings1.Default.PS_Margin2.Y * 4 - printFont.GetHeight(ev.Graphics);

                if (Footer[1] != String.Empty)
                {
                    Align.Alignment = StringAlignment.Near;
                    ev.Graphics.DrawString(Footer[1], printFont, myBrush, leftMargin, yPosition, Align);
                }
                if (Footer[2] != String.Empty)
                {
                    Align.Alignment = StringAlignment.Center;
                    ev.Graphics.DrawString(Footer[2], printFont, myBrush, printDocument1.DefaultPageSettings.PaperSize.Width / 2, yPosition, Align);
                }
                if (Footer[3] != String.Empty)
                {
                    Align.Alignment = StringAlignment.Far;
                    int paperWidth = printDocument1.DefaultPageSettings.PaperSize.Width;
                    ev.Graphics.DrawString(Footer[3], printFont, myBrush, paperWidth - (paperWidth - rightMargin), yPosition, Align);
                }
            }

                    //  This while statement prints the text of the file.
                    //  If a line is broken because its too long the software will
                    //  first print the 'nextLine' string until it can be printed
                    //  without breaking.
                    //  If 'nextLine' is empty then print the next line IN THE TEXT
                    //  EDITOR.
            while (count < linesPerPage)
            {
                    //  If the last line can override the Footer then break this loop,
                    //  and start a new page.
                yPosition = Settings1.Default.PS_Margin2.Y * 4 + (count * printFont.GetHeight(ev.Graphics));
                if (yPosition + printFont.GetHeight(ev.Graphics) >
                    printDocument1.DefaultPageSettings.PaperSize.Height - Settings1.Default.PS_Margin2.Y * 4 - printFont.GetHeight(ev.Graphics))
                {
                    linesPerPage--;
                    break;
                }
                if (nextLine != "")
                {
                    line = checkLinePrint(nextLine, out nextLine);
                }
                else if ((line = myReader.ReadLine()) != null)
                {
                    line = checkLinePrint(line, out nextLine);
                }
                ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }

                    //  If there are more lines, print another page.
            if (line != null)
            {
                PageLine++;
                ev.HasMorePages = true;
            }
            else
            {
                ev.HasMorePages = false;

                if (Application.OpenForms.OfType<WarningBox>().First().Text == "Printing")
                {
                    Application.OpenForms.OfType<WarningBox>().First().Dispose();
                }
            }

            myBrush.Dispose();
        }

        private string checkLinePrint(string str1, out string nextL)
        {
                    //  Here the software checks if the text written is too long
                    //  for a line, if it is then break the line.
                    //  If the line is too long AND has spaces break the line per word.
                    //  If the line is too long AND doesn't have spaces break the line
                    //  at the first letter that extends beyond the margins.
            Font sFont = rtbFont;
            SizeF size = TextRenderer.MeasureText(str1, sFont);

            nextLine = "";
            while ((size.Width) > (printDocument1.DefaultPageSettings.Bounds.Width
                - printDocument1.DefaultPageSettings.Margins.Right
                - printDocument1.DefaultPageSettings.Margins.Left - 30))
            {
                if (str1.Contains(" "))
                {
                    nextLine = str1.Substring(str1.LastIndexOf(" ") + 1) + " " + nextLine;
                    str1 = str1.Substring(0, str1.LastIndexOf(" "));
                }
                else
                {
                    nextLine = str1.Substring(str1.Length - 1) + nextLine;
                    str1 = str1.Substring(0, str1.Length - 1);
                }
                size = TextRenderer.MeasureText(str1, sFont);
            }
            nextL = nextLine;
            return str1;
        }

        private string[] checkTextCommands(string arr)
        {
            string[] returnArray = new string[4];
            returnArray[0] = arr;
            string command = "";
            bool firstRun = true;

            if (!arr.Contains('&'))
            {
                if (firstRun)
                {
                    returnArray[2] = returnArray[2] + arr;
                    firstRun = false;
                }
            }

            while (arr.Contains('&'))
            {
                        //  First the software converts the &d,&t etc' to their text.
                        //  Here we use Regex to replace all text regardless of capital letters.
                if (arr.ToLower().Contains("&d"))
                {
                    DateTime DateStr = DateTime.Now;

                    arr = Regex.Replace(arr,Regex.Escape("&d"), DateStr.ToString().Substring(
                        0, DateStr.Date.ToString().IndexOf(" ")).Replace("$","$$"), RegexOptions.IgnoreCase);
                }
                if (arr.ToLower().Contains("&t"))
                {
                    DateTime DateStr = DateTime.Now;

                    arr = Regex.Replace(arr,Regex.Escape("&t"), DateStr.ToString().Substring(
                        DateStr.Date.ToString().IndexOf(" ") + 1).Replace("$","$$"), RegexOptions.IgnoreCase);
                }
                if (arr.ToLower().Contains("&f"))
                {
                    arr = Regex.Replace(arr,Regex.Escape("&f"), dnp.fileName.Replace("$","$$"), RegexOptions.IgnoreCase);
                }
                if (arr.ToLower().Contains("&p"))
                {
                    arr = Regex.Replace(arr,Regex.Escape("&p"), PageLine.ToString().Replace("$","$$"), RegexOptions.IgnoreCase);
                }

                        //  Then the software figures out where to send each text to
                        //  in the array.
                if (firstRun)
                {
                    returnArray[2] = returnArray[2] + arr.Substring(0, arr.IndexOf('&'));
                    firstRun = false;
                }
                        //  'command' string grabs the '&l','&c' and '&r'.
                        //  every text after the command string the software will know
                        //  where to assign this text to in the array.
                        //      0 - general string.
                        //      1 - left text alignment.
                        //      2 - center text alignment.
                        //      3 - right text alignment.
                command = arr.Substring(arr.IndexOf('&'), 2);
                arr = arr.Substring(arr.IndexOf('&') + 2);

                switch (command.ToLower())
                {
                    case "&l":
                        if (arr.Contains('&'))
                        {
                            returnArray[1] = returnArray[1] + arr.Substring(0, arr.IndexOf('&'));
                        }
                        else
                        {
                            returnArray[1] = returnArray[1] + arr;
                        }
                        break;
                    case "&c":
                        if (arr.Contains('&'))
                        {
                            returnArray[2] = returnArray[2] + arr.Substring(0, arr.IndexOf('&'));
                        }
                        else
                        {
                            returnArray[2] = returnArray[2] + arr;
                        }
                        break;
                    case "&r":
                        if (arr.Contains('&'))
                        {
                            returnArray[3] = returnArray[3] + arr.Substring(0, arr.IndexOf('&'));
                        }
                        else
                        {
                            returnArray[3] = returnArray[3] + arr;
                        }
                        break;
                }
            }
            return returnArray;
        }
    }
}
