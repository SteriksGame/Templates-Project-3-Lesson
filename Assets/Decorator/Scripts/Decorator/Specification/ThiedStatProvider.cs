public class ThiedStatProvider : IStatProvider
{
    private IStatProvider _statProvider;

    private const int DOP_AGILITY = 5;

    public ThiedStatProvider(IStatProvider statProvider) => _statProvider = statProvider;

    public Stat Stat 
    { 
        get => _statProvider.Stat; 
        set => _statProvider.Stat = value; 
    }

    public int CalculationAgility()
    {
        _statProvider.Stat += new Stat(0, 0, DOP_AGILITY);
        return _statProvider.CalculationAgility();
    }

    public int CalculationIntellect() => _statProvider.CalculationIntellect();

    public int CalculationPower() => _statProvider.CalculationPower();
}