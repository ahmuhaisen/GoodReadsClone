using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("api/users")]
public class UsersController(ISender _sender)
{
    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public async Task<ActionResult<UsersModel>> Register([FromForm] UserRegisterRequest request)
    {

        var result = await _sender.Send(new CreateUserCommand(request));


        return result;
    }
}
