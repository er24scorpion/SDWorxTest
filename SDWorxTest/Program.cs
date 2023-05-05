using API.Exceptions;
using Application.Handlers;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SlimMessageBus.Host;
using SlimMessageBus.Host.Memory;

var builder = WebApplication.CreateBuilder(args);

// logging
builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting up");

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBookHandler).Assembly));
builder.Services.AddDbContext<RepositoryContext>(
    opt => opt.UseInMemoryDatabase("Library"));

builder.Services.AddSlimMessageBus(mbb =>
{
    mbb.WithProviderMemory()
       .AutoDeclareFrom(typeof(BookSavedHandler).Assembly);
    mbb.AddServicesFromAssemblyContaining<BookSavedHandler>();
    mbb.AddAspNet();
}).AddHttpContextAccessor();

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
app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Generating sample data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RepositoryContext>();

    // Call the DataGenerator to create sample data
    DataGenerator.Initialize(services);
}

app.Run();
