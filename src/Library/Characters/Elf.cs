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
    
    public void AddItem(IItem item)        //metodo añadir item
    {
        if (item != null)
        {
            if (item is IMagicItem)
            {
                this.items.Add(item);
            }
        }
        else
        {
            Console.WriteLine("Ese item no existe");
        }
    }

    public void RemoveItem(IItem item)             //metodo quitar item
    {
        if (item != null)
        {
            this.items.Remove(item);
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
    
    public int TotalDamage() //metodo para calcular el daño total
    {
        int totalatk = 0; //se inicializa la variable totalatk en 0
        foreach (IItem item in this.items)//se recorre el arraylist de items
        {
            if (item is IAttackItem attackItem)
            {
                totalatk += attackItem.AttackValue; //se suma el valor de ataque de cada item
            }
        }
        return totalatk; //se retorna el valor total de ataque
    }
    public int TotalDefense() //metodo para calcular la defensa total
    {
        int totaldef = 0; //se inicializa la variable totaldef en 0
        foreach (IItem item in this.items) //se recorre el arraylist de items
        {
            if (item is IDefenseItem defenseItem)
            {
                totaldef += defenseItem.DefenseValue; //se suma el valor de defensa de cada item
            }
        } 
        return totaldef; //se retorna el valor total de defensa
    }

    public void Attack(Chara target) //metodo para atacar
    {
        int damage = this.TotalDamage(); //se calcula el daño total
        Console.WriteLine($"{this.Name} ataca a {target.Name} y causa {damage} de daño."); //se imprime un mensaje
        target.ReceiveDamage(damage);   //se llama al metodo ReceiveDamage de la clase Chara
       
    }

    
    public void ReceiveDamage(int damage) //metodo para recibir daño
    {
        int defensa = this.TotalDefense();
        int dañorecibido = damage - defensa;
        this.Health -= dañorecibido; //se resta el daño a la vida
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
        foreach (IAttackItem item in this.items)
        {
            info += $"- {item.Name} (Ataque: {item.AttackValue})\n";
        }
        foreach (IDefenseItem item in this.items)
        {
            info += $"- {item.Name} (Defensa: {item.DefenseValue})\n";
        }
        info += $"Total Ataque: {this.TotalDamage()}\n";
        info += $"Total Defensa: {this.TotalDefense()}\n";
        return info;
    }
}