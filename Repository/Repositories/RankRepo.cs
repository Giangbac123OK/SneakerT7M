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
	public class RankRepo : IRankRepo
	{
		MyDbContext _context;
		public RankRepo(MyDbContext context)
		{
			_context = context;
		}

		public bool Add(Rank kh)
		{
			try
			{
				_context.ranks.Add(kh);
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
				var a = _context.ranks.FirstOrDefault(kh => kh.id == id);
				if (a != null)
				{
					_context.ranks.Remove(a);
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

		public Rank GetByid(int id)
		{
			return _context.ranks.Find(id);
		}

		public List<Rank> GetAll()
		{
			return _context.ranks.ToList();
		}

		public bool Update(int id, Rank ra)
		{
			try
			{
				var a = _context.ranks.FirstOrDefault(kh => kh.id == id);
				if (a != null)
				{
					a.tenrank = ra.tenrank;
					
					_context.ranks.Update(a);
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
