namespace Library.Items;

public class Guantelete : IAttackItem, IDefenseItem
{
    public string Name { get; private set; }
    public int AttackValue { get; private set; }
    public int DefenseValue { get; private set; }

    public Guantelete(string nombre, int ataque, int defensa)
    {
        Name = nombre;
        AttackValue = ataque;
        DefenseValue = defensa;
    }
}