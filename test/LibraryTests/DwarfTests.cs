using Library;

namespace LibraryTests;

public class DwarfTests
{
    [Test]
    public void Test1()     // Dwarf
    {
        Dwarf enano = new Dwarf("Gimli", 100);

        Assert.That(enano.Name, Is.EqualTo("Gimli"));
        Assert.That(enano.Health, Is.EqualTo(100));
    }

    [Test]
    public void Test2()     // Item
    {
        Item martilloDeGuerra = new Item("Martillo de Guerra", 15, 5);

        Assert.That(martilloDeGuerra.Name, Is.EqualTo("Martillo de Guerra"));
        Assert.That(martilloDeGuerra.AttackValue, Is.EqualTo(15));
        Assert.That(martilloDeGuerra.DefenseValue, Is.EqualTo(5));
    }

    [Test]
    public void Test3()     // GetInfo | AddItem | RemoveItem
    {
        Dwarf enano = new Dwarf("Gimli", 100);
        Item martilloDeGuerra = new Item("Martillo de Guerra", 15, 5);
        enano.AddItem(martilloDeGuerra);

        string result = enano.GetInfo();
        string expected = "Nombre: Gimli, Vida: 100\nItems:\n- Martillo de Guerra (Ataque: 15, Defensa: 5)\nTotal Ataque: 15\nTotal Defensa: 5\n";
        Assert.That(result, Is.EqualTo(expected));

        enano.RemoveItem(martilloDeGuerra);

        result = enano.GetInfo();
        expected = "Nombre: Gimli, Vida: 100\nItems:\nTotal Ataque: 0\nTotal Defensa: 0\n";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test4()     // Heal
    {
        Dwarf enano = new Dwarf("Gimli", 100);
        enano.Health = 55;

        Assert.That(enano.Health, Is.EqualTo(55));

        enano.Heal();

        Assert.That(enano.Health, Is.EqualTo(100));
    }

    [Test]
    public void Test5()     // TotalDamage | TotalDefense
    {
        Dwarf enano = new Dwarf("Gimli", 100);
        Item martilloDeGuerra = new Item("Martillo de Guerra", 15, 5);
        Item armaduraValiriana = new Item("Armadura Valiriana", 0, 20);

        enano.AddItem(martilloDeGuerra);
        enano.AddItem(armaduraValiriana);

        Assert.That(enano.TotalDamage(), Is.EqualTo(15));
        Assert.That(enano.TotalDefense(), Is.EqualTo(25));
    }
}