using Microsoft.AspNetCore.Mvc;
using SalesSystem.ViewModels;

namespace SalesSystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IItemServices _itemServices;
        private readonly IStockServices _stockServices;
        private readonly IProductServices _productsServices;

        public ProductsController(IItemServices itemServices, IStockServices stockServices,IProductServices productServices)
        {
            _itemServices = itemServices;
            _stockServices = stockServices;
            _productsServices = productServices;
        }

       

       
        public IActionResult Index()
        {
            var product = _productsServices.GetAll();
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateProductFormViewModel viewModel = new()
            {
                Item = _itemServices.GetSelectList(),
                Stock = _stockServices.GetSelectList()
            };

            return View(viewModel);
           // return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult>Create(CreateProductFormViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Item = _itemServices.GetSelectList();
                model.Stock = _stockServices.GetSelectList();
                return View(model);
            }

            await _productsServices.Create(model);

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _productsServices.GetById(id);

            if (game is null)
                return NotFound();

            EditProductFormViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Descreption = game.Descreption,
                ItemId = game.ItemId,
                StockId=game.StockId,
                Item = _itemServices.GetSelectList(),
                Stock = _stockServices.GetSelectList(),
                CurrentCover = game.Image,
                Barcode=game.Barcode,
                PricePruchase= game.PricePruchase ,
                PriceSale = game.PriceSale ,
                QuentityStock = game.QuentityStock ,
         
        };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Item = _itemServices.GetSelectList();
                model.Stock = _stockServices.GetSelectList();
                return View(model);
            }

            var game = await _productsServices.Update(model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
    }
}
