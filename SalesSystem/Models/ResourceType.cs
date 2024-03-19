namespace SalesSystem.Models
{
    public class ResourceType:BaseEntity
    {

        public string? Name { get; set; } = null!;

        public string? Desc { get; set; } = null!;

        public ICollection<Resource> Clients { get; set; } = new List<Resource>();

    }
}
