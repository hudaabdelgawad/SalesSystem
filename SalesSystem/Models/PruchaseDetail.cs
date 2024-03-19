

namespace SalesSystem.Models;

public  class PruchaseDetail
{
   
    
    public decimal? Quentiti { get; set; }

    public decimal ?Total { get; set; }

   // public decimal Pay { get; set; }

   // public decimal Stay { get; set; }

    public decimal? Discount { get; set; }

    public decimal? Price { get; set; }
    public int ProductId { get; set; }

    public Product? Product { get; set; } = default!;
    public int PruchaseId { get; set; }

    public Pruchase? Pruchase { get; set; } = default!;
}
