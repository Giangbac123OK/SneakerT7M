using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AppData.Models
{
    public enum TrahangStatus
    {

        [Description("Trả hàng thành công")]
        TraHangThanhCong = 0,

        [Description("Trả hàng không thành công")]
        TraHangKhongThanhCong = 1,

        [Description("Đơn hàng chờ trả hàng")]
        DonhangChoTraHang = 2
    }
    public class Trahang
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id {  get; set; }
		public string Tenkhachhang {  get; set; }
		public int? Idnv { get; set; }
		[ForeignKey("Idnv")]
		public virtual Nhanvien Nhanvien { get; set; }
		public int Idkh { get; set; }
		[ForeignKey("Idkh")]
		public virtual Khachhang Khachhang { get; set; }
		public decimal? Sotienhoan {  get; set; }
		public string? Lydotrahang {  get; set; }
		public int Trangthai {  get; set; }
		public string Phuongthuchoantien {  get; set; }
		public DateTime? Ngaytrahangdukien {  get; set; }
		public DateTime? Ngaytrahangthucte {  get; set; }
		public string? Chuthich {  get; set; }
		public virtual ICollection<Hinhanh> Hinhanhs { get; set; }
		public virtual ICollection<Trahangchitiet> Trahangchitiets { get; set; }

	}
}
