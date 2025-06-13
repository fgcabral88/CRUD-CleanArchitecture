using CRUD_CleanArchitecture.Domain.Interfaces.Repositories;

namespace CRUD_CleanArchitecture.Application.UseCases.Tax
{
    public class DeleteTaxHandler
    {
        private readonly ITaxRepository _repository;

        public DeleteTaxHandler(ITaxRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> HandleAsync(Guid id)
        {
            var tax = await _repository.GetByIdAsync(id);

            if (tax == null)
                return false;

            await _repository.DeleteAsync(id);

            return true;
        }
    }
}
