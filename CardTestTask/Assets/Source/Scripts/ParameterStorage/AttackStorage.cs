public class AttackStorage : DefaultParameterStorage
{
    public override ParametersType Type => ParametersType.Attack;

    public AttackStorage(int value) : base(value) { }
}
