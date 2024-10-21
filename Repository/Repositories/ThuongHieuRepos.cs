using AppData;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ThuongHieuRepos : IThuongHieuRepos
    {
        private readonly MyDbContext _context;
        public ThuongHieuRepos(MyDbContext context)
        {
            _context = context;
        }
        public bool Add(Thuonghieu thuonghieu)
        {
            try
            {
                _context.thuonghieus.Add(thuonghieu);
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
                var a = _context.thuonghieus.FirstOrDefault(d => d.Id == id);
                if (a != null)
                {
                    _context.thuonghieus.Remove(a);
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

        public List<Thuonghieu> GetAll()
        {
            return _context.thuonghieus.ToList();
        }

        public Thuonghieu GetById(int id)
        {
            return _context.thuonghieus.Find(id);
        }

        public bool Update(int id, Thuonghieu thuonghieu)
        {
            try
            {
                var a = _context.thuonghieus.FirstOrDefault(d => d.Id == id);
                if (a != null)
                {
                    a.Tenthuonghieu = thuonghieu.Tenthuonghieu;
                    a.Tinhtrang = thuonghieu.Tinhtrang;
                    _context.thuonghieus.Update(a);
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
