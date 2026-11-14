using expensesProject.Data;
using expensesProject.Repostory;
using expensesProject.Repostory.Base;
using expensesProject.Server;
using expensesProject.Server.Base;
using expensesProject.Serviec;
using expensesProject.Serviec.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfwork, UnitOfwork>();
builder.Services.AddScoped<IExpensesServers, ExpensesServers>();
builder.Services.AddScoped<ICatrgoryServes, CatrgoryServes>();
builder.Services.AddScoped<IPaymentMethodServiec, PaymentMethodServiec>();
builder.Services.AddScoped<IUserServiec, UserServiec>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();