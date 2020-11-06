using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nutrition.Graphs
{
    public partial class Graph : Form
    {
        Random rand = new Random();
        public Graph()
        {
            InitializeComponent();
        }

        private void formsPlot2_Load(object sender, EventArgs e)
        {
            double[] values = { 778, 283, 184, 76, 43 };

            // plot the data
            formsPlot2.Reset();
            formsPlot2.plt.PlotPie(values, showValues: true, showPercentages: true);
            formsPlot2.plt.Frame(false);
            formsPlot2.plt.Grid(false);
            formsPlot2.plt.Ticks(false, false);
            formsPlot2.Render();
        }

        private void formsPlot3_Load(object sender, EventArgs e)
        {
            double[] ys = DataGen.RandomWalk(rand, 100);
            double[] xs = new double[ys.Length];

            DateTime dtStart = new DateTime(2020, 10, 10);
            for (int i = 0; i < ys.Length; i++)
            {
                DateTime dtNow = dtStart.AddDays(i);
                xs[i] = dtNow.ToOADate();
            }
            formsPlot3.plt.YLabel("Calories");
            formsPlot3.plt.PlotScatter(xs, ys);

            // define tick spacing as 1 day (every day will be shown)
            formsPlot3.plt.Grid(xSpacing: 1);
            formsPlot3.plt.Layout(xScaleHeight: 60);

            formsPlot3.plt.Ticks(dateTimeX: true);
            formsPlot3.Render();
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            int pointCount = 4;
            double[] ys1 = ScottPlot.DataGen.RandomWalk(rand, pointCount, mult: 50, offset: 100);
            double[] ys2 = ScottPlot.DataGen.RandomWalk(rand, pointCount, mult: 50, offset: 100);

            // collect the data into groups
            string[] groupLabels = { "Calories", "Fat", "Carbohydrates", "Protein"};
            string[] seriesLabels = { "Current", "Reccomended" };
            double[][] barHeights = { ys1, ys2 };

            // plot the data
            formsPlot1.Reset();
            formsPlot1.plt.PlotBarGroups(groupLabels, seriesLabels, barHeights);

            // additional styling
            formsPlot1.plt.Title("WOW GRAPH");
            //formsPlot1.plt.XLabel("Current vs Expected");
            formsPlot1.plt.YLabel("WOW VERTICAL BARS");
            formsPlot1.plt.Legend(location: ScottPlot.legendLocation.upperLeft);
            formsPlot1.plt.Axis(y1: 0);
            formsPlot1.Render();
        }
    }
}
