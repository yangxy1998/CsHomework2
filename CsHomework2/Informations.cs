using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JiebaNet.Analyser;

namespace CsHomework2
{
    public class Informations
    {
        public string CompanyName//公司名称
        {
            set;
            get;
        }
        public string JobName//岗位名称
        {
            set;
            get;
        }
        public string JobDuty//岗位职责
        {
            set;
            get;
        }
        public string JobRequire//岗位要求
        {
            set;
            get;
        }
        public string CompanyType//公司类型
        {
            set;
            get;
        }
        public string CompanyPrice//公司荣誉
        {
            set;
            get;
        }
        public string CompanyAddress//公司地址
        {
            set;
            get;
        }
        public string CompanyDetails//公司详情
        {
            set;
            get;
        }
        public string CompanyWebsite//公司官网
        {
            set;
            get;
        }
        public WordWeightPair KeyWords//岗位关键词
        {
            set;
            get;
        }
        public string Get(int x)
            /**
             * 1:CompanyName
             * 2:JobName
             * 3:JobDuty
             * 4:JobRequire
             * 5:CompanyType
             * 6:CompanyPrice
             * 7:CompanyAddress
             * 8:CompanyDetails
             * 9:CompanyWebsite
             * **/
        {
            switch (x)
            {
                case 1: return CompanyName;
                case 2: return JobName;
                case 3: return JobDuty;
                case 4: return JobRequire;
                case 5: return CompanyType;
                case 6: return CompanyPrice;
                case 7: return CompanyAddress;
                case 8: return CompanyDetails;
                case 9: return CompanyWebsite;
                default: return null;
            }
        }
    }
}
