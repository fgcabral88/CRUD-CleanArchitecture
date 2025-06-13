using CRUD_CleanArchitecture.Application.Entities;
using CRUD_CleanArchitecture.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUD_CleanArchitecture.Infrastructure.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private readonly SQLContext _context;

        public TaxRepository(SQLContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaxEntity>> GetAllAsync() => await _context.Taxes.ToListAsync();

        public async Task<TaxEntity?> GetByIdAsync(Guid id) => await _context.Taxes.FindAsync(id);

        public async Task AddAsync(TaxEntity tax)
        {
            await _context.Taxes.AddAsync(tax);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaxEntity tax)
        {
            _context.Taxes.Update(tax);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tax = await _context.Taxes.FindAsync(id);

            if (tax != null)
            {
                _context.Taxes.Remove(tax);
                await _context.SaveChangesAsync();
            }
        }
    }
}
