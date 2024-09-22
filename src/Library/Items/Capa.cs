namespace Library.Items;

public class Capa : IDefenseItem
{
    public string Name { get; private set; }
    public int DefenseValue { get; private set; }

    public Capa(string nombre, int potenciaDefensa)
    {
        Name = nombre;
        DefenseValue = potenciaDefensa;
    }
}