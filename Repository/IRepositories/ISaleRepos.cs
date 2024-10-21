using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ISaleRepos
    {
        Task<IEnumerable<Sale>> GetAllSale();
        Task<Sale> GetSaleByID(int id);
        Task create(Sale sale);
        Task update(Sale sale);
        Task delete(int id);
        Task SaveChanges();
    }
    public interface ISaleChiTietRepos
    {
        Task<IEnumerable<Salechitiet>> GetAllSaleChiTiet();
        Task<Salechitiet> GetSaleChiTietByID(int id);
        Task create(Salechitiet saleChiTiet);
        Task update(Salechitiet saleChiTiet);
        Task delete(int id);
        Task SaveChanges();
    }
}
