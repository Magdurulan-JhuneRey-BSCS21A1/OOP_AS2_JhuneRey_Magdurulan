using System;

public class Identity
{
    public string Username { get; set; }
    public string Password { get; set; }

    public Identity(string username, string password)
    {
        Username = username;
        Password = password;
    }
}

