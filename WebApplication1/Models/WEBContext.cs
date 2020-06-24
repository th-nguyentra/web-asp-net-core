using System;
using DEMO.Models;
using DOAN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class WEBContext : DbContext
    {
        public WEBContext()
        {
        }

        public WEBContext(DbContextOptions<WEBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Anh> Anh { get; set; }
        public virtual DbSet<Chitiethoadon> Chitiethoadon { get; set; }
        public virtual DbSet<Hang> Hang { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Magiamgia> Magiamgia { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }

        public virtual DbSet<Taikhoan> Taikhoan { get; set; }
        public virtual DbSet<Users> Users { get; set; }

       
        
        //public virtual DbSet<ExportPDF> ExportPDF { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   if (!optionsBuilder.IsConfigured)
        //    {
        //        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //       optionsBuilder.UseSqlServer("Server=DESKTOP-0ED97E5\\TRA;Database=WEB;Trusted_Connection=True;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ten)
                    .HasColumnName("TEN")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.ToTable("nhanvien");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ten)
                    .HasColumnName("TEN")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Anh>(entity =>
            {
                entity.HasKey(e => new { e.Masp, e.Link })
                    .HasName("PK__anh__962847F55648893B");

                entity.ToTable("anh");

                entity.Property(e => e.Masp)
                    .HasColumnName("MASP")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Link)
                    .HasColumnName("LINK")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Anh)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ANH_KH");
            });

            modelBuilder.Entity<Chitiethoadon>(entity =>
            {
                entity.HasKey(e => new { e.Mahd, e.Masp })
                    .HasName("PK__chitieth__563D086DC4FCABF1");

                entity.ToTable("chitiethoadon");

                entity.Property(e => e.Mahd).HasColumnName("MAHD");

                entity.Property(e => e.Masp).HasColumnName("MASP");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Gia).HasColumnName("GIA");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Chitiethoadon)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHD_SP");
            });

            modelBuilder.Entity<Hang>(entity =>
            {
                entity.HasKey(e => e.Mahang)
                    .HasName("PK__hang__279EA4C28D1DC286");

                entity.ToTable("hang");

                entity.Property(e => e.Mahang).HasColumnName("MAHANG");

                entity.Property(e => e.Tenhang)
                    .IsRequired()
                    .HasColumnName("TENHANG")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("PK__hoadon__603F20CEC9E5564B");

                entity.ToTable("hoadon");

                entity.Property(e => e.Mahd).HasColumnName("MAHD");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .IsUnicode(false);

                entity.Property(e => e.Idkh).HasColumnName("IDKH");

                entity.Property(e => e.Ngayhd)
                    .HasColumnName("NGAYHD")
                    .HasColumnType("date");

                entity.Property(e => e.Tinhtrang)
                    .IsRequired()
                    .HasColumnName("TINHTRANG")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdkhNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.Idkh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HD_KH");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.ToTable("khachhang");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ghichu)
                    .HasColumnName("GHICHU")
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ten)
                    .HasColumnName("TEN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Magiamgia>(entity =>
            {
                entity.HasKey(e => e.Magiamgia1)
                    .HasName("PK__magiamgi__41C28439899B4FBD");

                entity.ToTable("magiamgia");

                entity.Property(e => e.Magiamgia1).HasColumnName("MAGIAMGIA");

                entity.Property(e => e.Masp).HasColumnName("MASP");

                entity.Property(e => e.Phantram).HasColumnName("PHANTRAM");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Magiamgia)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GIAMGIA_SP");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PK__sanpham__60228A32352A54EA");

                entity.ToTable("sanpham");

                entity.Property(e => e.Masp).HasColumnName("MASP");

                entity.Property(e => e.Anhdaidien)
                    .HasColumnName("ANHDAIDIEN")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Bonhotrong)
                    .HasColumnName("BONHOTRONG")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Camerasau)
                    .HasColumnName("CAMERASAU")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cameratruoc)
                    .HasColumnName("CAMERATRUOC")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cpu)
                    .HasColumnName("CPU")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gia).HasColumnName("GIA");

                entity.Property(e => e.Giakhuyenmai).HasColumnName("GIAKHUYENMAI");

                entity.Property(e => e.Gpu)
                    .HasColumnName("GPU")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Hang).HasColumnName("HANG");

                entity.Property(e => e.Manhinh)
                    .HasColumnName("MANHINH")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Namsx)
                    .HasColumnName("NAMSX")
                    .HasColumnType("date");

                entity.Property(e => e.Os)
                    .HasColumnName("OS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ram)
                    .HasColumnName("RAM")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sim)
                    .HasColumnName("SIM")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tensp)
                    .IsRequired()
                    .HasColumnName("TENSP")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.HangNavigation)
                    .WithMany(p => p.Sanpham)
                    .HasForeignKey(d => d.Hang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SP_HANG");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Tentk)
                    .HasName("PK__taikhoan__A58DF1B94EBA7F4C");

                entity.ToTable("taikhoan");

                entity.Property(e => e.Tentk)
                    .HasColumnName("TENTK")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("PASS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quyen)
                    .IsRequired()
                    .HasColumnName("QUYEN")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasColumnName("FULL_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("ROLE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('khachhang')");

                entity.Property(e => e.Sdt)
                    .HasColumnName("SDT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
