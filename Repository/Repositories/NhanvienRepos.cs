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
    public class NhanvienRepos : INhanvienRepos
    {
        private readonly MyDbContext _context;
        public NhanvienRepos(MyDbContext context)
        {
            _context = context;
        }
        public bool Add(Nhanvien nhanvien)
        {
            try
            {
                _context.nhanviens.Add(nhanvien);
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
                var a = _context.nhanviens.FirstOrDefault(nh => nh.Id == id);
                if (a != null)
                {
                    _context.nhanviens.Remove(a);
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

        public List<Nhanvien> GetAll()
        {
            return _context.nhanviens.ToList();
        }

        public Nhanvien GetById(int id)
        {
            return _context.nhanviens.Find(id);
        }

        public bool Update(int id, Nhanvien nhanvien)
        {
            try
            {
                var a = _context.nhanviens.FirstOrDefault(nh => nh.Id == id);
                if (a != null)
                {
                    a.Hoten = nhanvien.Hoten;
                    a.Ngaysinh = nhanvien.Ngaysinh;
                    a.Diachi = nhanvien.Diachi;
                    a.Gioitinh = nhanvien.Gioitinh;
                    a.Sdt = nhanvien.Sdt;
                    a.Trangthai = nhanvien.Trangthai;
                    a.Password = nhanvien.Password;
                    a.Role = nhanvien.Role; 
                    _context.nhanviens.Update(a);
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
