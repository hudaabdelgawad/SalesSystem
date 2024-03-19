

namespace SalesSystem.Models;

public  class Product:BaseEntity
{
   

    public string ?Name { get; set; } = null!;

    public decimal PricePruchase { get; set; }

    public decimal PriceSale { get; set; }

    public decimal QuentityStock { get; set; }

    public string ?Barcode { get; set; } = null!;

    public string ?Descreption { get; set; } = null!;

    public int ItemId { get; set; }

    public int StockId { get; set; }

    public string? Image { get; set; }

    public  Item ?Item { get; set; } = null!;
    public Stock ?Stock { get; set; } = null!;

}
