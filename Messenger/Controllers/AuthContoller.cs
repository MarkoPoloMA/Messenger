using Microsoft.AspNetCore.Mvc;
using Messenger.Database.Context.Factory;
using Messenger.Domain.Dtos.User;
using Messenger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Messenger.Models;

namespace Messenger.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthContoller : ControllerBase
{
	private readonly IApplicationContextFactory _applicationContextFactory;
	public AuthContoller(IApplicationContextFactory applicationContextFactory)
	{
		_applicationContextFactory = applicationContextFactory;
	}

	[HttpPost("register")]
    public async Task<IActionResult> Registation(RegisterModel model)
	{
		await using var context = _applicationContextFactory.Create();
		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		if (await context.Users.AnyAsync(login => login.Login == model.Login))
			return BadRequest("Этот логин занят");

		var user = new User { Id = Guid.NewGuid(), Name = model.Login };

		var newUser = new User
		{
			Id = Guid.NewGuid(),
			Login = model.Login,
			Password = model.Password,
			Name = model.Name,
			RegistrationDate = DateTime.UtcNow
		};
		context.Users.Add(newUser);
		await context.SaveChangesAsync();

		var userRegisterDto = new RegisterDto
		{
			Id = newUser.Id,
			Login = newUser.Login,
			Name = newUser.Name
		};

		return Ok(userRegisterDto);
    }
	//public IActionResult Index()
	//{
	//	return View();
	//}
}

