using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Clients.Application.Features.Accounts.Commands.CreateAccount;
using Clients.Application.Features.Accounts.Commands.UpdateAccount;
using Clients.Application.Features.Accounts.Commands.DeleteAccount;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clients.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // ?? - если значение слева нулл, то будет вычислено и возвращено значение справа 


        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/<AccountController>
        [HttpPost(Name = "CreateAccount")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // ActionResult - абстрактный класс, возвращающий разные типы данных

        // PUT api/<AccountController>/5
        [HttpPut(Name = "UpdateAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType] // Создает описательные сведения об ответе для страниц справки по веб-API, создаваемых Swagger.
        public async Task<ActionResult> UpdateAccount([FromBody] UpdateAccountCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAccount(Guid id)
        {
            var command = new DeleteAccountCommand() { Account_ID = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
