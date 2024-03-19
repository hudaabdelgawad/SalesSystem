using Microsoft.AspNetCore.Mvc;
using static SalesSystem.Helper;

namespace SalesSystem.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IItemServices _itemservices;

        public ItemsController(ApplicationDbContext context,IItemServices itemservices)
        {
            _context = context;
           _itemservices = itemservices;
        }

        public IItemServices Itemservices { get; }

        public IActionResult Index()
        {
            var item = _itemservices.GetItems();
            return View(item);
        }
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new CreateItemFormViewModel());
            else
            {
                var itemModel = _itemservices.GetById(id);
                if (itemModel == null)
                {
                    return NotFound();
                }
                CreateItemFormViewModel viewModel = new()
                {
                    Id = id,
                    Name = itemModel.Name,
                    Descreption = itemModel.Descreption,
                   
                };

                return View(viewModel);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> AddOrEdit(int id, CreateItemFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    await _itemservices.Add(model);
                }
                //Update
                else
                {
                    try
                    {
                        await _itemservices.Update(model);

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StockModelExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Items.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }


        private bool StockModelExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _itemservices.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}
