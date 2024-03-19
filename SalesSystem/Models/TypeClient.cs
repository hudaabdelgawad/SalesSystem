

namespace SalesSystem.Models;

public  class TypeClient:BaseEntity
{
   

    public string ?Name { get; set; } = null!;

    public string ?Desc { get; set; } = null!;

    public  ICollection<Client> Clients { get; set; } = new List<Client>();
}
