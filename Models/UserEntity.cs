using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App6Yao.Models
{
    public  class UserEntity
    {

        public int id { get; set; }
        public string username { get; set; }
        public string userpassword { get; set; }
        public string openid { get; set; }
        public string Nickname { get; set; }
        public string Headportrait { get; set; }
        public string MobilePhone { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime AddDate { get; set; }
        public int Role { get; set; }
        /// <summary>
        /// 可以使用的免费问卦数
        /// </summary>
        public int Available { get; set; }
        public string tockenStr { get; set; }
    }
}
