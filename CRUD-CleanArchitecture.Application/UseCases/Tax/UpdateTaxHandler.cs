using CRUD_CleanArchitecture.Application.Dtos.Tax;
using CRUD_CleanArchitecture.Domain.Interfaces.Repositories;

namespace CRUD_CleanArchitecture.Application.UseCases.Tax
{
    public class UpdateTaxHandler
    {
        private readonly ITaxRepository _repository;

        public UpdateTaxHandler(ITaxRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> HandleAsync(Guid id, TaxListDto dto)
        {
            var existingTax = await _repository.GetByIdAsync(id);

            if (existingTax == null)
                return false;

            existingTax.Update(dto.Name, dto.Percentage);

            await _repository.UpdateAsync(existingTax);

            return true;
        }
    }
}
