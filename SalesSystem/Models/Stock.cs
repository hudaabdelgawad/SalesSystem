

namespace SalesSystem.Models;

public  class Stock:BaseEntity
{
   

    public string ?NameStock { get; set; } = null!;

    public string ?Address { get; set; } = null!;

    public string ?Phone { get; set; } = null!;

    public string ?AmeenStock { get; set; } = null!;

    public  ICollection<Order> Orders { get; set; } = new List<Order>();

    public  ICollection<Pruchase> Pruchases { get; set; } = new List<Pruchase>();
}
