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
    public class HoadonRepos : IHoadonRepository
    {
        private readonly MyDbContext _context;

        public HoadonRepos(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hoadon>> GetAllAsync()
        {
            try
            {
                return await _context.hoadons
                                     .Include(h => h.Giamgia)
                                     .Include(h => h.Khachhang)
                                     .Include(h => h.Nhanvien)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hóa đơn.", ex);
            }
        }

        public async Task<Hoadon> GetByIdAsync(int id)
        {
            try
            {
                return await _context.hoadons
                                     .Include(h => h.Giamgia)
                                     .Include(h => h.Khachhang)
                                     .Include(h => h.Nhanvien)
                                     .FirstOrDefaultAsync(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy hóa đơn với ID {id}.", ex);
            }
        }

        public async Task AddAsync(Hoadon entity)
        {
            try
            {
                await _context.hoadons.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi thêm hóa đơn vào cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi thêm hóa đơn.", ex);
            }
        }

        public async Task UpdateAsync(Hoadon entity)
        {
            try
            {
                _context.hoadons.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi cập nhật hóa đơn trong cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi cập nhật hóa đơn.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.hoadons.FindAsync(id);
                if (entity != null)
                {
                    _context.hoadons.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Không tìm thấy hóa đơn với ID {id} để xóa.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi xóa hóa đơn trong cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi xóa hóa đơn.", ex);
            }
        }
    }
}
