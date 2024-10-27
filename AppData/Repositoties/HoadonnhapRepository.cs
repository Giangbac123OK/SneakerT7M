using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppData.Repositoties
{
	public class HoadonnhapRepository : IhoadonnhapRepository
	{
		private readonly MyDbContext _context;
		public HoadonnhapRepository(MyDbContext context)
        {
            _context = context;
        }
        public Hoadonnhap AddHoadonnhap(Hoadonnhap hoadonnhap)
		{
			_context.hoadonnhaps.Add(hoadonnhap);
			_context.SaveChanges();
			return hoadonnhap;
		}

		public Nhacungcap GetNhacungcapById(int id)
		{
			return _context.nhacungcaps.Find(id);
		}
	}
}
