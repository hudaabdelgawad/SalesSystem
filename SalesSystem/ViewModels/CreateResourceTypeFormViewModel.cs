using System.ComponentModel;

namespace SalesSystem.ViewModels
{
    public class CreateResourceTypeFormViewModel:BaseEntity
    {
        [DisplayName(" مجموعة الموردين ")]
        [Required(ErrorMessage = "ادخل اسم مجموعة الموردين")]
        //[MaxLength(12, ErrorMessage = "Maximum 12 characters only")]

        public string? Name { get; set; } = null!;
        [DisplayName("  وصف مجموعة الموردين ")]
        [Required(ErrorMessage = "ادخل وصف مجموعة الموردين")]

        public string? Desc { get; set; } = null!;

    }
}
