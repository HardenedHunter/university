namespace Hashing_GUI
{
    partial class FormAddCarInfo
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
            this.TextBoxCarNumber = new System.Windows.Forms.TextBox();
            this.TextBoxCarModel = new System.Windows.Forms.TextBox();
            this.TextBoxCarOwner = new System.Windows.Forms.TextBox();
            this.LabelCarNumber = new System.Windows.Forms.Label();
            this.LabelCarModel = new System.Windows.Forms.Label();
            this.LabelCarOwner = new System.Windows.Forms.Label();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBoxCarNumber
            // 
            this.TextBoxCarNumber.Location = new System.Drawing.Point(40, 43);
            this.TextBoxCarNumber.Name = "TextBoxCarNumber";
            this.TextBoxCarNumber.Size = new System.Drawing.Size(190, 20);
            this.TextBoxCarNumber.TabIndex = 0;
            // 
            // TextBoxCarModel
            // 
            this.TextBoxCarModel.Location = new System.Drawing.Point(40, 87);
            this.TextBoxCarModel.Name = "TextBoxCarModel";
            this.TextBoxCarModel.Size = new System.Drawing.Size(190, 20);
            this.TextBoxCarModel.TabIndex = 0;
            // 
            // TextBoxCarOwner
            // 
            this.TextBoxCarOwner.Location = new System.Drawing.Point(40, 131);
            this.TextBoxCarOwner.Name = "TextBoxCarOwner";
            this.TextBoxCarOwner.Size = new System.Drawing.Size(190, 20);
            this.TextBoxCarOwner.TabIndex = 0;
            // 
            // LabelCarNumber
            // 
            this.LabelCarNumber.AutoSize = true;
            this.LabelCarNumber.Location = new System.Drawing.Point(40, 24);
            this.LabelCarNumber.Name = "LabelCarNumber";
            this.LabelCarNumber.Size = new System.Drawing.Size(105, 13);
            this.LabelCarNumber.TabIndex = 1;
            this.LabelCarNumber.Text = "Номер автомобиля";
            // 
            // LabelCarModel
            // 
            this.LabelCarModel.AutoSize = true;
            this.LabelCarModel.Location = new System.Drawing.Point(40, 71);
            this.LabelCarModel.Name = "LabelCarModel";
            this.LabelCarModel.Size = new System.Drawing.Size(46, 13);
            this.LabelCarModel.TabIndex = 1;
            this.LabelCarModel.Text = "Модель";
            // 
            // LabelCarOwner
            // 
            this.LabelCarOwner.AutoSize = true;
            this.LabelCarOwner.Location = new System.Drawing.Point(40, 115);
            this.LabelCarOwner.Name = "LabelCarOwner";
            this.LabelCarOwner.Size = new System.Drawing.Size(91, 13);
            this.LabelCarOwner.TabIndex = 1;
            this.LabelCarOwner.Text = "ФИО владельца";
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.Location = new System.Drawing.Point(95, 168);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(75, 23);
            this.ButtonSubmit.TabIndex = 2;
            this.ButtonSubmit.Text = "Готово";
            this.ButtonSubmit.UseVisualStyleBackColor = true;
            this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // FormAddCarInfo
            // 
            this.AcceptButton = this.ButtonSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 213);
            this.Controls.Add(this.ButtonSubmit);
            this.Controls.Add(this.LabelCarOwner);
            this.Controls.Add(this.LabelCarModel);
            this.Controls.Add(this.LabelCarNumber);
            this.Controls.Add(this.TextBoxCarOwner);
            this.Controls.Add(this.TextBoxCarModel);
            this.Controls.Add(this.TextBoxCarNumber);
            this.Name = "FormAddCarInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить информацию";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxCarNumber;
        private System.Windows.Forms.TextBox TextBoxCarModel;
        private System.Windows.Forms.TextBox TextBoxCarOwner;
        private System.Windows.Forms.Label LabelCarNumber;
        private System.Windows.Forms.Label LabelCarModel;
        private System.Windows.Forms.Label LabelCarOwner;
        private System.Windows.Forms.Button ButtonSubmit;
    }
}