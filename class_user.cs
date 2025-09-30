// class för user och funktion för att user ska kunna logga in.

namespace App;

class User
{
    public string Username;

    string Password;


    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Username && password == Password;
    }
}