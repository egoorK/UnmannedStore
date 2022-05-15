using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using ProductRecognition.Application.Features.Images.Commands.SaveImage;
using ProductRecognition.Application.Features.Images.Queries.GetImageById;
using System.Threading.Tasks;

namespace ProductRecognition.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImageController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // GET: api/<ImageController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ImageController>/5
        [HttpGet("{id}", Name = "GetImage")]
        [ProducesResponseType(typeof(ImageVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ImageVm>> GetImageById(Guid Id)
        {
            var query = new GetImageQuery(Id);
            var image = await _mediator.Send(query);
            return Ok(image);
        }

        // POST api/<ImageController>
        [HttpPost(Name = "RecognizeProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> RecognizeProduct([FromBody] SaveImageCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // PUT api/<ImageController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ImageController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
