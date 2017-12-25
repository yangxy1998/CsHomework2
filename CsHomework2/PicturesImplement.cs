using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using JiebaNet.Analyser;

namespace CsHomework2
{
    class PicturesImplement:Pictures
    {
        //各种颜色
        Brush[] brushes ={Brushes.AliceBlue,Brushes.AntiqueWhite,Brushes.Aqua,Brushes.Aquamarine,Brushes.Azure,
                             Brushes.Beige,Brushes.Bisque,Brushes.BlanchedAlmond,Brushes.Blue,Brushes.BlueViolet,
                             Brushes.Brown,Brushes.BurlyWood,Brushes.CadetBlue,Brushes.Chartreuse,Brushes.Chocolate,
                             Brushes.Coral,Brushes.CornflowerBlue,Brushes.Cornsilk,Brushes.Crimson,Brushes.Cyan,
                             Brushes.DarkBlue,Brushes.DarkCyan,Brushes.DarkGoldenrod,Brushes.DarkGray,Brushes.DarkGreen,
                             Brushes.DarkKhaki,Brushes.DarkMagenta,Brushes.DarkOliveGreen,Brushes.DarkOrange,Brushes.DarkOrchid,
                             Brushes.DarkRed,Brushes.DarkSalmon,Brushes.DarkSeaGreen,Brushes.DarkSlateBlue,Brushes.DarkSlateGray,
                             Brushes.DarkTurquoise,Brushes.DarkViolet,Brushes.DeepPink,Brushes.DeepSkyBlue,Brushes.DimGray,Brushes.DodgerBlue,
                             Brushes.Firebrick,Brushes.FloralWhite,Brushes.ForestGreen,Brushes.Fuchsia,Brushes.Gainsboro,Brushes.Gold,
                             Brushes.Goldenrod,Brushes.Gray,Brushes.Green,Brushes.GreenYellow,Brushes.Honeydew,Brushes.HotPink,Brushes.IndianRed,
                             Brushes.Indigo,Brushes.Ivory,Brushes.Khaki,Brushes.Lavender,Brushes.LavenderBlush,Brushes.LawnGreen,Brushes.LemonChiffon,
                             Brushes.LightBlue,Brushes.LightCoral,Brushes.LightCyan,Brushes.LightGoldenrodYellow,Brushes.LightGray,Brushes.LightGreen,
                             Brushes.LightPink,Brushes.LightSalmon,Brushes.LightSeaGreen,Brushes.LightSkyBlue,Brushes.LightSlateGray,Brushes.LightSteelBlue,
                             Brushes.LightYellow,Brushes.Lime,Brushes.LimeGreen,Brushes.Linen,Brushes.Magenta,Brushes.Maroon,Brushes.MediumAquamarine,
                             Brushes.MediumBlue,Brushes.MediumOrchid,Brushes.MediumPurple,Brushes.MediumSeaGreen,Brushes.MediumSlateBlue,Brushes.MediumSpringGreen,
                             Brushes.MediumTurquoise,Brushes.MediumVioletRed,Brushes.MidnightBlue,Brushes.MintCream,Brushes.MistyRose,Brushes.Moccasin,
                             Brushes.NavajoWhite,Brushes.Navy,Brushes.OldLace,Brushes.Olive,Brushes.OliveDrab,Brushes.Orange,Brushes.OrangeRed,Brushes.Orchid,
                             Brushes.PaleGoldenrod,Brushes.PaleGreen,Brushes.PaleTurquoise,Brushes.PaleVioletRed,Brushes.PapayaWhip,Brushes.PeachPuff,
                             Brushes.Peru,Brushes.Pink,Brushes.Plum,Brushes.PowderBlue,Brushes.Purple,Brushes.Red,Brushes.SeaShell,
                             Brushes.RosyBrown,Brushes.RoyalBlue,Brushes.SaddleBrown,Brushes.Salmon,Brushes.SandyBrown,Brushes.SeaGreen,
                             Brushes.Sienna,Brushes.Silver,Brushes.SkyBlue,Brushes.SlateBlue,Brushes.SlateGray,Brushes.Snow,Brushes.SpringGreen,
                             Brushes.SteelBlue,Brushes.Tan,Brushes.Teal,Brushes.Thistle,Brushes.Tomato,Brushes.Transparent,Brushes.Turquoise,
                             Brushes.Violet,Brushes.Wheat,Brushes.White,Brushes.WhiteSmoke,Brushes.Yellow,Brushes.YellowGreen
                        };
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
            Random rand = new Random();
            foreach (Company company in companies)
            {
                if (company.WorkCount < 2) continue;
                if (X >= 680)
                {
                    X = 20;
                    Y = 200;
                }
                int randomNumber = rand.Next(brushes.Length);
                Font font=new Font("宋体",9);
                //设置横轴公司名
                StringFormat strF = new StringFormat(StringFormatFlags.DirectionVertical);
                g.DrawString(company.CompanyName, font, Brushes.Black, X, Y, strF);
                //填充直方图
                g.FillRectangle(brushes[randomNumber], X + 4, Y - company.WorkCount, 12, company.WorkCount);
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
        Image Pictures.Get_PieGraph(Informations informations)
        {
            Bitmap image = new Bitmap(400, 300);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            double angle = 0;
            double totalangle = 0;
            Random rand=new Random();
            foreach (WordWeightPair wordweight in informations.KeyWords)
            {
                int randomNumber=rand.Next(brushes.Length);
                angle = wordweight.Weight * 360;
                g.FillPie(brushes[randomNumber], 220, 150, 120, 120, (int)totalangle, (int)angle);
                g.DrawPie(Pens.Black, 220, 150, 120, 120, (int)totalangle, (int)angle);
                totalangle += angle;
            }
            return image;
        }
    }
}
