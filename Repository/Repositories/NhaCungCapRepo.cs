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
	public class NhaCungCapRepo : INhaCungCapRepo
	{
		MyDbContext _context;
		public NhaCungCapRepo(MyDbContext context)
		{
			_context = context;
		}

		public bool Add(Nhacungcap kh)
		{
			try
			{
				_context.nhacungcaps.Add(kh);
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
				var a = _context.nhacungcaps.FirstOrDefault(kh => kh.Id == id);
				if (a != null)
				{
					_context.nhacungcaps.Remove(a);
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

		public Nhacungcap GetByid(int id)
		{
			return _context.nhacungcaps.Find(id);
		}

		public List<Nhacungcap> GetAll()
		{
			return _context.nhacungcaps.ToList();
		}

		public bool Update(int id, Nhacungcap kh)
		{
			try
			{
				var a = _context.nhacungcaps.FirstOrDefault(kh => kh.Id == id);
				if (a != null)
				{
					a.Tennhacungcap = kh.Tennhacungcap;
					a.Sdt = kh.Sdt;
					a.Diachi = kh.Diachi;
					a.Email = kh.Email;
					a.Diachi = kh.Diachi;
					a.Trangthai = kh.Trangthai;
					_context.nhacungcaps.Update(a);
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
