namespace RadixSort
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea22 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend22 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series43 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series44 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea23 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend23 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series45 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series46 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea24 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend24 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series47 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series48 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartSmall = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.chartMedium = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLarge = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSmallSet = new System.Windows.Forms.Button();
            this.buttonMediumSet = new System.Windows.Forms.Button();
            this.buttonLargeSet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartSmall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMedium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // chartSmall
            // 
            chartArea22.Name = "ChartArea1";
            this.chartSmall.ChartAreas.Add(chartArea22);
            legend22.Name = "Legend1";
            this.chartSmall.Legends.Add(legend22);
            this.chartSmall.Location = new System.Drawing.Point(12, 12);
            this.chartSmall.Name = "chartSmall";
            series43.BorderWidth = 3;
            series43.ChartArea = "ChartArea1";
            series43.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series43.LabelBorderWidth = 3;
            series43.Legend = "Legend1";
            series43.Name = "Десятичная";
            series43.YValuesPerPoint = 3;
            series44.BorderWidth = 3;
            series44.ChartArea = "ChartArea1";
            series44.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series44.LabelBorderWidth = 3;
            series44.Legend = "Legend1";
            series44.Name = "Двоичная";
            this.chartSmall.Series.Add(series43);
            this.chartSmall.Series.Add(series44);
            this.chartSmall.Size = new System.Drawing.Size(776, 199);
            this.chartSmall.TabIndex = 0;
            this.chartSmall.Text = "chart1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(648, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 99);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество доступов к массиву (на запись и чтение) для сортировок в различных сис" +
    "темах счисления";
            // 
            // chartMedium
            // 
            chartArea23.Name = "ChartArea1";
            this.chartMedium.ChartAreas.Add(chartArea23);
            legend23.Name = "Legend1";
            this.chartMedium.Legends.Add(legend23);
            this.chartMedium.Location = new System.Drawing.Point(12, 226);
            this.chartMedium.Name = "chartMedium";
            series45.BorderWidth = 3;
            series45.ChartArea = "ChartArea1";
            series45.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series45.LabelBorderWidth = 3;
            series45.Legend = "Legend1";
            series45.Name = "Десятичная";
            series45.YValuesPerPoint = 3;
            series46.BorderWidth = 3;
            series46.ChartArea = "ChartArea1";
            series46.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series46.LabelBorderWidth = 3;
            series46.Legend = "Legend1";
            series46.Name = "Двоичная";
            this.chartMedium.Series.Add(series45);
            this.chartMedium.Series.Add(series46);
            this.chartMedium.Size = new System.Drawing.Size(776, 199);
            this.chartMedium.TabIndex = 0;
            this.chartMedium.Text = "chart1";
            // 
            // chartLarge
            // 
            chartArea24.Name = "ChartArea1";
            this.chartLarge.ChartAreas.Add(chartArea24);
            legend24.Name = "Legend1";
            this.chartLarge.Legends.Add(legend24);
            this.chartLarge.Location = new System.Drawing.Point(12, 440);
            this.chartLarge.Name = "chartLarge";
            series47.BorderWidth = 3;
            series47.ChartArea = "ChartArea1";
            series47.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series47.LabelBorderWidth = 3;
            series47.Legend = "Legend1";
            series47.Name = "Десятичная";
            series47.YValuesPerPoint = 3;
            series48.BorderWidth = 3;
            series48.ChartArea = "ChartArea1";
            series48.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series48.LabelBorderWidth = 3;
            series48.Legend = "Legend1";
            series48.Name = "Двоичная";
            this.chartLarge.Series.Add(series47);
            this.chartLarge.Series.Add(series48);
            this.chartLarge.Size = new System.Drawing.Size(776, 199);
            this.chartLarge.TabIndex = 0;
            this.chartLarge.Text = "chart1";
            // 
            // buttonSmallSet
            // 
            this.buttonSmallSet.Location = new System.Drawing.Point(651, 155);
            this.buttonSmallSet.Name = "buttonSmallSet";
            this.buttonSmallSet.Size = new System.Drawing.Size(116, 23);
            this.buttonSmallSet.TabIndex = 2;
            this.buttonSmallSet.Text = "Обновить";
            this.buttonSmallSet.UseVisualStyleBackColor = true;
            this.buttonSmallSet.Click += new System.EventHandler(this.buttonSmallSet_Click);
            // 
            // buttonMediumSet
            // 
            this.buttonMediumSet.Location = new System.Drawing.Point(651, 370);
            this.buttonMediumSet.Name = "buttonMediumSet";
            this.buttonMediumSet.Size = new System.Drawing.Size(116, 23);
            this.buttonMediumSet.TabIndex = 3;
            this.buttonMediumSet.Text = "Обновить";
            this.buttonMediumSet.UseVisualStyleBackColor = true;
            this.buttonMediumSet.Click += new System.EventHandler(this.buttonMediumSet_Click);
            // 
            // buttonLargeSet
            // 
            this.buttonLargeSet.Location = new System.Drawing.Point(651, 582);
            this.buttonLargeSet.Name = "buttonLargeSet";
            this.buttonLargeSet.Size = new System.Drawing.Size(116, 23);
            this.buttonLargeSet.TabIndex = 4;
            this.buttonLargeSet.Text = "Обновить";
            this.buttonLargeSet.UseVisualStyleBackColor = true;
            this.buttonLargeSet.Click += new System.EventHandler(this.buttonLargeSet_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(648, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 74);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество доступов к массиву (на запись и чтение) для сортировок в различных сис" +
    "темах счисления";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(648, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 74);
            this.label3.TabIndex = 1;
            this.label3.Text = "Количество доступов к массиву (на запись и чтение) для сортировок в различных сис" +
    "темах счисления";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 653);
            this.Controls.Add(this.buttonLargeSet);
            this.Controls.Add(this.buttonMediumSet);
            this.Controls.Add(this.buttonSmallSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartMedium);
            this.Controls.Add(this.chartLarge);
            this.Controls.Add(this.chartSmall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Поразрядная сортировка";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartSmall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMedium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLarge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSmall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMedium;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLarge;
        private System.Windows.Forms.Button buttonSmallSet;
        private System.Windows.Forms.Button buttonMediumSet;
        private System.Windows.Forms.Button buttonLargeSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

