namespace CRUD_CleanArchitecture.Application.Dtos.Tax
{
    public class TaxListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Percentage { get; set; }
    }
}
