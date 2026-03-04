using FluentValidation;
using ProductClientHub.Communication.Requests;

namespace ProductClientHub.API.UseCases.Clients.SharedValidator
{
    public class RequestClientsValidator : AbstractValidator<RequestClientsJson>
    {
        public RequestClientsValidator() {
            // Nome não pode ser vazio!
            RuleFor(Clients => Clients.Nome).NotEmpty().WithMessage("O nome não pode ser vazio!");
            RuleFor(Clients => Clients.Email).EmailAddress().WithMessage("O email não é válido!");
        }
    }
}
