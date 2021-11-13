using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Chart
{
    public partial class BarChart : Form
    {
        public BarChart()
        {
            InitializeComponent();
            InitBar();
        }

        private void InitBar()
        {
            grBarchart.AutoGenerateColumns = false;

            double tongCong = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("THANG", typeof(string));
            dt.Columns.Add("DOANHSO", typeof(double));
            dt.Columns.Add("TONGCONG", typeof(int));
            Random rd = new Random();
            DataRow rNew;
            for (int i = 1; i <= 12; i++)
            {
                string name = "Tháng " + i;
                double val = InitValue(rd);

                if (i == 6 || i == 8) val = -val;
                if (i == 9) val = 0;

                rNew = dt.NewRow();
                rNew["THANG"] = name;
                rNew["DOANHSO"] = val;
                rNew["TONGCONG"] = 0;
                dt.Rows.Add(rNew);

                tongCong += val;
            }

            rNew = dt.NewRow();
            rNew["THANG"] = "TỔNG CỘNG";
            rNew["DOANHSO"] = tongCong;
            rNew["TONGCONG"] = 30;
            dt.Rows.Add(rNew);

            grBarchart.DataSource = dt;
            //custom column
            DataGridViewBarGraphColumn colButton = new DataGridViewBarGraphColumn();
            colButton.HeaderText = "Doanh Thu";
            colButton.DataPropertyName = "DOANHSO";
            grBarchart.Columns.RemoveAt(grBarchart.Columns.Count - 1);
            grBarchart.Columns.Add(colButton);
        }

        private double InitValue(Random rd)
        {
            double i = 0;
            while (i % 100000 != 0 || i == 0)
            {
                i = rd.Next(1000000, 1000000000);
            }
            return i;
        }
    }

    public class DataGridViewBarGraphColumn : DataGridViewColumn
    {
        public DataGridViewBarGraphColumn()
        {
            this.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.CellTemplate = new DataGridViewBarGraphCell();
            this.ReadOnly = true;
        }

        public long MaxValue;
        private bool needsRecalc = true;
        public decimal totalValue = 0;

        public void CalcMaxValue()
        {
            if (!needsRecalc) return;
            needsRecalc = false;

            totalValue = 0;
            int colIndex = 1;
            for (int rowIndex = 0; rowIndex < this.DataGridView.Rows.Count; rowIndex++)
            {
                DataGridViewRow row = this.DataGridView.Rows[rowIndex];

                bool tongCong = Convert.ToInt64((row.DataBoundItem as DataRowView).Row["TONGCONG"]) > 0;
                if (tongCong) continue;
                MaxValue = Math.Max(Math.Abs(MaxValue), Math.Abs(Convert.ToInt64(row.Cells[colIndex].Value)));
                totalValue += Convert.ToInt64(row.Cells[colIndex].Value);
            }
        }

        public bool hasTwoPanel = false;
        private bool needsReget = true;
        public void checkHasTwoPanel()
        {
            if (!needsReget) return;
            needsReget = false;
            bool Negative = false;
            bool Positive = false;
            for (int rowIndex = 0; rowIndex< this.DataGridView.Rows.Count; rowIndex++)
            {
                DataGridViewRow row = this.DataGridView.Rows[rowIndex];
                Int64 val = Convert.ToInt64(row.Cells[DisplayIndex].Value);
                if (val > 0) Positive = true;
                if (val< 0) Negative = true;
            }
            hasTwoPanel = Positive && Negative;
        }

        public float maxMarginLeft = 0;
        private bool needsReCalLeft = true;
        public void CalcMaxMarginLeft(Graphics gr, Font fnt)
        {
            if (!needsReCalLeft) return;
            needsReCalLeft = false;
            for (int rowIndex = 0; rowIndex < this.DataGridView.Rows.Count; rowIndex++)
            {
                DataGridViewRow row = this.DataGridView.Rows[rowIndex];
                bool tongCong = Convert.ToInt64((row.DataBoundItem as DataRowView).Row["TONGCONG"]) > 0;
                if (tongCong) continue;
                string text = Math.Round(Convert.ToInt64(row.Cells[DisplayIndex].Value) / totalValue * 100, 2) + "%";
                if (maxMarginLeft < gr.MeasureString(text, fnt).Width)
                {
                    maxMarginLeft = gr.MeasureString(text, fnt).Width + 5;
                }
            }
        }
    }

    public class DataGridViewBarGraphCell : DataGridViewTextBoxCell
    {
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, "", errorText, cellStyle, advancedBorderStyle, paintParts);

            decimal cellValue = 0;
            string cellText = "";
            if (Convert.IsDBNull(value))
            {
                cellValue = 0;
            }
            else
            {
                cellValue = Convert.ToDecimal(value);
            }

            DataGridViewBarGraphColumn parent = (DataGridViewBarGraphColumn)this.OwningColumn;
            parent.CalcMaxValue();
            long maxValue = parent.MaxValue;

            Font fnt = parent.InheritedStyle.Font;

            if (cellValue == parent.totalValue)
            {
                fnt = new Font(fnt.FontFamily, fnt.Size + 5, FontStyle.Bold);
            }

            SizeF maxValueSize = graphics.MeasureString(maxValue.ToString(), fnt);
            parent.checkHasTwoPanel();
            parent.CalcMaxMarginLeft(graphics, fnt);
            float availableWidth = (parent.hasTwoPanel ? cellBounds.Width / 2 : cellBounds.Width) - maxValueSize.Width - (parent.hasTwoPanel ? 2 : 1) * 20 - parent.maxMarginLeft;

            decimal cellValueText = Math.Abs(Convert.ToDecimal((Convert.ToDouble(cellValue) / maxValue) * availableWidth));

            const int VERTOFFSET = 4;
            float xPositionBarChart = cellBounds.X + (parent.hasTwoPanel ? cellBounds.Width / 2 : 0) + parent.maxMarginLeft - 5;
            if (parent.hasTwoPanel)
            {
                if (cellValue < 0 && parent.hasTwoPanel)
                {
                    xPositionBarChart = xPositionBarChart - Convert.ToSingle(cellValueText);
                }
            }

            //BartChart
            RectangleF newRect = new RectangleF(xPositionBarChart, cellBounds.Y + VERTOFFSET, Convert.ToSingle(cellValueText) , cellBounds.Height - (VERTOFFSET * 2));

            if (cellValue != parent.totalValue)
            {
                if (cellValue >= 0)
                {
                    graphics.FillRectangle(Brushes.Blue, newRect);
                }
                else
                {
                    graphics.FillRectangle(Brushes.Red, newRect);
                }
            }

            cellText = NumberToText(cellValue);
            SizeF textSize = graphics.MeasureString(cellText, fnt);
            //Giá trị căn phải hết
            float xPositonText = cellBounds.Width - textSize.Width + (float)(cellValue == 0 ? -2 : 0);
            PointF textStart = new PointF(xPositonText, (cellBounds.Height - textSize.Height) / 2);
            Color textColor = cellValue < 0 ? Color.Red : Color.Blue;
            using (SolidBrush brush = new SolidBrush(textColor))
            {
                graphics.DrawString(cellText, fnt, brush, cellBounds.X + textStart.X, cellBounds.Y + textStart.Y);
            }
            //Giá trị phần trăm
            cellText = Math.Round(cellValue / parent.totalValue * 100, 2) + "%";
            using (SolidBrush brush = new SolidBrush(textColor))
            {
                if (cellValue != parent.totalValue) graphics.DrawString(cellText, fnt, brush, cellBounds.X, cellBounds.Y + textStart.Y);
            }
        }

        private string NumberToText(decimal cellValue)
        {
            string startWith = cellValue < 0 ? "-" : "";
            string val = Math.Abs(cellValue).ToString("n2");
            return startWith + val + (cellValue != 0 ? " " : "");
        }
    }
}
