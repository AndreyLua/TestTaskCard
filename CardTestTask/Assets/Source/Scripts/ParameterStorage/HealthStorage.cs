using System;

public class HealthStorage : ParameterStorageBase
{
    private int _value;

    public event Action Died;
    public override event Action<int> ValueChanged;
    public override int Value => _value;
    public override ParametersType Type => ParametersType.Health;

    public HealthStorage(int value)
    {
        _value = value;
        ValueChanged?.Invoke(_value);
    }

    public override void ChangeValue(int value)
    {
        _value = value;
        ValueChanged?.Invoke(_value);
        if (_value < 0)
            Died?.Invoke();
    }
}
