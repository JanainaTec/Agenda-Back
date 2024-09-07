using Agenda.Domain;
using Agenda.Infra.Dto;
using Agenda.Infra.Model;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Agenda.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : Controller
    {
        private readonly IContato _contato;

        public ContatoController(IContato contato)
        {
            _contato = contato;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona uma nova Contato")]
        public IActionResult OnPost(ContactRequest model)
        {
            try
            {
                _contato.AddContact(model);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna todos os Contato")]
        [ProducesDefaultResponseType(typeof(List<Contato>))]
        public IActionResult OnGet()
        {
            try
            {
                var result = _contato.GetAllContacts();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Altera um contato")]
        public IActionResult OnPut(string id, ContactRequest model)
        {
            try
            {
                _contato.UpdateContact(Guid.Parse(id), model);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um contato")]
        public IActionResult OnDelete(string id)
        {
            try
            {
                _contato.DeleteContact(Guid.Parse(id));
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
