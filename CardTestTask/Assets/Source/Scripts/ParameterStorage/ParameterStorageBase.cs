using System;

public abstract class ParameterStorageBase
{
    public abstract int Value { get; }
    public abstract ParametersType Type { get; }
    public abstract void ChangeValue(int value);
    public abstract event Action<int> ValueChanged;
}
