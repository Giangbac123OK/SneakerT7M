using AppData.Models;

namespace AppView.IServices
{
	public interface INhanvienService
	{
		Task<List<Nhanvien>> GetAll();
		Task<Nhanvien> Get(int id);
		Task Create(Nhanvien nv);
		Task Update(int id,Nhanvien nv);
		Task Delete(int id);
		Task Login(string sdt, string password);
	}
}
