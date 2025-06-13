using CRUD_CleanArchitecture.Application.Dtos.Tax;
using CRUD_CleanArchitecture.Domain.Interfaces.Repositories;

namespace CRUD_CleanArchitecture.Application.UseCases.Tax
{
    public class GetTaxByIdHandler
    {
        private readonly ITaxRepository _repository;

        public GetTaxByIdHandler(ITaxRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaxListDto?> HandleAsync(Guid id)
        {
            var tax = await _repository.GetByIdAsync(id);

            return tax is null ? null : new TaxListDto
            {
                Id = tax.Id,
                Name = tax.Name,
                Percentage = tax.Percentage
            };
        }
    }
}
