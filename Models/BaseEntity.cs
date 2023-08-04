using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App6Yao.Models
{
    public  class BaseEntity
    {
        public static string url { get; set; }= "https://yao.yyzfs.ren";
        public static string tockenStr { get; set; }
        public static UserEntity user { get; set; }
        public static long sevVCode { get; set; }
    }
}
