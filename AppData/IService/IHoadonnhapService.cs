using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Dto;

namespace AppData.IService
{
    public interface IHoadonnhapService
    {
        (string message, string providerName) ValidateAndAddHoadonnhap(HoadonnhapDTO hoadonnhapDTO, int idnv);
    }
}
