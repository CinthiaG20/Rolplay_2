using Library;

namespace LibraryTests;

public class WizardsTest
{
    [Test]
    public void Test1()     // Wizard
    {
        SpellTome spellTome = new SpellTome("Tome", ItemType.Magic);
        Wizard mago = new Wizard("Gandalf", 100, spellTome);
        
        Assert.That(mago.Name, Is.EqualTo("Gandalf"));
        Assert.That(mago.Health, Is.EqualTo(100));
    }

    [Test]
    public void Test2()     // Item
    {
        Item baston = new Item("Bastón Mágico", 10, ItemType.Magic);

        Assert.That(baston.Name, Is.EqualTo("Bastón Mágico"));
        Assert.That(baston.AttackValue, Is.EqualTo(10));
        Assert.That(baston.DefenseValue, Is.EqualTo(10));
    }
    
    [Test]
    public void Test3()     // GetInfo | AddItem | RemoveItem
    {
        SpellTome spellTome = new SpellTome("Tome",  ItemType.Magic);
        Wizard mago = new Wizard("Gandalf", 100, spellTome);
        Item baston = new Item("Bastón Mágico", 10, ItemType.Magic);
        mago.AddItem(baston);
        
        string result = mago.GetInfo();
        string expected = "Nombre: Gandalf, Vida: 100\nItems:\n- Bastón Mágico (Ataque: 10, Defensa: 10)\nTotal Ataque: 10\nTotal Defensa: 10\nHechizos:\n";
        Assert.That(result, Is.EqualTo(expected));
        
        mago.RemoveItem(baston);
        
        result = mago.GetInfo();
        expected = "Nombre: Gandalf, Vida: 100\nItems:\nTotal Ataque: 0\nTotal Defensa: 0\nHechizos:\n";
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test4()     // Heal
    {
        SpellTome spellTome = new SpellTome("Tome", ItemType.Magic);
        Wizard mago = new Wizard("Gandalf", 100, spellTome);
        mago.Health = 55;
        
        Assert.That(mago.Health, Is.EqualTo(55));
        
        mago.Heal();
        
        Assert.That(mago.Health, Is.EqualTo(100));
    }

    [Test]
    public void Test5()     // TotalDamage | TotalDefense
    {
        SpellTome spellTome = new SpellTome("Tome", ItemType.Magic);
        Wizard mago1 = new Wizard("Sauron", 100, spellTome);
        Item bastonigneo = new Item("Bastón de Fuego", 10, ItemType.Magic);
        Item amuleto = new Item("Amuleto mistico", 5, ItemType.Magic);
        Item capain = new Item("Capa de Sigilo", 0, ItemType.Magic);
        
        mago1.AddItem(bastonigneo);
        mago1.AddItem(amuleto);
        mago1.AddItem(capain);
        
        Assert.That(mago1.TotalDamage(), Is.EqualTo(15));
        Assert.That(mago1.TotalDefense(), Is.EqualTo(15));
    }

    [Test]
    public void Test6()     // UseSpell
    {
        Spell bolaDeFuego = new Spell("Bola de Fuego", 20);
        SpellTome spellTome = new SpellTome("Tome", ItemType.Magic);
        spellTome.AddSpell(bolaDeFuego);
        Wizard mago = new Wizard("Gandalf", 100, spellTome);
        Dwarf enano = new Dwarf("Gimli", 100);

        mago.UseSpell(bolaDeFuego, enano);

        Assert.That(enano.Health, Is.EqualTo(80));
    }
}