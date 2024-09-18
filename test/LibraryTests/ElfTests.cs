using Library;

namespace LibraryTests;

public class ElfTests
{
    [Test]
    public void Test1()     // Elf
    {
        Elf elfo = new Elf("Legolas", 100);

        Assert.That(elfo.Name, Is.EqualTo("Legolas"));
        Assert.That(elfo.Health, Is.EqualTo(100));
    }

    [Test]
    public void Test2()     // Item
    {
        Item arco = new Item("Arco de yggdrasil", 12, 0);

        Assert.That(arco.Name, Is.EqualTo("Arco de yggdrasil"));
        Assert.That(arco.AttackValue, Is.EqualTo(12));
        Assert.That(arco.DefenseValue, Is.EqualTo(0));
    }

    [Test]
    public void Test3()     // GetInfo | AddItem | RemoveItem
    {
        Elf elfo = new Elf("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);
        elfo.AddItem(arco);

        string result = elfo.GetInfo();
        string expected = "Nombre: Legolas, Vida: 100\nItems:\n- Arco de yggdrasil (Ataque: 12, Defensa: 0)\nTotal Ataque: 12\nTotal Defensa: 0\n";
        Assert.That(result, Is.EqualTo(expected));

        elfo.RemoveItem(arco);

        result = elfo.GetInfo();
        expected = "Nombre: Legolas, Vida: 100\nItems:\nTotal Ataque: 0\nTotal Defensa: 0\n";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test4()     // Heal
    {
        Elf elfo = new Elf("Legolas", 100);
        elfo.Health = 55;

        Assert.That(elfo.Health, Is.EqualTo(55));

        elfo.Heal();

        Assert.That(elfo.Health, Is.EqualTo(100));
    }

    [Test]
    public void Test5()     // TotalDamage | TotalDefense
    {
        Elf elfo = new Elf("Legolas", 100);
        Item arco = new Item("Arco de yggdrasil", 12, 0);
        Item tunicaElfica = new Item("Túnica Élfica", 0, 8);

        elfo.AddItem(arco);
        elfo.AddItem(tunicaElfica);

        Assert.That(elfo.TotalDamage(), Is.EqualTo(12));
        Assert.That(elfo.TotalDefense(), Is.EqualTo(8));
    }
}