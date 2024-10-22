using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
	public interface INhaCungCapRepo
	{
		List<Nhacungcap> GetAll();
		Nhacungcap GetByid(int id);
		bool Add(Nhacungcap kh);
		bool Update(int id, Nhacungcap rk);
		bool Delete(int id);
	}
}
