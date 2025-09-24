/*
A user needs to be able to register an account
A user needs to be able to log out.
A user needs to be able to log in.
A user needs to be able to upload information about the item they wish to trade.
A user needs to be able to browse a list of other users items.
A user needs to be able to request a trade for other users items.
A user needs to be able to browse trade requests.
A user needs to be able to accept a trade request.
A user needs to be able to deny a trade request.
A user needs to be able to browse completed requests.
*/

using App;


List <User> users = new List<User>();            //Här lägger jag till en lista med folks inlogg.
users.Add(new User("moskarsson@hotmail.com", "password123"));
users.Add(new User("mlind@hotmail.com", "password123"));
users.Add(new User("anilsson@hotmail.com", "password123"));
users.Add(new User("hsöderberg@hotmail.com", "password123"));
users.Add(new User("dknezevic@hotmail.com", "password123"));
users.Add(new User("wtanski@hotmail.com", "password123"));
users.Add(new User("dtrulsson@hotmail.com", "password123"));
users.Add(new User("sandersson@hotmail.com", "password123"));

User active_user = null;   // Antingen finns det en User eller så kan den vara tom. Antingen finns en inloggad user eller inte.

bool running = true;

while (running)
{
    if(active_user == null)   // Funktionen för att logga in
    {
        Console.Write("Email: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        foreach (User user in users)
        {
            if (user.TryLogin(username, password))
            {
                active_user = user;
                break;
            }
        }
    }    
    else            // Funktionen för att logga ut
    {
        Console.WriteLine("--- Trade system ---");
        Console.WriteLine("logout");
        string input = Console.ReadLine();

        switch (input)
        {
            case "logout":
                active_user = null;
                break;
        }
    }
    
}