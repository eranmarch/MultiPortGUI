using System;

namespace MultiPortBreakDown
{
    partial class MultiPortBreakDown
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
            this.PathToFile = new System.Windows.Forms.Label();
            this.PortNameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CommentText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TypeOpts = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.MemorySizeText = new System.Windows.Forms.TextBox();
            this.DataSizeBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RelativeAddressCheckBox = new System.Windows.Forms.CheckBox();
            this.EmergencyCheckBox = new System.Windows.Forms.CheckBox();
            this.DebugCheckBox = new System.Windows.Forms.CheckBox();
            this.ValidCheckBox = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.BankBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.InsertButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.R_WCombo = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ErrorMessage = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearButton = new System.Windows.Forms.Button();
            this.UnCommentButton = new System.Windows.Forms.Button();
            this.CommentButton = new System.Windows.Forms.Button();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathToFile
            // 
            this.PathToFile.AutoSize = true;
            this.PathToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathToFile.Location = new System.Drawing.Point(28, 13);
            this.PathToFile.Name = "PathToFile";
            this.PathToFile.Size = new System.Drawing.Size(92, 20);
            this.PathToFile.TabIndex = 0;
            this.PathToFile.Text = "Path to file: ";
            // 
            // PortNameText
            // 
            this.PortNameText.Location = new System.Drawing.Point(115, 13);
            this.PortNameText.Name = "PortNameText";
            this.PortNameText.Size = new System.Drawing.Size(150, 20);
            this.PortNameText.TabIndex = 8;
            this.PortNameText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PortNameText_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Comment";
            // 
            // CommentText
            // 
            this.CommentText.Location = new System.Drawing.Point(115, 45);
            this.CommentText.Name = "CommentText";
            this.CommentText.Size = new System.Drawing.Size(150, 20);
            this.CommentText.TabIndex = 23;
            this.CommentText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommentText_KeyUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 294);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1074, 265);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.DataGridView1_SelectionChanged);
            // 
            // TypeOpts
            // 
            this.TypeOpts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeOpts.FormattingEnabled = true;
            this.TypeOpts.Items.AddRange(new object[] {
            "SLOW",
            "RANDOM",
            "SEQUENTIAL",
            "SPRINT",
            "MANAGER"});
            this.TypeOpts.Location = new System.Drawing.Point(101, 13);
            this.TypeOpts.Name = "TypeOpts";
            this.TypeOpts.Size = new System.Drawing.Size(77, 21);
            this.TypeOpts.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Port type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "R_W";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Relative address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(221, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Emergency enable";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(220, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "Priority";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(331, 46);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown1.TabIndex = 36;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(35, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 41;
            this.label10.Text = "Search";
            // 
            // searchBox
            // 
            this.searchBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.searchBox.Location = new System.Drawing.Point(93, 265);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(246, 20);
            this.searchBox.TabIndex = 40;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(331, 78);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown2.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(220, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 17);
            this.label9.TabIndex = 42;
            this.label9.Text = "Memory section";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(112, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 44;
            this.label11.Text = "Debug enable";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 17);
            this.label12.TabIndex = 46;
            this.label12.Text = "Memory size";
            // 
            // MemorySizeText
            // 
            this.MemorySizeText.Location = new System.Drawing.Point(115, 77);
            this.MemorySizeText.Name = "MemorySizeText";
            this.MemorySizeText.Size = new System.Drawing.Size(150, 20);
            this.MemorySizeText.TabIndex = 47;
            this.MemorySizeText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MemorySizeText_KeyUp);
            // 
            // DataSizeBox
            // 
            this.DataSizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataSizeBox.FormattingEnabled = true;
            this.DataSizeBox.Items.AddRange(new object[] {
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512"});
            this.DataSizeBox.Location = new System.Drawing.Point(101, 76);
            this.DataSizeBox.Name = "DataSizeBox";
            this.DataSizeBox.Size = new System.Drawing.Size(77, 21);
            this.DataSizeBox.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.TabIndex = 48;
            this.label13.Text = "Data size";
            // 
            // RelativeAddressCheckBox
            // 
            this.RelativeAddressCheckBox.AutoSize = true;
            this.RelativeAddressCheckBox.Location = new System.Drawing.Point(163, 111);
            this.RelativeAddressCheckBox.Name = "RelativeAddressCheckBox";
            this.RelativeAddressCheckBox.Size = new System.Drawing.Size(15, 14);
            this.RelativeAddressCheckBox.TabIndex = 51;
            this.RelativeAddressCheckBox.UseVisualStyleBackColor = true;
            // 
            // EmergencyCheckBox
            // 
            this.EmergencyCheckBox.AutoSize = true;
            this.EmergencyCheckBox.Location = new System.Drawing.Point(373, 108);
            this.EmergencyCheckBox.Name = "EmergencyCheckBox";
            this.EmergencyCheckBox.Size = new System.Drawing.Size(15, 14);
            this.EmergencyCheckBox.TabIndex = 52;
            this.EmergencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // DebugCheckBox
            // 
            this.DebugCheckBox.AutoSize = true;
            this.DebugCheckBox.Location = new System.Drawing.Point(250, 115);
            this.DebugCheckBox.Name = "DebugCheckBox";
            this.DebugCheckBox.Size = new System.Drawing.Size(15, 14);
            this.DebugCheckBox.TabIndex = 53;
            this.DebugCheckBox.UseVisualStyleBackColor = true;
            // 
            // ValidCheckBox
            // 
            this.ValidCheckBox.AutoSize = true;
            this.ValidCheckBox.Location = new System.Drawing.Point(73, 111);
            this.ValidCheckBox.Name = "ValidCheckBox";
            this.ValidCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ValidCheckBox.TabIndex = 55;
            this.ValidCheckBox.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(15, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 17);
            this.label14.TabIndex = 54;
            this.label14.Text = "Valid";
            // 
            // BankBox
            // 
            this.BankBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BankBox.FormattingEnabled = true;
            this.BankBox.Items.AddRange(new object[] {
            "A",
            "B"});
            this.BankBox.Location = new System.Drawing.Point(311, 14);
            this.BankBox.Name = "BankBox";
            this.BankBox.Size = new System.Drawing.Size(77, 21);
            this.BankBox.TabIndex = 57;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(220, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 17);
            this.label15.TabIndex = 56;
            this.label15.Text = "Bank";
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(601, 262);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(75, 25);
            this.InsertButton.TabIndex = 27;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(433, 262);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 25);
            this.LoadButton.TabIndex = 25;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.Load_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(514, 262);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 25);
            this.Delete.TabIndex = 26;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // R_WCombo
            // 
            this.R_WCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.R_WCombo.FormattingEnabled = true;
            this.R_WCombo.Items.AddRange(new object[] {
            "R",
            "W"});
            this.R_WCombo.Location = new System.Drawing.Point(101, 45);
            this.R_WCombo.Name = "R_WCombo";
            this.R_WCombo.Size = new System.Drawing.Size(77, 21);
            this.R_WCombo.TabIndex = 59;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.Location = new System.Drawing.Point(75, 242);
            this.ErrorMessage.Margin = new System.Windows.Forms.Padding(1);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.ReadOnly = true;
            this.ErrorMessage.Size = new System.Drawing.Size(141, 19);
            this.ErrorMessage.TabIndex = 60;
            this.ErrorMessage.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.ClearButton);
            this.panel2.Controls.Add(this.LoadButton);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.Delete);
            this.panel2.Controls.Add(this.PathToFile);
            this.panel2.Controls.Add(this.InsertButton);
            this.panel2.Controls.Add(this.UnCommentButton);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.CommentButton);
            this.panel2.Controls.Add(this.searchBox);
            this.panel2.Controls.Add(this.ErrorMessage);
            this.panel2.Location = new System.Drawing.Point(15, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1075, 560);
            this.panel2.TabIndex = 64;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.BankBox);
            this.panel3.Controls.Add(this.TypeOpts);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.EmergencyCheckBox);
            this.panel3.Controls.Add(this.RelativeAddressCheckBox);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.numericUpDown2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.DataSizeBox);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.R_WCombo);
            this.panel3.Location = new System.Drawing.Point(345, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(401, 137);
            this.panel3.TabIndex = 65;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ValidCheckBox);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.PortNameText);
            this.panel1.Controls.Add(this.DebugCheckBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.MemorySizeText);
            this.panel1.Controls.Add(this.CommentText);
            this.panel1.Location = new System.Drawing.Point(38, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 137);
            this.panel1.TabIndex = 64;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1099, 24);
            this.menuStrip1.TabIndex = 65;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openManualToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // ClearButton
            // 
            this.ClearButton.Image = global::MultiPortBreakDown.Properties.Resources.Clearall;
            this.ClearButton.Location = new System.Drawing.Point(1045, 265);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(25, 25);
            this.ClearButton.TabIndex = 28;
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.Clear_Click);
            // 
            // UnCommentButton
            // 
            this.UnCommentButton.Image = global::MultiPortBreakDown.Properties.Resources.uncomment;
            this.UnCommentButton.Location = new System.Drawing.Point(345, 262);
            this.UnCommentButton.Name = "UnCommentButton";
            this.UnCommentButton.Size = new System.Drawing.Size(25, 25);
            this.UnCommentButton.TabIndex = 63;
            this.UnCommentButton.UseVisualStyleBackColor = true;
            this.UnCommentButton.Click += new System.EventHandler(this.UnCommentButton_Click);
            // 
            // CommentButton
            // 
            this.CommentButton.Image = global::MultiPortBreakDown.Properties.Resources.comment;
            this.CommentButton.Location = new System.Drawing.Point(376, 262);
            this.CommentButton.Name = "CommentButton";
            this.CommentButton.Size = new System.Drawing.Size(25, 25);
            this.CommentButton.TabIndex = 62;
            this.CommentButton.UseVisualStyleBackColor = true;
            this.CommentButton.Click += new System.EventHandler(this.CommentButton_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::MultiPortBreakDown.Properties.Resources.save;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::MultiPortBreakDown.Properties.Resources.open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::MultiPortBreakDown.Properties.Resources.Close;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Close";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // openManualToolStripMenuItem
            // 
            this.openManualToolStripMenuItem.Image = global::MultiPortBreakDown.Properties.Resources.help;
            this.openManualToolStripMenuItem.Name = "openManualToolStripMenuItem";
            this.openManualToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.openManualToolStripMenuItem.Text = "Manual";
            // 
            // MultiPortBreakDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1099, 601);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1115, 640);
            this.Name = "MultiPortBreakDown";
            this.Text = "MultiPortBreakdown";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.frm_sizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label PathToFile;
        private System.Windows.Forms.TextBox PortNameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox CommentText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox TypeOpts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox MemorySizeText;
        private System.Windows.Forms.ComboBox DataSizeBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox RelativeAddressCheckBox;
        private System.Windows.Forms.CheckBox EmergencyCheckBox;
        private System.Windows.Forms.CheckBox DebugCheckBox;
        private System.Windows.Forms.CheckBox ValidCheckBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox BankBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.ComboBox R_WCombo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox ErrorMessage;
        private System.Windows.Forms.Button CommentButton;
        private System.Windows.Forms.Button UnCommentButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openManualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

