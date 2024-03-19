

using Microsoft.AspNetCore.Http.HttpResults;

namespace SalesSystem.Services
{
    public class ProductServices : IProductServices
    {
        public int x { get; set; }
        private readonly ApplicationDbContext _context;
        private string _imagesPath;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductServices(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }





        public async Task Create(CreateProductFormViewModel model)
        {
            var coverName = await SaveCover(model.Image);

            Product product = new()
            {
                Name = model.Name,
                Barcode = model.Barcode,
                StockId = model.StockId,
                PricePruchase = model.PricePruchase,
                PriceSale = model.PriceSale,
                QuentityStock = model.QuentityStock,
                ItemId = model.ItemId,
                Image = coverName,
                Descreption=model.Descreption,

            };

            _context.Add(product);
            _context.SaveChanges();
        }



        public Task<Product?> Update(EditProductFormViewModel model)
        {
            throw new NotImplementedException();
        }

       
      public  Product? GetById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<string> SaveCover(IFormFile image)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

            var path = Path.Combine(_imagesPath, coverName);

            using var stream = File.Create(path);
            await image.CopyToAsync(stream);

            return coverName;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IProductServices.GetAll()
        {
            return _context.Products
           .Include(g => g.Item)
           .Include(s=>s.Stock)
           .AsNoTracking()
           .ToList();
        }
        IEnumerable<Product> IProductServices.GetAllInStock(int?id)
        {
            return _context.Products.Where(x =>x.StockId.Equals(id)).ToList();

        }
        //OrderDetail? IProductServices.GetQOrderdetails(int? id)
        //{
            

          
        // var query=  _context.OrderDetails
        //    .Where(X => X.ProductId.Equals(id))
        //    .GroupBy(w => new { w.ProductId })
        //      .Select(x => new
        //      {
        //        totalQuintity =x.Sum(v => v.Quentit),

        //      })
        //      .ToList();

        //   return query();
        //}
        public Product? GetPriceProduct(int?id)
        {
            return _context.Products.FirstOrDefault(x => x.Id.Equals(id));

        }
        Product? IProductServices.GetById(int id)
        {
            return _context.Products
            .Include(g => g.Item)
            .Include(g=>g.Stock)

            .AsNoTracking()
            .SingleOrDefault(g => g.Id == id);
        }

      

        async Task<Product?> IProductServices.Update(EditProductFormViewModel model)
        {
            var game = _context.Products
          .Include(g => g.Item)
          .SingleOrDefault(g => g.Id == model.Id);

            if (game is null)
                return null;

            var hasNewCover = model.Image is not null;
            var oldCover = game.Image;

            game.Name = model.Name;
            game.Descreption = model.Descreption;
            game.ItemId = model.ItemId;
            game.StockId = model.StockId;
            game.PricePruchase = model.PricePruchase;
            game.PriceSale = model.PriceSale;
            game.QuentityStock = model.QuentityStock;
            game.Barcode = model.Barcode;



           
            if (hasNewCover)
            {
                game.Image = await SaveCover(model.Image!);
            }

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                if (hasNewCover)
                {
                    var cover = Path.Combine(_imagesPath, oldCover);
                    File.Delete(cover);
                }

                return game;
            }
            else
            {
                var cover = Path.Combine(_imagesPath, game.Image);
                File.Delete(cover);

                return null;
            }
        }

        bool IProductServices.Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Products.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                 OrderBy(d => d.Text).
                   AsNoTracking().
                   ToList();

        }

   
       
    }
}
