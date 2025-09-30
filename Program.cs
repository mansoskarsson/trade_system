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



List<User> users = new List<User>();            //Här lägger jag till en lista med folks inlogg.

Console.WriteLine("=== Create an account ===");
Console.Write("Type your Email: ");
string newUsername = Console.ReadLine();

Console.Write("Choose a password: ");
string newPassword = Console.ReadLine();

users.Add(new User(newUsername, newPassword));
Console.WriteLine("Account created!");

Console.WriteLine("=== Log in ===");
Console.Write("Email: ");
string loginUser = Console.ReadLine();

Console.Write("Password: ");
string loginPassword = Console.ReadLine();

List<Item> items = new List<Item>();





 

bool running = true;

while (running)
{
    bool loggedIn = false;

    foreach (User user in users)
    {
        if (user.TryLogin(loginUser, loginPassword))
        {
            loggedIn = true;
            break;
        }
    }
    if (!loggedIn)
    {
        Console.WriteLine("Wrong username or password");
    }
    else            
    {
        Console.WriteLine($" Welcome {loginUser}");
        

        if (true)         // En meny för att välja vad man vill göra
        {
            Console.WriteLine("Ready to start trade?");
            Console.WriteLine("Select what you want to do: ");
            Console.WriteLine("1. Add an item");
            Console.WriteLine("2. Show items in inventory");
            Console.WriteLine("3. Make a trade");
            Console.WriteLine("4. Browse trade requests");
            Console.WriteLine("5. Browse completed trades");

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
                    break;

                case "2":                                         // Detta är för att kunna visa vilka items som har lagt till i inventory
                    Console.WriteLine("Items in inventory");
                    if (items.Count == 0) {
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

                case "3":
                    Trade newTrade = new Trade("Sender", "Reciever", "TradeStatus", "Item");
                    //Console.Write("Current sender is:" {GetUser} "and current reciever is:" {GetUser});
                    break; 
                    
            }

        }
        
    }
    
}