using AppData.Dto;
using AppData.IRepository;
using AppData.IService;
using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Service
{
	public class RankSevi : IRankServiece
	{
		private readonly IRankRepos _repos;
		public RankSevi(IRankRepos repos)
		{
			_repos = repos;
		}
		public async Task AddRankDTOAsync(RankDTO rankDto)
		{
			var asf = new Rank()
			{
				tenrank = rankDto.TenRank,
				maxMoney = rankDto.MaxMoney,
				minMoney = rankDto.MinMoney,
				trangthai = 0,
				
			};
			await _repos.AddAsync(asf);
		}

		public async Task DeleteRankAsync(int id)
		{
			await _repos.DeleteAsync(id);
		}

		public async Task<IEnumerable<RankDTO>> GetAllRanksAsync()
		{
			var a = await _repos.GetAllAsync();
			return a.Select(x => new RankDTO()
			{
				TenRank = x.tenrank,
				MaxMoney = x.maxMoney,
				MinMoney = x.minMoney,
				trangthai = x.trangthai,
			});
		}

		public async Task<RankDTO> GetRankByIdAsync(int id)
		{
			var x = await _repos.GetByIdAsync(id);
			return new RankDTO()
			{
				TenRank = x.tenrank,
				MaxMoney = x.maxMoney,
				MinMoney = x.minMoney,
				trangthai = x.trangthai,
			};
		}

		public async Task UpdateRankAsync(int id, RankDTO rankDTO)
		{
			var x = await _repos.GetByIdAsync(id);
			if (x == null) throw new KeyNotFoundException("Khách hàng không tồn tại.");
			x.tenrank = rankDTO.TenRank;
			x.maxMoney = rankDTO.MaxMoney;
			x.minMoney = rankDTO.MinMoney;
			x.trangthai = rankDTO.trangthai;
			await _repos.UpdateAsync(x);
				
			
		}
	}
}
