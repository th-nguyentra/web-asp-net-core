using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Anh = new HashSet<Anh>();
            Chitiethoadon = new HashSet<Chitiethoadon>();
            Magiamgia = new HashSet<Magiamgia>();
        }

        public int Masp { get; set; }
        public string Tensp { get; set; }
        public int Hang { get; set; }
        public string Mota { get; set; }
        public DateTime? Namsx { get; set; }
        public double? Gia { get; set; }
        public double? Giakhuyenmai { get; set; }
        public string Anhdaidien { get; set; }
        public string Manhinh { get; set; }
        public string Cameratruoc { get; set; }
        public string Camerasau { get; set; }
        public string Ram { get; set; }
        public string Bonhotrong { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Pin { get; set; }



        public string Os { get; set; }
        public string Sim { get; set; }

        public virtual Hang HangNavigation { get; set; }
        public virtual ICollection<Anh> Anh { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadon { get; set; }
        public virtual ICollection<Magiamgia> Magiamgia { get; set; }
       



    }
}
