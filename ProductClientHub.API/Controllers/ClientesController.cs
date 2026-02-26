using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;

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
            try
            {
                var useCase = new RegisterClientsUseCases();

                var response = useCase.Execute(request);

                // Created() espera ou 0 parâmetros ou 2, como só queremos passar um, passamos o outro vazio
                return Created(string.Empty, response);
            }
            catch (ArgumentException ex) {
                return BadRequest(new ResponseErrorMessagesJson(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("ERRO DESCONHECIDO"));
            }
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        //caso tenha requisições iguais, como dois HttpGet, terá de especificar a URL

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet] //("by-id")
        [Route("{id}")]
        public IActionResult GetById(Guid Id)
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
