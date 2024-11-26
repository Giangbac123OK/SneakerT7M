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
    public class TraHangChiTietRepos : ITraHangChiTietRepos
    {
        private readonly MyDbContext _context;
        public TraHangChiTietRepos(MyDbContext context)
        {
            _context = context;
        }
        public async Task Add(Trahangchitiet ct)
        {
            _context.trahangchitiets.Add(ct);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var a = await _context.trahangchitiets.FirstOrDefaultAsync(x=>x.Id == id);
            if(a != null)
            {
                _context.trahangchitiets.Remove(a);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Không tồn tại!");
            }
        }

        public async Task<List<Trahangchitiet>> GetAll()
        {
            return await _context.trahangchitiets.ToListAsync();
        }

        public async Task<Trahangchitiet> GetById(int id)
        {
            return await _context.trahangchitiets.FindAsync(id);
        }

        public async Task<List<Trahangchitiet>> GetByMaHD(int id)
        {
            return await _context.trahangchitiets.Where(x=>x.Idth == id).ToListAsync();
        }

        public async Task Update(Trahangchitiet ct)
        {
            _context.trahangchitiets.Update(ct);
            await _context.SaveChangesAsync();
        }
    }
}
