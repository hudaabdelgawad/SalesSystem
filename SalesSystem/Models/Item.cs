

namespace SalesSystem.Models;

public  class Item:BaseEntity
{

   
    public string ?Name { get; set; } = null!;

    public string? Descreption { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
