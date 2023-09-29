public class BarbarStatProvider : IStatProvider
{
    private IStatProvider _statProvider;

    private const int DOP_POWER = 5;

    public BarbarStatProvider(IStatProvider statProvider) => _statProvider = statProvider;

    public Stat Stat { get => _statProvider.Stat; set => _statProvider.Stat = value; }

    public int CalculationAgility() => _statProvider.CalculationAgility();

    public int CalculationIntellect() => _statProvider.CalculationIntellect();

    public int CalculationPower()
    {
        _statProvider.Stat += new Stat(DOP_POWER, 0, 0);
        return _statProvider.CalculationPower();
    }
}