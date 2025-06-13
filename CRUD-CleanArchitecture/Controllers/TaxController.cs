using Microsoft.AspNetCore.Mvc;
using CRUD_CleanArchitecture.Application.UseCases.Tax;
using CRUD_CleanArchitecture.Application.Dtos.Tax;

namespace CRUD_CleanArchitecture.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly CreateTaxHandler _createHandler;
        private readonly GetTaxByIdHandler _getHandler;
        private readonly UpdateTaxHandler _updateHandler;
        private readonly DeleteTaxHandler _deleteHandler;

        public TaxController(CreateTaxHandler createHandler, GetTaxByIdHandler getHandler, UpdateTaxHandler updateHandler, DeleteTaxHandler deleteHandler)
        {
            _createHandler = createHandler;
            _getHandler = getHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaxListDto dto)
        {
            var id = await _createHandler.HandleAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getHandler.HandleAsync(id);

            return result is null ? NotFound() : Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TaxListDto dto)
        {
            var success = await _updateHandler.HandleAsync(id, dto);

            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _deleteHandler.HandleAsync(id);

            return success ? NoContent() : NotFound();
        }
    }
}
