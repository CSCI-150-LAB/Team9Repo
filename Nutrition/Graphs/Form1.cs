using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LvChartTest
{
    public partial class Form1 : Form
    {
        Random e1 = new Random();
        public Form1()
        {
            InitializeComponent();

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 10),
                        new ObservablePoint(4,7),
                        new ObservablePoint(5,3),
                        new ObservablePoint(7,6)
                    },
                    PointGeometrySize = 10
                }
            };
        }

       private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Days",
                Labels = new[] { "Mon", "Tu", "Wed", "Th", "Fri", "Sat", "Sun" }
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Weight",
               // LabelFormatter = value => value.ToString("C")
            });
            cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;
        }


        private void LoadButton_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series.Clear();
            SeriesCollection series = new SeriesCollection();
            for (int i = 0; i < 2; i++)
            {
                List<double> values = new List<double>();
                for(int month = 1; month <= 12; month++)
                {
                    double value = e1.Next(0,12);
                    values.Add(value);
                }
                series.Add(new LineSeries() { Title = i.ToString(), Values = new ChartValues<double>(values) });
                cartesianChart1.Series = series;
            }

            //Fill the piechart and gauge
            pieChart1_ChildChanged(sender, null);
            solidGauge1_ChildChanged(sender, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Define a collection of items to display in the chart 
            SeriesCollection piechartData = new SeriesCollection
    {
        new PieSeries
        {
            Title = "First Item",
            Values = new ChartValues<double> {e1.Next(0,25)},
            DataLabels = true,
            LabelPoint = labelPoint
        },
        new PieSeries
        {
            Title = "Second Item",
            Values = new ChartValues<double> {e1.Next(0,25)},
            DataLabels = true,
            LabelPoint = labelPoint
        },
        new PieSeries
        {
            Title = "Third Item",
            Values = new ChartValues<double> {e1.Next(0,25)},
            DataLabels = true,
            LabelPoint = labelPoint
        }
    };
            piechartData.Add(
                new PieSeries
                {
                    Title = "Fourth Item",
                    Values = new ChartValues<double> { e1.Next(0, 25) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    Fill = System.Windows.Media.Brushes.Aqua
                }
            );

            // Define the collection of Values to display in the Pie Chart
            pieChart1.Series = piechartData;

            // Set the legend location to appear in the Right side of the chart
            pieChart1.LegendLocation = LegendLocation.Right;
        }

        private void solidGauge1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            solidGauge1.From = 0;
            solidGauge1.To = 100;
            solidGauge1.Value = Int32.Parse(e1.Next(0,99).ToString());
        }
    }
}
