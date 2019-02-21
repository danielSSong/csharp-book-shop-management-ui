using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace BookShopManagement.UserControls
{
    public partial class UC_Home : UserControl
    {
        Random rand = new Random();

        public UC_Home()
        {
            InitializeComponent();

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 10),  //First Point of First Line
                        new ObservablePoint(4, 7),
                        new ObservablePoint(5, 3),
                        new ObservablePoint(7, 6),
                        new ObservablePoint(10, 8)
                    },
                    PointGeometrySize = 15
                },
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 4),  //First Point of First Line
                        new ObservablePoint(5, 5),
                        new ObservablePoint(7, 7),
                        new ObservablePoint(9, 8),
                        new ObservablePoint(10, 9)
                    },
                    PointGeometrySize = 15
                }
            };
        }

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);
        private void LoadChart()
        {
            var cnv = new LineSeries();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            foreach(var obj in data.Revenue)
            {
                series.Add(new PieSeries()
                {
                    Title = obj.Year.ToString(),
                    Values = new ChartValues<double> { obj.Total },
                    DataLabels = true,
                    LabelPoint = labelPoint
                });
            }
                pieChart1.Series = series;
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            pieChart1.LegendLocation = LegendLocation.Bottom;
        }
    }
}
