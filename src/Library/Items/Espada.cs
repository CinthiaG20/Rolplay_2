namespace Library.Items;

public class Espada : IAttackItem
{
    public string Name { get; private set; }
    public int AttackValue { get; private set; }

    public Espada(string nombre, int ataque)
    {
        Name = nombre;
        AttackValue = ataque;
    }
}