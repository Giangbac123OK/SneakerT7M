using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DANHGIA",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDKH = table.Column<string>(type: "varchar(10)", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NOIDUNGDANHGIA = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    NGAYDANHGIA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDSPCHITIET = table.Column<string>(type: "varchar(10)", nullable: false),
                    HINHANH = table.Column<string>(type: "Nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DANHGIA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DIACHI",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDKH = table.Column<string>(type: "varchar(10)", nullable: false),
                    THANHPHO = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    QUANHUYEN = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PHUONGXA = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DIACHICUTHE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIACHI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GIAMGIA",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    MOTA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Donvi = table.Column<int>(type: "int", nullable: false),
                    GIATRI = table.Column<float>(type: "real", nullable: false),
                    NGAYBATDAU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NGAYKETTHUC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIAMGIA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GIAMGIA_TICHDIEM",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDKH = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDVOUCHER = table.Column<string>(type: "varchar(10)", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIAMGIA_TICHDIEM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GIOHANG",
                columns: table => new
                {
                    IDKH = table.Column<string>(type: "varchar(10)", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIOHANG", x => x.IDKH);
                });

            migrationBuilder.CreateTable(
                name: "GIOHANGCHITIET",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDGIOHANG = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDSPCHITIET = table.Column<string>(type: "varchar(10)", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIOHANGCHITIET", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HINHANH",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    URLHINHANH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HINHANH", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDNV = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDKH = table.Column<string>(type: "varchar(10)", nullable: false),
                    TRANGTHAITHANHTOAN = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DONVITRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    THOIGIANDATHANG = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DIACHISHIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGAYGIAO = table.Column<DateOnly>(type: "date", nullable: false),
                    TONGTIENCANTRA = table.Column<float>(type: "real", nullable: false),
                    TONGTIENSANPHAM = table.Column<float>(type: "real", nullable: false),
                    SDT = table.Column<string>(type: "varchar(10)", nullable: false),
                    TONGTIENGIAMGIA = table.Column<float>(type: "real", nullable: false),
                    IDGIAMGIA = table.Column<string>(type: "varchar(10)", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADON", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOADONCHITIET",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDHOADON = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDSPCHITIET = table.Column<string>(type: "varchar(10)", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false),
                    Giasp = table.Column<float>(type: "real", nullable: false),
                    Idgiamgia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIAMGIA = table.Column<float>(type: "real", nullable: false),
                    IDDANHGIA = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADONCHITIET", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOADONNHAP",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDNV = table.Column<string>(type: "varchar(10)", nullable: false),
                    Ngaynhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TONGTIEN = table.Column<float>(type: "real", nullable: false),
                    NGUOIGIAO = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SDTNGUOIGIAO = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADONNHAP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOADONNHAPCHITIET",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDHOADONNHAP = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDSP = table.Column<string>(type: "varchar(10)", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false),
                    GIANHAP = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADONNHAPCHITIET", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    TEN = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SDT = table.Column<string>(type: "varchar(10)", nullable: false),
                    NGAYSINH = table.Column<DateOnly>(type: "date", nullable: false),
                    TICHDIEM = table.Column<int>(type: "int", nullable: false),
                    EMAIL = table.Column<string>(type: "varchar(max)", nullable: false),
                    DIACHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(50)", nullable: false),
                    DIEMSUDUNG = table.Column<int>(type: "int", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHACHHANG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LICHSUTHANHTOAN",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDHOADON = table.Column<string>(type: "varchar(10)", nullable: false),
                    NGAYTHANHTOAN = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LICHSUTHANHTOAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NHACUNGCAP",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    TENNHACUNGCAP = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SDT = table.Column<string>(type: "varchar(10)", nullable: false),
                    DIACHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHACUNGCAP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NHANVIEN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HOTEN = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NGAYSINH = table.Column<DateOnly>(type: "date", nullable: false),
                    DIACHI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIOITINH = table.Column<bool>(type: "bit", nullable: false),
                    SDT = table.Column<string>(type: "varchar(10)", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(50)", nullable: false),
                    ROLE = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANVIEN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHUONGTHUCTHANHTOAN",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    TENPTT = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHUONGTHUCTHANHTOAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SALE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    TEN = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    THOIHAN = table.Column<TimeOnly>(type: "time", nullable: false),
                    MOTA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NGAYBATDAU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NGAYKETTHUC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SALECHITIET",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDSPCHITIET = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDSALE = table.Column<string>(type: "varchar(10)", nullable: false),
                    DONVI = table.Column<int>(type: "int", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false),
                    GIAMGIA = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALECHITIET", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    TENSP = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MOTA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GIABAN = table.Column<float>(type: "real", nullable: false),
                    GIASALE = table.Column<float>(type: "real", nullable: false),
                    HINHANH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANPHAM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAMCHITIET",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDSP = table.Column<string>(type: "varchar(10)", nullable: false),
                    MOTA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    GIATHOIDIEMHIENTAI = table.Column<float>(type: "real", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANPHAMCHITIET", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "THUOCTINH",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    TENTHUOCTINH = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUOCTINH", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "THUOCTINH_SANPHAMCHITIET",
                columns: table => new
                {
                    IDTHUOCTINH = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDSPCHITIET = table.Column<string>(type: "varchar(10)", nullable: false),
                    TENTHUOCTINHCHITIET = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUOCTINH_SANPHAMCHITIET", x => new { x.IDTHUOCTINH, x.IDSPCHITIET });
                });

            migrationBuilder.CreateTable(
                name: "THUONGHIEU",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    TENTHUONGHIEU = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TINHTRANG = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THUONGHIEU", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRAHANG",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    TENKHACHHANG = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IDKH = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDNV = table.Column<string>(type: "varchar(10)", nullable: false),
                    SOTIENHOAN = table.Column<float>(type: "real", nullable: false),
                    LYDOTRHANG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TRANGTHAI = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PHUONGTHUCHOANTIEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NGAYTRAHANG = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHUTHICH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAHANG", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRAHANGCHITIET",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", nullable: false),
                    IDHOADONCHITIET = table.Column<string>(type: "varchar(10)", nullable: false),
                    SOLUONG = table.Column<int>(type: "int", nullable: false),
                    TINHTRANG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GHICHU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HINHTHUCXULY = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAHANGCHITIET", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DANHGIA");

            migrationBuilder.DropTable(
                name: "DIACHI");

            migrationBuilder.DropTable(
                name: "GIAMGIA");

            migrationBuilder.DropTable(
                name: "GIAMGIA_TICHDIEM");

            migrationBuilder.DropTable(
                name: "GIOHANG");

            migrationBuilder.DropTable(
                name: "GIOHANGCHITIET");

            migrationBuilder.DropTable(
                name: "HINHANH");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "HOADONCHITIET");

            migrationBuilder.DropTable(
                name: "HOADONNHAP");

            migrationBuilder.DropTable(
                name: "HOADONNHAPCHITIET");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "LICHSUTHANHTOAN");

            migrationBuilder.DropTable(
                name: "NHACUNGCAP");

            migrationBuilder.DropTable(
                name: "NHANVIEN");

            migrationBuilder.DropTable(
                name: "PHUONGTHUCTHANHTOAN");

            migrationBuilder.DropTable(
                name: "SALE");

            migrationBuilder.DropTable(
                name: "SALECHITIET");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "SANPHAMCHITIET");

            migrationBuilder.DropTable(
                name: "THUOCTINH");

            migrationBuilder.DropTable(
                name: "THUOCTINH_SANPHAMCHITIET");

            migrationBuilder.DropTable(
                name: "THUONGHIEU");

            migrationBuilder.DropTable(
                name: "TRAHANG");

            migrationBuilder.DropTable(
                name: "TRAHANGCHITIET");
        }
    }
}
