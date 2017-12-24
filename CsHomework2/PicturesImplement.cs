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
        Graphics Pictures.Get_BarGraph(List<Company> companies)
        {
            int[] counts = new int[companies.Count];
            string[] names = new string[companies.Count];
            int height = 500, width = 700;
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            Pen mypen = new Pen(Brushes.Black, 1);
            g.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
            for (int i = 0, x = 36; i < companies.Count; i++)
            {
                g.DrawLine(mypen, x, 80, x, 340);
                x = x + 36;
            }
            for (int i = 0, y = 0; i < 20; i++)
            {
                Font font = new Font("宋体", 12);
                g.DrawString((i * 10).ToString(), font, Brushes.Black,10,400-y);
                g.DrawLine(mypen, 60, y, 620, y);
                y = y + 20;
            }
            int X = 36;
            foreach (Company company in companies)
            {
                Font font=new Font("宋体",12);
                g.DrawString(company.CompanyName, font, Brushes.Black, X, 400);
                g.FillRectangle(Brushes.Green, X, 400, 20, company.WorkCount*2);
                X += 36;
            }
            return g;
        }
        TreeView Pictures.Get_WorkAbilityTree(Informations informations)
        {
            TreeView treeview = null;
            return treeview;
        }
    }
}
