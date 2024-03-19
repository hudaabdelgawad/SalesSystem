

using Microsoft.EntityFrameworkCore;

namespace SalesSystem.Services
{
    public class ResourceTypeServices : IResourceTypeServices
    {
        private readonly ApplicationDbContext _context;

        public ResourceTypeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(CreateResourceTypeFormViewModel model)
        {
            ResourceType resourceType = new()
            {
                Name = model.Name,
                Desc = model.Desc,
            };
            _context.Add(resourceType);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var isDeleted = true;
            var resourceTypes = _context.resourceTypes.Find(id);

            if (resourceTypes is null)
                return isDeleted;

            _context.Remove(resourceTypes);
            _context.SaveChanges();
            return isDeleted;
        }

        public IEnumerable<ResourceType> GetAll()
        {
            return _context.resourceTypes.ToList();
        }

        public ResourceType? GetById(int id)
        {
            return _context.resourceTypes.AsNoTracking().SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.resourceTypes
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                 OrderBy(d => d.Text).
                   AsNoTracking().
                   ToList();

        }

        public async  Task<ResourceType?> Update(CreateResourceTypeFormViewModel model)
        {
            var resourceType = _context.resourceTypes.SingleOrDefault(g => g.Id == model.Id);
            resourceType.Name = model.Name;
            resourceType.Desc = model.Desc;
            _context.SaveChanges();
            return resourceType;


                }
    }
}

