using AppData.Models;
using AppData;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ThuoctinhsanphamchitietRepos : IThuoctinhsanphamchitietRepos
    {
        private readonly MyDbContext _context;
        public ThuoctinhsanphamchitietRepos(MyDbContext context)
        {
            _context = context;
        }
        public bool Add(Thuoctinhsanphamchitiet thuoctinhsanphamchitiet)
        {
            try
            {
                _context.thuoctinhsanphamchitiets.Add(thuoctinhsanphamchitiet);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var a = _context.thuoctinhsanphamchitiets.FirstOrDefault(d => d.Idtt == id);
                if (a != null)
                {
                    _context.thuoctinhsanphamchitiets.Remove(a);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<Thuoctinhsanphamchitiet> GetAll()
        {
            return _context.thuoctinhsanphamchitiets.ToList();
        }

        public Thuoctinhsanphamchitiet GetById(int id)
        {
            return _context.thuoctinhsanphamchitiets.Find(id);
        }

        public bool Update(int id, Thuoctinhsanphamchitiet thuoctinhsanphamchitiet)
        {
            try
            {
                var a = _context.thuoctinhsanphamchitiets.FirstOrDefault(d => d.Idtt == id);
                if (a != null)
                {
                    a.Tenthuoctinhchitiet = thuoctinhsanphamchitiet.Tenthuoctinhchitiet;
                    _context.thuoctinhsanphamchitiets.Update(a);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
