
namespace SalesSystem.Services
{
    public class ResourceServices : IResourceServices
    {
        private readonly ApplicationDbContext _context;
        public ResourceServices(ApplicationDbContext context)
        {
           _context = context;
        }

       

        public async Task Create(CreateResourceFormViewModel model)
        {
            Resource resource = new()
            {
                Name = model.Name,
                Address = model.Address,
                ResourceTypeId = model.Idtype,
                Phone = model.Phone,
                State = model.State
            };

            _context.Add(resource);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var isDeleted = true;

            var resource = _context.Resources.Find(id);

            if (resource is null)
                return isDeleted;

            _context.Remove(resource);
            var effectedRows = _context.SaveChanges();

            

            return isDeleted;
        }

        public IEnumerable<Resource> GetAll()
        {
            return _context.Resources
           .Include(g => g.ResourceType)
           .AsNoTracking()
           .ToList();
        }

        public Resource? GetById(int id)
        {
            return _context.Resources
             .Include(g => g.ResourceType)
            
             .AsNoTracking()
             .SingleOrDefault(g => g.Id == id);
        }

        public async Task<Resource> Update(CreateResourceFormViewModel model)
        {
            var resource = _context.Resources
                .Include(g => g.ResourceType)
                .SingleOrDefault(g => g.Id == model.Id);


            //if (client is null)
            //    return null;

            resource.Name = model.Name;
            resource.Phone = model.Phone;
            resource.ResourceTypeId = model.Idtype;
            resource.Address = model.Address;
            resource.State = model.State;

            

            var effectedRows = _context.SaveChanges();
           

            return resource;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.resourceTypes.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                 OrderBy(d => d.Text).
                   AsNoTracking().
                   ToList();

        }

    }
}
