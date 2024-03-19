

namespace SalesSystem.ViewModels
{
    public class BayInvoiceViewModel
    {
        //public List<Client> ClientList { get; set; } = new List<Client>();
        //public List<Product> ProductCList { get; set; } = new List<Product>();
        public Order NewBuyInovice { get; set; } = new Order();
       

        [Required(ErrorMessage = "اسم العميل مطلوب")]

        public int ClientId { get; set; }
        public int StockId { get; set; }
        
        public int ProductId { get; set; }
        public IEnumerable<SelectListItem> Client { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Product { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Stock { get; set; } = Enumerable.Empty<SelectListItem>();
       
    }
}
