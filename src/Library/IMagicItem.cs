namespace Library;

public interface IMagicItem : IItem
{
    void AddSpell(Spell spell);
    string Spells();
}