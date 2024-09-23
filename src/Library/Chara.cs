namespace Library;

public interface Chara //crea la interfaz Chara
{
    string Name { get; }
    int Health { get; }
    void Heal();
    void AddItem(IItem item);
    int TotalDefense();
    void ReceiveDamage(int damage);
    void ReceiveMagicDamage(int damage);
}

