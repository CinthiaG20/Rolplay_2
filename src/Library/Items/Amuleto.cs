namespace Library.Items;


public class Amuleto : IAttackItem, IDefenseItem
{
    public string Name { get; private set; }
    public int AttackValue { get; private set; }
    public int DefenseValue { get; private set; }

    public Amuleto(string nombre, int ataque, int defensa)
    {
        Name = nombre;
        AttackValue = ataque;
        DefenseValue = defensa;
    }
}