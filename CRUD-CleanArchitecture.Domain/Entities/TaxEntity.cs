namespace CRUD_CleanArchitecture.Application.Entities
{
    public class TaxEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public decimal Percentage { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        public TaxEntity(string name, decimal percentage)
        {
            Name = name;
            Percentage = percentage;
        }

        public void Update(string name, decimal percentage)
        {
            Name = name;
            Percentage = percentage;
        }
    }
}
