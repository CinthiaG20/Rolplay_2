namespace Library;

public class Item : IItem
{
    public string Name { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public ItemType Type { get; set; }

    public Item(string name,int valor, ItemType type)
    {
        this.Name = name;
        this.Type = type;
        if (type == ItemType.Attack)
        {
            AttackValue = valor;
            DefenseValue = 0;
        }

        if (type == ItemType.Defense)
        {
            AttackValue = 0;
            DefenseValue = valor;
        }

        if (type == ItemType.Magic)
        {
            
        }
        
        
    }
}