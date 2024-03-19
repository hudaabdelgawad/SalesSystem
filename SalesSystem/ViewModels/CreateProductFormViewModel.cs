﻿

namespace SalesSystem.ViewModels
{
    public class CreateProductFormViewModel
    {
        public string Name { get; set; } = null!;

        public decimal PricePruchase { get; set; }

        public decimal PriceSale { get; set; }

        public decimal QuentityStock { get; set; }

        public string Barcode { get; set; } = null!;

        public string Descreption { get; set; } = null!;

        public int ItemId { get; set; }

        public int StockId { get; set; }

        public IFormFile Image { get; set; } = default;

          public IEnumerable<SelectListItem> Stock { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Item { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
