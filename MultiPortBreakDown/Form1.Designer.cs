using System;

namespace MultiPortBreakDown
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveAstButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.PathToFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.ClearButton = new System.Windows.Forms.Button();
            this.InsertButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.R_WCombo = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ErrorMessage = new System.Windows.Forms.RichTextBox();
            this.CommentButton = new System.Windows.Forms.Button();
            this.UnCommentButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.SaveAstButton);
            this.panel1.Controls.Add(this.OpenButton);
            this.panel1.Controls.Add(this.PathToFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(48, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 52);
            this.panel1.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(789, 18);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(65, 22);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(692, 17);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(65, 22);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveAstButton
            // 
            this.SaveAstButton.Location = new System.Drawing.Point(588, 17);
            this.SaveAstButton.Name = "SaveAstButton";
            this.SaveAstButton.Size = new System.Drawing.Size(65, 24);
            this.SaveAstButton.TabIndex = 3;
            this.SaveAstButton.Text = "Save As";
            this.SaveAstButton.UseVisualStyleBackColor = true;
            this.SaveAstButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(481, 15);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(65, 24);
            this.OpenButton.TabIndex = 2;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // PathToFile
            // 
            this.PathToFile.Location = new System.Drawing.Point(167, 16);
            this.PathToFile.Name = "PathToFile";
            this.PathToFile.ReadOnly = true;
            this.PathToFile.Size = new System.Drawing.Size(267, 20);
            this.PathToFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to file";
            // 
            // PortNameText
            // 
            this.PortNameText.Location = new System.Drawing.Point(166, 99);
            this.PortNameText.Name = "PortNameText";
            this.PortNameText.Size = new System.Drawing.Size(150, 20);
            this.PortNameText.TabIndex = 8;
            this.PortNameText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PortNameText_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(67, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Comment";
            // 
            // CommentText
            // 
            this.CommentText.Location = new System.Drawing.Point(166, 163);
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 343);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 228);
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
            this.TypeOpts.Location = new System.Drawing.Point(680, 130);
            this.TypeOpts.Name = "TypeOpts";
            this.TypeOpts.Size = new System.Drawing.Size(77, 21);
            this.TypeOpts.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(589, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Port type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(349, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "R_W";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(349, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Relative address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(349, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Emergency enable";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(589, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 35;
            this.label6.Text = "Priority";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(700, 195);
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
            this.label10.Location = new System.Drawing.Point(12, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 41;
            this.label10.Text = "Search";
            // 
            // searchBox
            // 
            this.searchBox.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.searchBox.Location = new System.Drawing.Point(70, 9);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(213, 20);
            this.searchBox.TabIndex = 40;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(700, 228);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown2.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(589, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 17);
            this.label9.TabIndex = 42;
            this.label9.Text = "Memory section";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(349, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 17);
            this.label11.TabIndex = 44;
            this.label11.Text = "Debug enable";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(67, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 17);
            this.label12.TabIndex = 46;
            this.label12.Text = "Memory size";
            // 
            // MemorySizeText
            // 
            this.MemorySizeText.Location = new System.Drawing.Point(166, 131);
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
            this.DataSizeBox.Location = new System.Drawing.Point(680, 97);
            this.DataSizeBox.Name = "DataSizeBox";
            this.DataSizeBox.Size = new System.Drawing.Size(77, 21);
            this.DataSizeBox.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(589, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 17);
            this.label13.TabIndex = 48;
            this.label13.Text = "Data size";
            // 
            // RelativeAddressCheckBox
            // 
            this.RelativeAddressCheckBox.AutoSize = true;
            this.RelativeAddressCheckBox.Location = new System.Drawing.Point(481, 160);
            this.RelativeAddressCheckBox.Name = "RelativeAddressCheckBox";
            this.RelativeAddressCheckBox.Size = new System.Drawing.Size(15, 14);
            this.RelativeAddressCheckBox.TabIndex = 51;
            this.RelativeAddressCheckBox.UseVisualStyleBackColor = true;
            // 
            // EmergencyCheckBox
            // 
            this.EmergencyCheckBox.AutoSize = true;
            this.EmergencyCheckBox.Location = new System.Drawing.Point(481, 189);
            this.EmergencyCheckBox.Name = "EmergencyCheckBox";
            this.EmergencyCheckBox.Size = new System.Drawing.Size(15, 14);
            this.EmergencyCheckBox.TabIndex = 52;
            this.EmergencyCheckBox.UseVisualStyleBackColor = true;
            // 
            // DebugCheckBox
            // 
            this.DebugCheckBox.AutoSize = true;
            this.DebugCheckBox.Location = new System.Drawing.Point(481, 219);
            this.DebugCheckBox.Name = "DebugCheckBox";
            this.DebugCheckBox.Size = new System.Drawing.Size(15, 14);
            this.DebugCheckBox.TabIndex = 53;
            this.DebugCheckBox.UseVisualStyleBackColor = true;
            // 
            // ValidCheckBox
            // 
            this.ValidCheckBox.AutoSize = true;
            this.ValidCheckBox.Location = new System.Drawing.Point(481, 102);
            this.ValidCheckBox.Name = "ValidCheckBox";
            this.ValidCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ValidCheckBox.TabIndex = 55;
            this.ValidCheckBox.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(349, 97);
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
            this.BankBox.Location = new System.Drawing.Point(680, 162);
            this.BankBox.Name = "BankBox";
            this.BankBox.Size = new System.Drawing.Size(77, 21);
            this.BankBox.TabIndex = 57;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(589, 163);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 17);
            this.label15.TabIndex = 56;
            this.label15.Text = "Bank";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(357, 6);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 28;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.Clear_Click);
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(654, 8);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(81, 22);
            this.InsertButton.TabIndex = 27;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(455, 6);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 25;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.Load_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(551, 7);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(81, 23);
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
            this.R_WCombo.Location = new System.Drawing.Point(481, 128);
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
            this.ErrorMessage.Location = new System.Drawing.Point(805, 79);
            this.ErrorMessage.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.ReadOnly = true;
            this.ErrorMessage.Size = new System.Drawing.Size(199, 180);
            this.ErrorMessage.TabIndex = 60;
            this.ErrorMessage.Text = "";
            // 
            // CommentButton
            // 
            this.CommentButton.Image = ((System.Drawing.Image)(resources.GetObject("CommentButton.Image")));
            this.CommentButton.Location = new System.Drawing.Point(157, 218);
            this.CommentButton.Name = "CommentButton";
            this.CommentButton.Size = new System.Drawing.Size(24, 23);
            this.CommentButton.TabIndex = 62;
            this.CommentButton.UseVisualStyleBackColor = true;
            this.CommentButton.Click += new System.EventHandler(this.CommentButton_Click);
            // 
            // UnCommentButton
            // 
            this.UnCommentButton.Image = ((System.Drawing.Image)(resources.GetObject("UnCommentButton.Image")));
            this.UnCommentButton.Location = new System.Drawing.Point(211, 218);
            this.UnCommentButton.Name = "UnCommentButton";
            this.UnCommentButton.Size = new System.Drawing.Size(22, 23);
            this.UnCommentButton.TabIndex = 63;
            this.UnCommentButton.UseVisualStyleBackColor = true;
            this.UnCommentButton.Click += new System.EventHandler(this.UnCommentButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.UnCommentButton);
            this.panel2.Controls.Add(this.CommentButton);
            this.panel2.Controls.Add(this.PortNameText);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.CommentText);
            this.panel2.Controls.Add(this.ErrorMessage);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.MemorySizeText);
            this.panel2.Controls.Add(this.ValidCheckBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.BankBox);
            this.panel2.Controls.Add(this.R_WCombo);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.DataSizeBox);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.numericUpDown2);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.RelativeAddressCheckBox);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.EmergencyCheckBox);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.DebugCheckBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.TypeOpts);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 339);
            this.panel2.TabIndex = 64;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ClearButton);
            this.panel3.Controls.Add(this.LoadButton);
            this.panel3.Controls.Add(this.Delete);
            this.panel3.Controls.Add(this.InsertButton);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.searchBox);
            this.panel3.Location = new System.Drawing.Point(60, 280);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(746, 39);
            this.panel3.TabIndex = 64;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1040, 571);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.MinimumSize = new System.Drawing.Size(1056, 610);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.frm_sizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button SaveAstButton;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.TextBox PathToFile;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

