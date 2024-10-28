using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Service
{
    public class KhachhangService : IKhachhangService
    {
        private readonly IKhachhangRepos _repos;
        public KhachhangService(IKhachhangRepos repos)
        {
            _repos = repos;
        }

        public async Task AddKhachhangAsync(KhachhangDTO dto)
        {
            var kh = new Khachhang() 
            { 
                Ten = dto.Ten,
                Sdt = dto.Sdt,
                Ngaysinh = dto.Ngaysinh,
                Tichdiem = 0,
                Email = dto.Email,
                Diachi = dto.Diachi,
                Password = dto.Password,
                Diemsudung = 0,
                Trangthai = 0,
                Idrank = dto.Idrank
            };
            await _repos.AddAsync(kh);
        }

        public async Task DeleteKhachhangAsync(int id)
        {
            await _repos.DeleteAsync(id);
        }

        public async Task<IEnumerable<KhachhangDTO>> GetAllKhachhangsAsync()
        {
            var a = await _repos.GetAllAsync();
            return a.Select(x => new KhachhangDTO()
            {
                Ten = x.Ten,
                Sdt = x.Sdt,
                Ngaysinh = x.Ngaysinh,
                Tichdiem = x.Tichdiem,
                Email = x.Email,
                Diachi = x.Diachi,
                Password = x.Password,
                Diemsudung = x.Diemsudung,
                Trangthai = x.Trangthai,
                Idrank = x.Idrank
            });
        }

        public async Task<KhachhangDTO> GetKhachhangByIdAsync(int id)
        {
            var x = await _repos.GetByIdAsync(id);
            return new KhachhangDTO()
            {
                Ten = x.Ten,
                Sdt = x.Sdt,
                Ngaysinh = x.Ngaysinh,
                Tichdiem = x.Tichdiem,
                Email = x.Email,
                Diachi = x.Diachi,
                Password = x.Password,
                Diemsudung = x.Diemsudung,
                Trangthai = x.Trangthai,
                Idrank = x.Idrank
            };
        }

        public async Task UpdateKhachhangAsync(int id, KhachhangDTO dto)
        {
            var a = await _repos.GetByIdAsync(id);
            if (a == null) throw new KeyNotFoundException("Khách hàng không tồn tại.");

            a.Ten = dto.Ten;
            a.Sdt = dto.Sdt;
            a.Ngaysinh = dto.Ngaysinh;
            a.Tichdiem = dto.Tichdiem;
            a.Email = dto.Email;
            a.Diachi = dto.Diachi;
            a.Password = dto.Password;
            a.Diemsudung = dto.Diemsudung;
            a.Trangthai = dto.Trangthai;
            a.Idrank = dto.Idrank;

            await _repos.UpdateAsync(a);
        }
    }
}
