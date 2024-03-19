

using Microsoft.EntityFrameworkCore;

namespace SalesSystem.Services
{
    public class ItemServices : IItemServices
    {
        private readonly ApplicationDbContext _context;

        public ItemServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(CreateItemFormViewModel model)
        {
            Item item = new()
            {
                Name = model.Name,
                Descreption = model.Descreption,
               

            };

            _context.Add(item);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var isDeleted = true;

            var item = _context.Items.Find(id);

            if (item is null)
                return isDeleted;

            _context.Remove(item);
            var effectedRows = _context.SaveChanges();



            return isDeleted;
        }

        public Item? GetById(int id)
        {
            return _context.Items.FirstOrDefault(i=>i.Id==id);
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
         return _context.Items.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
              OrderBy(d=>d.Text).
                AsNoTracking().
                ToList();

        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public async Task<Item?> Update(CreateItemFormViewModel model)
        {
            var item = _context.Items

                     .SingleOrDefault(g => g.Id == model.Id);


            item.Name = model.Name;
            item.Descreption = model.Descreption;
            _context.SaveChanges();
            return item;

        }
    }
}

