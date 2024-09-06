using System;
using System.Text.Json;

public class User
{
    private List<Identity> users = new List<Identity>();
    public string filePath = "user.json";
    public void LoadUsersFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            users = JsonSerializer.Deserialize<List<Identity>>(json);
        }
        else
        {
            users.Add(new Identity("admin", "password"));
            SaveUsersToJson(filePath);
        }
    }

    public void SaveUsersToJson(string filePath)
    {
        string json = JsonSerializer.Serialize(users);
        File.WriteAllText(filePath, json);
    }

    public bool IsValid(string username, string password)
    {
        foreach (var user in users)
        {
            if (user.Username == username && user.Password == password)
            {
                return true;
            }
        }
        return false;
    }

    public void AddUser(string username, string password, string filepath)
    {
        foreach (var user in users)
        {
            if (user.Username == username)
            {
                throw new InvalidOperationException("User already exists.");
            }
        }
        users.Add(new Identity(username, password));
        SaveUsersToJson(filepath);
    }


}

