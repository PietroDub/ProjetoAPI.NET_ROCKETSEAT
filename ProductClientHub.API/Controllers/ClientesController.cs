using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        // EndPoint (CRUD)
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientsJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientsJson request)
        {
                //verificação do try catch feita no filter
                var useCase = new RegisterClientsUseCases();

                var response = useCase.Execute(request);

                // Created() espera ou 0 parâmetros ou 2, como só queremos passar um, passamos o outro vazio
                return Created(string.Empty, response);
      
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [Route("{id}")]
        public IActionResult Update([FromBody] RequestClientsJson request, [FromRoute] Guid id)
        {
            var UseCase = new UpdateClientUseCase();

            UseCase.Execute(id, request);

            return NoContent();
        }

        //caso tenha requisições iguais, como dois HttpGet, terá de especificar a URL

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClients), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetClientsAllUseCase();

            var response = useCase.Execute();

            if (response.Clients.Count > 0)
            {
                return Ok(response);
            }
            else {
                return NoContent();
            }
        }

        [HttpGet] //("by-id")
        [Route("{id}")]
        public IActionResult GetById([FromRoute]Guid Id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
