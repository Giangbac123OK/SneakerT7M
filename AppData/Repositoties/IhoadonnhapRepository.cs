using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.Models;

namespace AppData.Repositoties
{
	public interface IhoadonnhapRepository
	{
		Hoadonnhap AddHoadonnhap(Hoadonnhap hoadonnhap);
		Nhacungcap GetNhacungcapById(int id);

	}
}
