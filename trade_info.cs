// En class för trade

namespace App;

class Trade
{
    public string Sender;
    public string Reciever;
    public string TradeStatus;
    public string Item;

    public Trade(string sender, string reciever, string tradeStatus, string item)
    {
        Sender = sender;
        Reciever = reciever;
        TradeStatus = tradeStatus;
        Item = item;
    }

}