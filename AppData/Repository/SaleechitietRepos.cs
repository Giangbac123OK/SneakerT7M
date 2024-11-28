using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repository
{
	public class SaleechitietRepos : IsalechitietRepos
	{
        private readonly MyDbContext _context;

        public SaleechitietRepos(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salechitiet>> GetAllAsync()
        {
            try
            {
                return await _context.salechitiets
                                     .Include(h => h.Sale)
                                     .Include(h => h.spchitiet)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sale chi tiết.", ex);
            }
        }

        public async Task<Salechitiet> GetByIdAsync(int id)
        {
            try
            {
                return await _context.salechitiets
                                     .Include(h => h.Sale)
                                     .Include(h => h.spchitiet)
                                     .FirstOrDefaultAsync(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy sale chi tiết với ID {id}.", ex);
            }
        }


        public async Task<Salechitiet> GetByIdAsyncSpct(int id)
        {
            try
            {
                return await _context.salechitiets
                                     .Include(h => h.Sale)
                                     .Include(h => h.spchitiet)
                                     .FirstOrDefaultAsync(h => h.Idspct == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy sale chi tiết idspct với ID {id}.", ex);
            }
        }


        public async Task AddAsync(Salechitiet entity)
        {
            try
            {
                await _context.salechitiets.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi thêm sale chi tiết vào cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi thêm sale chi tiết.", ex);
            }
        }

        public async Task UpdateAsync(Salechitiet entity)
        {
            try
            {
                _context.salechitiets.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi cập nhật sale chi tiết trong cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi cập nhật sale chi tiết.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _context.salechitiets.FindAsync(id);
                if (entity != null)
                {
                    _context.salechitiets.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Không tìm thấy sale chi tiết với ID {id} để xóa.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Lỗi khi xóa sale chi tiết trong cơ sở dữ liệu.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi không xác định khi xóa sale chi tiết.", ex);
            }
        }

    }
}
