

namespace SalesSystem.Models;

public  class Order:BaseEntity
{
    //asp-format="{0:yyyy-MM-dd}"
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime OrderDate { get; set; }

    public int ClientId { get; set; }

    public int StockId { get; set; }

    public decimal? Total { get; set; }

    public decimal? Pay { get; set; }

    public decimal? Stay { get; set; }

    public decimal? Disount { get; set; }
    public decimal? AfterDiscount { get; set; }

    public Client? Client { get; set; } = null!;

    public  Stock? Stock { get; set; } = null!;
    
    public List<OrderDetail> OrderDetailList { get; set; } = new List<OrderDetail>();
}
