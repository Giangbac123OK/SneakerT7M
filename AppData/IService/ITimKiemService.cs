using AppData.Models;
using AppData.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IService
{
    public interface ITimKiemService
    {
        Task<List<NhanvienDTO>> TimKiemNhanVien(string search);
        Task<List<KhachhangDTO>> TimKiemKhachHang(string search);
        Task<List<SanphamDTO>> TimKiemSanPham(string search);
    }
}
