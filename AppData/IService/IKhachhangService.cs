using AppData.Dto;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IService
{
    public interface IKhachhangService
    {
        Task<IEnumerable<KhachhangDTO>> GetAllKhachhangsAsync();
        Task<KhachhangDTO> GetKhachhangByIdAsync(int id);
        Task AddKhachhangAsync(KhachhangDTO dto);
        Task UpdateKhachhangAsync(int id, KhachhangDTO dto);
        Task DeleteKhachhangAsync(int id);
        Task<IEnumerable<KhachhangDTO>> TimKiemAsync(string search);
		Task<(bool IsSuccess, string Otp)> SendOtpAsync(string email);
		string GenerateOtp();
		Task<bool> ChangePasswordAsync(DoimkKhachhang changePasswordDto);
		Task<KhachhangDTO> FindByEmailAsync(string email);
	}
}
