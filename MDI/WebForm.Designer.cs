namespace MDI {
    partial class WebForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.WebOpenButton = new System.Windows.Forms.Button();
            this.WebCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.webTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WebOpenButton
            // 
            this.WebOpenButton.Location = new System.Drawing.Point(193, 308);
            this.WebOpenButton.Name = "WebOpenButton";
            this.WebOpenButton.Size = new System.Drawing.Size(145, 57);
            this.WebOpenButton.TabIndex = 0;
            this.WebOpenButton.Text = "Open";
            this.WebOpenButton.UseVisualStyleBackColor = true;
            this.WebOpenButton.Click += new System.EventHandler(this.WebOpenButton_Click);
            // 
            // WebCancelButton
            // 
            this.WebCancelButton.Location = new System.Drawing.Point(487, 308);
            this.WebCancelButton.Name = "WebCancelButton";
            this.WebCancelButton.Size = new System.Drawing.Size(145, 57);
            this.WebCancelButton.TabIndex = 0;
            this.WebCancelButton.Text = "Cancel";
            this.WebCancelButton.UseVisualStyleBackColor = true;
            this.WebCancelButton.Click += new System.EventHandler(this.WebCancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location";
            // 
            // webTextBox
            // 
            this.webTextBox.Location = new System.Drawing.Point(80, 192);
            this.webTextBox.Name = "webTextBox";
            this.webTextBox.Size = new System.Drawing.Size(676, 31);
            this.webTextBox.TabIndex = 2;
            // 
            // WebForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 437);
            this.Controls.Add(this.webTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WebCancelButton);
            this.Controls.Add(this.WebOpenButton);
            this.Name = "WebForm";
            this.Text = "WebForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WebOpenButton;
        private System.Windows.Forms.Button WebCancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox webTextBox;
    }
}