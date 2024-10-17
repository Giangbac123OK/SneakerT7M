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
    public class KhachhangRepos : IKhachhangRepos
    {
        MyDbContext _context;
        public KhachhangRepos(MyDbContext context)
        {
            _context = context;
        }

        public bool Add(Khachhang kh)
        {
            try
            {
                _context.khachhangs.Add(kh);
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
                var a = _context.khachhangs.FirstOrDefault(kh => kh.Id == id);
                if (a != null)
                {
                    _context.khachhangs.Remove(a);
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

        public Khachhang Get(int id)
        {
            return _context.khachhangs.Find(id);
        }

        public List<Khachhang> GetAll()
        {
            return _context.khachhangs.ToList();
        }

        public bool Update(int id, Khachhang kh)
        {
            try
            {
                var a = _context.khachhangs.FirstOrDefault(kh => kh.Id == id);
                if (a != null)
                {
                    a.Ten = kh.Ten;
                    a.Sdt = kh.Sdt;
                    a.Ngaysinh = kh.Ngaysinh;
                    a.Tichdiem = kh.Tichdiem;
                    a.Diachi = kh.Diachi;
                    a.Password = kh.Password;
                    a.Diemsudung = kh.Diemsudung;
                    a.Trangthai = kh.Trangthai;
                    a.Idrank = kh.Idrank;
                    a.Rank = kh.Rank;
                    _context.khachhangs.Update(a);
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
