using AppData.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Repository
{
    public class TimKiemRepos : ITimKiemRepos
    {
        private readonly MyDbContext _context;
        public TimKiemRepos(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Khachhang>> TimKiemKhachHang(string search)
        {
            return await _context.khachhangs
                .Where(x => x.Ten.StartsWith(search) || x.Sdt.StartsWith(search) || x.Email.StartsWith(search))
                .ToListAsync();
        }

        public async Task<List<Nhanvien>> TimKiemNhanVien(string search)
        {
            return await _context.nhanviens
                .Where(x => x.Hoten.StartsWith(search) || x.Sdt.StartsWith(search))
                .ToListAsync();
        }

        public async Task<List<Sanpham>> TimKiemSanPham(string search)
        {
            return await _context.sanphams
                .Where(x => x.Tensp.StartsWith(search))
                .ToListAsync();
        }
    }
}
