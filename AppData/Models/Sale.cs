using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Sale
	{
		public string Id {  get; set; }
		public string Ten {  get; set; }
		public TimeOnly Thoihan { get; set; }
		public string Mota {  get; set; }
		public string Trangthai {  get; set; }
		public DateTime Ngaybatdau { get; set; }
		public DateTime Ngayketthuc {  get; set; }
	}
}
