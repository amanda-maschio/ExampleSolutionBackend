using HotelSolutionBackend.Command.Application.Commands.User;
using HotelSolutionBackend.Query.Application.Queries.User;
using HotelSolutionBackend.Query.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetUserListQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetUserByIdQuery(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // POST api/<UsersController>/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserViewModel user)
        {
            try
            {
                var command = new AddUserCommand(user.Email, user.Password, user.SessionToken, user.Register);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<UsersController>/3/Update
        [HttpPut("{id}/Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UserViewModel user)
        {
            try
            {
                var command = new UpdateUserCommand(id, user.Email, user.Password, user.SessionToken, user.Register);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Conflict(ex);
            }
        }

        // DELETE api/<UsersController>/3/Delete
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
