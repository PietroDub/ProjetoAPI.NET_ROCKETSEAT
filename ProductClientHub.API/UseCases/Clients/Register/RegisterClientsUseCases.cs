using ProductClientHub.API.Entities;
using ProductClientHub.API.infraestruture;
using ProductClientHub.API.UseCases.Clients.SharedValidator;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;
namespace ProductClientHub.API.UseCases.Clients.Register;


public class RegisterClientsUseCases
{
     public ResponseClientsJson Execute(RequestClientsJson request) { 

        Validate(request);

        var dbContext = new ProductClientHubDbContext();

        var entity = new cliente
        {
            Name = request.Nome,
            Email = request.Email
        };

        //prepara query
        dbContext.Clients.Add(entity);

        // persiste no banco
        dbContext.SaveChanges();

        return new ResponseClientsJson();
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
