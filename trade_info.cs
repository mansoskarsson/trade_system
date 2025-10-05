// En class för trade

namespace App;

class Trade
{
    public string Sender;
    public string Reciever;
    public string Item;

    public TradeStatus Status;


    public Trade(string sender, string reciever, string item, TradeStatus status)
    {
        Sender = sender;
        Reciever = reciever;
        Item = item;
        Status = status;

    }

    //public TradeStatus GetTradeStatus();

    //public Item GetItem();

    //public User GetUser();

}

enum TradeStatus
{
    Pending,
    Denied,
    Accepted,
}



/*
class Tradeaction
{
    public string Accept;
    public string Deny;


    public Tradeaction(string accept, string deny)
    {
        Accept = accept;
        Deny = deny;
    }
}    
*/