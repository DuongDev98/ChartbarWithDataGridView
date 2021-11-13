namespace Chart
{
    partial class BarChart
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
            this.grBarchart = new System.Windows.Forms.DataGridView();
            this.colThang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDoanhSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grBarchart)).BeginInit();
            this.SuspendLayout();
            // 
            // grBarchart
            // 
            this.grBarchart.AllowUserToAddRows = false;
            this.grBarchart.AllowUserToDeleteRows = false;
            this.grBarchart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grBarchart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colThang,
            this.colDoanhSo});
            this.grBarchart.Location = new System.Drawing.Point(12, 12);
            this.grBarchart.Name = "grBarchart";
            this.grBarchart.ReadOnly = true;
            this.grBarchart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grBarchart.Size = new System.Drawing.Size(776, 426);
            this.grBarchart.TabIndex = 0;
            // 
            // colThang
            // 
            this.colThang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colThang.DataPropertyName = "THANG";
            this.colThang.HeaderText = "Tháng";
            this.colThang.Name = "colThang";
            this.colThang.ReadOnly = true;
            this.colThang.Width = 63;
            // 
            // colDoanhSo
            // 
            this.colDoanhSo.DataPropertyName = "DOANHSO";
            this.colDoanhSo.HeaderText = "Doanh số";
            this.colDoanhSo.Name = "colDoanhSo";
            this.colDoanhSo.ReadOnly = true;
            // 
            // BarChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grBarchart);
            this.Name = "BarChart";
            this.Text = "BarChart";
            ((System.ComponentModel.ISupportInitialize)(this.grBarchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grBarchart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoanhSo;
    }
}