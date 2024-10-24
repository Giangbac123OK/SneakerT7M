using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace AppData.Models
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (DateTime?)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (currentValue != null && comparisonValue != null && currentValue < comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }


    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không được để trống.")]
        [StringLength(200, ErrorMessage = "Tên không được vượt quá 200 ký tự.")]
        public string Ten { get; set; }

        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự.")]
        public string? Mota { get; set; }

        [Range(0, 1, ErrorMessage = "Trạng thái chỉ có thể là 0 (inactive) hoặc 1 (active).")]
        public int Trangthai { get; set; }

        [Required(ErrorMessage = "Ngày bắt đầu không được để trống.")]
        public DateTime Ngaybatdau { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc không được để trống.")]
        [DateGreaterThan("Ngaybatdau", ErrorMessage = "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.")]
        public DateTime Ngayketthuc { get; set; }

        [JsonIgnore]
        public virtual ICollection<Salechitiet>? Salechitiets { get; set; }
    }

}
