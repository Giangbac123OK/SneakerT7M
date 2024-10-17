using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Phuongthucthanhtoan
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Tenpttt { get; set; }
		public int Trangthai {  get; set; }
		public virtual ICollection<Lichsuthanhtoan> Lichsuthanhtoans { get; set; }
	}
}
