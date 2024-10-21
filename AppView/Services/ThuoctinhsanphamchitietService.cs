using AppData.Models;
using AppView.IServices;
using Newtonsoft.Json;

namespace AppView.Services
{
    public class ThuoctinhsanphamchitietService : IThuoctinhsanphamchitietService
    {
        private readonly HttpClient _httpClient;

        public ThuoctinhsanphamchitietService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Thuoctinhsanphamchitiet thuoctinhsanphamchitiet)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7202/api/Thuoctinhsanphamchitiets", thuoctinhsanphamchitiet);
        }

        public async Task Delete(Thuoctinhsanphamchitiet id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7202/api/Thuoctinhsanphamchitiets/{id}");
        }

        public async Task<IEnumerable<Thuoctinhsanphamchitiet>?> GetAllThuocTinhSanPhamChiTiets()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7202/api/Thuoctinhsanphamchitiets");
            var thuoctinhsanphamchitiet = JsonConvert.DeserializeObject<IEnumerable<Thuoctinhsanphamchitiet>>(response);
            return thuoctinhsanphamchitiet;
        }

        public async Task<Thuoctinhsanphamchitiet?> GetThuocTinhSanPhamChiTietById(Guid id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7202/api/Thuoctinhsanphamchitiets/{id}");
            var thuoctinhsanphamchitiet = JsonConvert.DeserializeObject<Thuoctinhsanphamchitiet>(response);
            return thuoctinhsanphamchitiet;
        }

        public async Task Update(Thuoctinhsanphamchitiet thuoctinhsanphamchitiet)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7202/api/Thuoctinhsanphamchitiets/{thuoctinhsanphamchitiet.Idtt}", thuoctinhsanphamchitiet);
        }
    }
}
