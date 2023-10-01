public abstract class StatDecorator : IStatProvider
{
    protected readonly IStatProvider _provider;

    protected StatDecorator(IStatProvider provider) => _provider = provider;

    public Stat Stat { get => _provider.Stat; set => _provider.Stat = value; }

    abstract public Stat StatCalculation();
}
