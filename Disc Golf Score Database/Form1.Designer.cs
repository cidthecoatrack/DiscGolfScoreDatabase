namespace Disc_Golf_Score_Database
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NameCombo = new System.Windows.Forms.ComboBox();
            this.ScoreTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterScoreButton = new System.Windows.Forms.Button();
            this.DateInput = new System.Windows.Forms.DateTimePicker();
            this.EditSelected = new System.Windows.Forms.Button();
            this.CommentBox = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.MoveLeftButton = new System.Windows.Forms.Button();
            this.MoveRightButton = new System.Windows.Forms.Button();
            this.StatBox = new System.Windows.Forms.RichTextBox();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.ScoreBox = new System.Windows.Forms.ListBox();
            this.GraphButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SimulCheckbox = new System.Windows.Forms.CheckBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HandicapCheck = new System.Windows.Forms.CheckBox();
            this.HandicapText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TypeCombo = new System.Windows.Forms.ComboBox();
            this.SimultanText = new System.Windows.Forms.TextBox();
            this.CompHandiCheck = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPlayerFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameCombo
            // 
            this.NameCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NameCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.NameCombo.FormattingEnabled = true;
            this.NameCombo.Location = new System.Drawing.Point(88, 59);
            this.NameCombo.Name = "NameCombo";
            this.NameCombo.Size = new System.Drawing.Size(170, 21);
            this.NameCombo.Sorted = true;
            this.NameCombo.TabIndex = 0;
            // 
            // ScoreTextBox
            // 
            this.ScoreTextBox.Location = new System.Drawing.Point(56, 86);
            this.ScoreTextBox.Name = "ScoreTextBox";
            this.ScoreTextBox.Size = new System.Drawing.Size(48, 20);
            this.ScoreTextBox.TabIndex = 1;
            this.ScoreTextBox.Tag = "Enter score against the posted course par";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score:";
            // 
            // EnterScoreButton
            // 
            this.EnterScoreButton.Font = new System.Drawing.Font("Burton\'s Nightmare", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterScoreButton.Location = new System.Drawing.Point(12, 240);
            this.EnterScoreButton.Name = "EnterScoreButton";
            this.EnterScoreButton.Size = new System.Drawing.Size(246, 46);
            this.EnterScoreButton.TabIndex = 7;
            this.EnterScoreButton.Text = "Enter Score";
            this.EnterScoreButton.UseVisualStyleBackColor = true;
            this.EnterScoreButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // DateInput
            // 
            this.DateInput.Location = new System.Drawing.Point(56, 112);
            this.DateInput.Name = "DateInput";
            this.DateInput.Size = new System.Drawing.Size(202, 20);
            this.DateInput.TabIndex = 3;
            // 
            // EditSelected
            // 
            this.EditSelected.Font = new System.Drawing.Font("Burton\'s Nightmare", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSelected.Location = new System.Drawing.Point(586, 337);
            this.EditSelected.Name = "EditSelected";
            this.EditSelected.Size = new System.Drawing.Size(149, 46);
            this.EditSelected.TabIndex = 15;
            this.EditSelected.Text = "Edit Selected Game";
            this.EditSelected.UseVisualStyleBackColor = true;
            this.EditSelected.Click += new System.EventHandler(this.EditSelected_Click);
            // 
            // CommentBox
            // 
            this.CommentBox.Location = new System.Drawing.Point(83, 165);
            this.CommentBox.Name = "CommentBox";
            this.CommentBox.Size = new System.Drawing.Size(175, 43);
            this.CommentBox.TabIndex = 5;
            this.CommentBox.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 168);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Comments:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 118);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Date:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Player Name:";
            // 
            // MoveLeftButton
            // 
            this.MoveLeftButton.Location = new System.Drawing.Point(277, 27);
            this.MoveLeftButton.Name = "MoveLeftButton";
            this.MoveLeftButton.Size = new System.Drawing.Size(30, 26);
            this.MoveLeftButton.TabIndex = 12;
            this.MoveLeftButton.Text = "<";
            this.MoveLeftButton.UseVisualStyleBackColor = true;
            this.MoveLeftButton.Click += new System.EventHandler(this.MoveLeftButton_Click);
            // 
            // MoveRightButton
            // 
            this.MoveRightButton.Location = new System.Drawing.Point(516, 27);
            this.MoveRightButton.Name = "MoveRightButton";
            this.MoveRightButton.Size = new System.Drawing.Size(30, 26);
            this.MoveRightButton.TabIndex = 13;
            this.MoveRightButton.Text = ">";
            this.MoveRightButton.UseVisualStyleBackColor = true;
            this.MoveRightButton.Click += new System.EventHandler(this.MoveRightButton_Click);
            // 
            // StatBox
            // 
            this.StatBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatBox.Location = new System.Drawing.Point(277, 59);
            this.StatBox.Name = "StatBox";
            this.StatBox.ReadOnly = true;
            this.StatBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.StatBox.Size = new System.Drawing.Size(269, 249);
            this.StatBox.TabIndex = 23;
            this.StatBox.TabStop = false;
            this.StatBox.Text = "";
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.Font = new System.Drawing.Font("Burton\'s Nightmare", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNameLabel.Location = new System.Drawing.Point(315, 24);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(62, 27);
            this.PlayerNameLabel.TabIndex = 24;
            this.PlayerNameLabel.Text = "(Player)";
            this.PlayerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScoreBox
            // 
            this.ScoreBox.FormattingEnabled = true;
            this.ScoreBox.HorizontalScrollbar = true;
            this.ScoreBox.Location = new System.Drawing.Point(586, 27);
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.Size = new System.Drawing.Size(305, 277);
            this.ScoreBox.TabIndex = 9;
            this.ScoreBox.SelectedIndexChanged += new System.EventHandler(this.ScoreBox_SelectedIndexChanged);
            // 
            // GraphButton
            // 
            this.GraphButton.Font = new System.Drawing.Font("Burton\'s Nightmare", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphButton.Location = new System.Drawing.Point(277, 314);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(269, 69);
            this.GraphButton.TabIndex = 14;
            this.GraphButton.Tag = "Will graph only those games currently shwon as they are currently shown";
            this.GraphButton.Text = "Graph";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Burton\'s Nightmare", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(751, 337);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(140, 46);
            this.DeleteButton.TabIndex = 16;
            this.DeleteButton.Text = "Delete Selected Game";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SimulCheckbox
            // 
            this.SimulCheckbox.AutoSize = true;
            this.SimulCheckbox.Location = new System.Drawing.Point(12, 216);
            this.SimulCheckbox.Name = "SimulCheckbox";
            this.SimulCheckbox.Size = new System.Drawing.Size(103, 17);
            this.SimulCheckbox.TabIndex = 6;
            this.SimulCheckbox.Text = "Simultaneous as";
            this.SimulCheckbox.UseVisualStyleBackColor = true;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(633, 310);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(258, 20);
            this.SearchTextBox.TabIndex = 17;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(583, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Search:";
            // 
            // HandicapCheck
            // 
            this.HandicapCheck.AutoSize = true;
            this.HandicapCheck.Location = new System.Drawing.Point(110, 88);
            this.HandicapCheck.Name = "HandicapCheck";
            this.HandicapCheck.Size = new System.Drawing.Size(72, 17);
            this.HandicapCheck.TabIndex = 2;
            this.HandicapCheck.Text = "Handicap";
            this.HandicapCheck.UseVisualStyleBackColor = true;
            this.HandicapCheck.CheckedChanged += new System.EventHandler(this.HandicapCheck_CheckedChanged);
            // 
            // HandicapText
            // 
            this.HandicapText.Enabled = false;
            this.HandicapText.Location = new System.Drawing.Point(188, 86);
            this.HandicapText.Name = "HandicapText";
            this.HandicapText.Size = new System.Drawing.Size(70, 20);
            this.HandicapText.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Game Type:";
            // 
            // TypeCombo
            // 
            this.TypeCombo.FormattingEnabled = true;
            this.TypeCombo.Items.AddRange(new object[] {
            "(Normal)"});
            this.TypeCombo.Location = new System.Drawing.Point(83, 138);
            this.TypeCombo.Name = "TypeCombo";
            this.TypeCombo.Size = new System.Drawing.Size(175, 21);
            this.TypeCombo.Sorted = true;
            this.TypeCombo.TabIndex = 4;
            // 
            // SimultanText
            // 
            this.SimultanText.Location = new System.Drawing.Point(121, 214);
            this.SimultanText.Name = "SimultanText";
            this.SimultanText.ReadOnly = true;
            this.SimultanText.Size = new System.Drawing.Size(137, 20);
            this.SimultanText.TabIndex = 34;
            // 
            // CompHandiCheck
            // 
            this.CompHandiCheck.AutoSize = true;
            this.CompHandiCheck.Location = new System.Drawing.Point(15, 355);
            this.CompHandiCheck.Name = "CompHandiCheck";
            this.CompHandiCheck.Size = new System.Drawing.Size(167, 17);
            this.CompHandiCheck.TabIndex = 11;
            this.CompHandiCheck.Text = "Compute stats with handicaps";
            this.CompHandiCheck.UseVisualStyleBackColor = true;
            this.CompHandiCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(903, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPlayerFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addPlayerFileToolStripMenuItem
            // 
            this.addPlayerFileToolStripMenuItem.Name = "addPlayerFileToolStripMenuItem";
            this.addPlayerFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addPlayerFileToolStripMenuItem.Text = "Add Player File";
            this.addPlayerFileToolStripMenuItem.Click += new System.EventHandler(this.addPlayerFileToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 394);
            this.Controls.Add(this.CompHandiCheck);
            this.Controls.Add(this.SimultanText);
            this.Controls.Add(this.TypeCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HandicapText);
            this.Controls.Add(this.HandicapCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.SimulCheckbox);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.GraphButton);
            this.Controls.Add(this.ScoreBox);
            this.Controls.Add(this.PlayerNameLabel);
            this.Controls.Add(this.MoveRightButton);
            this.Controls.Add(this.MoveLeftButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.CommentBox);
            this.Controls.Add(this.EditSelected);
            this.Controls.Add(this.DateInput);
            this.Controls.Add(this.EnterScoreButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScoreTextBox);
            this.Controls.Add(this.NameCombo);
            this.Controls.Add(this.StatBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Disc Golf Score Database 3.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox NameCombo;
        private System.Windows.Forms.TextBox ScoreTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EnterScoreButton;
        private System.Windows.Forms.DateTimePicker DateInput;
        private System.Windows.Forms.Button EditSelected;
        private System.Windows.Forms.RichTextBox CommentBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button MoveLeftButton;
        private System.Windows.Forms.Button MoveRightButton;
        private System.Windows.Forms.RichTextBox StatBox;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.ListBox ScoreBox;
        private System.Windows.Forms.Button GraphButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.CheckBox SimulCheckbox;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox HandicapCheck;
        private System.Windows.Forms.TextBox HandicapText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TypeCombo;
        private System.Windows.Forms.TextBox SimultanText;
        private System.Windows.Forms.CheckBox CompHandiCheck;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPlayerFileToolStripMenuItem;
    }
}

