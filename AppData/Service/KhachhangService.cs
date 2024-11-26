﻿using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Service
{
    public class KhachhangService : IKhachhangService
    {
        private readonly IKhachhangRepos _repos;
		private readonly IConfiguration _configuration;
		public KhachhangService(IKhachhangRepos repos, IConfiguration configuration)
        {
            _configuration = configuration;
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

		public async Task<bool> ChangePasswordAsync(DoimkKhachhang changePasswordDto)
		{
			var doi = await _repos.GetByEmailAsync(changePasswordDto.Email);
			if (doi == null)
			{
				throw new Exception("Không tìm thấy nhân viên với email này.");
			}

			// Kiểm tra mật khẩu cũ
			if (doi.Password != changePasswordDto.OldPassword)
			{
				throw new Exception("Mật khẩu cũ không đúng.");
			}

			// Cập nhật mật khẩu mới
			doi.Password = changePasswordDto.NewPassword;
			await _repos.UpdateAsync(doi);

			return true;
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

		public async Task<(bool IsSuccess, string Otp)> SendOtpAsync(string email)
		{
			try
			{
				// Kiểm tra cấu hình
				var senderEmail = _configuration["EmailSettings:SenderEmail"]
					?? throw new InvalidOperationException("Sender email not configured");
				var senderPassword = _configuration["EmailSettings:SenderPassword"]
					?? throw new InvalidOperationException("Sender password not configured");
				var smtpServer = _configuration["EmailSettings:SmtpServer"]
					?? throw new InvalidOperationException("SMTP server not configured");
				var smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]
					?? throw new InvalidOperationException("SMTP port not configured"));

				var otp = GenerateOtp();
				var subject = "Mã OTP xác thực quên mật khẩu";
				var body = $"Mã OTP của bạn là: {otp}. Vui lòng không chia sẻ mã này với bất kỳ ai.";

				using var client = new SmtpClient(smtpServer)
				{
					Port = smtpPort,
					Credentials = new NetworkCredential(senderEmail, senderPassword),
					EnableSsl = true,
				};

				using var message = new MailMessage(senderEmail, email, subject, body);
				await client.SendMailAsync(message);

				return (true, otp);
			}
			catch (Exception ex)
			{
				// Log lỗi ở đây
				Console.WriteLine($"Error sending email: {ex.Message}");
				return (false, string.Empty);
			}
		}
		public string GenerateOtp()
		{
			var random = new Random();
			var otp = random.Next(100000, 999999).ToString();
			return otp;
		}
		public async Task<IEnumerable<KhachhangDTO>> TimKiemAsync(string search)
        {
            var a = await _repos.TimKiemAsync(search);
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

		public async Task<KhachhangDTO> FindByEmailAsync(string email)
		{
			
				var dto = await _repos.GetByEmailAsync(email);
				if (dto == null)
					return null;

				return new KhachhangDTO
				{

					Ten = dto.Ten,
					Sdt = dto.Sdt,
					Ngaysinh = dto.Ngaysinh,
					Tichdiem = dto.Tichdiem,
					Email = dto.Email,
					Diachi = dto.Diachi,
					Password = dto.Password,
					Diemsudung = dto.Diemsudung,
					Trangthai = dto.Trangthai,
					Idrank = dto.Idrank
				};
			
		}
	}
}
