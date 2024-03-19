

using Microsoft.EntityFrameworkCore;
using System;

namespace SalesSystem.Services
{
    public class StockServices : IStockServices
    {
        private readonly ApplicationDbContext _context;

        public StockServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task Add(CreateStockFormViewModel model)
        {
             Stock stock = new()
            {
                NameStock = model.NameStock,
                Address = model.Address,
                AmeenStock = model.AmeenStock,
                Phone = model.Phone,
                
            };

            _context.Add(stock);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var isDeleted = true;

            var stock = _context.Stocks.Find(id);

            if (stock is null)
                return isDeleted;

            _context.Remove(stock);
            var effectedRows = _context.SaveChanges();



            return isDeleted;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            
         return _context.Stocks.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.NameStock }).
              OrderBy(d=>d.Text).
                AsNoTracking().
                ToList();

        }

        public IEnumerable<Stock> GetStocks()
        {
            return _context.Stocks
        
           .ToList();
        }

        public async  Task<Stock?> Update(CreateStockFormViewModel model)
        {
            var stock = _context.Stocks
         
          .SingleOrDefault(g => g.Id == model.Id);


            stock.NameStock = model.NameStock;
            stock.Phone = model.Phone;
            stock.Address = model.Address;
            stock.AmeenStock = model.AmeenStock;
            _context.SaveChanges();
            return stock;


           
        }
        public Stock? GetById(int id)
        {
            return _context.Stocks
             
             .AsNoTracking()
             .SingleOrDefault(g => g.Id == id);
        }

    }
}

