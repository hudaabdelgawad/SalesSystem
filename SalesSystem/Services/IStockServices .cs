namespace SalesSystem.Services
{
    public interface IStockServices
    {
        IEnumerable<Stock> GetStocks();
        Task Add(CreateStockFormViewModel model);
        Task<Stock?> Update(CreateStockFormViewModel model);
        public  IEnumerable<SelectListItem> GetSelectList();
        bool Delete(int id);
        Stock? GetById(int id);
    }
}
