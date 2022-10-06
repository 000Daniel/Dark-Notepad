using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DarkNotepad
{
    public partial class Notepad : Form
    {
        private int Button3Length;
        private int Button4Length;
        private int Button5Length;
        private Point Button3DefPos;
        private Point Button4DefPos;
        private Point Button5DefPos;
        private int defaultLineYpos = 21;

        public string fileName = "Untitled";
        public string fileDirectory = String.Empty;

        private bool TextModded = false;
        private bool ForceSaveAs = false;
        private string SaveCommand = String.Empty;

        private int oldCaretPosition = 0;
        private int oldZoomFactor = 1;

        private int completeSelectionStart;
        private bool SelectionToRight = false;

        private string[] files = Array.Empty<string>();
        private bool OpenedDragFile = false;

        public Notepad(string Arg)
        {
            InitializeComponent();

            if (File.Exists(Arg))
            {
                //fileName = Path.GetFileName(Arg);
                //fileDirectory = Path.GetDirectoryName(Arg);
                //Debug.WriteLine(Arg);
                files = new string[] { Arg };
                openDroppedFile();
            }

            SendMessage(this.Handle, WM_SETICON, ICON_SMALL, Resource1.DarkNotepadSimpleIcon.Handle);
            SendMessage(this.Handle, WM_SETICON, ICON_BIG, Resource1.DarkNotepadIcon.Handle);

            Button3Length = button1.Size.Width +
                button2.Size.Width +
                button3.Size.Width;
            Button4Length = Button3Length +
                button4.Size.Width;
            Button5Length = Button4Length +
                button5.Size.Width;

            Button3DefPos = button3.Location;
            Button4DefPos = button4.Location;
            Button5DefPos = button5.Location;
        }

        //  Whenever the main Form is resized update the size of all controls.
        private void Notepad_Resize(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
            StatusPanel.Width = this.Width;
            StatusPanel.Location = new Point(0, this.Height - 59);
            if (Settings1.Default.StatusBar)
            {
                richTextBox1.Size = new Size(this.Width - 16,
                    this.Height - panel1.Location.Y - 61);
                CaretChange.Enabled = true;

                pictureBox1.Location = new Point(StatusPanel.Size.Width - 30, 0);
                StatusInnerPanel.Location = new Point(StatusPanel.Size.Width - 136, 0);
                StatusInnerPanel2.Location = new Point(StatusPanel.Size.Width - 242, 0);
                StatusInnerPanel3.Location = new Point(StatusPanel.Size.Width - 348, 0);
                if (StatusInnerPanel2.Location.X <= -2)
                {
                    StatusInnerPanel2.Location = new Point(-1, 0);
                }
                if (StatusInnerPanel3.Location.X <= -2)
                {
                    StatusInnerPanel3.Location = new Point(-1, 0);
                }
            }
            else
            {
                richTextBox1.Size = new Size(this.Width - 16,
                    this.Height - panel1.Location.Y - 41);
                CaretChange.Enabled = false;
            }
            richTextBox1.Location = new Point(0, panel1.Location.Y + 2);

            if (this.WindowState == FormWindowState.Maximized)
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
            }

            if (this.Width - 16 <= Button3Length)
            {
                button3.Location = new Point(0, defaultLineYpos);
                button4.Location = new Point(button3.Size.Width, defaultLineYpos);
                button5.Location = new Point(0, defaultLineYpos * 2);
                panel1.Location = new Point(0, defaultLineYpos * 3);
                return;
            }

            if (this.Width - 16 <= Button4Length)
            {
                button3.Location = Button3DefPos;
                button4.Location = new Point(0, defaultLineYpos);
                button5.Location = new Point(button4.Size.Width, defaultLineYpos);
                panel1.Location = new Point(0, defaultLineYpos * 2);
                return;
            }

            if (this.Width - 16 <= Button5Length)
            {
                button3.Location = Button3DefPos;
                button4.Location = Button4DefPos;
                button5.Location = new Point(0, defaultLineYpos);
                panel1.Location = new Point(0, defaultLineYpos * 2);
                return;
            }

            panel1.Location = new Point(0, defaultLineYpos);

            button3.Location = Button3DefPos;
            button4.Location = Button4DefPos;
            button5.Location = Button5DefPos;
        }

        public void updateTextFont()
        {
            richTextBox1.Font = Settings1.Default.Font;
        }

        public void updateFormName()
        {
                    //  This 'if' statement is necessary so that when the user Drags and
                    //  Drops a file the software would recognize the file as unmodified.
            if (OpenedDragFile && TextModded)
            {
                TextModded = false;
                OpenedDragFile = false;
            }
            if (TextModded)
            {
                this.Text = String.Format("*{0} - Notepad", fileName);
            }
            else
            {
                this.Text = String.Format("{0} - Notepad", fileName);
            }
        }

        private void Notepad_Load(object sender, EventArgs e)
        {
            if (Button5DefPos == button5.Location)
            {
                Notepad_Resize(sender, e);
            }
            richTextBox1.WordWrap = Settings1.Default.WordWrap;
            richTextBox1.AutoWordSelection = false;
            richTextBox1.EnableAutoDragDrop = false;
            richTextBox1.AllowDrop = true;
            StatusPanel.Visible = Settings1.Default.StatusBar;
            Settings1.Default.FindNextPrev = String.Empty;
            Settings1.Default.MatchCase = false;
            Settings1.Default.Encode = "UTF-8";
            Settings1.Default.Save();
            updateFormName();
            updateTextFont();
            updateThemeColors();
            updateStatusBar();
            this.Focus();
        }

        private void Notepad_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (!TextModded)
            {
                openDroppedFile();
                return;
            }
            if (Application.OpenForms.OfType<WarningBox>().Any())
            {
                return;
            }
            SaveCommand = "drop file";
            WarningBox WB = new WarningBox(String.Format("Do you want to save changes to {0}?", Path.Combine(fileDirectory, fileName)));
            WB.createButton(null, null, "Cancel", "CloseWarningBox", 70);
            WB.createButton(null, null, "Don't Save", "openDroppedFile", 90);
            WB.createButton(null, null, "Save", "SaveFile", 70);
            WB.StartPosition = FormStartPosition.CenterScreen;
            WB.Show();
            WB.BringToFront();

            WB = null;
            return;
        }

        //  This function can call other functions by their name,
        //  This is used by Context Menu buttons and some other forms.
        public void invokeMethod(object sender, EventArgs e, string methodname)
        {
            MethodInfo mi = this.GetType().GetMethod(methodname);
            mi.Invoke(this, null);
        }

        //  The next functions are called by the custom Context Menu
        //  buttons using the 'invokeMethod' function.
        //  TestEvent() for example is used to Debug buttons.
        public void TestEvent()
        {
            Debug.WriteLine("This is a test function for invokeMethod function.");
        }
        public void ExitSoftware()
        {
            if (Application.OpenForms.OfType<FindReplace>().Any())
                Application.OpenForms.OfType<FindReplace>().First().Close();
            Application.Exit();
        }
        public void ForceExitSoftware()
        {
            TextModded = false;
            Application.Exit();
        }
        public void NewFileCheck()
        {
            if (TextModded)
            {
                if (Application.OpenForms.OfType<WarningBox>().Any()) return;

                SaveCommand = "new file";
                WarningBox WB = new WarningBox(String.Format("Do you want to save changes to {0}?", Path.Combine(fileDirectory, fileName)));
                WB.createButton(null, null, "Cancel", "CloseWarningBox", 70);
                WB.createButton(null, null, "Don't Save", "NewFile", 90);
                WB.createButton(null, null, "Save", "SaveFile", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();

                WB = null;
            }
            else
            {
                NewFile();
            }
        }

        public void CloseWarningBox()
        {
            if (Application.OpenForms.OfType<WarningBox>().Any())
            {
                Application.OpenForms.OfType<WarningBox>().First().Close();
            }
        }
        public void CloseContextMenu()
        {
            if (Application.OpenForms.OfType<ContextMenu>().Any())
            {
                Application.OpenForms.OfType<ContextMenu>().First().Close();
            }
        }

        public void NewWindow()
        {
            Process.Start(Application.ExecutablePath);
        }

        public void OpenFile()
        {
            if (TextModded)
            {
                if (Application.OpenForms.OfType<WarningBox>().Any()) return;

                SaveCommand = "open file";
                WarningBox WB = new WarningBox(String.Format("Do you want to save changes to {0}?", Path.Combine(fileDirectory, fileName)));
                WB.createButton(null, null, "Cancel", "CloseWarningBox", 70);
                WB.createButton(null, null, "Don't Save", "ForceOpenFile", 90);
                WB.createButton(null, null, "Save", "SaveFile", 70);
                WB.StartPosition = FormStartPosition.CenterScreen;
                WB.Show();
                WB.BringToFront();

                WB = null;
            }
            else
            {
                ForceOpenFile();
            }
        }

        public void ForceOpenFile()
        {
            CloseWarningBox();
            CloseContextMenu();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Documents |*.txt|All Files |*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Open";
            if (ofd.ShowDialog() == DialogResult.Cancel) return;

            richTextBox1.Text = File.ReadAllText(ofd.FileName);
            fileName = Path.GetFileName(ofd.FileName);
            fileDirectory = Path.GetDirectoryName(ofd.FileName);

            ofd = null;
            TextModded = false;
            updateFormName();
            richTextBox1.Focus();
        }

        public void NewFile()
        {
            CloseContextMenu();

            richTextBox1.Text = String.Empty;
            richTextBox1.Lines = Array.Empty<string>();

            CloseWarningBox();

            fileName = "Untitled";
            fileDirectory = string.Empty;
            TextModded = false;
            updateFormName();
            richTextBox1.Focus();
        }

        public void ForceSaveFile()
        {
            ForceSaveAs = true;
            SaveFile();
        }

        public void SaveFile()
        {
            CloseContextMenu();
            CloseWarningBox();

            Encoding enc = Encoding.Default;
            switch (Settings1.Default.Encode)
            {
                case "ASCII":
                    enc = Encoding.ASCII;
                    break;
                case "Latin1":
                    enc = Encoding.Latin1;
                    break;
                case "UTF-32":
                    enc = Encoding.UTF32;
                    break;
                case "UTF-16 LE":
                    enc = Encoding.Unicode;
                    break;
                case "UTF-16 BE":
                    enc = Encoding.BigEndianUnicode;
                    break;
                case "UTF-8":
                    enc = Encoding.UTF8;
                    break;
                case "UTF-7":
                    enc = Encoding.UTF7;
                    break;
            }

            if (File.Exists(Path.Combine(fileDirectory, fileName)) &&
                fileDirectory != String.Empty && !ForceSaveAs)
            {
                StreamWriter sw = new StreamWriter(File.Create(Path.Combine(fileDirectory, fileName)), enc);
                sw.Write(richTextBox1.Text);
                sw.Dispose();
            }
            else
            {
                ForceSaveAs = false;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text Documents |*.txt|All Files |*.*";
                sfd.FilterIndex = 1;
                sfd.Title = "Save As";
                if (fileName == "Untitled" && fileDirectory == String.Empty)
                {
                    sfd.FileName = "*.txt";
                }
                else
                {
                    sfd.FileName = fileName;
                }

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) return;

                
                StreamWriter sw = new StreamWriter(File.Create(sfd.FileName), enc);
                sw.Write(richTextBox1.Text);
                sw.Dispose();

                fileName = Path.GetFileName(sfd.FileName);
                fileDirectory = Path.GetDirectoryName(sfd.FileName);
                sfd.Dispose();
            }

            ForceSaveAs = false;
            TextModded = false;
            if (SaveCommand == "exit")
            {
                Application.Exit();
            }
            if (SaveCommand == "new file")
            {
                NewFile();
            }
            if (SaveCommand == "open file")
            {
                OpenFile();
            }
            if (SaveCommand == "drop file")
            {
                openDroppedFile();
            }
            SaveCommand = String.Empty;
            updateFormName();
            richTextBox1.Focus();
        }
        public void openDroppedFile()
        {
            CloseWarningBox();
            OpenedDragFile = true;
            richTextBox1.Text = File.ReadAllText(files[0]);
            fileName = Path.GetFileName(files[0]);
            fileDirectory = Path.GetDirectoryName(files[0]);

            updateFormName();
            richTextBox1.Focus();

            files = Array.Empty<string>();
        }

        public void UndoFunc()
        {
            CloseContextMenu();
            richTextBox1.Undo();
            richTextBox1.Focus();
        }
        public void RedoFunc()
        {
            CloseContextMenu();
            richTextBox1.Redo();
            richTextBox1.Focus();
        }
        public void CutFunc()
        {
            CloseContextMenu();
            if (richTextBox1.SelectionLength > 0)
                richTextBox1.Cut();
            richTextBox1.Focus();
        }
        public void CopyFunc()
        {
            CloseContextMenu();
            if (richTextBox1.SelectionLength > 0)
                richTextBox1.Copy();
            richTextBox1.Focus();
        }
        public void PasteFunc()
        {
            CloseContextMenu();

            IDataObject id = Clipboard.GetDataObject();
            if (id.GetDataPresent(DataFormats.UnicodeText)
                || id.GetDataPresent(DataFormats.Text)
                || id.GetDataPresent(DataFormats.Html))
            {
                richTextBox1.SelectedText = Clipboard.GetText();
            }
            richTextBox1.Focus();
        }
        public void DeleteFunc()
        {
            CloseContextMenu();
            if (richTextBox1.SelectionLength > 0)
                richTextBox1.SelectedText = "";
            richTextBox1.Focus();
        }

        public void InternetSearchFunc()
        {
            CloseContextMenu();
            if (richTextBox1.SelectionLength > 0)
            {
                String SearchEngine = "https://duckduckgo.com/?q=";

                if (Settings1.Default.CustomBrowserURL != String.Empty)
                {
                    SearchEngine = Settings1.Default.CustomBrowserURL;
                }
                else
                {
                    SearchEngine = Settings1.Default.SearchEngine;

                    switch (SearchEngine)
                    {
                        case "DuckDuckGo":
                            SearchEngine = "https://duckduckgo.com/?q=";
                            break;
                        case "Google":
                            SearchEngine = "https://www.google.com/search?q=";
                            break;
                        case "Bing":
                            SearchEngine = "https://www.bing.com/search?q=";
                            break;
                        case "SearX":
                            SearchEngine = "http://searx.thegpm.org/?q=";
                            break;
                        case "Yandex":
                            SearchEngine = "https://yandex.com/search/?text=";
                            break;
                    }
                }

                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        FileName = string.Format("{0}{1}", SearchEngine, richTextBox1.SelectedText),
                    });
                }
                catch (Exception other)
                {
                    WarningBox WB = new WarningBox(String.Format("{0}", other.Message));
                    WB.createButton(null, null, "Okay", "CloseWarningBox", 70);
                    WB.StartPosition = FormStartPosition.CenterScreen;
                    WB.Show();
                    WB.BringToFront();

                    WB = null;
                }
            }
        }
        public void SelectAllFunc()
        {
            CloseContextMenu();
            richTextBox1.Focus();
            richTextBox1.SelectAll();
            completeSelectionStart = -1;
            SelectionToRight = false;
        }
        public void TimeDateFunc()
        {
            CloseContextMenu();
            richTextBox1.SelectedText = DateTime.Now.ToString();
            richTextBox1.Focus();
        }

        public void FindReplaceMenu()
        {
            FindReplace FR = new FindReplace();
            FR.StartPosition = FormStartPosition.CenterScreen;
            FR.Show();
            FR.BringToFront();
            FR.TopMost = true;
            FR = null;
        }
        public void GoToMenu()
        {
            GoTo GT = new GoTo();
            GT.StartPosition = FormStartPosition.CenterScreen;
            GT.Show();
            GT.BringToFront();
            GT = null;
        }
        public void WordWrapFunc()
        {
            Settings1.Default.WordWrap = !Settings1.Default.WordWrap;
            Settings1.Default.Save();
            richTextBox1.WordWrap = Settings1.Default.WordWrap;
            richTextBox1.AutoWordSelection = false;
            CloseContextMenu();
            richTextBox1.Focus();
        }
        public void ZoomInFunc()
        {
            CloseContextMenu();
            richTextBox1.Focus();

            if (richTextBox1.ZoomFactor < 5)
                richTextBox1.ZoomFactor += 0.1f;
        }
        public void ZoomOutFunc()
        {
            CloseContextMenu();
            richTextBox1.Focus();

            if (richTextBox1.ZoomFactor > 0.1f)
                richTextBox1.ZoomFactor -= 0.1f;
        }
        public void ZoomResetFunc()
        {
            CloseContextMenu();
            richTextBox1.Focus();

            richTextBox1.ZoomFactor = 1;
        }
        public void FontMenu()
        {
            FontMenu FM = new FontMenu();
            FM.StartPosition = FormStartPosition.CenterScreen;
            FM.Show();
            FM.BringToFront();
            FM = null;
        }
        public void StatusBarFunc()
        {
            Settings1.Default.StatusBar = !Settings1.Default.StatusBar;
            Settings1.Default.Save();
            StatusPanel.Visible = Settings1.Default.StatusBar;
            Notepad_Resize(null, null);
            richTextBox1.Focus();
        }
        public void AboutMenu()
        {
            AboutMenu AM = new AboutMenu();
            AM.Show();
            AM.Location = new Point(this.Location.X + this.Width / 3, this.Location.Y + this.Height / 4);
            AM.BringToFront();
            AM = null;
        }
        public void ViewHelpMenu()
        {
            ViewHelp VA = new ViewHelp();
            VA.Show();
            VA.Location = new Point(this.Location.X + this.Width / 3, this.Location.Y + this.Height / 4);
            VA.BringToFront();
            VA = null;
        }
        public void StylizeMenu()
        {
            Stylize SM = new Stylize();
            SM.StartPosition = FormStartPosition.CenterScreen;
            SM.Show();
            SM.BringToFront();
            SM = null;
        }
        public void ResetThemes()
        {
            if (Application.OpenForms.OfType<Stylize>().Any())
            {
                Application.OpenForms.OfType<Stylize>().First().reset_Theme();
                CloseWarningBox();
                Application.OpenForms.OfType<Stylize>().First().BringToFront();
                Application.OpenForms.OfType<Stylize>().First().Focus();
            }
            else
            {
                Stylize SStyle = new Stylize();
                if (Application.OpenForms.OfType<WarningBox>().Any())
                {
                    SStyle.reset_Theme();
                    CloseWarningBox();
                }
                else
                {
                    SStyle.Reset_Click(null, null);
                }
                SStyle.Dispose();
            }
        }
        public void SendFeedback()
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo("https://github.com/000Daniel/Dark-Notepad/issues");
                proc.UseShellExecute = true;
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error!:\n" + ex.Message);
            }
        }
        public void PageSetupMenu()
        {
            PageSetup PS = new PageSetup();
            PS.StartPosition = FormStartPosition.CenterScreen;
            PS.Show();
            PS.BringToFront();
            PS = null;
        }
                //  These are the encoders which the software uses to save files.
                //  By default the software would use UTF-8.
        public void Encode1()
        {
            EncodeStr("ASCII");
        }
        public void Encode2()
        {
            EncodeStr("Latin1");
        }
        public void Encode3()
        {
            EncodeStr("UTF-32");
        }
        public void Encode4()
        {
            EncodeStr("UTF-16 LE");
        }
        public void Encode5()
        {
            EncodeStr("UTF-16 BE");
        }
        public void Encode6()
        {
            EncodeStr("UTF-8");
        }
        public void Encode7()
        {
            EncodeStr("UTF-7");
        }
        public void EncodeStr(string str)
        {
            CloseContextMenu();
            Settings1.Default.Encode = str;
            Settings1.Default.Save();
            if (Application.OpenForms.OfType<ViewHelp>().Any())
            {
                Application.OpenForms.OfType<ViewHelp>().First().button4.Text = Settings1.Default.Encode.ToString(); ;
            }
            updateStatusBar();
        }


        /*  These are the paper sizes supported. 
         *  THIS FEATURE MIGHT NOT WORK AT ALL! IT HAS NOT BEEN TESTED!
         *  (Inches)
            A3 (11.7, 16.5)
            A4 (8,3 11.7)
            A5 (5.8, 8.3)
            A6 (4.13, 5.83) --Not supported
            B4 (9.84, 13.90)
            B5 (6.93, 9.84)
            Legal (8.50, 13.21)
            Letter (8.50, 11.00)
            Ledger (11, 17)
            Tabloid (17, 11)
            C2 (25.51,18.03)
            C3 (18.03, 12.76)
            D0 (42.91, 30.35)
        */
        public void PS_PaperSize1()
        {
            PS_PaperSize("A3");
        }
        public void PS_PaperSize2()
        {
            PS_PaperSize("A4");
        }
        public void PS_PaperSize3()
        {
            PS_PaperSize("A5");
        }
        public void PS_PaperSize4()     //  Out of support due to size printing issues.
        {
            PS_PaperSize("A6");
        }
        public void PS_PaperSize5()
        {
            PS_PaperSize("B4");
        }
        public void PS_PaperSize6()
        {
            PS_PaperSize("B5");
        }
        public void PS_PaperSize7()
        {
            PS_PaperSize("Legal");
        }
        public void PS_PaperSize8()
        {
            PS_PaperSize("Letter");
        }
        public void PS_PaperSize9()
        {
            PS_PaperSize("Ledger");
        }
        public void PS_PaperSize10()
        {
            PS_PaperSize("Tabloid");
        }
        public void PS_PaperSize11()
        {
            PS_PaperSize("C2");
        }
        public void PS_PaperSize12()
        {
            PS_PaperSize("C3");
        }
        public void PS_PaperSize13()
        {
            PS_PaperSize("D0");
        }
        public void PS_PaperSize(string str)
        {
            CloseContextMenu();
            if (Application.OpenForms.OfType<PageSetup>().Any())
            {
                Application.OpenForms.OfType<PageSetup>().First().button1.Text = str;
                Application.OpenForms.OfType<PageSetup>().First().button4_Click(null, null);
            }
        }
        public void PrintFile()
        {
            CloseContextMenu();
                //  PagePrint class is responsible for printing.
            new PagePrint().Start(richTextBox1.Text, richTextBox1.Font);
        }

                //  These functions handle the custom Context Menu script.
                //  cxm is the context menu that these functions add buttons to,
                //  the 'createButton' function also takes a method name which it would
                //  call(on this script) when pressed.
        private void button1_Click(object sender, EventArgs e)
        {
            ContextMenu cxm = new ContextMenu();
            cxm.ShowInTaskbar = false;
            cxm.createButton(sender, e, "New", "NewFileCheck");
            cxm.createButton(sender, e, "New Window", "NewWindow");
            cxm.createButton(sender, e, "Open...", "OpenFile");
            cxm.createButton(sender, e, "Save", "SaveFile");
            cxm.createButton(sender, e, "Save As...", "ForceSaveFile");
            cxm.createPanelLine(sender, e, 4);
            cxm.createButton(sender, e, "Page Setup...", "PageSetupMenu");
            cxm.createButton(sender, e, "Print...", "PrintFile");
            cxm.createPanelLine(sender, e, 4);
            cxm.createButton(sender, e, "Exit", "ExitSoftware");
            cxm.Show();

            int Xpos = button1.Location.X + this.Left + 7;
            int Ypos = button1.Location.Y + button1.Size.Height + 30 + this.Top;
            cxm.Location = new Point(Xpos, Ypos);

            cxm = null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool gotoEnabled = true;
            bool hasText = false;
            bool selectedText = false;
            bool pasteableText = false;
            if (Settings1.Default.WordWrap || richTextBox1.Lines.Count() <= 1)
            {
                gotoEnabled = false;
            }
            if (richTextBox1.Text.Length > 0)
            {
                hasText = true;
            }
            if (richTextBox1.SelectionLength > 0)
            {
                selectedText = true;
            }
            IDataObject id = Clipboard.GetDataObject();
            if (id.GetDataPresent(DataFormats.UnicodeText)
                || id.GetDataPresent(DataFormats.Text)
                || id.GetDataPresent(DataFormats.Html))
            {
                pasteableText = true;
            }
            ContextMenu cxm = new ContextMenu();
            cxm.ShowInTaskbar = false;
            cxm.createButton(sender, e, "Undo", "UndoFunc", richTextBox1.CanUndo);
            cxm.createButton(sender, e, "Redo", "RedoFunc", richTextBox1.CanRedo);
            cxm.createPanelLine(sender, e, 4);
            cxm.createButton(sender, e, "Cut", "CutFunc", selectedText);
            cxm.createButton(sender, e, "Copy", "CopyFunc", selectedText);
            cxm.createButton(sender, e, "Paste", "PasteFunc", pasteableText);
            cxm.createButton(sender, e, "Delete", "DeleteFunc", selectedText);
            cxm.createPanelLine(sender, e, 4);
            cxm.createButton(sender, e, "Internet Search...", "InternetSearchFunc", selectedText);
            cxm.createButton(sender, e, "Find...", "FindReplaceMenu", hasText);
            cxm.createButton(sender, e, "Replace...", "FindReplaceMenu", hasText);
            cxm.createButton(sender, e, "Go To...", "GoToMenu", gotoEnabled);
            cxm.createPanelLine(sender, e, 4);
            cxm.createButton(sender, e, "Select All", "SelectAllFunc");
            cxm.createButton(sender, e, "Time/Date", "TimeDateFunc");

            cxm.Show();

            int Xpos = button2.Location.X + this.Left + 7;
            int Ypox = button2.Location.Y + button2.Size.Height + 30 + this.Top;
            cxm.Location = new Point(Xpos, Ypox);

            id = null;
            cxm = null;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ContextMenu cxm = new ContextMenu();
            cxm.ShowInTaskbar = false;
            cxm.createButton(sender, e, "Word Wrap", "WordWrapFunc", true, Settings1.Default.WordWrap);
            cxm.createButton(sender, e, "Font...", "FontMenu");
            cxm.createButton(sender, e, "Stylize...", "StylizeMenu");

            cxm.Show();

            int Xpos = button3.Location.X + this.Left + 7;
            int Ypox = button3.Location.Y + button3.Size.Height + 30 + this.Top;
            cxm.Location = new Point(Xpos, Ypox);

            cxm = null;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ContextMenu cxm = new ContextMenu();
            cxm.ShowInTaskbar = false;
            cxm.createButton(sender, e, "Zoom In", "ZoomInFunc");
            cxm.createButton(sender, e, "Zoom Out", "ZoomOutFunc");
            cxm.createButton(sender, e, "Restore Default Zoom", "ZoomResetFunc");
            cxm.createButton(sender, e, "Status Bar", "StatusBarFunc", true, Settings1.Default.StatusBar);

            cxm.Show();

            int Xpos = button4.Location.X + this.Left + 7;
            int Ypox = button4.Location.Y + button4.Size.Height + 30 + this.Top;
            cxm.Location = new Point(Xpos, Ypox);

            cxm = null;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ContextMenu cxm = new ContextMenu();
            cxm.ShowInTaskbar = false;
            cxm.createButton(sender, e, "View Help", "ViewHelpMenu");
            cxm.createButton(sender, e, "Send Feedback", "SendFeedback");
            cxm.createPanelLine(sender, e, 4);
            cxm.createButton(sender, e, "About Dark Notepad", "AboutMenu");

            cxm.Show();

            int Xpos = button5.Location.X + this.Left + 7;
            int Ypox = button5.Location.Y + button5.Size.Height + 30 + this.Top;
            cxm.Location = new Point(Xpos, Ypox);

            cxm = null;
        }

                //  These functions make sure to display the correct Context Menu,
                //  depending on what button the mouse is hovering over.
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<ContextMenu>().Any()) return;
            if (Application.OpenForms.OfType<ContextMenu>().First().Location.X
                == button1.Location.X + this.Left + 7) return;

            Application.OpenForms.OfType<ContextMenu>().First().Close();
            button1_Click(sender, e);
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<ContextMenu>().Any()) return;
            if (Application.OpenForms.OfType<ContextMenu>().First().Location.X
                == button2.Location.X + this.Left + 7) return;

            Application.OpenForms.OfType<ContextMenu>().First().Close();
            button2_Click(sender, e);
        }
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<ContextMenu>().Any()) return;
            if (Application.OpenForms.OfType<ContextMenu>().First().Location.X
                == button3.Location.X + this.Left + 7) return;

            Application.OpenForms.OfType<ContextMenu>().First().Close();
            button3_Click(sender, e);
        }
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<ContextMenu>().Any()) return;
            if (Application.OpenForms.OfType<ContextMenu>().First().Location.X
                == button4.Location.X + this.Left + 7) return;

            Application.OpenForms.OfType<ContextMenu>().First().Close();
            button4_Click(sender, e);
        }
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<ContextMenu>().Any()) return;
            if (Application.OpenForms.OfType<ContextMenu>().First().Location.X
                == button5.Location.X + this.Left + 7) return;

            Application.OpenForms.OfType<ContextMenu>().First().Close();
            button5_Click(sender, e);
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

                //  This function handles warning boxes and other forms that need
                //  to be shown on top of the main form.
        private void Notepad_Activated(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Stylize>().Any())
            {
                Application.OpenForms.OfType<Stylize>().First().BringToFront();
            }
            if (Application.OpenForms.OfType<WarningBox>().Any(form => form.Text == "Printing"))
            {
                Application.OpenForms.OfType<WarningBox>().First(form => form.Text == "Printing").Dispose();
            }
            if (Application.OpenForms.OfType<WarningBox>().Any())
            {
                Application.OpenForms.OfType<WarningBox>().First().BringToFront();
                return;
            }
            if (Application.OpenForms.OfType<GoTo>().Any())
            {
                Application.OpenForms.OfType<GoTo>().First().BringToFront();
                return;
            }
            if (Application.OpenForms.OfType<AboutMenu>().Any())
            {
                Application.OpenForms.OfType<AboutMenu>().First().BringToFront();
                return;
            }
            if (Application.OpenForms.OfType<ViewHelp>().Any())
            {
                Application.OpenForms.OfType<ViewHelp>().First().BringToFront();
                return;
            }
            if (Application.OpenForms.OfType<PageSetup>().Any())
            {
                Application.OpenForms.OfType<PageSetup>().First().BringToFront();
                return;
            }
        }

                //  This function handles whether to add a '*' to the title or not.
                //  '*' means the file has been edited but not saved.
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (fileName == "Untitled" && fileDirectory == String.Empty
                && richTextBox1.Text == String.Empty
                || files.Count() >= 1 && files[0] == String.Empty)
            {
                return;
            }

            TextModded = true;
            updateFormName();
        }

        private void updateStatusBar()
        {
            int Ln = 1;
            int Col = 1;
            if (SelectionToRight)
            {
                Ln = richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart);
                Col = richTextBox1.SelectionStart
                    - richTextBox1.GetFirstCharIndexFromLine(Ln);
            }
            else
            {
                Ln = richTextBox1.GetLineFromCharIndex(
                    richTextBox1.SelectionStart + richTextBox1.SelectionLength);
                Col = richTextBox1.SelectionStart + richTextBox1.SelectionLength
                    - richTextBox1.GetFirstCharIndexFromLine(Ln);
            }

            statusLabel1.Text = String.Format("{0}", Settings1.Default.Encode);
            statusLabel2.Text = String.Format("{0}%", oldZoomFactor);
            statusLabel3.Text = String.Format("Ln {0},Col {1}", Ln + 1, Col + 1);
        }

        private void Notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!TextModded)
            {
                return;
            }

            e.Cancel = true;
            if (Application.OpenForms.OfType<WarningBox>().Any()) return;

            SaveCommand = "exit";
            WarningBox WB = new WarningBox(String.Format("Do you want to save changes to {0}?", Path.Combine(fileDirectory, fileName)));
            WB.createButton(null, null, "Cancel", "CloseWarningBox", 70);
            WB.createButton(null, null, "Don't Save", "ForceExitSoftware", 90);
            WB.createButton(null, null, "Save", "SaveFile", 70);
            WB.StartPosition = FormStartPosition.CenterScreen;
            WB.Show();
            WB.BringToFront();
            WB = null;
        }

                //  Every 10 seconds the software runs a Garbage Collection.
        private void CollectGarbage_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

                //  These are all the current custom keybinds/shortcuts.
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;

                IDataObject id = Clipboard.GetDataObject();
                if (id.GetDataPresent(DataFormats.UnicodeText)
                || id.GetDataPresent(DataFormats.Text)
                || id.GetDataPresent(DataFormats.Html))
                {
                    richTextBox1.SelectedText = Clipboard.GetText();
                }
                id = null;
            }
            if (e.Control && !e.Shift && e.KeyCode == Keys.N)
            {
                e.Handled = true;
                NewFileCheck();
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.N)
            {
                e.Handled = true;
                NewWindow();
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                e.Handled = true;
                OpenFile();
            }
            if (e.Control && !e.Shift && e.KeyCode == Keys.S)
            {
                e.Handled = true;
                SaveFile();
            }
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                e.Handled = true;
                ForceSaveFile();
            }
            if (e.Control && e.KeyCode == Keys.P)
            {
                e.Handled = true;
                PrintFile();
            }
            if (e.Control && e.KeyCode == Keys.E)
            {
                e.Handled = true;
                InternetSearchFunc();
            }
            if (e.Control && (e.KeyCode == Keys.F || e.KeyCode == Keys.H))
            {
                e.Handled = true;
                FindReplaceMenu();
            }
            if (e.KeyCode == Keys.F3)
            {
                e.Handled = true;

                if (Settings1.Default.FindNextPrev == String.Empty)
                {
                    FindReplaceMenu();
                }
                else
                {
                    FindReplace FR = new FindReplace();

                    if (e.Shift)
                    {
                        FR.button1_Click(sender, e);
                    }
                    else
                    {
                        FR.button2_Click(sender, e);
                    }
                }
            }
            if (e.Control && e.KeyCode == Keys.G)
            {
                e.Handled = true;
                GoToMenu();
            }
            if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                TimeDateFunc();
            }
            if (e.Control && e.KeyCode == Keys.A)
            {
                e.Handled = true;
                SelectAllFunc();
            }
            if (e.Control && (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add))
            {
                e.Handled = true;
                ZoomInFunc();
            }
            if (e.Control && (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract))
            {
                e.Handled = true;
                ZoomOutFunc();
            }
            if (e.Control && (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0))
            {
                e.Handled = true;
                ZoomResetFunc();
            }
            if (e.KeyCode == Keys.Tab)
            {
                e.Handled = true;
                richTextBox1.Focus();
                richTextBox1.SelectedText = new string(' ', 4);
            }
            if (e.Control && e.KeyCode == Keys.R)
            {
                e.Handled = true;
                ResetThemes();
            }
        }

                //  This function handles the custom 'size Grip'.
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Size = new Size(MousePosition.X - this.Location.X + 25, MousePosition.Y - this.Location.Y + 25);
                this.Update();
            }
        }

                //  This function is responsible for beginning to update the status bar
                //  info, (Ln,Col), Zoom factor and Encoder.
        private void CaretChange_Tick(object sender, EventArgs e)
        {
            if (!Settings1.Default.StatusBar) return;

            if (oldCaretPosition != richTextBox1.SelectionStart
                + richTextBox1.SelectionLength)
            {
                oldCaretPosition = richTextBox1.SelectionStart
                    + richTextBox1.SelectionLength;
                updateStatusBar();
            }

            string tempZoomFactor = (richTextBox1.ZoomFactor * 100).ToString();
            if (tempZoomFactor.Contains("."))
            {
                tempZoomFactor = tempZoomFactor.Substring(0, tempZoomFactor.IndexOf("."));
            }
            if (oldZoomFactor != int.Parse(tempZoomFactor))
            {
                oldZoomFactor = int.Parse(tempZoomFactor);
                updateStatusBar();
            }
        }

                //  This function determines whether the user is selecting left to right
                //  or right to left.
                //  this is used for the status bar (Ln, Col)
                //  KNOWN ISSUE: sometimes when ctrl+A the Ln,Col reset to 1, 1.
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (!Settings1.Default.StatusBar) return;
            if (completeSelectionStart == -1) return;
            SelectionToRight = false;

            if (richTextBox1.SelectionStart > completeSelectionStart)
            {
                completeSelectionStart = richTextBox1.SelectionStart;
            }

            if (richTextBox1.SelectionStart + richTextBox1.SelectionLength <= completeSelectionStart)
            {
                completeSelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
                SelectionToRight = true;
                updateStatusBar();
            }
        }

                //  This code sets different icons for the Top right icon and
                //  task bar icon.
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);

        private const uint WM_SETICON = 0x80u;
        private const int ICON_SMALL = 0;
        private const int ICON_BIG = 1;

        public void updateThemeColors()
        {
            SettingsStylize SStylize = SettingsStylize.Default;
            this.BackColor = SStylize.Background;
            this.ForeColor = SStylize.Text;
            richTextBox1.BackColor = SStylize.Background;
            richTextBox1.ForeColor = SStylize.Text;
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
            panel1.BackColor = SStylize.Background_Highlight;
        }
    }
}
//This software was created by 000Daniel on Github.
//      https://github.com/000Daniel
