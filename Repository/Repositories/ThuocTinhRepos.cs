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
    public class ThuocTinhRepos : IThuocTinhhRepos
    {
        private readonly MyDbContext _context;
        public ThuocTinhRepos(MyDbContext context)
        {
            _context = context;
        }
        public bool Add(Thuoctinh thuoctinh)
        {
            try
            {
                _context.thuoctinhs.Add(thuoctinh);
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
                var a = _context.thuoctinhs.FirstOrDefault(d => d.Id == id);
                if (a != null)
                {
                    _context.thuoctinhs.Remove(a);
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

        public List<Thuoctinh> GetAll()
        {
            return _context.thuoctinhs.ToList();
        }

        public Thuoctinh GetById(int id)
        {
            return _context.thuoctinhs.Find(id);
        }

        public bool Update(int id, Thuoctinh thuoctinh)
        {
            try
            {
                var a = _context.thuoctinhs.FirstOrDefault(d => d.Id == id);
                if (a != null)
                {
                    a.Tenthuoctinh = thuoctinh.Tenthuoctinh;
                    _context.thuoctinhs.Update(a);
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
