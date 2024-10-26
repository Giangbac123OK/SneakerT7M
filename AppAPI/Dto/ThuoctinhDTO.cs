using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAPI.Dto
{
	public class ThuoctinhDTO
	{
		[Required(ErrorMessage = "Tên thuộc tính không được để trống")]
		[MaxLength(50)]
        public string Tenthuoctinh { get; set; }
	}
}
