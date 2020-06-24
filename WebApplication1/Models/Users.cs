using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class Users
    {
        public Users()
        {
            Hoadon = new HashSet<Hoadon>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ICollection<Hoadon> Hoadon { get; set; }
    }
}
