
using Messenger.Domain.Dtos.User;
using Messenger.Domain.Entities;

namespace Messenger.Domain.Extension;
public static class LoginExtension
{
	public static LoginDto ToDto(this User user)
	{
		return new LoginDto
        {
			Login = user.Login,
			Password = user.Password
		};
	}
}