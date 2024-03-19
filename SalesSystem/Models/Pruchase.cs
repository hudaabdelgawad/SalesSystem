

namespace SalesSystem.Models;

public  class Pruchase:BaseEntity
{
    

    public DateTime OrderDate { get; set; }

    public int ResourceId { get; set; }

    public int StockId { get; set; }

    public decimal ?Total { get; set; }

    public decimal ?Pay { get; set; }

    public decimal ?Stay { get; set; }

    public decimal ?Descount { get; set; }

    public  Resource ?Resource { get; set; } = null!;

    public  Stock ?Stock { get; set; } = null!;
}
