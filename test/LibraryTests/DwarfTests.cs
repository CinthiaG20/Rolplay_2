using Library;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class DwarfTests
    {
        private Dwarf dwarf;
        private IItem defenseItem;
        private IItem attackItem;
        private IItem attackDefenseItem;
        private Dwarf target;

        [SetUp]
        public void Setup()
        {
            dwarf = new Dwarf("Gimli", 100);
            defenseItem = new Item("Shield", 0, 20, ItemType.Defense);
            attackItem = new Item("Sword", 30, 0, ItemType.Attack);
            attackDefenseItem = new Item("Battle Axe", 15, 10, ItemType.attackDefense);
            target = new Dwarf("Thorin", 100);
        }

        [Test]
        public void Test1() // Dwarf
        {
            Assert.That(dwarf.Name, Is.EqualTo("Gimli"));
            Assert.That(dwarf.Health, Is.EqualTo(100));
        }

        [Test]
        public void Test2() // Item
        {
            Item axe = new Item("Axe", 10, 3, ItemType.Attack);
            Assert.That(axe.Name, Is.EqualTo("Axe"));
            Assert.That(axe.AttackValue, Is.EqualTo(10));
            Assert.That(axe.DefenseValue, Is.EqualTo(0));
        }

        [Test]
        public void Test3() // GetInfo | AddItem | RemoveItem
        {
            Item axe = new Item("Axe", 10, 3, ItemType.Attack);
            dwarf.AddItem(axe);

            string result = dwarf.GetInfo();
            string expected = "Nombre: Gimli, Vida: 100\nItems:\n- Axe (Ataque: 10, Defensa: 0)\nTotal Ataque: 10\nTotal Defensa: 0\n";
            Assert.That(result, Is.EqualTo(expected));

            dwarf.RemoveItem(axe);

            result = dwarf.GetInfo();
            expected = "Nombre: Gimli, Vida: 100\nItems:\nTotal Ataque: 0\nTotal Defensa: 0\n";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test4() // Heal
        {
            dwarf.Health = 55;
            Assert.That(dwarf.Health, Is.EqualTo(55));

            dwarf.Heal();
            Assert.That(dwarf.Health, Is.EqualTo(100));
        }

        [Test]
        public void Test5() // TotalDamage | TotalDefense
        {
            Item axe = new Item("Axe", 10, 3, ItemType.Attack);
            Item amulet = new Item("Amulet", 5, 5, ItemType.attackDefense);
            Item cloak = new Item("Cloak", 0, 10, ItemType.Defense);

            dwarf.AddItem(axe);
            dwarf.AddItem(amulet);
            dwarf.AddItem(cloak);

            Assert.That(dwarf.TotalDamage(), Is.EqualTo(15));
            Assert.That(dwarf.TotalDefense(), Is.EqualTo(18));
        }

        [Test]
        public void Test6() // ReceiveDamage
        {
            dwarf.AddItem(defenseItem);
            dwarf.ReceiveDamage(50);
            Assert.That(dwarf.Health, Is.EqualTo(70));
        }

        [Test]
        public void Test7() // ReceiveDamage_ShouldNotReduceHealthBelowZero
        {
            dwarf.AddItem(defenseItem);
            dwarf.ReceiveDamage(150);
            Assert.That(dwarf.Health, Is.EqualTo(0));
        }

        [Test]
        public void Test8() // Attack
        {
            dwarf.AddItem(attackItem);
            dwarf.Attack(target, attackItem);
            Assert.That(target.Health, Is.EqualTo(70));
        }

        [Test]
        public void Test9() // attack con un item de defensa
        {
            dwarf.AddItem(defenseItem);
            dwarf.Attack(target, defenseItem);
            Assert.That(target.Health, Is.EqualTo(100));
        }
    }
}