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
	public class SalechitietService : ISalechitietService
	{
        private readonly IsalechitietRepos _repository;
        private readonly ISanphamchitietRepos _SPCTrepository;
        private readonly IsaleRepos _Salerepository;
        public SalechitietService(IsalechitietRepos repository, ISanphamchitietRepos SPCTrepository, IsaleRepos Salerepository)
        {
            _repository = repository;
            _SPCTrepository = SPCTrepository;
            _Salerepository = Salerepository;
        }

        public async Task<IEnumerable<Salechitiet>> GetAllAsync()
        {

            var entities = await _repository.GetAllAsync();

            return entities.Select(salect => new Salechitiet
            {
                Id = salect.Id,
                Idsale = salect.Idsale,
                Idspct = salect.Idspct,
                Donvi = salect.Donvi,
                Soluong = salect.Soluong,
                Giatrigiam = salect.Giatrigiam
            });
        }

        public async Task<Salechitiet> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new Salechitiet
            {
                Id = entity.Id,
                Idsale = entity.Idsale,
                Idspct = entity.Idspct,
                Donvi = entity.Donvi,
                Soluong = entity.Soluong,
                Giatrigiam = entity.Giatrigiam
            };
        }

        public async Task<Salechitiet> GetByIdAsyncSpct(int id)
        {
            var entity = await _repository.GetByIdAsyncSpct(id);
            if (entity == null) return null;

            return new Salechitiet
            {
                Id = entity.Id,
                Idsale = entity.Idsale,
                Idspct = entity.Idspct,
                Donvi = entity.Donvi,
                Soluong = entity.Soluong,
                Giatrigiam = entity.Giatrigiam
            };
        }

        public async Task AddAsync(SalechitietDTO spctDTO)
        {
            var idspct = await _SPCTrepository.GetByIdAsync(spctDTO.Idspct);
            if (idspct == null) throw new ArgumentNullException("Sản phẩm chi tiết không tồn tại");

            var entity = await _Salerepository.GetByIdAsync(spctDTO.Idsale);
            if (entity == null) throw new ArgumentNullException("Sale không tồn tại");


            // Tạo đối tượng Hoadon từ DTO
            var salect = new Salechitiet
            {
                Idsale = spctDTO.Idsale,
                Idspct = spctDTO.Idspct,
                Donvi = spctDTO.Donvi,
                Soluong = spctDTO.Soluong,
                Giatrigiam = spctDTO.Giatrigiam
            };

            // Thêm hóa đơn vào cơ sở dữ liệu
            await _repository.AddAsync(salect);
        }


        // Phương thức cập nhật hoá đơn
        public async Task UpdateAsync(SalechitietDTO dto, int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Hóa đơn không tồn tại");

            var idspct = await _SPCTrepository.GetByIdAsync(dto.Idspct);
            if (idspct == null) throw new ArgumentNullException("Sản phẩm chi tiết không tồn tại");

            var sale = await _Salerepository.GetByIdAsync(dto.Idsale);
            if (sale == null) throw new ArgumentNullException("Sale không tồn tại");


            if (entity != null)
            {
                entity.Idsale = dto.Idsale;
                entity.Idspct = dto.Idspct;
                entity.Donvi = dto.Donvi;
                entity.Soluong = dto.Soluong;
                entity.Giatrigiam = dto.Giatrigiam;

                await _repository.UpdateAsync(entity);
            }
        }

        // Phương thức xóa hoá đơn
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
