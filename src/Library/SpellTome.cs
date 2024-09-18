using System.Collections;
namespace Library;

public class SpellTome : IItem, IEnumerable<Spell> //implementa la clase spelltome de tipo item y la interfaz IEnumerable de tipo spell
{
    private List<Spell> spells = new List<Spell>(); //se crea una lista de hechizos

    public SpellTome(string name, int attackValue, int defenseValue) : //constructor de la clase
        base(name, attackValue, defenseValue) //se llama al constructor de la clase base
    {
    }

    public void AddSpell(Spell spell) //metodo para añadir hechizo
    {
        if (spell != null) //si el hechizo existe
        {
            this.spells.Add(spell); //se añade el hechizo a la lista
        }
        else
        {
            Console.WriteLine("Ese hechizo no existe"); //si el hechizo no existe, se imprime un mensaje
        }
    }
 

    public void RemoveSpell(Spell spell) //metodo para quitar hechizo
    {
        if (spell != null) //si el hechizo existe
        {
            this.spells.Remove(spell); //se remueve el hechizo
        }
        else
        {
            Console.WriteLine("Ese hechizo no existe"); //si el hechizo no existe, se imprime un mensaje
        }
    }

    public bool ContainsSpell(Spell spell) //metodo para saber si contiene un hechizo
    {
        return this.spells.Contains(spell); //retorna si la lista contiene el hechizo
    }

    public string GetSpellsInfo() //metodo para obtener la informacion de los hechizos
    {
        string info = "Hechizos:\n"; //se inicializa la variable info
        foreach (Spell spell in this.spells) //se recorre la lista de hechizos
        {
            info += $"- {spell.Name} (Ataque: {spell.Damage})\n"; //se añade la informacion de cada hechizo
        }
        return info; //se retorna la informacion
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