using System.ComponentModel;
using static System.Collections.Specialized.BitVector32;

namespace SalesSystem.ViewModels
{
    public class CreateStockFormViewModel:BaseEntity
    {
        [DisplayName(" اسم المخزن")]
        [Required(ErrorMessage = "ادخل اسم المخزن")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]

        public string? NameStock { get; set; } = null!;
        [DisplayName(" العنوان")]
        [Required(ErrorMessage = " ادخل العنوان.")]
        //[MaxLength(12, ErrorMessage = "Maximum 12 characters only")]

        public string? Address { get; set; } = null!;
        [DisplayName(" التلفون")]
        [Required(ErrorMessage = "ادخل التلفون.")]
        //[MaxLength(12, ErrorMessage = "Maximum 12 characters only")]

        public string? Phone { get; set; } = null!;
        [DisplayName(" امين المخزن")]
        [Required(ErrorMessage = "ادخل اسم امين المخزن.")]
        //[MaxLength(12, ErrorMessage = "Maximum 12 characters only")]

        public string? AmeenStock { get; set; } = null!;
    }
}
