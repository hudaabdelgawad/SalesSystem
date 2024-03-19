using Microsoft.AspNetCore.Mvc;
using static SalesSystem.Helper;

namespace SalesSystem.Controllers
{
    public class ResourceTypeController : Controller
        

    {
        private readonly ApplicationDbContext _context;
        private readonly IResourceTypeServices _resourceTypeServices;

        public ResourceTypeController(ApplicationDbContext context,IResourceTypeServices resourceTypeServices)
        {
           _context = context;
            _resourceTypeServices = resourceTypeServices;
        }

        
        public IActionResult Index()
        {
            var resourceTypes = _resourceTypeServices.GetAll();
            return View(resourceTypes);
        }
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new CreateResourceTypeFormViewModel());
            else
            {
                var resorceTypeModel = _resourceTypeServices.GetById(id);
                if (resorceTypeModel == null)
                {
                    return NotFound();
                }
                CreateResourceTypeFormViewModel viewModel = new()
                {
                    Id = id,
                    Name = resorceTypeModel.Name,
                    Desc = resorceTypeModel.Desc,
                   

                };

                return View(viewModel);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> AddOrEdit(int id, CreateResourceTypeFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    await _resourceTypeServices.Add(model);
                }
                //Update
                else
                {
                    try
                    {
                        await _resourceTypeServices.Update(model);

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!resourcetypeModelExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                // return RedirectToAction("Index");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.resourceTypes.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }


        private bool resourcetypeModelExists(int id)
        {
            return _context.resourceTypes.Any(e => e.Id == id);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _resourceTypeServices.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}
