public class HumanStatProvider : IStatProvider
{
    private IStatProvider _statProvider;

    private const int DOP_INTELLECT = 5;

    public HumanStatProvider(IStatProvider statProvider) => _statProvider = statProvider;

    public Stat Stat
    {
        get => _statProvider.Stat;
        set => _statProvider.Stat = value;
    }

    public int CalculationAgility() => _statProvider.CalculationAgility();

    public int CalculationIntellect()
    {
        _statProvider.Stat += new Stat(0, DOP_INTELLECT, 0);
        return _statProvider.CalculationIntellect();
    }

    public int CalculationPower() => _statProvider.CalculationIntellect();
}