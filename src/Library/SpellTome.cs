using System.Collections;
using System.Collections.Generic;

namespace Library;

public class SpellTome : IItem, IEnumerable<Spell>
{
    private List<Spell> spells = new List<Spell>();

    public string Name { get; set; }
    public ItemType Type { get; set; }
    public int AttackValue { get; set; } = 0; //de esta forma se evita al crear un libro agrtegarle un valor de ataque
    public int DefenseValue { get; set; } = 0; //de esta forma se evita al crear un libro agrtegarle un valor de defensa
    public SpellTome(string name, ItemType type)
    {
        this.Name = name;
        this.Type = type;
    }

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

    public void RemoveSpell(Spell spell)
    {
        if (spell != null)
        {
            this.spells.Remove(spell);
        }
        else
        {
            Console.WriteLine("Ese hechizo no existe");
        }
    }

    public bool ContainsSpell(Spell spell)
    {
        return this.spells.Contains(spell);
    }

    public string GetSpellsInfo()
    {
        string info = "Hechizos:\n";
        foreach (Spell spell in this.spells)
        {
            info += $"- {spell.Name}\n";
        }
        return info;
    }

    public IEnumerator<Spell> GetEnumerator()
    {
        return this.spells.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}