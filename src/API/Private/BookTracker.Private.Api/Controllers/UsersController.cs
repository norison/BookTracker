using BookTracker.BusinessLogic.Features.Commands.AddUser;
using BookTracker.BusinessLogic.Features.Commands.VerifyUser;
using BookTracker.Private.Api.Contracts.AddUser;
using BookTracker.Private.Api.Contracts.VerifyUser;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Private.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddUserAsync(AddUserRequest request, CancellationToken cancellationToken)
    {
        var command = new AddUserCommand
        {
            Login = request.Login,
            Email = request.Email,
            Password = request.Password,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        
        await _sender.Send(command, cancellationToken);
        return NoContent();
    }
    
    [HttpPost("verify")]
    public async Task<IActionResult> VerifyUserAsync(VerifyUserRequest request, CancellationToken cancellationToken)
    {
        var command = new VerifyUserCommand
        {
            EmailOrLogin = request.EmailOrLogin,
            Password = request.Password
        };
        
        await _sender.Send(command, cancellationToken);
        return NoContent();
    }
}
