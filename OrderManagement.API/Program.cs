using Microsoft.EntityFrameworkCore;
using OrderManagement.Core;
using OrderManagement.Core.Services;
using OrderManagement.Data;
using OrderManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<OrderManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderManagement")));

builder.Services.AddTransient<IStateService, StateService>();
builder.Services.AddTransient<ISupplierService, SupplierService>();
//builder.Services.AddTransient<IStateRepository, StateRepository>();
//builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Configure JSON logging to the console.
builder.Logging.AddJsonConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.Run();
