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
    public class GiohangRepos : IGiohangRepos
    {
        private readonly MyDbContext _context;
        public GiohangRepos(MyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Giohang gh)
        {
            if (_context.khachhangs.Find(gh.Idkh) != null)
            {
                if (gh.Soluong >= 0)
                {
                    await _context.giohangs.AddAsync(gh);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    new Exception("");
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            var a = await GetByIdAsync(id);
            if (a != null)
            {
                _context.giohangs.Remove(a);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Không tìm thấy nhân viên");
            }
        }

        public async Task<IEnumerable<Giohang>> GetAllAsync()
        {
            return await _context.giohangs.ToListAsync();
        }

        public async Task<Giohang> GetByIdAsync(int id)
        {
            return await _context.giohangs.FindAsync(id);
        }

        public async Task UpdateAsync(Giohang gh)
        {
            _context.giohangs.Update(gh);
            await _context.SaveChangesAsync();
        }
    }
}
