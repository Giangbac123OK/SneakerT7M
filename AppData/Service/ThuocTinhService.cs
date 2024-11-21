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
    public class ThuocTinhService : IThuoctinhService
    {
        private readonly IThuoctinhRepository _repository;

        public ThuocTinhService(IThuoctinhRepository repos)
        {
            _repository = repos;
        }


        public async Task<IEnumerable<ThuoctinhDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new ThuoctinhDTO
            {
                Tenthuoctinh = e.Tenthuoctinh
            });
        }

        public async Task<ThuoctinhDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new ThuoctinhDTO
            {
                Tenthuoctinh = entity.Tenthuoctinh
            };
        }

        public async Task<ThuoctinhDTO> AddAsync(ThuoctinhDTO dto)
        {
            var entity = new Thuoctinh
            {
                Tenthuoctinh = dto.Tenthuoctinh
            };

            var addedEntity = await _repository.AddAsync(entity);
            return new ThuoctinhDTO
            {
                Tenthuoctinh = addedEntity.Tenthuoctinh
            };
        }

        public async Task<ThuoctinhDTO> UpdateAsync(int id, ThuoctinhDTO dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.Tenthuoctinh = dto.Tenthuoctinh;

            var updatedEntity = await _repository.UpdateAsync(entity);
            return new ThuoctinhDTO
            {
                Tenthuoctinh = updatedEntity.Tenthuoctinh
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
