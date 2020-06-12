namespace Modeling
{
    partial class View
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.richTextBoxCommittee = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDispatcher = new System.Windows.Forms.RichTextBox();
            this.labelDispatcher = new System.Windows.Forms.Label();
            this.labelCommittee = new System.Windows.Forms.Label();
            this.richTextBoxDepartments = new System.Windows.Forms.RichTextBox();
            this.labelDepartments = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(545, 435);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(124, 43);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // richTextBoxCommittee
            // 
            this.richTextBoxCommittee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxCommittee.Location = new System.Drawing.Point(25, 65);
            this.richTextBoxCommittee.Name = "richTextBoxCommittee";
            this.richTextBoxCommittee.Size = new System.Drawing.Size(369, 338);
            this.richTextBoxCommittee.TabIndex = 3;
            this.richTextBoxCommittee.Text = "";
            // 
            // richTextBoxDispatcher
            // 
            this.richTextBoxDispatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxDispatcher.Location = new System.Drawing.Point(413, 65);
            this.richTextBoxDispatcher.Name = "richTextBoxDispatcher";
            this.richTextBoxDispatcher.Size = new System.Drawing.Size(369, 338);
            this.richTextBoxDispatcher.TabIndex = 3;
            this.richTextBoxDispatcher.Text = "";
            // 
            // labelDispatcher
            // 
            this.labelDispatcher.AutoSize = true;
            this.labelDispatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDispatcher.Location = new System.Drawing.Point(550, 27);
            this.labelDispatcher.Name = "labelDispatcher";
            this.labelDispatcher.Size = new System.Drawing.Size(109, 24);
            this.labelDispatcher.TabIndex = 4;
            this.labelDispatcher.Text = "Диспетчер";
            // 
            // labelCommittee
            // 
            this.labelCommittee.AutoSize = true;
            this.labelCommittee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCommittee.Location = new System.Drawing.Point(139, 27);
            this.labelCommittee.Name = "labelCommittee";
            this.labelCommittee.Size = new System.Drawing.Size(135, 24);
            this.labelCommittee.TabIndex = 4;
            this.labelCommittee.Text = "Приём заявок";
            // 
            // richTextBoxDepartments
            // 
            this.richTextBoxDepartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxDepartments.Location = new System.Drawing.Point(801, 65);
            this.richTextBoxDepartments.Name = "richTextBoxDepartments";
            this.richTextBoxDepartments.Size = new System.Drawing.Size(369, 338);
            this.richTextBoxDepartments.TabIndex = 3;
            this.richTextBoxDepartments.Text = "";
            // 
            // labelDepartments
            // 
            this.labelDepartments.AutoSize = true;
            this.labelDepartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDepartments.Location = new System.Drawing.Point(935, 27);
            this.labelDepartments.Name = "labelDepartments";
            this.labelDepartments.Size = new System.Drawing.Size(81, 24);
            this.labelDepartments.TabIndex = 4;
            this.labelDepartments.Text = "Отделы";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 507);
            this.Controls.Add(this.labelCommittee);
            this.Controls.Add(this.labelDepartments);
            this.Controls.Add(this.labelDispatcher);
            this.Controls.Add(this.richTextBoxDispatcher);
            this.Controls.Add(this.richTextBoxDepartments);
            this.Controls.Add(this.richTextBoxCommittee);
            this.Controls.Add(this.buttonStart);
            this.Name = "View";
            this.Text = "Модель";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RichTextBox richTextBoxCommittee;
        private System.Windows.Forms.RichTextBox richTextBoxDispatcher;
        private System.Windows.Forms.Label labelDispatcher;
        private System.Windows.Forms.Label labelCommittee;
        private System.Windows.Forms.RichTextBox richTextBoxDepartments;
        private System.Windows.Forms.Label labelDepartments;
    }
}

