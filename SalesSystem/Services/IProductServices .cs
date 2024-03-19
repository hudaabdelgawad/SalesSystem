

namespace SalesSystem.Services
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Task Create(CreateProductFormViewModel model);
        Task<Product?> Update(EditProductFormViewModel model);
        bool Delete(int id);
        public IEnumerable<SelectListItem> GetSelectList();
        IEnumerable<Product> GetAllInStock(int?id);
        Product? GetPriceProduct(int? id);

       //public OrderDetail ?GetQOrderdetails(int? id);
    }
}
