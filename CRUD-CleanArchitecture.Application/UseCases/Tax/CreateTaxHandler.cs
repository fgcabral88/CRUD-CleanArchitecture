using CRUD_CleanArchitecture.Application.Dtos.Tax;
using CRUD_CleanArchitecture.Application.Entities;
using CRUD_CleanArchitecture.Domain.Interfaces.Repositories;

namespace CRUD_CleanArchitecture.Application.UseCases.Tax
{
    public class CreateTaxHandler
    {
        public readonly ITaxRepository _repository;

        public CreateTaxHandler(ITaxRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> HandleAsync(TaxListDto dto)
        {
            var tax = new TaxEntity(dto.Name, dto.Percentage);

            await _repository.AddAsync(tax);

            return tax.Id;
        }
    }
}
