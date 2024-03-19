namespace SalesSystem.Services
{
    public interface IBayInvoiceServices
    {
        IEnumerable<Order> GetAll();
         Order? GetById(int id);
         bool Delete(int id);
        
    }
}
