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
    public class ThuoctinhsanphamchitietService : IThuoctinhsanphamchitietService
    {
        private readonly IThuoctinhsanphamchitietRepos _repository;

        public ThuoctinhsanphamchitietService(IThuoctinhsanphamchitietRepos repos)
        {
            _repository = repos;
        }


        public async Task<IEnumerable<ThuoctinhsanphamchitietDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new ThuoctinhsanphamchitietDTO
            {
                Tenthuoctinhchitiet = e.Tenthuoctinhchitiet
            });
        }

        public async Task<ThuoctinhsanphamchitietDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new ThuoctinhsanphamchitietDTO
            {
                Tenthuoctinhchitiet = entity.Tenthuoctinhchitiet
            };
        }

        public async Task<ThuoctinhsanphamchitietDTO> AddAsync(ThuoctinhsanphamchitietDTO dto)
        {
            var entity = new Thuoctinhsanphamchitiet
            {
                Tenthuoctinhchitiet = dto.Tenthuoctinhchitiet
            };

            var addedEntity = await _repository.AddAsync(entity);
            return new ThuoctinhsanphamchitietDTO
            {
                Tenthuoctinhchitiet = addedEntity.Tenthuoctinhchitiet
            };
        }

        public async Task<ThuoctinhsanphamchitietDTO> UpdateAsync(int id, ThuoctinhsanphamchitietDTO dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.Tenthuoctinhchitiet = dto.Tenthuoctinhchitiet;

            var updatedEntity = await _repository.UpdateAsync(entity);
            return new ThuoctinhsanphamchitietDTO
            {
                Tenthuoctinhchitiet = updatedEntity.Tenthuoctinhchitiet
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
