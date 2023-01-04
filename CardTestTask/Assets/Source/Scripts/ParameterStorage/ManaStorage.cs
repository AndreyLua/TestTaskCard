public class ManaStorage : DefaultParameterStorage
{
    public override ParametersType Type => ParametersType.Mana;
    public ManaStorage(int value) : base(value) { }
}
