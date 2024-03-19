
using SalesSystem.Models;

namespace SalesSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Client> Clients { get; set; }

        public  DbSet<Item> Items { get; set; }

        public  DbSet<Order> Orders { get; set; }

        public  DbSet<OrderDetail> OrderDetails { get; set; }

        public  DbSet<Product> Products { get; set; }

        public  DbSet<Pruchase> Pruchases { get; set; }

        public  DbSet<PruchaseDetail> PruchaseDetails { get; set; }

        public  DbSet<Resource> Resources { get; set; }

        public  DbSet<Stock> Stocks { get; set; }

        public  DbSet<TypeClient> TypeClients { get; set; }
        public DbSet<InvoiceTemp> InvoiceTemp { get; set; }
        public DbSet<ResourceType> resourceTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

          

            modelBuilder.Entity<OrderDetail>()
                .HasKey(e => new { e.OrderId, e.ProductId });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PruchaseDetail>()
               .HasKey(e => new { e.ProductId, e.PruchaseId });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasData(
                 new Item { Id = 1, Name = "لحوم" },
                new Item { Id = 2, Name = "خضار" },
                new Item { Id = 3, Name = "فواكه" }


    );
            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, NameStock = "رئيسي" },
                new Stock { Id = 2, NameStock = "فرعي"}
                 );
            modelBuilder.Entity<TypeClient>().HasData(
             new TypeClient { Id = 1, Name = "شركه" },
             new TypeClient { Id = 2, Name = "تاجر جمله" }
              );
            //modelBuilder.Entity<Client>().HasData(
            //  new Client { Id = 1, Name = "هدى",TypeClientId=1 },
            //  new Client { Id = 2, Name = "مصطفى",TypeClientId=2 }
            //   );
            //modelBuilder.Entity<Product>().HasData(
            // new Product { Id = 1, Name = "لحمه مفر" },
            // new Product { Id = 2, Name = "مصطفى" }
            //  );
        }
    }
}
    

   

