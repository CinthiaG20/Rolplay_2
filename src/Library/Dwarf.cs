using System.Security.Cryptography;
using System.Collections;

namespace Library;

public class Dwarf : Chara
{
    private string name;
    private int health;
    private int maxhealth;
    private ArrayList items = new ArrayList();

    public Dwarf(string name, int maxhealth)
    {
        this.Name = name;
        this.maxhealth = maxhealth;
        this.Health = maxhealth;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public void AddItem(IItem item)
    {
        if (item != null)
        {
            if (item.Type != ItemType.Magic)
            {
                this.items.Add(item);
            }
        }
        else
        {
            Console.WriteLine("Ese item no existe");
        }
    }

    public void RemoveItem(IItem item)
    {
        if (item != null)
        {
            this.items.Remove(item);
            Console.WriteLine($"{item.Name} ha sido removido de {this.Name}.");
        }
        else
        {
            Console.WriteLine("Ese item no existe.");
        }
    }

    public IItem GetItemByName(string nombre)
    {
        foreach (IItem item in this.items)
        {
            if (item.Name == nombre)
            {
                return item;
            }
        }

        return null;
    }

    public int TotalDamage()
    {
        int totalatk = 0;
        foreach (IItem item in this.items)
        {
            totalatk += item.AttackValue;
        }
        return totalatk;
    }

    public int TotalDefense()
    {
        int totaldef = 0;
        foreach (IItem item in this.items)
        {
            totaldef += item.DefenseValue;
        }
        return totaldef;
    }

    public void Attack(Chara target, IItem item) //metodo para atacar con un item
    {
        if (this.items.Contains(item)) //verifica si el item está asignado al personaje
        {
            if (item.Type == ItemType.Attack ||  item.Type == ItemType.attackDefense) //verifica si el item es de tipo ataque, ataque mágico o ataque-defensa
            {
                int damage = item.AttackValue; //se usa el valor de ataque del item
                Console.WriteLine($"{this.Name} ataca a {target.Name} con {item.Name} y causa {damage} de daño."); //se imprime un mensaje
                target.ReceiveDamage(damage); //se llama al metodo ReceiveDamage de la clase Chara
            }
            else
            {
                Console.WriteLine($"{item.Name} no puede ser usado para atacar."); //si el item no es de tipo ataque, se imprime un mensaje
            }
        }
        else
        {
            Console.WriteLine($"{this.Name} no tiene asignado el item {item.Name}."); //si el item no está asignado, se imprime un mensaje
        }
    }

    public void ReceiveDamage(int damage, IItem defenseItem = null)
    {
        if (defenseItem != null && (defenseItem.Type == ItemType.Defense || defenseItem.Type == ItemType.attackDefense))
        {
            int reducedDamage = damage - defenseItem.DefenseValue; // Reduce damage by defense value
            if (reducedDamage < 0) reducedDamage = 0; // Ensure damage is not negative
            this.Health -= reducedDamage; // Apply reduced damage to health
            if (this.Health < 0) this.Health = 0; // Ensure health is not negative
            Console.WriteLine($"{this.Name} se defiende con {defenseItem.Name} y recibe {reducedDamage} de daño. Vida restante: {this.Health}");
        }
        else
        {
            this.Health -= damage; // Apply full damage to health
            if (this.Health < 0) this.Health = 0; // Ensure health is not negative
            Console.WriteLine($"{this.Name} recibe {damage} de daño. Vida restante: {this.Health}");
        }
    }
    public void Heal()
    {
        this.health = this.maxhealth;
        Console.WriteLine($"{this.name} ha sido curado. Vida restaurada a: {this.health}");
    }

    public string GetInfo()
    {
        string info = $"Nombre: {this.name}, Vida: {this.health}\nItems:\n";
        foreach (IItem item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.AttackValue}, Defensa: {item.DefenseValue})\n";
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";
        info += $"Total Defensa: {this.TotalDefense()}\n";
        return info;
    }
}