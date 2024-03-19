using System.ComponentModel;

namespace SalesSystem.ViewModels
{
    public class CreateItemFormViewModel:BaseEntity
{




        [DisplayName(" اسم الصنف ")]
        [Required(ErrorMessage = "ادخل اسم الصنف")]
        public string ?Name { get; set; } = null!;
        [DisplayName(" وصف الصنف")]
        [Required(ErrorMessage = "ادخل وصف للصنف")]
        public string? Descreption { get; set; }
    
    }
}
