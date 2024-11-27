using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.IRepository;
using AppData;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using AppData.Dto;
using Microsoft.Data.SqlClient;

namespace AppData.Repository
{
    public class SanphamchitietRepos : ISanphamchitietRepos
    {
        private readonly MyDbContext _context;

        public SanphamchitietRepos(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sanphamchitiet>> GetAllAsync()
        {
            try
            {
                return await _context.Sanphamchitiets.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sản phẩm chi tiết: " + ex.Message);
            }
        }

        public async Task<Sanphamchitiet> GetByIdAsync(int id)
        {
            try
            {
                var result = await _context.Sanphamchitiets.FindAsync(id);
                if (result == null)
                    throw new KeyNotFoundException("Không tìm thấy sản phẩm chi tiết với ID: " + id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm sản phẩm chi tiết: " + ex.Message);
            }
        }
        public async Task<List<Sanphamchitiet>> GetByIdSPAsync(int idsp)
        {
            return await _context.Sanphamchitiets
                                   .Where(t => t.Idsp == idsp)
                                   .ToListAsync();
        }

        public async Task<List<Thuoctinhsanphamchitiet>> GetByIdTTSPCTAsync(int idspct)
        {
            return await _context.thuoctinhsanphamchitiets
                                   .Where(t => t.Idspct == idspct)
                                   .ToListAsync();
        }

        public async Task<Thuoctinhsanphamchitiet> GetByISPCTAsync(List<string> tenthuoctinh)
        {
            if (tenthuoctinh == null || !tenthuoctinh.Any())
                throw new ArgumentException("Danh sách thuộc tính không được để trống.");

            // Tạo câu lệnh SQL an toàn với tham số thay vì nối trực tiếp
            var tenthuoctinhParams = string.Join(",", tenthuoctinh.Select((t, index) => $"@t{index}"));

            var sqlQuery = $@"
                    SELECT tt.Idspct
                    FROM thuoctinhsanphamchitiets tt
                    WHERE tt.Tenthuoctinhchitiet IN ({tenthuoctinhParams})
                    GROUP BY tt.Idspct
                    HAVING COUNT(DISTINCT tt.Tenthuoctinhchitiet) = {tenthuoctinh.Count}";

            // Tạo danh sách các tham số
            var parameters = tenthuoctinh.Select((t, index) => new SqlParameter($"@t{index}", t)).ToArray();

            // Thực thi câu lệnh SQL với tham số
            var result = await _context.thuoctinhsanphamchitiets
                                       .FromSqlRaw(sqlQuery, parameters) // Truyền các tham số vào câu lệnh SQL
                                       .Select(tt => new Thuoctinhsanphamchitiet
                                       {
                                           Idspct = tt.Idspct
                                       })
                                       .FirstOrDefaultAsync();

            return result;
        }


        public async Task<Sanphamchitiet> AddAsync(Sanphamchitiet sanphamchitiet)
        {
            try
            {
                _context.Sanphamchitiets.Add(sanphamchitiet);
                await _context.SaveChangesAsync();
                return sanphamchitiet;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm chi tiết: " + ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Sanphamchitiet> UpdateAsync(Sanphamchitiet sanphamchitiet)
        {
            try
            {
                _context.Sanphamchitiets.Update(sanphamchitiet);
                await _context.SaveChangesAsync();
                return sanphamchitiet;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Lỗi khi cập nhật sản phẩm chi tiết: " + ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var sanphamchitiet = await _context.Sanphamchitiets.FindAsync(id);
                if (sanphamchitiet == null)
                    throw new KeyNotFoundException("Không tìm thấy sản phẩm chi tiết với ID: " + id);

                _context.Sanphamchitiets.Remove(sanphamchitiet);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm chi tiết: " + ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task AddThuoctinhsanphamchitiet(int idspct, int idtt, List<string> tenthuoctinhchitietList)
        {
            try
            {
                var sanphamchitiet = await _context.Sanphamchitiets.FindAsync(idspct);
                if (sanphamchitiet == null)
                    throw new Exception("Sản phẩm chi tiết không tồn tại với ID: " + idspct);

                var thuoctinh = await _context.thuoctinhs.FindAsync(idtt);
                if (thuoctinh == null)
                    throw new Exception("Thuộc tính không tồn tại với ID: " + idtt);

                foreach (var tenthuoctinhchitiet in tenthuoctinhchitietList)
                {
                    var existingThuoctinhchitiet = await _context.thuoctinhsanphamchitiets
                        .FirstOrDefaultAsync(r => r.Tenthuoctinhchitiet == tenthuoctinhchitiet
                                                   && r.Idspct == idspct
                                                   && r.Idtt == idtt);

                    if (existingThuoctinhchitiet == null)
                    {
                        var newThuoctinhchitiet = new Thuoctinhsanphamchitiet
                        {
                            Idspct = idspct,
                            Idtt = idtt,
                            Tenthuoctinhchitiet = tenthuoctinhchitiet
                        };
                        _context.thuoctinhsanphamchitiets.Add(newThuoctinhchitiet);
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Lỗi khi thêm thuộc tính chi tiết: " + ex.InnerException?.Message ?? ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm thuộc tính chi tiết: " + ex.Message);
            }
        }
    }
}
