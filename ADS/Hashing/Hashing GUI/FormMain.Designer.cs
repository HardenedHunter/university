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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHashTable = new System.Windows.Forms.DataGridView();
            this.ButtonFill = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonFind = new System.Windows.Forms.Button();
            this.TextBoxCarNumber = new System.Windows.Forms.TextBox();
            this.LabelCarNumber = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHashTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHashTable
            // 
            this.dgvHashTable.AllowUserToAddRows = false;
            this.dgvHashTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHashTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHashTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHashTable.Location = new System.Drawing.Point(18, 17);
            this.dgvHashTable.Name = "dgvHashTable";
            this.dgvHashTable.RowHeadersVisible = false;
            this.dgvHashTable.Size = new System.Drawing.Size(403, 364);
            this.dgvHashTable.TabIndex = 0;
            // 
            // ButtonFill
            // 
            this.ButtonFill.Location = new System.Drawing.Point(446, 304);
            this.ButtonFill.Name = "ButtonFill";
            this.ButtonFill.Size = new System.Drawing.Size(121, 34);
            this.ButtonFill.TabIndex = 1;
            this.ButtonFill.Text = "Заполнить из файла";
            this.ButtonFill.UseVisualStyleBackColor = true;
            this.ButtonFill.Click += new System.EventHandler(this.ButtonFill_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(446, 205);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(121, 34);
            this.ButtonAdd.TabIndex = 2;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(446, 155);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(121, 34);
            this.ButtonDelete.TabIndex = 3;
            this.ButtonDelete.Text = "Удалить";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonFind
            // 
            this.ButtonFind.Location = new System.Drawing.Point(446, 106);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(121, 34);
            this.ButtonFind.TabIndex = 3;
            this.ButtonFind.Text = "Найти";
            this.ButtonFind.UseVisualStyleBackColor = true;
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // TextBoxCarNumber
            // 
            this.TextBoxCarNumber.Location = new System.Drawing.Point(446, 71);
            this.TextBoxCarNumber.Name = "TextBoxCarNumber";
            this.TextBoxCarNumber.Size = new System.Drawing.Size(121, 20);
            this.TextBoxCarNumber.TabIndex = 4;
            // 
            // LabelCarNumber
            // 
            this.LabelCarNumber.AutoSize = true;
            this.LabelCarNumber.Location = new System.Drawing.Point(453, 55);
            this.LabelCarNumber.Name = "LabelCarNumber";
            this.LabelCarNumber.Size = new System.Drawing.Size(105, 13);
            this.LabelCarNumber.TabIndex = 5;
            this.LabelCarNumber.Text = "Номер автомобиля";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(446, 255);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(121, 34);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 398);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.LabelCarNumber);
            this.Controls.Add(this.TextBoxCarNumber);
            this.Controls.Add(this.ButtonFind);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonFill);
            this.Controls.Add(this.dgvHashTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Хеширование";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHashTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHashTable;
        private System.Windows.Forms.Button ButtonFill;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonFind;
        private System.Windows.Forms.TextBox TextBoxCarNumber;
        private System.Windows.Forms.Label LabelCarNumber;
        private System.Windows.Forms.Button ButtonSave;
    }
}

