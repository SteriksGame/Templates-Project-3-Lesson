public class FlexibleStatProvider : IStatProvider
{
    private IStatProvider _statProvider;

    private const int DOP_AGILITY = 2;

    public FlexibleStatProvider(IStatProvider statProvider) => _statProvider = statProvider;

    public Stat Stat { get => _statProvider.Stat; set => _statProvider.Stat = value; }

    public int CalculationAgility()
    {
        _statProvider.Stat += new Stat(0, 0, DOP_AGILITY);
        return _statProvider.CalculationAgility();
    }

    public int CalculationIntellect() => _statProvider.CalculationIntellect();

    public int CalculationPower() => _statProvider.CalculationPower();
}
