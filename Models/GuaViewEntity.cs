using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App6Yao.Models.GuaViewEntity;

namespace App6Yao.Models
{
    public  class GuaViewEntity
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
            public int txtShuxiang { get; set; }
            /// <summary>
            /// 伏神Id
            /// </summary>
            public List<int> FuYaoId { get; set; }
            /// <summary>
            /// 伏神
            /// </summary>
            public List<string> FuYao { get; set; }
            /// <summary>
            /// 伏神纳甲
            /// </summary>
            public List<string> FuYaoNj { get; set; }
            public List<Gua64ViewEntity> Gua64s { get; set; }

            private string guaIdStr = string.Empty;
            /// <summary>
            /// 卦身
            /// </summary>
            public string GuSehn { get; set; }
            public string GuaIdStr
            { get; set; }
            public string ChineseString
            { get; set; }


            public string Xk
            { get; set; }
            public string GanZhi
            { get; set; }
            public string ym { get; set; }
            public string 驿马 { get; set; }

            public string gr { get; set; }
            public string 贵人 { get; set; }
            public string th { get; set; }
            public string 桃花 { get; set; }
            public string rl { get; set; }
            public string 禄
            { get; set; }
            public string 天喜 { get; set; }
            public string 天医 { get; set; }
            public string 灾煞 { get; set; }
            public string 谋星 { get; set; }
            public string 华盖 { get; set; }
            public string 劫煞 { get; set; }
            public string 将星 { get; set; }
            public string 贵文昌人 { get; set; }
            public string 羊刃 { get; set; }

            /// <summary>
            /// 备注信息
            /// </summary>
            public gua64remark remark { get; set; }
            public string 大数据分析 { get; set; }




        
        public class gua64remark
        {
            public int id { get; set; }
            public string title1 { get; set; }
            public string Remark1 { get; set; }
        }

    }
}
