using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAPI.Dto;
using AppAPI.IRepository;
using AppAPI.IService;
using AppData.Models;
using AutoMapper;

namespace AppAPI.Service
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
			return _mapper.Map<GiamgiaDTO>(giamgia);
		}

		public async Task<GiamgiaDTO> AddAsync(GiamgiaDTO dto)
		{
			var giamgia = _mapper.Map<Giamgia>(dto);
			await _repository.AddAsync(giamgia);
			return _mapper.Map<GiamgiaDTO>(giamgia);
		}

		public async Task<GiamgiaDTO> UpdateAsync(int id, GiamgiaDTO dto)
		{
			var existingGiamgia = await _repository.GetByIdAsync(id);
			_mapper.Map(dto, existingGiamgia);
			await _repository.UpdateAsync(existingGiamgia);
			return _mapper.Map<GiamgiaDTO>(existingGiamgia);
		}

		public async Task DeleteAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}
	}
}
