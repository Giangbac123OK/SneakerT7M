using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Dto
{
	public class ThuonghieuDTO
	{
		[Required(ErrorMessage = "Tên thương hiệu không được để trống")]
		[MaxLength(50)]
        public string Tenthuonghieu { get; set; }

        [Range(0, 1, ErrorMessage = "Trạng thái phải là sử dụng hoặc không sử dụng")]
        public int Tinhtrang { get; set; }
    }
}
