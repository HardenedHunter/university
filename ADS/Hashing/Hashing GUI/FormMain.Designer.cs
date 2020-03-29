namespace Hashing_GUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHashTable = new System.Windows.Forms.DataGridView();
            this.ButtonFill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHashTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHashTable
            // 
            this.dgvHashTable.AllowUserToAddRows = false;
            this.dgvHashTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHashTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHashTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHashTable.Location = new System.Drawing.Point(31, 45);
            this.dgvHashTable.Name = "dgvHashTable";
            this.dgvHashTable.RowHeadersVisible = false;
            this.dgvHashTable.Size = new System.Drawing.Size(330, 457);
            this.dgvHashTable.TabIndex = 0;
            // 
            // ButtonFill
            // 
            this.ButtonFill.Location = new System.Drawing.Point(420, 45);
            this.ButtonFill.Name = "ButtonFill";
            this.ButtonFill.Size = new System.Drawing.Size(75, 23);
            this.ButtonFill.TabIndex = 1;
            this.ButtonFill.Text = "Заполнить";
            this.ButtonFill.UseVisualStyleBackColor = true;
            this.ButtonFill.Click += new System.EventHandler(this.ButtonFill_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 576);
            this.Controls.Add(this.ButtonFill);
            this.Controls.Add(this.dgvHashTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Хеширование";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHashTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHashTable;
        private System.Windows.Forms.Button ButtonFill;
    }
}

