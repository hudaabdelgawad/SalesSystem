using SalesSystem.Models;
using SalesSystem.ViewModels;

namespace SalesSystem.Services
{
    public interface IClientServices
    {
        IEnumerable<Client> GetAll();
        Client? GetById(int id);
        Task Create(CreateClientFormViewModel model);
        Task<Client?> Update(EditClientFormViewModel model);
        bool Delete(int id);
        public IEnumerable<SelectListItem> GetSelectList();
    }
}
