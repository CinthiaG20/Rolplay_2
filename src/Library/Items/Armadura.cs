namespace Library.Items;

public class Armadura : IDefenseItem
{
    public string Name { get; private set; }
    public int DefenseValue { get; private set; }

    public Armadura(string nombre, int potenciaDefensa)
    {
        Name = nombre;
        DefenseValue = potenciaDefensa;
    }
}