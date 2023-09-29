public interface IStatProvider
{
    Stat Stat { get; set; }

    int CalculationPower();
    int CalculationIntellect();
    int CalculationAgility();
}
