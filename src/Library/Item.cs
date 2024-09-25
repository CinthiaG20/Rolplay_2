namespace Library;

public class Item : IItem // creo la clase Item que implementa la interfaz IItem
{
    public string Name { get; set; }
    public int AttackValue { get; set; }
    public int DefenseValue { get; set; }
    public ItemType Type { get; set; }

    public Item(string name, int valor, ItemType type) //constructor de la clase
    {
      
        this.Name = name;
        this.Type = type;
      if (type == ItemType.Attack || type==ItemType.MagicAttack)
      {
          this.AttackValue = valor;
          this.DefenseValue = 0;
      }

      if (type == ItemType.Defense || type == ItemType.magicDefense)
      {
          this.DefenseValue = valor;
          this.AttackValue = 0;
      }

      if (type == ItemType.attackDefense || type==ItemType.Magic)
      {
          this.AttackValue = valor;
          this.DefenseValue = valor;
      }
    }
}
