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

using System.Runtime.CompilerServices;
using App;

List<User> users = new List<User>();            

List<Item> items = new List<Item>();

bool running = true;


while (running)
{
    Console.WriteLine("=== Create an account ===");   //Här lägger jag till så att man kan skapa en inloggning som man sedan ska kunna använda för att logga in
    Console.Write("Type your Email: ");
    string newUsername = Console.ReadLine();

    Console.Write("Choose a password: ");
    string newPassword = Console.ReadLine();

    User newUser = new User(newUsername, newPassword);
    users.Add(newUser);
    Console.WriteLine("Account created!");

    bool loggedIn = false;
    User currentUser = null;

    while (!loggedIn)
    {
        Console.WriteLine("=== Log in ===");
        Console.Write("Email: ");
        string loginUser = Console.ReadLine();

        Console.Write("Password: ");
        string loginPassword = Console.ReadLine();

        foreach (User user in users)                       //kollar så att inlogget finns
        {
            if (user.TryLogin(loginUser, loginPassword))
            {
                loggedIn = true;
                currentUser = user;
                Console.WriteLine($" Welcome {loginUser}");        // om rätt inlogg kommer man vidare till menyn

                string[] User = { loginUser, loginPassword };     // Spara inlogg i users.txt
                File.AppendAllLines("users.txt", User);

                break;
            }
        }
        if (!loggedIn)
        {
            Console.WriteLine("Wrong username or password");           //om fel inloggningsuppgifter blir användaren tillsagd att det är fel lösenord eller username
        }
    }
    bool Menu = true;
    while (Menu)    // En meny för att välja vad man vill göra
    {
        Console.WriteLine("Ready to start trade?");
        Console.WriteLine("Select what you want to do: ");
        Console.WriteLine("1. Add an item");
        Console.WriteLine("2. Show items in inventory");
        Console.WriteLine("3. Make a trade");
        Console.WriteLine("4. Browse trade requests");
        Console.WriteLine("5. Browse completed trades");
        Console.WriteLine("6. Logout");

        string userChoice = Console.ReadLine();

        switch (userChoice)
        {
            case "1":    // Detta är för att kunna lägga till items med namn och beskrivning
                Item newItem = new Item("Name", "Description");
                Console.Write("Please type in the name of your item: ");
                newItem.Item_name = Console.ReadLine();
                Console.Write("Please type an description of your item: ");
                newItem.Item_description = Console.ReadLine();
                items.Add(newItem);
                Console.WriteLine("The Item have been added! Press ENTER");
                Console.ReadLine();
                string[] Item = { newItem.Item_name, newItem.Item_description };
                File.AppendAllLines("items.txt", Item);
                break;

            case "2":                                         // Detta är för att kunna visa vilka items som har lagt till i inventory
                Console.WriteLine("Items in inventory");
                if (items.Count == 0)
                {
                    Console.WriteLine("Inventory is empty");
                }
                else
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        Item u = items[i];
                        Console.WriteLine($"{i + 1}. {u.Item_name} with the description: {u.Item_description}");
                    }
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                break;

            case "3":       //meny för trade
                Console.WriteLine("3,1. Choose Sender");
                Console.WriteLine("3,2. Choose Reciever");
                Console.WriteLine("3,3. Choose TradeStatus");
                Console.WriteLine("3,4. Choose Item");
                Console.WriteLine("3,5. Show current trade");

                string tradeChoice = Console.ReadLine();
                
                switch (tradeChoice)        // en till switch för att kunna göra cases för trade
                {

                case "3,1":
                Trade newTrade = new Trade("Sender", "Reciever", "TradeStatus", "Item");
                string[] user_rows = File.ReadAllLines("users.txt\n");       //få in info om user från users.txt
                foreach (string user_row in user_rows)
                {
                    Console.WriteLine(user_row);
                }

                break;
                }

                break;
            case "6":
                Console.WriteLine("You have been logged out");
                Menu = false;
                break;

        }

    }
    
}