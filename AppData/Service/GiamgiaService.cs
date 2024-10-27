using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;
using AppData.Models;
using AppData.Repositoties;
using AutoMapper;

namespace AppData.Service
{
	public class GiamgiaService: IGiamgiaService
	{
		private readonly IGiamgiaRepos _repository;
		private readonly IMapper _mapper;
        public GiamgiaService(IGiamgiaRepos repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;	

		}
		public async Task<IEnumerable<GiamgiaDTO>> GetAllAsync()
		{
			var giamgias = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<GiamgiaDTO>>(giamgias);
		}

		public async Task<GiamgiaDTO> GetByIdAsync(int id)
		{
			var giamgia = await _repository.GetByIdAsync(id);
			if (giamgia == null) throw new KeyNotFoundException("Không tìm thấy mã giảm giá.");

			return _mapper.Map<GiamgiaDTO>(giamgia);
		}

		public async Task AddAsync(GiamgiaDTO dto)
		{
			var giamgia = _mapper.Map<Giamgia>(dto);
			await _repository.AddAsync(giamgia);
			
		}

		public async Task UpdateAsync(int id, GiamgiaDTO dto)
		{
			var existingGiamgia = await _repository.GetByIdAsync(id);
			if (existingGiamgia == null) throw new KeyNotFoundException("Không tìm thấy mã giảm giá.");
			_mapper.Map(dto, existingGiamgia);
			await _repository.UpdateAsync(existingGiamgia);
			
		}

		public async Task DeleteAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}

		public async Task AddRankToGiamgia(Giamgia_RankDTO dto)
		{
			var giamgia = new Giamgia
			{
				Mota = dto.Mota,
				Donvi = dto.Donvi,
				Giatri = dto.Giatri,
				Ngaybatdau = dto.Ngaybatdau,
				Ngayketthuc = dto.Ngayketthuc,
				Trangthai = dto.Trangthai
			};

			await _repository.AddAsync(giamgia);
			await _repository.AddRankToGiamgia(giamgia.Id, dto.RankNames);
		}
	}
}
