using CRUD_CleanArchitecture.Application.UseCases.Tax;
using CRUD_CleanArchitecture.Domain.Interfaces.Repositories;
using CRUD_CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do DbContext com Pomelo
builder.Services.AddDbContext<SQLContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// Registre os repositórios e handlers
builder.Services.AddScoped<ITaxRepository, TaxRepository>();
builder.Services.AddScoped<CreateTaxHandler>();
builder.Services.AddScoped<GetTaxByIdHandler>();
builder.Services.AddScoped<UpdateTaxHandler>();
builder.Services.AddScoped<DeleteTaxHandler>();

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
app.Run();