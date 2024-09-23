namespace Library;

public class Item : IItem // creo la clase Item que implementa la interfaz IItem
{
    public string Name { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public ItemType Type { get; set; }

    public Item(string name, int attackValue, int defenseValue, ItemType type) //constructor de la clase
    {
      
        this.Name = name;
        this.AttackValue = attackValue;
        this.DefenseValue = defenseValue;
        this.Type = type;
    }
}