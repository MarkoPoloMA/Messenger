using Messenger.Domain.Dtos.User;
using Messenger.Domain.Entities;

namespace Messenger.Domain.Extension;
public static class RegisterExtension
{
	public static RegisterDto ToDto(this User user)
	{
		return new RegisterDto
		{
			Name = user.Name,
			Login = user.Login,
			Password = user.Password
		};
	}
}