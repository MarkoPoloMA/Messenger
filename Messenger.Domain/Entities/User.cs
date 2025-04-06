﻿namespace Messenger.Domain.Entities;
public class User
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
	public DateTime RegistrationDate { get; set; }
}
