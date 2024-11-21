using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppData.Service
{
    public class TimKiemService : ITimKiemService
    {
        private readonly ITimKiemRepos _repos;
        public TimKiemService(ITimKiemRepos repos)
        {
            _repos = repos;
        }

        public async Task<List<KhachhangDTO>> TimKiemKhachHang(string search)
        {
            var a = await _repos.TimKiemKhachHang(search);
            return a.Select(x => new KhachhangDTO()
            {
                Ten = x.Ten,
                Sdt = x.Sdt,
                Ngaysinh = x.Ngaysinh,
                Tichdiem = x.Tichdiem,
                Email = x.Email,
                Diachi = x.Diachi,
                Password = x.Password,
                Diemsudung = x.Diemsudung,
                Trangthai = x.Trangthai,
                Idrank = x.Idrank
            }).ToList();
        }

        public async Task<List<NhanvienDTO>> TimKiemNhanVien(string search)
        {
            var a = await _repos.TimKiemNhanVien(search);
            return a.Select(n => new NhanvienDTO
            {
                Hoten = n.Hoten,
                Ngaysinh = n.Ngaysinh,
                Diachi = n.Diachi,
                Gioitinh = n.Gioitinh,
                Sdt = n.Sdt,
                Trangthai = n.Trangthai,
                Password = n.Password,
                Role = n.Role
            }).ToList();
        }

        public async Task<List<SanphamDTO>> TimKiemSanPham(string search)
        {
            var sanphams = await _repos.TimKiemSanPham(search);
            return sanphams.Select(sp => new SanphamDTO
            {
                Tensp = sp.Tensp,
                Mota = sp.Mota,
                Trangthai = sp.Trangthai,
                Soluong = sp.Soluong,
                Giaban = sp.Giaban,
                //Giasale = sp.Giasale,
                UrlHinhanh = sp.UrlHinhanh,
                Idth = sp.Idth
            }).ToList();
        }
    }
}
