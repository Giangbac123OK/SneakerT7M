using System.ComponentModel.DataAnnotations;

namespace AppAPI.Dto
{
    public class NhanvienDTO
    {

        [Required(ErrorMessage = "Vui lòng nhập họ tên nhân viên!")]
        [StringLength(100, ErrorMessage = "Vui lòng nhập không quá 100 ký tự")]
        public string Hoten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string? Diachi { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn giới tính!")]
        public bool Gioitinh { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có đúng 10 chữ số!")]
        public string Sdt { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn trạng thái!")]
        public int Trangthai { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        [StringLength(50, ErrorMessage = "Vui lòng nhập không quá 50 ký tự")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$%^&*(),.?""{}|<>]).{8,}$", ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên, có ít nhất 1 ký tự chữ viết hoa và 1 ký tự đặc biệt.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn quyền hạn!")]
        [Range(0,1)]
        public int Role { get; set; }
    }
}
