

using Microsoft.AspNetCore.Identity;

namespace SalesSystem.Models;

public  class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal? Discount { get; set; }

    public decimal ?Total { get; set; }

   // public decimal Pay { get; set; }

   // public decimal Stay { get; set; }

    public decimal ?Quentit { get; set; }

    public decimal ?PriceSale { get; set; }

    public  Order ?Order { get; set; } = default!;

    public  Product ?Product { get; set; } = default!;
    public string? Barcode { get; set; }
}
