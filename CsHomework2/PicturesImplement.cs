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
        Image Pictures.Get_BarGraph(List<Company> companies)
        {
            int[] counts = new int[companies.Count];
            string[] names = new string[companies.Count];
            int height = 500, width = 700;
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            Pen mypen = new Pen(Brushes.Black, 1);
            g.FillRectangle(Brushes.WhiteSmoke, 0, 0, width, height);
            for (int x = 20; x <= 700;)
            {
                g.DrawLine(mypen, x, 0, x, 200);
                g.DrawLine(mypen, x, 250, x, 450);
                x = x + 20;
            }
            for (int y = 0; y <= 200;)
            {
                Font font = new Font("宋体", 6);
                g.DrawString(y.ToString(), font, Brushes.Black, 10, 450 - y);
                g.DrawString(y.ToString(), font, Brushes.Black, 10, 200 - y);
                g.DrawLine(mypen, 20, y, 680, y);
                g.DrawLine(mypen, 20, 250 + y, 680, 250 + y);
                y = y + 20;
            }
            int X = 20;
            int Y = 450;
            foreach (Company company in companies)
            {
                if (company.WorkCount < 2) continue;
                if (X >= 680)
                {
                    X = 20;
                    Y = 200;
                }
                Font font=new Font("宋体",9);
                //设置横轴公司名
                StringFormat strF = new StringFormat(StringFormatFlags.DirectionVertical);
                g.DrawString(company.CompanyName, font, Brushes.Black, X, Y,strF);
                //填充直方图
                g.FillRectangle(Brushes.Green, X, Y - company.WorkCount, 12, company.WorkCount);
                g.DrawString(company.WorkCount.ToString(), font, Brushes.Black, X, Y - company.WorkCount-10);
                X += 20;
            }
            return image;
        }
        TreeView Pictures.Get_WorkAbilityTree(Informations informations)
        {
            TreeView treeview = null;
            return treeview;
        }
    }
}
