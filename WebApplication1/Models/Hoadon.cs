using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Hoadon
    {
        public int Mahd { get; set; }
        public DateTime Ngayhd { get; set; }
        public int Tongtien { get; set; }
        public int Idkh { get; set; }
        public string Ghichu { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Tinhtrang { get; set; }

        public virtual Users IdkhNavigation { get; set; }
    }
}
