using AbashonWeb.Service.Features.ClientFeatures.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbashonWeb.Controllers
{
    //[Authorize]
    [Route("api/v{version:apiVersion}/Client")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpGet]
        //[Route("")]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await Mediator.Send(new GetAllCustomerQuery()));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(new DeleteCustomerByIdCommand { Id = id }));
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await Mediator.Send(command));
        //}
    }
}
