using System.Security.Cryptography;
using System.Collections;

namespace Library;

public class Elf : Chara
{
    private string name;            //atributo nombre
    private int health;
    private int maxhealth;
    private ArrayList items = new ArrayList();
    
    public Elf(string name, int maxhealth)          //metodo constructor
    {
        this.Name = name;                   //toma el string para el nombre
        this.maxhealth = maxhealth;         //toma el entero dado para que sea la vida maxima
        this.Health = maxhealth;            //le da el mismo valor a la vida actual
    }
    public string Name              //metodo para poner o saber nombre
    {
        get { return name;}
        set { name = value;}
    }
    public int Health               //metodo vida
    {
        get { return health;}
        set { health = value;}
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

    public IItem GetItemByName(string nombre)        //metodo buscar item por nombre
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
    
    public int TotalDamage()                //Metodo Daño total
    {
        int totalatk = 0;       //inicia una variabe
        foreach (IItem item in this.items)
        {
            totalatk += item.AttackValue;
        }                               //suma al ataque total todos los valores de ataque de los items
        return totalatk;        //devuelve el total
    }
    
    public int TotalDefense()               //Metodo Daño total
    {
        int totaldef = 0;       //inicia una variable
        foreach (IItem item in this.items)
        {
            totaldef += item.DefenseValue;
        }                          
        return totaldef;        //devuelve la defensa total
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

    public void ReceiveDamage(int damage) //metodo para recibir daño
    {
        this.Health -= damage; //se resta el daño a la vida
        if (this.Health < 0) this.Health = 0; //si la vida es menor a 0, se asigna 0
        Console.WriteLine($"{this.name} recibe {damage} de daño. Vida restante: {this.Health}"); //se imprime un mensaje
    }
    public void Heal() //metodo para curar
    {
        this.health = this.maxhealth; //se asigna la vida maxima a la vida
        Console.WriteLine($"{this.name} ha sido curado. Vida restaurada a: {this.health}"); //se imprime un mensaje
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