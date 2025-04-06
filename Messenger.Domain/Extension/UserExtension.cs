using Messenger.Domain.Dtos.User;
using Messenger.Domain.Entities;

namespace Messenger.Domain.Extension;
public static class UserExtension
{
	public static UserDto ToDto(this User user)
	{
		return new UserDto
		{
			Name = user.Name
		};
	}
}