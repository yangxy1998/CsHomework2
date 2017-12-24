using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;

namespace CsHomework2
{
    public partial class Form1 : Form
    {
        GetInformations getinformations = new GetInformationsImplement();
        Pictures pictures=new PicturesImplement();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Informations[] informations = getinformations.GetInformationsFromFile("C:\\Users\\Administrator\\Desktop\\informations.txt");
            List<Company> companies = getinformations.Set_CompanyJobCount(informations);
            Graphics g = pictures.Get_BarGraph(companies);
            imageList1.Draw(g, 0, 0, 0);
        }
    }
}
