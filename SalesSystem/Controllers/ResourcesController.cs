using Microsoft.AspNetCore.Mvc;
using static SalesSystem.Helper;

namespace SalesSystem.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IResourceServices _resourceServices;

        public ResourcesController( ApplicationDbContext context, IResourceServices resourceServices)
        {
            _context = context;
            _resourceServices = resourceServices;
        }
        public IActionResult Index()
        {
            var resource = _resourceServices.GetAll();
            return View(resource);
        }
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {


            if (id == 0)
            {
                CreateResourceFormViewModel viewmodel = new()
                {
                    ResourceType = _resourceServices.GetSelectList()
                };
                return View(viewmodel);
             
            }
            else
            {
                var resorceModel = _resourceServices.GetById(id);
                if (resorceModel == null)
                {
                    return NotFound();
                }
                CreateResourceFormViewModel viewModel = new()
                {
                    Id = id,
                    Name = resorceModel.Name,
                    Address = resorceModel.Address,
                    Phone=resorceModel.Phone,
                    Idtype=resorceModel.ResourceTypeId,
                    ResourceType = _resourceServices.GetSelectList()


                };

                return View(viewModel);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddOrEdit(int id, CreateResourceFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    await _resourceServices.Create(model);
                }
                //Update
                else
                {
                    try
                    {
                        await _resourceServices.Update(model);

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ResourceModelExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
             //   return  Json(RedirectToAction("Index"));
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Resources.Include(g=>g.ResourceType).ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }


        private bool ResourceModelExists(int id)
        {
            return _context.Resources.Any(e => e.Id == id);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _resourceServices.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}
