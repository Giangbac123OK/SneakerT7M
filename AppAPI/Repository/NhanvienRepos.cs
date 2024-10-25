using AppAPI.IRepository;
using AppData;
using AppData.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Repository
{
    public class NhanvienRepos : INhanvienRepos
    {
        private readonly MyDbContext _context;
        public NhanvienRepos(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Nhanvien> AddAsync(Nhanvien nv)
        {
            _context.nhanviens.AddAsync(nv);
            await _context.SaveChangesAsync();
            return nv;
        }

        public async Task DeleteAsync(int id)
        {
            var a = await _context.nhanviens.FindAsync(id);
            if (a != null)
            {
                _context.nhanviens.Remove(a);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Nhanvien>> GetAllAsync()
        {
            return await _context.nhanviens.ToListAsync();
        }

        public async Task<Nhanvien> GetByIdAsync(int id)
        {
            return await _context.nhanviens.FindAsync(id);
        }

        public async Task<Nhanvien> UpdateAsync(Nhanvien nv)
        {
            _context.nhanviens.Update(nv);
            await _context.SaveChangesAsync();
            return nv;
        }
    }
}
