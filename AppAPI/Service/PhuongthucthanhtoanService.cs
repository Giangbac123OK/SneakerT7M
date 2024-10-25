using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.IRepository;
using AppAPI.Dto;
using AppAPI.IService;
using AppData.Models;


namespace AppAPI.Service
{
	public class PhuongthucthanhtoanService : IphuongthucthanhtoanServicee
	{
		private readonly IphuongthucthanhtoanRepos _repository;

		public PhuongthucthanhtoanService(IphuongthucthanhtoanRepos repos)
		{
			_repository = repos;
		}


		public async Task<IEnumerable<PhuongthucthanhtoanDTO>> GetAllAsync()
		{
			var entities = await _repository.GetAllAsync();
			return entities.Select(e => new PhuongthucthanhtoanDTO
			{
				Tenpttt = e.Tenpttt,
				Trangthai = e.Trangthai
			});
		}

		public async Task<PhuongthucthanhtoanDTO> GetByIdAsync(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null) return null;

			return new PhuongthucthanhtoanDTO
			{
				Tenpttt = entity.Tenpttt,
				Trangthai = entity.Trangthai
			};
		}

		public async Task<PhuongthucthanhtoanDTO> AddAsync(PhuongthucthanhtoanDTO dto)
		{
			var entity = new Phuongthucthanhtoan
			{
				Tenpttt = dto.Tenpttt,
				Trangthai = dto.Trangthai
			};

			var addedEntity = await _repository.AddAsync(entity);
			return new PhuongthucthanhtoanDTO
			{
				Tenpttt = addedEntity.Tenpttt,
				Trangthai = addedEntity.Trangthai
			};
		}

		public async Task<PhuongthucthanhtoanDTO> UpdateAsync(int id, PhuongthucthanhtoanDTO dto)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null) return null;

			entity.Tenpttt = dto.Tenpttt;
			entity.Trangthai = dto.Trangthai;

			var updatedEntity = await _repository.UpdateAsync(entity);
			return new PhuongthucthanhtoanDTO
			{
				Tenpttt = updatedEntity.Tenpttt,
				Trangthai = updatedEntity.Trangthai
			};
		}

		public async Task<bool> DeleteAsync(int id)
		{
			return await _repository.DeleteAsync(id);
		}
	}
}