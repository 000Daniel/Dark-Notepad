using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic.Devices;

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

        CustomScrollbar_Commands CSC = new CustomScrollbar_Commands();
        ImageGeneration ig = new ImageGeneration();
        public bool VScrollBar_HoldingUp = false, VScrollBar_HoldingDown = false,
            HScrollBar_HoldingLeft = false, HScrollBar_HoldingRight = false;
        public Bitmap VSB_Arrow_Up = null, VSB_Arrow_Up_Press = null,
            VSB_Arrow_Down = null, VSB_Arrow_Down_Press = null,
            HSB_Arrow_Left = null, HSB_Arrow_Left_Press = null,
            HSB_Arrow_Right = null, HSB_Arrow_Right_Press = null,
            Grab = null, Grab2 = null, Grab2_Empty = null, Grab2_Mirrored = null,
            Check = null, Check2 = null;

        private FormWindowState lastState;

        private int mouseDiffX = -1, mouseDiffY = -1;

        public Notepad(string Arg)
        {
            InitializeComponent();

            if (File.Exists(Arg))
            {
                files = new string[] { Arg };
                openDroppedFile();
            }
            SendMessage(this.Handle, WM_SETICON, ICON_SMALL, Resource1.DarkNotepadSimpleIcon.Handle);
            SendMessage(this.Handle, WM_SETICON, ICON_BIG, Resource1.DarkNotepadIcon.Handle);
            richTextBox1.MouseWheel += new MouseEventHandler(richTextBox1_scroll);
            HScrollBar_Thumb.Height = 15;
            HScrollBar_Thumb.Top = 1;
            VScrollBar_Thumb.Width = 15;
            VScrollBar_Thumb.Left = 1;
            CSC.dnp = this;
            VScrollBar_ArrowUp.MouseDown += new MouseEventHandler(CSC.VScrollBar_ArrowUp_MouseDown);
            VScrollBar_ArrowUp.MouseUp += new MouseEventHandler(CSC.VScrollBar_ArrowUp_MouseUp);
            VScrollBar_ArrowDown.MouseDown += new MouseEventHandler(CSC.VScrollBar_ArrowDown_MouseDown);
            VScrollBar_ArrowDown.MouseUp += new MouseEventHandler(CSC.VScrollBar_ArrowDown_MouseUp);
            HScrollBar_ArrowLeft.MouseDown += new MouseEventHandler(CSC.HScrollBar_ArrowLeft_MouseDown);
            HScrollBar_ArrowLeft.MouseUp += new MouseEventHandler(CSC.HScrollBar_ArrowLeft_MouseUp);
            HScrollBar_ArrowRight.MouseDown += new MouseEventHandler(CSC.HScrollBar_ArrowRight_MouseDown);
            HScrollBar_ArrowRight.MouseUp += new MouseEventHandler(CSC.HScrollBar_ArrowRight_MouseUp);
            HScrollBar_ArrowLeft.Click += new EventHandler((sender2, e2) => CSC.HScrollBar_ArrowLeft_Click(sender2 ,e2, richTextBox1));
            HScrollBar_ArrowRight.Click += new EventHandler((sender2, e2) => CSC.HScrollBar_ArrowRight_Click(sender2 ,e2, richTextBox1));
            VScrollBar_ArrowUp.Click += new EventHandler((sender2, e2) => CSC.VScrollBar_ArrowUp_Click(sender2 ,e2, richTextBox1));
            VScrollBar_ArrowDown.Click += new EventHandler((sender2, e2) => CSC.VScrollBar_ArrowDown_Click(sender2 ,e2, richTextBox1));

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

                    //  This fixes an issue, when minimizing the software could cause
                    //  The RichTextBox to change size to the wrong size;
            this.SizeChanged += (s, e) => {
                if (WindowState == lastState) return;
                switch (WindowState)
                {
                    case FormWindowState.Normal:
                        Notepad_Resize(null, null);
                        break;
                    case FormWindowState.Maximized:
                        Notepad_Resize(null, null);
                        break;
                }
                lastState = WindowState; };
        }

                //  Whenever the main Form is resized, update the size of all controls.
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
            ScrollGraphics();
            
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

                //  'ScrollGraphics()' is responsible for the custom scrollbar graphics.
                //  This function exists in other classes aswell.
        public void ScrollGraphics()
        {
            MassLoadImages();

            if (Application.OpenForms.OfType<WarningBox>().Any(form => form.Text == "Generating Icons"))
            {
                Application.OpenForms.OfType<WarningBox>().First(form => form.Text == "Generating Icons").Dispose();
            }

            if (!Settings1.Default.CustomScrollbar)
            {
                VScrollBar.Visible = false;
                HScrollBar.Visible = false;
                VScrollBar_ArrowDown.Visible = false;
                VScrollBar_ArrowUp.Visible = false;
                HScrollBar_ArrowLeft.Visible = false;
                HScrollBar_ArrowRight.Visible = false;
                ScrollBars_Grip.Visible = false;
                return;
            }
            else
            {
                if (!VScrollBar.Visible)
                {
                    VScrollBar.Visible = true;
                    VScrollBar_ArrowDown.Visible = true;
                    VScrollBar_ArrowUp.Visible = true;
                    ScrollBars_Grip.Visible = true;
                }
            }
                    //  This determines how should the 'grip' of the custom scrollbars display.
                    //  It'll display a grip if both scrollbars are enabled and the statusbar
                    //  disabled. Otherwize it will display empty or won't display at all.
            if (Settings1.Default.WordWrap || Settings1.Default.StatusBar || WindowState == FormWindowState.Maximized)
            {
                ScrollBars_Grip.Image = Grab2_Empty;
                ScrollBars_Grip.Enabled = false;

                if (Settings1.Default.WordWrap)
                {
                    ScrollBars_Grip.Visible = false;
                }
                else
                {
                    ScrollBars_Grip.Visible = true;
                }
            }
            else
            {
                if (richTextBox1.RightToLeft == RightToLeft.Yes)
                {
                    ScrollBars_Grip.Cursor = Cursors.SizeNESW;
                    ScrollBars_Grip.Image = Grab2_Mirrored;
                }
                else
                {
                    ScrollBars_Grip.Cursor = Cursors.SizeNWSE;
                    ScrollBars_Grip.Image = Grab2;
                }

                ScrollBars_Grip.Enabled = true;
                ScrollBars_Grip.Visible = true;
            }

            if (Settings1.Default.WordWrap)
            {
                HScrollBar.Visible = false;
                HScrollBar_ArrowLeft.Visible = false;
                HScrollBar_ArrowRight.Visible = false;

                VScrollBar.Size = new Size(17, richTextBox1.Height - 34);
                if (richTextBox1.RightToLeft == RightToLeft.Yes)
                {
                    VScrollBar.Location = new Point(0, richTextBox1.Top + 17);
                    VScrollBar_ArrowDown.Location = new Point(0, richTextBox1.Top + richTextBox1.Height - 17);
                    VScrollBar_ArrowUp.Location = new Point(0, richTextBox1.Top);
                }
                else
                {
                    VScrollBar.Location = new Point(richTextBox1.Width + richTextBox1.Left - 17, richTextBox1.Top + 17);
                    VScrollBar_ArrowDown.Location = new Point(richTextBox1.Width + richTextBox1.Left - 17, richTextBox1.Top + richTextBox1.Height - 17);
                    VScrollBar_ArrowUp.Location = new Point(richTextBox1.Width + richTextBox1.Left - 17, richTextBox1.Top);
                }
            }
            else
            {
                HScrollBar.Visible = true;
                HScrollBar_ArrowLeft.Visible = true;
                HScrollBar_ArrowRight.Visible = true;
                HScrollBar.Size = new Size(richTextBox1.Width - 51, 17);
                VScrollBar.Size = new Size(17, richTextBox1.Height - 51);
                if (richTextBox1.RightToLeft == RightToLeft.Yes)
                {
                    HScrollBar.Location = new Point(34, richTextBox1.Height + richTextBox1.Top - 17);
                    VScrollBar.Location = new Point(0, richTextBox1.Top + 17);

                    HScrollBar_ArrowLeft.Location = new Point(17, richTextBox1.Height + richTextBox1.Top - 17);
                    HScrollBar_ArrowRight.Location = new Point(richTextBox1.Width + richTextBox1.Left - 17, richTextBox1.Height + richTextBox1.Top - 17);
                    VScrollBar_ArrowDown.Location = new Point(0, richTextBox1.Top + richTextBox1.Height - 34);
                    VScrollBar_ArrowUp.Location = new Point(0, richTextBox1.Top);

                    ScrollBars_Grip.Location = new Point(0, richTextBox1.Height + richTextBox1.Top - 17);
                }
                else
                {
                    HScrollBar.Location = new Point(17, richTextBox1.Height + richTextBox1.Top - 17);
                    VScrollBar.Location = new Point(richTextBox1.Width + richTextBox1.Left - 17, richTextBox1.Top + 17);

                    HScrollBar_ArrowLeft.Location = new Point(0, richTextBox1.Height + richTextBox1.Top - 17);
                    HScrollBar_ArrowRight.Location = new Point(richTextBox1.Width + richTextBox1.Left - 34, richTextBox1.Height + richTextBox1.Top - 17);
                    VScrollBar_ArrowDown.Location = new Point(richTextBox1.Width + richTextBox1.Left - 17, richTextBox1.Top + richTextBox1.Height - 34);
                    VScrollBar_ArrowUp.Location = new Point(richTextBox1.Width + richTextBox1.Left - 17, richTextBox1.Top);

                    ScrollBars_Grip.Location = new Point(richTextBox1.Width + richTextBox1.Left - 17, richTextBox1.Height + richTextBox1.Top - 17);
                }
            }
            
            
        }
                //  'MassLoadImages()' checks if it loaded images already or not.
                //  if not it will load images from the 'temp' folder.
        private void MassLoadImages()
        {
            if (VSB_Arrow_Up == null || VSB_Arrow_Up_Press == null)
            {
                VSB_Arrow_Up = ig.LoadImage("Arrow_Up");
                VScrollBar_ArrowUp.Image = VSB_Arrow_Up;
                VSB_Arrow_Up_Press = ig.LoadImage("Arrow_Up_Press");
            }
            if (VSB_Arrow_Down == null || VSB_Arrow_Down_Press == null)
            {
                VSB_Arrow_Down = ig.LoadImage("Arrow_Down");
                VScrollBar_ArrowDown.Image = VSB_Arrow_Down;
                VSB_Arrow_Down_Press = ig.LoadImage("Arrow_Down_Press");
            }
            if (HSB_Arrow_Left == null || HSB_Arrow_Left_Press == null)
            {
                HSB_Arrow_Left = ig.LoadImage("Arrow_Left");
                HScrollBar_ArrowLeft.Image = HSB_Arrow_Left;
                HSB_Arrow_Left_Press = ig.LoadImage("Arrow_Left_Press");
            }
            if (HSB_Arrow_Right == null || HSB_Arrow_Right_Press == null)
            {
                HSB_Arrow_Right = ig.LoadImage("Arrow_Right");
                HScrollBar_ArrowRight.Image = HSB_Arrow_Right;
                HSB_Arrow_Right_Press = ig.LoadImage("Arrow_Right_Press");
            }
            if (Grab == null || Grab2 == null || Grab2_Empty == null || Grab2_Mirrored == null)
            {
                Grab = ig.LoadImage("Grab");
                pictureBox1.Image = Grab;
                Grab2 = ig.LoadImage("Grab2");
                Grab2_Empty = ig.LoadImage("Grab2_Empty");
                Grab2_Mirrored = ig.LoadImage("Grab2_Mirrored");
            }
            if (Check == null || Check2 == null)
            {
                Check = ig.LoadImage("Check");
                Check2 = ig.LoadImage("Check2");
            }
        }
                //  This gives all the data necessary to generate custom icons based
                //  on theme colors.
                //  For more information check the 'ImageGeneration' class.
        public void CreateCustomIcons()
        {
            WarningBox WB = new WarningBox("Generating Icons for theme...\nPlease wait");
            WB.Text = "Generating Icons";
            WB.StartPosition = FormStartPosition.CenterScreen;
            WB.Show();
            WB.BringToFront();

            SettingsStylize SStylize = SettingsStylize.Default;

            VSB_Arrow_Up = null; VSB_Arrow_Up_Press = null;
            VSB_Arrow_Down = null; VSB_Arrow_Down_Press = null;
            HSB_Arrow_Left = null; HSB_Arrow_Left_Press = null;
            HSB_Arrow_Right = null; HSB_Arrow_Right_Press = null;
            Grab = null; Grab2 = null; Grab2_Empty = null;
            Check = null; Check2 = null;
            VScrollBar_ArrowUp.Image = Resource1.Arrow_Up;
            VScrollBar_ArrowDown.Image = Resource1.Arrow_Down;
            HScrollBar_ArrowLeft.Image = Resource1.Arrow_Left;
            HScrollBar_ArrowRight.Image = Resource1.Arrow_Right;

            ig.GenerateImage(Resource_masks.Arrow_Up_Mask,SStylize.Scrollbar_Icon_Background, SStylize.Scrollbar_Icon, "Arrow_Up");
            ig.GenerateImage(Resource_masks.Arrow_Up_Mask,SStylize.Scrollbar_Icon_Tint, SStylize.Scrollbar_Icon, "Arrow_Up_Press");
            ig.GenerateImage(Resource_masks.Arrow_Down_Mask,SStylize.Scrollbar_Icon_Background, SStylize.Scrollbar_Icon, "Arrow_Down");
            ig.GenerateImage(Resource_masks.Arrow_Down_Mask,SStylize.Scrollbar_Icon_Tint, SStylize.Scrollbar_Icon, "Arrow_Down_Press");
            ig.GenerateImage(Resource_masks.Arrow_Left_Mask,SStylize.Scrollbar_Icon_Background, SStylize.Scrollbar_Icon, "Arrow_Left");
            ig.GenerateImage(Resource_masks.Arrow_Left_Mask,SStylize.Scrollbar_Icon_Tint, SStylize.Scrollbar_Icon, "Arrow_Left_Press");
            ig.GenerateImage(Resource_masks.Arrow_Right_Mask,SStylize.Scrollbar_Icon_Background, SStylize.Scrollbar_Icon, "Arrow_Right");
            ig.GenerateImage(Resource_masks.Arrow_Right_Mask,SStylize.Scrollbar_Icon_Tint, SStylize.Scrollbar_Icon, "Arrow_Right_Press");
            ig.GenerateImage(Resource_masks.Grab_Mask,SStylize.Status, SStylize.Scrollbar_Icon, "Grab");
            ig.GenerateImage(Resource_masks.Grab2_Mask,SStylize.Scrollbar_Icon_Background, SStylize.Scrollbar_Icon, "Grab2");
            ig.GenerateImage(Resource_masks.Grab2_Empty_Mask,SStylize.Scrollbar_Icon_Background, SStylize.Scrollbar_Icon, "Grab2_Empty");
            ig.GenerateImage(Resource_masks.Grab2_Mirrored_Mask,SStylize.Scrollbar_Icon_Background, SStylize.Scrollbar_Icon, "Grab2_Mirrored");
            ig.GenerateImage(Resource_masks.Check_Mask,SStylize.Scrollbar_Icon_Background, SStylize.Scrollbar_Icon, "Check");
            ig.GenerateImage(Resource_masks.Check2_Mask,SStylize.Scrollbar_Icon_Background, SStylize.Scrollbar_Icon, "Check2");
            ScrollGraphics();
        }
                //  This timer changes the size of the scrollbar's 'Thumb'.
                //  For more info check the 'CustomScrollbar_Commands' class.
        private void HScrollBarTimer_Tick(object sender, EventArgs e)
        {
            if (Settings1.Default.WordWrap) return;
            CSC.HScrollSelection(richTextBox1.Handle, HScrollBar_Thumb, HScrollBar);

                    //  If user pressing arrows scroll.
            if (HScrollBar_HoldingLeft)
                CSC.HScrollBar_ArrowLeft_Click(sender, e,richTextBox1);
            if (HScrollBar_HoldingRight)
                CSC.HScrollBar_ArrowRight_Click(sender, e,richTextBox1);
        }
                //  This timer changes the size of the scrollbar's 'Thumb'.
                //  For more info check the 'CustomScrollbar_Commands' class.
        private void VScrollBarTimer_Tick(object sender, EventArgs e)
        {
            CSC.ScrollSelection(richTextBox1.Handle, VScrollBar_Thumb, VScrollBar);
            
                    //  If user pressing arrows scroll.
            if (VScrollBar_HoldingUp)
                CSC.VScrollBar_ArrowUp_Click(sender, e, richTextBox1);
            if (VScrollBar_HoldingDown)
                CSC.VScrollBar_ArrowDown_Click(sender, e, richTextBox1);
        }
                //  This enables the user to scroll sideways by holding shift.
        private void richTextBox1_scroll(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Shift) return;

            if (e.Delta > 0)
            {
                CSC.HScrollBar_ArrowLeft_Click(sender, e,richTextBox1);
            }
            else
            {
                CSC.HScrollBar_ArrowRight_Click(sender, e,richTextBox1);
            }
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
            if (Settings1.Default.RightToLeft)
            {
                richTextBox1.RightToLeft = RightToLeft.Yes;
                richTextBox1.SetInnerMargins(0, 0, 5, 0);
            }
            else
            {
                richTextBox1.RightToLeft = RightToLeft.No;
                richTextBox1.SetInnerMargins(5, 0, 0, 0);
            }
            StatusPanel.Visible = Settings1.Default.StatusBar;
            Settings1.Default.FindNextPrev = String.Empty;
            Settings1.Default.MatchCase = false;
            Settings1.Default.Save();
            ScrollGraphics();
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
            System.Reflection.MethodInfo mi = this.GetType().GetMethod(methodname);
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

                if (sfd.ShowDialog() == DialogResult.Cancel) return;

                
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
            if (richTextBox1.SelectionLength <= 0) return;
            try
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

                Process.Start(new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = string.Format("{0}{1}", SearchEngine, richTextBox1.SelectedText),
                });
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
        public void SelectAllFunc()
        {
            CloseContextMenu();
            richTextBox1.Focus();
            completeSelectionStart = 0;
            richTextBox1.SelectAll();
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
            Notepad_Resize(null,null);
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
        public void RightToLeftFunc()
        {
            CloseContextMenu();
            richTextBox1.Focus();

            if (richTextBox1.RightToLeft == RightToLeft.Yes)
            {
                richTextBox1.RightToLeft = RightToLeft.No;
                richTextBox1.SetInnerMargins(5, 0, 0, 0);
                Settings1.Default.RightToLeft = false;
            }
            else
            {
                richTextBox1.RightToLeft = RightToLeft.Yes;
                richTextBox1.SetInnerMargins(0, 0, 5, 0);
                Settings1.Default.RightToLeft = true;
            }
            Settings1.Default.Save();
            ScrollGraphics();
        }
        public void InternetHelp()
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo("https://github.com/000Daniel/Dark-Notepad/blob/main/Documents/Q%26A.md");
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
         ***THIS FEATURE MIGHT NOT WORK AT ALL! IT HAS NOT BEEN TESTED!
         ***(In inches)
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
                //  The 'PagePrint' class is responsible for printing.
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
                //  This is a hidden button that has '&x' set as its text.
                //  This is done so that when the user hits ALT+X the software closes.
        private void button_hidden1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            richTextBox1.Focus();
        }

                //  This creates a context menu when the user rightclicks on the RichTextBox.
        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            bool selectedText = false;
            bool pasteableText = false;
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
            cxm.createButton(sender, e, "Select All", "SelectAllFunc");
            cxm.createPanelLine(sender, e, 4);
            if (richTextBox1.RightToLeft == RightToLeft.Yes)
            {
                cxm.createButton(sender, e, "Right to left Reading order", "RightToLeftFunc", true, true);
            }
            else
            {
                cxm.createButton(sender, e, "Right to left Reading order", "RightToLeftFunc", true, false);
            }
            
            cxm.createPanelLine(sender, e, 4);
            cxm.createButton(sender, e, "Internet Search...", "InternetSearchFunc", selectedText); //InternetHelp()
            cxm.createButton(sender, e, "Internet Help", "InternetHelp");

            cxm.Show();

            int Xpos = Cursor.Position.X;
            int Ypox = Cursor.Position.Y;
            cxm.Location = new Point(Xpos, Ypox);

            id = null;
            cxm = null;
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
            richTextBox1.Focus();
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
            if (!TextModded) return;

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

                //  This method handles custom keybinds/shortcuts.
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
            if (e.KeyCode == Keys.F1)
            {
                InternetHelp();
            }
        }
        
                //  This function handles the custom 'size Grip'.
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (richTextBox1.RightToLeft == RightToLeft.Yes && !Settings1.Default.StatusBar)
            {
                        //  This allows the user to resize from the bottom left grip.
                if (mouseDiffX < 0 || mouseDiffY < 0)
                {
                    mouseDiffX = (this.Location.X) - MousePosition.X;
                    mouseDiffY = (this.Location.Y + this.Size.Height) - MousePosition.Y;
                }

                Win32_Calls.MoveWindow(this.Handle,
                    MousePosition.X - mouseDiffX, this.Top,
                    this.Width + (int)((this.Left - MousePosition.X) + mouseDiffX), MousePosition.Y - this.Location.Y + mouseDiffY,
                    true);
            }
            else
            {
                        //  This allows the user to resize from the bottom right grip.
                if (mouseDiffX < 0 || mouseDiffY < 0)
                {
                    mouseDiffX = (this.Location.X + this.Size.Width) - MousePosition.X;
                    mouseDiffY = (this.Location.Y + this.Size.Height) - MousePosition.Y;
                }
                this.Size = new Size(MousePosition.X - this.Location.X + mouseDiffX, MousePosition.Y - this.Location.Y + mouseDiffY); //+15
            }
            this.Update();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDiffX = -1;
            mouseDiffY = -1;
        }
        private void ScrollBars_Grip_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1_MouseUp(sender, e);
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
            StatusPanel.BackColor = SStylize.Status;
            StatusInnerPanel.BackColor = SStylize.Status;
            StatusInnerPanel2.BackColor = SStylize.Status;
            StatusInnerPanel3.BackColor = SStylize.Status;
            panel3.BackColor = SStylize.Status_Splitter;
            panel5.BackColor = SStylize.Status_Splitter;
            panel6.BackColor = SStylize.Status_Splitter;
            statusLabel1.BackColor = SStylize.Status;
            statusLabel1.ForeColor = SStylize.Status_Text;
            statusLabel2.BackColor = SStylize.Status;
            statusLabel2.ForeColor = SStylize.Status_Text;
            statusLabel3.BackColor = SStylize.Status;
            statusLabel3.ForeColor = SStylize.Status_Text;
            HScrollBar.BackColor = SStylize.Scrollbar_Tint;
            HScrollBar_Thumb.BackColor = SStylize.Scrollbar;
            VScrollBar.BackColor = SStylize.Scrollbar_Tint;
            VScrollBar_Thumb.BackColor = SStylize.Scrollbar;
            VScrollBar_ArrowUp.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar_ArrowUp.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar_ArrowUp.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
            VScrollBar_ArrowDown.BackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar_ArrowDown.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            VScrollBar_ArrowDown.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
            HScrollBar_ArrowLeft.BackColor = SStylize.Scrollbar_Icon_Background;
            HScrollBar_ArrowLeft.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            HScrollBar_ArrowLeft.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
            HScrollBar_ArrowRight.BackColor = SStylize.Scrollbar_Icon_Background;
            HScrollBar_ArrowRight.FlatAppearance.MouseOverBackColor = SStylize.Scrollbar_Icon_Background;
            HScrollBar_ArrowRight.FlatAppearance.MouseDownBackColor = SStylize.Scrollbar_Icon_Tint;
        }
    }
}
//This software was created by 000Daniel on Github.
//      https://github.com/000Daniel
