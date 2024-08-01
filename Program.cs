using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TransactionApi.Data;
using TransactionApi.Repositories;
using TransactionApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework Core to use In-Memory database
builder.Services.AddDbContext<TransactionContext>(options =>
    options.UseInMemoryDatabase("TransactionDb"));

// Register repository and service
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers(); // Map controllers

// Add a simple default route
app.MapGet("/", () => "Welcome to the Transaction API!");

app.Run();