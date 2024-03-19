

using Microsoft.EntityFrameworkCore;

namespace SalesSystem.Services
{
    public class ClientTypeServices : IClientTypeServices
    {
        private readonly ApplicationDbContext _context;

        public ClientTypeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
         return _context.TypeClients.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
              OrderBy(d=>d.Text).
                AsNoTracking().
                ToList();

        }
    }
}

