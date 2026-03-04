using ProductClientHub.API.Entities;
using ProductClientHub.API.infraestruture;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Clients.Update
{ 
    public class UpdateClientUseCase
    {
       public void Execute(Guid clientId, RequestClientsJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();

            //pega o primeiro cliente com o id q ta procurando SE EXISTIR
            var entity = dbContext.Clients.First(client => client.Id == clientId);
            if (entity == null) {
                throw new NotFoundException("Cliente Não Encontrado!");
            }
            entity.Name = request.Nome;
            entity.Email = request.Email;

            dbContext.Clients.Update(entity);
            dbContext.SaveChanges();

        }

        private void Validate(RequestClientsJson request)
        {
            var validator = new RequestClientsValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {

                var lista = result.Errors.Select(failure => failure.ErrorMessage).ToList();

                throw new ErroOnValidationException(lista);
            }
        }
    }
}
