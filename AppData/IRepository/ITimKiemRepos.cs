using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepository
{
    public interface ITimKiemRepos
    {
        Task<List<Nhanvien>> TimKiemNhanVien(string search);
        Task<List<Khachhang>> TimKiemKhachHang(string search);
        Task<List<Sanpham>> TimKiemSanPham(string search);
    }
}
