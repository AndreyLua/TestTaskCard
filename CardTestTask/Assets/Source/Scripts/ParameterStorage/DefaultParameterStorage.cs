using System;

public abstract class DefaultParameterStorage : ParameterStorageBase
{
    private int _value;

    public override int Value => _value;
    public override event Action<int> ValueChanged;

    public DefaultParameterStorage(int value)
    {
        _value = value;
        ValueChanged?.Invoke(_value);
    }

    public override void ChangeValue(int value)
    {
        _value = value;
        ValueChanged?.Invoke(_value);
    }
}
