namespace SixthLab
{
    partial class MainForm
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
            guessGameButton = new Button();
            arraysButton = new Button();
            tetrisButton = new Button();
            aboutAuthorButton = new Button();
            SuspendLayout();
            // 
            // guessGameButton
            // 
            guessGameButton.Location = new Point(12, 79);
            guessGameButton.Name = "guessGameButton";
            guessGameButton.Size = new Size(179, 30);
            guessGameButton.TabIndex = 0;
            guessGameButton.Text = "Guess Game";
            guessGameButton.UseVisualStyleBackColor = true;
            guessGameButton.Click += guessGameButton_Click;
            // 
            // arraysButton
            // 
            arraysButton.Location = new Point(186, 153);
            arraysButton.Name = "arraysButton";
            arraysButton.Size = new Size(179, 30);
            arraysButton.TabIndex = 1;
            arraysButton.Text = "Arrays";
            arraysButton.UseVisualStyleBackColor = true;
            arraysButton.Click += arraysButton_Click;
            // 
            // tetrisButton
            // 
            tetrisButton.Location = new Point(353, 207);
            tetrisButton.Name = "tetrisButton";
            tetrisButton.Size = new Size(179, 30);
            tetrisButton.TabIndex = 2;
            tetrisButton.Text = "Tetris";
            tetrisButton.UseVisualStyleBackColor = true;
            tetrisButton.Click += this.tetrisButton_Click;
            // 
            // aboutAuthorButton
            // 
            aboutAuthorButton.Location = new Point(508, 258);
            aboutAuthorButton.Name = "aboutAuthorButton";
            aboutAuthorButton.Size = new Size(179, 30);
            aboutAuthorButton.TabIndex = 3;
            aboutAuthorButton.Text = "AboutAuthor";
            aboutAuthorButton.UseVisualStyleBackColor = true;
            aboutAuthorButton.Click += aboutAuthorButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 450);
            Controls.Add(aboutAuthorButton);
            Controls.Add(tetrisButton);
            Controls.Add(arraysButton);
            Controls.Add(guessGameButton);
            Name = "MainForm";
            Text = "SixthLab";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button guessGameButton;
        private Button arraysButton;
        private Button tetrisButton;
        private Button aboutAuthorButton;
    }
}
