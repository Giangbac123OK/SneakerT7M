using AppAPI.Dto;
using AppAPI.IRepository;
using AppAPI.IService;
using AppData.Models;
using AutoMapper;
using Humanizer;

namespace AppAPI.Service
{
    public class SanphamchitietService : ISanphamchitietService
    {
        private readonly ISanphamchitietRepos _repository;
        private readonly IMapper _mapper;
        public SanphamchitietService(ISanphamchitietRepos repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<SanphamchitietsDTO>> GetAllAsync()
        {
            var sanphamchitiets = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SanphamchitietsDTO>>(sanphamchitiets);
        }

        public async Task<SanphamchitietsDTO> GetByIdAsync(int id)
        {
            var sanphamchitiet = await _repository.GetByIdAsync(id);
            if (sanphamchitiet == null) throw new KeyNotFoundException("Không tìm thấy sản phẩm chi tiết.");

            return _mapper.Map<SanphamchitietsDTO>(sanphamchitiet);
        }

        public async Task AddAsync(SanphamchitietsDTO dto)
        {
            var sanphamchitiet = _mapper.Map<Sanphamchitiet>(dto);
            await _repository.AddAsync(sanphamchitiet);
        }

        public async Task UpdateAsync(int id, SanphamchitietsDTO dto)
        {
            var existingSanphamCT = await _repository.GetByIdAsync(id);
            if (existingSanphamCT == null) throw new KeyNotFoundException("Không tìm thấy sản phẩm chi tiết.");
            _mapper.Map(dto, existingSanphamCT);
            await _repository.UpdateAsync(existingSanphamCT);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task AddThuoctinhsanphamchitiet(ThuoctinhsanphamchitietDTO thuoctinhsanphamchitietDTO)
        {

            try
            {
                await _repository.AddThuoctinhsanphamchitiet(thuoctinhsanphamchitietDTO.Idspct, thuoctinhsanphamchitietDTO.Idtt, thuoctinhsanphamchitietDTO.Tenthuoctinhchitiet);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm thuộc tính chi tiết cho sản phẩm: {ex.Message}");
            }
        }



    }
}
