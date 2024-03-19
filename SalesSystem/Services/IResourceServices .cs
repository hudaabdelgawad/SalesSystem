using SalesSystem.Models;
using SalesSystem.ViewModels;

namespace SalesSystem.Services
{
    public interface IResourceServices
    {
        IEnumerable<Resource> GetAll();
        Resource? GetById(int id);
        Task Create(CreateResourceFormViewModel model);
        Task<Resource?> Update(CreateResourceFormViewModel model);
        bool Delete(int id);
        public IEnumerable<SelectListItem> GetSelectList();
    }
}
