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
using item_class;


List <User> users = new List<User>();            //Här lägger jag till en lista med folks inlogg.
users.Add(new User("moskarsson@hotmail.com", "password123"));
users.Add(new User("mlind@hotmail.com", "password123"));
users.Add(new User("anilsson@hotmail.com", "password123"));
users.Add(new User("hsöderberg@hotmail.com", "password123"));
users.Add(new User("dknezevic@hotmail.com", "password123"));
users.Add(new User("wtanski@hotmail.com", "password123"));
users.Add(new User("dtrulsson@hotmail.com", "password123"));
users.Add(new User("sandersson@hotmail.com", "password123"));

List<Item> items = new List<Item>();  //Lista för items


User? active_user = null;   // Antingen finns det en User eller så kan den vara tom. Antingen finns en inloggad user eller inte.

bool running = true;

while (running)
{
    if (active_user == null)   // Funktionen för att logga in
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
    else            
    {
        Console.WriteLine("--- Trade system ---");
        

        if (true)         // En meny för att välja vad man vill göra
        {
            Console.WriteLine("Welcome User! Ready to start trade?");
            Console.WriteLine("Select what you want to do: ");
            Console.WriteLine("1. Add an item");
            Console.WriteLine("2. Show items in inventory");
            Console.WriteLine("3. Make a trade");
            Console.WriteLine("4. Browse trade requests");
            Console.WriteLine("5. Browse completed trades");

            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":                                             // Detta är för att kunna lägga till items med namn och beskrivning
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
                    Console.Write("Current sender is:" {GetUser} "and current reciever is:" {GetUser});
                    break; 
                    
            }

        }
        
    }
    
}