using DataAccessEF;
using DataAccessEF.UnitOfWork;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Accessing to connection string and adding DbContext EshopContext to the service container
builder.Services.AddDbContext<EshopContext>(options =>
    {
        var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

        if (string.IsNullOrEmpty(connectionString))
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            Console.WriteLine("Connection string is not set. Please check your environment variables.");
        }
        else
        {
            options.UseSqlServer(connectionString);
            Console.WriteLine($"Connection String: {connectionString}");
        }


    }
);

// add transient service for the IUnitOfWork interface and mapping it to the UnitOfWork class.
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
        // Apply CORS policy for any type of origin  
        .AllowAnyMethod()
        // Apply CORS policy for any type of http methods  
        .AllowAnyHeader());
});

builder.Services.AddControllers();

builder.Services.AddSingleton<TokenService>();
builder.Services.AddSingleton<OrderService>();

var app = builder.Build();

app.UseCors("AllowOrigin");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();



