namespace Library.Items;

public class Arco : IAttackItem
{
    public string Name { get; private set; }
    public int AttackValue { get; private set; }

    public Arco(string nombre, int ataque)
    {
        Name = nombre;
        AttackValue = ataque;
    }
}