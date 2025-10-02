// class för item

namespace App;

class Item
{
    public string Name;

    public string Owner;

    public string Description;

    public Item(string name, string description, string owner)
    {
        Description = description;
        Name = name;
        Owner = owner; 
    }
}
