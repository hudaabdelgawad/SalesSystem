

namespace SalesSystem.Services
{
    public class BayInvoiceServices : IBayInvoiceServices
    {
        private readonly ApplicationDbContext _context;
        public BayInvoiceServices(ApplicationDbContext context)
        {
           _context = context;
        }

       

       
      

        public bool Delete(int id)
        {
            var isDeleted = true;

            var order = _context.Orders.Find(id);

            if (order is null)
                return isDeleted;

            _context.Remove(order);
            var effectedRows = _context.SaveChanges();

            

            return isDeleted;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
           .Include(g => g.Client)
           .Include(g => g.OrderDetailList)
           
           .AsNoTracking()
           .ToList();
        }

        public Order? GetById(int id)
        {
            return _context.Orders
             .Include(g => g.Client)
              .Include(g => g.Stock)
            .Include(g=>g.OrderDetailList)
            .ThenInclude(d=>d.Product)
         
      
             .AsNoTracking()
             .SingleOrDefault(g => g.Id == id);
        }

       

       

        
    }
}
