using CRUD_CleanArchitecture.Application.Entities;

namespace CRUD_CleanArchitecture.Domain.Interfaces.Repositories
{
    public interface ITaxRepository
    {
        Task<IEnumerable<TaxEntity>> GetAllAsync();
        Task<TaxEntity?> GetByIdAsync(Guid id);
        Task AddAsync(TaxEntity tax);
        Task UpdateAsync(TaxEntity tax);
        Task DeleteAsync(Guid id);
    }
}
