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
	public class SanphamchitietService : ISanphamchitietService
	{
		private readonly ISanphamchitietRepository _repository;
		private readonly ISanPhamservice _sprepository;
		
		public SanphamchitietService(ISanphamchitietRepository repository, ISanPhamservice sprepository)
		{
			_repository = repository;
			_sprepository = sprepository;


		}

		public async Task<IEnumerable<Sanphamchitiet>> GetAllAsync()
		{
			
			var entities = await _repository.GetAllAsync();
			
			return entities.Select(sp => new Sanphamchitiet
			{
				Id = sp.Id,
				Mota = sp.Mota,
				Giathoidiemhientai =sp.Giathoidiemhientai,
				Soluong = sp.Soluong,
				Trangthai= sp.Trangthai,
				Idsp = sp.Idsp,
				


		});
		}

		// Phương thức lấy sản phẩm chi tiết theo Id
		public async Task<Sanphamchitiet> GetByIdAsync(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null) return null;

			return new Sanphamchitiet
			{
				Id = entity.Id,
				Mota = entity.Mota,
				
				Soluong = entity.Soluong,
				Idsp = entity.Idsp,
				
			};
		}

		// Phương thức  phẩm chi tiết
		public async Task AddAsync(SanphamchitietDto dto)
		{
			var sanpham = await _sprepository.GetByIdAsync(dto.Idsp);
			var entity = new Sanphamchitiet
			{
				Mota = dto.Mota,
				Soluong = dto.Soluong,
				Trangthai = dto.Soluong > 0 ? 0 : 1,
				Giathoidiemhientai = sanpham.Giaban,
				Idsp = dto.Idsp
				// Không cần thiết cập nhật Trangthai và Giathoidiemhientai ở đây
				// vì chúng sẽ được tính tự động khi truy xuất
			};
			await _repository.AddAsync(entity);
		}

		// Phương thức cập nhật sản phẩm chi tiết
		public async Task UpdateAsync(SanphamchitietDto dto,int id)
		{
			var sanpham = await _sprepository.GetByIdAsync(dto.Idsp);
			var entity = await _repository.GetByIdAsync(id);
			if (entity != null)
			{
				entity.Mota = dto.Mota;
				entity.Soluong = dto.Soluong;
				entity.Idsp = dto.Idsp;
				entity.Trangthai = dto.Soluong > 0 ? 0 : 1;
				entity.Giathoidiemhientai = sanpham.Giaban;
				
				await _repository.UpdateAsync(entity);
			}
		}

		// Phương thức xóa sản phẩm chi tiết
		public async Task DeleteAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public Task UpdateAsync(SanphamchitietDto dto)
		{
			throw new NotImplementedException();
		}
	}
	}
