namespace Tree_GUI
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.textBoxAdd = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxDelete = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.radioLinked = new System.Windows.Forms.RadioButton();
            this.radioArray = new System.Windows.Forms.RadioButton();
            this.groupBoxImplementation = new System.Windows.Forms.GroupBox();
            this.groupBoxMainFunctions = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonFactor = new System.Windows.Forms.Button();
            this.textBoxFactor = new System.Windows.Forms.TextBox();
            this.buttonSortEven = new System.Windows.Forms.Button();
            this.buttonSortOdd = new System.Windows.Forms.Button();
            this.groupBoxUtils = new System.Windows.Forms.GroupBox();
            this.buttonMakeImmutable = new System.Windows.Forms.Button();
            this.buttonDataSet = new System.Windows.Forms.Button();
            this.groupBoxImplementation.SuspendLayout();
            this.groupBoxMainFunctions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxUtils.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(21, 51);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(128, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panelCanvas
            // 
            this.panelCanvas.Location = new System.Drawing.Point(12, 26);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(913, 512);
            this.panelCanvas.TabIndex = 0;
            this.panelCanvas.TabStop = true;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            // 
            // textBoxAdd
            // 
            this.textBoxAdd.Location = new System.Drawing.Point(21, 25);
            this.textBoxAdd.Name = "textBoxAdd";
            this.textBoxAdd.Size = new System.Drawing.Size(128, 20);
            this.textBoxAdd.TabIndex = 2;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(21, 116);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(128, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxDelete
            // 
            this.textBoxDelete.Location = new System.Drawing.Point(21, 90);
            this.textBoxDelete.Name = "textBoxDelete";
            this.textBoxDelete.Size = new System.Drawing.Size(128, 20);
            this.textBoxDelete.TabIndex = 4;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(21, 155);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(128, 23);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Очистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // radioLinked
            // 
            this.radioLinked.AutoSize = true;
            this.radioLinked.Location = new System.Drawing.Point(25, 29);
            this.radioLinked.Name = "radioLinked";
            this.radioLinked.Size = new System.Drawing.Size(117, 17);
            this.radioLinked.TabIndex = 7;
            this.radioLinked.TabStop = true;
            this.radioLinked.Text = "На основе списка";
            this.radioLinked.UseVisualStyleBackColor = true;
            // 
            // radioArray
            // 
            this.radioArray.AutoSize = true;
            this.radioArray.Location = new System.Drawing.Point(25, 52);
            this.radioArray.Name = "radioArray";
            this.radioArray.Size = new System.Drawing.Size(125, 17);
            this.radioArray.TabIndex = 8;
            this.radioArray.TabStop = true;
            this.radioArray.Text = "На основе массива";
            this.radioArray.UseVisualStyleBackColor = true;
            // 
            // groupBoxImplementation
            // 
            this.groupBoxImplementation.Controls.Add(this.radioArray);
            this.groupBoxImplementation.Controls.Add(this.radioLinked);
            this.groupBoxImplementation.Location = new System.Drawing.Point(949, 336);
            this.groupBoxImplementation.Name = "groupBoxImplementation";
            this.groupBoxImplementation.Size = new System.Drawing.Size(168, 91);
            this.groupBoxImplementation.TabIndex = 10;
            this.groupBoxImplementation.TabStop = false;
            this.groupBoxImplementation.Text = "Представление";
            // 
            // groupBoxMainFunctions
            // 
            this.groupBoxMainFunctions.Controls.Add(this.buttonAdd);
            this.groupBoxMainFunctions.Controls.Add(this.buttonDelete);
            this.groupBoxMainFunctions.Controls.Add(this.buttonClear);
            this.groupBoxMainFunctions.Controls.Add(this.textBoxDelete);
            this.groupBoxMainFunctions.Controls.Add(this.textBoxAdd);
            this.groupBoxMainFunctions.Location = new System.Drawing.Point(949, 26);
            this.groupBoxMainFunctions.Name = "groupBoxMainFunctions";
            this.groupBoxMainFunctions.Size = new System.Drawing.Size(168, 195);
            this.groupBoxMainFunctions.TabIndex = 11;
            this.groupBoxMainFunctions.TabStop = false;
            this.groupBoxMainFunctions.Text = "Основные функции";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonFactor);
            this.groupBox1.Controls.Add(this.textBoxFactor);
            this.groupBox1.Location = new System.Drawing.Point(949, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 90);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Степень ветвления";
            // 
            // buttonFactor
            // 
            this.buttonFactor.Location = new System.Drawing.Point(21, 51);
            this.buttonFactor.Name = "buttonFactor";
            this.buttonFactor.Size = new System.Drawing.Size(128, 23);
            this.buttonFactor.TabIndex = 6;
            this.buttonFactor.Text = "Изменить";
            this.buttonFactor.UseVisualStyleBackColor = true;
            this.buttonFactor.Click += new System.EventHandler(this.buttonFactor_Click);
            // 
            // textBoxFactor
            // 
            this.textBoxFactor.Location = new System.Drawing.Point(21, 25);
            this.textBoxFactor.Name = "textBoxFactor";
            this.textBoxFactor.Size = new System.Drawing.Size(128, 20);
            this.textBoxFactor.TabIndex = 0;
            // 
            // buttonSortEven
            // 
            this.buttonSortEven.Location = new System.Drawing.Point(21, 31);
            this.buttonSortEven.Name = "buttonSortEven";
            this.buttonSortEven.Size = new System.Drawing.Size(128, 23);
            this.buttonSortEven.TabIndex = 13;
            this.buttonSortEven.Text = "Оставить чётные";
            this.buttonSortEven.UseVisualStyleBackColor = true;
            this.buttonSortEven.Click += new System.EventHandler(this.buttonSortEven_Click);
            // 
            // buttonSortOdd
            // 
            this.buttonSortOdd.Location = new System.Drawing.Point(21, 60);
            this.buttonSortOdd.Name = "buttonSortOdd";
            this.buttonSortOdd.Size = new System.Drawing.Size(128, 23);
            this.buttonSortOdd.TabIndex = 14;
            this.buttonSortOdd.Text = "Оставить нечётные";
            this.buttonSortOdd.UseVisualStyleBackColor = true;
            this.buttonSortOdd.Click += new System.EventHandler(this.buttonSortOdd_Click);
            // 
            // groupBoxUtils
            // 
            this.groupBoxUtils.Controls.Add(this.buttonMakeImmutable);
            this.groupBoxUtils.Controls.Add(this.buttonDataSet);
            this.groupBoxUtils.Controls.Add(this.buttonSortOdd);
            this.groupBoxUtils.Controls.Add(this.buttonSortEven);
            this.groupBoxUtils.Location = new System.Drawing.Point(949, 438);
            this.groupBoxUtils.Name = "groupBoxUtils";
            this.groupBoxUtils.Size = new System.Drawing.Size(168, 158);
            this.groupBoxUtils.TabIndex = 15;
            this.groupBoxUtils.TabStop = false;
            this.groupBoxUtils.Text = "Утилиты";
            // 
            // buttonMakeImmutable
            // 
            this.buttonMakeImmutable.Location = new System.Drawing.Point(21, 118);
            this.buttonMakeImmutable.Name = "buttonMakeImmutable";
            this.buttonMakeImmutable.Size = new System.Drawing.Size(128, 23);
            this.buttonMakeImmutable.TabIndex = 16;
            this.buttonMakeImmutable.Text = "Запретить изменения";
            this.buttonMakeImmutable.UseVisualStyleBackColor = true;
            this.buttonMakeImmutable.Click += new System.EventHandler(this.buttonMakeImmutable_Click);
            // 
            // buttonDataSet
            // 
            this.buttonDataSet.Location = new System.Drawing.Point(21, 89);
            this.buttonDataSet.Name = "buttonDataSet";
            this.buttonDataSet.Size = new System.Drawing.Size(128, 23);
            this.buttonDataSet.TabIndex = 15;
            this.buttonDataSet.Text = "Заполнить данными";
            this.buttonDataSet.UseVisualStyleBackColor = true;
            this.buttonDataSet.Click += new System.EventHandler(this.buttonDataSet_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1145, 653);
            this.Controls.Add(this.groupBoxUtils);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxMainFunctions);
            this.Controls.Add(this.groupBoxImplementation);
            this.Controls.Add(this.panelCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "View";
            this.Text = "Б+ дерево";
            this.groupBoxImplementation.ResumeLayout(false);
            this.groupBoxImplementation.PerformLayout();
            this.groupBoxMainFunctions.ResumeLayout(false);
            this.groupBoxMainFunctions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxUtils.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.TextBox textBoxAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxDelete;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.RadioButton radioLinked;
        private System.Windows.Forms.RadioButton radioArray;
        private System.Windows.Forms.GroupBox groupBoxImplementation;
        private System.Windows.Forms.GroupBox groupBoxMainFunctions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonFactor;
        private System.Windows.Forms.TextBox textBoxFactor;
        private System.Windows.Forms.Button buttonSortEven;
        private System.Windows.Forms.Button buttonSortOdd;
        private System.Windows.Forms.GroupBox groupBoxUtils;
        private System.Windows.Forms.Button buttonDataSet;
        private System.Windows.Forms.Button buttonMakeImmutable;
    }
}

