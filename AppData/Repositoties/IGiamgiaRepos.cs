using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppData.Repositoties
{
	public interface IGiamgiaRepos
	{
		Task<IEnumerable<Giamgia>> GetAllAsync();
		Task<Giamgia> GetByIdAsync(int id);
		Task<Giamgia> AddAsync(Giamgia giamgia);
		Task<Giamgia> UpdateAsync(Giamgia giamgia);
		Task AddRankToGiamgia(int giamgiaId, List<string> rankNames);
		Task DeleteAsync(int id);
	}
}
