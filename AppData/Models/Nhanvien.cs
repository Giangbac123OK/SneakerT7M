using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Nhanvien
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
		public string Hoten { get; set; }
		public DateTime Ngaysinh { get; set; }
		public string Diachi {  get; set; }
		public bool Gioitinh {  get; set; }
		public string Sdt {  get; set; }
		public int Trangthai {  get; set; }
		public string Password {  get; set; }
		public int Role {  get; set; }
		public virtual ICollection<Hoadon> Hoadons { get; set; }
		public virtual ICollection<Hoadonnhap> Hoadonnhaps { get; set; }
		public virtual ICollection<Trahang> Trahangs { get; set; }
	}
}
