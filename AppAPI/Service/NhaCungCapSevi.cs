using AppAPI.Dto;
using AppAPI.IRepository;
using AppAPI.IService;
using AppData.Models;
using AutoMapper;

namespace AppAPI.Service
{
	public class NhaCungCapSevi: INhacungcapSevi
	{
		private readonly INhacungcapRepo _repository;
		private readonly IMapper _mapper;

		public NhaCungCapSevi(INhacungcapRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}
		public async Task<IEnumerable<NhacungcapDTO>> GetAllAsync()
		{
			var ncc = await _repository.GetAllAsync();
			return _mapper.Map<IEnumerable<NhacungcapDTO>>(ncc);
		}
		public async Task<NhacungcapDTO> GetByIdAsync(int id)
		{
			var ncc = await _repository.GetByIdAsync(id);
			return _mapper.Map<NhacungcapDTO>(ncc);
		}
		public async Task<NhacungcapDTO> AddAsync(NhacungcapDTO dto)
		{
			var ncc = _mapper.Map<Nhacungcap>(dto);
			await _repository.AddAsync(ncc);
			return _mapper.Map<NhacungcapDTO>(ncc);
		}

		public async Task<NhacungcapDTO> UpdateAsync(int id, NhacungcapDTO dto)
		{
			var ncc = await _repository.GetByIdAsync(id);
			_mapper.Map(dto, ncc);
			await _repository.UpdateAsync(ncc);
			return _mapper.Map<NhacungcapDTO>(ncc);
		}

		public async Task DeleteAsync(int id)
		{
			await _repository.DeleteAsync(id);
		}
	}
}
