using ProductClientHub.API.infraestruture;
using ProductClientHub.Communication.Responses;

namespace ProductClientHub.API.UseCases.Clients.GetAll
{
    public class GetClientsAllUseCase
    {
        public ResponseAllClients Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            var clients = dbContext.Clients.ToList();

            var teste = clients.Select(client => new ResponseClientsJson
            {
                Id = client.Id,
                Name = client.Name,
            }).ToList();

            return new ResponseAllClients
            {
                Clients = teste
            };
        }
    }
}
