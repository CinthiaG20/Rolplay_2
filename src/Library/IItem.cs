namespace Library;

public interface IItem
{
    string Name { get; set; }
    int AttackValue { get; set; }
    int DefenseValue { get; set; }
    ItemType Type { get; set; }
}