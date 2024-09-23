namespace Library;

using System.Collections;

public class Wizard : Chara //se crea la clase Wizard que implementa la interfaz Chara
{
    private string name; //atributo nombre
    private int health; //atributo vida
    private int maxhealth; //atributo vida maxima/vida inicial
    private ArrayList items = new ArrayList(); //se crea un arraylist para los items
    private SpellTome spellTome; //se crea un atributo SpellTome

    public Wizard(string name, int vida, SpellTome spellTome) //constructor de la clase
    {
        this.name = name; //se asigna el nombre
        this.health = vida; //se asigna la vida
        this.maxhealth = vida; //se asigna la vida maxima/vida inicial
        this.spellTome = spellTome; //se asigna el SpellTome 
    }

    public string Name //metodo para poner o saber nombre
    {
        get { return name; }
        set { name = value; }
    }
    public int Health //metodo vida
    {
        get { return health; }
        set { health = value; }
    }
    public void AddItem(IItem item) //metodo añadir item
    {
        if (item != null)   //si el item existe
        {
            this.items.Add(item); //se añade el item al arraylist
        }
        else
        {
            Console.WriteLine("Ese item no existe"); //si el item no existe, se imprime un mensaje
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
    public int TotalDamage() //metodo para calcular el daño total
    {
        int totalatk = 0; //se inicializa la variable totalatk en 0
        foreach (IItem item in this.items) //se recorre el arraylist de items
        {
            totalatk += item.AttackValue; //se suma el valor de ataque de cada item
        }
        return totalatk; //se retorna el valor total de ataque
    }
    public int TotalDefense() //metodo para calcular la defensa total
    {
        int totaldef = 0; //se inicializa la variable totaldef en 0
        foreach (IItem item in this.items) //se recorre el arraylist de items
        {
            totaldef += item.DefenseValue; //se suma el valor de defensa de cada item
        } 
        return totaldef; //se retorna el valor total de defensa
    }

    public void Attack(Chara target, IItem item) //metodo para atacar con un item
    {
        if (this.items.Contains(item)) //verifica si el item está asignado al personaje
        {
            if (item.Type == ItemType.Attack || item.Type == ItemType.MagicAttack || item.Type == ItemType.attackDefense) //verifica si el item es de tipo ataque, ataque mágico o ataque-defensa
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
    

    public void UseSpell(Spell spell, Chara target) //metodo para usar hechizo
    {
        if (this.spellTome.ContainsSpell(spell)) //si el hechizo esta en el SpellTome
        {
            Console.WriteLine($"{this.name} usa {spell.Name} y causa {spell.Damage} de daño."); //se imprime un mensaje del nombre del mago y del hechizo y el daño
            target.ReceiveMagicDamage(spell.Damage); //se llama al metodo ReceiveDamage de la clase Chara
        }
        else
        {
            Console.WriteLine($"{this.name} no conoce el hechizo {spell.Name}."); //si el hechizo no esta en el SpellTome, se imprime un mensaje
        }
    }

    public void ReceiveDamage(int damage)
    {
        int totalDefenseValue = 0;

        // calcula el total de defensa
        foreach (IItem item in this.items)
        {
            if (item.Type == ItemType.Defense || item.Type == ItemType.attackDefense || item.Type == ItemType.magicDefense)
            {
                totalDefenseValue += item.DefenseValue;
            }
        }

        // Reduce el daño por el valor total de defensa
        int reducedDamage = damage - totalDefenseValue;
        if (reducedDamage < 0) reducedDamage = 0; // no permitir que el daño reducido sea negativo

        // aplicar el daño reducido a la vida
        this.Health -= reducedDamage;
        if (this.Health < 0) this.Health = 0; // no permitir que la vida sea negativa

        Console.WriteLine($"{this.Name} recibe {reducedDamage} de daño después de aplicar defensa. Vida restante: {this.Health}");
    }
    public void ReceiveMagicDamage(int damage)
    {
        this.Health -= damage;
        if (this.Health < 0) this.Health = 0;
        Console.WriteLine($"{this.name} recibe {damage} de daño. Vida restante: {this.Health}");
    }

    public void Heal() //metodo para curar
    {
        this.health = this.maxhealth; //se asigna la vida maxima a la vida
        Console.WriteLine($"{this.name} ha sido curado. Vida restaurada a: {this.health}"); //se imprime un mensaje
    }
    public string GetInfo() //metodo para obtener informacion
    {
        string info = $"Nombre: {this.name}, Vida: {this.health}\nItems:\n"; //se inicializa la variable info con el nombre y la vida
        foreach (IItem item in this.items) //se recorre el arraylist de items
        {
            info += $"- {item.Name} (Ataque: {item.AttackValue}, Defensa: {item.DefenseValue})\n"; //se agrega el nombre, ataque y defensa de cada item
        }
        info += $"Total Ataque: {this.TotalDamage()}\n"; //se agrega el total de ataque
        info += $"Total Defensa: {this.TotalDefense()}\n"; //se agrega el total de defensa
        info += this.spellTome.GetSpellsInfo(); //se agrega la informacion de los hechizos dentro del libro asignado
        return info;  //se retorna la informacion
    }
}