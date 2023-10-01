public interface IStatProvider
{
    Stat Stat { get; set; }

    Stat StatCalculation();
}
