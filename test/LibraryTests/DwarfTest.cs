using Library;
namespace LibraryTests;

public class DwarfTest
{
    [Test]
    public void Testpersonaje()     // Dwarf
    {
        Dwarf enano = new Dwarf("Enano", 10);
        
        Assert.That(enano.Name, Is.EqualTo("Enano"));
        Assert.That(enano.Health, Is.EqualTo(10));
    }

    [Test]
    public void TestItem()     // Item
    {
        Item martillo = new Item("Martillo", 15, 10);

        Assert.That(martillo.Name, Is.EqualTo("Martillo"));
        Assert.That(martillo.AttackValue, Is.EqualTo(15));
        Assert.That(martillo.DefenseValue, Is.EqualTo(10));
    }
    
    [Test]
    public void Test3()     // GetInfo | AddItem | RemoveItem
    {
        Dwarf enano = new Dwarf("Enano", 100);
        Item martillo = new Item("Martillo", 15, 10);
        enano.AddItem(martillo);
        
        string result = enano.GetInfo();
        string expected = "Nombre: Enano, Vida: 100\nItems:\n- Martillo (Ataque: 15, Defensa: 10)\nTotal Ataque: 15\nTotal Defensa: 10\n";
        Assert.That(result, Is.EqualTo(expected));
        
        enano.RemoveItem(martillo);
        
        result = enano.GetInfo();
        expected = "Nombre: Enano, Vida: 100\nItems:\nTotal Ataque: 0\nTotal Defensa: 0\n";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Testheal()     // Heal
    {
        Dwarf enano = new Dwarf("Enano", 100);
        enano.Health = 50;
        
        Assert.That(enano.Health, Is.EqualTo(50));
        
        enano.Heal();
        
        Assert.That(enano.Health, Is.EqualTo(100));
    }

    [Test]
    public void TestDamage()     // TotalDamage | TotalDefense
    {
        Dwarf enano = new Dwarf("Enano", 100);
        Item martillo = new Item("Martillo", 10, 3);
        Item espada = new Item("Espada", 5, 5);
        Item hacha = new Item("Hacha", 0, 10);
        
        Assert.That(enano.TotalDamage(), Is.EqualTo(0));
        Assert.That(enano.TotalDefense(), Is.EqualTo(0));
    }
}