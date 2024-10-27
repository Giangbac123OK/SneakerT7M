using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
	public class Thuoctinhsanphamchitiet
	{
		[Key, Column(Order = 0)]
		public int Idtt { get; set; }

		[Key, Column(Order = 1)]
		public int Idspct { get; set; }

		public string Tenthuoctinhchitiet { get; set; }
		
		[ForeignKey("Idtt")]
		public virtual Thuoctinh Thuoctinh { get; set; }
		[ForeignKey("Idspct")]
		public virtual Sanphamchitiet Sanphamchitiet { get; set; }

	}
}
