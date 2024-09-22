namespace Library.Items;

public class Martillo : IAttackItem
{
    public string Name { get; private set; }
    public int AttackValue { get; private set; }

    public Martillo(string nombre, int ataque)
    {
        Name = nombre;
        AttackValue = ataque;
    }
}