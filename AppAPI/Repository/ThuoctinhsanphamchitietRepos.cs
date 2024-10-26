using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.IRepository;
using AppData.Models;
using Microsoft.EntityFrameworkCore;


namespace AppData.Repositoties
{
    public class ThuoctinhsanphamchitietRepos : IThuoctinhsanphamchitietRepos
    {
        private readonly MyDbContext _context;
        public ThuoctinhsanphamchitietRepos(MyDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Thuoctinhsanphamchitiet>> GetAllAsync()
        {
            return await _context.Set<Thuoctinhsanphamchitiet>().ToListAsync();
        }

        public async Task<Thuoctinhsanphamchitiet> GetByIdAsync(int id)
        {
            return await _context.Set<Thuoctinhsanphamchitiet>().FindAsync(id);
        }

        public async Task<Thuoctinhsanphamchitiet> AddAsync(Thuoctinhsanphamchitiet entity)
        {
            _context.Set<Thuoctinhsanphamchitiet>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Thuoctinhsanphamchitiet> UpdateAsync(Thuoctinhsanphamchitiet entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _context.Set<Thuoctinhsanphamchitiet>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
