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
using System.Windows.Forms.DataVisualization.Charting;

namespace CsHomework2
{
    interface Pictures
    {
        //获取柱状图，传入参数为Company，返回一个柱状图
        Image Get_BarGraph(List<Company> Companies);
        //获取岗位技能树，传入参数为一条岗位信息，返回一个树状图
        TreeView Get_WorkAbilityTree(Informations informations);
    }
}
