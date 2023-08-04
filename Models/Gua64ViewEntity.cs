using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App6Yao.Models
{
    public  class Gua64ViewEntity
    {
        public int id { get; set; }
        public string GuaName { get; set; }
        public string Outer { get; set; }
        public string Interior { get; set; }
        public int Yao1 { get; set; }
        public int Yao2 { get; set; }
        public int Yao3 { get; set; }
        public int Yao4 { get; set; }
        public int Yao5 { get; set; }
        public int Yao6 { get; set; }


        public bool IsDy1 { get; set; }
        public bool IsDy2 { get; set; }
        public bool IsDy3 { get; set; }
        public bool IsDy4 { get; set; }
        public bool IsDy5 { get; set; }
        public bool IsDy6 { get; set; }

        public string Najia1 { get; set; }
        public string Najia2 { get; set; }
        public string Najia3 { get; set; }
        public string Najia4 { get; set; }
        public string Najia5 { get; set; }
        public string Najia6 { get; set; }

        public string Qin1 { get; set; }
        public string Qin2 { get; set; }
        public string Qin3 { get; set; }
        public string Qin4 { get; set; }
        public string Qin5 { get; set; }
        public string Qin6 { get; set; }

        public string ShengShou1 { get; set; }
        public string ShengShou2 { get; set; }
        public string ShengShou3 { get; set; }
        public string ShengShou4 { get; set; }
        public string ShengShou5 { get; set; }
        public string ShengShou6 { get; set; }

        public string GuaGong { get; set; }
        public int GongWei { get; set; }
        public int ShiYao { get; set; }
        public int YingYao { get; set; }
        public int Group { get; set; }

        public string Remark { get; set; }

        /// <summary>
        /// 六沖卦,六合卦,归魂,游魂
        /// </summary>
        public string Gyhc { get; set; }

        /// <summary>
        /// 卦身
        /// </summary>
        public string GuSehn { get; set; }
    }
}
