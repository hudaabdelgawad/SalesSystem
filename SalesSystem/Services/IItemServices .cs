namespace SalesSystem.Services
{
    public interface IItemServices
    {
      public  IEnumerable<SelectListItem> GetSelectList();

        IEnumerable<Item> GetItems();
        Task Add(CreateItemFormViewModel model);
        Task<Item?> Update(CreateItemFormViewModel model);
        bool Delete(int id);
        Item? GetById(int id);
    }
}
