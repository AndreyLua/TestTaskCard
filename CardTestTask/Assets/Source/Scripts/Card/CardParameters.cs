public struct CardParameters
{
    private int _health;
    private int _mana;
    private int _attack;

    public int Health =>_health;
    public int Attack => _attack;
    public int Mana => _mana;

    public CardParameters(int mana, int health, int attack)
    {
        _mana = mana;
        _health = health;
        _attack = attack;
    }
}
