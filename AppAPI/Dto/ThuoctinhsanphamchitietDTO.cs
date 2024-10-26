using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Dto
{
	public class ThuoctinhsanphamchitietDTO
	{
		[Required(ErrorMessage = "Tên thuộc tính chi tiết không được để trống")]
		[MaxLength(50)]
        public string Tenthuoctinhchitiet { get; set; }
    }
}
