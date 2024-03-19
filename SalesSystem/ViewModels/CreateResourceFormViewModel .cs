

namespace SalesSystem.ViewModels
{
    public class CreateResourceFormViewModel:BaseEntity
    {

        [Display(Name = "اسم المورد")]
        [Required(ErrorMessage = "ادخل اسم المورد")]

        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "ادخل العنوان")]

        [Display(Name = "العنوان")]
       
         
        public string Address { get; set; } = null!;
        [Display(Name = "التلفون")]
        [Required(ErrorMessage = "ادخل التلفون")]

        public string Phone { get; set; } = null!;
        [Display(Name = "الحاله")]
        public bool State { get; set; }
        [Display(Name = "مجموعة الوردين ")]
        [Required(ErrorMessage = "اختر مجموعة الموردين ")]

        public int Idtype { get; set; } = default;

        public IEnumerable<SelectListItem> ResourceType { get; set; } = Enumerable.Empty<SelectListItem>();


        }
}
