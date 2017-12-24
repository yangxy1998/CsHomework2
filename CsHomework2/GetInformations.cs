using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHomework2
{
    interface GetInformations
    {
        string[] GetHtml();//获取各个公司实习兼职页面地址，返回值是所有地址

        Informations[] GetInformationsFromHtml(string[] Htmls);//从地址获取数据，返回所有Informations对象

        Informations[] GetInformationsFromFile(string FilePath);//从文件读取数据，返回所有Informations对象

        string WriteInformationsToFile(Informations[] informations);//将获取到的信息写入文件，返回写入的文件路径

        List<Company> Set_CompanyJobCount(Informations[] informations);//设置公司岗位数量，返回company列表
    }
}
