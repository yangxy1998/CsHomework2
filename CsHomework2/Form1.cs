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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] htmls = getinformations.GetHtml();
            Informations[] informatios = getinformations.GetInformationsFromHtml(htmls);
            string filepath = getinformations.WriteInformationsToFile(informatios);
            Informations[] informations=getinformations.GetInformationsFromFile(filepath);
        }
    }
}
