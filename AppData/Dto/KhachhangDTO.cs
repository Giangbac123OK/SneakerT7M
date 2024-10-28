using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Dto
{
    public class KhachhangDTO
    {
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(50, ErrorMessage = "Họ tên không được vượt quá 50 ký tự")]
        public string Ten { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Số điện thoại phải có 10 chữ số")]
        public string Sdt { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public decimal Tichdiem { get; set; }
        public string? Email { get; set; }
        public string Diachi { get; set; }
        public string Password { get; set; }
        public int Diemsudung { get; set; }
        public int Trangthai { get; set; }
        public int Idrank { get; set; }
    }
}
