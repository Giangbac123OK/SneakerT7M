using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Giamgia
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string? Mota {  get; set; }
		public string Donvi {  get; set; }
		public int Giatri {  get; set; }
		public DateTime Ngaybatdau { get; set; }
		public DateTime Ngayketthuc { get; set; }
		public int Trangthai {  get; set; }
		public virtual ICollection<Hoadon> Hoadons { get; set; }
		public virtual ICollection<giamgia_rank> Giamgia_Ranks { get; set; }

	}
}
