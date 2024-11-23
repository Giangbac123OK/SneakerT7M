using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppData.Service
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
        public async Task<IEnumerable<Sanphamchitiet>> GetAllAsync()
        {
            var sanphamchitiets = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<Sanphamchitiet>>(sanphamchitiets);
        }

        public async Task<Sanphamchitiet> GetByIdAsync(int id)
        {
            var sanphamchitiet = await _repository.GetByIdAsync(id);
            if (sanphamchitiet == null) throw new KeyNotFoundException("Không tìm thấy sản phẩm chi tiết.");

            return _mapper.Map<Sanphamchitiet>(sanphamchitiet);
        }

        public async Task<List<ThuoctinhsanphamchitietDTO>> GetByIdTTSPCTAsync(int idspct)
        {
            try
            {
                // Gọi repository để lấy dữ liệu
                var results = await _repository.GetByIdTTSPCTAsync(idspct);

                if (results == null || !results.Any())
                    throw new KeyNotFoundException("Không tìm thấy thuộc tính sản phẩm chi tiết với ID: " + idspct);

                // Ánh xạ thủ công từ entity sang DTO
                var dtoList = results.Select(result => new ThuoctinhsanphamchitietDTO
                {
                    Idspct = result.Idspct,
                    Idtt = result.Idtt,
                    Tenthuoctinhchitiet = result.Tenthuoctinhchitiet.Split(',').ToList()
                }).ToList();

                return dtoList;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm thuộc tính sản phẩm chi tiết: " + ex.Message);
            }
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
