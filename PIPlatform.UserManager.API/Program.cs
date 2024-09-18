using PIPlatform.UserManager.BL.HttpClients;
using PIPlatform.UserManager.BL.Implementations;
using PIPlatform.UserManager.BL.Interfaces;
using PIPlatform.UserManager.BL.NovaServices;
using PIPlatform.UserManager.DAL;
using PIPlatform.UserManager.DAL.Repositories.Implementations;
using PIPlatform.UserManager.DAL.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplyService, SupplyService>();
builder.Services.AddScoped<INovaService, NovaService>();
builder.Services.AddScoped<INovaUserService, NovaUserService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();
builder.Services.AddScoped<INovaUserRepository, NovaUserRepository>();
builder.Services.AddScoped<IProductOrderRepository, ProductOrderRepository>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<INovaHttpClient, NovaHttpClient>();

builder.Services.AddDbContext<UserManagerContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();