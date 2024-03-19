

namespace SalesSystem.Models;

public  class Resource:BaseEntity
{
   

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public bool? State { get; set; }
    public int ResourceTypeId { get; set; }
    public ResourceType ?ResourceType { get; set; }
    public  ICollection<Pruchase> Pruchases { get; set; } = new List<Pruchase>();
}
