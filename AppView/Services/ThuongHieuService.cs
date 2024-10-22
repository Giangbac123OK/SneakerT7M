using AppData.Models;
using AppView.IServices;
using Newtonsoft.Json;
using System.Drawing;

namespace AppView.Services
{
    public class ThuongHieuService : IThuongHieuService
    {
        private readonly HttpClient _httpClient;

        public ThuongHieuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Create(Thuonghieu thuonghieu)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7202/api/Thuonghieus", thuonghieu);
        }

        public async Task Delete(Thuonghieu id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7202/api/Thuonghieus/{id}");
        }

        public async Task<IEnumerable<Thuonghieu>?> GetAllThuongHieus()
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7202/api/Thuonghieus");
            var thuonghieus = JsonConvert.DeserializeObject<IEnumerable<Thuonghieu>>(response);
            return thuonghieus;
        }

        public async Task<Thuonghieu?> GetThuongHieuById(Guid id)
        {
            var response = await _httpClient.GetStringAsync($"https://localhost:7202/api/Thuonghieus/{id}");
            var thuonghieus = JsonConvert.DeserializeObject<Thuonghieu>(response);
            return thuonghieus;
        }

        public async Task Update(Thuonghieu thuonghieu)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7202/api/Thuonghieus/{thuonghieu.Id}", thuonghieu);
        }
    }
}
