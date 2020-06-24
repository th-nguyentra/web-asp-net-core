using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Anh
    {
        public int Masp { get; set; }
        public string Link { get; set; }

        public virtual Sanpham MaspNavigation { get; set; }
    }
}
