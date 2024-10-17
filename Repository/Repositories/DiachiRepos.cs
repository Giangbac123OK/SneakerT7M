using AppData;
using AppData.Models;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class DiachiRepos : IDiachiRepos
    {
        private readonly MyDbContext _context;
        public DiachiRepos(MyDbContext context)
        {
            _context = context;
        }
        public bool Add(Diachi diachi)
        {
            try
            {
                _context.diachis.Add(diachi);
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
                var a = _context.diachis.FirstOrDefault(d => d.Id == id);
                if (a != null)
                {
                    _context.diachis.Remove(a);
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

        public List<Diachi> GetAll()
        {
            return _context.diachis.ToList();
        }

        public Diachi GetById(int id)
        {
            return _context.diachis.Find(id);
        }

        public bool Update(int id, Diachi diachi)
        {
            try
            {
                var a = _context.diachis.FirstOrDefault(d => d.Id == id);
                if (a != null)
                {
                    a.Idkh = diachi.Idkh;
                    a.Thanhpho = diachi.Thanhpho;
                    a.Quanhuyen = diachi.Quanhuyen;
                    a.Phuongxa = diachi.Phuongxa;
                    a.Diachicuthe = diachi.Diachicuthe;
                    _context.diachis.Update(a);
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
