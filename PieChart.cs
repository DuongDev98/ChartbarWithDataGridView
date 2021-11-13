using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Chart
{
    public partial class PieChart : Form
    {
        public PieChart()
        {
            InitializeComponent();
            SetUpPieChart();
        }

        private void SetUpPieChart()
        {
            Random rd = new Random();

            List<string> x = new List<string>();
            List<double> y = new List<double>();

            for (int i = 1; i <= 12; i++)
            {
                string name = "Tháng " + i;
                double val = InitValue(rd);

                x.Add(name);
                y.Add(val);
            }

            //init PieChart
            pieeChart.Series[0].ChartType = SeriesChartType.Pie;
            pieeChart.Series[0].Points.DataBindXY(x, y);
            pieeChart.Legends[0].Enabled = true;
            pieeChart.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private double InitValue(Random rd)
        {
            double i = 0;
            while (i % 100000 != 0 || i == 0)
            {
                i = rd.Next(1000000, 10000000);
            }
            return i;
        }
    }
}
