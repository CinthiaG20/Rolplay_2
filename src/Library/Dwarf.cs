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
            if (item.Type == ItemType.Magic)
            {
                this.items.Remove(item);
            }
        }
        else
        {
            Console.WriteLine("Ese item no existe");
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

    public void Attack(Chara target)
    {
        int damage = this.TotalDamage();
        Console.WriteLine($"{this.Name} ataca a {target.Name} y causa {damage} de daño.");
        target.ReceiveDamage(damage);
    }

    public void ReceiveDamage(int damage)
    {
        this.Health -= damage;
        if (this.Health < 0) this.Health = 0;
        Console.WriteLine($"{this.name} recibe {damage} de daño. Vida restante: {this.Health}");
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