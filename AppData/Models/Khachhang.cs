using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Khachhang
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Ten {  get; set; }
		public string Sdt {  get; set; }
		public DateTime Ngaysinh { get; set; }
		public decimal Tichdiem {  get; set; }
		public string? Email {  get; set; }
		public string Diachi {  get; set; }
		public string Password {  get; set; }
		public int Diemsudung {  get; set; }
		public int Trangthai {  get; set; }
		public int Idrank { get; set; }
		[ForeignKey("Idrank")]
		public virtual Rank Rank { get; set; }
		
		public  Giohang Giohang { get; set; }
		public virtual ICollection<Danhgia> Danhgias { get; set; }
		public virtual ICollection<Diachi> Diachis { get; set; }
		public virtual ICollection<Hoadon> Hoadons { get; set; }
	}
}
