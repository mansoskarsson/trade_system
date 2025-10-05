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

using System.Buffers;
using System.Runtime.CompilerServices;
using App;

List<User> users = new List<User>();

List<Item> items = new List<Item>();

List<Trade> trades = new List<Trade>();

bool running = true;


while (running)
{
    Console.Clear();
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
        Console.Clear();
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

                string[] User = { loginUser };     // Spara inlogg i users.txt
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
        Console.Clear();
        Console.WriteLine("Select what you want to do: ");
        Console.WriteLine("1. Add an item");
        Console.WriteLine("2. Show items in inventory");
        Console.WriteLine("3. Make a trade");
        Console.WriteLine("4. Browse trade requests");       // if TradeStaus.Pending
        Console.WriteLine("5. Browse completed trades");      // if TradeStatus.Accepted
        Console.WriteLine("6. Logout");

        string userChoice = Console.ReadLine();

        switch (userChoice)
        {
            case "1":    // Detta är för att kunna lägga till items med namn och beskrivning
                Console.Clear();
                Console.Write("Please type in the name of your item: ");
                string itemName = Console.ReadLine();

                Console.Write("Please type an description of your item: ");
                string itemDescription = Console.ReadLine();

                Item newItem = new Item(itemName, itemDescription, currentUser.Username);
                items.Add(newItem);

                Console.WriteLine("The Item have been added! Press ENTER");
                Console.ReadLine();

                string[] Item = { newItem.Name, newItem.Description, newItem.Owner };
                File.AppendAllLines("items.txt", Item);
                break;

            case "2":                                         // Detta är för att kunna visa vilka items som har lagt till i inventory
                Console.Clear();
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
                        Console.WriteLine($"{i + 1}. {u.Name} with the description: {u.Description}");
                    }
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                break;

               

            case "3":       //meny för trade
                Console.Clear();
                {
                    string sender = "";
                    string reciever = "";
                    Item chosenItem = null;
                    TradeStatus currentTradeStatus = TradeStatus.Pending;

                    bool TradeMenu = true;
                    while (TradeMenu)
                    {
                        Console.WriteLine();
                        Console.WriteLine("=== Trade menu ===");
                        Console.WriteLine("3,1. Choose Sender");
                        Console.WriteLine("3,2. Choose Reciever");
                        Console.WriteLine("3,3. Choose TradeStatus");
                        Console.WriteLine("3,4. Choose Item");
                        Console.WriteLine("3,5. Show current trade");
                        Console.WriteLine("b. back to main menu");
                        Console.Write("Choice: ");

                        string tradeChoice = Console.ReadLine();


                        switch (tradeChoice)        // en till switch för att kunna göra cases för trade
                        {

                            case "3,1":

                                string[] user_rows_sender = File.ReadAllLines("users.txt");       //få in info om user från users.txt

                                if (users.Count == 0)
                                {
                                    Console.WriteLine("No users avaliable");
                                    break;
                                }
                                Console.WriteLine("Avaliable users:");
                                for (int i = 0; i < users.Count; i++)  // en for loop här istället for en foreach efter som jag vill kunna ange ett index för att välja vilken användare jag vill man ska kunna välja som sender
                                
                                    Console.WriteLine($"{i + 1}. {users[i].Username}");
                                
                                Console.Write("Choose a sender by number: ");
                                if (int.TryParse(Console.ReadLine(), out int senderindex) && senderindex >= 1 && senderindex <= users.Count)
                                {
                                    sender = users[senderindex - 1].Username;
                                    Console.WriteLine($"Sender chosen: {sender}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection");
                                }
                                break;

                            case "3,2":
                                string[] user_rows_reciever = File.ReadAllLines("users.txt");       //få in info om user från users.txt
                                if (users.Count == 0)
                                {
                                    Console.WriteLine("No users avaliable");
                                    break;
                                }
                                Console.WriteLine("Avaliable users:");
                                for (int i = 0; i < users.Count; i++)
                                    Console.WriteLine($"{i + 1}. {users[i].Username}");
                                
                                Console.Write("Choose a reciever by number:");
                                if (int.TryParse(Console.ReadLine(), out int recieverindex) && recieverindex >= 1 && recieverindex <= users.Count)
                                {
                                    reciever = users[recieverindex - 1].Username;
                                    Console.WriteLine($"Reciever chosen: {reciever}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection.");
                                }
                                break;

                            case "3,3":
                                Console.WriteLine("=== Choose Trade Status ===");
                                var statuses = Enum.GetValues(typeof(TradeStatus));

                                int index = 1;
                                foreach (TradeStatus y in statuses)
                                {
                                    Console.WriteLine($"{index}. {y}");
                                    index++;
                                }

                                Console.Write("Chose a status by number: ");
                                if (int.TryParse(Console.ReadLine(), out int statusIndex) && statusIndex >= 1 && statusIndex <= statuses.Length)
                                {
                                    TradeStatus chosenStatus = (TradeStatus)statuses.GetValue(statusIndex - 1);
                                    Console.WriteLine($"Trade status chosen: {chosenStatus}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid slection");
                                }

                                break;

                            case "3,4":
                                string[] item_rows = File.ReadAllLines("items.txt");  //för att visa items från textfilen items.txt
                                List<Item> userItems = new List<Item>();

                                if (items.Count == 0)
                                {
                                    Console.WriteLine("No items avaliable");
                                    break;
                                }
                                Console.WriteLine("Avaliable items:");

                                for (int i = 0; i < items.Count; i++)
                                    Console.WriteLine($"{i + 1}. {items[i].Name} - {items[i].Description} (Owner: {items[i].Owner})");   // för att kunna välja items med ett nummer
                                Console.Write("Choose an item by number: ");
                                if (int.TryParse(Console.ReadLine(), out int itemindex) && itemindex >= 1 && itemindex <= items.Count)
                                {
                                    chosenItem = items[itemindex - 1];
                                    Console.WriteLine($"You chose: {chosenItem.Name} from {chosenItem.Owner}");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection");
                                }
                                break;

                            case "3,5":
                                if (sender == null || reciever == null || chosenItem == null)
                                {
                                    Console.WriteLine("You must choose sender, reciever and item first.");
                                }
                                else
                                {
                                    Trade newTrade = new Trade(sender, reciever, chosenItem.Name, currentTradeStatus);          //visar vilken sender, reciever och item för traden
                                    trades.Add(newTrade);           //lägger till en trade för case 4 där jag vill att alla trades med "pending" från case 3,3 tradestatus ska visas

                                    Console.WriteLine($"Trade created");
                                    Console.WriteLine($"Sender: {newTrade.Sender}");
                                    Console.WriteLine($"Reciever: {newTrade.Reciever}");
                                    Console.WriteLine($"Item: {newTrade.Item}");
                                    Console.WriteLine($"Status: {newTrade.Status}");
                                }
                                break;
                            case "b":                        //för att komma tillbaka till main menu
                                TradeMenu = false;
                                break;
                        }
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        
                    }
                    break;
                }

                case "4":
                Console.Clear();
                Console.WriteLine("=== Pending Trade Requests ===");

                List<Trade> pendingTrades = new List<Trade>();

                foreach (Trade t in trades)
                {
                    if (t.Status == TradeStatus.Pending)
                    {
                        pendingTrades.Add(t);
                    }
                }

                if (pendingTrades.Count == 0)
                {
                    Console.WriteLine("No pending trades avaliable");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    break;
                }
                
                
                for (int i = 0; i < pendingTrades.Count; i++)          //skriva ut all info om traden iklusive tradestatus när man browsar trade requests
                {
                    Trade trade = pendingTrades[i];
                    Console.WriteLine($"{i + 1}. Sender: {trade.Sender} --> Reciever: {trade.Reciever} | Item: {trade.Item} | Status: {trade.Status}");
                }

                Console.WriteLine();
                Console.Write("Chose a trade to accept/deny by number");                        //möjligheten att kunna välja att acceptera eller neka en trade som har statusen pending
                string input = Console.ReadLine();

                int tradeIndex;
                if (int.TryParse(input, out tradeIndex) && tradeIndex >= 1 && tradeIndex <= pendingTrades.Count)
                {
                    Trade selectedTrade = pendingTrades[tradeIndex - 1];

                    Console.WriteLine($"You selected trade: {selectedTrade.Sender} --> {selectedTrade.Reciever} | Item: {selectedTrade.Item}");
                    Console.WriteLine("1. Accept trade");
                    Console.WriteLine("2. Deny trade");

                    Console.WriteLine("Choose an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            selectedTrade.Status = TradeStatus.Accepted;
                            Console.WriteLine("Trade Accepted");
                            break;

                        case "2":
                            selectedTrade.Status = TradeStatus.Denied;
                            Console.WriteLine("Trade Denied");
                            break;

                        default:
                            Console.WriteLine("Invalid selection");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid trade number");
                }

                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                break;

                case "5":                // I stort sett samma som case 4 bara att de som har blivit valda som accepted eller denied istället för pending ska visas här under browse completed trades
                Console.Clear();
                Console.WriteLine("=== Completed Trades ===");

                List<Trade> completedTrades = new List<Trade>();

                foreach (Trade t in trades)
                {
                    if (t.Status == TradeStatus.Accepted || t.Status == TradeStatus.Denied)
                    {
                        completedTrades.Add(t);
                    }
                }
                if (completedTrades.Count == 0)
                {
                    Console.WriteLine("No completed trades found");
                }
                else
                {
                    for (int i = 0; i < completedTrades.Count; i++)
                    {
                        Trade trade = completedTrades[i];
                        Console.WriteLine($"{i + 1}. Sender: {trade.Sender} --> Reciever: {trade.Reciever} | Item: {trade.Item} | Status: {trade.Status}");
                    }
                }
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                break;


            case "6":                                              // för att kunna logga ut och därefter kunna skapa en till användare
                Console.Clear();
                Console.WriteLine("You have been logged out");
                Menu = false;
                break;

        }

    }
    
}