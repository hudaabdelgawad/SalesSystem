
namespace SalesSystem.Services
{
    public class ClientServices : IClientServices
    {
        private readonly ApplicationDbContext _context;
        public ClientServices(ApplicationDbContext context)
        {
           _context = context;
        }

       

        public async Task Create(CreateClientFormViewModel model)
        {
            Client client = new()
            {
                Name = model.Name,
                Address = model.Address,
                TypeClientId = model.Idtype,
                Phone = model.Phone,
                AccountBalance = model.AccountBalance
            };

            _context.Add(client);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var isDeleted = true;

            var client = _context.Clients.Find(id);

            if (client is null)
                return isDeleted;

            _context.Remove(client);
            var effectedRows = _context.SaveChanges();

            

            return isDeleted;
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients
           .Include(g => g.TypeClient)
           .AsNoTracking()
           .ToList();
        }

        public Client? GetById(int id)
        {
            return _context.Clients
             .Include(g => g.TypeClient)
            
             .AsNoTracking()
             .SingleOrDefault(g => g.Id == id);
        }

        public async Task<Client> Update(EditClientFormViewModel model)
        {
            var client = _context.Clients
                .Include(g => g.TypeClient)
                .SingleOrDefault(g => g.Id == model.Id);


            //if (client is null)
            //    return null;

            client.Name = model.Name;
            client.Phone = model.Phone;
            client.TypeClientId = model.Idtype;
            client.Address = model.Address;
            client.State = model.State;

            

            var effectedRows = _context.SaveChanges();
            //if (effectedRows > 0)
            //{

            //    return client;
            //}
            //else
            //{

            //    return null;
            //}

            return client;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Clients.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                 OrderBy(d => d.Text).
                   AsNoTracking().
                   ToList();

        }

    }
}
