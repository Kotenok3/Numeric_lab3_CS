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
using Microsoft.VisualBasic;


namespace Charts
{
    public partial class Form1 : Form
    {
        static (double, double) GetMaxMin(Func<Func<double[], double>,double, double,double,double,bool, double[]> method,
            Func<double[], double> fun,(double,double) x, (double,double) y,double parametr = 10)
        {
            double max = 0, min = Int32.MaxValue;
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                
                double x0 = (r.Next(Convert.ToInt32(x.Item1),Convert.ToInt32(x.Item2)) + r.NextDouble());
                double y0 = (r.Next(Convert.ToInt32(y.Item1),Convert.ToInt32(y.Item2)) + r.NextDouble());
                var p = method(fun,x0, y0, 0.0001,parametr, false);
                if (p[2] > max) max = p[2];
                if (p[2] < min) min = p[2];
            }

            return (max, min);
        }

        public static Series[] MinFunDescentGraph(Func<Func<double[], double>,double, double,double,double,bool, double[]> method,
            Func<double[], double> fun, (double,double) x, (double,double) y,double step = 0.01, double parametr = 10)
        {
            var seriesR = new Series() { ChartType = SeriesChartType.Point, MarkerStyle = MarkerStyle.Circle, Color = Color.Red};
            var seriesG = new Series() { ChartType = SeriesChartType.Point, MarkerStyle = MarkerStyle.Circle, Color = Color.Green };
            var seriesB = new Series() { ChartType = SeriesChartType.Point, MarkerStyle = MarkerStyle.Circle, Color = Color.Navy };
            var (max, min) = GetMaxMin(method, fun, x, y);
            for (double x0 = x.Item1; x0 < x.Item2; x0 += step)
            {
                for (double y0 = y.Item1; y0 < y.Item2; y0 += step)
                {
                    var p = method(fun,x0, y0, 0.0001,parametr, false);
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

            var valueFunAX = (-0.8, 0.0);
            var valueFunAY = (-3.5,-1.5);
            var valueFunB = (-10, 10);
            
            
            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            var ser = MinFunDescentGraph(MultiMinFun.ConjugateGradient, Fun.B, valueFunB, valueFunB,0.2,50);
            foreach (var s in ser)
                chart.Series.Add(s);
            
            chart.Dock = DockStyle.Fill;
            Controls.Add(chart);

        }
    }
}