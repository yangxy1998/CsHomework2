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
        Informations[] informations;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.informations = getinformations.GetInformationsFromFile("C:\\Users\\Administrator\\Desktop\\informations.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Informations information in informations)
            {
                ListViewItem LvItem = new ListViewItem();
                LvItem.Text = information.JobName;
                listView1.Items.Add(LvItem);
                progressBar1.Value = (int)(100*i / informations.Length)*progressBar1.Step;
                i++;
                Application.DoEvents();
            }
            progressBar1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Company> companies = getinformations.Set_CompanyJobCount(informations);
            pictureBox1.BackgroundImage = pictures.Get_BarGraph(companies);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                int k = info.Item.Index;
                Form2 form = new Form2(informations[k]);
                form.ShowDialog();
            }
        }
    }
}
