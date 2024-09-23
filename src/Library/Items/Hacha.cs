namespace Library.Items;

public class Hacha : IAttackItem
{
    public string Name { get; private set; }
    public int AttackValue { get; private set; }

    public Hacha(string nombre, int ataque)
    {
        Name = nombre;
        AttackValue = ataque;
    }
}