namespace questiongen
{
    partial class questionGenWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(questionGenWindow));
            this.inputText = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.goBackButton = new System.Windows.Forms.Button();
            this.generatedText = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.questionLabel = new System.Windows.Forms.Label();
            this.correctAnswerButton = new System.Windows.Forms.RadioButton();
            this.answerButton1 = new System.Windows.Forms.RadioButton();
            this.answerButton2 = new System.Windows.Forms.RadioButton();
            this.answerButton3 = new System.Windows.Forms.RadioButton();
            this.quitQuizButton = new System.Windows.Forms.Button();
            this.statsLabel = new System.Windows.Forms.Label();
            this.blanksCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // inputText
            // 
            this.inputText.AutoSize = true;
            this.inputText.BackColor = System.Drawing.Color.Transparent;
            this.inputText.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputText.ForeColor = System.Drawing.Color.White;
            this.inputText.Location = new System.Drawing.Point(27, 19);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(233, 13);
            this.inputText.TabIndex = 0;
            this.inputText.Text = "Input the text that you wish to have analyzed.";
            this.inputText.Click += new System.EventHandler(this.label1_Click);
            // 
            // inputBox
            // 
            this.inputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputBox.BackColor = System.Drawing.Color.DimGray;
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputBox.ForeColor = System.Drawing.Color.White;
            this.inputBox.Location = new System.Drawing.Point(26, 46);
            this.inputBox.MaxLength = 0;
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputBox.Size = new System.Drawing.Size(731, 449);
            this.inputBox.TabIndex = 1;
            this.inputBox.TextChanged += new System.EventHandler(this.inputBox_TextChanged);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.LimeGreen;
            this.submitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.submitButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.ForeColor = System.Drawing.Color.White;
            this.submitButton.Location = new System.Drawing.Point(0, 513);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(784, 23);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // goBackButton
            // 
            this.goBackButton.BackColor = System.Drawing.Color.Red;
            this.goBackButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.goBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.goBackButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackButton.ForeColor = System.Drawing.Color.White;
            this.goBackButton.Location = new System.Drawing.Point(0, 490);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(784, 23);
            this.goBackButton.TabIndex = 3;
            this.goBackButton.Text = "Go Back";
            this.goBackButton.UseVisualStyleBackColor = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // generatedText
            // 
            this.generatedText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generatedText.BackColor = System.Drawing.Color.Black;
            this.generatedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.generatedText.ForeColor = System.Drawing.Color.White;
            this.generatedText.Location = new System.Drawing.Point(26, 19);
            this.generatedText.MaxLength = 0;
            this.generatedText.Multiline = true;
            this.generatedText.Name = "generatedText";
            this.generatedText.ReadOnly = true;
            this.generatedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.generatedText.Size = new System.Drawing.Size(731, 476);
            this.generatedText.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(650, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Answer Sheet";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.BackColor = System.Drawing.Color.Transparent;
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.ForeColor = System.Drawing.Color.White;
            this.questionLabel.Location = new System.Drawing.Point(26, 35);
            this.questionLabel.MaximumSize = new System.Drawing.Size(700, 300);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(128, 24);
            this.questionLabel.TabIndex = 6;
            this.questionLabel.Text = "questionLabel";
            // 
            // correctAnswerButton
            // 
            this.correctAnswerButton.BackColor = System.Drawing.Color.Transparent;
            this.correctAnswerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correctAnswerButton.ForeColor = System.Drawing.Color.White;
            this.correctAnswerButton.Location = new System.Drawing.Point(26, 150);
            this.correctAnswerButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.correctAnswerButton.MaximumSize = new System.Drawing.Size(700, 80);
            this.correctAnswerButton.Name = "correctAnswerButton";
            this.correctAnswerButton.Size = new System.Drawing.Size(700, 80);
            this.correctAnswerButton.TabIndex = 7;
            this.correctAnswerButton.TabStop = true;
            this.correctAnswerButton.Text = "answer";
            this.correctAnswerButton.UseVisualStyleBackColor = false;
            // 
            // answerButton1
            // 
            this.answerButton1.BackColor = System.Drawing.Color.Transparent;
            this.answerButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerButton1.ForeColor = System.Drawing.Color.White;
            this.answerButton1.Location = new System.Drawing.Point(26, 230);
            this.answerButton1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.answerButton1.MaximumSize = new System.Drawing.Size(700, 80);
            this.answerButton1.Name = "answerButton1";
            this.answerButton1.Size = new System.Drawing.Size(700, 80);
            this.answerButton1.TabIndex = 8;
            this.answerButton1.TabStop = true;
            this.answerButton1.Text = "answer";
            this.answerButton1.UseVisualStyleBackColor = false;
            // 
            // answerButton2
            // 
            this.answerButton2.BackColor = System.Drawing.Color.Transparent;
            this.answerButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerButton2.ForeColor = System.Drawing.Color.White;
            this.answerButton2.Location = new System.Drawing.Point(26, 310);
            this.answerButton2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.answerButton2.MaximumSize = new System.Drawing.Size(700, 80);
            this.answerButton2.Name = "answerButton2";
            this.answerButton2.Size = new System.Drawing.Size(700, 80);
            this.answerButton2.TabIndex = 9;
            this.answerButton2.TabStop = true;
            this.answerButton2.Text = "answer";
            this.answerButton2.UseVisualStyleBackColor = false;
            // 
            // answerButton3
            // 
            this.answerButton3.BackColor = System.Drawing.Color.Transparent;
            this.answerButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerButton3.ForeColor = System.Drawing.Color.White;
            this.answerButton3.Location = new System.Drawing.Point(26, 390);
            this.answerButton3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.answerButton3.MaximumSize = new System.Drawing.Size(700, 80);
            this.answerButton3.Name = "answerButton3";
            this.answerButton3.Size = new System.Drawing.Size(700, 80);
            this.answerButton3.TabIndex = 10;
            this.answerButton3.TabStop = true;
            this.answerButton3.Text = "answer";
            this.answerButton3.UseVisualStyleBackColor = false;
            // 
            // quitQuizButton
            // 
            this.quitQuizButton.BackColor = System.Drawing.Color.Red;
            this.quitQuizButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.quitQuizButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitQuizButton.ForeColor = System.Drawing.Color.White;
            this.quitQuizButton.Location = new System.Drawing.Point(0, 0);
            this.quitQuizButton.Name = "quitQuizButton";
            this.quitQuizButton.Size = new System.Drawing.Size(75, 23);
            this.quitQuizButton.TabIndex = 11;
            this.quitQuizButton.Text = "Quit";
            this.quitQuizButton.UseVisualStyleBackColor = false;
            this.quitQuizButton.Click += new System.EventHandler(this.quitQuizButton_Click);
            // 
            // statsLabel
            // 
            this.statsLabel.AutoSize = true;
            this.statsLabel.BackColor = System.Drawing.Color.Transparent;
            this.statsLabel.ForeColor = System.Drawing.Color.White;
            this.statsLabel.Location = new System.Drawing.Point(370, 3);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(199, 13);
            this.statsLabel.TabIndex = 12;
            this.statsLabel.Text = "Total Questions: 0 | Correct: 0 | Wrong: 0";
            // 
            // blanksCheckBox
            // 
            this.blanksCheckBox.AutoSize = true;
            this.blanksCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.blanksCheckBox.ForeColor = System.Drawing.Color.White;
            this.blanksCheckBox.Location = new System.Drawing.Point(552, 18);
            this.blanksCheckBox.Name = "blanksCheckBox";
            this.blanksCheckBox.Size = new System.Drawing.Size(82, 17);
            this.blanksCheckBox.TabIndex = 13;
            this.blanksCheckBox.Text = "Blanks Only";
            this.blanksCheckBox.UseVisualStyleBackColor = false;
            // 
            // questionGenWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::questiongen.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(784, 536);
            this.Controls.Add(this.blanksCheckBox);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.quitQuizButton);
            this.Controls.Add(this.answerButton3);
            this.Controls.Add(this.answerButton2);
            this.Controls.Add(this.answerButton1);
            this.Controls.Add(this.correctAnswerButton);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.generatedText);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.inputText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 575);
            this.Name = "questionGenWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuestionGen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputText;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.TextBox generatedText;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.RadioButton correctAnswerButton;
        private System.Windows.Forms.RadioButton answerButton1;
        private System.Windows.Forms.RadioButton answerButton2;
        private System.Windows.Forms.RadioButton answerButton3;
        private System.Windows.Forms.Button quitQuizButton;
        private System.Windows.Forms.Label statsLabel;
        private System.Windows.Forms.CheckBox blanksCheckBox;
    }
}

