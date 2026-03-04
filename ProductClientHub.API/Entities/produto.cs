namespace ProductClientHub.API.Entities
{
    public class produto
    {
        public Guid Id { get; set; } 
        public string Name { get; set;} = string.Empty;

        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid ClienteId { get; set; }

    }
}
