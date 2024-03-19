
using System.ComponentModel.DataAnnotations.Schema;


namespace SalesSystem.Models

{
    public class InvoiceTemp
    {
        [Key]
        public int InvoiceId { get; set; }
        public string? Barcode { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

      
        public decimal? Discount { get; set; }

        public decimal? Total { get; set; }

        //  public decimal Pay { get; set; }

        // public decimal Stay { get; set; }
        public decimal? AfterDiscount { get; set; }

        public decimal ?Quentit { get; set; }

        public decimal? PriceSale { get; set; }

    }
}
