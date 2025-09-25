// class för item

namespace item_class;

class Item
{
    public string Item_name;

    public string Item_description;

    public Item(string item_name, string item_description)
    {
        Item_description = item_description;
        Item_name = item_name;
    }
}
