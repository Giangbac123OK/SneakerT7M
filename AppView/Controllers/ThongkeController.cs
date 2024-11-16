using AppData.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class ThongkeController : Controller
    {

        private readonly HttpClient _client;
        public ThongkeController(HttpClient client)
        {
            _client = client;
        }
        public IActionResult Thongke(string thoigian)
        {
            var response = _client.GetStringAsync($"https://localhost:7297/api/Thongke/{thoigian}").Result;
            var data = JsonConvert.DeserializeObject<ThongkeDTO>(response);
            return View(data);
        }
    }
}
