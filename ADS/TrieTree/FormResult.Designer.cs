namespace TrieTree
{
    partial class FormResult
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
            this.ListViewWords = new System.Windows.Forms.ListView();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListViewWords
            // 
            this.ListViewWords.HideSelection = false;
            this.ListViewWords.Location = new System.Drawing.Point(12, 12);
            this.ListViewWords.Name = "ListViewWords";
            this.ListViewWords.Size = new System.Drawing.Size(257, 395);
            this.ListViewWords.TabIndex = 0;
            this.ListViewWords.UseCompatibleStateImageBehavior = false;
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(103, 420);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 29);
            this.ButtonClose.TabIndex = 1;
            this.ButtonClose.Text = "Закрыть";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 461);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ListViewWords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormResult";
            this.Text = "FormResult";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListViewWords;
        private System.Windows.Forms.Button ButtonClose;
    }
}