using System;
using System.Collections.Generic;

namespace DEMO.Models
{
    public partial class Nhanvien
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
