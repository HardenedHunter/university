namespace ExternalSorting
{
    partial class FormAddCountry
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelCapital = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.labelContinent = new System.Windows.Forms.Label();
            this.labelGovernment = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCapital = new System.Windows.Forms.TextBox();
            this.textBoxArea = new System.Windows.Forms.TextBox();
            this.comboBoxContinent = new System.Windows.Forms.ComboBox();
            this.comboBoxGovernment = new System.Windows.Forms.ComboBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelPopulation = new System.Windows.Forms.Label();
            this.textBoxPopulation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(30, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(57, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название";
            // 
            // labelCapital
            // 
            this.labelCapital.AutoSize = true;
            this.labelCapital.Location = new System.Drawing.Point(30, 73);
            this.labelCapital.Name = "labelCapital";
            this.labelCapital.Size = new System.Drawing.Size(49, 13);
            this.labelCapital.TabIndex = 1;
            this.labelCapital.Text = "Столица";
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Location = new System.Drawing.Point(30, 124);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(124, 13);
            this.labelArea.TabIndex = 2;
            this.labelArea.Text = "Площадь в млн. кв. км";
            // 
            // labelContinent
            // 
            this.labelContinent.AutoSize = true;
            this.labelContinent.Location = new System.Drawing.Point(30, 225);
            this.labelContinent.Name = "labelContinent";
            this.labelContinent.Size = new System.Drawing.Size(60, 13);
            this.labelContinent.TabIndex = 3;
            this.labelContinent.Text = "Континент";
            // 
            // labelGovernment
            // 
            this.labelGovernment.AutoSize = true;
            this.labelGovernment.Location = new System.Drawing.Point(30, 276);
            this.labelGovernment.Name = "labelGovernment";
            this.labelGovernment.Size = new System.Drawing.Size(129, 13);
            this.labelGovernment.TabIndex = 4;
            this.labelGovernment.Text = "Государственный строй";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(29, 39);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(215, 20);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxCapital
            // 
            this.textBoxCapital.Location = new System.Drawing.Point(29, 89);
            this.textBoxCapital.Name = "textBoxCapital";
            this.textBoxCapital.Size = new System.Drawing.Size(215, 20);
            this.textBoxCapital.TabIndex = 6;
            // 
            // textBoxArea
            // 
            this.textBoxArea.Location = new System.Drawing.Point(29, 140);
            this.textBoxArea.Name = "textBoxArea";
            this.textBoxArea.Size = new System.Drawing.Size(215, 20);
            this.textBoxArea.TabIndex = 7;
            // 
            // comboBoxContinent
            // 
            this.comboBoxContinent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContinent.FormattingEnabled = true;
            this.comboBoxContinent.Location = new System.Drawing.Point(29, 241);
            this.comboBoxContinent.Name = "comboBoxContinent";
            this.comboBoxContinent.Size = new System.Drawing.Size(215, 21);
            this.comboBoxContinent.TabIndex = 9;
            // 
            // comboBoxGovernment
            // 
            this.comboBoxGovernment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGovernment.FormattingEnabled = true;
            this.comboBoxGovernment.Location = new System.Drawing.Point(29, 292);
            this.comboBoxGovernment.Name = "comboBoxGovernment";
            this.comboBoxGovernment.Size = new System.Drawing.Size(215, 21);
            this.comboBoxGovernment.TabIndex = 10;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(97, 332);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 11;
            this.buttonSubmit.Text = "Готово";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // labelPopulation
            // 
            this.labelPopulation.AutoSize = true;
            this.labelPopulation.Location = new System.Drawing.Point(30, 176);
            this.labelPopulation.Name = "labelPopulation";
            this.labelPopulation.Size = new System.Drawing.Size(95, 13);
            this.labelPopulation.TabIndex = 2;
            this.labelPopulation.Text = "Население в млн";
            // 
            // textBoxPopulation
            // 
            this.textBoxPopulation.Location = new System.Drawing.Point(29, 192);
            this.textBoxPopulation.Name = "textBoxPopulation";
            this.textBoxPopulation.Size = new System.Drawing.Size(215, 20);
            this.textBoxPopulation.TabIndex = 8;
            // 
            // FormAddCountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 372);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.comboBoxGovernment);
            this.Controls.Add(this.comboBoxContinent);
            this.Controls.Add(this.textBoxPopulation);
            this.Controls.Add(this.textBoxArea);
            this.Controls.Add(this.textBoxCapital);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelGovernment);
            this.Controls.Add(this.labelContinent);
            this.Controls.Add(this.labelPopulation);
            this.Controls.Add(this.labelArea);
            this.Controls.Add(this.labelCapital);
            this.Controls.Add(this.labelName);
            this.Name = "FormAddCountry";
            this.Text = "Добавить страну";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCapital;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Label labelContinent;
        private System.Windows.Forms.Label labelGovernment;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCapital;
        private System.Windows.Forms.TextBox textBoxArea;
        private System.Windows.Forms.ComboBox comboBoxContinent;
        private System.Windows.Forms.ComboBox comboBoxGovernment;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelPopulation;
        private System.Windows.Forms.TextBox textBoxPopulation;
    }
}