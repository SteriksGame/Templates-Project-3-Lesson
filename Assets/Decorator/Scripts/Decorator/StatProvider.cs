public class StatProvider : IStatProvider
{
    public Stat Stat { get; set; }

    public StatProvider(Stat stats) => Stat = stats;

    public int CalculationPower() => Stat.Power;
    public int CalculationIntellect() => Stat.Intellect;
    public int CalculationAgility() => Stat.Agility;
}