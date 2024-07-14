using GoodReadersClone.Application.DTOs;
using GoodReadersClone.Application.Features.Users.Commands;
using GoodReadersClone.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodReadersClone.Api.Controllers;


[ApiController]
[Route("users")]
public class UsersController(ISender _sender)
{
    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public async Task<ActionResult<UserModel>> Register([FromForm] UserRegisterRequest request)
    {
        var result = await _sender.Send(new CreateUserCommand(request));
        return result;
    }

    [HttpGet]
    [Route("get")]
    public async Task<ActionResult<IEnumerable<UserInfoModel>>> GetAll()
    {
        var result = await _sender.Send(new GetAllUsersQuery());
        return result.ToList();
    }

    [HttpGet]
    [Route("get/{userId}")]
    public async Task<ActionResult<UserInfoModel>> GetById(string userId)
    {
        var result = await _sender.Send(new GetUserByIdQuery(userId));
        return result;
    }


    [HttpPost]
    [Route("seAsAuthor/{userId}")]
    public async Task<ActionResult<UserModel>> SetUserAsAuthor(string userId)
    {
        var result = await _sender.Send(new SetUserAsAuthorCommand(userId));
        return result;
    }
}
