
namespace DarkNotepad
{
    partial class Notepad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notepad));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatusInnerPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusLabel1 = new System.Windows.Forms.Label();
            this.StatusInnerPanel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.statusLabel2 = new System.Windows.Forms.Label();
            this.StatusInnerPanel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.statusLabel3 = new System.Windows.Forms.Label();
            this.CollectGarbage = new System.Windows.Forms.Timer(this.components);
            this.CaretChange = new System.Windows.Forms.Timer(this.components);
            this.HScrollBar = new System.Windows.Forms.Panel();
            this.HScrollBar_Thumb = new System.Windows.Forms.Panel();
            this.HScrollBarTimer = new System.Windows.Forms.Timer(this.components);
            this.VScrollBarTimer = new System.Windows.Forms.Timer(this.components);
            this.VScrollBar = new System.Windows.Forms.Panel();
            this.VScrollBar_Thumb = new System.Windows.Forms.Panel();
            this.VScrollBar_ArrowUp = new System.Windows.Forms.Button();
            this.VScrollBar_ArrowDown = new System.Windows.Forms.Button();
            this.HScrollBar_ArrowRight = new System.Windows.Forms.Button();
            this.HScrollBar_ArrowLeft = new System.Windows.Forms.Button();
            this.ScrollBars_Grip = new System.Windows.Forms.PictureBox();
            this.button_hidden1 = new System.Windows.Forms.Button();
            this.StatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.StatusInnerPanel.SuspendLayout();
            this.StatusInnerPanel2.SuspendLayout();
            this.StatusInnerPanel3.SuspendLayout();
            this.HScrollBar.SuspendLayout();
            this.VScrollBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollBars_Grip)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Location = new System.Drawing.Point(0, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 2);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "&File";
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(40, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 21);
            this.button2.TabIndex = 2;
            this.button2.Text = "&Edit";
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(80, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 21);
            this.button3.TabIndex = 3;
            this.button3.Text = "F&ormat";
            this.button3.UseCompatibleTextRendering = true;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(140, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(45, 21);
            this.button4.TabIndex = 4;
            this.button4.Text = "&View";
            this.button4.UseCompatibleTextRendering = true;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.MouseEnter += new System.EventHandler(this.button4_MouseEnter);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(185, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 21);
            this.button5.TabIndex = 5;
            this.button5.Text = "&Help";
            this.button5.UseCompatibleTextRendering = true;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(0, 23);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(816, 439);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Notepad_DragDrop);
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            this.richTextBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
            // 
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.StatusPanel.Controls.Add(this.pictureBox1);
            this.StatusPanel.Controls.Add(this.StatusInnerPanel);
            this.StatusPanel.Controls.Add(this.StatusInnerPanel2);
            this.StatusPanel.Controls.Add(this.StatusInnerPanel3);
            this.StatusPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.StatusPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.StatusPanel.Location = new System.Drawing.Point(0, 519);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(1000, 22);
            this.StatusPanel.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pictureBox1.Image = global::DarkNotepad.Resource1.Grab;
            this.pictureBox1.Location = new System.Drawing.Point(970, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(14, 20);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // StatusInnerPanel
            // 
            this.StatusInnerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.StatusInnerPanel.Controls.Add(this.panel3);
            this.StatusInnerPanel.Controls.Add(this.statusLabel1);
            this.StatusInnerPanel.Location = new System.Drawing.Point(864, 0);
            this.StatusInnerPanel.Name = "StatusInnerPanel";
            this.StatusInnerPanel.Size = new System.Drawing.Size(106, 22);
            this.StatusInnerPanel.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 22);
            this.panel3.TabIndex = 1;
            // 
            // statusLabel1
            // 
            this.statusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.statusLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel1.ForeColor = System.Drawing.SystemColors.Control;
            this.statusLabel1.Location = new System.Drawing.Point(10, 3);
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(100, 14);
            this.statusLabel1.TabIndex = 0;
            this.statusLabel1.Text = "100%";
            // 
            // StatusInnerPanel2
            // 
            this.StatusInnerPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.StatusInnerPanel2.Controls.Add(this.panel5);
            this.StatusInnerPanel2.Controls.Add(this.statusLabel2);
            this.StatusInnerPanel2.Location = new System.Drawing.Point(758, 0);
            this.StatusInnerPanel2.Name = "StatusInnerPanel2";
            this.StatusInnerPanel2.Size = new System.Drawing.Size(106, 22);
            this.StatusInnerPanel2.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 22);
            this.panel5.TabIndex = 1;
            // 
            // statusLabel2
            // 
            this.statusLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.statusLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel2.ForeColor = System.Drawing.SystemColors.Control;
            this.statusLabel2.Location = new System.Drawing.Point(10, 3);
            this.statusLabel2.Name = "statusLabel2";
            this.statusLabel2.Size = new System.Drawing.Size(100, 14);
            this.statusLabel2.TabIndex = 0;
            this.statusLabel2.Text = "Ln 1,Col 1";
            // 
            // StatusInnerPanel3
            // 
            this.StatusInnerPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.StatusInnerPanel3.Controls.Add(this.panel6);
            this.StatusInnerPanel3.Controls.Add(this.statusLabel3);
            this.StatusInnerPanel3.Location = new System.Drawing.Point(652, 0);
            this.StatusInnerPanel3.Name = "StatusInnerPanel3";
            this.StatusInnerPanel3.Size = new System.Drawing.Size(106, 22);
            this.StatusInnerPanel3.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(2, 22);
            this.panel6.TabIndex = 1;
            // 
            // statusLabel3
            // 
            this.statusLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.statusLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.statusLabel3.ForeColor = System.Drawing.SystemColors.Control;
            this.statusLabel3.Location = new System.Drawing.Point(10, 3);
            this.statusLabel3.Name = "statusLabel3";
            this.statusLabel3.Size = new System.Drawing.Size(100, 14);
            this.statusLabel3.TabIndex = 0;
            this.statusLabel3.Text = "Ln 1,Col 1";
            // 
            // CollectGarbage
            // 
            this.CollectGarbage.Enabled = true;
            this.CollectGarbage.Interval = 10000;
            this.CollectGarbage.Tick += new System.EventHandler(this.CollectGarbage_Tick);
            // 
            // CaretChange
            // 
            this.CaretChange.Interval = 10;
            this.CaretChange.Tick += new System.EventHandler(this.CaretChange_Tick);
            // 
            // HScrollBar
            // 
            this.HScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.HScrollBar.Controls.Add(this.HScrollBar_Thumb);
            this.HScrollBar.Enabled = false;
            this.HScrollBar.Location = new System.Drawing.Point(65, 450);
            this.HScrollBar.Name = "HScrollBar";
            this.HScrollBar.Size = new System.Drawing.Size(649, 12);
            this.HScrollBar.TabIndex = 8;
            // 
            // HScrollBar_Thumb
            // 
            this.HScrollBar_Thumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HScrollBar_Thumb.Location = new System.Drawing.Point(70, 0);
            this.HScrollBar_Thumb.Name = "HScrollBar_Thumb";
            this.HScrollBar_Thumb.Size = new System.Drawing.Size(529, 12);
            this.HScrollBar_Thumb.TabIndex = 9;
            // 
            // HScrollBarTimer
            // 
            this.HScrollBarTimer.Enabled = true;
            this.HScrollBarTimer.Interval = 10;
            this.HScrollBarTimer.Tick += new System.EventHandler(this.HScrollBarTimer_Tick);
            // 
            // VScrollBarTimer
            // 
            this.VScrollBarTimer.Enabled = true;
            this.VScrollBarTimer.Interval = 10;
            this.VScrollBarTimer.Tick += new System.EventHandler(this.VScrollBarTimer_Tick);
            // 
            // VScrollBar
            // 
            this.VScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.VScrollBar.Controls.Add(this.VScrollBar_Thumb);
            this.VScrollBar.Enabled = false;
            this.VScrollBar.Location = new System.Drawing.Point(804, 45);
            this.VScrollBar.Name = "VScrollBar";
            this.VScrollBar.Size = new System.Drawing.Size(12, 360);
            this.VScrollBar.TabIndex = 10;
            // 
            // VScrollBar_Thumb
            // 
            this.VScrollBar_Thumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.VScrollBar_Thumb.Location = new System.Drawing.Point(0, 36);
            this.VScrollBar_Thumb.Name = "VScrollBar_Thumb";
            this.VScrollBar_Thumb.Size = new System.Drawing.Size(12, 278);
            this.VScrollBar_Thumb.TabIndex = 9;
            // 
            // VScrollBar_ArrowUp
            // 
            this.VScrollBar_ArrowUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VScrollBar_ArrowUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.VScrollBar_ArrowUp.FlatAppearance.BorderSize = 0;
            this.VScrollBar_ArrowUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VScrollBar_ArrowUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollBar_ArrowUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VScrollBar_ArrowUp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VScrollBar_ArrowUp.Image = global::DarkNotepad.Resource1.Arrow_Up;
            this.VScrollBar_ArrowUp.Location = new System.Drawing.Point(779, 25);
            this.VScrollBar_ArrowUp.Name = "VScrollBar_ArrowUp";
            this.VScrollBar_ArrowUp.Size = new System.Drawing.Size(17, 17);
            this.VScrollBar_ArrowUp.TabIndex = 11;
            this.VScrollBar_ArrowUp.UseCompatibleTextRendering = true;
            this.VScrollBar_ArrowUp.UseVisualStyleBackColor = false;
            // 
            // VScrollBar_ArrowDown
            // 
            this.VScrollBar_ArrowDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VScrollBar_ArrowDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.VScrollBar_ArrowDown.FlatAppearance.BorderSize = 0;
            this.VScrollBar_ArrowDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VScrollBar_ArrowDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollBar_ArrowDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VScrollBar_ArrowDown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VScrollBar_ArrowDown.Image = ((System.Drawing.Image)(resources.GetObject("VScrollBar_ArrowDown.Image")));
            this.VScrollBar_ArrowDown.Location = new System.Drawing.Point(779, 60);
            this.VScrollBar_ArrowDown.Name = "VScrollBar_ArrowDown";
            this.VScrollBar_ArrowDown.Size = new System.Drawing.Size(17, 17);
            this.VScrollBar_ArrowDown.TabIndex = 12;
            this.VScrollBar_ArrowDown.UseCompatibleTextRendering = true;
            this.VScrollBar_ArrowDown.UseVisualStyleBackColor = false;
            // 
            // HScrollBar_ArrowRight
            // 
            this.HScrollBar_ArrowRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HScrollBar_ArrowRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HScrollBar_ArrowRight.FlatAppearance.BorderSize = 0;
            this.HScrollBar_ArrowRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.HScrollBar_ArrowRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HScrollBar_ArrowRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HScrollBar_ArrowRight.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HScrollBar_ArrowRight.Image = ((System.Drawing.Image)(resources.GetObject("HScrollBar_ArrowRight.Image")));
            this.HScrollBar_ArrowRight.Location = new System.Drawing.Point(50, 426);
            this.HScrollBar_ArrowRight.Name = "HScrollBar_ArrowRight";
            this.HScrollBar_ArrowRight.Size = new System.Drawing.Size(17, 17);
            this.HScrollBar_ArrowRight.TabIndex = 14;
            this.HScrollBar_ArrowRight.UseCompatibleTextRendering = true;
            this.HScrollBar_ArrowRight.UseVisualStyleBackColor = false;
            // 
            // HScrollBar_ArrowLeft
            // 
            this.HScrollBar_ArrowLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.HScrollBar_ArrowLeft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.HScrollBar_ArrowLeft.FlatAppearance.BorderSize = 0;
            this.HScrollBar_ArrowLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.HScrollBar_ArrowLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HScrollBar_ArrowLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HScrollBar_ArrowLeft.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HScrollBar_ArrowLeft.Image = ((System.Drawing.Image)(resources.GetObject("HScrollBar_ArrowLeft.Image")));
            this.HScrollBar_ArrowLeft.Location = new System.Drawing.Point(11, 426);
            this.HScrollBar_ArrowLeft.Name = "HScrollBar_ArrowLeft";
            this.HScrollBar_ArrowLeft.Size = new System.Drawing.Size(17, 17);
            this.HScrollBar_ArrowLeft.TabIndex = 13;
            this.HScrollBar_ArrowLeft.UseCompatibleTextRendering = true;
            this.HScrollBar_ArrowLeft.UseVisualStyleBackColor = false;
            // 
            // ScrollBars_Grip
            // 
            this.ScrollBars_Grip.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ScrollBars_Grip.Image = global::DarkNotepad.Resource1.Grab2;
            this.ScrollBars_Grip.Location = new System.Drawing.Point(768, 412);
            this.ScrollBars_Grip.Name = "ScrollBars_Grip";
            this.ScrollBars_Grip.Size = new System.Drawing.Size(17, 17);
            this.ScrollBars_Grip.TabIndex = 15;
            this.ScrollBars_Grip.TabStop = false;
            this.ScrollBars_Grip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.ScrollBars_Grip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScrollBars_Grip_MouseUp);
            // 
            // button_hidden1
            // 
            this.button_hidden1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button_hidden1.FlatAppearance.BorderSize = 0;
            this.button_hidden1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.button_hidden1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.button_hidden1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_hidden1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_hidden1.Location = new System.Drawing.Point(-64, -64);
            this.button_hidden1.Name = "button_hidden1";
            this.button_hidden1.Size = new System.Drawing.Size(40, 21);
            this.button_hidden1.TabIndex = 16;
            this.button_hidden1.Text = "&x";
            this.button_hidden1.UseCompatibleTextRendering = true;
            this.button_hidden1.UseVisualStyleBackColor = true;
            this.button_hidden1.Click += new System.EventHandler(this.button_hidden1_Click);
            // 
            // Notepad
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(984, 541);
            this.Controls.Add(this.button_hidden1);
            this.Controls.Add(this.HScrollBar_ArrowRight);
            this.Controls.Add(this.HScrollBar_ArrowLeft);
            this.Controls.Add(this.VScrollBar_ArrowDown);
            this.Controls.Add(this.VScrollBar_ArrowUp);
            this.Controls.Add(this.ScrollBars_Grip);
            this.Controls.Add(this.VScrollBar);
            this.Controls.Add(this.HScrollBar);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Notepad";
            this.Text = "Notepad";
            this.Activated += new System.EventHandler(this.Notepad_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notepad_FormClosing);
            this.Load += new System.EventHandler(this.Notepad_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Notepad_DragDrop);
            this.Resize += new System.EventHandler(this.Notepad_Resize);
            this.StatusPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.StatusInnerPanel.ResumeLayout(false);
            this.StatusInnerPanel2.ResumeLayout(false);
            this.StatusInnerPanel3.ResumeLayout(false);
            this.HScrollBar.ResumeLayout(false);
            this.VScrollBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScrollBars_Grip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel StatusPanel;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer CollectGarbage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel StatusInnerPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label statusLabel1;
        private System.Windows.Forms.Panel StatusInnerPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label statusLabel2;
        private System.Windows.Forms.Timer CaretChange;
        private System.Windows.Forms.Panel StatusInnerPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label statusLabel3;
        private System.Windows.Forms.Panel HScrollBar;
        private System.Windows.Forms.Panel HScrollBar_Thumb;
        private System.Windows.Forms.Timer HScrollBarTimer;
        private System.Windows.Forms.Timer VScrollBarTimer;
        private System.Windows.Forms.Panel VScrollBar;
        private System.Windows.Forms.Panel VScrollBar_Thumb;
        private System.Windows.Forms.PictureBox ScrollBars_Grip;
        public System.Windows.Forms.Button VScrollBar_ArrowUp;
        public System.Windows.Forms.Button VScrollBar_ArrowDown;
        public System.Windows.Forms.Button HScrollBar_ArrowRight;
        public System.Windows.Forms.Button HScrollBar_ArrowLeft;
        private System.Windows.Forms.Button button_hidden1;
    }
}

