using Library;
using NUnit.Framework;

namespace LibraryTests
{
    [TestFixture]
    public class WizardsTest
    {
        private Wizard wizard;
        private SpellTome spellTome;
        private IItem defenseItem;
        private IItem attackItem;
        private IItem attackDefenseItem;
        private Spell fireballSpell;
        private Dwarf target;

        [SetUp]
        public void Setup()
        {
            spellTome = new SpellTome("Tome", ItemType.Magic);
            wizard = new Wizard("Gandalf", 100, spellTome);
            defenseItem = new Item("Shield", 0, 20, ItemType.Defense);
            attackItem = new Item("Sword", 30, 0, ItemType.Attack);
            attackDefenseItem = new Item("Battle Axe", 15, 10, ItemType.attackDefense);
            fireballSpell = new Spell("Fireball", 20);
            target = new Dwarf("Gimli", 100);
        }

        [Test]
        public void Test1() // Wizard
        {
            Assert.That(wizard.Name, Is.EqualTo("Gandalf"));
            Assert.That(wizard.Health, Is.EqualTo(100));
        }

        [Test]
        public void Test2() // Item
        {
            Item baston = new Item("Bastón Mágico", 10, 3, ItemType.MagicAttack);
            Assert.That(baston.Name, Is.EqualTo("Bastón Mágico"));
            Assert.That(baston.AttackValue, Is.EqualTo(10));
            Assert.That(baston.DefenseValue, Is.EqualTo(0));
        }

        [Test]
        public void Test3() // GetInfo | AddItem | RemoveItem
        {
            Item baston = new Item("Bastón Mágico", 10, 3, ItemType.MagicAttack);
            wizard.AddItem(baston);

            string result = wizard.GetInfo();
            string expected = "Nombre: Gandalf, Vida: 100\nItems:\n- Bastón Mágico (Ataque: 10, Defensa: 0)\nTotal Ataque: 10\nTotal Defensa: 0\nHechizos:\n";
            Assert.That(result, Is.EqualTo(expected));

            wizard.RemoveItem(baston);

            result = wizard.GetInfo();
            expected = "Nombre: Gandalf, Vida: 100\nItems:\nTotal Ataque: 0\nTotal Defensa: 0\nHechizos:\n";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Test4() // Heal
        {
            wizard.Health = 55;
            Assert.That(wizard.Health, Is.EqualTo(55));

            wizard.Heal();
            Assert.That(wizard.Health, Is.EqualTo(100));
        }

        [Test]
        public void Test5() // TotalDamage | TotalDefense
        {
            Item bastonigneo = new Item("Bastón de Fuego", 10, 3, ItemType.MagicAttack);
            Item amuleto = new Item("Amuleto mistico", 5, 5, ItemType.attackDefense);
            Item capain = new Item("Capa de Sigilo", 0, 10, ItemType.Defense);

            wizard.AddItem(bastonigneo);
            wizard.AddItem(amuleto);
            wizard.AddItem(capain);

            Assert.That(wizard.TotalDamage(), Is.EqualTo(15));
            Assert.That(wizard.TotalDefense(), Is.EqualTo(18));
        }

        [Test]
        public void Test6() // UseSpell
        {
            spellTome.AddSpell(fireballSpell);
            wizard.UseSpell(fireballSpell, target);
            Assert.That(target.Health, Is.EqualTo(80));
        }

        [Test]
        public void Test7() // ReceiveDamage
        {
            wizard.AddItem(defenseItem);
            wizard.ReceiveDamage(50);
            Assert.That(wizard.Health, Is.EqualTo(70));
        }

        [Test]
        public void Test8() // ReceiveDamage_ShouldNotReduceHealthBelowZero
        {
            wizard.AddItem(defenseItem);
            wizard.ReceiveDamage(150);
            Assert.That(wizard.Health, Is.EqualTo(0));
        }

        [Test]
        public void Test9() // Attack
        {
            wizard.AddItem(attackItem);
            wizard.Attack(target, attackItem);
            Assert.That(target.Health, Is.EqualTo(70));
        }

        [Test]
        public void Test10() // attack con un item de defensa
        {
            wizard.AddItem(defenseItem);
            wizard.Attack(target, defenseItem);
            Assert.That(target.Health, Is.EqualTo(100));
        }
    }
}