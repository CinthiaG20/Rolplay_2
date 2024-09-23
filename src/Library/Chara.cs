namespace Library;

public interface Chara
{
    string Name { get; }
    int Health { get; }
    void Heal();
    void AddItem(IItem item);
    int TotalDefense();
    void ReceiveDamage(int damage);
    void ReceiveMagicDamage(int damage);
}

