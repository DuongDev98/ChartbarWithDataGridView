﻿namespace Chart
{
    partial class PieChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pieeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pieeChart)).BeginInit();
            this.SuspendLayout();
            // 
            // pieeChart
            // 
            chartArea1.Name = "ChartArea1";
            this.pieeChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.pieeChart.Legends.Add(legend1);
            this.pieeChart.Location = new System.Drawing.Point(0, 0);
            this.pieeChart.Name = "pieeChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.pieeChart.Series.Add(series1);
            this.pieeChart.Size = new System.Drawing.Size(755, 445);
            this.pieeChart.TabIndex = 0;
            this.pieeChart.Text = "chart1";
            // 
            // PieChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 445);
            this.Controls.Add(this.pieeChart);
            this.Name = "PieChart";
            this.Text = "PieChart";
            ((System.ComponentModel.ISupportInitialize)(this.pieeChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart pieeChart;
    }
}