namespace SalesSystem.ViewModels
{
    public class EditClientFormViewModel
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "First name is required")]

        [Display(Name = "العنوان")]

        [MaxLength(5)]
        public string Address { get; set; } = null!;
        [Display(Name = "التلفون")]
        public string Phone { get; set; } = null!;
        [Display(Name = "الرصيد")]
        public decimal AccountBalance { get; set; }
        [Display(Name = "الحالة")]
        public bool State { get; set; }
        [Display(Name = "نوع العميل")]
        public int Idtype { get; set; } = default;

        public IEnumerable<SelectListItem> ClientType { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
