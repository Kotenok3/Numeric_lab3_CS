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
using lab3;


namespace Charts
{
    public partial class Form1 : Form
    {
        static (double, double) GetMaxMin(Func<double, double,double,bool, double[]> fun)
        {
            double max = 0, min=1000;
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                double x0 = -(r.NextDouble() % 0.8);
                double y0 = -((r.Next(-2, 4) + r.NextDouble()) % 0.5);
                var p = fun(x0, y0, 0.0001, false);
                if (p[2] > max) max = p[2];
                if (p[2] < min) min = p[2];
            }

            return (max, min);
        }

        public static Series[] MinFunDescentGraph(Func<double, double,double,bool, double[]> fun)
        {
            var seriesR = new Series() { ChartType = SeriesChartType.Point, MarkerStyle = MarkerStyle.Circle, Color = Color.Red};
            var seriesG = new Series() { ChartType = SeriesChartType.Point, MarkerStyle = MarkerStyle.Circle, Color = Color.Green };
            var seriesB = new Series() { ChartType = SeriesChartType.Point, MarkerStyle = MarkerStyle.Circle, Color = Color.Navy };
            var (max, min) = GetMaxMin(fun);
            for (double x0 = -0.8; x0 < 0; x0 += 0.01)
            {
                for (double y0 = -3.5; y0 < -1.5; y0 += 0.02)
                {
                    var p = fun(x0, y0, 0.0001, false);
                    var mark = (max - p[2]) / (max - min) * 300;
                    if (p[2] < 100) seriesG.Points.AddXY(p[0], p[1]);
                    else if (p[2] < 200) seriesB.Points.AddXY(p[0], p[1]);
                    else seriesR.Points.AddXY(p[0], p[1]);
                }
            }
            return new []{seriesB,seriesR,seriesG};
        }
        
        public Form1()
        {
            InitializeComponent();
            Func<double, double> function = x => Math.Exp(x);
            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            var ser = MinFunDescentGraph(MultiMinFun.MinFunConjugateGradient);
            foreach (var s in ser)
                chart.Series.Add(s);
            
            chart.Dock = DockStyle.Fill;
            Controls.Add(chart);

        }
    }
}