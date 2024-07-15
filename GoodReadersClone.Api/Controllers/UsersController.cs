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
    [Route("registerAsReader")]
    [AllowAnonymous]
    public async Task<ActionResult<UserModel>> RegisterAsReader([FromForm] UserRegisterRequest request)
    {
        var result = await _sender.Send(new CreateReaderCommand(request));
        return result;
    }

    [HttpPost]
    [Route("registerAsAuthor")]
    [AllowAnonymous]
    public async Task<ActionResult<UserModel>> RegisterAsAuthor([FromForm] UserRegisterRequest request)
    {
        var result = await _sender.Send(new CreateAuthorCommand(request));
        return result;
    }

    [HttpGet]
    [Route("getAllUsers")]
    public async Task<ActionResult<IEnumerable<UserInfoModel>>> GetAllReaders()
    {
        var result = await _sender.Send(new GetAllUsersQuery());
        return result.ToList();
    }


    [HttpGet]
    [Route("getAllAuthors")]
    public async Task<ActionResult<IEnumerable<UserInfoModel>>> GetAllAuthors()
    {
        var result = await _sender.Send(new GetAllAuthorsQuery());
        return result.ToList();
    }

    [HttpGet]
    [Route("get/{userId}")]
    public async Task<ActionResult<UserInfoModel>> GetById(string userId)
    {
        var result = await _sender.Send(new GetUserByIdQuery(userId));
        return result;
    }


}
