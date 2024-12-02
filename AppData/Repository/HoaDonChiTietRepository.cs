using AppData.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.ViewModel;

namespace AppData.Repository
{
    public class HoaDonChiTietRepos : IHoaDonChiTietRepository
    {
        private readonly MyDbContext _context;

        public HoaDonChiTietRepos(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hoadonchitiet>> GetAllAsync()
        {
            try
            {
                return await _context.hoadonchitiets
                                     .Include(h => h.Hoadon)
                                     .Include(h => h.Idspchitiet)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hóa đơn chi tiết.", ex);
            }
        }

        public async Task<Hoadonchitiet> GetByIdAsync(int id)
        {
            try
            {
                return await _context.hoadonchitiets
                                     .Include(h => h.Hoadon)
                                     .Include(h => h.Idspchitiet)
                                     .FirstOrDefaultAsync(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy hóa đơn chi tiết với ID {id}.", ex);
            }
        }

        public async Task<List<Hoadonchitiet>> HoadonchitietByIDHD(int id)
        {
            return await _context.hoadonchitiets
                                    .Where(t => t.Idhd == id)
                                    .ToListAsync();
        }

        public async Task AddAsync(Hoadonchitiet entity)
        {
            try
            {
                await _context.hoadonchitiets.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi thêm hóa đơn chi tiết vào cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi thêm hóa đơn chi tiết.", ex);
            }
        }


        public async Task UpdateAsync(Hoadonchitiet entity)
        {
            try
            {
                _context.hoadonchitiets.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi cập nhật hóa đơn chi tiết trong cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi cập nhật hóa đơn chi tiết.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.hoadonchitiets.FindAsync(id);
                if (entity != null)
                {
                    _context.hoadonchitiets.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Không tìm thấy hóa đơn chi tiết với ID {id} để xóa.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi xóa hóa đơn chi tiết trong cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi xóa hóa đơn chi tiết.", ex);
            }
        }

        public async Task<List<HoadonchitietViewModel>> HoadonchitietTheoMaHD(int id)
        {
            return await _context.hoadonchitiets.Where(x => x.Idhd == id)
                .Select(x => new HoadonchitietViewModel
                {
                    Id = x.Id,
                    Idhd = x.Idhd,
                    Idspct = x.Idspct,
                    Idsp = _context.Sanphamchitiets.FirstOrDefault(e => e.Id == x.Idspct).Idsp,
                    Tensp = _context.sanphams.FirstOrDefault(e => e.Id == x.Idspct).Tensp,
                    urlHinhanh = _context.sanphams.FirstOrDefault(e => e.Id == x.Idspct).UrlHinhanh,
                    Giasp = x.Giasp,
                    Giamgia = x.Giamgia ?? 0,
                    Soluong = x.Soluong,
                    Trangthaihd = _context.hoadons.FirstOrDefault(e => e.Id == x.Idhd).Trangthai
                })
                .ToListAsync();
        }
    }
}
