using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData
{
	public class MyDbContext : DbContext
	{
		//ad
		public MyDbContext() { }
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
		public DbSet<Khachhang> Khachhangs { get; set; }
		public DbSet<Diachi> Diachis { get; set; }
		public DbSet<Hoadon> Hoadons { get; set; }
		public DbSet<Lichsuthanhtoan> Lichsuthanhtoans { get; set; }
		public DbSet<Nhanvien> Nhanviens { get; set; }
		public DbSet<Phuongthucthanhtoan> Phuongthucthanhtoans { get; set; }
		public DbSet<Danhgia> Danhgias { get; set; }
		public DbSet<Giohang> Giohangs { get; set; }
		public DbSet<Giamgiatichdiem> Giamgiatichdiems { get; set; }
		public DbSet<Giamgia> Giamgias {  get; set; }
		public DbSet<Hoadonchitiet> Hoadonchitiets { get; set; }
		public DbSet<Trahangchitiet> Trahangchitiets { get; set; }
		public DbSet<Trahang> Trahangs { get; set; }
		public DbSet<Hinhanh> Hinhanhs { get; set; }
		public DbSet<Giohangchitiet> Giohangchitiets { get; set; }
		public DbSet<Sanphamchitiet> Sanphamchitiets { get; set; }
		public DbSet<Sanpham> Sanphams { get; set; }
		public DbSet<Hoadonnhapchitiet> Hoadonnhapchitiets { get; set; }
		public DbSet<Hoadonnhap> Hoadonnhaps { get; set; }
		public DbSet<Nhacungcap> Nhacungcaps { get; set; }
		public DbSet<Thuonghieu> Thuonghieus { get; set; }
		public DbSet<Sale> Sales { get; set; }
		public DbSet<Salechitiet> Salechitiets { get; set; }
		public DbSet<Thuoctinhsanphamchitiet> Thuoctinhsanphamchitiets { get; set; }
		public DbSet<Thuoctinh> Thuoctinhs { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=HOANGTHANHGIANG\\SQLEXPRESS;Initial Catalog=SneakerT7M;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Khach hang
			modelBuilder.Entity<Khachhang>(entity =>
			{
				entity.ToTable("KHACHHANG");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("ID");
				entity.Property(k => k.Ten)
					.HasColumnType("nvarchar(100)")
					.IsRequired()
					.HasColumnName("TEN");
				entity.Property(k => k.Sdt)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("SDT");
				entity.Property(k => k.Ngaysinh)
					.IsRequired()
					.HasColumnName("NGAYSINH");
				entity.Property(k => k.Tichdiem)
					.IsRequired()
					.HasColumnName("TICHDIEM");
				entity.Property(k => k.Email)
					.HasColumnType("varchar(max)")
					.IsRequired()
					.HasColumnName("EMAIL");
				entity.Property(k => k.Trangthai)
					.HasColumnType("nvarchar(50)")
					.IsRequired()
					.HasColumnName("TRANGTHAI");
				entity.Property(k => k.Diachi)
					.HasColumnType("nvarchar(max)")
					.IsRequired()
					.HasColumnName("DIACHI");
				entity.Property(k => k.Password)
					.HasColumnType("varchar(50)")
					.IsRequired()
					.HasColumnName("PASSWORD");
				entity.Property(k => k.Diemsudung)
					.IsRequired()
					.HasColumnName("DIEMSUDUNG");
			});
			//Phuong thuc thanh toan
			modelBuilder.Entity<Phuongthucthanhtoan>(entity =>
			{
				entity.ToTable("PHUONGTHUCTHANHTOAN");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("ID");
				entity.Property(k => k.Tenpttt)
					.HasColumnType("nvarchar(100)")
					.IsRequired()
					.HasColumnName("TENPTT");
				entity.Property(k => k.Trangthai)
					.HasColumnType("nvarchar(50)")
					.IsRequired()
					.HasColumnName("TRANGTHAI");
			});
			//Lich su thanh toan
			modelBuilder.Entity<Lichsuthanhtoan>(entity =>
			{
				entity.ToTable("LICHSUTHANHTOAN");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("ID");
				entity.Property(k => k.Idhoadon)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("IDHOADON");
				entity.Property(k => k.Ngaythanhtoan)
					.IsRequired()
					.HasColumnName("NGAYTHANHTOAN");
				entity.Property(k => k.Trangthai)
					.HasColumnType("nvarchar(50)")
					.IsRequired()
					.HasColumnName("TRANGTHAI");
			});
			//Hoa don
			modelBuilder.Entity<Hoadon>(entity =>
			{
				entity.ToTable("HOADON");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("ID");
				entity.Property(k => k.Idnv)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("IDNV");
				entity.Property(k => k.Idkh)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("IDKH");
				entity.Property(k => k.Trangthaithanhtoan)
					.HasColumnType("nvarchar(50)")
					.IsRequired()
					.HasColumnName("TRANGTHAITHANHTOAN");
				entity.Property(k => k.Donvitrangthai)
					.HasColumnType("nvarchar(50)")
					.IsRequired()
					.HasColumnName("DONVITRANGTHAI");
				entity.Property(k => k.Thoigiandathang)
					.IsRequired()
					.HasColumnName("THOIGIANDATHANG");
				entity.Property(k => k.Diachiship)
					.HasColumnType("nvarchar(max)")
					.IsRequired()
					.HasColumnName("DIACHISHIP");
				entity.Property(k => k.Ngaygiao)
					.IsRequired()
					.HasColumnName("NGAYGIAO");
				entity.Property(k => k.Tongtiencantra)
					.IsRequired()
					.HasColumnName("TONGTIENCANTRA");
				entity.Property(k => k.Tongtiensanpham)
					.IsRequired()
					.HasColumnName("TONGTIENSANPHAM");
				entity.Property(k => k.Tonggiamgia)
					.IsRequired()
					.HasColumnName("TONGTIENGIAMGIA");
				entity.Property(k => k.Sdt)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("SDT");
				entity.Property(k => k.Idgiamgia)
					.HasColumnType("varchar(10)")
					.IsRequired()
					.HasColumnName("IDGIAMGIA");
				entity.Property(k => k.Trangthai)
					.HasColumnType("nvarchar(50)")
					.IsRequired()
					.HasColumnName("TRANGTHAI");
			});
			//Nhan vien
			modelBuilder.Entity<Nhanvien>(entity =>
			{
				entity.ToTable("NHANVIEN");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Hoten)
					.HasColumnName("HOTEN")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Ngaysinh)
					.HasColumnName("NGAYSINH")
					.IsRequired();
				entity.Property(k => k.Diachi)
					.HasColumnName("DIACHI")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Gioitinh)
					.HasColumnName("GIOITINH")
					.IsRequired();
				entity.Property(k => k.Sdt)
					.HasColumnName("SDT")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Trangthai)
					.HasColumnName("TRANGTHAI")
					.HasColumnType("nvarchar(50)")
					.IsRequired();
				entity.Property(k => k.Password)
					.HasColumnName("PASSWORD")
					.HasColumnType("varchar(50)")
					.IsRequired();
				entity.Property(k => k.Role)
					.HasColumnName("ROLE")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
			});
			//Dia chi
			modelBuilder.Entity<Diachi>(entity =>
			{
				entity.ToTable("DIACHI");
				entity.HasKey(k=> k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k=>k.Idkh)
					.HasColumnName("IDKH")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Thanhpho)
					.HasColumnName("THANHPHO")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Quanhuyen)
					.HasColumnName("QUANHUYEN")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Phuongxa)
					.HasColumnName("PHUONGXA")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Diachicuthe)
					.HasColumnName("DIACHICUTHE")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
			});
			//Danh gia
			modelBuilder.Entity<Danhgia>(entity =>
			{
				entity.ToTable("DANHGIA");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idkh)
					.HasColumnName("IDKH")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Trangthai)
					.HasColumnName("TRANGTHAI")
					.HasColumnType("nvarchar(50)")
					.IsRequired();
				entity.Property(k => k.Noidungdanhgia)
					.HasColumnName("NOIDUNGDANHGIA")
					.HasColumnType("nvarchar(MAX)")
					.IsRequired();
				entity.Property(k => k.Ngaydanhgia)
					.HasColumnName("NGAYDANHGIA")
					.IsRequired();
				entity.Property(k => k.Idspchitiet)
					.HasColumnName("IDSPCHITIET")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Hinhanh)
					.HasColumnName("HINHANH")
					.HasColumnType("Nvarchar(MAX)")
					.IsRequired();
			});
			//Gio hang
			modelBuilder.Entity<Giohang>(entity =>
			{
				entity.ToTable("GIOHANG");
				entity.HasKey(k => k.Idkh);
				entity.Property(k => k.Idkh)
					.HasColumnName("IDKH")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Soluong)
					.HasColumnName("SOLUONG")
					.IsRequired();
			});
			//Giam gia - tich diem
			modelBuilder.Entity<Giamgiatichdiem>(entity =>
			{
				entity.ToTable("GIAMGIA_TICHDIEM");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idkh)
					.HasColumnName("IDKH")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idvoucher)
					.HasColumnName("IDVOUCHER")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Soluong)
					.HasColumnName("SOLUONG")
					.IsRequired();
			});
			//Giam gia
			modelBuilder.Entity<Giamgia>(entity =>
			{
				entity.ToTable("GIAMGIA");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Mota)
					.HasColumnName("MOTA")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Giatri)
					.HasColumnName("GIATRI")
					.IsRequired();
				entity.Property(k => k.Ngaybatdau)
					.HasColumnName("NGAYBATDAU")
					.IsRequired();
				entity.Property(k => k.Ngayketthuc)
					.HasColumnName("NGAYKETTHUC")
					.IsRequired();
				entity.Property(k => k.Trangthai)
					.HasColumnName("TRANGTHAI")
					.HasColumnType("nvarchar(50)")
					.IsRequired();
			});
			//Hoa don chi tiet
			modelBuilder.Entity<Hoadonchitiet>(entity =>
			{
				entity.ToTable("HOADONCHITIET");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idhoadon)
					.HasColumnName("IDHOADON")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idspchitiet)
					.HasColumnName("IDSPCHITIET")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Soluong)
					.HasColumnName("SOLUONG")
					.IsRequired();
				entity.Property(k => k.Giamgia)
					.HasColumnName("GIAMGIA")
					.IsRequired();
				entity.Property(k => k.Iddanhgia)
					.HasColumnName("IDDANHGIA")
					.HasColumnType("varchar(10)")
					.IsRequired();
			});
			//Tra hang chi tiet
			modelBuilder.Entity<Trahangchitiet>(entity =>
			{
				entity.ToTable("TRAHANGCHITIET");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idhoadonchitiet)
					.HasColumnName("IDHOADONCHITIET")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Soluong)
					.HasColumnName("SOLUONG")
					.IsRequired();
				entity.Property(k => k.Tinhtrang)
					.HasColumnName("TINHTRANG")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Ghichu)
					.HasColumnName("GHICHU")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Hinhthucxuly)
					.HasColumnName("HINHTHUCXULY")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
			});
			//Tra hang
			modelBuilder.Entity<Trahang>(entity =>
			{
				entity.ToTable("TRAHANG");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Tenkhachhang)
					.HasColumnName("TENKHACHHANG")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Idkh)
					.HasColumnName("IDKH")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idnv)
					.HasColumnName("IDNV")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Sotienhoan)
					.HasColumnName("SOTIENHOAN")
					.IsRequired();
				entity.Property(k => k.Lydotrahang)
					.HasColumnName("LYDOTRHANG")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Trangthai)
					.HasColumnName("TRANGTHAI")
					.HasColumnType("nvarchar(50)")
					.IsRequired();
				entity.Property(k => k.Phuongthuchoantien)
					.HasColumnName("PHUONGTHUCHOANTIEN")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Ngaytrahang)
					.HasColumnName("NGAYTRAHANG")
					.IsRequired();
				entity.Property(k => k.Chuthich)
					.HasColumnName("CHUTHICH")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
			});
			//hinh anh
			modelBuilder.Entity<Hinhanh>(entity =>
			{
				entity.ToTable("HINHANH");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Urlhinhanh)
					.HasColumnName("URLHINHANH")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
			});
			//Gio hang chi tiet
			modelBuilder.Entity<Giohangchitiet>(entity =>
			{
				entity.ToTable("GIOHANGCHITIET");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idgiohang)
					.HasColumnName("IDGIOHANG")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idspchitiet)
					.HasColumnName("IDSPCHITIET")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Soluong)
					.HasColumnName("SOLUONG")
					.IsRequired();
			});
			//San pham chi tiet
			modelBuilder.Entity<Sanphamchitiet>(entity =>
			{
				entity.ToTable("SANPHAMCHITIET");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idsp)
					.HasColumnName("IDSP")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Mota)
					.HasColumnName("MOTA")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Trangthai)
					.HasColumnName("TRANGTHAI")
					.HasColumnType("nvarchar(50)")
					.IsRequired();
				entity.Property(k => k.Giathoidiemhientai)
					.HasColumnName("GIATHOIDIEMHIENTAI")
					.IsRequired();
				entity.Property(k => k.Soluong)
					.HasColumnName("SOLUONG")
					.IsRequired();
			});
			//san pham
			modelBuilder.Entity<Sanpham>(entity =>
			{
				entity.ToTable("SANPHAM");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Tensp)
					.HasColumnName("TENSP")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Mota)
					.HasColumnName("MOTA")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Giaban)
					.HasColumnName("GIABAN")
					.IsRequired();
				entity.Property(k => k.Giasale)
					.HasColumnName("GIASALE")
					.IsRequired();
				entity.Property(k => k.Hinhanh)
					.HasColumnName("HINHANH")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
			});
			//Hoa don nhap chi tiet
			modelBuilder.Entity<Hoadonnhapchitiet>(entity =>
			{
				entity.ToTable("HOADONNHAPCHITIET");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idhoadonnhap)
					.HasColumnName("IDHOADONNHAP")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idsp)
					.HasColumnName("IDSP")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Soluong)
					.HasColumnName("SOLUONG")
					.IsRequired();
				entity.Property(k => k.Gianhap)
					.HasColumnName("GIANHAP")
					.IsRequired();
			});
			//Hoa don nhap
			modelBuilder.Entity<Hoadonnhap>(entity =>
			{
				entity.ToTable("HOADONNHAP");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idnv)
					.HasColumnName("IDNV")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Trangthai)
					.HasColumnName("TRANGTHAI")
					.HasColumnType("nvarchar(50)")
					.IsRequired();
				entity.Property(k => k.Tongtienhang)
					.HasColumnName("TONGTIEN")
					.IsRequired();
				entity.Property(k => k.Nguoigiao)
					.HasColumnName("NGUOIGIAO")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Sdtnguoigiao)
					.HasColumnName("SDTNGUOIGIAO")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.HasOne(k => k.Nhanvien)
					.WithMany(k => k.Hoadonnhaps)
					.HasForeignKey(k => k.Idnv);
			});
			//nha cung cap
			modelBuilder.Entity<Nhacungcap>(entity =>
			{
				entity.ToTable("NHACUNGCAP");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Tennhacungcap)
					.HasColumnName("TENNHACUNGCAP")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Sdt)
					.HasColumnName("SDT")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Diachi)
					.HasColumnName("DIACHI")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Email)
					.HasColumnName("EMAIL")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Trangthai)
					.HasColumnName("TRANGTHAI")
					.HasColumnType("nvarchar(50)")
					.IsRequired();
			});
			//thuong hieu
			modelBuilder.Entity<Thuonghieu>(entity =>
			{
				entity.ToTable("THUONGHIEU");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Tenthuonghieu)
					.HasColumnName("TENTHUONGHIEU")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Tinhtrang)
					.HasColumnName("TINHTRANG")
					.HasColumnType("nvarchar(50)")
					.IsRequired();
			});
			//sale
			modelBuilder.Entity<Sale>(entity =>
			{
				entity.ToTable("SALE");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Ten)
					.HasColumnName("TEN")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
				entity.Property(k => k.Thoihan)
					.HasColumnName("THOIHAN")
					.IsRequired();
				entity.Property(k => k.Mota)
					.HasColumnName("MOTA")
					.HasColumnType("nvarchar(max)")
					.IsRequired();
				entity.Property(k => k.Trangthai)
					.HasColumnName("TRANGTHAI")
					.HasColumnType("nvarchar(50)")
					.IsRequired();
				entity.Property(k => k.Ngaybatdau)
					.HasColumnName("NGAYBATDAU")
					.IsRequired();
				entity.Property(k => k.Ngayketthuc)
					.HasColumnName("NGAYKETTHUC")
					.IsRequired();
			});
			//sale ct
			modelBuilder.Entity<Salechitiet>(entity =>
			{
				entity.ToTable("SALECHITIET");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idspchitiet)
					.HasColumnName("IDSPCHITIET")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idsale)
					.HasColumnName("IDSALE")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Donvi)
					.HasColumnName("DONVI")
					.IsRequired();
				entity.Property(k => k.Soluong)
					.HasColumnName("SOLUONG")
					.IsRequired();
				entity.Property(k => k.Giamgia)
					.HasColumnName("GIAMGIA")
					.IsRequired();
			});
			//Thuoc tinh - san pham chi tiet
			modelBuilder.Entity<Thuoctinhsanphamchitiet>(entity =>
			{
				entity.ToTable("THUOCTINH_SANPHAMCHITIET");
				entity.HasKey(k => new { k.Idthuoctinh, k.Idspchitiet });
				entity.Property(k => k.Idthuoctinh)
					.HasColumnName("IDTHUOCTINH")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Idspchitiet)
					.HasColumnName("IDSPCHITIET")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Tenthuoctinhchitiet)
					.HasColumnName("TENTHUOCTINHCHITIET")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
			});
			//Thuoc tinh
			modelBuilder.Entity<Thuoctinh>(entity =>
			{
				entity.ToTable("THUOCTINH");
				entity.HasKey(k => k.Id);
				entity.Property(k => k.Id)
					.HasColumnName("ID")
					.HasColumnType("varchar(10)")
					.IsRequired();
				entity.Property(k => k.Tenthuoctinh)
					.HasColumnName("TENTHUOCTINH")
					.HasColumnType("nvarchar(100)")
					.IsRequired();
			});
		}
	}
}
