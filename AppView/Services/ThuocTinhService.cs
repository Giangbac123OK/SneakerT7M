using AppData.Models;
using AppView.IServices;
using Newtonsoft.Json;

namespace AppView.Services
{
    public class ThuocTinhService : IThuoctinhService
    {
        private readonly HttpClient _httpClient;

        public ThuocTinhService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Thuoctinh thuoctinh)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7202/api/Thuoctinhs", thuoctinh);
        }

        public async Task Delete(Thuoctinh id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7202/api/Thuoctinhs/{id}");
        }

        public async Task<IEnumerable<Thuoctinh>?> GetAllThuocTinhs()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7202/api/Thuoctinhs");
            var thuonghieus = JsonConvert.DeserializeObject<IEnumerable<Thuoctinh>>(response);
            return thuonghieus;
        }

        public async Task<Thuoctinh?> GetThuocTinhById(Guid id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7202/api/Thuoctinhs/{id}");
            var thuoctinhs = JsonConvert.DeserializeObject<Thuoctinh>(response);
            return thuoctinhs;
        }

        public async Task Update(Thuoctinh thuoctinh)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7202/api/Thuoctinhs/{thuoctinh.Id}", thuoctinh);
        }
    }
}
