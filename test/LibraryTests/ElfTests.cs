using Library;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class ElfTests
    {
        private Elf elf;
        private IItem defenseItem;
        private IItem attackItem;
        private IItem attackDefenseItem;
        private Elf target;

        [SetUp]
        public void Setup()
        {
            elf = new Elf("Legolas", 100);
            defenseItem = new Item("Shield", 0, 20, ItemType.Defense);
            attackItem = new Item("Bow", 30, 0, ItemType.Attack);
            attackDefenseItem = new Item("Sword", 15, 10, ItemType.attackDefense);
            target = new Elf("Thranduil", 100);
        }

        [Test]
        public void Test1() // Elf
        {
            Assert.That(elf.Name, Is.EqualTo("Legolas"));
            Assert.That(elf.Health, Is.EqualTo(100));
        }

        [Test]
        public void Test2() // Item
        {
            Item bow = new Item("Bow", 10, 3, ItemType.Attack);
            Assert.That(bow.Name, Is.EqualTo("Bow"));
            Assert.That(bow.AttackValue, Is.EqualTo(10));
            Assert.That(bow.DefenseValue, Is.EqualTo(0));
        }

        [Test]
        public void Test3() // GetInfo | AddItem | RemoveItem
        {
            Item bow = new Item("Bow", 10, 3, ItemType.Attack);
            elf.AddItem(bow);

            string result = elf.GetInfo();
            string expected = "Nombre: Legolas, Vida: 100\nItems:\n- Bow (Ataque: 10, Defensa: 0)\nTotal Ataque: 10\nTotal Defensa: 0\n";
            Assert.That(result, Is.EqualTo(expected));

            elf.RemoveItem(bow);

            result = elf.GetInfo();
            expected = "Nombre: Legolas, Vida: 100\nItems:\nTotal Ataque: 0\nTotal Defensa: 0\n";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test4() // Heal
        {
            elf.Health = 55;
            Assert.That(elf.Health, Is.EqualTo(55));

            elf.Heal();
            Assert.That(elf.Health, Is.EqualTo(100));
        }

        [Test]
        public void Test5() // TotalDamage | TotalDefense
        {
            Item bow = new Item("Bow", 10, 3, ItemType.Attack);
            Item amulet = new Item("Amulet", 5, 5, ItemType.attackDefense);
            Item cloak = new Item("Cloak", 0, 10, ItemType.Defense);

            elf.AddItem(bow);
            elf.AddItem(amulet);
            elf.AddItem(cloak);

            Assert.That(elf.TotalDamage(), Is.EqualTo(15));
            Assert.That(elf.TotalDefense(), Is.EqualTo(18));
        }

        [Test]
        public void Test6() // ReceiveDamage
        {
            elf.AddItem(defenseItem);
            elf.ReceiveDamage(50);
            Assert.That(elf.Health, Is.EqualTo(70));
        }

        [Test]
        public void Test7() // ReceiveDamage_ShouldNotReduceHealthBelowZero
        {
            elf.AddItem(defenseItem);
            elf.ReceiveDamage(150);
            Assert.That(elf.Health, Is.EqualTo(0));
        }

        [Test]
        public void Test8() // Attack
        {
            elf.AddItem(attackItem);
            elf.Attack(target, attackItem);
            Assert.That(target.Health, Is.EqualTo(70));
        }

        [Test]
        public void Test9() // attack con un item de defensa
        {
            elf.AddItem(defenseItem);
            elf.Attack(target, defenseItem);
            Assert.That(target.Health, Is.EqualTo(100));
        }
    }
}