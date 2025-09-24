// class för user och funktion för att user ska kunna logga in.

namespace App;

class User
{
    public string Email;

    string _password;


    public User(string email, string password)
    {
        Email = email;
        _password = password;
    }

    public bool TryLogin(string username, string password)
    {
        return username == Email && password == _password;
    }
}