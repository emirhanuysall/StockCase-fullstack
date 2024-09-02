using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Services;
using Backend.Repositories;
using Backend.Cache; // RedisCacheService için doðru namespace
using Serilog;
using Microsoft.Extensions.Caching.Distributed; // IDistributedCache için gerekli namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Redis cache
builder.Services.AddSingleton<IDistributedCache>(sp =>
    new RedisCacheService(builder.Configuration.GetConnectionString("RedisConnection")));

// Add scoped services
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Add endpoints and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Serilog
builder.Host.UseSerilog((context, config) =>
{
    config
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
        .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Geliþtirme ortamýnda hata sayfasý
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Üretim ortamýnda genel hata iþleme
    app.UseHsts(); // HTTP Strict Transport Security
}

app.UseHttpsRedirection(); // HTTPS yönlendirme


app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();


