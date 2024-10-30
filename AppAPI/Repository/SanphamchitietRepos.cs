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

        public async Task AddThuoctinhsanphamchitiet(int idspct, int idtt, List<string> Tenthuoctinhchitiet)
        {
            var Sanphamchitiet = await _context.Sanphamchitiets.FindAsync(idspct);
            var Thuoctinh = await _context.thuoctinhs.FindAsync(idtt);
            if (Sanphamchitiet == null) throw new Exception("Sản phẩm chi tiết không tồn tại");
            if (Thuoctinh == null) throw new Exception("Thuộc tính không tồn tại");

            foreach (var Tenthuoctinhchitiets in Tenthuoctinhchitiet)
            {
                var TenTT = await _context.thuoctinhsanphamchitiets.FirstOrDefaultAsync(r => r.Tenthuoctinhchitiet == Tenthuoctinhchitiets);
                if (TenTT != null)
                {
                    var TenTTSpct = new Thuoctinhsanphamchitiet { Idspct = idspct, Idtt = idtt, Tenthuoctinhchitiet = Tenthuoctinhchitiets };
                    _context.thuoctinhsanphamchitiets.Add(TenTTSpct);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
