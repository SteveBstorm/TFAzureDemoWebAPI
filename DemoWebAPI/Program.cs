using BLL_Pizzeria.Interface;
using DAL_Pizzeria.Interface;
using DAL = DAL_Pizzeria.Services;
using BLL = BLL_Pizzeria.Services;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(sp => new SqlConnection(
    builder.Configuration.GetConnectionString("default")
    ));

builder.Services.AddScoped<IUserService, DAL.UserService>();
builder.Services.AddScoped<IUserBLLService, BLL.UserService>();
builder.Services.AddScoped<IOrderService, DAL.OrderService>();
builder.Services.AddScoped<IPizzaService, DAL.PizzaService>();
builder.Services.AddScoped<IOrderBLLService, BLL.OrderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
