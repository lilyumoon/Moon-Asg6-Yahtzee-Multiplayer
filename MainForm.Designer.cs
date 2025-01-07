namespace Moon_Asg6_Yahtzee_Multiplayer
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
            this.newGameButton = new System.Windows.Forms.Button();
            this.playersLabel = new System.Windows.Forms.Label();
            this.playerCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.playerLabel = new System.Windows.Forms.Label();
            this.playerOneTextBox = new System.Windows.Forms.TextBox();
            this.playerTwoTextBox = new System.Windows.Forms.TextBox();
            this.playerThreeTextBox = new System.Windows.Forms.TextBox();
            this.playerFourTextBox = new System.Windows.Forms.TextBox();
            this.topScoreLabel = new System.Windows.Forms.Label();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.topScoreIndicatorLabel = new System.Windows.Forms.Label();
            this.highScoreIndicatorLabel = new System.Windows.Forms.Label();
            this.p1ColorButton = new System.Windows.Forms.Button();
            this.p2ColorButton = new System.Windows.Forms.Button();
            this.p3ColorButton = new System.Windows.Forms.Button();
            this.p4ColorButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.playerCountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(13, 17);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 23);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.TabStop = false;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Location = new System.Drawing.Point(106, 22);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(44, 13);
            this.playersLabel.TabIndex = 2;
            this.playersLabel.Text = "Players:";
            // 
            // playerCountUpDown
            // 
            this.playerCountUpDown.Location = new System.Drawing.Point(152, 19);
            this.playerCountUpDown.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.playerCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerCountUpDown.Name = "playerCountUpDown";
            this.playerCountUpDown.ReadOnly = true;
            this.playerCountUpDown.Size = new System.Drawing.Size(40, 20);
            this.playerCountUpDown.TabIndex = 3;
            this.playerCountUpDown.TabStop = false;
            this.playerCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerCountUpDown.ValueChanged += new System.EventHandler(this.playerCountUpDown_ValueChanged);
            // 
            // playerLabel
            // 
            this.playerLabel.AutoSize = true;
            this.playerLabel.Location = new System.Drawing.Point(211, 25);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(39, 13);
            this.playerLabel.TabIndex = 4;
            this.playerLabel.Text = "Player:";
            // 
            // playerOneTextBox
            // 
            this.playerOneTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.playerOneTextBox.Location = new System.Drawing.Point(253, 22);
            this.playerOneTextBox.MaxLength = 32;
            this.playerOneTextBox.Name = "playerOneTextBox";
            this.playerOneTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerOneTextBox.TabIndex = 0;
            this.playerOneTextBox.Text = "One";
            // 
            // playerTwoTextBox
            // 
            this.playerTwoTextBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.playerTwoTextBox.Location = new System.Drawing.Point(253, 44);
            this.playerTwoTextBox.MaxLength = 32;
            this.playerTwoTextBox.Name = "playerTwoTextBox";
            this.playerTwoTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerTwoTextBox.TabIndex = 9;
            this.playerTwoTextBox.Text = "Two";
            this.playerTwoTextBox.Visible = false;
            // 
            // playerThreeTextBox
            // 
            this.playerThreeTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.playerThreeTextBox.Location = new System.Drawing.Point(253, 66);
            this.playerThreeTextBox.MaxLength = 32;
            this.playerThreeTextBox.Name = "playerThreeTextBox";
            this.playerThreeTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerThreeTextBox.TabIndex = 10;
            this.playerThreeTextBox.Text = "Three";
            this.playerThreeTextBox.Visible = false;
            // 
            // playerFourTextBox
            // 
            this.playerFourTextBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.playerFourTextBox.Location = new System.Drawing.Point(253, 89);
            this.playerFourTextBox.MaxLength = 32;
            this.playerFourTextBox.Name = "playerFourTextBox";
            this.playerFourTextBox.Size = new System.Drawing.Size(100, 20);
            this.playerFourTextBox.TabIndex = 11;
            this.playerFourTextBox.Text = "Four";
            this.playerFourTextBox.Visible = false;
            // 
            // topScoreLabel
            // 
            this.topScoreLabel.AutoSize = true;
            this.topScoreLabel.Location = new System.Drawing.Point(84, 71);
            this.topScoreLabel.Name = "topScoreLabel";
            this.topScoreLabel.Size = new System.Drawing.Size(61, 13);
            this.topScoreLabel.TabIndex = 12;
            this.topScoreLabel.Text = "Top Player:";
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Location = new System.Drawing.Point(97, 95);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(47, 13);
            this.highScoreLabel.TabIndex = 13;
            this.highScoreLabel.Text = "All Time:";
            // 
            // topScoreIndicatorLabel
            // 
            this.topScoreIndicatorLabel.AutoSize = true;
            this.topScoreIndicatorLabel.Location = new System.Drawing.Point(150, 71);
            this.topScoreIndicatorLabel.Name = "topScoreIndicatorLabel";
            this.topScoreIndicatorLabel.Size = new System.Drawing.Size(45, 13);
            this.topScoreIndicatorLabel.TabIndex = 14;
            this.topScoreIndicatorLabel.Text = "None: 0";
            // 
            // highScoreIndicatorLabel
            // 
            this.highScoreIndicatorLabel.AutoSize = true;
            this.highScoreIndicatorLabel.Location = new System.Drawing.Point(150, 95);
            this.highScoreIndicatorLabel.Name = "highScoreIndicatorLabel";
            this.highScoreIndicatorLabel.Size = new System.Drawing.Size(45, 13);
            this.highScoreIndicatorLabel.TabIndex = 15;
            this.highScoreIndicatorLabel.Text = "None: 0";
            // 
            // p1ColorButton
            // 
            this.p1ColorButton.Location = new System.Drawing.Point(359, 21);
            this.p1ColorButton.Name = "p1ColorButton";
            this.p1ColorButton.Size = new System.Drawing.Size(25, 20);
            this.p1ColorButton.TabIndex = 16;
            this.p1ColorButton.TabStop = false;
            this.p1ColorButton.Tag = "";
            this.p1ColorButton.Text = "‍🌈";
            this.p1ColorButton.UseVisualStyleBackColor = true;
            this.p1ColorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // p2ColorButton
            // 
            this.p2ColorButton.Location = new System.Drawing.Point(359, 43);
            this.p2ColorButton.Name = "p2ColorButton";
            this.p2ColorButton.Size = new System.Drawing.Size(25, 20);
            this.p2ColorButton.TabIndex = 17;
            this.p2ColorButton.TabStop = false;
            this.p2ColorButton.Tag = "";
            this.p2ColorButton.Text = "‍🌈";
            this.p2ColorButton.UseVisualStyleBackColor = true;
            this.p2ColorButton.Visible = false;
            this.p2ColorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // p3ColorButton
            // 
            this.p3ColorButton.Location = new System.Drawing.Point(359, 66);
            this.p3ColorButton.Name = "p3ColorButton";
            this.p3ColorButton.Size = new System.Drawing.Size(25, 20);
            this.p3ColorButton.TabIndex = 18;
            this.p3ColorButton.TabStop = false;
            this.p3ColorButton.Tag = "";
            this.p3ColorButton.Text = "‍🌈";
            this.p3ColorButton.UseVisualStyleBackColor = true;
            this.p3ColorButton.Visible = false;
            this.p3ColorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // p4ColorButton
            // 
            this.p4ColorButton.Location = new System.Drawing.Point(359, 89);
            this.p4ColorButton.Name = "p4ColorButton";
            this.p4ColorButton.Size = new System.Drawing.Size(25, 20);
            this.p4ColorButton.TabIndex = 19;
            this.p4ColorButton.TabStop = false;
            this.p4ColorButton.Tag = "";
            this.p4ColorButton.Text = "‍🌈";
            this.p4ColorButton.UseVisualStyleBackColor = true;
            this.p4ColorButton.Visible = false;
            this.p4ColorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 121);
            this.Controls.Add(this.p4ColorButton);
            this.Controls.Add(this.p3ColorButton);
            this.Controls.Add(this.p2ColorButton);
            this.Controls.Add(this.p1ColorButton);
            this.Controls.Add(this.highScoreIndicatorLabel);
            this.Controls.Add(this.topScoreIndicatorLabel);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.topScoreLabel);
            this.Controls.Add(this.playerFourTextBox);
            this.Controls.Add(this.playerThreeTextBox);
            this.Controls.Add(this.playerTwoTextBox);
            this.Controls.Add(this.playerOneTextBox);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.playerCountUpDown);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.newGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.Text = "Moon - Yahtzee Multiplayer";
            ((System.ComponentModel.ISupportInitialize)(this.playerCountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.NumericUpDown playerCountUpDown;
        private System.Windows.Forms.Label playerLabel;
        private System.Windows.Forms.TextBox playerOneTextBox;
        private System.Windows.Forms.TextBox playerTwoTextBox;
        private System.Windows.Forms.TextBox playerThreeTextBox;
        private System.Windows.Forms.TextBox playerFourTextBox;
        private System.Windows.Forms.Label topScoreLabel;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Label topScoreIndicatorLabel;
        private System.Windows.Forms.Label highScoreIndicatorLabel;
        private System.Windows.Forms.Button p1ColorButton;
        private System.Windows.Forms.Button p2ColorButton;
        private System.Windows.Forms.Button p3ColorButton;
        private System.Windows.Forms.Button p4ColorButton;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}