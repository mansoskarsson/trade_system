// En class för trade

namespace App;

class Trade
{
    public string Sender;
    public string Reciever;
    public string TradeStatus;
    public string Item;
    public string Accept;
    public string Deny;

    public Trade(string sender, string reciever, string tradeStatus, string item, string accept, string deny)
    {
        Sender = sender;
        Reciever = reciever;
        TradeStatus = tradeStatus;
        Item = item;
        Accept = accept;
        Deny = deny;
    }

}