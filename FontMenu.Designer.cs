namespace DarkNotepad
{
    partial class FontMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontMenu));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FontFinder = new System.Windows.Forms.Timer(this.components);
            this.FontFinder2 = new System.Windows.Forms.Timer(this.components);
            this.FontFinder3 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.FontStyleFinder = new System.Windows.Forms.Timer(this.components);
            this.preview_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Sample_Text_Panel = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SelectionMenu1 = new System.Windows.Forms.Panel();
            this.VScrollbar1 = new System.Windows.Forms.Panel();
            this.VScrollbar1_Thumb = new System.Windows.Forms.Panel();
            this.SelectionMenu2 = new System.Windows.Forms.Panel();
            this.SelectionMenu3 = new System.Windows.Forms.Panel();
            this.VScrollbar_Timer = new System.Windows.Forms.Timer(this.components);
            this.VScrollbar2 = new System.Windows.Forms.Panel();
            this.VScrollbar2_Thumb = new System.Windows.Forms.Panel();
            this.VScrollbar3 = new System.Windows.Forms.Panel();
            this.VScrollbar3_Thumb = new System.Windows.Forms.Panel();
            this.VScrollBar1_ArrowDown = new System.Windows.Forms.Button();
            this.VScrollBar1_ArrowUp = new System.Windows.Forms.Button();
            this.VScrollBar2_ArrowDown = new System.Windows.Forms.Button();
            this.VScrollBar2_ArrowUp = new System.Windows.Forms.Button();
            this.VScrollBar3_ArrowDown = new System.Windows.Forms.Button();
            this.VScrollBar3_ArrowUp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Sample_Text_Panel.SuspendLayout();
            this.VScrollbar1.SuspendLayout();
            this.VScrollbar2.SuspendLayout();
            this.VScrollbar3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(12, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 21);
            this.textBox1.TabIndex = 14;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Font:";
            // 
            // FontFinder
            // 
            this.FontFinder.Enabled = true;
            this.FontFinder.Interval = 10;
            this.FontFinder.Tick += new System.EventHandler(this.FontFinder_Tick);
            // 
            // FontFinder2
            // 
            this.FontFinder2.Enabled = true;
            this.FontFinder2.Interval = 10;
            this.FontFinder2.Tick += new System.EventHandler(this.FontFinder2_Tick);
            // 
            // FontFinder3
            // 
            this.FontFinder3.Enabled = true;
            this.FontFinder3.Interval = 10;
            this.FontFinder3.Tick += new System.EventHandler(this.FontFinder3_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(272, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Font style:";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(272, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(234, 21);
            this.textBox2.TabIndex = 18;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // FontStyleFinder
            // 
            this.FontStyleFinder.Interval = 10;
            this.FontStyleFinder.Tick += new System.EventHandler(this.FontStyleFinder_Tick);
            // 
            // preview_label
            // 
            this.preview_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.preview_label.AutoEllipsis = true;
            this.preview_label.AutoSize = true;
            this.preview_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preview_label.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.preview_label.Location = new System.Drawing.Point(135, 36);
            this.preview_label.Name = "preview_label";
            this.preview_label.Size = new System.Drawing.Size(63, 18);
            this.preview_label.TabIndex = 21;
            this.preview_label.Text = "AaBbYyZz";
            this.preview_label.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.preview_label.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(532, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Font size:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(532, 37);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(67, 21);
            this.textBox3.TabIndex = 22;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(508, 368);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 26);
            this.button2.TabIndex = 26;
            this.button2.Text = "Cancel";
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(408, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 26);
            this.button1.TabIndex = 25;
            this.button1.Text = "Okay";
            this.button1.UseCompatibleTextRendering = true;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox1.Controls.Add(this.Sample_Text_Panel);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(249, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 100);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sample";
            // 
            // Sample_Text_Panel
            // 
            this.Sample_Text_Panel.Controls.Add(this.preview_label);
            this.Sample_Text_Panel.Location = new System.Drawing.Point(5, 15);
            this.Sample_Text_Panel.Name = "Sample_Text_Panel";
            this.Sample_Text_Panel.Size = new System.Drawing.Size(340, 80);
            this.Sample_Text_Panel.TabIndex = 28;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(50)))), ((int)(((byte)(205)))));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.linkLabel1.Location = new System.Drawing.Point(12, 335);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 15);
            this.linkLabel1.TabIndex = 28;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Show more fonts";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(160)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // SelectionMenu1
            // 
            this.SelectionMenu1.AutoScroll = true;
            this.SelectionMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SelectionMenu1.Location = new System.Drawing.Point(12, 58);
            this.SelectionMenu1.Name = "SelectionMenu1";
            this.SelectionMenu1.Size = new System.Drawing.Size(234, 176);
            this.SelectionMenu1.TabIndex = 29;
            // 
            // VScrollbar1
            // 
            this.VScrollbar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.VScrollbar1.Controls.Add(this.VScrollbar1_Thumb);
            this.VScrollbar1.Enabled = false;
            this.VScrollbar1.Location = new System.Drawing.Point(214, 6);
            this.VScrollbar1.Name = "VScrollbar1";
            this.VScrollbar1.Size = new System.Drawing.Size(17, 167);
            this.VScrollbar1.TabIndex = 0;
            // 
            // VScrollbar1_Thumb
            // 
            this.VScrollbar1_Thumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollbar1_Thumb.Location = new System.Drawing.Point(3, 27);
            this.VScrollbar1_Thumb.Name = "VScrollbar1_Thumb";
            this.VScrollbar1_Thumb.Size = new System.Drawing.Size(10, 100);
            this.VScrollbar1_Thumb.TabIndex = 1;
            // 
            // SelectionMenu2
            // 
            this.SelectionMenu2.AutoScroll = true;
            this.SelectionMenu2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SelectionMenu2.Location = new System.Drawing.Point(272, 58);
            this.SelectionMenu2.Name = "SelectionMenu2";
            this.SelectionMenu2.Size = new System.Drawing.Size(234, 176);
            this.SelectionMenu2.TabIndex = 30;
            // 
            // SelectionMenu3
            // 
            this.SelectionMenu3.AutoScroll = true;
            this.SelectionMenu3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SelectionMenu3.Location = new System.Drawing.Point(532, 58);
            this.SelectionMenu3.Name = "SelectionMenu3";
            this.SelectionMenu3.Size = new System.Drawing.Size(67, 176);
            this.SelectionMenu3.TabIndex = 31;
            // 
            // VScrollbar_Timer
            // 
            this.VScrollbar_Timer.Enabled = true;
            this.VScrollbar_Timer.Interval = 10;
            this.VScrollbar_Timer.Tick += new System.EventHandler(this.VScrollbar_Timer_Tick);
            // 
            // VScrollbar2
            // 
            this.VScrollbar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.VScrollbar2.Controls.Add(this.VScrollbar2_Thumb);
            this.VScrollbar2.Enabled = false;
            this.VScrollbar2.Location = new System.Drawing.Point(469, 12);
            this.VScrollbar2.Name = "VScrollbar2";
            this.VScrollbar2.Size = new System.Drawing.Size(17, 167);
            this.VScrollbar2.TabIndex = 2;
            // 
            // VScrollbar2_Thumb
            // 
            this.VScrollbar2_Thumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollbar2_Thumb.Location = new System.Drawing.Point(3, 27);
            this.VScrollbar2_Thumb.Name = "VScrollbar2_Thumb";
            this.VScrollbar2_Thumb.Size = new System.Drawing.Size(10, 100);
            this.VScrollbar2_Thumb.TabIndex = 1;
            // 
            // VScrollbar3
            // 
            this.VScrollbar3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.VScrollbar3.Controls.Add(this.VScrollbar3_Thumb);
            this.VScrollbar3.Enabled = false;
            this.VScrollbar3.Location = new System.Drawing.Point(590, 12);
            this.VScrollbar3.Name = "VScrollbar3";
            this.VScrollbar3.Size = new System.Drawing.Size(17, 167);
            this.VScrollbar3.TabIndex = 3;
            // 
            // VScrollbar3_Thumb
            // 
            this.VScrollbar3_Thumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollbar3_Thumb.Location = new System.Drawing.Point(3, 27);
            this.VScrollbar3_Thumb.Name = "VScrollbar3_Thumb";
            this.VScrollbar3_Thumb.Size = new System.Drawing.Size(10, 100);
            this.VScrollbar3_Thumb.TabIndex = 1;
            // 
            // VScrollBar1_ArrowDown
            // 
            this.VScrollBar1_ArrowDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VScrollBar1_ArrowDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.VScrollBar1_ArrowDown.FlatAppearance.BorderSize = 0;
            this.VScrollBar1_ArrowDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VScrollBar1_ArrowDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollBar1_ArrowDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VScrollBar1_ArrowDown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VScrollBar1_ArrowDown.Image = ((System.Drawing.Image)(resources.GetObject("VScrollBar1_ArrowDown.Image")));
            this.VScrollBar1_ArrowDown.Location = new System.Drawing.Point(168, 6);
            this.VScrollBar1_ArrowDown.Name = "VScrollBar1_ArrowDown";
            this.VScrollBar1_ArrowDown.Size = new System.Drawing.Size(17, 17);
            this.VScrollBar1_ArrowDown.TabIndex = 14;
            this.VScrollBar1_ArrowDown.UseCompatibleTextRendering = true;
            this.VScrollBar1_ArrowDown.UseVisualStyleBackColor = false;
            // 
            // VScrollBar1_ArrowUp
            // 
            this.VScrollBar1_ArrowUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VScrollBar1_ArrowUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.VScrollBar1_ArrowUp.FlatAppearance.BorderSize = 0;
            this.VScrollBar1_ArrowUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VScrollBar1_ArrowUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollBar1_ArrowUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VScrollBar1_ArrowUp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VScrollBar1_ArrowUp.Image = global::DarkNotepad.Resource1.Arrow_Up;
            this.VScrollBar1_ArrowUp.Location = new System.Drawing.Point(191, 6);
            this.VScrollBar1_ArrowUp.Name = "VScrollBar1_ArrowUp";
            this.VScrollBar1_ArrowUp.Size = new System.Drawing.Size(17, 17);
            this.VScrollBar1_ArrowUp.TabIndex = 13;
            this.VScrollBar1_ArrowUp.UseCompatibleTextRendering = true;
            this.VScrollBar1_ArrowUp.UseVisualStyleBackColor = false;
            // 
            // VScrollBar2_ArrowDown
            // 
            this.VScrollBar2_ArrowDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VScrollBar2_ArrowDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.VScrollBar2_ArrowDown.FlatAppearance.BorderSize = 0;
            this.VScrollBar2_ArrowDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VScrollBar2_ArrowDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollBar2_ArrowDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VScrollBar2_ArrowDown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VScrollBar2_ArrowDown.Image = ((System.Drawing.Image)(resources.GetObject("VScrollBar2_ArrowDown.Image")));
            this.VScrollBar2_ArrowDown.Location = new System.Drawing.Point(423, 6);
            this.VScrollBar2_ArrowDown.Name = "VScrollBar2_ArrowDown";
            this.VScrollBar2_ArrowDown.Size = new System.Drawing.Size(17, 17);
            this.VScrollBar2_ArrowDown.TabIndex = 33;
            this.VScrollBar2_ArrowDown.UseCompatibleTextRendering = true;
            this.VScrollBar2_ArrowDown.UseVisualStyleBackColor = false;
            // 
            // VScrollBar2_ArrowUp
            // 
            this.VScrollBar2_ArrowUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VScrollBar2_ArrowUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.VScrollBar2_ArrowUp.FlatAppearance.BorderSize = 0;
            this.VScrollBar2_ArrowUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VScrollBar2_ArrowUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollBar2_ArrowUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VScrollBar2_ArrowUp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VScrollBar2_ArrowUp.Image = global::DarkNotepad.Resource1.Arrow_Up;
            this.VScrollBar2_ArrowUp.Location = new System.Drawing.Point(446, 6);
            this.VScrollBar2_ArrowUp.Name = "VScrollBar2_ArrowUp";
            this.VScrollBar2_ArrowUp.Size = new System.Drawing.Size(17, 17);
            this.VScrollBar2_ArrowUp.TabIndex = 32;
            this.VScrollBar2_ArrowUp.UseCompatibleTextRendering = true;
            this.VScrollBar2_ArrowUp.UseVisualStyleBackColor = false;
            // 
            // VScrollBar3_ArrowDown
            // 
            this.VScrollBar3_ArrowDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VScrollBar3_ArrowDown.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.VScrollBar3_ArrowDown.FlatAppearance.BorderSize = 0;
            this.VScrollBar3_ArrowDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VScrollBar3_ArrowDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollBar3_ArrowDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VScrollBar3_ArrowDown.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VScrollBar3_ArrowDown.Image = ((System.Drawing.Image)(resources.GetObject("VScrollBar3_ArrowDown.Image")));
            this.VScrollBar3_ArrowDown.Location = new System.Drawing.Point(544, 6);
            this.VScrollBar3_ArrowDown.Name = "VScrollBar3_ArrowDown";
            this.VScrollBar3_ArrowDown.Size = new System.Drawing.Size(17, 17);
            this.VScrollBar3_ArrowDown.TabIndex = 35;
            this.VScrollBar3_ArrowDown.UseCompatibleTextRendering = true;
            this.VScrollBar3_ArrowDown.UseVisualStyleBackColor = false;
            // 
            // VScrollBar3_ArrowUp
            // 
            this.VScrollBar3_ArrowUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VScrollBar3_ArrowUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.VScrollBar3_ArrowUp.FlatAppearance.BorderSize = 0;
            this.VScrollBar3_ArrowUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.VScrollBar3_ArrowUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.VScrollBar3_ArrowUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VScrollBar3_ArrowUp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VScrollBar3_ArrowUp.Image = global::DarkNotepad.Resource1.Arrow_Up;
            this.VScrollBar3_ArrowUp.Location = new System.Drawing.Point(567, 6);
            this.VScrollBar3_ArrowUp.Name = "VScrollBar3_ArrowUp";
            this.VScrollBar3_ArrowUp.Size = new System.Drawing.Size(17, 17);
            this.VScrollBar3_ArrowUp.TabIndex = 34;
            this.VScrollBar3_ArrowUp.UseCompatibleTextRendering = true;
            this.VScrollBar3_ArrowUp.UseVisualStyleBackColor = false;
            // 
            // FontMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(615, 406);
            this.Controls.Add(this.VScrollBar3_ArrowDown);
            this.Controls.Add(this.VScrollBar3_ArrowUp);
            this.Controls.Add(this.VScrollBar2_ArrowDown);
            this.Controls.Add(this.VScrollBar2_ArrowUp);
            this.Controls.Add(this.VScrollBar1_ArrowDown);
            this.Controls.Add(this.VScrollbar3);
            this.Controls.Add(this.VScrollBar1_ArrowUp);
            this.Controls.Add(this.VScrollbar2);
            this.Controls.Add(this.VScrollbar1);
            this.Controls.Add(this.SelectionMenu3);
            this.Controls.Add(this.SelectionMenu2);
            this.Controls.Add(this.SelectionMenu1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Font";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FontMenu_FormClosing);
            this.Load += new System.EventHandler(this.FontMenu_Load);
            this.groupBox1.ResumeLayout(false);
            this.Sample_Text_Panel.ResumeLayout(false);
            this.Sample_Text_Panel.PerformLayout();
            this.VScrollbar1.ResumeLayout(false);
            this.VScrollbar2.ResumeLayout(false);
            this.VScrollbar3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer FontFinder;
        private System.Windows.Forms.Timer FontFinder2;
        private System.Windows.Forms.Timer FontFinder3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer FontStyleFinder;
        private System.Windows.Forms.Label preview_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel Sample_Text_Panel;
        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.Panel SelectionMenu1;
        public System.Windows.Forms.Panel SelectionMenu2;
        public System.Windows.Forms.Panel SelectionMenu3;
        private System.Windows.Forms.Timer VScrollbar_Timer;
        public System.Windows.Forms.Panel VScrollbar1;
        public System.Windows.Forms.Panel VScrollbar1_Thumb;
        public System.Windows.Forms.Panel VScrollbar2;
        public System.Windows.Forms.Panel VScrollbar2_Thumb;
        public System.Windows.Forms.Panel VScrollbar3;
        public System.Windows.Forms.Panel VScrollbar3_Thumb;
        public System.Windows.Forms.Button VScrollBar1_ArrowDown;
        public System.Windows.Forms.Button VScrollBar1_ArrowUp;
        public System.Windows.Forms.Button VScrollBar2_ArrowDown;
        public System.Windows.Forms.Button VScrollBar2_ArrowUp;
        public System.Windows.Forms.Button VScrollBar3_ArrowDown;
        public System.Windows.Forms.Button VScrollBar3_ArrowUp;
    }
}