namespace Library;

public interface Chara
{ 
  string Name { get; }
  int Health { get; }
  int TotalDefense();
  void ReceiveDamage(int damage);

}