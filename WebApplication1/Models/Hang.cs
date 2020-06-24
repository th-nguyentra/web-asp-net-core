using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class Hang
    {
        public Hang()
        {
            Sanpham = new HashSet<Sanpham>();
        }

        public int Mahang { get; set; }
        public string Tenhang { get; set; }

        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
