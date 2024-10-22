using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
	public interface IRankRepo
	{
		List<Rank> GetAll();
		Rank GetByid(int id);
		bool Add(Rank kh);
		bool Update(int id, Rank rk);
		bool Delete(int id);
	}
}
