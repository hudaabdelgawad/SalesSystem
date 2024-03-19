namespace SalesSystem.Services
{
    public interface IResourceTypeServices
    {
      public  IEnumerable<SelectListItem> GetSelectList();
        ResourceType? GetById(int id);
        IEnumerable<ResourceType> GetAll();
        Task Add(CreateResourceTypeFormViewModel model);
        Task<ResourceType?> Update(CreateResourceTypeFormViewModel model);
        bool Delete(int id);


    }
}
