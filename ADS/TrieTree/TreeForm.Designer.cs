using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TrieTree
{
    partial class TreeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

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
            this.TrieTreeView = new System.Windows.Forms.TreeView();
            this.ButtonFill = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonTask = new System.Windows.Forms.Button();
            this.LabelEnding = new System.Windows.Forms.Label();
            this.TextBoxEnding = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TrieTreeView
            // 
            this.TrieTreeView.Location = new System.Drawing.Point(18, 15);
            this.TrieTreeView.Name = "TrieTreeView";
            this.TrieTreeView.Size = new System.Drawing.Size(372, 454);
            this.TrieTreeView.TabIndex = 0;
            // 
            // ButtonFill
            // 
            this.ButtonFill.Location = new System.Drawing.Point(18, 489);
            this.ButtonFill.Name = "ButtonFill";
            this.ButtonFill.Size = new System.Drawing.Size(174, 25);
            this.ButtonFill.TabIndex = 1;
            this.ButtonFill.Text = "Заполнить";
            this.ButtonFill.UseVisualStyleBackColor = true;
            this.ButtonFill.Click += new System.EventHandler(this.ButtonFill_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(18, 534);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(174, 25);
            this.ButtonClear.TabIndex = 2;
            this.ButtonClear.Text = "Очистить";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonTask
            // 
            this.ButtonTask.Location = new System.Drawing.Point(216, 489);
            this.ButtonTask.Name = "ButtonTask";
            this.ButtonTask.Size = new System.Drawing.Size(174, 25);
            this.ButtonTask.TabIndex = 3;
            this.ButtonTask.Text = "Найти слова по окончанию";
            this.ButtonTask.UseVisualStyleBackColor = true;
            this.ButtonTask.Click += new System.EventHandler(this.ButtonTask_Click);
            // 
            // LabelEnding
            // 
            this.LabelEnding.AutoSize = true;
            this.LabelEnding.Location = new System.Drawing.Point(233, 521);
            this.LabelEnding.Name = "LabelEnding";
            this.LabelEnding.Size = new System.Drawing.Size(95, 13);
            this.LabelEnding.TabIndex = 5;
            this.LabelEnding.Text = "Окончание слова";
            // 
            // TextBoxEnding
            // 
            this.TextBoxEnding.Location = new System.Drawing.Point(216, 537);
            this.TextBoxEnding.Name = "TextBoxEnding";
            this.TextBoxEnding.Size = new System.Drawing.Size(174, 22);
            this.TextBoxEnding.TabIndex = 6;
            this.TextBoxEnding.Text = "";
            // 
            // TreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 580);
            this.Controls.Add(this.TextBoxEnding);
            this.Controls.Add(this.LabelEnding);
            this.Controls.Add(this.ButtonTask);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonFill);
            this.Controls.Add(this.TrieTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TreeForm";
            this.Text = "Сильно ветвящееся дерево";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView TrieTreeView;
        private Button ButtonFill;
        private Button ButtonClear;
        private Button ButtonTask;
        private Label LabelEnding;
        private RichTextBox TextBoxEnding;
    }
}

