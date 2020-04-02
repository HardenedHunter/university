namespace Backtracking
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxSource = new System.Windows.Forms.RichTextBox();
            this.TextBoxResult = new System.Windows.Forms.RichTextBox();
            this.LabelSource = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonTask = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxSource
            // 
            this.TextBoxSource.Location = new System.Drawing.Point(12, 32);
            this.TextBoxSource.Name = "TextBoxSource";
            this.TextBoxSource.Size = new System.Drawing.Size(163, 406);
            this.TextBoxSource.TabIndex = 0;
            this.TextBoxSource.Text = "";
            // 
            // TextBoxResult
            // 
            this.TextBoxResult.Location = new System.Drawing.Point(181, 32);
            this.TextBoxResult.Name = "TextBoxResult";
            this.TextBoxResult.ReadOnly = true;
            this.TextBoxResult.Size = new System.Drawing.Size(163, 406);
            this.TextBoxResult.TabIndex = 1;
            this.TextBoxResult.Text = "";
            // 
            // LabelSource
            // 
            this.LabelSource.AutoSize = true;
            this.LabelSource.Location = new System.Drawing.Point(13, 13);
            this.LabelSource.Name = "LabelSource";
            this.LabelSource.Size = new System.Drawing.Size(38, 13);
            this.LabelSource.TabIndex = 2;
            this.LabelSource.Text = "Слова";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Результат";
            // 
            // ButtonTask
            // 
            this.ButtonTask.Location = new System.Drawing.Point(361, 129);
            this.ButtonTask.Name = "ButtonTask";
            this.ButtonTask.Size = new System.Drawing.Size(88, 30);
            this.ButtonTask.TabIndex = 4;
            this.ButtonTask.Text = "Выполнить";
            this.ButtonTask.UseVisualStyleBackColor = true;
            this.ButtonTask.Click += new System.EventHandler(this.ButtonTask_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(361, 174);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(88, 30);
            this.ButtonClear.TabIndex = 5;
            this.ButtonClear.Text = "Очистить";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(361, 219);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(88, 30);
            this.ButtonExit.TabIndex = 6;
            this.ButtonExit.Text = "Выход";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(361, 84);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(88, 30);
            this.ButtonOpen.TabIndex = 7;
            this.ButtonOpen.Text = "Открыть файл";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 450);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LabelSource);
            this.Controls.Add(this.TextBoxResult);
            this.Controls.Add(this.TextBoxSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Алгоритм с возвратом";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBoxSource;
        private System.Windows.Forms.RichTextBox TextBoxResult;
        private System.Windows.Forms.Label LabelSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonTask;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonOpen;
    }
}

