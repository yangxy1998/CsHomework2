using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace CsHomework2
{
    class PicturesImplement:Pictures
    {
        Chart Pictures.Get_BarGraph(List<Company> companies)
        {
            int[] counts = new int[companies.Count];
            string[] names = new string[companies.Count];
            int i = 0;
            foreach (Company company in companies)
            {
                counts[i] = company.WorkCount;
                names[i] = company.CompanyName;
                i++;
            }
            Chart chart = new Chart();
            chart.Width = 800;
            chart.Height = 600;
            chart.BackColor = Color.White;
            chart.Name = "柱状图表";
            chart.Palette = ChartColorPalette.BrightPastel;

            ChartArea chartArea = new ChartArea("ChartArea1");
            chartArea.BorderDashStyle = ChartDashStyle.Solid;
            chartArea.BackColor = Color.WhiteSmoke;     
            chartArea.ShadowColor = Color.FromArgb(0, 0, 0, 0);
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;//设置网格为虚线
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas.Add(chartArea);
            
            Series series = new Series("各公司岗位数目");
            series.ChartArea = "ChartArea1";
            series.ChartType = SeriesChartType.Column;//柱状图
            series.YValueType = ChartValueType.Double;
            series.LabelFormat = "0.ms";
            series.XValueType = ChartValueType.Auto;
            series.ShadowColor = Color.Black;
            series.CustomProperties = "DrawingStyle=Emboss";
            chart.Series.Add(series);

            for (i = 0; i < companies.Count; i++)
            {

            }
            int width = 700, height = 700;
            return chart;
        }
        TreeView Pictures.Get_WorkAbilityTree(Informations informations)
        {
            TreeView treeview = null;
            return treeview;
        }
    }
}
