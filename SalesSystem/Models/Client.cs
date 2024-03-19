


namespace SalesSystem.Models;

public partial class Client:BaseEntity
{
  
    public string ?Name { get; set; } 

    public string ?Address { get; set; }

    public string ?Phone { get; set; }

    public decimal AccountBalance { get; set; }

    public bool State { get; set; }

   public int TypeClientId { get; set; }

    public TypeClient ?TypeClient { get; set; } 

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    
}
