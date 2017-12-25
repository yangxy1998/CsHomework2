using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Text.RegularExpressions; 

namespace CsHomework2
{
    class GetInformationsImplement:GetInformations
    {
        string[] GetInformations.GetHtml()
        {
            WebClient wc = new WebClient();
            string url = "https://www.nowcoder.com/recommend/";
            wc.Encoding = Encoding.UTF8;
            string html = wc.DownloadString(url);
            Regex regex = new Regex("<a href=.*? class=\"js-address\">(?<location>.*?)" + @"</a>");//获取工作地点
            MatchCollection matches = regex.Matches(html);
            int i = 0;
            string[] location = new string[matches.Count];
            foreach (Match item in matches)
            {
                location[i] = item.Groups["location"].Value.ToString();
                i++;
            }
            string[] Html = new string[1000];
            i = 0;
            while (i < 1000)
            {
                Regex regexForNum = new Regex("\"totalPage\":(?<totalpage>.*?),\"");
                Regex regexForJobList = new Regex("\"id\":(?<id>.*?),\"internCompanyId\":(?<companyid>.*?),\"mark\":false,\"receiveResumeCount\":0,\"status\":0,\"title\":\"(?<title>.*?)\",");
                for (int j = 0; j < location.Length; j++)
                {
                    string js = wc.DownloadString("https://www.nowcoder.com/recommend-intern/list?token=&page=1&address=" + location[j]);//提取该工作地的总页数
                    matches = regexForNum.Matches(js);
                    int k = int.Parse(matches[0].Groups["totalpage"].Value.ToString());
                    for (; k > 0; k--)
                    {
                        js = wc.DownloadString("https://www.nowcoder.com/recommend-intern/list?token=&page=" + k + "&address=" + location[j]);//提取该工作地每一页当中包含的实习兼职信息
                        matches = regexForJobList.Matches(js);
                        foreach (Match item in matches)
                        {
                            Html[i] = "https://www.nowcoder.com/recommend-intern/" + item.Groups["companyid"].Value.ToString()
                                + "?jobId=" + item.Groups["id"].Value.ToString();//链接
                            i++;
                            if (i > 999) break;//防止溢出
                        }
                        if (i > 999) break;
                    }
                    if (i > 999) break;
                }
                if (i > 999) break;
            }
            return Html;
        }
        Informations[] GetInformations.GetInformationsFromHtml(string[] Htmls)
        {
            int i = 0;
            Informations[] infos = new Informations[Htmls.Length];
            while (i < Htmls.Length)
            {
                infos[i] = new Informations();
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                string html = wc.DownloadString(Htmls[i]);
                html = html.Replace("\n", "");
                Regex regex = new Regex("<h2>(?<id>.*?)</h2>");//岗位名称
                MatchCollection matches = regex.Matches(html);
                if (matches.Count > 0)
                {
                    infos[i].JobName = matches[0].Groups["id"].Value.ToString();
                }
                else
                {
                    infos[i].JobName = "NULL";
                }
                regex = new Regex("<dl class=\"job-duty\">(?<content>.*?)</dl>");//获取岗位职责内包含的全部字符
                matches = regex.Matches(html);
                Regex content = new Regex("<span style=.*?>(?<text>.*?)</span>");//按行获取岗位职责信息
                MatchCollection matchContents = content.Matches(matches[0].Groups["content"].Value);
                infos[i].JobDuty = "岗位职责：";
                foreach (Match item in matchContents)
                {
                    infos[i].JobDuty += item.Groups["text"].Value.ToString();
                }
                regex = new Regex("<dl>(?<content>.*?)</dl>");//获取岗位要求当中包含的全部字符
                content = new Regex(">(?<text>.*?)<");
                matches = regex.Matches(html);//按行获取岗位要求信息
                matchContents = content.Matches(matches[0].Groups["content"].Value);
                infos[i].JobRequire = "";
                foreach (Match item in matchContents)
                {
                    infos[i].JobRequire += item.Groups["text"].Value.ToString();
                }
                regex = new Regex("<p class=\"com-lbs\">(?<address>.*?)</p>");
                matches = regex.Matches(html);
                if (matches.Count > 0)
                {
                    infos[i].CompanyAddress = matches[0].Groups["address"].Value.ToString();
                }
                else
                {
                    infos[i].CompanyAddress = "NULL";
                }
                regex = new Regex("<a href=\"/recommand\">内推首页</a><span>&gt;</span>(?<companyname>.*?)</div>");
                matches = regex.Matches(html);
                if (matches.Count > 0)
                {
                    infos[i].CompanyName = matches[0].Groups["companyname"].Value.ToString();
                }
                else
                {
                    infos[i].CompanyName = "NULL";
                }
                regex = new Regex("<div class=\"com-detail\"><p>(?<detail>.*?)</p><p><a href=\"(?<website>.*?)\" target=\"_blank\">(?<web>.*?)</a></p></div>");
                matches = regex.Matches(html);
                content = new Regex(">(?<detail>.*?)<");
                if (matches.Count > 0)
                {
                    matchContents = content.Matches(matches[0].Groups["detail"].Value.ToString());
                    infos[i].CompanyDetails = "公司详情：";
                    foreach (Match item in matchContents)
                    {
                        infos[i].CompanyDetails += item.Groups["detail"].Value.ToString();
                    }
                    infos[i].CompanyWebsite = "公司网站：" + matches[0].Groups["web"].Value.ToString();
                }
                else
                {
                    infos[i].CompanyDetails = "NULL";
                    infos[i].CompanyWebsite = "NULL";
                }
                regex = new Regex("<p class=\"com-price\">(?<price>.*?)</p>");
                matches = regex.Matches(html);
                if (matches.Count > 0)
                {
                    infos[i].CompanyPrice = matches[0].Groups["price"].Value.ToString();
                }
                else
                {
                    infos[i].CompanyPrice = "NULL";
                }
                regex = new Regex("<p class=\"com-type\">(?<type>.*?)</p>");
                matches = regex.Matches(html);
                if (matches.Count > 0)
                {
                    infos[i].CompanyType = matches[0].Groups["type"].Value.ToString();
                }
                else
                {
                    infos[i].CompanyType = "NULL";
                }
                Console.WriteLine(i);
                i++;
            }
            return infos;
        }
        Informations[] GetInformations.GetInformationsFromFile(string FilePath)
        {
            StreamReader reader = new StreamReader(FilePath, Encoding.UTF8);
            Informations[] infos=null;
            string s = reader.ReadLine();
            if(s!=null){
                int count = int.Parse(s);
                infos = new Informations[count];
                string text = reader.ReadToEnd();
                Regex r=new Regex("<Informations>(?<informations>.*?)</Informations>");
                MatchCollection matches=r.Matches(text);
                for (int i = 0; i < count; i++)
                {
                    string info = matches[i].Groups["informations"].Value;
                    infos[i] = new Informations();
                    Regex regex = new Regex("<CompanyName>(?<companyname>.*?)</CompanyName>");
                    Match match = regex.Match(info);
                    infos[i].CompanyName = match.Groups["companyname"].Value;
                    regex = new Regex("<JobName>(?<jobname>.*?)</JobName>");
                    match = regex.Match(info);
                    infos[i].JobName = match.Groups["jobname"].Value;
                    regex = new Regex("<JobDuty>(?<jobduty>.*?)</JobDuty>");
                    match = regex.Match(info);
                    infos[i].JobDuty = match.Groups["jobduty"].Value;
                    regex = new Regex("<JobRequire>(?<jobrequire>.*?)</JobRequire>");
                    match = regex.Match(info);
                    infos[i].JobRequire = match.Groups["jobrequire"].Value;
                    regex = new Regex("<CompanyType>(?<companytype>.*?)</CompanyType>");
                    match = regex.Match(info);
                    infos[i].CompanyType = match.Groups["companytype"].Value;
                    regex = new Regex("<CompanyPrice>(?<companyprice>.*?)</CompanyPrice>");
                    match = regex.Match(info);
                    infos[i].CompanyPrice = match.Groups["companyprice"].Value;
                    regex = new Regex("<CompanyAddress>(?<companyaddress>.*?)</CompanyAddress>");
                    match = regex.Match(info);
                    infos[i].CompanyAddress = match.Groups["companyaddress"].Value;
                    regex = new Regex("<CompanyDetails>(?<companydetails>.*?)</CompanyDetails>");
                    match = regex.Match(info);
                    infos[i].CompanyDetails = match.Groups["companydetails"].Value;
                    regex = new Regex("<CompanyWebsite>(?<companywebsite>.*?)</CompanyWebsite>");
                    match = regex.Match(info);
                    infos[i].CompanyWebsite = match.Groups["companywebsite"].Value;
                }
            }
            reader.Close();
            return infos;
        }
        string GetInformations.WriteInformationsToFile(Informations[] informations)
        {
            SaveFileDialog savefilewindow = new SaveFileDialog();
            savefilewindow.Filter = "文本文档（*.txt）|*.txt";
            savefilewindow.FilterIndex = 1;
            savefilewindow.RestoreDirectory = true;
            string filepath = null;
            if (savefilewindow.ShowDialog() == DialogResult.OK)
            {
                filepath = savefilewindow.FileName.ToString();//获得保存文件的地址
                StreamWriter writer = new StreamWriter(filepath);
                writer.WriteLine(informations.Length);//写入数据条数
                for (int i = 0; i < informations.Length; i++)
                {
                    writer.WriteLine("<Informations><CompanyName>"+informations[i].CompanyName+"</CompanyName>"
                        +"<JobName>"+informations[i].JobName+"</JobName>"
                        +"<JobDuty>"+informations[i].JobDuty+"</JobDuty>"
                        +"<JobRequire>"+informations[i].JobRequire+"</JobRequire>"
                        +"<CompanyType>"+informations[i].CompanyType+"</CompanyType>"
                        +"<CompanyPrice>"+informations[i].CompanyPrice+"</CompanyPrice>"
                        +"<CompanyAddress>"+informations[i].CompanyAddress+"</CompanyAddress>"
                        +"<CompanyDetails>"+informations[i].CompanyDetails+"</CompanyDetails>"
                        +"<CompanyWebsite>"+informations[i].CompanyWebsite+"</CompanyWebsite></Informations>");
                    Console.WriteLine(i);
                }
                writer.Close();
            }
            return filepath;
        }

        List<Company> GetInformations.Set_CompanyJobCount(Informations[] informations)//设置公司岗位数量，返回company列表
        {
            List<Company> Companies=new List<Company>();
            foreach(Informations information in informations){
                bool IsExist = false;//判断是否已存在这个公司
                foreach (Company company in Companies)//在company列表当中寻找是否已存在
                {
                    if (company.CompanyName.Equals(information.CompanyName))
                    {
                        IsExist = true;
                        company.WorkCount += 1;
                        company.CompanyInformations.Add(information);
                    }
                }
                if (IsExist) continue;//如果存在这个公司
                else//不存在，则新建一个
                {
                    Company company = new Company();
                    company.CompanyName = information.CompanyName;
                    company.WorkCount = 0;
                    company.CompanyInformations.Add(information);
                    Companies.Add(company);
                }
            }
            return Companies;
        }
    }
}
