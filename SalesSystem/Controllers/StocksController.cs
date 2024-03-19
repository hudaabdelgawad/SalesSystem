using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Models;
using static SalesSystem.Helper;

namespace SalesSystem.Controllers
{
    public class StocksController : Controller
    {
        private readonly IStockServices _stockServices;
        private readonly ApplicationDbContext _context;

        public StocksController(IStockServices stockServices, ApplicationDbContext context)
        {
            _stockServices = stockServices;
            _context = context;
        }
        public IActionResult Index()
        {
            var stocks = _stockServices.GetStocks();
            return View(stocks);
        }
        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new CreateStockFormViewModel());
            else
            {
                var stockModel =  _stockServices.GetById(id);
                if (stockModel == null)
                {
                    return NotFound();
                }
                CreateStockFormViewModel viewModel = new()
                {
                    Id = id,
                    NameStock = stockModel.NameStock,
                    Address = stockModel.Address,
                    AmeenStock = stockModel.AmeenStock,
                    Phone = stockModel.Phone,
                   
                };

                return View(viewModel);
               
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       

        public async Task<IActionResult> AddOrEdit(int id, CreateStockFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    await _stockServices.Add(model);
                             }
                //Update
                else
                {
                    try
                    {
                        await _stockServices.Update(model);

                        }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!StockModelExists(model.Id))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
              // return RedirectToAction("Index");
               return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Stocks.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        
        private bool StockModelExists(int id)
        {
            return _context.Stocks.Any(e => e.Id == id);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _stockServices.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }
    }
}  
