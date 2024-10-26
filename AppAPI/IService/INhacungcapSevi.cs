using AppAPI.Dto;

namespace AppAPI.IService
{
	public interface INhacungcapSevi
	{
		Task<IEnumerable<NhacungcapDTO>> GetAllAsync();
		Task<NhacungcapDTO> GetByIdAsync(int id);
		Task<NhacungcapDTO> AddAsync(NhacungcapDTO dto);
		Task<NhacungcapDTO> UpdateAsync(int id, NhacungcapDTO dto);
		Task DeleteAsync(int id);
	}
}
