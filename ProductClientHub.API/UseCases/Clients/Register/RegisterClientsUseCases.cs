using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
namespace ProductClientHub.API.UseCases.Clients.Register;


public class RegisterClientsUseCases
{
      public ResponseClientsJson Execute(RequestClientsJson request)
    {
        var validator = new RegisterClientsValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false) {
            throw new ArgumentException("Erro NOS DADOS");
        }
        return new ResponseClientsJson();
    }
}
