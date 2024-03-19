


using Microsoft.Extensions.FileProviders;
using SalesSystem.Services;

var builder = WebApplication.CreateBuilder(args);
var mvcBuilder = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("No connection string was found");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();
//AddSingleton=>create one instance for the project lifecycle use in configuration
//AddScoped=>create one instance for the same request
//AddTransient=>create new instance for each request and even if the same request
builder.Services.AddScoped<IClientTypeServices, ClientTypeServices>();
builder.Services.AddScoped<IClientServices, ClientServices>();
builder.Services.AddScoped<IProductServices,ProductServices>();
builder.Services.AddScoped<IItemServices, ItemServices>();

    builder.Services.AddScoped<IBayInvoiceServices, BayInvoiceServices>();
builder.Services.AddScoped<IStockServices, StockServices>();
builder.Services.AddScoped<IItemServices, ItemServices>();
builder.Services.AddScoped<IResourceTypeServices, ResourceTypeServices>();
builder.Services.AddScoped<IResourceServices, ResourceServices>();
//config o devexpress



var app = builder.Build();
//dev
//app.UseDevExpressControls();
//System.Net.ServicePointManager.SecurityProtocol |= System.Net.SecurityProtocolType.Tls12;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//devexpress


app.UseRouting();

app.UseAuthorization();
//devexpress


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
