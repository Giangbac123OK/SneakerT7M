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
    public class HinhanhRepos : IHinhanhRepos
    {
        private readonly MyDbContext _context;
        public HinhanhRepos(MyDbContext context)
        {
            _context = context;
        }

        public async Task Add(Hinhanh hinhanh)
        {
            _context.hinhanhs.Add(hinhanh);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var a = await _context.hinhanhs.FirstOrDefaultAsync(x => x.Id == id);
            if (a != null)
            {
                _context.hinhanhs.Remove(a);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Khong tim thay id");
            }
        }

        public async Task<List<Hinhanh>> GetAll()
        {
            return await _context.hinhanhs.ToListAsync();
        }

        public async Task<Hinhanh> GetById(int id)
        {
            return await _context.hinhanhs.FindAsync(id);
        }

        public async Task Update(Hinhanh hinhanh)
        {
            _context.hinhanhs.Update(hinhanh);
            await _context.SaveChangesAsync();
        }
    }
}
