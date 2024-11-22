using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;

namespace AppData.Service
{
	public class ThuonghieuService:IthuonghieuService
	{
		private readonly IThuonghieuRepos _repository;
        public ThuonghieuService(IThuonghieuRepos repository)
        {
			_repository = repository;

		}
		public async Task<IEnumerable<Thuonghieu>> GetAllAsync()
		{
			return await _repository.GetAllAsync(); // Trả về danh sách đối tượng Thuonghieu
		}

		public async Task<ThuonghieuDTO> GetByIdAsync(int id)
		{
			var brand = await _repository.GetByIdAsync(id);
			return new ThuonghieuDTO
			{
				Tenthuonghieu = brand.Tenthuonghieu,
				// Chỉ cần trả về tên, không có Id
			};
		}

		public async Task AddAsync(ThuonghieuDTO thuonghieuDto)
		{
			var thuonghieu = new Thuonghieu
			{
				Tenthuonghieu = thuonghieuDto.Tenthuonghieu,
				Tinhtrang = 0 // Mặc định là hoạt động khi thêm mới
			};
			await _repository.AddAsync(thuonghieu);
		}

		public async Task UpdateAsync(int id, ThuonghieuDTO thuonghieuDto)
		{
			var thuonghieu = await _repository.GetByIdAsync(id);
			if (thuonghieu != null)
			{
				thuonghieu.Tenthuonghieu = thuonghieuDto.Tenthuonghieu;
				thuonghieu.Tinhtrang = 0; // Đảm bảo tình trạng vẫn là hoạt động
				await _repository.UpdateAsync(thuonghieu);
			}
		}

		public async Task DeleteAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task<IEnumerable<ThuonghieuDTO>> SearchByNameAsync(string name)
		{
			return await _repository.SearchByNameAsync(name);
		}
	}
}
