using CRUD_CleanArchitecture.Application.Entities;
using Microsoft.EntityFrameworkCore;

public class SQLContext : DbContext
{
    public SQLContext(DbContextOptions<SQLContext> options)
        : base(options) { }

    public DbSet<TaxEntity> Taxes => Set<TaxEntity>();
}