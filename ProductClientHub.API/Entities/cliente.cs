namespace ProductClientHub.API.Entities
{
    public class cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid(); //cria um novo id
        public string Name { get; set; } = string.Empty;
        public string Email{ get; set; } = string.Empty;
    }
}
