using AppData.Models;
using AppView.IServices;
using Newtonsoft.Json;

namespace AppView.Services
{
	public class NhanvienService : INhanvienService
	{
		private readonly string url = "https://localhost:7202/api/Nhanvien";
		private readonly HttpClient _client;
		public NhanvienService(HttpClient client)
		{
			_client = client;
		}
		public async Task Create(Nhanvien nv)
		{
			await _client.PostAsJsonAsync(url, nv);
		}

		public async Task Delete(int id)
		{
			await _client.DeleteAsync(url+"/"+id);
		}

		public async Task<Nhanvien> Get(int id)
		{
			var response = await _client.GetStringAsync(url+"/"+id);
			var data =  JsonConvert.DeserializeObject<Nhanvien>(response);
			return data;
		}

		public async Task<List<Nhanvien>> GetAll()
		{
			var response = await _client.GetStringAsync(url);
			var data = JsonConvert.DeserializeObject<List<Nhanvien>>(response);
			return data;
		}

		public async Task Login(string sdt, string password)
		{
			var loginData = new { sdt = sdt, password = password };
			await _client.PostAsJsonAsync(url + "/login", loginData);
		}

		public async Task Update(int id, Nhanvien nv)
		{
			await _client.PutAsJsonAsync(url+"/"+id, nv);
		}
	}
}
