using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Nhacungcap
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
		public string Tennhacungcap {  get; set; }
		public string Sdt {  get; set; }
		public string Diachi {  get; set; }
		public string? Email {  get; set; }
		public int Trangthai {  get; set; }
		public virtual ICollection<Hoadonnhap> Hoadonnhaps { get; set; }
	}
}
