using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsHomework2
{
    public partial class Form2 : Form
    {
        Informations informations;
        public Form2(Informations informations)
        {
            this.informations = informations;
            InitializeComponent();
            textBox1.AppendText("公司名称：" + informations.CompanyName + "\n");
            textBox1.AppendText("岗位名称：" + informations.JobName + "\n");
            textBox1.AppendText(informations.JobDuty + "\n");
            textBox1.AppendText(informations.JobRequire + "\n");
            textBox1.AppendText("公司类型：" + informations.CompanyType + "\n");
            textBox1.AppendText("公司荣誉：" + informations.CompanyPrice + "\n");
            textBox1.AppendText("公司地址：" + informations.CompanyAddress + "\n");
            textBox1.AppendText(informations.CompanyDetails + "\n");
            textBox1.AppendText(informations.CompanyWebsite + "\n");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
