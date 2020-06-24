using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DOAN.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hang",
                columns: table => new
                {
                    MAHANG = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENHANG = table.Column<string>(unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__hang__279EA4C28D1DC286", x => x.MAHANG);
                });

            migrationBuilder.CreateTable(
                name: "khachhang",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TEN = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    DIACHI = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    SDT = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    GHICHU = table.Column<string>(unicode: false, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachhang", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "taikhoan",
                columns: table => new
                {
                    TENTK = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    PASS = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    QUYEN = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__taikhoan__A58DF1B94EBA7F4C", x => x.TENTK);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FULL_NAME = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    ROLE = table.Column<string>(unicode: false, maxLength: 30, nullable: false, defaultValueSql: "('khachhang')"),
                    DIACHI = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    SDT = table.Column<string>(unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    password = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    ReturnUrl = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "sanpham",
                columns: table => new
                {
                    MASP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TENSP = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    HANG = table.Column<int>(nullable: false),
                    MOTA = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    NAMSX = table.Column<DateTime>(type: "date", nullable: true),
                    GIA = table.Column<int>(nullable: true),
                    GIAKHUYENMAI = table.Column<int>(nullable: true),
                    ANHDAIDIEN = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    MANHINH = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    CAMERATRUOC = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    CAMERASAU = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    RAM = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    BONHOTRONG = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    CPU = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    GPU = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    PIN = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    OS = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    SIM = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sanpham__60228A32352A54EA", x => x.MASP);
                    table.ForeignKey(
                        name: "FK_SP_HANG",
                        column: x => x.HANG,
                        principalTable: "hang",
                        principalColumn: "MAHANG",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hoadon",
                columns: table => new
                {
                    MAHD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NGAYHD = table.Column<DateTime>(type: "date", nullable: false),
                    TONGTIEN = table.Column<int>(nullable: false),
                    IDKH = table.Column<int>(nullable: false),
                    GHICHU = table.Column<string>(unicode: false, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(0)", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "(getdate())"),
                    TINHTRANG = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__hoadon__603F20CEC9E5564B", x => x.MAHD);
                    table.ForeignKey(
                        name: "FK_HD_Users",
                        column: x => x.IDKH,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "anh",
                columns: table => new
                {
                    MASP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LINK = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__anh__962847F55648893B", x => new { x.MASP, x.LINK });
                    table.ForeignKey(
                        name: "FK_ANH_KH",
                        column: x => x.MASP,
                        principalTable: "sanpham",
                        principalColumn: "MASP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chitiethoadon",
                columns: table => new
                {
                    MAHD = table.Column<int>(nullable: false),
                    MASP = table.Column<int>(nullable: false),
                    THANHTIEN = table.Column<int>(nullable: true),
                    SOLUONG = table.Column<int>(nullable: true),
                    GIA = table.Column<int>(nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime2(0)", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__chitieth__563D086DC4FCABF1", x => new { x.MAHD, x.MASP });
                    table.ForeignKey(
                        name: "FK_CTHD_SP",
                        column: x => x.MASP,
                        principalTable: "sanpham",
                        principalColumn: "MASP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "magiamgia",
                columns: table => new
                {
                    MAGIAMGIA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MASP = table.Column<int>(nullable: false),
                    PHANTRAM = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__magiamgi__41C28439899B4FBD", x => x.MAGIAMGIA);
                    table.ForeignKey(
                        name: "FK_GIAMGIA_SP",
                        column: x => x.MASP,
                        principalTable: "sanpham",
                        principalColumn: "MASP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chitiethoadon_MASP",
                table: "chitiethoadon",
                column: "MASP");

            migrationBuilder.CreateIndex(
                name: "IX_hoadon_IDKH",
                table: "hoadon",
                column: "IDKH");

            migrationBuilder.CreateIndex(
                name: "IX_magiamgia_MASP",
                table: "magiamgia",
                column: "MASP");

            migrationBuilder.CreateIndex(
                name: "IX_sanpham_HANG",
                table: "sanpham",
                column: "HANG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anh");

            migrationBuilder.DropTable(
                name: "chitiethoadon");

            migrationBuilder.DropTable(
                name: "hoadon");

            migrationBuilder.DropTable(
                name: "magiamgia");

            migrationBuilder.DropTable(
                name: "taikhoan");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "khachhang");

            migrationBuilder.DropTable(
                name: "sanpham");

            migrationBuilder.DropTable(
                name: "hang");
        }
    }
}
