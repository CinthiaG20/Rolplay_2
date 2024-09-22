namespace Library.Items;

public class Escudo : IDefenseItem
{
    public string Name { get; private set; }
    public int DefenseValue { get; private set; }

    public Escudo(string nombre, int potenciaDefensa)
    {
        Name = nombre;
        DefenseValue = potenciaDefensa;
    }
}