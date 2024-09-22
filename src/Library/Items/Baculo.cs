namespace Library.Items;

public class Baculo : IMagicItem
{
    public string Name { get; private set; }
    private List<Spell> spells = new List<Spell>();
    
    public void AddSpell(Spell spell)
    {
        if (spell != null)
        {
            this.spells.Add(spell);
        }
        else
        {
            Console.WriteLine("Ese hechizo no existe");
        }
    }

    public Baculo(string nombre)
    {
        Name = nombre;
    }
}