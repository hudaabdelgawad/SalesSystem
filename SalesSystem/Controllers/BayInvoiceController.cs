using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesSystem.ViewModels;

namespace SalesSystem.Controllers
{
    public class BayInvoiceController : Controller
    {
        private readonly IProductServices _IProductServices;
        private readonly IClientServices _clientServices;
        private readonly ApplicationDbContext _context;
        private readonly IBayInvoiceServices _bayInvoiceServices;
        private readonly IStockServices _stockServices;

        public BayInvoiceController(IStockServices stockServices, IProductServices IProductServices, IClientServices clientServices ,ApplicationDbContext context,IBayInvoiceServices bayInvoiceServices)
        {
            _stockServices= stockServices;
            _clientServices = clientServices;
           _context = context;
            _bayInvoiceServices = bayInvoiceServices;
            _IProductServices = IProductServices;
        }
        public IActionResult Index() 
        {
            var bayinvoice = _bayInvoiceServices.GetAll();
            return View(bayinvoice);
        }
        public IActionResult Details(int id)
        {
            //var product_order = _context.OrderDetails.Include(g => g.Product).Where(g => g.OrderId == id).ToList();
            //ViewBag.p = product_order;
      
          var bayinvoice = _bayInvoiceServices.GetById(id);

            if (bayinvoice is null)
                return NotFound();

            return View(bayinvoice);
        }
        [HttpGet]
        public IActionResult GetProduct(int?id)
        {
            return Json(_IProductServices.GetAllInStock(id));
         
        }
        [HttpGet]
        public IActionResult GetQOrderdetails(int? id)
        {
            // _IProductServices.GetQOrderdetails(id);
            var query = _context.OrderDetails
               .Where(X => X.ProductId.Equals(id))
               .GroupBy(w => new { w.ProductId })
                 .Select(x => new
                 {
                     Orderquentity = x.Sum(v => v.Quentit),

                 })
                 .ToList();
            return Json(query);
        }
        [HttpGet]

        public IActionResult GetPriceProduct(int? id)
        {
            return Json(_IProductServices.GetPriceProduct(id));

        }
        [HttpGet]
        public IActionResult Create()
        {
            
            int id = _context.Orders.Max(m => m.Id);
           
            ViewBag.no = id+1;

            return View(new BayInvoiceViewModel
            {
                Client = _clientServices.GetSelectList(),
                Product = _IProductServices.GetSelectList(),
                Stock = _stockServices.GetSelectList(),
          
            }

             
        );
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BayInvoiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var result = _context.InvoiceTemp.ToList();
                foreach (var item in result)
                {
                    model.NewBuyInovice.OrderDetailList.Add(new OrderDetail()
                    {
                        Discount=item.Discount,
                         PriceSale=item.PriceSale,
                       
                        ProductId = item.ProductId,
                      
                        Quentit = item.Quentit,
                        Total = item.Total
                    });
                    _context.InvoiceTemp.Remove(item);
                    _context.SaveChanges();
                }//
              
               
                _context.Orders.Add(model.NewBuyInovice);
                _context.SaveChanges();
               
                return RedirectToAction("Index", "BayInvoice");

            }
            return View(model.NewBuyInovice);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDeleted = _bayInvoiceServices.Delete(id);

            return isDeleted ? Ok() : BadRequest();
        }

        //public IActionResult GetBayInvoiceReport()
        //{
        //    //BayInvoiceReport bayInvoiceReport = new BayInvoiceReport();
        //    return View(bayInvoiceReport);
        //}

    }
}

