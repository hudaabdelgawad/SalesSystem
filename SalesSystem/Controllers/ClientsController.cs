using Microsoft.AspNetCore.Mvc;
using SalesSystem.Services;
using SalesSystem.ViewModels;

namespace SalesSystem.Controllers
{
    public class ClientsController : Controller
    {

        private readonly IClientTypeServices _clienttypeServices;
        private readonly IClientServices _clientServices;

        public ClientsController(IClientTypeServices clienttypeServices, IClientServices clientServices)
        {
            _clientServices = clientServices;
            _clienttypeServices = clienttypeServices;
        }
        public IActionResult Index()
        {
            var Client = _clientServices.GetAll();
            return View(Client);
        }
        public IActionResult Create()
        {
            CreateClientFormViewModel viewmodel = new()
            {
                ClientType = _clienttypeServices.GetSelectList()
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateClientFormViewModel model)
        {
            if (!ModelState.IsValid)
            {

                model.ClientType = _clienttypeServices.GetSelectList();

                return View(model);

            }
            await _clientServices.Create(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _clientServices.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var client = _clientServices.GetById(id);

            if (client is null)
                return NotFound();

            EditClientFormViewModel viewModel = new()
            {
                Id = id,
                Name = client.Name,
                Phone = client.Phone,
                Address = client.Address,
                AccountBalance = client.AccountBalance,
                State = client.State,
                Idtype = client.TypeClientId,
                ClientType = _clienttypeServices.GetSelectList(),

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditClientFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ClientType = _clienttypeServices.GetSelectList();

                return View(model);
            }

            var client = await _clientServices.Update(model);

            if (client is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }


    }
}
