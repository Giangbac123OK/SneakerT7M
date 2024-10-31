using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.IRepository;
using AppData;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repository
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
            return await _context.Sanphamchitiets.ToListAsync();
        }

        public async Task<Sanphamchitiet> GetByIdAsync(int id)
        {
            return await _context.Sanphamchitiets.FindAsync(id);
        }

        public async Task<Sanphamchitiet> AddAsync(Sanphamchitiet Sanphamchitiet)
        {
            _context.Sanphamchitiets.Add(Sanphamchitiet);
            await _context.SaveChangesAsync();
            return Sanphamchitiet;
        }

        public async Task<Sanphamchitiet> UpdateAsync(Sanphamchitiet Sanphamchitiet)
        {
            _context.Sanphamchitiets.Update(Sanphamchitiet);
            await _context.SaveChangesAsync();
            return Sanphamchitiet;
        }

        public async Task DeleteAsync(int id)
        {
            var Sanphamchitiet = await _context.Sanphamchitiets.FindAsync(id);
            if (Sanphamchitiet != null)
            {
                _context.Sanphamchitiets.Remove(Sanphamchitiet);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Không tìm thấy mã giảm giá");
            }
        }

        public async Task AddThuoctinhsanphamchitiet(int idspct, int idtt, List<string> tenthuoctinhchitietList)
        {
            try
            {
                var sanphamchitiet = await _context.Sanphamchitiets.FindAsync(idspct);
                if (sanphamchitiet == null)
                    throw new Exception("Sản phẩm chi tiết không tồn tại");

                var thuoctinh = await _context.thuoctinhs.FindAsync(idtt);
                if (thuoctinh == null)
                    throw new Exception("Thuộc tính không tồn tại");

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
                throw new Exception("Lỗi khi lưu thay đổi: " + ex.InnerException?.Message ?? ex.Message);
            }
        }


    }
}
