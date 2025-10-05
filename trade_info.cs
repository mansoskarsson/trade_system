// En class för trade

namespace App;

class Trade
{
    public string Sender;
    public string Reciever;
    
    public string Item;


    public Trade(string sender, string reciever, string item)
    {
        Sender = sender;
        Reciever = reciever;
        
        Item = item;

    }

    //public TradeStatus GetTradeStatus();

    //public Item GetItem();

    //public User GetUser();

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