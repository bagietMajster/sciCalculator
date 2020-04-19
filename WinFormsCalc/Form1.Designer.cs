namespace WinFormsCalc
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
            this.insertTextBox = new System.Windows.Forms.TextBox();
            this.additionButton = new System.Windows.Forms.Button();
            this.subtractionButton = new System.Windows.Forms.Button();
            this.equLabel = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.secondInsertTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // insertTextBox
            // 
            this.insertTextBox.Location = new System.Drawing.Point(12, 10);
            this.insertTextBox.Name = "insertTextBox";
            this.insertTextBox.Size = new System.Drawing.Size(96, 22);
            this.insertTextBox.TabIndex = 0;
            // 
            // additionButton
            // 
            this.additionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.additionButton.Location = new System.Drawing.Point(12, 52);
            this.additionButton.Name = "additionButton";
            this.additionButton.Size = new System.Drawing.Size(45, 45);
            this.additionButton.TabIndex = 1;
            this.additionButton.Text = "+";
            this.additionButton.UseVisualStyleBackColor = true;
            this.additionButton.Click += new System.EventHandler(this.additionButton_Click);
            // 
            // subtractionButton
            // 
            this.subtractionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.subtractionButton.Location = new System.Drawing.Point(63, 52);
            this.subtractionButton.Name = "subtractionButton";
            this.subtractionButton.Size = new System.Drawing.Size(45, 45);
            this.subtractionButton.TabIndex = 2;
            this.subtractionButton.Text = "-";
            this.subtractionButton.UseVisualStyleBackColor = true;
            this.subtractionButton.Click += new System.EventHandler(this.subtractionButton_Click);
            // 
            // equLabel
            // 
            this.equLabel.AutoSize = true;
            this.equLabel.Location = new System.Drawing.Point(217, 13);
            this.equLabel.Name = "equLabel";
            this.equLabel.Size = new System.Drawing.Size(16, 17);
            this.equLabel.TabIndex = 3;
            this.equLabel.Text = "=";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(239, 13);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(16, 17);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "0";
            // 
            // secondInsertTextBox
            // 
            this.secondInsertTextBox.Location = new System.Drawing.Point(114, 10);
            this.secondInsertTextBox.Name = "secondInsertTextBox";
            this.secondInsertTextBox.Size = new System.Drawing.Size(96, 22);
            this.secondInsertTextBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.secondInsertTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.equLabel);
            this.Controls.Add(this.subtractionButton);
            this.Controls.Add(this.additionButton);
            this.Controls.Add(this.insertTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox insertTextBox;
        private System.Windows.Forms.Button additionButton;
        private System.Windows.Forms.Button subtractionButton;
        private System.Windows.Forms.Label equLabel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox secondInsertTextBox;
    }
}

