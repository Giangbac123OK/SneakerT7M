using AppData.Models;

namespace AppAPI.IRepository
{
	public interface INhacungcapRepo
	{
		Task<IEnumerable<Nhacungcap>> GetAllAsync();
		Task<Nhacungcap> GetByIdAsync(int id);
		Task<Nhacungcap> AddAsync(Nhacungcap ncc);
		Task<Nhacungcap> UpdateAsync(Nhacungcap ncc);
		Task DeleteAsync(int id);
	}
}
