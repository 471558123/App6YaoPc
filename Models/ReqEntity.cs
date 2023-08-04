using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App6Yao.Models
{
    public class ReqEntity
    {


        /// <summary>
        /// 姓名
        /// </summary>
        public string txtName { get; set; }
        /// <summary>
        /// 所占何事
        /// </summary>
        public string inpzs { get; set; }
        /// <summary>
        /// 占事范围Id
        /// </summary>
        public int whyarea { get; set; }
        /// <summary>
        /// 占事范围 汉字
        /// </summary>
        public string whyareaName { get; set; }
        /// <summary>
        /// 起卦方式
        /// </summary>
        public string QiGuaFs { get; set; }

        public DateTime QiGuaSj { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string rdoSex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int txtNL { get; set; }
        /// <summary>
        /// 属相
        /// </summary>
        public string shuxiang { get; set; }
        /// <summary>
        /// 铜钱随机出来的数组，手动选择的数组
        /// </summary>

        public List<string> Gyao { get; set; }

        public string Remark { get; set; }

        public string tockenStr { get; set; }
    }
}
